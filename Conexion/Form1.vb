Imports System.Data.SqlClient
Imports FirebirdSql.Data.FirebirdClient

Public Class Form1
    Dim basemicrosip As String
    Dim conmicrosip As FbConnection


    Public Shared Sub daQueryMICROSIP(ByVal sSql As String, ByVal oCon As FbConnection, ByRef oDsc As DataSet, ByVal sTabla As String, ByVal basemicrosip As String)

        basemicrosip = "User=SYSDBA;" &
"Password=masterkey;" &
"Database=C:\Program Files\Microsip Datos\JAIME BURCIAGA DUARTE 2019.fdb;" &
"DataSource=localhost;" &
"Port=3050;" &
"Dialect=3;" &
"Charset=NONE;" &
"Role=;" &
"Connection lifetime=15;" &
"Pooling=true;" &
"MinPoolSize=0;" &
"MaxPoolSize=50;" &
"Packet Size=8192;" &
"ServerType=0;"



        Dim ocon1 As New FbConnection(basemicrosip)
        ' Dim ocon1 As New FbConnection("User=SYSDBA;Password=masterkey;Database=" & basemicrosip)
        'Dim ocon1 As New FbConnection("User=SYSDBA;Password=masterkey;Database=" & basemicrosip)

        'conmicrosip = New FirebirdSql.Data.FirebirdClient.FbConnection(strConn)
        MsgBox("me voy a conectara")

        ocon1.Open()

        MsgBox("me conecté")

        Dim oComando As New FbCommand(sSql, ocon1)
        Dim oAdap As New FbDataAdapter(oComando)
        Try
            oComando.CommandTimeout = 0
            oAdap.Fill(oDsc, sTabla)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ocon1.Close()
        ';datasource=192.168.1.102"
        'Datasource=localhost"
    End Sub



    Public Shared Sub EjecutaMICROSIP(ByVal sSql As String, ByVal oCon As FbConnection, ByVal basemicrosip As String)
        'Dim ocon1 As New FbConnection("User=SYSDBA;Password=masterkey;Database=" & basemicrosip)
        Dim ocon1 As New FbConnection(basemicrosip)
        'conmicrosip = New FirebirdSql.Data.FirebirdClient.FbConnection(strConn)
        ocon1.Open()

        Dim oComando As New FbCommand(sSql, ocon1)
        If ocon1.State = ConnectionState.Closed Then
            ocon1.Open()
        End If
        Try
            oComando.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        ocon1.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call prueba()
    End Sub


    Sub prueba()
        Dim sql As String
        Dim dsc As New DataSet

        sql = "select * from articulos"
        daQueryMICROSIP(sql, conmicrosip, dsc, "Tabla", basemicrosip)



        If dsc.Tables("Tabla").Rows.Count > 0 Then
            MsgBox(dsc.Tables("Tabla").Rows("nombre")(0))
        End If

        MsgBox("termine")

    End Sub


End Class
