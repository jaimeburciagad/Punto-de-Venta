Imports Microsoft.PointOfService

Public Class CashDrawerMonitor
    Implements IDisposable

    Private _explorer As PosExplorer
    Private _drawer As CashDrawer

    Private _inicializado As Boolean = False
    Private _abiertoDesde As DateTime?
    Private _alertaEmitida As Boolean = False
    Private _origenApertura As String = ""

    Private _solicitudSistemaValidaHasta As DateTime?

    Public Property SegundosParaAlerta As Integer = 20

    Public ReadOnly Property Inicializado As Boolean
        Get
            Return _inicializado
        End Get
    End Property

    Public ReadOnly Property OrigenActual As String
        Get
            Return _origenApertura
        End Get
    End Property

    Public Event EstadoActualizado(abierto As Boolean, segundosAbierto As Integer, origen As String)
    Public Event CajonAbierto(origen As String)
    Public Event CajonCerrado(segundosAbierto As Integer, origen As String)
    Public Event AlertaTiempoExcedido(segundosAbierto As Integer, origen As String)
    Public Event ErrorCajon(mensaje As String)

    Public Sub Inicializar(Optional logicalName As String = Nothing)

        Liberar()

        Try
            _explorer = New PosExplorer()
            _explorer.Refresh()

            Dim device As DeviceInfo

            ' Recomendado: usar el CashDrawer default que configuraste con POSDM.
            If String.IsNullOrWhiteSpace(logicalName) Then
                device = _explorer.GetDevice(DeviceType.CashDrawer)
            Else
                device = _explorer.GetDevice(DeviceType.CashDrawer, logicalName)
            End If

            If device Is Nothing Then
                Throw New Exception("No se encontró CashDrawer configurado en POS for .NET.")
            End If

            _drawer = CType(_explorer.CreateInstance(device), CashDrawer)

            _drawer.Open()
            _drawer.Claim(3000)
            _drawer.DeviceEnabled = True

            If Not _drawer.CapStatus Then
                Throw New Exception("El cajón abre, pero no reporta estado abierto/cerrado. CapStatus=False.")
            End If

            _inicializado = True

        Catch ex As PosControlException
            _inicializado = False
            RaiseEvent ErrorCajon("Error POS al inicializar cajón: " &
                                  ex.Message &
                                  " | ErrorCode: " & ex.ErrorCode.ToString() &
                                  " | Extended: " & ex.ErrorCodeExtended.ToString())

        Catch ex As Exception
            _inicializado = False
            RaiseEvent ErrorCajon("Error al inicializar cajón: " & ex.Message)
        End Try

    End Sub

    Public Sub MarcarAperturaSolicitadaPorSistema(Optional segundosVentana As Integer = 5)
        _solicitudSistemaValidaHasta = DateTime.Now.AddSeconds(segundosVentana)
    End Sub

    Public Sub AbrirPorSistema()

        If Not _inicializado OrElse _drawer Is Nothing Then
            Throw New Exception("El cajón no está inicializado.")
        End If

        MarcarAperturaSolicitadaPorSistema()
        _drawer.OpenDrawer()

    End Sub

    Public Sub Revisar()

        If Not _inicializado OrElse _drawer Is Nothing Then Exit Sub

        Try
            Dim abierto As Boolean = _drawer.DrawerOpened

            If abierto Then

                If Not _abiertoDesde.HasValue Then

                    _abiertoDesde = DateTime.Now
                    _alertaEmitida = False

                    If _solicitudSistemaValidaHasta.HasValue AndAlso
                       DateTime.Now <= _solicitudSistemaValidaHasta.Value Then

                        _origenApertura = "Sistema"
                    Else
                        _origenApertura = "Manual/Llave"
                    End If

                    RaiseEvent CajonAbierto(_origenApertura)

                End If

                Dim segundos As Integer =
                    CInt((DateTime.Now - _abiertoDesde.Value).TotalSeconds)

                RaiseEvent EstadoActualizado(True, segundos, _origenApertura)

                If segundos >= SegundosParaAlerta AndAlso Not _alertaEmitida Then
                    _alertaEmitida = True
                    RaiseEvent AlertaTiempoExcedido(segundos, _origenApertura)
                End If

            Else

                If _abiertoDesde.HasValue Then

                    Dim segundos As Integer =
                        CInt((DateTime.Now - _abiertoDesde.Value).TotalSeconds)

                    Dim origenCierre As String = _origenApertura

                    _abiertoDesde = Nothing
                    _alertaEmitida = False
                    _origenApertura = ""
                    _solicitudSistemaValidaHasta = Nothing

                    RaiseEvent CajonCerrado(segundos, origenCierre)

                End If

                RaiseEvent EstadoActualizado(False, 0, "")

            End If

        Catch ex As PosControlException
            RaiseEvent ErrorCajon("Error POS leyendo cajón: " &
                                  ex.Message &
                                  " | ErrorCode: " & ex.ErrorCode.ToString() &
                                  " | Extended: " & ex.ErrorCodeExtended.ToString())

        Catch ex As Exception
            RaiseEvent ErrorCajon("Error leyendo cajón: " & ex.Message)
        End Try

    End Sub

    Public Sub Liberar()

        Try
            If _drawer IsNot Nothing Then
                Try
                    If _drawer.DeviceEnabled Then _drawer.DeviceEnabled = False
                Catch
                End Try

                Try
                    _drawer.Release()
                Catch
                End Try

                Try
                    _drawer.Close()
                Catch
                End Try
            End If

        Finally
            _drawer = Nothing
            _explorer = Nothing
            _inicializado = False
            _abiertoDesde = Nothing
            _alertaEmitida = False
            _origenApertura = ""
            _solicitudSistemaValidaHasta = Nothing
        End Try

    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Liberar()
    End Sub

End Class