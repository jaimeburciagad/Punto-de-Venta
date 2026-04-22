'Contiene todas las variables globales
'Hay ke tener cuidado con su manejo ya que se definieron
'como públicas y no c hace validación alguna.
Module Globales
    'Estas son obligatorias y deben venir en el XML

    Public sCadenaConexionSQL As String
    Public sCadenaConexionRemota As String


    Public sUsuarioBase As String
    Public sClaveUsuario As String
    Public usmicro As String
    Public sBaseDatos, rBaseDatos As String
    Public sServidor As String
    Public sRemoto As String
    Public sEmpresa As String
    Public sPtoClave As String
    Public sPtoNombre As String
    Public sPlazaClave As String
    Public sPlazaNombre As String
    Public sDireccion As String()
    Public SUCMICRO As Integer
    Public condpago As Integer
    Public caja As String
    Public CAJARET As String
    Public grupo As String
    Public empresa As String
    Public dir1 As String
    Public dir2 As String
    Public DIR3 As String
    Public rfc As String
    Public CIUDAD As String
    Public datos4 As String
    Public numletras As Integer
    Public cvesucursal As Integer
    Public limiteCORTES As Double
    Public nomempresa As String
    Public rNomEmpresa As String
    Public DirReportes As String
    Public DirCargaXMLs As String
    Public rDirReportes As String
    Public rDirCargaXMLs As String
    Public VendedorID, rVendedorID As Integer
    'Estas van variando conforme se mueve de un lado del programa a otro
    Public sNominaEmpleado As String
    Public sNombreEmpleado As String
    Public TipoUsuario As String
    Public iTurnoActivo As Integer
    Public oFechaTurno As Date
    Public nombreusuario As String
    Public CAJERANOMBRE As String
    Public Remoto As Boolean
    Public movimiento As Integer
    Public CVEIMPUESTO As Integer
    Public CVEIMPUESTOIEPS As Integer
    Public CVEEXCENTO As Integer

    Public basemicrosip, BaseNominaMicrosip As String
    Public rBaseMicrosip, rBaseNominaMicrosip As String

    Public FACTORIVA As Integer

    Public rgrupo As String
    Public rempresa As String
    Public rdir1 As String
    Public rdir2 As String
    Public rDIR3 As String
    Public rrfc As String
    Public rCIUDAD As String

    Public rusmicro As String
    Public rsucmicro As Integer
    Public rcondpago As Integer
    Public rCVEEXCENTO As Integer
    Public rCVEIMPUESTO As Integer
    Public rCVEImpuestoIEPS As Integer
    Public rmovimiento As Integer


    Public BaseMicrosipCrisp As String
    Public SucMicrosipCrisp As Integer
    Public CondPagoCrisp As Integer
    Public CVEIMPUESTOCrisp As Integer
    Public CVEEXCENTOCrisp As Integer
    Public CVEIEPSCrisp As Integer
    Public VendedorIdCrisp, rVendedorIdCrisp As Integer

    Public rBaseMicrosipCrisp As String
    Public rSucMicrosipCrisp As Integer
    Public rCondPagoCrisp As Integer
    Public rCVEIMPUESTOCrisp As Integer
    Public rCVEEXCENTOCrisp As Integer
    Public rCVEIEPSCrisp As Integer

    Public VendedorIdLuisMario, rVendedorIdLuisMario As Integer
    Public BaseMicrosipLuisMario As String
    Public SucMicrosipLuisMario As Integer
    Public CondPagoLuisMario As Integer
    Public CVEIMPUESTOLuisMario As Integer
    Public CVEEXCENTOLuisMario As Integer
    Public CVEIEPSLuisMario As Integer

    Public rBaseMicrosipLuisMario As String
    Public rSucMicrosipLuisMario As Integer
    Public rCondPagoLuisMario As Integer
    Public rCVEIMPUESTOLuisMario As Integer
    Public rCVEEXCENTOLuisMario As Integer
    Public rCVEIEPSLuisMario As Integer

    Public Property NombreEmpleado() As String
        Get
            Return sNombreEmpleado
        End Get
        Set(ByVal Value As String)
            Dim sArr() As String = Split(Value, "/")
            sNombreEmpleado = sArr(0).Trim & " " & sArr(1).Trim
            sNombreEmpleado = sNombreEmpleado.Replace("#", "Ñ")
        End Set
    End Property

    Public Enum ColVenta
        ColCantidad = 0
        ColDescripcion = 1
        ColPrecio = 2
        ColTotal = 3
        ColUPCInv = 4
        ColVale = 5
        ColFIVA = 6
        ColF1 = 7
        ColF2 = 8
        ColF3 = 9
        ColFIEPS = 10
        ColArtClave = 11
        ColNomLargo = 12
        ColFamilia = 13
        ColCostoCap = 14
        ColTipoOferta = 15
        ColPrecio1 = 16
        ColComisionRen = 17
        ColFactor = 18
        ColF6 = 19
    End Enum
End Module
