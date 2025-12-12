Imports System.Data.SqlClient
Public Class RegistroHistorial

    Public Shared Sub HistorialAutorizaciones(ByVal Xcon As SqlConnection, ByVal CompuNombre As String, ByVal Usuario As String, Folio As Integer, ByVal Tipo As String, ByVal Modulo As String)
        Dim SQL As String
        Try
            SQL = "insert into HistorialAutorizaciones (NombreComputadora,Fecha,Usuario,Folio,Tipo,Modulo) values ('" & CompuNombre & "',getdate(),'" & Usuario & "'," & Folio & ",'" & Tipo & "','" & Modulo & "')"
            Base.Ejecuta(SQL, Xcon)
        Catch ex As Exception
            MsgBox("Error al insertar Historial." & Chr(13) & Chr(13) & ex.Message, vbExclamation, Modulo)
        End Try
    End Sub


End Class
