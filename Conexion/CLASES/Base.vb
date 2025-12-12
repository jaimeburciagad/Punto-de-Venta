Imports System.Data.SqlClient
Imports FirebirdSql.Data.FirebirdClient

Public Class Base
    Public Shared Sub daQuery(ByVal sSql As String, ByVal oCon As SqlConnection, ByRef oDsc As DataSet, ByVal sTabla As String)
        Dim oComando As New SqlCommand(sSql, oCon)
        Dim oAdap As New SqlDataAdapter(oComando)
        Try
            oComando.CommandTimeout = 0
            oAdap.Fill(oDsc, sTabla)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
    Public Shared Sub Ejecuta(ByVal sSql As String, ByVal oCon As SqlConnection)
        Dim oComando As New SqlCommand(sSql, oCon)
        If oCon.State = ConnectionState.Closed Then
            oCon.Open()
        End If
        Try
            oComando.ExecuteNonQuery()
        Catch ex As Exception

            Throw New Exception(ex.Message)
        End Try
        oCon.Close()
    End Sub

    Public Shared Sub daQueryMICROSIP(ByVal sSql As String, ByVal oCon As FbConnection, ByRef oDsc As DataSet, ByVal sTabla As String, ByVal basemicrosip As String)


        'basemicrosip = "User=SYSDBA;" &
        '"Password=masterkey;" &
        '"Database=C:\Program Files\Microsip Datos\JAIME BURCIAGA DUARTE 2019.fdb;" &
        '"DataSource=localhost;" &
        '"Port=3050;" &
        '"Dialect=3;" &
        '"Charset=NONE;" &
        '"Role=;" &
        '"Connection lifetime=15;" &
        '"Pooling=true;" &
        '"MinPoolSize=0;" &
        '"MaxPoolSize=50;" &
        '"Packet Size=8192;" &
        '"ServerType=0;"



        '"USER=SYSDBA;Password=masterkey;Database=C:\MICROSIP DATOS\MA LUISA DUARTE SALAZAR (2021).FDB;DataSource=SERVER;Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"

        Dim ocon1 As New FbConnection(basemicrosip)
        ' Dim ocon1 As New FbConnection("User=SYSDBA;Password=masterkey;Database=" & basemicrosip)
        'Dim ocon1 As New FbConnection("User=SYSDBA;Password=masterkey;Database=" & basemicrosip)

        'conmicrosip = New FirebirdSql.Data.FirebirdClient.FbConnection(strConn)

        ocon1.Open()


        Dim oComando As New FbCommand(sSql, ocon1)
        Dim oAdap As New FbDataAdapter(oComando)
        Try
            oComando.CommandTimeout = 0
            oAdap.Fill(oDsc, sTabla)
        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
        ocon1.Close()
        ';datasource=192.168.1.102"
        'Datasource=localhost"
    End Sub



    Public Shared Sub EjecutaMICROSIP(ByVal sSql As String, ByVal oCon As FbConnection, ByVal basemicrosip As String)
        'Dim ocon1 As New FbConnection("User=SYSDBA;Password=masterkey;Database=" & basemicrosip)
        '        basemicrosip = "User=SYSDBA;" &
        '"Password=masterkey;" &
        '"Database=C:\Program Files\Microsip Datos\JAIME BURCIAGA DUARTE 2019.fdb;" &
        '"DataSource=localhost;" &
        '"Port=3050;" &
        '"Dialect=3;" &
        '"Charset=NONE;" &
        '"Role=;" &
        '"Connection lifetime=15;" &
        '"Pooling=true;" &
        '"MinPoolSize=0;" &
        '"MaxPoolSize=50;" &
        '"Packet Size=8192;" &
        '"ServerType=0;"


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
            Throw New Exception(ex.Message)

        End Try
        ocon1.Close()
    End Sub

End Class
