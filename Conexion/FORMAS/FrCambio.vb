Imports System.Data.SqlClient
Imports MSXML2
Imports System.Threading
Public Class FrCambio

    Inherits System.Windows.Forms.Form
    Dim fo As FrVenta
    Public FOLIOAUT As Integer
    Dim SEPROCESO As Boolean
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
    'No lo modifique con el editor de código.
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
        Dim valor As String
        Dim valor1 As String
        FOLIOAUT = 0
        SEPROCESO = False
        valor = fo.ntx_totalventa.Text
        Me.tx_totalventa.Text = "Total Venta: " & Format(Val(valor), "$###,###.00")
        valor1 = fo.ntx_totalpago.Text
        Me.tx_totalpago.Text = "Total Pago : " & Format(Val(valor1), "$###,###.00")
        Me.tx_cambio.Text = " Su Cambio : " & Format(Val(valor1) - Val(valor), "$###,###.00")
        Call empieza()

    End Sub

    Private Sub empieza()
        btn_continuar.Focus()
    End Sub

    Private Sub BorraTicketHandler(ByVal Mensaje As String, ByVal TmpAuxVta As Boolean, ByVal TmpAuxVta1 As Boolean, ByVal ECVenta As Boolean, ByVal LigasFolios As Boolean, ByVal ECVentaDete As Boolean, ByVal ECVentaDet As Boolean, ByVal ECDetVenta As Boolean)
        Dim BorraTmpAuxVta As Boolean = Nothing
        Dim BorraTmpAuxVta1 As Boolean = Nothing
        Dim BorraECVenta As Boolean = Nothing
        Dim BorraLigasFolios As Boolean = Nothing
        Dim BorraECVentaDete As Boolean = Nothing
        Dim BorraECDetVenta As Boolean = Nothing
        Dim BorraECVentaDet As Boolean = Nothing

        If TmpAuxVta Then
            Try
                Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", fo.xCon)
                BorraTmpAuxVta = True
            Catch ex As Exception
                BorraTmpAuxVta = False
            End Try
        End If
        If TmpAuxVta1 Then
            Try
                Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", fo.xCon)
                BorraTmpAuxVta1 = True
            Catch ex As Exception
                BorraTmpAuxVta1 = False
            End Try
        End If
        If ECVenta Then
            Try
                Base.Ejecuta("delete from ecventa where ven_id=" & fo.xven & " and ven_usuario='" & "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "'", fo.xCon)
                BorraECVenta = True
            Catch ex As Exception
                BorraECVenta = False
            End Try
        End If
        If LigasFolios Then
            Try
                Base.Ejecuta("delete from Ligasfolios where ven_id=" & fo.xven, fo.xCon)
                BorraLigasFolios = True
            Catch ex As Exception
                BorraLigasFolios = False
            End Try
        End If
        If ECVentaDete Then
            Try
                Base.Ejecuta("delete from ecventadete where dve_venta=" & fo.xven, fo.xCon)
                BorraECVentaDete = True
            Catch ex As Exception
                BorraECVentaDete = False
            End Try
        End If
        If ECVentaDet Then
            Try
                Base.Ejecuta("delete from ecdetventa where dve_venta=" & fo.xven, fo.xCon)
                BorraECDetVenta = True
            Catch ex As Exception
                BorraECDetVenta = False
            End Try
        End If
        If ECDetVenta Then
            Try
                Base.Ejecuta("delete from ecventadet where dve_venta=" & fo.xven, fo.xCon)
                BorraECVentaDet = True
            Catch ex As Exception
                BorraECVentaDet = False
            End Try
        End If

        Dim Mensaje2 As String = ""
        Dim Pendientes As String = ""
        Dim Borradas As String = ""

        If ((BorraTmpAuxVta Or BorraTmpAuxVta = Nothing) And (BorraTmpAuxVta1 Or BorraTmpAuxVta1 = Nothing) And (BorraECVenta Or BorraECVenta = Nothing) And (BorraECVentaDete Or BorraECVentaDete = Nothing) And (BorraECDetVenta And BorraECDetVenta = Nothing) And (BorraECVentaDet Or BorraECVentaDet = Nothing)) Then
            'If (BorraTmpAuxVta And BorraTmpAuxVta1 And BorraECVenta And BorraECVentaDete And BorraECDetVenta And BorraECVentaDet) Then
            Mensaje2 = "Progreso borrado correctamente."
        Else
            If TmpAuxVta Then
                If BorraTmpAuxVta Then
                    Borradas = IIf(Borradas = "", "TmpAuxVta", Borradas & ", TmpAuxVta")
                Else
                    Pendientes = IIf(Pendientes = "", "TmpAuxVta", Pendientes & ", TmpAuxVta")
                End If
            End If

            If TmpAuxVta1 Then
                If BorraTmpAuxVta1 Then
                    Borradas = IIf(Borradas = "", "TmpAuxVta1", Borradas & ", TmpAuxVta1")
                Else
                    Pendientes = IIf(Pendientes = "", "TmpAuxVta1", Pendientes & ", TmpAuxVta1")
                End If
            End If

            If ECVenta Then
                If BorraTmpAuxVta Then
                    Borradas = IIf(Borradas = "", "ECVenta", Borradas & ", ECVenta")
                Else
                    Pendientes = IIf(Pendientes = "", "ECVenta", Pendientes & ", ECVenta")
                End If
            End If

            If LigasFolios Then
                If BorraLigasFolios Then
                    Borradas = IIf(Borradas = "", "LigasFolios", Borradas & ", LigasFolios")
                Else
                    Pendientes = IIf(Pendientes = "", "LigasFolios", Pendientes & ", LigasFolios")
                End If
            End If

            If ECVentaDete Then
                If BorraTmpAuxVta Then
                    Borradas = IIf(Borradas = "", "ECVentaDete", Borradas & ", ECVentaDete")
                Else
                    Pendientes = IIf(Pendientes = "", "ECVentaDete", Pendientes & ", ECVentaDete")
                End If
            End If

            If ECDetVenta Then
                If BorraTmpAuxVta Then
                    Borradas = IIf(Borradas = "", "ECDetVenta", Borradas & ", ECDetVenta")
                Else
                    Pendientes = IIf(Pendientes = "", "ECDetVenta", Pendientes & ", ECDetVenta")
                End If
            End If

            If ECVentaDet Then
                If BorraTmpAuxVta Then
                    Borradas = IIf(Borradas = "", "ECVentaDet", Borradas & ", ECVentaDet")
                Else
                    Pendientes = IIf(Pendientes = "", "ECVentaDet", Pendientes & ", ECVentaDet")
                End If
            End If

            If Pendientes <> "" Then
                Mensaje2 = " No pudo borrarse la información de " & Pendientes & ", "
            End If
            If Borradas <> "" Then
                Mensaje2 = Mensaje2 & " sólo de " & Borradas & "."
            Else
                Mensaje2 = Strings.Left(Mensaje2, Len(Mensaje2) - 2) & "."
            End If
        End If
        MsgBox(Mensaje & " " & Mensaje2, MsgBoxStyle.Critical, "Punto de Venta")
    End Sub

    Private Sub BorraFormaPagoHandler(ByVal Ticket As Integer)
        Try
            Base.Ejecuta("delete from ECFormaPago where referencia=" & Ticket, fo.xCon)
            Try
                Base.Ejecuta("delete from ECTarjetas where Tar_VentaID=" & Ticket, fo.xCon)
                Try
                    Base.Ejecuta("delete from ECTransfer where Tra_VentaID=" & Ticket, fo.xCon)
                    Try
                        Base.Ejecuta("delete from ECcuentasXCob where CxC_Folio=" & Ticket, fo.xCon)
                        Try
                            Dim SQL As String
                            SQL = "update ecventa.dbo.ECDETCLIENTEEMP set DCLI_SALDO=Saldo from ecventa.dbo.eccuentasxcob e join (" &
                                    "Select e.DCLI_CLAVE,COALESCE(SUM(cxc_saldo) ,0) Saldo  from ecventa.dbo.ECDETCLIENTEEMP e join ecventa.dbo.eccuentasxcob x on DCLI_CLAVE=cxc_cliente " &
                                    "group by e.DCLI_CLAVE) a on a.DCLI_CLAVE=e.cxc_cliente where ecventa.dbo.ECDETCLIENTEEMP.DCLI_CLAVE=e.cxc_cliente"
                            Base.Ejecuta(SQL, fo.xCon)
                        Catch ex As Exception
                            MsgBox("Error Crítico - Notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "No pudo actualizarse saldos de cliente en ECDetClienteEmp; sólo se borró progreso de tablas ECFormaPago, ECTarjetas, ECTransfer y ECCuentasXCob.", MsgBoxStyle.Critical, "Punto de Venta")
                        End Try
                    Catch ex As Exception
                        MsgBox("Error Crítico - Notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "No pudo borrarse la información de la tabla ECCuentasXCob, ni actualizar saldos de cliente en ECDetClienteEmp; sólo de ECFormaPago, ECTarjetas y ECTransfer.", MsgBoxStyle.Critical, "Punto de Venta")
                    End Try
                Catch ex As Exception
                    MsgBox("Error Crítico - Notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "No pudo borrarse la información de las tablas ECTransfer, ECCuentasXCob, ni actualizar saldos de cliente en ECDetClienteEmp; sólo de ECFormaPago y ECTarjetas.", MsgBoxStyle.Critical, "Punto de Venta")
                End Try
            Catch ex As Exception
                MsgBox("Error Crítico - Notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "No pudo borrarse la información de las tablas ECTarjetas, ECTransfer, ECCuentasXCob, ni actualizar saldos de cliente en ECDetClienteEmp; sólo de ECFormaPago.", MsgBoxStyle.Critical, "Punto de Venta")
            End Try
        Catch ex As Exception
            MsgBox("Error Crítico - Notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "No pudo borrarse la información de las tablas ECFormaPago, ECTarjetas, ECTransfer, ECCuentasXCob, ni actualizar saldos de cliente en ECDetClienteEmp.", MsgBoxStyle.Critical, "Punto de Venta")
        End Try
    End Sub
    Private Sub btn_continuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_continuar.Click
        Dim sSql As String = ""
        Dim dsc As New DataSet
        Dim iID As Integer
        Dim l As Integer
        Dim valido As Integer
        Dim lcaja As String
        Dim Sw_Cancelar As Boolean
        Dim autor As Form
        Dim FolioCaja As String
        Dim FolioSerie As String
        Dim Counter As Integer

        btn_continuar.Enabled = False
        Sw_Cancelar = False
        lcaja = "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1)
        valido = 0
        Counter = 0
        fo.xven = 0
        FolioCaja = ""
        With fo.fp_articulos.ActiveSheet
            While valido = 0 And Counter < 3
                Base.daQuery("exec dasigfolio '" & lcaja & "'", fo.xCon, dsc, "Fo")
                If dsc.Tables("Fo").Rows(0)("FolioN") > 0 Then
                    fo.xven = CDbl(dsc.Tables("Fo").Rows(0)("FolioN"))
                    FolioCaja = dsc.Tables("Fo").Rows(0)("FolioCaja")
                End If
                dsc.Tables.Remove("Fo")

                'Base.Ejecuta("exec dasigfolio '" & lcaja & "'", fo.xCon)
                'sSql = "select foliovta from tmpconsecu where caja='" & lcaja & "'"
                'Base.daQuery(sSql, fo.xCon, dsc, "tablahel")
                'If dsc.Tables("tablahel").Rows.Count > 0 Then
                'fo.xven = CDbl(dsc.Tables("tablahel").Rows(0)("foliovta"))
                'End If

                If fo.xven = 0 Then
                    valido = 0
                    Counter += 1
                Else
                    valido = 1
                End If
                'Dim SQL As String
                'Sql = "select isnull(ConsecutivoCaja,0)+1 Folio, Serie from tmpconsecu where caja='" & lcaja & "'"
                'Base.daQuery(SQL, fo.xCon, dsc, "FolioSerie")
                'If dsc.Tables("FolioSerie").Rows.Count > 0 Then
                '    FolioSerie = dsc.Tables("FolioSerie").Rows(0)("Serie")
                '    FolioCaja = FolioSerie & Strings.Right("000000" & dsc.Tables("FolioSerie").Rows(0)("Folio"), 6)
                'End If
                'dsc.Tables.Remove("FolioSerie")
                'dsc.Tables.Remove("Tablahel")
            End While

            iID = fo.xven

        End With

        If iID = 0 Then
            MsgBox("No puede cerrarse la venta, notifique a Jaime Burciaga.", vbCritical, "Punto de Venta")
            Exit Sub
        End If

        'If fo.HayTarjeta Then
        '    fo.SacaProporcionP1P2(iID)
        'End If



        Dim Ticket = fo.GuardaTicketConHandler(FolioCaja)
        If Ticket.Mensaje = "OK" Then
            If Not fo.GuardaFormaDePagoConHandler() Then
                BorraFormaPagoHandler(iID)
                BorraTicketHandler(Ticket.Mensaje, Ticket.TmpAuxVta, Ticket.TmpAuxVta1, Ticket.ECVenta, Ticket.LigasFolios, Ticket.ECVentaDete, Ticket.ECVentaDet, Ticket.ECDetVenta)
                Exit Sub
            End If
        Else
            BorraTicketHandler(Ticket.Mensaje, Ticket.TmpAuxVta, Ticket.TmpAuxVta1, Ticket.ECVenta, Ticket.LigasFolios, Ticket.ECVentaDete, Ticket.ECVentaDet, Ticket.ECDetVenta)
            Exit Sub
        End If


        'If fo.TxtControl.Text.Trim <> "0" Then
        fo.GuardaTicketCliente(CDbl(fo.TxtControl.Text.Trim), fo.xven)
        'End If


        Dim oPreImpre As New preImpresion(Me.tx_cambio.Text, fo.fp_articulos, Globales.sDireccion, Globales.sNominaEmpleado, Globales.NombreEmpleado, fo.LbTotal.Text.Replace(",", ""), iID, fo.xCon)
        preImpresion = oPreImpre.COLECCION


        Dim imprimevirtual As New previrtual(fo.fp_articulos, iID, fo.xCon)
        fo.imprimeTicket(preImpresion)

        If fo.estiempoaire Then

            '   MsgBox("ESTOY EN TIEMPO AIRE", MsgBoxStyle.Exclamation)

            Dim password As String
            Dim puntoventa As String
            Dim producto As String
            Dim respuesta As String
            Dim txttelefono As String
            Dim xestatus As String
            '----------- PARA GENERAR TIEMPO AIRE
            xestatus = ""
            puntoventa = "SERVDUARSA"
            password = "Duarsa1.1"


            'puntoventa = "PRUEBA0000"
            'password = "432143"


            producto = fo.claveprod


            'MsgBox(producto, MsgBoxStyle.Exclamation)

            txttelefono = fo.txt_ctel1.Text & fo.txt_ctel2.Text & fo.txt_ctel3.Text & fo.txt_ctel4.Text


            'MsgBox(txttelefono, MsgBoxStyle.Exclamation)


            respuesta = EnviarTransaccion(puntoventa, password, producto, txttelefono, ("000000" & iID.ToString).Substring(Len("000000" & iID.ToString) - 6, 6), "", xestatus)


            MsgBox(DSCESTATUS(respuesta))


            Dim Sw_Cancelar_Venta As Boolean

            Sw_Cancelar_Venta = False

            '-- 1. Solicitar TAE
            '-- 2. Cerrar la transacción de Venta con estatus OPERADO
            '-- 3. Validar los estatus en un LOOP de 5 intentos cada 3 segundos
            '-- 4. Si al terminar el LOOP la respuesta NO es satifactoria CANCELAR venta y enviar por Switch Venta y Cancelación
            '-- 5. Si la venta es satisfactoria actualizar el # de autorización de la Venta y enviar por Switch

            '-- 2. Cerrar la transacción de Venta con estatus OPERADO
            Dim Estatus_TAE_CONF As String
            Dim estatus_tae As String = ""
            Dim Sw_Consultar As Boolean
            Dim Max_Consulta As Integer  '-- Indica el numero de veces que preguntara SI se aplico o NO
            Dim Num_Consulta As Integer  '-- Indica el numero de consulta actual
            Dim Segundos As Integer  '-- Indica los segundos que deben transcurrir entre cada consulta
            '    Dim Sw_Cancelar As Boolean

            Estatus_TAE_CONF = ""
            Sw_Consultar = True
            Max_Consulta = 3
            Num_Consulta = 1
            Segundos = 5

            '-- 3. Validar los estatus en un LOOP de 5 intentos cada 3 segundos
            Do While Sw_Consultar
                Thread.Sleep(Segundos * 50)
                Estatus_TAE_CONF = consultartrans(puntoventa, password, txttelefono, ("000000" & iID.ToString).Substring(Len("000000" & iID.ToString) - 6, 6), estatus_tae)

                Select Case Estatus_TAE_CONF
                    Case "22"   '-- ReIntentar hasta Max_Consulta
                        If Num_Consulta + 1 > Max_Consulta Then
                            Sw_Consultar = False
                        End If
                    Case "30"   '-- No se pudo conectar al HOST
                        Sw_Consultar = True '-- Intentarlo las 5 veces
                    Case "17"   '-- Transacción NO encontrada
                        Sw_Consultar = False
                    Case "00"   '-- El TAE se aplico correctamente
                        Sw_Consultar = False
                End Select
                Num_Consulta = Num_Consulta + 1
                If Num_Consulta > Max_Consulta Then
                    Sw_Consultar = False
                End If
            Loop

            If Estatus_TAE_CONF = "00" Then
                Base.Ejecuta("UPDATE ecdetventatel  Set dve_folio=" & FOLIOAUT.ToString & " WHERE dve_venta=" & iID.ToString & "", fo.xCon)
                Dim opretiempo As New pretiempoaire(iID, fo.xCon)
                fo.imprimetaire(opretiempo.COLECCION)

            Else
                Sw_Cancelar = True
            End If
        End If

        fo.segundoticket = False
        For l = 0 To fo.fp_articulos.ActiveSheet.RowCount - 1
            If fo.fp_articulos.ActiveSheet.Cells(l, 5).Text = "*" Then
                fo.segundoticket = True
            End If
        Next
        If fo.segundoticket = True Then
            'MsgBox("Arracar Ticket")
            Dim vImpresion As Impresion
            vImpresion = New Impresion(imprimevirtual.COLECCION)
            vImpresion.imprime(True)
            ''fo.imprimevirtual(imprimevirtual.COLECCION)
        End If


        If fo.pagare = True Then
            Dim deudor As String
            Dim direccion As String
            Dim telefono As String
            Dim saldo As String
            Dim credito As String
            Dim comando As New SqlCommand
            Dim rdr As SqlDataReader
            deudor = ""
            direccion = ""
            telefono = ""
            comando.CommandText = "Select cli_nombre,cli_direccion,'' cli_telefono,dcli_saldo cli_saldo ,cli_clave id_credito from ecclientes inner join ecdetclienteemp on dcli_clave=cli_clave where dcli_empresa=1 and cli_clave=" & fo.clientex & ""
            comando.Connection = fo.xCon
            fo.xCon.Open()
            Try
                rdr = comando.ExecuteReader
                rdr.Read()
                deudor = rdr.GetValue(0)
                direccion = rdr.GetValue(1)
                telefono = rdr.GetValue(2)
                saldo = rdr.GetValue(3)
                credito = rdr.GetValue(4)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            fo.xCon.Close()
            Dim totaluco As Double
            Dim i As Integer
            totaluco = 0
            With fo.FP_FORMASPAGO.ActiveSheet
                For i = 0 To .RowCount - 1
                    If .Cells(i, 0).Value = "Credito" Then
                        totaluco += .Cells(i, 1).Value
                    End If
                Next
            End With
            fo.tb_total.Text.Replace(",", "")
            Dim prime As New prevales(totaluco.ToString, deudor, direccion, telefono, iID)
            fo.imprimevirtual(prime.COLECCION)

        End If

        ' para aplicar el inventario

        If Not fo.estiempoaire Then
            If fo.sipuntos Then
                Dim impuntos As New prepuntos(iID, fo.xCon)
                fo.imprimevirtual(impuntos.COLECCION)
            End If
            fo.aplicainv()
        Else
            If Sw_Cancelar = True Then
                Base.Ejecuta("UPDATE ECVENTA SET VEN_STATUS=2,VEN_DSCUSUARIO='" & Globales.nombreusuario & "',VEN_FECHACANC=GETDATE() , VEN_MOTIVO='" & " TIEMPO AIRE QUE NO SE ACREDITO " & "' WHERE VEN_ID=" & iID, fo.xCon)
                '                Base.Ejecuta("EXEC APLICAVENTAINVENTARIO " & TICKET & ",4", xcon)DIF
                '                    Base.Ejecuta("EXEC APLICAVENTAINVENTARIO " & TICKET & ",4", xcon)
                MsgBox("No se aplicó el TIEMPO AIRE AL CLIENTE, DEVUELVA EL DINERO  , LA OPERACION SE HA CANCELADO ", MsgBoxStyle.Information)
            Else
                '----------------------------HAY QUE IMPRIMIR TICKET DEL TIEMPO AIRE
            End If
        End If

        fo.sipuntos = False
        fo.limpiaSpread(True)
        fo.PERMISOVENDER = False
        MsgBox("Teclee Enter para continuar", MsgBoxStyle.Exclamation)
        Me.Dispose(True)
        Me.Hide()
        fo.pagare = False
        fo.segundoticket = False
        fo.txt_tipoventa.Text = "1"
        fo.txt_tipoventa.Enabled = True
        fo.txt_tipoventa.Focus()
        fo.Label11.Text = "Fecha: " & Today.Day & " de " & MonthName(Today.Month) & " del " & Today.Year & " | Hora: " & Now.ToShortTimeString & " |"
    End Sub


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


End Class
