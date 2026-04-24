Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading
Imports ECVENTA4.FrVenta
Imports MSXML2
Public Class FrCambio

    Inherits System.Windows.Forms.Form
    Dim fo As FrVenta
    Public FOLIOAUT As Integer
    Private preImpresion As Collection
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private prepagos As Collection
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef forma As FrVenta)

        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        fo = forma


        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de Código.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tx_totalventa As System.Windows.Forms.Label
    Friend WithEvents tx_totalpago As System.Windows.Forms.Label
    Friend WithEvents tx_cambio As System.Windows.Forms.Label
    Friend WithEvents btn_continuar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tx_totalventa = New System.Windows.Forms.Label()
        Me.tx_totalpago = New System.Windows.Forms.Label()
        Me.tx_cambio = New System.Windows.Forms.Label()
        Me.btn_continuar = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(163, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 99)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "GRACIAS POR SU COMPRA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tx_totalventa
        '
        Me.tx_totalventa.BackColor = System.Drawing.Color.Transparent
        Me.tx_totalventa.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_totalventa.ForeColor = System.Drawing.Color.White
        Me.tx_totalventa.Location = New System.Drawing.Point(97, 7)
        Me.tx_totalventa.Name = "tx_totalventa"
        Me.tx_totalventa.Size = New System.Drawing.Size(328, 40)
        Me.tx_totalventa.TabIndex = 1
        '
        'tx_totalpago
        '
        Me.tx_totalpago.BackColor = System.Drawing.Color.Transparent
        Me.tx_totalpago.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_totalpago.ForeColor = System.Drawing.Color.White
        Me.tx_totalpago.Location = New System.Drawing.Point(97, 47)
        Me.tx_totalpago.Name = "tx_totalpago"
        Me.tx_totalpago.Size = New System.Drawing.Size(328, 40)
        Me.tx_totalpago.TabIndex = 2
        '
        'tx_cambio
        '
        Me.tx_cambio.BackColor = System.Drawing.Color.Transparent
        Me.tx_cambio.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cambio.ForeColor = System.Drawing.Color.White
        Me.tx_cambio.Location = New System.Drawing.Point(97, 87)
        Me.tx_cambio.Name = "tx_cambio"
        Me.tx_cambio.Size = New System.Drawing.Size(328, 40)
        Me.tx_cambio.TabIndex = 4
        '
        'btn_continuar
        '
        Me.btn_continuar.BackColor = System.Drawing.Color.Transparent
        Me.btn_continuar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.BOTON_NUEVO
        Me.btn_continuar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_continuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_continuar.ForeColor = System.Drawing.Color.Goldenrod
        Me.btn_continuar.Location = New System.Drawing.Point(432, 436)
        Me.btn_continuar.Name = "btn_continuar"
        Me.btn_continuar.Size = New System.Drawing.Size(49, 49)
        Me.btn_continuar.TabIndex = 5
        Me.btn_continuar.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.logoDUARSA
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(32, 23)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(83, 52)
        Me.PictureBox3.TabIndex = 430
        Me.PictureBox3.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.tx_cambio)
        Me.Panel1.Controls.Add(Me.tx_totalpago)
        Me.Panel1.Controls.Add(Me.tx_totalventa)
        Me.Panel1.Location = New System.Drawing.Point(20, 111)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(533, 170)
        Me.Panel1.TabIndex = 431
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGray
        Me.Label3.Location = New System.Drawing.Point(487, 436)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 58)
        Me.Label3.TabIndex = 432
        Me.Label3.Text = "CONTINUAR"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrCambio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(625, 543)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.btn_continuar)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(160, 80)
        Me.Name = "FrCambio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Gracias Por Su Compra"
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrCambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FOLIOAUT = 0

        Dim totalVenta As Decimal = fo.TotalVenta
        Dim totalPago As Decimal = fo.TotalPago

        Me.tx_totalventa.Text = "Total Venta: " & totalVenta.ToString("$###,##0.00")
        Me.tx_totalpago.Text = "Total Pago : " & totalPago.ToString("$###,##0.00")
        Me.tx_cambio.Text = "Su Cambio  : " & (totalPago - totalVenta).ToString("$###,##0.00")

        Call empieza()

    End Sub

    Private Sub empieza()
        btn_continuar.Focus()
    End Sub

    Private Sub btn_continuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_continuar.Click

        ' 1. BLOQUEO DE UI
        btn_continuar.Enabled = False
        Cursor = Cursors.WaitCursor

        ' Variables que usaremos
        Dim iID As Integer = 0
        Dim HayVales As Boolean = False

        Dim FechaVenta As DateTime = Now
        ' Formato de usuario: 000 + ultimo digito
        Dim UsuarioStr As String = "000" & Globales.caja.Substring(Math.Max(0, Globales.caja.Length - 1))
        Dim UsuarioStrPago As String = "00" & Globales.caja.Substring(Math.Max(0, Globales.caja.Length - 1)) & "0"

        ' 2. INICIO DE LA TRANSACCIÓN MAESTRA
        Using Conn As New SqlConnection(sCadenaConexionSQL)
            Try
                Conn.Open()
            Catch ex As Exception
                MsgBox("Error al conectar con la base de datos: " & ex.Message, vbCritical)
                Cursor = Cursors.Default
                btn_continuar.Enabled = True
                Exit Sub
            End Try

            ' Iniciamos la TRANSACCIÓN. A partir de aquí, nada es definitivo hasta el Commit.
            Using Trans As SqlTransaction = Conn.BeginTransaction("VentaCompleta")

                Try
                    ' Creamos un comando vinculado a la TRANSACCIÓN
                    Using Cmd As SqlCommand = Conn.CreateCommand()
                        Cmd.Transaction = Trans
                        Cmd.CommandTimeout = 120 ' Damos tiempo suficiente

                        ' ---------------------------------------------------------
                        ' FASE A: GUARDAR EL TICKET (Llamamos a la función privada nueva)
                        ' ---------------------------------------------------------
                        iID = GuardaTicket_Transaccional(Cmd, UsuarioStr, FechaVenta, fo.totalote, HayVales)
                        ' ---------------------------------------------------------
                        ' FASE B: GUARDAR LOS PAGOS
                        ' ---------------------------------------------------------
                        GuardaPagos_Transaccional(Cmd, iID, UsuarioStrPago, FechaVenta)

                        ' ---------------------------------------------------------
                        ' FASE C: ASOCIAR CLIENTE (Transaccional)
                        ' ---------------------------------------------------------
                        If IsNumeric(fo.TxtControl.Text) Then
                            Dim ClienteID As Integer = CInt(fo.TxtControl.Text.Trim)
                            GuardaTicketCliente_Transaccional(Cmd, ClienteID, iID)
                        End If
                        ' ---------------------------------------------------------
                        ' FASE D: AFECTAR INVENTARIO
                        ' ---------------------------------------------------------
                        Cmd.CommandText = "EXEC aplicaventainventario " & iID & ", 1"
                        Cmd.ExecuteNonQuery()

                    End Using ' Fin del Command

                    ' 3. SI LLEGAMOS aquí SIN ERRORES -> CONFIRMAMOS TODO
                    Trans.Commit()
                    ' ¡LISTO! aquí se guardó todo de golpe.

                Catch ex As Exception
                    ' 4. SI ALGO FALLó -> DESHACEMOS TODO (ROLLBACK)
                    Try
                        Trans.Rollback()
                    Catch
                        ' Ignoramos error si la conexión ya estaba cerrada
                    End Try

                    MsgBox("Error crítico al procesar la venta. No se guardó nada." & vbCrLf &
                       "Detalle: " & ex.Message, vbCritical)

                    ' Limpieza y Salida
                    Cursor = Cursors.Default
                    btn_continuar.Enabled = True
                    Exit Sub
                End Try
            End Using
        End Using

        ' =========================================================
        ' 5. PROCESOS POST-VENTA (Fuera de la TRANSACCIÓN)
        ' =========================================================

        Try
            ' Asignamos el ID generado a la variable global por compatibilidad
            fo.xven = iID

            ' A. PREPARAR impresión PRINCIPAL
            Dim oPreImpre As New preImpresion(Me.tx_cambio.Text, Globales.sDireccion, Globales.sNominaEmpleado, Globales.NombreEmpleado, iID)
            preImpresion = oPreImpre.COLECCION

            ' B. INSTANCIAR PREVIRTUAL (Lo que faltaba)
            ' Esta clase prepara la colección necesaria para el segundo ticket y otros procesos
            Dim imprimevirtual As New previrtual(iID)

            ' C. IMPRIMIR TICKET NORMAL
            fo.imprimeTicket(preImpresion, iID)

            ' D. IMPRIMIR SEGUNDO TICKET (Vales/Mercancía Especial)            
            If HayVales Then
                ' aquí USAMOS LA colección DE imprimevirtual COMO EN TU ORIGINAL
                Dim vImpresion As New Impresion(imprimevirtual.COLECCION, iID)
                vImpresion.imprime(True)
            End If

            ' E. IMPRIMIR pagaré (Crédito)
            If fo.pagare Then
                ImprimirPagareCredito(iID)
            End If

            ' F. IMPRIMIR PUNTOS
            If fo.sipuntos Then
                Dim impuntos As New prepuntos(iID)
                Dim oImpresion As New Impresion(impuntos.COLECCION, iID)
                oImpresion.imprime(False) ' False = No abrir cajón (ya se abrió con el ticket normal)
            End If

            ' G. TIEMPO AIRE (TAE)
            If fo.estiempoaire Then
                If Not ProcesarTiempoAire(iID) Then
                    ' Si el TAE falla pero la venta ya se cobró, aquí avisas
                End If
            End If

            ' H. FINALIZAR UI
            MsgBox("Venta registrada correctamente.", vbInformation)
        Catch ex As Exception
            MsgBox("Venta guardada exitosamente, pero hubo un error en la impresión: " & ex.Message, vbExclamation)
        End Try

        Cursor = Cursors.Default
        fo.sipuntos = False
        fo.limpiaSpread(True)
        fo.PERMISOVENDER = False
        fo.pagare = False
        fo.segundoticket = False
        fo.txt_tipoventa.Text = "1"
        fo.txt_tipoventa.Enabled = True

        Me.DialogResult = DialogResult.OK
        Me.Close()

        fo.txt_tipoventa.Focus()



    End Sub
    ' Esta función va dentro de tu formulario o clase de lógica
    Private Function GuardaTicket_Transaccional(ByVal Cmd As SqlCommand,
                                                ByVal Usuario As String,
                                                ByVal Fecha As DateTime,
                                                ByVal MontoTotal As Decimal, ByRef HuboVales As Boolean) As Integer

        Dim FolioGenerado As Integer = 0
        Dim FolioCaja As String = ""

        ' 1. OBTENER FOLIO
        Cmd.CommandText = "exec dasigfolio @caja"
        Cmd.Parameters.Clear()
        Dim CajaParam As String = "000" & Globales.caja.Substring(Math.Max(0, Globales.caja.Length - 1))
        Cmd.Parameters.AddWithValue("@caja", CajaParam)

        Using Rdr As SqlDataReader = Cmd.ExecuteReader()
            If Rdr.Read() Then
                FolioGenerado = CInt(Rdr("FolioN"))
                FolioCaja = Rdr("FolioCaja").ToString()
            Else
                Throw New Exception("Error al obtener folio.")
            End If
        End Using
        Cmd.Parameters.Clear()

        ' =========================================================================
        ' 2. ESTRUCTURAS DE DATOS
        ' =========================================================================

        ' A) ECVENTADET (Inventario - Agrupado PURO por UPC)
        ' Quitamos EsVale. Solo nos importa UPC y Cantidad Total.
        Dim dtUPC As New DataTable()
        dtUPC.Columns.Add("dve_articulo", GetType(String))
        dtUPC.Columns.Add("dve_upc", GetType(String))
        dtUPC.Columns.Add("dve_precio", GetType(Decimal))
        dtUPC.Columns.Add("dve_cantidad", GetType(Decimal))
        dtUPC.Columns.Add("dve_total", GetType(Decimal))
        dtUPC.Columns.Add("dve_poriva", GetType(Decimal))
        dtUPC.Columns.Add("dve_iva", GetType(Decimal))
        dtUPC.Columns.Add("dve_costou", GetType(Decimal))
        dtUPC.Columns.Add("dve_costo", GetType(Decimal))
        dtUPC.Columns.Add("dve_familia", GetType(String))
        dtUPC.Columns.Add("dve_renglon", GetType(Integer))
        dtUPC.Columns.Add("FueConF1", GetType(Integer))
        dtUPC.Columns.Add("FueConF2", GetType(Integer))
        dtUPC.Columns.Add("FueConF3", GetType(Integer))
        dtUPC.Columns.Add("FueConF6", GetType(Integer))
        dtUPC.Columns.Add("dve_porieps", GetType(Decimal))
        dtUPC.Columns.Add("dve_ieps", GetType(Decimal))

        ' B) ECDETVENTA (impresión - Agrupado por Clave)
        Dim dtAgrupado As New DataTable()
        dtAgrupado.Columns.Add("dve_articulo", GetType(String))
        dtAgrupado.Columns.Add("dve_precio", GetType(Decimal))
        dtAgrupado.Columns.Add("dve_cantidad", GetType(Decimal))
        'dtAgrupado.Columns.Add("dve_total", GetType(Decimal)) computed 
        dtAgrupado.Columns.Add("dve_poriva", GetType(Decimal))
        dtAgrupado.Columns.Add("dve_iva", GetType(Decimal))
        dtAgrupado.Columns.Add("dve_costou", GetType(Decimal))
        dtAgrupado.Columns.Add("dve_costo", GetType(Decimal))
        dtAgrupado.Columns.Add("dve_familia", GetType(String))
        dtAgrupado.Columns.Add("dve_renglon", GetType(Integer))
        dtAgrupado.Columns.Add("dve_porieps", GetType(Decimal))
        dtAgrupado.Columns.Add("dve_ieps", GetType(Decimal))

        ' C) ECVENTADETE (Vales - Sin Agrupar / Cronológico)
        Dim dtVales As New DataTable()
        dtVales.Columns.Add("dve_articulo", GetType(String))
        dtVales.Columns.Add("dve_upc", GetType(String))
        dtVales.Columns.Add("dve_cantidad", GetType(Decimal))
        dtVales.Columns.Add("dve_precio", GetType(Decimal))
        dtVales.Columns.Add("dve_total", GetType(Decimal))
        dtVales.Columns.Add("dve_factoraplicado", GetType(Decimal))
        dtVales.Columns.Add("FueConF6", GetType(Integer))

        ' --- DICCIONARIOS ---
        ' Inventario: Key = UPC + PrecioUnitarioInventario + F6 + Factor
        Dim DicInventario As New Dictionary(Of String, ItemAcumulado)
        ' impresión: Key = Clave + PrecioCapturado + F6 + Factor
        Dim DicImpresion As New Dictionary(Of String, ItemAcumulado)

        Dim CancelacionesVales As New Dictionary(Of String, Decimal)
        Dim TraeValeGlobal As Boolean = False

        ' =========================================================================
        ' 3. BARRIDA Única DEL GRID
        ' =========================================================================
        With fo.FpArticulos.ActiveSheet

            ' 3.1 Cancelaciones
            For k As Integer = 0 To .RowCount - 1
                Dim Cant As Decimal = CDec(Val(.Cells(k, ColVenta.ColCantidad).Value))
                If Cant < 0 Then
                    Dim UPC As String = .Cells(k, ColVenta.ColUPCInv).Text.Trim

                    Dim FactorCancelacion As Decimal = CDec(Val(.Cells(k, ColVenta.ColFactor).Value))
                    If FactorCancelacion <= 0D Then FactorCancelacion = 1D

                    Dim F6Cancelacion As Integer = CInt(Val(.Cells(k, ColVenta.ColF6).Value))

                    Dim KeyValeCancelacion As String =
                            UPC & "|" &
                            FactorCancelacion.ToString("0.####", CultureInfo.InvariantCulture) & "|" &
                            F6Cancelacion.ToString()

                    If CancelacionesVales.ContainsKey(KeyValeCancelacion) Then
                        CancelacionesVales(KeyValeCancelacion) += Cant
                    Else
                        CancelacionesVales.Add(KeyValeCancelacion, Cant)
                    End If
                End If
            Next


            ' 3.2 Barrida Principal
            For i As Integer = 0 To .RowCount - 1
                Dim Cantidad As Decimal = CDec(Val(.Cells(i, ColVenta.ColCantidad).Value))
                If Cantidad <= 0 Then Continue For

                ' Variables
                Dim UPC As String = .Cells(i, ColVenta.ColUPCInv).Text.Trim
                Dim ArtClave As String = .Cells(i, ColVenta.ColArtClave).Text.Trim
                Dim Precio As Decimal = CDec(Val(.Cells(i, ColVenta.ColPrecio).Value))
                Dim TotalLinea As Decimal = CDec(Val(.Cells(i, ColVenta.ColTotal).Value))
                Dim NomLargo As String = .Cells(i, ColVenta.ColNomLargo).Text.Trim.Replace("'", "")
                Dim Familia As String = .Cells(i, ColVenta.ColFamilia).Value
                Dim CostoU As Decimal = CDec(Val(.Cells(i, ColVenta.ColCostoCap).Value))

                Dim PorcIVA As Decimal = CDec(Val(.Cells(i, ColVenta.ColFIVA).Value))
                Dim PorcIEPS As Decimal = CDec(Val(.Cells(i, ColVenta.ColFIEPS).Value))

                Dim F1 As Integer = CInt(Val(.Cells(i, ColVenta.ColF1).Value))
                Dim F2 As Integer = CInt(Val(.Cells(i, ColVenta.ColF2).Value))
                Dim F3 As Integer = CInt(Val(.Cells(i, ColVenta.ColF3).Value))
                Dim F6 As Integer = CInt(Val(.Cells(i, ColVenta.ColF6).Value))
                Dim TieneAsterisco As Boolean = (.Cells(i, ColVenta.ColVale).Text = "*")

                Dim Factor As Decimal = CDec(Val(.Cells(i, ColVenta.ColFactor).Value))
                If Factor <= 0D Then Factor = 1D

                Dim CantidadCapturada As Decimal = Cantidad
                Dim CantidadInventario As Decimal = Cantidad * Factor
                Dim PrecioInventario As Decimal = Precio
                If Factor > 1D Then
                    PrecioInventario = Precio / Factor
                End If

                Dim KeyInventario As String =
                    UPC & "|" &
                    PrecioInventario.ToString("0.####", CultureInfo.InvariantCulture) & "|" &
                    F6.ToString() & "|" &
                    Factor.ToString("0.####", CultureInfo.InvariantCulture)

                Dim KeyImpresion As String =
                    ArtClave & "|" &
                    Precio.ToString("0.####", CultureInfo.InvariantCulture) & "|" &
                    F6.ToString() & "|" &
                    Factor.ToString("0.####", CultureInfo.InvariantCulture)

                Dim ImpIVA As Decimal = 0
                Dim ImpIEPS As Decimal = 0
                If PorcIVA > 0 Then ImpIVA = (TotalLinea / (1 + (PorcIVA / 100D))) * (PorcIVA / 100D)
                If PorcIEPS > 0 Then ImpIEPS = (TotalLinea / (1 + (PorcIEPS / 100D))) * (PorcIEPS / 100D)

                ' ------------------------------------------------------------------
                ' A) INVENTARIO (ECVENTADET) - AGRUPAR POR UPC + PRESENTACION
                ' ------------------------------------------------------------------
                If Not DicInventario.ContainsKey(KeyInventario) Then
                    DicInventario.Add(KeyInventario, New ItemAcumulado With {
                        .UPC = UPC, .Clave = ArtClave, .Descripcion = NomLargo,
                        .PrecioU = PrecioInventario, .CostoU = CostoU, .Familia = Familia,
                        .PorcIVA = PorcIVA, .PorcIEPS = PorcIEPS,
                        .F1 = F1, .F2 = F2, .F3 = F3, .F6 = F6
                    })
                End If
                With DicInventario(KeyInventario)
                    .Cantidad += CantidadInventario
                    .Total += TotalLinea
                    .ImporteIVA += ImpIVA
                    .ImporteIEPS += ImpIEPS
                End With

                ' ------------------------------------------------------------------
                ' B) IMPRESION (ECDETVENTA) - AGRUPAR POR CLAVE + PRECIO + PRESENTACION
                ' ------------------------------------------------------------------
                If Not DicImpresion.ContainsKey(KeyImpresion) Then
                    DicImpresion.Add(KeyImpresion, New ItemAcumulado With {
                        .Clave = ArtClave, .PrecioU = Precio, .CostoU = CostoU, .Familia = Familia,
                        .PorcIVA = PorcIVA, .PorcIEPS = PorcIEPS
                    })
                End If
                With DicImpresion(KeyImpresion)
                    .Cantidad += CantidadCapturada
                    .Total += TotalLinea
                    .ImporteIVA += ImpIVA
                    .ImporteIEPS += ImpIEPS
                End With


                ' ------------------------------------------------------------------
                ' C) VALES (ECVENTADETE) - SIN AGRUPAR (Detalle Pendiente)
                ' ------------------------------------------------------------------
                Dim KeyVale As String =
                    UPC & "|" &
                    Factor.ToString("0.####", CultureInfo.InvariantCulture) & "|" &
                    F6.ToString()

                Dim CantidadNeta As Decimal = CantidadCapturada
                If CancelacionesVales.ContainsKey(KeyVale) Then
                    Dim Restar As Decimal = Math.Min(CantidadNeta, Math.Abs(CancelacionesVales(KeyVale)))
                    CantidadNeta -= Restar
                    CancelacionesVales(KeyVale) += Restar
                End If
            Next
        End With

        ' =========================================================================
        ' 4. VOLCADO TVP
        ' =========================================================================

        ' 4.1 Inventario (ECVENTADET)
        Dim RenglonInv As Integer = 1
        For Each kvp In DicInventario
            Dim itm = kvp.Value
            Dim CostoTotal As Decimal = itm.Cantidad * itm.CostoU

            dtUPC.Rows.Add(itm.Clave, itm.UPC, itm.PrecioU, itm.Cantidad, itm.Total,
                           itm.PorcIVA, itm.ImporteIVA, itm.CostoU, CostoTotal, itm.Familia,
                           RenglonInv, itm.F1, itm.F2, itm.F3, itm.F6, itm.PorcIEPS, itm.ImporteIEPS)
            RenglonInv += 1
        Next

        ' 4.2 impresión (ECDETVENTA)
        Dim RenglonImp As Integer = 1
        For Each kvp In DicImpresion
            Dim itm = kvp.Value
            Dim CostoTotal As Decimal = itm.Cantidad * itm.CostoU

            dtAgrupado.Rows.Add(itm.Clave, itm.PrecioU, itm.Cantidad, 'itm.Total, computed
                                itm.PorcIVA, itm.ImporteIVA, itm.CostoU, CostoTotal,
                                itm.Familia, RenglonImp, itm.PorcIEPS, itm.ImporteIEPS)
            RenglonImp += 1
        Next

        ' =========================================================================
        ' 5. EJECUCIÓN 
        ' =========================================================================

        ' A) Insert Encabezado
        Cmd.CommandText = "INSERT INTO ECVENTA (ven_id, ven_usuario, ven_fecha, ven_status, ven_total, ven_turno, ven_tipov, CORTE, NombreCajera, TraeVale) " &
                          "VALUES (@id, @usu, @fecha, 1, @total, @turno, @tipo, 0, @nombre, '')"
        Cmd.Parameters.AddWithValue("@id", FolioGenerado)
        Cmd.Parameters.AddWithValue("@usu", Usuario)
        Cmd.Parameters.AddWithValue("@fecha", Fecha)
        Cmd.Parameters.AddWithValue("@total", MontoTotal)
        Cmd.Parameters.AddWithValue("@turno", Globales.iTurnoActivo)
        Cmd.Parameters.AddWithValue("@tipo", fo.TIPOVENTA)
        Cmd.Parameters.AddWithValue("@nombre", Globales.NombreEmpleado)
        Cmd.ExecuteNonQuery()

        Cmd.CommandText = "INSERT INTO LigasFolios VALUES(" & FolioGenerado & ",'" & FolioCaja & "')"
        Cmd.ExecuteNonQuery()
        If fo.estiempoaire Then
            Dim Tel As String = fo.txt_ctel1.Text & "-" & fo.txt_ctel2.Text & "-" & fo.txt_ctel3.Text & "-" & fo.txt_ctel4.Text
            Cmd.CommandText = "INSERT INTO ecdetventatel (dve_venta,dve_telefono,dve_fecha,dve_folio) VALUES (" & FolioGenerado & ",'" & Tel & "', GETDATE(), 0)"
            Cmd.ExecuteNonQuery()
        End If

        ' B) TVP 1: ECVENTADET (1 renglón por UPC - Máxima velocidad Inventario)
        If dtUPC.Rows.Count > 0 Then
            Cmd.CommandText = "sp_InsertarVenta_DetalleUPC"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Clear()
            Cmd.Parameters.AddWithValue("@Folio", FolioGenerado)
            Dim param As SqlParameter = Cmd.Parameters.AddWithValue("@TablaDetalle", dtUPC)
            param.SqlDbType = SqlDbType.Structured
            param.TypeName = "dbo.TipoDetalleUPC"
            Cmd.ExecuteNonQuery()
        End If

        ' C) TVP 2: ECDETVENTA (Resumen Ticket)
        If dtAgrupado.Rows.Count > 0 Then
            Cmd.CommandText = "sp_InsertarVenta_Agrupado"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Clear()
            Cmd.Parameters.AddWithValue("@Folio", FolioGenerado)
            Dim param As SqlParameter = Cmd.Parameters.AddWithValue("@TablaDetalle", dtAgrupado)
            param.SqlDbType = SqlDbType.Structured
            param.TypeName = "dbo.TipoDetalleAgrupado"
            Cmd.ExecuteNonQuery()
        End If

        ' D) TVP 3: ECVENTADETE (Vales Detallados)
        If dtVales.Rows.Count > 0 Then
            Cmd.CommandText = "sp_InsertarVenta_Vales"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Clear()
            Cmd.Parameters.AddWithValue("@Folio", FolioGenerado)
            Dim param As SqlParameter = Cmd.Parameters.AddWithValue("@TablaDetalle", dtVales)
            param.SqlDbType = SqlDbType.Structured
            param.TypeName = "dbo.TipoDetalleVales"
            Cmd.ExecuteNonQuery()
        End If

        Cmd.CommandType = CommandType.Text

        ' E) Flag Encabezado
        If TraeValeGlobal Then
            Cmd.CommandText = "UPDATE ECVENTA SET TraeVale='*' WHERE ven_id=" & FolioGenerado
            Cmd.ExecuteNonQuery()
        End If

        If fo.HayTarjeta Then
            SacaProporcionP1P2_Transaccional(Cmd, FolioGenerado, MontoTotal)
        End If

        HuboVales = TraeValeGlobal
        Return FolioGenerado
    End Function

    Public Sub SacaProporcionP1P2_Transaccional(ByVal Cmd As SqlCommand, ByVal NumTicket As Integer, ByVal MontoTotal As Decimal)
        Dim CuantosMen As Decimal = 0 ' Cambio a Decimal por si hay medios (kilos)
        Dim CuantosMay As Decimal = 0
        Dim Ratio As Decimal = 0

        ' 1. LIMPIEZA DE PARÁMETROS (Vital porque el Cmd viene "sucio" de los inserts anteriores)
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@folio", NumTicket)

        ' 2. CÁLCULO DIRECTO SOBRE LA VENTA REAL (ECVENTADET)
        ' Nota Importante: Cambiamos "THEN 1" por "THEN dve_cantidad" porque ahora los renglones están agrupados.
        Cmd.CommandText = "SELECT " &
                      "ISNULL(SUM(CASE WHEN ART_PRECIO1 <> dve_precio THEN dve_cantidad ELSE 0 END), 0) AS CuantosMay, " &
                      "ISNULL(SUM(CASE WHEN ART_PRECIO1 = dve_precio THEN dve_cantidad ELSE 0 END), 0) AS CuantosMen " &
                      "FROM ECVENTADET " &
                      "JOIN articulo ON dve_articulo = ART_CLAVE " &
                      "WHERE dve_venta = @folio"

        Using Rdr As SqlDataReader = Cmd.ExecuteReader()
            If Rdr.Read() Then
                ' Leemos los acumulados reales
                CuantosMay = CDec(Rdr("CuantosMay"))
                CuantosMen = CDec(Rdr("CuantosMen"))
            End If
        End Using
        ' El Reader se cierra aquí y libera el Cmd

        ' 3. CÁLCULO RATIO
        Dim TotalArticulos As Decimal = CuantosMen + CuantosMay
        If TotalArticulos > 0 Then
            Ratio = Math.Round(CuantosMay / TotalArticulos, 3)
        End If

        ' 4. INSERTADO EN TABLA DE PROPORCIÓN
        Cmd.CommandText = "INSERT INTO ProporcionVentaTicket (NumTicket, PrecioMay, PrecioMen, TotalTicket, Usuario, ProporcionMayMen) " &
                      "VALUES (@tid, @may, @men, @monto, @usu, @ratio)"

        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@tid", NumTicket)
        Cmd.Parameters.AddWithValue("@may", CuantosMay)
        Cmd.Parameters.AddWithValue("@men", CuantosMen)
        Cmd.Parameters.AddWithValue("@monto", MontoTotal)
        Cmd.Parameters.AddWithValue("@usu", Globales.nombreusuario) ' Ojo: Asegúrate que esta variable tenga valor, o usa el parámetro Usuario que recibía la función principal
        Cmd.Parameters.AddWithValue("@ratio", Ratio)

        Cmd.ExecuteNonQuery()
    End Sub

    Private Sub GuardaPagos_Transaccional(ByVal Cmd As SqlCommand,
                                      ByVal iID As Integer,
                                      ByVal UsuarioCode As String,
                                      ByVal Fecha As DateTime)

        Dim iRen As Integer = 0
        Dim signo As Integer = 1
        Dim HuboCredito As Boolean = False

        ' Formateamos la fecha a String seguro para SQL (AñoMesDia Hora:Min:Seg.Miliseg)
        ' Esto evita problemas de configuración regional en el servidor.
        Dim FechaStr As String = Fecha.ToString("yyyyMMdd HH:mm:ss.fff")

        ' Aseguramos que el comando esté limpio de parámetros anteriores
        Cmd.Parameters.Clear()

        With fo.FpFormasPago.ActiveSheet
            ' Recorremos todo el grid de pagos
            For iRen = 0 To .RowCount - 1

                ' Validaciones básicas para no tronar por celdas vacías
                If .Cells(iRen, 0).Value Is Nothing Then Continue For
                Dim TipoPago As String = LTrim(RTrim(.Cells(iRen, 0).Text))
                If String.IsNullOrEmpty(TipoPago) Then Continue For

                ' 1. Determinar Signo (Comisiones restan, Pagos suman)
                If TipoPago = "Comision Vales" Or TipoPago = "Comis Tar" Then
                    signo = -1
                Else
                    signo = 1
                End If

                ' 2. Obtener valores
                Dim valorRenglon As Decimal = CDec(Val(.Cells(iRen, 1).Value))

                ' Limpiamos la referencia de comillas simples para evitar errores SQL
                Dim Referencia As String = ""
                If .Cells(iRen, 2).Value IsNot Nothing Then
                    Referencia = Strings.Left(.Cells(iRen, 2).Text, 50).Replace("'", "")
                End If

                ' =========================================================
                ' A. INSERCIÓN GENERAL (Tabla ecformapago)
                ' =========================================================
                Cmd.CommandText = "INSERT INTO ecformapago (referencia, tipo_pago, pago, banco) VALUES (" &
                              iID & ", '" & TipoPago & "', " & (valorRenglon * signo) & ", '" & Referencia & "')"
                Cmd.ExecuteNonQuery()

                ' =========================================================
                ' B. LÓGICA ESPECÍFICA POR TIPO DE PAGO
                ' =========================================================

                ' CASO 1: TARJETA (Crédito o Débito)
                If TipoPago = "Tarjeta" Then
                    ' Nota: Replicamos tu lógica de usuario: '00' + Usuario + '0'
                    Cmd.CommandText = "INSERT INTO ectarjetas (tar_empresa, TAR_VENTAID, CAJA, FECHA, DESCRIPCION, CANTIDAD, COMISION, REFERENCIA, FOLIOCONC, TOTALCONC, ESTATUS, corte, TipoTarjeta) " &
                                  "VALUES (1, " & iID & ", '" & UsuarioCode & "0', '" & FechaStr & "', 'Pago del Ticket " & iID & "', " &
                                  (valorRenglon * signo) & ", 0, '" & Referencia & "', 0, 0, 0, 0, '" & fo.TipoTarj & "')"
                    Cmd.ExecuteNonQuery()

                    ' CASO 2: COMISIÓN TARJETA (Actualiza el registro anterior)
                ElseIf TipoPago = "Comis Tar" Then
                    ' Actualizamos el campo 'comision' en la tabla de tarjetas ligado a esta venta
                    Cmd.CommandText = "UPDATE ectarjetas SET comision=" & valorRenglon & " WHERE tar_ventaid=" & iID
                    Cmd.ExecuteNonQuery()

                    ' CASO 3: TRANSFERENCIA
                ElseIf TipoPago = "Transfer" Then
                    Cmd.CommandText = "INSERT INTO ectransfer (TRA_EMPRESA,TRA_VENTAID,CAJA,FECHA,DESCRIPCION,CANTIDAD,COMISION,REFERENCIA,FOLIOCONC,TOTALCONC,ESTATUS,CORTE) (tra_empresa, tra_ventaid, CAJA, FECHA, DESCRIPCION, CANTIDAD, COMISION, REFERENCIA, FOLIOCONC, TOTALCONC, ESTATUS, corte) " &
                                  "VALUES (1, " & iID & ", '" & UsuarioCode & "0', '" & FechaStr & "', 'Pago del Ticket " & iID & "', " &
                                  (valorRenglon * signo) & ", 0, '" & Referencia & "', 0, 0, 0, 0)"
                    Cmd.ExecuteNonQuery()

                    ' CASO 4: CRÉDITO (Pagaré / Cuentas por Cobrar)
                ElseIf TipoPago = "Credito" Then
                    ' Insertamos en cuentas por cobrar
                    ' Usamos fo.txb_credito1.Text que contiene el ID del cliente
                    Cmd.CommandText = "INSERT INTO eccuentasxcob (cxc_fecha,cxc_cliente,cxc_tipo,cxc_totalvta,cxc_saldo,cxc_totalabo,cxc_estatus,cxc_folio) " &
                                  "VALUES ('" & FechaStr & "', '" & fo.txb_credito1.Text & "', 1, " & valorRenglon & ", " &
                                  valorRenglon & ", 0, 1, " & iID & ")"
                    Cmd.ExecuteNonQuery()

                    ' Marcamos bandera para actualizar saldo del cliente al final
                    HuboCredito = True
                End If

            Next iRen
        End With

        ' =========================================================
        ' C. ACTUALIZACIÓN DE SALDO CLIENTE (Solo si hubo crédito)
        ' =========================================================
        If HuboCredito Then
            ' Recalcula el saldo sumando todas las cuentas por cobrar de ese cliente
            Cmd.CommandText = "UPDATE ecventa.dbo.ECDETCLIENTEEMP SET DCLI_SALDO = a.Saldo " &
                          "FROM ecventa.dbo.ECDETCLIENTEEMP e " &
                          "JOIN (SELECT cxc_cliente, COALESCE(SUM(cxc_saldo), 0) AS Saldo " &
                          "      FROM ecventa.dbo.eccuentasxcob " &
                          "      GROUP BY cxc_cliente) a ON a.cxc_cliente = e.DCLI_CLAVE " &
                          "WHERE e.DCLI_CLAVE=" & fo.txb_credito1.Text
            Cmd.ExecuteNonQuery()
        End If

    End Sub
    Public Sub GuardaTicketCliente_Transaccional(ByVal Cmd As SqlCommand, ByVal ClienteID As Integer, ByVal TicketID As Integer)
        ' Limpiamos PARÁMETROS previos del comando que venimos reutilizando
        Cmd.Parameters.Clear()

        ' Query parametrizado (Moderno y Seguro)
        Cmd.CommandText = "INSERT INTO TicketsClientes (ClienteID, FolioTicket) VALUES (@cliente, @ticket)"

        ' Asignación de valores
        Cmd.Parameters.AddWithValue("@cliente", ClienteID)
        Cmd.Parameters.AddWithValue("@ticket", TicketID)

        ' Ejecutamos. Al usar 'Cmd', esto ocurre dentro de la TRANSACCIÓN maestra.
        Cmd.ExecuteNonQuery()
    End Sub

    Private Sub ImprimirPagareCredito(ByVal iID As Integer)
        Dim deudor As String = ""
        Dim direccion As String = ""
        Dim telefono As String = ""

        ' Conexión rápida solo lectura
        Using xConLocal As New SqlConnection(Globales.sCadenaConexionSQL)
            Try
                xConLocal.Open()
                Dim cmd As New SqlCommand("Select cli_nombre, cli_direccion, '' as cli_telefono from ecclientes inner join ecdetclienteemp on dcli_clave=cli_clave where dcli_empresa=1 and cli_clave=" & fo.clientex, xConLocal)
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    If rdr.Read() Then
                        deudor = rdr(0).ToString()
                        direccion = rdr(1).ToString()
                        telefono = rdr(2).ToString()
                    End If
                End Using
            Catch ex As Exception
                MsgBox("Error leyendo datos del cliente para pagaré: " & ex.Message)
            End Try
        End Using

        Dim totaluco As Double = 0
        With fo.FpFormasPago.ActiveSheet
            For i As Integer = 0 To .RowCount - 1
                If .Cells(i, 0).Value IsNot Nothing AndAlso .Cells(i, 0).Value.ToString() = "Credito" Then
                    If IsNumeric(.Cells(i, 1).Value) Then totaluco += CDbl(.Cells(i, 1).Value)
                End If
            Next
        End With

        Dim oprevales As New prevales(totaluco.ToString(), deudor, direccion, telefono, iID)
        Dim oImpresion As New Impresion(oprevales.COLECCION, iID)
        oImpresion.imprime(False) ' False = No abrir cajón (ya se abrió con el ticket normal)
    End Sub

    Private Function ProcesarTiempoAire(ByVal VentaID As Integer) As Boolean
        Dim Password As String = "Duarsa1.1"
        Dim PuntoVenta As String = "SERVDUARSA"
        Dim Producto As String = fo.claveprod
        Dim Telefono As String = fo.txt_ctel1.Text & fo.txt_ctel2.Text & fo.txt_ctel3.Text & fo.txt_ctel4.Text
        Dim FolioTAE As String = ("000000" & VentaID.ToString).Substring(Math.Max(0, ("000000" & VentaID.ToString).Length - 6))
        Dim Estatus As String = ""

        Dim Respuesta As String = EnviarTransaccion(PuntoVenta, Password, Producto, Telefono, FolioTAE, "", Estatus)

        Dim Intentos As Integer = 0
        Dim Exito As Boolean = False

        Do While Intentos < 3
            Application.DoEvents()
            Thread.Sleep(250)
            Dim EstatusFinal As String = consultartrans(PuntoVenta, Password, Telefono, FolioTAE, "")
            If EstatusFinal = "00" Then
                Exito = True
                Exit Do
            ElseIf EstatusFinal = "17" Then
                Exit Do
            End If
            Intentos += 1
        Loop

        If Exito Then
            Base.Ejecuta("UPDATE ecdetventatel SET dve_folio=" & FOLIOAUT.ToString & " WHERE dve_venta=" & VentaID, sCadenaConexionSQL)
            Dim opretiempo As New pretiempoaire(VentaID)
            fo.imprimetaire(opretiempo.COLECCION)
            Return True
        Else
            MsgBox("El tiempo aire NO se acreditó. Devuelva el dinero.", vbExclamation)
            Return False
        End If
    End Function

    Function DSCESTATUS(ByVal Codigo As String)
        Dim Descripcion As String

        Descripcion = ""
        Select Case Codigo
            Case "00" : Descripcion = "TRANSACCION EXITOSA"
            Case "01" : Descripcion = "TELEFONO INVALIDO REVISAR TELEFONIA"
            Case "02" : Descripcion = "DESTINO NO DISPONIBLE"
            Case "03" : Descripcion = "MONTO NO VALIDO"
            Case "04" : Descripcion = "NO SE PUEDE ABONAR"
            Case "05" : Descripcion = "SALDO INSUFICIENTE"
            Case "06" : Descripcion = "MANTENIMIENTO OPERADORA EN CURSO"
            Case "07" : Descripcion = "RECHAZO TABLA DE TRANSACCIONES LLENA"
            Case "08" : Descripcion = "TIME-OUT OPERADORA"
            Case "09" : Descripcion = "AUTORIZADOR NO DISPONIBLE"
            Case "10" : Descripcion = "INTERMITENCIA EN SERVICIO"
            Case "11" : Descripcion = "OPERADORA NO DISPONIBLE"
            Case "12" : Descripcion = "DATOS INCORRECTOS"
            Case "13" : Descripcion = "FECHA PDV NO VALIDA"
            Case "14" : Descripcion = "USUARIO BLOQUEADO"
            Case "15" : Descripcion = "REINTENTO NO VALIDO, INTENTE EN 3 MIN"
            Case "16" : Descripcion = "PRODUCTO NO DISPONIBLE"
            Case "17" : Descripcion = "MOVIMIENTO NO ENCONTRADO"
            Case "18" : Descripcion = "MOVIMIENTO YA REVERSADO"
            Case "19" : Descripcion = "MOVIMIENTO NO AUTORIZADO"
            Case "20" : Descripcion = "ERROR INDETERMINADO"
            Case "21" : Descripcion = "NO SE PUDO REVERSAR"
            Case "22" : Descripcion = "TIME-OUT OPERADORA"
            Case "23" : Descripcion = "ERROR DE LA BASE DE DATOS OPERADORA"
            Case "25" : Descripcion = "APLICATIVO NO VALIDO"
            Case "30" : Descripcion = "OPERADORA NO DISPONIBLE"
            Case "66" : Descripcion = "MANTENIMIENTO EN OPERADORA"
            Case "72" : Descripcion = "TIME-OUT OPERADORA"
            Case "73" : Descripcion = "TIME-OUT OPERADORA"
            Case "75" : Descripcion = "TIME-OUT OPERADORA"
            Case "83" : Descripcion = "TIME-OUT OPERADORA"
            Case "87" : Descripcion = "TELEFONO NO SUSCEPTIBLE DE ABONO"
            Case "91" : Descripcion = "TIME-OUT OPERADORA"
            Case "96" : Descripcion = "TIME-OUT OPERADORA"

        End Select
        DSCESTATUS = Descripcion

    End Function

    Public Function fTextosaldo(ByVal Puntoventa As String, ByVal Password As String, ByVal Producto As String, ByVal Telefono As String, ByVal Folio As String, ByVal Fecha As String) As String
        Dim fxml As String
        fxml = ""
        fxml = fxml & "<SALDO>"
        fxml = fxml & "<PuntoVenta>" & Trim(Puntoventa) & "</PuntoVenta>"
        fxml = fxml & "<Password>" & Trim(Password) & "</Password>"
        fxml = fxml & "<FechaInicio>" & Now & "</FechaInicio>"
        fxml = fxml & "<Tipo>" & "TAE" & "</Tipo>"
        fxml = fxml & "</SALDO>"
        fTextosaldo = fxml
    End Function


    Public Function fTextoCompraTiempoaire(ByVal Puntoventa As String, ByVal Password As String, ByVal Producto As String, ByVal Telefono As String, ByVal Folio As String, ByVal Fecha As String) As String
        Dim fxml As String
        fxml = ""
        fxml = fxml & "<SOLICITARTRANSACCION>"
        fxml = fxml & "<PuntoVenta>" & Trim(Puntoventa) & "</PuntoVenta>"
        fxml = fxml & "<Password>" & Trim(Password) & "</Password>"
        fxml = fxml & "<Producto>" & Trim(Producto) & "</Producto>"
        fxml = fxml & "<FechaVenta>" & Now & "</FechaVenta>"
        fxml = fxml & "<Telefono>" & Trim(Telefono) & "</Telefono>"
        fxml = fxml & "<Folio>" & Trim(Folio) & "</Folio>"
        fxml = fxml & "<FechaInicio>" & Now & "</FechaInicio>"
        fxml = fxml & "</SOLICITARTRANSACCION>"
        fTextoCompraTiempoaire = fxml
    End Function


    Function EnviarTransaccion(ByVal Puntoventa As String, ByVal Password As String, ByVal Producto As String, ByVal Telefono As String, ByVal Folio As String, ByVal Fecha As String, ByVal estatus As String) As String
        Dim strSoap As String
        Dim strSOAPAction As String
        'Dim strWsdl As String
        Dim strurl As String
        ' Dim Resultado As String


        'MsgBox("entre a enviar la transaccion", MsgBoxStyle.Exclamation)


        '------------------------------------------------------------------------------------------
        '------------------------   LOS DATOS DE LA TRANSACCION -----------------------------
        strSoap = fTextoCompraTiempoaire(Puntoventa, Password, Producto, Telefono, CStr(CDbl(Folio)), "")
        ' strSoap = fTextosaldo(Puntoventa, Password, Producto, Telefono, CStr(CDbl(Folio)), "")
        '
        '------------------------------------------------------------------------------------------

        ' MsgBox(strSoap, MsgBoxStyle.Exclamation)


        'strurl = "http://201.174.6.146:4451/service.asmx?WDSL"
        'strSOAPAction = Chr(34) & "https://www.prepago.com.mx/webservice/wsTransaction" & Chr(34)


        strurl = "https://h2h.m3rcurio.com/wsTransactions.asmx?WSDL"
        strSOAPAction = Chr(34) & "http://tempuri.org/wsTransaction" & Chr(34)

        Dim myXML As XMLHTTP30
        myXML = New XMLHTTP30

        myXML.open("POST", strurl, False)
        myXML.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
        myXML.setRequestHeader("SOAPAction", strSOAPAction)

        Dim Node As IXMLDOMProcessingInstruction
        Dim xmlSrcDoc As MSXML2.DOMDocument30
        xmlSrcDoc = New MSXML2.DOMDocument30

        xmlSrcDoc.async = False
        xmlSrcDoc.validateOnParse = False
        xmlSrcDoc.resolveExternals = False
        xmlSrcDoc.preserveWhiteSpace = True

        Node = Nothing

        Dim soapEnvelope As IXMLDOMElement
        'MsgBox("PASE 1", MsgBoxStyle.Exclamation)
        soapEnvelope = xmlSrcDoc.createElement("s:Envelope")
        soapEnvelope.setAttribute("xmlns:s", "http://schemas.xmlsoap.org/soap/envelope/")
        xmlSrcDoc.appendChild(soapEnvelope)
        Dim soapBody As IXMLDOMElement
        soapBody = xmlSrcDoc.createElement("s:Body")
        soapEnvelope.appendChild(soapBody)

        'MsgBox("PASE 2", MsgBoxStyle.Exclamation)
        Dim soapCall As IXMLDOMElement
        soapCall = xmlSrcDoc.createElement("wsTransaction")
        soapCall.setAttribute("xmlns", "http://tempuri.org/")

        'soapCall.setAttribute("xmlns", "https://www.prepago.com.mx/webservice")

        '        MsgBox("PASE 3", MsgBoxStyle.Exclamation)
        soapCall.setAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance")
        'soapCall.setAttribute "xmlns:i", "http://www.w3.org/2001/XMLSchema-instance"
        soapBody.appendChild(soapCall)
        ' finally add the argument(s)
        Dim soapxmlVenta As IXMLDOMElement
        soapxmlVenta = xmlSrcDoc.createElement("xmlVenta")
        soapxmlVenta.text = strSoap
        soapCall.appendChild(soapxmlVenta)

        ' let it go!
        myXML.send("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " ?> " & xmlSrcDoc.xml)

        Dim xmlDoc As MSXML2.DOMDocument30
        xmlDoc = myXML.responseXML
        Dim Codigo As String

        MsgBox(xmlDoc.text)

        Codigo = Mid(xmlDoc.text, 26, 2)
        If Codigo = "00" Then
            Dim Posicion As Integer
            Dim foliotexto As String
            foliotexto = ""
            Posicion = InStrRev(xmlDoc.text, "<Folio>") + 7

            Do While Mid(xmlDoc.text, Posicion, 1) <> "<"
                If Mid(xmlDoc.text, Posicion, 1) <> "" Then
                    foliotexto = foliotexto & Mid(xmlDoc.text, Posicion, 1)
                End If
                Posicion = Posicion + 1
            Loop
            FOLIOAUT = foliotexto
        Else
            FOLIOAUT = 0
        End If

        estatus = myXML.status
        EnviarTransaccion = Codigo

    End Function

    Public Sub evaluarresultado(ByVal XmlResponse)
        Dim i As Integer
        Dim J As Integer

        For i = 0 To XmlResponse.documentElement.childNodes.Length
            For J = 0 To 3
                MsgBox(XmlResponse.documentElement.childNodes(i).childNodes(J).childNodes(0).XML)
            Next J
        Next i

    End Sub

    '-----------------------------------------------------------------
    '--------XML PARA  CONSULTAR UNA TRANSACCION

    Function fTextoConsultaCompraTiempo(ByVal Puntoventa As String, ByVal Password As String, ByVal Telefono As String, ByVal Folio As String)
        Dim fxml As String
        fxml = ""
        'fxml.WriteLine "<?xml version=" & comma & "1.0" & comma & " encoding=" & comma & "utf-8" & comma & "?>"
        fxml = fxml & "<CONSULTARTRANSACCION>"
        fxml = fxml & "<PuntoVenta>" & Trim(Puntoventa) & "</PuntoVenta>"
        fxml = fxml & "<Password>" & Trim(Password) & "</Password>"
        fxml = fxml & "<Telefono>" & Trim(Telefono) & "</Telefono>"
        fxml = fxml & "<FolioCaja>" & Trim(Folio) & "</FolioCaja>"
        fxml = fxml & "</CONSULTARTRANSACCION>"
        fTextoConsultaCompraTiempo = fxml
    End Function



    Function consultartrans(ByVal Puntoventa As String, ByVal Password As String, ByVal Telefono As String, ByVal Folio As String, ByVal estatus As String) As String
        Dim strSoap As String
        Dim strSOAPAction As String
        '   Dim strWsdl As String
        Dim strurl As String
        '  Dim Resultado As String


        '------------------------------------------------------------------------------------------
        '------------------------   LOS DATOS DE LA TRANSACCION -----------------------------
        strSoap = fTextoConsultaCompraTiempo(Puntoventa, Password, Telefono, Folio)
        '------------------------------------------------------------------------------------------

        'strurl = "http://201.174.6.146:4451/service.asmx?WDSL"
        'strSOAPAction = Chr(34) & "https://www.prepago.com.mx/webservice/wsTransaction" & Chr(34)


        strurl = "https://h2h.m3rcurio.com/wsTransactions.asmx?WSDL"
        strSOAPAction = Chr(34) & "http://tempuri.org/wsTransaction" & Chr(34)


        Dim myXML As XMLHTTP30
        myXML = New XMLHTTP30

        myXML.open("POST", strurl, False)
        myXML.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
        myXML.setRequestHeader("SOAPAction", strSOAPAction)

        Dim Node As IXMLDOMProcessingInstruction
        Dim xmlSrcDoc As MSXML2.DOMDocument30
        xmlSrcDoc = New MSXML2.DOMDocument30

        xmlSrcDoc.async = False
        xmlSrcDoc.validateOnParse = False
        xmlSrcDoc.resolveExternals = False
        xmlSrcDoc.preserveWhiteSpace = True

        Node = Nothing
        Dim soapEnvelope As IXMLDOMElement
        soapEnvelope = xmlSrcDoc.createElement("s:Envelope")
        soapEnvelope.setAttribute("xmlns:s", "http://schemas.xmlsoap.org/soap/envelope/")
        xmlSrcDoc.appendChild(soapEnvelope)
        Dim soapBody As IXMLDOMElement
        soapBody = xmlSrcDoc.createElement("s:Body")
        soapEnvelope.appendChild(soapBody)
        Dim soapCall As IXMLDOMElement
        soapCall = xmlSrcDoc.createElement("wsTransaction")
        soapCall.setAttribute("xmlns", "http://tempuri.org/")

        'soapCall.setAttribute("xmlns", "https://www.prepago.com.mx/webservice")


        soapCall.setAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance")
        soapBody.appendChild(soapCall)
        ' finally add the argument(s)
        Dim soapxmlVenta As IXMLDOMElement
        soapxmlVenta = xmlSrcDoc.createElement("xmlVenta")
        soapxmlVenta.text = strSoap
        soapCall.appendChild(soapxmlVenta)

        ' let it go!
        myXML.send("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " ?> " & xmlSrcDoc.xml)

        Dim xmlDoc As MSXML2.DOMDocument30
        xmlDoc = myXML.responseXML
        Dim Codigo As String

        '   MsgBox(xmlDoc.text)

        Codigo = Mid(xmlDoc.text, 26, 2)


        estatus = myXML.status
        consultartrans = Codigo

    End Function

    Private Sub btn_continuar_KeyDown(sender As Object, e As KeyEventArgs) Handles btn_continuar.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Class ItemAcumulado
        Public Clave As String
        Public UPC As String
        Public Descripcion As String
        Public Familia As String

        ' Valores Acumulables
        Public Cantidad As Decimal = 0
        Public Total As Decimal = 0
        Public CostoTotal As Decimal = 0
        Public ImporteIVA As Decimal = 0
        Public ImporteIEPS As Decimal = 0

        ' Valores Unitarios/Fijos (Se toman del último registro o se promedian, usualmente son fijos por UPC)
        Public PrecioU As Decimal
        Public CostoU As Decimal
        Public PorcIVA As Decimal
        Public PorcIEPS As Decimal

        ' Flags
        Public F1 As Integer
        Public F2 As Integer
        Public F3 As Integer
        Public F6 As Integer
    End Class
End Class
'Imports System.Data.SqlClient
'Imports MSXML2
'Imports System.Threading
'Public Class FrCambio

'    Inherits System.Windows.Forms.Form
'    Dim fo As FrVenta
'    Public FOLIOAUT As Integer
'    Dim SEPROCESO As Boolean
'    Private preImpresion As Collection
'    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
'    Friend WithEvents Panel1 As System.Windows.Forms.Panel
'    Friend WithEvents Label3 As System.Windows.Forms.Label
'    Private prepagos As Collection
'#Region " Código generado por el Diseñador de Windows Forms "

'    Public Sub New(ByRef forma As FrVenta)

'        MyBase.New()

'        'El Diseñador de Windows Forms requiere esta llamada.
'        InitializeComponent()
'        fo = forma


'        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

'    End Sub

'    'Form reemplaza a Dispose para limpiar la lista de componentes.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Requerido por el Diseñador de Windows Forms
'    Private components As System.ComponentModel.IContainer

'    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
'    'Puede modificarse utilizando el Diseñador de Windows Forms. 
'    'No lo modifique con el editor de código.
'    Friend WithEvents Label1 As System.Windows.Forms.Label
'    Friend WithEvents tx_totalventa As System.Windows.Forms.Label
'    Friend WithEvents tx_totalpago As System.Windows.Forms.Label
'    Friend WithEvents tx_cambio As System.Windows.Forms.Label
'    Friend WithEvents btn_continuar As System.Windows.Forms.Button
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'        Me.Label1 = New System.Windows.Forms.Label()
'        Me.tx_totalventa = New System.Windows.Forms.Label()
'        Me.tx_totalpago = New System.Windows.Forms.Label()
'        Me.tx_cambio = New System.Windows.Forms.Label()
'        Me.btn_continuar = New System.Windows.Forms.Button()
'        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
'        Me.Panel1 = New System.Windows.Forms.Panel()
'        Me.Label3 = New System.Windows.Forms.Label()
'        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
'        Me.Panel1.SuspendLayout()
'        Me.SuspendLayout()
'        '
'        'Label1
'        '
'        Me.Label1.BackColor = System.Drawing.Color.Transparent
'        Me.Label1.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
'        Me.Label1.Location = New System.Drawing.Point(163, 9)
'        Me.Label1.Name = "Label1"
'        Me.Label1.Size = New System.Drawing.Size(365, 99)
'        Me.Label1.TabIndex = 1
'        Me.Label1.Text = "GRACIAS POR SU COMPRA"
'        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'tx_totalventa
'        '
'        Me.tx_totalventa.BackColor = System.Drawing.Color.Transparent
'        Me.tx_totalventa.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.tx_totalventa.ForeColor = System.Drawing.Color.White
'        Me.tx_totalventa.Location = New System.Drawing.Point(97, 7)
'        Me.tx_totalventa.Name = "tx_totalventa"
'        Me.tx_totalventa.Size = New System.Drawing.Size(328, 40)
'        Me.tx_totalventa.TabIndex = 1
'        '
'        'tx_totalpago
'        '
'        Me.tx_totalpago.BackColor = System.Drawing.Color.Transparent
'        Me.tx_totalpago.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.tx_totalpago.ForeColor = System.Drawing.Color.White
'        Me.tx_totalpago.Location = New System.Drawing.Point(97, 47)
'        Me.tx_totalpago.Name = "tx_totalpago"
'        Me.tx_totalpago.Size = New System.Drawing.Size(328, 40)
'        Me.tx_totalpago.TabIndex = 2
'        '
'        'tx_cambio
'        '
'        Me.tx_cambio.BackColor = System.Drawing.Color.Transparent
'        Me.tx_cambio.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.tx_cambio.ForeColor = System.Drawing.Color.White
'        Me.tx_cambio.Location = New System.Drawing.Point(97, 87)
'        Me.tx_cambio.Name = "tx_cambio"
'        Me.tx_cambio.Size = New System.Drawing.Size(328, 40)
'        Me.tx_cambio.TabIndex = 4
'        '
'        'btn_continuar
'        '
'        Me.btn_continuar.BackColor = System.Drawing.Color.Transparent
'        Me.btn_continuar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.BOTON_NUEVO
'        Me.btn_continuar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.btn_continuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'        Me.btn_continuar.ForeColor = System.Drawing.Color.Goldenrod
'        Me.btn_continuar.Location = New System.Drawing.Point(432, 436)
'        Me.btn_continuar.Name = "btn_continuar"
'        Me.btn_continuar.Size = New System.Drawing.Size(49, 49)
'        Me.btn_continuar.TabIndex = 5
'        Me.btn_continuar.UseVisualStyleBackColor = False
'        '
'        'PictureBox3
'        '
'        Me.PictureBox3.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.logoDUARSA
'        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox3.Location = New System.Drawing.Point(32, 23)
'        Me.PictureBox3.Name = "PictureBox3"
'        Me.PictureBox3.Size = New System.Drawing.Size(83, 52)
'        Me.PictureBox3.TabIndex = 430
'        Me.PictureBox3.TabStop = False
'        '
'        'Panel1
'        '
'        Me.Panel1.BackColor = System.Drawing.Color.Orange
'        Me.Panel1.Controls.Add(Me.tx_cambio)
'        Me.Panel1.Controls.Add(Me.tx_totalpago)
'        Me.Panel1.Controls.Add(Me.tx_totalventa)
'        Me.Panel1.Location = New System.Drawing.Point(20, 111)
'        Me.Panel1.Name = "Panel1"
'        Me.Panel1.Size = New System.Drawing.Size(533, 170)
'        Me.Panel1.TabIndex = 431
'        '
'        'Label3
'        '
'        Me.Label3.BackColor = System.Drawing.Color.Transparent
'        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label3.ForeColor = System.Drawing.Color.DarkGray
'        Me.Label3.Location = New System.Drawing.Point(487, 436)
'        Me.Label3.Name = "Label3"
'        Me.Label3.Size = New System.Drawing.Size(91, 58)
'        Me.Label3.TabIndex = 432
'        Me.Label3.Text = "CONTINUAR"
'        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'FrCambio
'        '
'        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'        Me.BackColor = System.Drawing.Color.White
'        Me.ClientSize = New System.Drawing.Size(625, 543)
'        Me.Controls.Add(Me.Label3)
'        Me.Controls.Add(Me.Panel1)
'        Me.Controls.Add(Me.PictureBox3)
'        Me.Controls.Add(Me.btn_continuar)
'        Me.Controls.Add(Me.Label1)
'        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
'        Me.Location = New System.Drawing.Point(160, 80)
'        Me.Name = "FrCambio"
'        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
'        Me.Text = "Gracias Por Su Compra"
'        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
'        Me.Panel1.ResumeLayout(False)
'        Me.ResumeLayout(False)

'    End Sub

'#End Region

'    Private Sub FrCambio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Dim valor As String
'        Dim valor1 As String
'        FOLIOAUT = 0
'        SEPROCESO = False
'        valor = fo.ntx_totalventa.Text
'        Me.tx_totalventa.Text = "Total Venta: " & Format(Val(valor), "$###,###.00")
'        valor1 = fo.ntx_totalpago.Text
'        Me.tx_totalpago.Text = "Total Pago : " & Format(Val(valor1), "$###,###.00")
'        Me.tx_cambio.Text = " Su Cambio : " & Format(Val(valor1) - Val(valor), "$###,###.00")
'        Call empieza()

'    End Sub

'    Private Sub empieza()
'        btn_continuar.Focus()
'    End Sub

'    Private Sub BorraTicketHandler(ByVal Mensaje As String, ByVal TmpAuxVta As Boolean, ByVal TmpAuxVta1 As Boolean, ByVal ECVenta As Boolean, ByVal LigasFolios As Boolean, ByVal ECVentaDete As Boolean, ByVal ECVentaDet As Boolean, ByVal ECDetVenta As Boolean)
'        Dim BorraTmpAuxVta As Boolean = Nothing
'        Dim BorraTmpAuxVta1 As Boolean = Nothing
'        Dim BorraECVenta As Boolean = Nothing
'        Dim BorraLigasFolios As Boolean = Nothing
'        Dim BorraECVentaDete As Boolean = Nothing
'        Dim BorraECDetVenta As Boolean = Nothing
'        Dim BorraECVentaDet As Boolean = Nothing

'        If TmpAuxVta Then
'            Try
'                Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", fo.xCon)
'                BorraTmpAuxVta = True
'            Catch ex As Exception
'                BorraTmpAuxVta = False
'            End Try
'        End If
'        If TmpAuxVta1 Then
'            Try
'                Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", fo.xCon)
'                BorraTmpAuxVta1 = True
'            Catch ex As Exception
'                BorraTmpAuxVta1 = False
'            End Try
'        End If
'        If ECVenta Then
'            Try
'                Base.Ejecuta("delete from ecventa where ven_id=" & fo.xven & " and ven_usuario='" & "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "'", fo.xCon)
'                BorraECVenta = True
'            Catch ex As Exception
'                BorraECVenta = False
'            End Try
'        End If
'        If LigasFolios Then
'            Try
'                Base.Ejecuta("delete from Ligasfolios where ven_id=" & fo.xven, fo.xCon)
'                BorraLigasFolios = True
'            Catch ex As Exception
'                BorraLigasFolios = False
'            End Try
'        End If
'        If ECVentaDete Then
'            Try
'                Base.Ejecuta("delete from ecventadete where dve_venta=" & fo.xven, fo.xCon)
'                BorraECVentaDete = True
'            Catch ex As Exception
'                BorraECVentaDete = False
'            End Try
'        End If
'        If ECVentaDet Then
'            Try
'                Base.Ejecuta("delete from ecdetventa where dve_venta=" & fo.xven, fo.xCon)
'                BorraECDetVenta = True
'            Catch ex As Exception
'                BorraECDetVenta = False
'            End Try
'        End If
'        If ECDetVenta Then
'            Try
'                Base.Ejecuta("delete from ecventadet where dve_venta=" & fo.xven, fo.xCon)
'                BorraECVentaDet = True
'            Catch ex As Exception
'                BorraECVentaDet = False
'            End Try
'        End If

'        Dim Mensaje2 As String = ""
'        Dim Pendientes As String = ""
'        Dim Borradas As String = ""

'        If ((BorraTmpAuxVta Or BorraTmpAuxVta = Nothing) And (BorraTmpAuxVta1 Or BorraTmpAuxVta1 = Nothing) And (BorraECVenta Or BorraECVenta = Nothing) And (BorraECVentaDete Or BorraECVentaDete = Nothing) And (BorraECDetVenta And BorraECDetVenta = Nothing) And (BorraECVentaDet Or BorraECVentaDet = Nothing)) Then
'            'If (BorraTmpAuxVta And BorraTmpAuxVta1 And BorraECVenta And BorraECVentaDete And BorraECDetVenta And BorraECVentaDet) Then
'            Mensaje2 = "Progreso borrado correctamente."
'        Else
'            If TmpAuxVta Then
'                If BorraTmpAuxVta Then
'                    Borradas = IIf(Borradas = "", "TmpAuxVta", Borradas & ", TmpAuxVta")
'                Else
'                    Pendientes = IIf(Pendientes = "", "TmpAuxVta", Pendientes & ", TmpAuxVta")
'                End If
'            End If

'            If TmpAuxVta1 Then
'                If BorraTmpAuxVta1 Then
'                    Borradas = IIf(Borradas = "", "TmpAuxVta1", Borradas & ", TmpAuxVta1")
'                Else
'                    Pendientes = IIf(Pendientes = "", "TmpAuxVta1", Pendientes & ", TmpAuxVta1")
'                End If
'            End If

'            If ECVenta Then
'                If BorraTmpAuxVta Then
'                    Borradas = IIf(Borradas = "", "ECVenta", Borradas & ", ECVenta")
'                Else
'                    Pendientes = IIf(Pendientes = "", "ECVenta", Pendientes & ", ECVenta")
'                End If
'            End If

'            If LigasFolios Then
'                If BorraLigasFolios Then
'                    Borradas = IIf(Borradas = "", "LigasFolios", Borradas & ", LigasFolios")
'                Else
'                    Pendientes = IIf(Pendientes = "", "LigasFolios", Pendientes & ", LigasFolios")
'                End If
'            End If

'            If ECVentaDete Then
'                If BorraTmpAuxVta Then
'                    Borradas = IIf(Borradas = "", "ECVentaDete", Borradas & ", ECVentaDete")
'                Else
'                    Pendientes = IIf(Pendientes = "", "ECVentaDete", Pendientes & ", ECVentaDete")
'                End If
'            End If

'            If ECDetVenta Then
'                If BorraTmpAuxVta Then
'                    Borradas = IIf(Borradas = "", "ECDetVenta", Borradas & ", ECDetVenta")
'                Else
'                    Pendientes = IIf(Pendientes = "", "ECDetVenta", Pendientes & ", ECDetVenta")
'                End If
'            End If

'            If ECVentaDet Then
'                If BorraTmpAuxVta Then
'                    Borradas = IIf(Borradas = "", "ECVentaDet", Borradas & ", ECVentaDet")
'                Else
'                    Pendientes = IIf(Pendientes = "", "ECVentaDet", Pendientes & ", ECVentaDet")
'                End If
'            End If

'            If Pendientes <> "" Then
'                Mensaje2 = " No pudo borrarse la información de " & Pendientes & ", "
'            End If
'            If Borradas <> "" Then
'                Mensaje2 = Mensaje2 & " sólo de " & Borradas & "."
'            Else
'                Mensaje2 = Strings.Left(Mensaje2, Len(Mensaje2) - 2) & "."
'            End If
'        End If
'        MsgBox(Mensaje & " " & Mensaje2, MsgBoxStyle.Critical, "Punto de Venta")
'    End Sub

'    Private Sub BorraFormaPagoHandler(ByVal Ticket As Integer)
'        Try
'            Base.Ejecuta("delete from ECFormaPago where referencia=" & Ticket, fo.xCon)
'            Try
'                Base.Ejecuta("delete from ECTarjetas where Tar_VentaID=" & Ticket, fo.xCon)
'                Try
'                    Base.Ejecuta("delete from ECTransfer where Tra_VentaID=" & Ticket, fo.xCon)
'                    Try
'                        Base.Ejecuta("delete from ECcuentasXCob where CxC_Folio=" & Ticket, fo.xCon)
'                        Try
'                            Dim SQL As String
'                            SQL = "update ecventa.dbo.ECDETCLIENTEEMP set DCLI_SALDO=Saldo from ecventa.dbo.eccuentasxcob e join (" &
'                                    "Select e.DCLI_CLAVE,COALESCE(SUM(cxc_saldo) ,0) Saldo  from ecventa.dbo.ECDETCLIENTEEMP e join ecventa.dbo.eccuentasxcob x on DCLI_CLAVE=cxc_cliente " &
'                                    "group by e.DCLI_CLAVE) a on a.DCLI_CLAVE=e.cxc_cliente where ecventa.dbo.ECDETCLIENTEEMP.DCLI_CLAVE=e.cxc_cliente"
'                            Base.Ejecuta(SQL, fo.xCon)
'                        Catch ex As Exception
'                            MsgBox("Error Crítico - Notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "No pudo actualizarse saldos de cliente en ECDetClienteEmp; sólo se borró progreso de tablas ECFormaPago, ECTarjetas, ECTransfer y ECCuentasXCob.", MsgBoxStyle.Critical, "Punto de Venta")
'                        End Try
'                    Catch ex As Exception
'                        MsgBox("Error Crítico - Notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "No pudo borrarse la información de la tabla ECCuentasXCob, ni actualizar saldos de cliente en ECDetClienteEmp; sólo de ECFormaPago, ECTarjetas y ECTransfer.", MsgBoxStyle.Critical, "Punto de Venta")
'                    End Try
'                Catch ex As Exception
'                    MsgBox("Error Crítico - Notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "No pudo borrarse la información de las tablas ECTransfer, ECCuentasXCob, ni actualizar saldos de cliente en ECDetClienteEmp; sólo de ECFormaPago y ECTarjetas.", MsgBoxStyle.Critical, "Punto de Venta")
'                End Try
'            Catch ex As Exception
'                MsgBox("Error Crítico - Notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "No pudo borrarse la información de las tablas ECTarjetas, ECTransfer, ECCuentasXCob, ni actualizar saldos de cliente en ECDetClienteEmp; sólo de ECFormaPago.", MsgBoxStyle.Critical, "Punto de Venta")
'            End Try
'        Catch ex As Exception
'            MsgBox("Error Crítico - Notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "No pudo borrarse la información de las tablas ECFormaPago, ECTarjetas, ECTransfer, ECCuentasXCob, ni actualizar saldos de cliente en ECDetClienteEmp.", MsgBoxStyle.Critical, "Punto de Venta")
'        End Try
'    End Sub
'    Private Sub btn_continuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_continuar.Click
'        Dim sSql As String = ""
'        Dim dsc As New DataSet
'        Dim iID As Integer
'        Dim l As Integer
'        Dim valido As Integer
'        Dim lcaja As String
'        Dim Sw_Cancelar As Boolean
'        Dim autor As Form
'        Dim FolioCaja As String
'        Dim FolioSerie As String
'        Dim Counter As Integer

'        btn_continuar.Enabled = False
'        Sw_Cancelar = False
'        lcaja = "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1)
'        valido = 0
'        Counter = 0
'        fo.xven = 0
'        FolioCaja = ""
'        With fo.fp_articulos.ActiveSheet
'            While valido = 0 And Counter < 3
'                Base.daQuery("exec dasigfolio '" & lcaja & "'", fo.xCon, dsc, "Fo")
'                If dsc.Tables("Fo").Rows(0)("FolioN") > 0 Then
'                    fo.xven = CDbl(dsc.Tables("Fo").Rows(0)("FolioN"))
'                    FolioCaja = dsc.Tables("Fo").Rows(0)("FolioCaja")
'                End If
'                dsc.Tables.Remove("Fo")

'                'Base.Ejecuta("exec dasigfolio '" & lcaja & "'", fo.xCon)
'                'sSql = "select foliovta from tmpconsecu where caja='" & lcaja & "'"
'                'Base.daQuery(sSql, fo.xCon, dsc, "tablahel")
'                'If dsc.Tables("tablahel").Rows.Count > 0 Then
'                'fo.xven = CDbl(dsc.Tables("tablahel").Rows(0)("foliovta"))
'                'End If

'                If fo.xven = 0 Then
'                    valido = 0
'                    Counter += 1
'                Else
'                    valido = 1
'                End If
'                'Dim SQL As String
'                'Sql = "select isnull(ConsecutivoCaja,0)+1 Folio, Serie from tmpconsecu where caja='" & lcaja & "'"
'                'Base.daQuery(SQL, fo.xCon, dsc, "FolioSerie")
'                'If dsc.Tables("FolioSerie").Rows.Count > 0 Then
'                '    FolioSerie = dsc.Tables("FolioSerie").Rows(0)("Serie")
'                '    FolioCaja = FolioSerie & Strings.Right("000000" & dsc.Tables("FolioSerie").Rows(0)("Folio"), 6)
'                'End If
'                'dsc.Tables.Remove("FolioSerie")
'                'dsc.Tables.Remove("Tablahel")
'            End While

'            iID = fo.xven

'        End With

'        If iID = 0 Then
'            MsgBox("No puede cerrarse la venta, notifique a Jaime Burciaga.", vbCritical, "Punto de Venta")
'            Exit Sub
'        End If

'        'If fo.HayTarjeta Then
'        '    fo.SacaProporcionP1P2(iID)
'        'End If



'        Dim Ticket = fo.GuardaTicketConHandler(FolioCaja)
'        If Ticket.Mensaje = "OK" Then
'            If Not fo.GuardaFormaDePagoConHandler() Then
'                BorraFormaPagoHandler(iID)
'                BorraTicketHandler(Ticket.Mensaje, Ticket.TmpAuxVta, Ticket.TmpAuxVta1, Ticket.ECVenta, Ticket.LigasFolios, Ticket.ECVentaDete, Ticket.ECVentaDet, Ticket.ECDetVenta)
'                Exit Sub
'            End If
'        Else
'            BorraTicketHandler(Ticket.Mensaje, Ticket.TmpAuxVta, Ticket.TmpAuxVta1, Ticket.ECVenta, Ticket.LigasFolios, Ticket.ECVentaDete, Ticket.ECVentaDet, Ticket.ECDetVenta)
'            Exit Sub
'        End If


'        'If fo.TxtControl.Text.Trim <> "0" Then
'        fo.GuardaTicketCliente(CDbl(fo.TxtControl.Text.Trim), fo.xven)
'        'End If


'        Dim oPreImpre As New preImpresion(Me.tx_cambio.Text, fo.fp_articulos, Globales.sDireccion, Globales.sNominaEmpleado, Globales.NombreEmpleado, fo.LbTotal.Text.Replace(",", ""), iID, fo.xCon)
'        preImpresion = oPreImpre.COLECCION


'        Dim imprimevirtual As New previrtual(fo.fp_articulos, iID, fo.xCon)
'        fo.imprimeTicket(preImpresion)

'        If fo.estiempoaire Then

'            '   MsgBox("ESTOY EN TIEMPO AIRE", MsgBoxStyle.Exclamation)

'            Dim password As String
'            Dim puntoventa As String
'            Dim producto As String
'            Dim respuesta As String
'            Dim txttelefono As String
'            Dim xestatus As String
'            '----------- PARA GENERAR TIEMPO AIRE
'            xestatus = ""
'            puntoventa = "SERVDUARSA"
'            password = "Duarsa1.1"


'            'puntoventa = "PRUEBA0000"
'            'password = "432143"


'            producto = fo.claveprod


'            'MsgBox(producto, MsgBoxStyle.Exclamation)

'            txttelefono = fo.txt_ctel1.Text & fo.txt_ctel2.Text & fo.txt_ctel3.Text & fo.txt_ctel4.Text


'            'MsgBox(txttelefono, MsgBoxStyle.Exclamation)


'            respuesta = EnviarTransaccion(puntoventa, password, producto, txttelefono, ("000000" & iID.ToString).Substring(Len("000000" & iID.ToString) - 6, 6), "", xestatus)


'            MsgBox(DSCESTATUS(respuesta))


'            Dim Sw_Cancelar_Venta As Boolean

'            Sw_Cancelar_Venta = False

'            '-- 1. Solicitar TAE
'            '-- 2. Cerrar la transacción de Venta con estatus OPERADO
'            '-- 3. Validar los estatus en un LOOP de 5 intentos cada 3 segundos
'            '-- 4. Si al terminar el LOOP la respuesta NO es satifactoria CANCELAR venta y enviar por Switch Venta y Cancelación
'            '-- 5. Si la venta es satisfactoria actualizar el # de autorización de la Venta y enviar por Switch

'            '-- 2. Cerrar la transacción de Venta con estatus OPERADO
'            Dim Estatus_TAE_CONF As String
'            Dim estatus_tae As String = ""
'            Dim Sw_Consultar As Boolean
'            Dim Max_Consulta As Integer  '-- Indica el numero de veces que preguntara SI se aplico o NO
'            Dim Num_Consulta As Integer  '-- Indica el numero de consulta actual
'            Dim Segundos As Integer  '-- Indica los segundos que deben transcurrir entre cada consulta
'            '    Dim Sw_Cancelar As Boolean

'            Estatus_TAE_CONF = ""
'            Sw_Consultar = True
'            Max_Consulta = 3
'            Num_Consulta = 1
'            Segundos = 5

'            '-- 3. Validar los estatus en un LOOP de 5 intentos cada 3 segundos
'            Do While Sw_Consultar
'                Thread.Sleep(Segundos * 50)
'                Estatus_TAE_CONF = consultartrans(puntoventa, password, txttelefono, ("000000" & iID.ToString).Substring(Len("000000" & iID.ToString) - 6, 6), estatus_tae)

'                Select Case Estatus_TAE_CONF
'                    Case "22"   '-- ReIntentar hasta Max_Consulta
'                        If Num_Consulta + 1 > Max_Consulta Then
'                            Sw_Consultar = False
'                        End If
'                    Case "30"   '-- No se pudo conectar al HOST
'                        Sw_Consultar = True '-- Intentarlo las 5 veces
'                    Case "17"   '-- Transacción NO encontrada
'                        Sw_Consultar = False
'                    Case "00"   '-- El TAE se aplico correctamente
'                        Sw_Consultar = False
'                End Select
'                Num_Consulta = Num_Consulta + 1
'                If Num_Consulta > Max_Consulta Then
'                    Sw_Consultar = False
'                End If
'            Loop

'            If Estatus_TAE_CONF = "00" Then
'                Base.Ejecuta("UPDATE ecdetventatel  Set dve_folio=" & FOLIOAUT.ToString & " WHERE dve_venta=" & iID.ToString & "", fo.xCon)
'                Dim opretiempo As New pretiempoaire(iID, fo.xCon)
'                fo.imprimetaire(opretiempo.COLECCION)

'            Else
'                Sw_Cancelar = True
'            End If
'        End If

'        fo.segundoticket = False
'        For l = 0 To fo.fp_articulos.ActiveSheet.RowCount - 1
'            If fo.fp_articulos.ActiveSheet.Cells(l, 5).Text = "*" Then
'                fo.segundoticket = True
'            End If
'        Next
'        If fo.segundoticket = True Then
'            'MsgBox("Arracar Ticket")
'            Dim vImpresion As Impresion
'            vImpresion = New Impresion(imprimevirtual.COLECCION)
'            vImpresion.imprime(True)
'            ''fo.imprimevirtual(imprimevirtual.COLECCION)
'        End If


'        If fo.pagare = True Then
'            Dim deudor As String
'            Dim direccion As String
'            Dim telefono As String
'            Dim saldo As String
'            Dim credito As String
'            Dim comando As New SqlCommand
'            Dim rdr As SqlDataReader
'            deudor = ""
'            direccion = ""
'            telefono = ""
'            comando.CommandText = "Select cli_nombre,cli_direccion,'' cli_telefono,dcli_saldo cli_saldo ,cli_clave id_credito from ecclientes inner join ecdetclienteemp on dcli_clave=cli_clave where dcli_empresa=1 and cli_clave=" & fo.clientex & ""
'            comando.Connection = fo.xCon
'            fo.xCon.Open()
'            Try
'                rdr = comando.ExecuteReader
'                rdr.Read()
'                deudor = rdr.GetValue(0)
'                direccion = rdr.GetValue(1)
'                telefono = rdr.GetValue(2)
'                saldo = rdr.GetValue(3)
'                credito = rdr.GetValue(4)
'            Catch ex As Exception
'                MsgBox(ex.Message)
'            End Try
'            fo.xCon.Close()
'            Dim totaluco As Double
'            Dim i As Integer
'            totaluco = 0
'            With fo.FP_FORMASPAGO.ActiveSheet
'                For i = 0 To .RowCount - 1
'                    If .Cells(i, 0).Value = "Credito" Then
'                        totaluco += .Cells(i, 1).Value
'                    End If
'                Next
'            End With
'            fo.tb_total.Text.Replace(",", "")
'            Dim prime As New prevales(totaluco.ToString, deudor, direccion, telefono, iID)
'            fo.imprimevirtual(prime.COLECCION)

'        End If

'        ' para aplicar el inventario

'        If Not fo.estiempoaire Then
'            If fo.sipuntos Then
'                Dim impuntos As New prepuntos(iID, fo.xCon)
'                fo.imprimevirtual(impuntos.COLECCION)
'            End If
'            fo.aplicainv()
'        Else
'            If Sw_Cancelar = True Then
'                Base.Ejecuta("UPDATE ECVENTA SET VEN_STATUS=2,VEN_DSCUSUARIO='" & Globales.nombreusuario & "',VEN_FECHACANC=GETDATE() , VEN_MOTIVO='" & " TIEMPO AIRE QUE NO SE ACREDITO " & "' WHERE VEN_ID=" & iID, fo.xCon)
'                '                Base.Ejecuta("EXEC APLICAVENTAINVENTARIO " & TICKET & ",4", xcon)DIF
'                '                    Base.Ejecuta("EXEC APLICAVENTAINVENTARIO " & TICKET & ",4", xcon)
'                MsgBox("No se aplicó el TIEMPO AIRE AL CLIENTE, DEVUELVA EL DINERO  , LA OPERACION SE HA CANCELADO ", MsgBoxStyle.Information)
'            Else
'                '----------------------------HAY QUE IMPRIMIR TICKET DEL TIEMPO AIRE
'            End If
'        End If

'        fo.sipuntos = False
'        fo.limpiaSpread(True)
'        fo.PERMISOVENDER = False
'        MsgBox("Teclee Enter para continuar", MsgBoxStyle.Exclamation)
'        Me.Dispose(True)
'        Me.Hide()
'        fo.pagare = False
'        fo.segundoticket = False
'        fo.txt_tipoventa.Text = "1"
'        fo.txt_tipoventa.Enabled = True
'        fo.txt_tipoventa.Focus()
'        fo.Label11.Text = "Fecha: " & Today.Day & " de " & MonthName(Today.Month) & " del " & Today.Year & " | Hora: " & Now.ToShortTimeString & " |"
'    End Sub


'    Function DSCESTATUS(ByVal Codigo As String)
'        Dim Descripcion As String

'        Descripcion = ""
'        Select Case Codigo
'            Case "00" : Descripcion = "TRANSACCION EXITOSA"
'            Case "01" : Descripcion = "TELEFONO INVALIDO REVISAR TELEFONIA"
'            Case "02" : Descripcion = "DESTINO NO DISPONIBLE"
'            Case "03" : Descripcion = "MONTO NO VALIDO"
'            Case "04" : Descripcion = "NO SE PUEDE ABONAR"
'            Case "05" : Descripcion = "SALDO INSUFICIENTE"
'            Case "06" : Descripcion = "MANTENIMIENTO OPERADORA EN CURSO"
'            Case "07" : Descripcion = "RECHAZO TABLA DE TRANSACCIONES LLENA"
'            Case "08" : Descripcion = "TIME-OUT OPERADORA"
'            Case "09" : Descripcion = "AUTORIZADOR NO DISPONIBLE"
'            Case "10" : Descripcion = "INTERMITENCIA EN SERVICIO"
'            Case "11" : Descripcion = "OPERADORA NO DISPONIBLE"
'            Case "12" : Descripcion = "DATOS INCORRECTOS"
'            Case "13" : Descripcion = "FECHA PDV NO VALIDA"
'            Case "14" : Descripcion = "USUARIO BLOQUEADO"
'            Case "15" : Descripcion = "REINTENTO NO VALIDO, INTENTE EN 3 MIN"
'            Case "16" : Descripcion = "PRODUCTO NO DISPONIBLE"
'            Case "17" : Descripcion = "MOVIMIENTO NO ENCONTRADO"
'            Case "18" : Descripcion = "MOVIMIENTO YA REVERSADO"
'            Case "19" : Descripcion = "MOVIMIENTO NO AUTORIZADO"
'            Case "20" : Descripcion = "ERROR INDETERMINADO"
'            Case "21" : Descripcion = "NO SE PUDO REVERSAR"
'            Case "22" : Descripcion = "TIME-OUT OPERADORA"
'            Case "23" : Descripcion = "ERROR DE LA BASE DE DATOS OPERADORA"
'            Case "25" : Descripcion = "APLICATIVO NO VALIDO"
'            Case "30" : Descripcion = "OPERADORA NO DISPONIBLE"
'            Case "66" : Descripcion = "MANTENIMIENTO EN OPERADORA"
'            Case "72" : Descripcion = "TIME-OUT OPERADORA"
'            Case "73" : Descripcion = "TIME-OUT OPERADORA"
'            Case "75" : Descripcion = "TIME-OUT OPERADORA"
'            Case "83" : Descripcion = "TIME-OUT OPERADORA"
'            Case "87" : Descripcion = "TELEFONO NO SUSCEPTIBLE DE ABONO"
'            Case "91" : Descripcion = "TIME-OUT OPERADORA"
'            Case "96" : Descripcion = "TIME-OUT OPERADORA"

'        End Select
'        DSCESTATUS = Descripcion

'    End Function

'    Public Function fTextosaldo(ByVal Puntoventa As String, ByVal Password As String, ByVal Producto As String, ByVal Telefono As String, ByVal Folio As String, ByVal Fecha As String) As String
'        Dim fxml As String
'        fxml = ""
'        fxml = fxml & "<SALDO>"
'        fxml = fxml & "<PuntoVenta>" & Trim(Puntoventa) & "</PuntoVenta>"
'        fxml = fxml & "<Password>" & Trim(Password) & "</Password>"
'        fxml = fxml & "<FechaInicio>" & Now & "</FechaInicio>"
'        fxml = fxml & "<Tipo>" & "TAE" & "</Tipo>"
'        fxml = fxml & "</SALDO>"
'        fTextosaldo = fxml
'    End Function


'    Public Function fTextoCompraTiempoaire(ByVal Puntoventa As String, ByVal Password As String, ByVal Producto As String, ByVal Telefono As String, ByVal Folio As String, ByVal Fecha As String) As String
'        Dim fxml As String
'        fxml = ""
'        fxml = fxml & "<SOLICITARTRANSACCION>"
'        fxml = fxml & "<PuntoVenta>" & Trim(Puntoventa) & "</PuntoVenta>"
'        fxml = fxml & "<Password>" & Trim(Password) & "</Password>"
'        fxml = fxml & "<Producto>" & Trim(Producto) & "</Producto>"
'        fxml = fxml & "<FechaVenta>" & Now & "</FechaVenta>"
'        fxml = fxml & "<Telefono>" & Trim(Telefono) & "</Telefono>"
'        fxml = fxml & "<Folio>" & Trim(Folio) & "</Folio>"
'        fxml = fxml & "<FechaInicio>" & Now & "</FechaInicio>"
'        fxml = fxml & "</SOLICITARTRANSACCION>"
'        fTextoCompraTiempoaire = fxml
'    End Function


'    Function EnviarTransaccion(ByVal Puntoventa As String, ByVal Password As String, ByVal Producto As String, ByVal Telefono As String, ByVal Folio As String, ByVal Fecha As String, ByVal estatus As String) As String
'        Dim strSoap As String
'        Dim strSOAPAction As String
'        'Dim strWsdl As String
'        Dim strurl As String
'        ' Dim Resultado As String


'        'MsgBox("entre a enviar la transaccion", MsgBoxStyle.Exclamation)


'        '------------------------------------------------------------------------------------------
'        '------------------------   LOS DATOS DE LA TRANSACCION -----------------------------
'        strSoap = fTextoCompraTiempoaire(Puntoventa, Password, Producto, Telefono, CStr(CDbl(Folio)), "")
'        ' strSoap = fTextosaldo(Puntoventa, Password, Producto, Telefono, CStr(CDbl(Folio)), "")
'        '
'        '------------------------------------------------------------------------------------------

'        ' MsgBox(strSoap, MsgBoxStyle.Exclamation)


'        'strurl = "http://201.174.6.146:4451/service.asmx?WDSL"
'        'strSOAPAction = Chr(34) & "https://www.prepago.com.mx/webservice/wsTransaction" & Chr(34)


'        strurl = "https://h2h.m3rcurio.com/wsTransactions.asmx?WSDL"
'        strSOAPAction = Chr(34) & "http://tempuri.org/wsTransaction" & Chr(34)

'        Dim myXML As XMLHTTP30
'        myXML = New XMLHTTP30

'        myXML.open("POST", strurl, False)
'        myXML.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
'        myXML.setRequestHeader("SOAPAction", strSOAPAction)

'        Dim Node As IXMLDOMProcessingInstruction
'        Dim xmlSrcDoc As MSXML2.DOMDocument30
'        xmlSrcDoc = New MSXML2.DOMDocument30

'        xmlSrcDoc.async = False
'        xmlSrcDoc.validateOnParse = False
'        xmlSrcDoc.resolveExternals = False
'        xmlSrcDoc.preserveWhiteSpace = True

'        Node = Nothing

'        Dim soapEnvelope As IXMLDOMElement
'        'MsgBox("PASE 1", MsgBoxStyle.Exclamation)
'        soapEnvelope = xmlSrcDoc.createElement("s:Envelope")
'        soapEnvelope.setAttribute("xmlns:s", "http://schemas.xmlsoap.org/soap/envelope/")
'        xmlSrcDoc.appendChild(soapEnvelope)
'        Dim soapBody As IXMLDOMElement
'        soapBody = xmlSrcDoc.createElement("s:Body")
'        soapEnvelope.appendChild(soapBody)

'        'MsgBox("PASE 2", MsgBoxStyle.Exclamation)
'        Dim soapCall As IXMLDOMElement
'        soapCall = xmlSrcDoc.createElement("wsTransaction")
'        soapCall.setAttribute("xmlns", "http://tempuri.org/")

'        'soapCall.setAttribute("xmlns", "https://www.prepago.com.mx/webservice")

'        '        MsgBox("PASE 3", MsgBoxStyle.Exclamation)
'        soapCall.setAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance")
'        'soapCall.setAttribute "xmlns:i", "http://www.w3.org/2001/XMLSchema-instance"
'        soapBody.appendChild(soapCall)
'        ' finally add the argument(s)
'        Dim soapxmlVenta As IXMLDOMElement
'        soapxmlVenta = xmlSrcDoc.createElement("xmlVenta")
'        soapxmlVenta.text = strSoap
'        soapCall.appendChild(soapxmlVenta)

'        ' let it go!
'        myXML.send("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " ?> " & xmlSrcDoc.xml)

'        Dim xmlDoc As MSXML2.DOMDocument30
'        xmlDoc = myXML.responseXML
'        Dim Codigo As String

'        MsgBox(xmlDoc.text)

'        Codigo = Mid(xmlDoc.text, 26, 2)
'        If Codigo = "00" Then
'            Dim Posicion As Integer
'            Dim foliotexto As String
'            foliotexto = ""
'            Posicion = InStrRev(xmlDoc.text, "<Folio>") + 7

'            Do While Mid(xmlDoc.text, Posicion, 1) <> "<"
'                If Mid(xmlDoc.text, Posicion, 1) <> "" Then
'                    foliotexto = foliotexto & Mid(xmlDoc.text, Posicion, 1)
'                End If
'                Posicion = Posicion + 1
'            Loop
'            FOLIOAUT = foliotexto
'        Else
'            FOLIOAUT = 0
'        End If

'        estatus = myXML.status
'        EnviarTransaccion = Codigo

'    End Function

'    Public Sub evaluarresultado(ByVal XmlResponse)
'        Dim i As Integer
'        Dim J As Integer

'        For i = 0 To XmlResponse.documentElement.childNodes.Length
'            For J = 0 To 3
'                MsgBox(XmlResponse.documentElement.childNodes(i).childNodes(J).childNodes(0).XML)
'            Next J
'        Next i

'    End Sub

'    '-----------------------------------------------------------------
'    '--------XML PARA  CONSULTAR UNA TRANSACCION

'    Function fTextoConsultaCompraTiempo(ByVal Puntoventa As String, ByVal Password As String, ByVal Telefono As String, ByVal Folio As String)
'        Dim fxml As String
'        fxml = ""
'        'fxml.WriteLine "<?xml version=" & comma & "1.0" & comma & " encoding=" & comma & "utf-8" & comma & "?>"
'        fxml = fxml & "<CONSULTARTRANSACCION>"
'        fxml = fxml & "<PuntoVenta>" & Trim(Puntoventa) & "</PuntoVenta>"
'        fxml = fxml & "<Password>" & Trim(Password) & "</Password>"
'        fxml = fxml & "<Telefono>" & Trim(Telefono) & "</Telefono>"
'        fxml = fxml & "<FolioCaja>" & Trim(Folio) & "</FolioCaja>"
'        fxml = fxml & "</CONSULTARTRANSACCION>"
'        fTextoConsultaCompraTiempo = fxml
'    End Function



'    Function consultartrans(ByVal Puntoventa As String, ByVal Password As String, ByVal Telefono As String, ByVal Folio As String, ByVal estatus As String) As String
'        Dim strSoap As String
'        Dim strSOAPAction As String
'        '   Dim strWsdl As String
'        Dim strurl As String
'        '  Dim Resultado As String


'        '------------------------------------------------------------------------------------------
'        '------------------------   LOS DATOS DE LA TRANSACCION -----------------------------
'        strSoap = fTextoConsultaCompraTiempo(Puntoventa, Password, Telefono, Folio)
'        '------------------------------------------------------------------------------------------

'        'strurl = "http://201.174.6.146:4451/service.asmx?WDSL"
'        'strSOAPAction = Chr(34) & "https://www.prepago.com.mx/webservice/wsTransaction" & Chr(34)


'        strurl = "https://h2h.m3rcurio.com/wsTransactions.asmx?WSDL"
'        strSOAPAction = Chr(34) & "http://tempuri.org/wsTransaction" & Chr(34)


'        Dim myXML As XMLHTTP30
'        myXML = New XMLHTTP30

'        myXML.open("POST", strurl, False)
'        myXML.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
'        myXML.setRequestHeader("SOAPAction", strSOAPAction)

'        Dim Node As IXMLDOMProcessingInstruction
'        Dim xmlSrcDoc As MSXML2.DOMDocument30
'        xmlSrcDoc = New MSXML2.DOMDocument30

'        xmlSrcDoc.async = False
'        xmlSrcDoc.validateOnParse = False
'        xmlSrcDoc.resolveExternals = False
'        xmlSrcDoc.preserveWhiteSpace = True

'        Node = Nothing
'        Dim soapEnvelope As IXMLDOMElement
'        soapEnvelope = xmlSrcDoc.createElement("s:Envelope")
'        soapEnvelope.setAttribute("xmlns:s", "http://schemas.xmlsoap.org/soap/envelope/")
'        xmlSrcDoc.appendChild(soapEnvelope)
'        Dim soapBody As IXMLDOMElement
'        soapBody = xmlSrcDoc.createElement("s:Body")
'        soapEnvelope.appendChild(soapBody)
'        Dim soapCall As IXMLDOMElement
'        soapCall = xmlSrcDoc.createElement("wsTransaction")
'        soapCall.setAttribute("xmlns", "http://tempuri.org/")

'        'soapCall.setAttribute("xmlns", "https://www.prepago.com.mx/webservice")


'        soapCall.setAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance")
'        soapBody.appendChild(soapCall)
'        ' finally add the argument(s)
'        Dim soapxmlVenta As IXMLDOMElement
'        soapxmlVenta = xmlSrcDoc.createElement("xmlVenta")
'        soapxmlVenta.text = strSoap
'        soapCall.appendChild(soapxmlVenta)

'        ' let it go!
'        myXML.send("<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " ?> " & xmlSrcDoc.xml)

'        Dim xmlDoc As MSXML2.DOMDocument30
'        xmlDoc = myXML.responseXML
'        Dim Codigo As String

'        '   MsgBox(xmlDoc.text)

'        Codigo = Mid(xmlDoc.text, 26, 2)


'        estatus = myXML.status
'        consultartrans = Codigo

'    End Function


'End Class
