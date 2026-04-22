Imports System.IO

Public Class Logger
    ' Ruta donde se guardarán los logs (Carpeta del ejecutable / Logs)
    Private Shared LogPath As String = Path.Combine(Application.StartupPath, "Logs")

    Public Shared Sub Escribir(ByVal Modulo As String, ByVal Mensaje As String)
        Try
            ' 1. Si no existe la carpeta Logs, la creamos
            If Not Directory.Exists(LogPath) Then
                Directory.CreateDirectory(LogPath)
            End If

            ' 2. Nombre del archivo: Uno por día (Log_2023-12-16.txt)
            ' Esto evita tener un archivo gigante de 1GB imposible de abrir.
            Dim Archivo As String = Path.Combine(LogPath, "Log_" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt")

            ' 3. Formato del mensaje: [HORA] [MODULO] Error
            Dim Linea As String = String.Format("[{0}] [{1}] : {2}",
                                                DateTime.Now.ToString("HH:mm:ss"),
                                                Modulo,
                                                Mensaje)

            ' 4. Escribir en el archivo (Append = True para agregar al final)
            Using sw As New StreamWriter(Archivo, True)
                sw.WriteLine(Linea)
            End Using

        Catch ex As Exception
            ' Si falla el log (ej. disco lleno), no hacemos nada. 
            ' El log nunca debe tumbar la aplicación.
        End Try
    End Sub
End Class