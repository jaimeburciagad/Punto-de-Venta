Public Module CajonPOS

    Private _monitor As CashDrawerMonitor

    Public ReadOnly Property Disponible As Boolean
        Get
            Return _monitor IsNot Nothing AndAlso _monitor.Inicializado
        End Get
    End Property

    Public Event EstadoActualizado(abierto As Boolean, segundosAbierto As Integer, origen As String)
    Public Event CajonAbierto(origen As String)
    Public Event CajonCerrado(segundosAbierto As Integer, origen As String)
    Public Event AlertaTiempoExcedido(segundosAbierto As Integer, origen As String)
    Public Event ErrorCajon(mensaje As String)

    Public Sub Inicializar(Optional segundosAlerta As Integer = 20)

        If _monitor IsNot Nothing AndAlso _monitor.Inicializado Then Exit Sub

        _monitor = New CashDrawerMonitor()
        _monitor.SegundosParaAlerta = segundosAlerta

        AddHandler _monitor.EstadoActualizado, AddressOf OnEstadoActualizado
        AddHandler _monitor.CajonAbierto, AddressOf OnCajonAbierto
        AddHandler _monitor.CajonCerrado, AddressOf OnCajonCerrado
        AddHandler _monitor.AlertaTiempoExcedido, AddressOf OnAlertaTiempoExcedido
        AddHandler _monitor.ErrorCajon, AddressOf OnErrorCajon

        _monitor.Inicializar()

    End Sub

    Public Sub Revisar()

        If _monitor Is Nothing OrElse Not _monitor.Inicializado Then Exit Sub

        _monitor.Revisar()

    End Sub

    Public Sub AbrirPorSistema()

        If _monitor Is Nothing OrElse Not _monitor.Inicializado Then
            Throw New Exception("El monitor de cajón no está inicializado.")
        End If

        _monitor.AbrirPorSistema()

    End Sub

    Public Sub Liberar()

        If _monitor IsNot Nothing Then
            _monitor.Dispose()
            _monitor = Nothing
        End If

    End Sub

    Private Sub OnEstadoActualizado(abierto As Boolean, segundosAbierto As Integer, origen As String)
        RaiseEvent EstadoActualizado(abierto, segundosAbierto, origen)
    End Sub

    Private Sub OnCajonAbierto(origen As String)
        RaiseEvent CajonAbierto(origen)
    End Sub

    Private Sub OnCajonCerrado(segundosAbierto As Integer, origen As String)
        RaiseEvent CajonCerrado(segundosAbierto, origen)
    End Sub

    Private Sub OnAlertaTiempoExcedido(segundosAbierto As Integer, origen As String)
        RaiseEvent AlertaTiempoExcedido(segundosAbierto, origen)
    End Sub

    Private Sub OnErrorCajon(mensaje As String)
        RaiseEvent ErrorCajon(mensaje)
    End Sub

End Module