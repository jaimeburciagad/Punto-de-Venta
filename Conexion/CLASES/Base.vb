Imports System.Data.SqlClient
Imports FirebirdSql.Data.FirebirdClient

Public Class Base
    ' ---------------------------------------------------------
    ' DAQUERY (SELECT) - VERSIÓN MODERNA
    ' ---------------------------------------------------------
    ' Ventaja: Llena el DataSet y desconecta inmediatamente.
    Public Shared Sub daQuery(ByVal sSql As String, ByVal CadenaConexionEspecifica As String, ByRef oDsc As DataSet, ByVal sTabla As String)
        Using oCon As New SqlConnection(CadenaConexionEspecifica)
            Try
                oCon.Open()
                Dim oAdap As New SqlDataAdapter(sSql, oCon)
                oAdap.SelectCommand.CommandTimeout = 120
                oAdap.Fill(oDsc, sTabla)
            Catch ex As Exception
                Throw New Exception("Error SQL: " & ex.Message & vbCrLf & "SQL: " & sSql)
            End Try
        End Using
    End Sub

    Public Shared Sub daQueryOriginal(ByVal sSql As String, ByVal oCon As SqlConnection, ByRef oDsc As DataSet, ByVal sTabla As String)
        Dim oComando As New SqlCommand(sSql, oCon)
        Dim oAdap As New SqlDataAdapter(oComando)
        Try
            oComando.CommandTimeout = 0
            oAdap.Fill(oDsc, sTabla)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    ' ---------------------------------------------------------
    ' EJECUTA (INSERT, UPDATE, DELETE) - VERSIÓN MODERNA
    ' ---------------------------------------------------------
    ' Ventaja: Abre, ejecuta y cierra en milisegundos.
    Public Shared Sub Ejecuta(ByVal sSql As String, ByVal CadenaConexionEspecifica As String)
        Using oCon As New SqlConnection(CadenaConexionEspecifica)
            Try
                oCon.Open()
                Using oComando As New SqlCommand(sSql, oCon)
                    oComando.CommandTimeout = 120
                    oComando.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Throw New Exception("Error SQL: " & ex.Message & vbCrLf & "SQL: " & sSql)
            End Try
        End Using
    End Sub
    Public Shared Sub EjecutaOriginal(ByVal sSql As String, ByVal oCon As SqlConnection)
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


    Public Shared Sub daQueryMICROSIP(ByVal sSql As String, ByRef oDsc As DataSet, ByVal sTabla As String, ByVal basemicrosip As String, Optional ByVal parameters As List(Of FbParameter) = Nothing)

        Try
            Using ocon1 As New FbConnection(basemicrosip) ' Usar Using para asegurar Dispose
                If ocon1.State = ConnectionState.Closed Then
                    ocon1.Open()
                End If
                Using oComando As New FbCommand(sSql, ocon1) ' Usar Using
                    oComando.CommandTimeout = 0 ' Considera un valor > 0 para evitar bloqueos indefinidos

                    If parameters IsNot Nothing AndAlso parameters.Any() Then
                        oComando.Parameters.AddRange(parameters)
                    End If

                    Using oAdap As New FbDataAdapter(oComando) ' Usar Using
                        Try
                            oAdap.Fill(oDsc, sTabla)
                        Catch exAdapter As Exception
                            ' Es bueno ser más específico o loggear el SQL y parámetros aquí
                            Throw New Exception($"Error al llenar el DataSet para la tabla '{sTabla}'. SQL: {sSql}. Error: {exAdapter.Message}", exAdapter)
                        End Try
                    End Using ' oAdap se dispone aquí
                End Using ' oComando se dispone aquí
                ' ocon1.Close() ' No es necesario con Using, se cierra al salir del bloque Using ocon1
            End Using ' ocon1 se cierra y dispone aquí
        Catch exGeneral As Exception
            ' Considera loggear más detalles aquí también
            Throw New Exception($"Error general en daQueryMICROSIP: {exGeneral.Message}", exGeneral)
        End Try
    End Sub



    Public Shared Sub EjecutaMICROSIP(ByVal sSql As String, ByVal oCon As FbConnection, ByVal basemicrosip As String, Optional parameters As List(Of FbParameter) = Nothing)
        Using ocon1 As New FbConnection(basemicrosip)
            Try
                ocon1.Open()
                Using oComando As New FbCommand(sSql, ocon1)
                    oComando.CommandTimeout = 60 ' Establece un timeout razonable (ej. 60 segundos)

                    If parameters IsNot Nothing AndAlso parameters.Any() Then
                        For Each param As FbParameter In parameters
                            oComando.Parameters.Add(param)
                        Next
                    End If

                    oComando.ExecuteNonQuery()
                End Using ' oComando se dispone aquí
            Catch exFb As FbException ' Capturar excepciones específicas de Firebird primero
                ' Aquí puedes loggear más detalles específicos de FbException si es necesario
                Throw New Exception($"Error de Firebird al ejecutar: {sSql}{vbCrLf}Mensaje: {exFb.Message}", exFb)
            Catch ex As Exception
                Throw New Exception($"Error general en EjecutaMICROSIPNuevaConexion al ejecutar: {sSql}{vbCrLf}Mensaje: {ex.Message}", ex)
            End Try
            ' ocon1.Close() es llamado automáticamente por el bloque Using al salir, incluso si hay error.
        End Using ' ocon1 se cierra y se dispone aquí
    End Sub

End Class
