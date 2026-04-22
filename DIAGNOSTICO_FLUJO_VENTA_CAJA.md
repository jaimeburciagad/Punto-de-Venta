# Diagnostico Del Flujo De Venta Y Caja

Fecha del levantamiento: 2026-04-19

## Alcance

Este documento cruza:

- Codigo VB.NET del proyecto.
- Esquema real de la base `ecventa`.
- Procedimientos almacenados y tipos tabla usados por el flujo de venta.
- Flujos auxiliares relacionados: pagos, cancelacion, devoluciones, impresion y cotizaciones.

El objetivo es distinguir:

- Que flujo esta vivo hoy.
- Que flujo es legado pero sigue en el repo.
- Que contratos entre app y base ya no coinciden.
- Que tendria que tocarse para implementar venta por caja real con `F6`.

## Resumen Ejecutivo

Hoy existen dos mundos al mismo tiempo:

1. Un flujo nuevo en `FrCambio` que guarda la venta de forma transaccional usando TVPs y SPs:
   - `sp_InsertarVenta_DetalleUPC`
   - `sp_InsertarVenta_Agrupado`
   - `sp_InsertarVenta_Vales`
   - y despues llama `APLICAVENTAINVENTARIO`

2. Un flujo viejo en `FrVenta` que arma `TMPAUXVTA` y `TMPAUXVTA1`, inserta directamente en:
   - `ECVENTA`
   - `ECDETVENTA`
   - `ECVENTADETE`
   - `ECVENTADET`
   - y tambien termina llamando `APLICAVENTAINVENTARIO`

El flujo vivo encontrado por caller real es el nuevo de `FrCambio`.

El problema central para venta por caja es este:

- `FueConF6` si llega a `ECVENTADET`.
- Pero ninguna logica SQL viva usa `FueConF6` para convertir la salida a piezas o descargar inventario real por contenido de caja.
- `APLICAVENTAINVENTARIO` no mueve inventario fisico; solo alimenta tablas de estadistica.
- Los SPs que si tocan inventario fisico (`APLICAVENTASINV`, `APLVENTAPEPS`) existen en la base, pero no aparecen conectados al flujo vivo encontrado en el codigo.

## Flujo Vivo Encontrado En Codigo

### 1. Inicio y contexto

- `FrLogin` construye `sCadenaConexionSQL` a partir de `CONFIGPV.TXT`.
- `SP_CREATURNO` se usa para abrir/activar turno.

Ubicaciones:

- `Conexion\\FORMAS\\FrLogin.vb`
- `CONFIGPV.TXT`

### 2. Captura de venta en `FrVenta`

`FrVenta` hoy funciona como captura y staging.

Puntos relevantes:

- `F6` activa `VentaCajaVirtual`.
- El color de `TX_UPC` cambia para indicar el modo.
- Al agregar articulo, si `VentaCajaVirtual = True` y el articulo viene como pieza (`Factor = 1`), calcula contenido con `art_cap1 * art_cap2`.
- Marca el item como `EsCajaVirtual = True`.
- Calcula precio por caja usando `ART_PRECIO3 * Factor`.

Persistencia/staging usada por la pantalla viva:

- `TMPAUXVTA2`

Usos de `TMPAUXVTA2` en la captura:

- cuenta pendiente pendiente de recuperar
- cotizacion -> carga a venta
- cambios de cantidad
- vales
- cambios de tipo de venta / cliente
- subconsultas de ofertas por articulo y clave

### 3. Cierre de venta en `FrCambio`

Al confirmar con `F10`, `FrVenta` abre `FrCambio`.

El handler vivo es:

- `FrCambio.btn_continuar_Click`

Ese handler:

1. Abre una transaccion SQL.
2. Obtiene folio con `dasigfolio`.
3. Inserta encabezado en `ECVENTA`.
4. Inserta `LigasFolios`.
5. Inserta `ECDETVENTATEL` si hay tiempo aire.
6. Genera tres TVPs desde el grid vivo:
   - `ECVENTADET` por UPC
   - `ECDETVENTA` agrupado para impresion
   - `ECVENTADETE` para vales
7. Guarda pagos:
   - `ECFORMAPAGO`
   - `ECTARJETAS`
   - `ECTRANSFER`
   - `ECCUENTASXCOB`
8. Inserta relacion cliente-ticket en `TicketsClientes`.
9. Ejecuta `APLICAVENTAINVENTARIO @ticket, 1`.
10. Hace `COMMIT`.

### 4. Impresion y post-proceso

Despues del commit:

- `preImpresion` lee `ECVENTA`, `ECDETVENTA`, `TicketsClientes`, `ECCLIENTES`, `ECFORMAPAGO`.
- `previrtual` lee `ECVENTA` y `ECVENTADETE`.
- Si hay credito se imprime pagare.
- Si hay tiempo aire se actualiza `ECDETVENTATEL`.

## Flujo Legado Todavia Presente En El Repo

En `FrVenta` siguen existiendo funciones que:

1. Arman `TMPAUXVTA`.
2. Arman `TMPAUXVTA1`.
3. Insertan manualmente en:
   - `ECVENTA`
   - `ECVENTADETE`
   - `ECDETVENTA`
   - `ECVENTADET`
4. Ejecutan `APLICAVENTAINVENTARIO`.

Estas funciones siguen definidas:

- `GuardaTicketConHandler`
- `GuardaFormaDePagoConHandler`
- versiones `Original`

Pero el caller vivo actual del boton continuar esta en `FrCambio`, no en ese flujo viejo. En `FrCambio` incluso existe un `btn_continuar_ClickOriginal` sin `Handles`, lo cual confirma la migracion parcial hacia el flujo transaccional nuevo.

## Contrato Real Entre App Y Base

### Tablas staging

#### `TMPAUXVTA`

Uso legado para resumen por articulo/impresion.

Columnas relevantes:

- `TMP_USUARIO`
- `TMP_CANTIDAD`
- `TMP_ARTICULO`
- `TMP_DSCART`
- `TMP_PRECIO`
- `TMP_TOTAL`
- `TMP_IVA`
- `TMP_IEPS`
- `TMP_FAMILIA`
- `TMP_COSTO`

#### `TMPAUXVTA1`

Uso legado para detalle por UPC/inventario.

Columnas relevantes:

- `TMP_USUARIO`
- `TMP_CANTIDAD`
- `TMP_ARTICULO`
- `TMP_DSCART`
- `TMP_PRECIO`
- `TMP_TOTAL`
- `TMP_UPC`
- `TMP_PORIVA`
- `TMP_IVA`
- `TMP_FAMILIA`
- `FueConF1`
- `FueConF2`
- `FueConF3`
- `TMP_PORIEPS`
- `TMP_IEPS`
- `TMP_COSTOU`

#### `TMPAUXVTA2`

Uso vivo en la captura actual.

Columnas reales encontradas en produccion:

- `renglon`
- `usuario`
- `articulo`
- `cantidad`
- `tipo`
- `FueConF1`
- `FueConF2`
- `FueConF3`
- `ClienteID`
- `ArtClave`
- `TraeVale`

No existen en la base viva:

- `FueConF6`
- `Factor`

Observacion:

- `TraeVale` aparece como columna 13. Eso sugiere que historicamente ya hubo columnas intermedias eliminadas o movidas.

### Tablas finales

#### `ECVENTA`

Encabezado del ticket.

#### `ECDETVENTA`

Detalle para impresion/resumen por articulo.

Se llena via:

- `sp_InsertarVenta_Agrupado`

TVP asociado:

- `dbo.TipoDetalleAgrupado`

No incluye `FueConF6`.

#### `ECVENTADET`

Detalle por UPC usado por inventario y estadisticas.

Se llena via:

- `sp_InsertarVenta_DetalleUPC`

TVP asociado:

- `dbo.TipoDetalleUPC`

Si incluye:

- `FueConF6`

No incluye `Factor`.

#### `ECVENTADETE`

Detalle de vales/mercancia pendiente.

Se llena via:

- `sp_InsertarVenta_Vales`

TVP asociado:

- `dbo.TipoDetalleVales`

### Otras tablas del flujo

- `LigasFolios`
- `TicketsClientes`
- `ECFORMAPAGO`
- `ECTARJETAS`
- `ECTRANSFER`
- `ECCUENTASXCOB`
- `ECDETVENTATEL`
- `ECCANCXUPC`

## Procedimientos Y Tipos Tabla Reales

### TVPs

#### `dbo.TipoDetalleUPC`

Columnas:

- `dve_articulo`
- `dve_upc`
- `dve_precio`
- `dve_cantidad`
- `dve_total`
- `dve_poriva`
- `dve_iva`
- `dve_costou`
- `dve_costo`
- `dve_familia`
- `dve_renglon`
- `FueConF1`
- `FueConF2`
- `FueConF3`
- `FueConF6`
- `dve_porieps`
- `dve_ieps`

#### `dbo.TipoDetalleAgrupado`

Columnas:

- `dve_articulo`
- `dve_precio`
- `dve_cantidad`
- `dve_poriva`
- `dve_iva`
- `dve_costou`
- `dve_costo`
- `dve_familia`
- `dve_renglon`
- `dve_porieps`
- `dve_ieps`

#### `dbo.TipoDetalleVales`

Columnas:

- `dve_articulo`
- `dve_upc`
- `dve_cantidad`
- `dve_precio`
- `dve_total`

### SPs vivos en el guardado nuevo

#### `dasigfolio`

Responsabilidad:

- Aumenta folio general en `ECCONTROLVENTA`.
- Actualiza `TMPCONSECU` para folio por caja.
- Devuelve:
  - `FolioN`
  - `FolioCaja`

#### `sp_InsertarVenta_DetalleUPC`

Responsabilidad:

- Inserta `ECVENTADET` desde `TipoDetalleUPC`.
- Persiste `FueConF6`.

#### `sp_InsertarVenta_Agrupado`

Responsabilidad:

- Inserta `ECDETVENTA` desde `TipoDetalleAgrupado`.

#### `sp_InsertarVenta_Vales`

Responsabilidad:

- Inserta `ECVENTADETE` desde `TipoDetalleVales`.

#### `SP_CREATURNO`

Responsabilidad:

- Determina turno 1 o 2 por caja.
- Inserta o reactiva registro en `ECHISTURNO`.

## Inventario: Lo Que Realmente Hace La Base

### `APLICAVENTAINVENTARIO`

Lee:

- `ECVENTADET`

Y llama:

- `APLICAMOVTOSMES`
- `APLICAMOVTOSSEMANA`
- `APLICAMOVTOSFECHA`
- `APLICAMOVTOSFECHACORTE`

Importante:

- Solo usa `DVE_UPC`, `DVE_ARTICULO`, `DVE_CANTIDAD`, `DVE_TOTAL`.
- No usa `FueConF6`.
- No usa `Factor`.
- No toca `ECINVENTARIOS`.
- No toca `ECINVENTARIOSD`.

### `APLICAMOVTOS*`

Los cuatro procedimientos actualizan tablas de estadistica:

- `ESTXFECHA`
- `ESTXMES`
- `ESTXSEMANA`
- `ESTXCORTEINVENTARIO`

Tipos observados:

- `1`: venta
- `3`: devolucion
- `4`: cancelacion
- `5`, `6`, `7`: ajustes

Estos procedimientos consideran `ECCANCXUPC` para restar devoluciones al cancelar, pero siguen siendo estadistica, no descarga fisica de inventario.

### Procedimientos de inventario fisico existentes pero desconectados

#### `APLICAVENTASINV`

Si toca:

- `ECINVENTARIOS`
- `ECVENTADET`
- `ECVENTA`
- `XUPC`
- `ARTICULO`

Ademas:

- Convierte cantidades cuando `ART_CODREL` existe.
- Usa `ART_CAP1` y `ART_CAP2`.
- Actualiza costo unitario y costo total en `ECVENTADET`.

#### `APLVENTAPEPS`

Si toca:

- `ECINVENTARIOSD`
- `ECVENTADET`
- `ECVENTADETI`
- `XUPC`
- `ARTICULO`

Responsabilidad:

- Aplicacion PEPS por lotes / referencias.

### Hallazgo clave

No se encontro referencia activa desde el flujo nuevo hacia:

- `APLICAVENTASINV`
- `APLVENTAPEPS`

Eso sugiere que hoy el flujo vivo:

- registra venta
- registra pagos
- registra estadistica por fecha/mes/semana/corte

pero no muestra evidencia de aplicar descarga fisica con esos procedimientos desde el camino nuevo encontrado en la app.

## F6 / Caja Virtual

### Lo que si hace hoy

En la app:

- `F6` activa modo caja virtual.
- Cambia visualmente el control de captura.
- Para articulos que vienen como pieza, calcula contenido con `art_cap1 * art_cap2`.
- Marca el item con `EsCajaVirtual = True`.
- Manda `FueConF6 = 1` al grid y al guardado final en `ECVENTADET`.

En la base:

- `TipoDetalleUPC` tiene columna `FueConF6`.
- `ECVENTADET` tiene columna `FueConF6`.
- `sp_InsertarVenta_DetalleUPC` la persiste.

### Lo que no hace hoy

- Ningun SP vivo usa `FueConF6` para transformar la cantidad.
- No existe `Factor` en `ECVENTADET`.
- No existe `Factor` en `TipoDetalleUPC`.
- `APLICAVENTAINVENTARIO` no usa `FueConF6`.
- `APLICAVENTAINVENTARIO` no conoce `art_cap1/art_cap2`.

### Conclusion funcional de F6

Hoy `F6` sirve para:

- logica de captura
- precio por caja
- trazabilidad parcial en `ECVENTADET`

Pero no alcanza para:

- descargar inventario por contenido real de caja virtual
- alimentar PEPS como caja virtual
- dejar una conversion explicita persistida para procesos posteriores

## Existencias: Hallazgo Clave

### `FrBuscaArt` y la existencia por articulo

La app, al mostrar existencia en busqueda, hace esto:

1. Resuelve el articulo/base.
2. Si viene por esquema legacy con `art_codrel`, se brinca al padre.
3. Ejecuta:
   - `exec calcexistencianxart @usuario, @articulo`
4. Lee el resultado desde:
   - `ExistenciasArticuloActualizadas`
5. Presenta la existencia visual dividida entre:
   - `art_cap1 * art_cap2`

Eso significa que el calculo de existencia visual no sale directo de `ECVENTADET`, sino de:

- `ESTXCORTEINVENTARIO`
- `tmp1`
- `ecteoricas`
- `ExistenciasArticuloActualizadas`

### `calcexistencianxart`

Este procedimiento ya fue modificado para contemplar dos rutas:

1. Legacy:
   - si `art_codrel <> ''`
   - agrupa al primer UPC del padre usando `DaPrimerCodigo(art_codrel)`
   - convierte con `daconversion(art_clave)`

2. Caja nueva:
   - si `xupc.upc_factor > 1`
   - agrupa visualmente al `xupc.upc_codinv`
   - multiplica ventas/devoluciones/cancelaciones por `xupc.upc_factor`

Este hallazgo es importante porque demuestra que en la capa de existencias ya existe un modelo mas moderno:

- no necesita un articulo hijo distinto en `ARTICULO`
- le basta con un UPC distinto en `XUPC` y un `upc_factor`

### Aclaracion De Nombres

Estos dos procedimientos no son el mismo:

- `calcexistencianxart`
- `calcexistenciasnxart`

La diferencia parece minima, pero es importante:

- `calcexistencianxart` es el que si vi modificado con logica de `xupc.upc_factor`.
- `calcexistenciasnxart` sigue en logica legacy con `art_codrel` y `daconversion`.

### `calcexistenciasn`

Aqui esta la desalineacion fuerte:

- `calcexistenciasn`
- `calcexistenciasnxart`

todavia usan solo la logica legacy:

- `art_codrel`
- `DaPrimerCodigo`
- `daconversion`

No usan:

- `xupc.upc_factor`

Por eso hoy tienes una inconsistencia:

- la existencia puntual por articulo (`calcexistencianxart`) ya entiende cajas nuevas por factor
- el calculo global (`calcexistenciasn`) no
- la variante por articulo `calcexistenciasnxart` tampoco

### Funciones helper

- `daconversion(articulo)` = `art_cap2 / art_cap1`
- `DaPrimerCodigo(articulo)` = devuelve el UPC principal donde `upc_codinv = upc_upc`

### Vistas

`ExistenciasArticuloActualizadas` no recalcula nada especial.

Solo expone:

- `ecteoricas`
- mas agregados de almacenes, sucursales y custodias

O sea:

- la decision de convertir o agrupar ocurre antes, dentro de `calcexistencianxart` / `calcexistenciasn`

## Recomendacion De Diseño Para Caja Virtual

### Pregunta central

¿Conviene guardar la estadistica como caja o convertirla de inmediato a piezas?

Mi recomendacion es:

- guardar el movimiento como la presentacion vendida
- pero identificar esa presentacion con un UPC propio
- y convertir a la presentacion padre durante el calculo de existencia/estadistica

En otras palabras:

- no guardaria la estadistica ya convertida y mezclada con la pieza
- tampoco me apoyaria solo en `FueConF6`
- usaria un `UPC virtual de caja`

### Por que

Porque con el modelo actual de `ESTX*`, el movimiento estadistico guarda:

- `UPC`
- `CVEART`
- cantidad
- monto

Si la venta virtual se guarda con el mismo UPC de la pieza:

- despues ya no puedes distinguir si fue pieza o caja virtual
- `FueConF6` no llega a `ESTX*`
- `APLICAMOVTOS*` no conoce factor

En cambio, si la venta de caja virtual usa un UPC distinto:

- si queda trazada como presentacion propia
- las tablas de estadistica mantienen historia limpia
- el calculo de existencia puede decidir como agruparla
- no obligas a meter columnas nuevas en `ESTX*`

### Como seria ese UPC virtual

La opcion menos invasiva es:

- crear una fila en `XUPC`
- con el mismo `upc_cveart` del articulo padre
- con `upc_upc` interno/sintetico
- con `upc_codinv` apuntando al UPC padre de pieza
- con `upc_factor = contenido de caja`

Eso te da una presentacion virtual sin crear un `ARTICULO` hijo nuevo.

### Ventaja importante

Ese modelo ya es compatible con la idea que aparece en:

- `FrVenta`, que ya lee `xupc.upc_factor`
- `calcexistencianxart`, que ya sabe agrupar por `upc_codinv` y multiplicar por `upc_factor`

### Implicacion practica

Para que funcione bien de punta a punta, la venta por `F6` no deberia quedarse solo con:

- mismo `UPC`
- mismo `ART_CLAVE`
- bandera `FueConF6`

Sino cambiar el `UPC` del renglon vendido al `UPC virtual` correspondiente.

### Que no me convence

No me convence basar toda la solucion en:

- `FueConF6`
- mas `Factor` en staging
- conversion en caliente sin UPC diferenciado

porque eso obliga a:

- modificar `APLICAMOVTOS*`
- modificar `ESTX*`
- o aceptar que la estadistica ya no podra distinguir caja vs pieza

### Mi recomendacion final

Si buscamos la ruta con menor friccion contra la arquitectura existente:

1. Caja virtual debe comportarse como un UPC virtual, no como solo una bandera.
2. El padre debe seguir siendo el articulo normal.
3. La conversion debe ocurrir al calcular existencia, no al grabar estadistica.
4. Hay que homologar `calcexistenciasn` y `calcexistenciasnxart` para que usen la misma logica de `upc_factor` que ya usa `calcexistencianxart`.

## Implicacion Para El Siguiente Diseño

Si seguimos esta linea, la implementacion futura de venta por caja no deberia arrancar por `TMPAUXVTA2`.

Deberia arrancar por definir:

- el contrato de `UPC virtual`
- el criterio de seleccion de ese UPC desde `F6`
- los ajustes a:
  - `calcexistenciasn`
  - `calcexistenciasnxart`
  - posiblemente `FrBuscaArt`
  - y despues el flujo de inventario fisico

## Propuesta De Contrato Minimo Para Venta Por Caja

Esta propuesta prioriza:

- poder vender caja virtual inmediatamente
- no obligar a crear UPCs virtuales en esta primera salida
- no perder trazabilidad comercial
- no romper existencias ni estadistica actual

### Idea base

`ECVENTADET` debe guardar dos miradas del mismo renglon:

1. La operativa:
   - cuanto salio realmente del inventario base
2. La comercial:
   - como fue cobrado/capturado al cajero

### Columnas propuestas

#### En `ECVENTADET`

Agregar:

- `DVE_CANTCAPTURADA decimal(18,4) not null default 0`
- `DVE_FACTORAPLICADO decimal(18,4) not null default 1`

Conservar:

- `FueConF6 int`

Opcional a futuro:

- `DVE_TIPOCAPTURA int not null default 0`

Interpretacion:

- `DVE_CANTIDAD`
  - cantidad real que afecta inventario/estadistica
- `DVE_CANTCAPTURADA`
  - cantidad comercial capturada
- `DVE_FACTORAPLICADO`
  - factor de conversion usado para pasar de captura a inventario
- `FueConF6`
  - indica que la captura fue caja virtual

Relacion esperada:

- `DVE_CANTIDAD = DVE_CANTCAPTURADA * DVE_FACTORAPLICADO`

#### En `TMPAUXVTA2`

Agregar:

- `CantCapturada decimal(18,4) not null default 0`
- `Factor decimal(18,4) not null default 1`
- `FueConF6 int not null default 0`

Nota:

- aqui `cantidad` puede seguir siendo la cantidad comercial en captura viva
- la expansion a cantidad real puede hacerse al volcar a `ECVENTADET`

#### En `dbo.TipoDetalleUPC`

Agregar:

- `dve_cantcapturada decimal(18,4)`
- `dve_factoraplicado decimal(18,4)`

Y mantener:

- `FueConF6`

#### En `sp_InsertarVenta_DetalleUPC`

Hacer que inserte tambien:

- `DVE_CANTCAPTURADA`
- `DVE_FACTORAPLICADO`

### Regla funcional por tipo de venta

#### 1. Pieza normal

- `FueConF6 = 0`
- `DVE_CANTCAPTURADA = cantidad vendida`
- `DVE_FACTORAPLICADO = 1`
- `DVE_CANTIDAD = cantidad vendida`

Ejemplo:

- 5 piezas
  - `DVE_CANTCAPTURADA = 5`
  - `DVE_FACTORAPLICADO = 1`
  - `DVE_CANTIDAD = 5`

#### 2. Caja fisica ya dada de alta por `XUPC.upc_factor`

- `FueConF6 = 0`
- `DVE_CANTCAPTURADA = cajas vendidas`
- `DVE_FACTORAPLICADO = upc_factor`
- `DVE_CANTIDAD = cajas vendidas * upc_factor`

Ejemplo:

- 2 cajas fisicas de 24
  - `DVE_CANTCAPTURADA = 2`
  - `DVE_FACTORAPLICADO = 24`
  - `DVE_CANTIDAD = 48`

#### 3. Caja virtual con `F6`

- `FueConF6 = 1`
- `DVE_CANTCAPTURADA = cajas vendidas`
- `DVE_FACTORAPLICADO = art_cap1 * art_cap2`
- `DVE_CANTIDAD = cajas vendidas * (art_cap1 * art_cap2)`

Ejemplo:

- 3 cajas virtuales de 96
  - `DVE_CANTCAPTURADA = 3`
  - `DVE_FACTORAPLICADO = 96`
  - `DVE_CANTIDAD = 288`

### Por que este contrato sirve

#### Existencias

Los procedimientos de existencias y estadistica pueden seguir usando:

- `DVE_CANTIDAD`

sin cambiar su semantica base.

#### Reconstruccion del detalle

Cuando quieras revisitar o reimprimir el detalle comercial:

- si `FueConF6 = 1`, sabes que fue caja virtual
- si `DVE_FACTORAPLICADO > 1` y `FueConF6 = 0`, sabes que fue caja fisica
- `DVE_CANTCAPTURADA` te evita hacer divisiones para reconstruir

#### Devoluciones

Puedes decidir si la devolucion:

- se captura en cajas
- o se permite en piezas

porque ya sabes:

- cuantas cajas se cobraron
- de cuantas piezas era cada caja

#### Reportes

Sin recalcular nada, puedes sacar:

- piezas reales vendidas
- cajas comerciales cobradas
- factor promedio / factor aplicado
- ventas de caja virtual vs caja fisica

## Recomendacion De Tipos De Dato

### `ECVENTADET`

- `DVE_CANTIDAD decimal(18,4)` ya existente
- `DVE_CANTCAPTURADA decimal(18,4)`
- `DVE_FACTORAPLICADO decimal(18,4)`
- `FueConF6 int`

### `TMPAUXVTA2`

- `cantidad decimal(18,4)` idealmente, si en deployment quieres aprovechar y dejar de usar `float`
- `CantCapturada decimal(18,4)`
- `Factor decimal(18,4)`
- `FueConF6 int`

Si no quieres tocar mucho hoy:

- puedes dejar `cantidad` como esta
- y solo agregar las columnas nuevas como `decimal`

## Donde Se Usaria Cada Campo

### `DVE_CANTIDAD`

Uso:

- existencias
- estadistica
- calculos de inventario

### `DVE_CANTCAPTURADA`

Uso:

- reimpresion comercial futura
- devoluciones
- auditoria
- pantallas de detalle

### `DVE_FACTORAPLICADO`

Uso:

- reconstruccion
- validacion
- soporte a devoluciones
- diferenciar caja fisica/virtual en conjunto con `FueConF6`

### `FueConF6`

Uso:

- distinguir caja virtual de caja fisica
- UI
- logica de devolucion
- reportes operativos

## Siguiente Paso Tecnico

Con este contrato, el cambio real se repartiría así:

1. Schema:
   - `TMPAUXVTA2`
   - `ECVENTADET`
   - `TipoDetalleUPC`
2. App:
   - `FrVenta`
   - `FrCambio`
3. Lectura:
   - recuperacion de venta pendiente
   - devoluciones
   - reimpresion / detalle

Y la regla central sería:

- la captura trabaja con `CantCapturada` y `Factor`
- el guardado a `ECVENTADET` persiste ambas y calcula `DVE_CANTIDAD`

## Desalineaciones Fuertes Entre Repo Y Base Viva

### 1. `TMPAUXVTA2`

El codigo actual intenta:

- leer `FueConF6`
- insertar `FueConF6`
- insertar `Factor`
- actualizar `FueConF6`

Pero en la base viva `TMPAUXVTA2` no tiene esas columnas.

Impacto esperado si ese codigo se despliega tal cual:

- falla al insertar desde cotizaciones
- falla al guardar renglones nuevos con `F6`
- falla al recuperar cuentas pendientes si intenta leer `FueConF6`

### 2. Consumo de `FueConF6`

La bandera si llega a `ECVENTADET`, pero no tiene consumidor SQL posterior.

### 3. Flujo nuevo vs flujo viejo

El repo conserva dos arquitecturas:

- guardado manual tabla por tabla
- guardado nuevo con TVPs y transaccion

Esto hace mas dificil razonar cambios, porque:

- partes del repo aun apuntan a `TMPAUXVTA` y `TMPAUXVTA1`
- la captura viva ya depende de `TMPAUXVTA2`
- la postventa y reimpresion aun conocen logica historica

## Cancelaciones Y Devoluciones

### Cancelacion de ticket

En `reimprime2`:

1. `UPDATE ECVENTA SET VEN_STATUS=2`
2. `EXEC APLICAVENTAINVENTARIO @ticket, 4`
3. Actualiza credito en:
   - `ECDETCLIENTEEMP`
   - `ECCUENTASXCOB`

Observacion:

- la cancelacion usa la misma familia de `APLICAMOVTOS*` via opcion `4`
- o sea nuevamente estadistica, no un flujo visible de inventario fisico

### Devoluciones

`Devoluciones.vb`:

- consulta `ECVENTA`, `ECVENTADET`, `ECVENTADETE`, `ECCANCXUPC`
- registra devolucion en `ECCANCXUPC`
- registra retiro en `ECRETIROS`
- ejecuta:
  - `APLICAMOVTOSFECHA`
  - `APLICAMOVTOSFECHACORTE`
  - `APLICAMOVTOSMES`
  - `APLICAMOVTOSSEMANA`

Observacion:

- tambien es estadistica
- no se encontro en este flujo una afectacion directa a `ECINVENTARIOS` o `ECINVENTARIOSD`

## Mapa End-To-End

### Flujo vivo de venta

`FrVenta`
-> captura articulo / ofertas / cliente / tipo / `F6`
-> staging en `TMPAUXVTA2`
-> `FrCambio`
-> `dasigfolio`
-> `ECVENTA`
-> `LigasFolios`
-> `ECDETVENTATEL` opcional
-> `sp_InsertarVenta_DetalleUPC`
-> `ECVENTADET`
-> `sp_InsertarVenta_Agrupado`
-> `ECDETVENTA`
-> `sp_InsertarVenta_Vales`
-> `ECVENTADETE`
-> `ECFORMAPAGO`
-> `ECTARJETAS` / `ECTRANSFER` / `ECCUENTASXCOB`
-> `TicketsClientes`
-> `APLICAVENTAINVENTARIO`
-> `APLICAMOVTOSFECHA/MES/SEMANA/FECHACORTE`
-> `ESTX*`

### Flujo legado de venta

`FrVenta`
-> `TMPAUXVTA`
-> `TMPAUXVTA1`
-> insert directo `ECVENTA`
-> insert directo `ECVENTADETE`
-> insert directo `ECDETVENTA`
-> insert directo `ECVENTADET`
-> `APLICAVENTAINVENTARIO`

### Flujo de cancelacion

`reimprime2`
-> `UPDATE ECVENTA status=2`
-> `APLICAVENTAINVENTARIO opcion 4`
-> `APLICAMOVTOS*`

### Flujo de devolucion

`Devoluciones`
-> `ECCANCXUPC`
-> `ECRETIROS`
-> `APLICAMOVTOS* opcion 3`

## Implicaciones Para Venta Por Caja

Si queremos venta por caja bien cerrada, hay que decidir explicitamente cual sera el comportamiento deseado:

1. Solo precio por caja.
2. Precio por caja y estadistica por caja.
3. Precio por caja pero descarga fisica en piezas.
4. Precio por caja con trazabilidad dual:
   - unidad logica de venta = caja
   - unidad fisica de inventario = piezas

El sistema actual esta mas cerca de la opcion 1.5:

- calcula y cobra caja
- guarda una bandera
- pero no completa la conversion operativa de inventario

## Recomendacion De Estrategia Antes Del Deployment

### Fase 1. Congelar contrato objetivo

Definir por escrito:

- como debe persistirse una caja virtual
- donde se guardara el factor de conversion
- si el inventario se descarga en piezas, en cajas, o en ambos niveles

### Fase 2. Normalizar staging y salida final

Recomendable alinear:

- `TMPAUXVTA2`
- TVPs
- `ECVENTADET`
- logica de inventario

### Fase 3. Conectar o sustituir inventario fisico

Dos rutas posibles:

1. Adaptar `APLICAVENTAINVENTARIO` para que deje de ser solo estadistica y se coordine con inventario fisico.
2. Mantener `APLICAVENTAINVENTARIO` para estadistica y agregar explicitamente el paso de inventario fisico llamando el procedimiento correcto o reemplazandolo por logica nueva.

### Fase 4. Deployment por capas

Orden sugerido:

1. Cambios de schema
2. Cambios de SPs / tipos tabla
3. App
4. Prueba controlada con tickets de laboratorio
5. Verificacion de:
   - `ECVENTADET`
   - `ECDETVENTA`
   - `ECVENTADETE`
   - `ESTX*`
   - `ECINVENTARIOS`
   - `ECINVENTARIOSD`

## Hallazgos Que Conviene Tratar Como Riesgo Alto

- `TMPAUXVTA2` del repo y `TMPAUXVTA2` productiva no coinciden.
- `FueConF6` no tiene consumidor SQL despues del insert.
- El flujo vivo no muestra conexion con los procedimientos que si descargan inventario fisico.
- El repo conserva arquitectura nueva y vieja al mismo tiempo.

## Siguiente Paso Recomendado

Con este mapa ya tiene sentido pasar al siguiente documento:

- diseno de contrato para venta por caja virtual
- plan de migration SQL
- plan de cambios en app
- plan de pruebas de caja, devolucion y cancelacion

Si seguimos en ese orden, el siguiente entregable deberia ser:

- una propuesta tecnica de implementacion de venta por caja real, con cambios concretos de tablas, TVPs, SPs y puntos del codigo a tocar.
