Imports System.Runtime.InteropServices

Public Class RawPrinterHelper
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Public Structure DOCINFOA
        <MarshalAs(UnmanagedType.LPStr)>
        Public pDocName As String
        <MarshalAs(UnmanagedType.LPStr)>
        Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPStr)>
        Public pDataType As String
    End Structure

    <DllImport("winspool.Drv", SetLastError:=True, CharSet:=CharSet.Ansi)>
    Public Shared Function OpenPrinter(ByVal pPrinterName As String, ByRef phPrinter As IntPtr, ByVal pDefault As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", SetLastError:=True, CharSet:=CharSet.Ansi)>
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", SetLastError:=True, CharSet:=CharSet.Ansi)>
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Integer, ByRef di As DOCINFOA) As Boolean
    End Function

    <DllImport("winspool.Drv", SetLastError:=True, CharSet:=CharSet.Ansi)>
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", SetLastError:=True, CharSet:=CharSet.Ansi)>
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", SetLastError:=True, CharSet:=CharSet.Ansi)>
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", SetLastError:=True, CharSet:=CharSet.Ansi)>
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Integer, ByRef dwWritten As Integer) As Boolean
    End Function

    Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String) As Boolean
        Dim pBytes As IntPtr
        Dim dwCount As Integer = szString.Length
        Dim dwWritten As Integer = 0
        Dim hPrinter As IntPtr = IntPtr.Zero

        If Not OpenPrinter(szPrinterName, hPrinter, IntPtr.Zero) Then Return False
        Dim di As New DOCINFOA With {
            .pDocName = "RAW Document",
            .pDataType = "RAW"
        }
        If Not StartDocPrinter(hPrinter, 1, di) Then Return False
        If Not StartPagePrinter(hPrinter) Then Return False

        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
        Marshal.FreeCoTaskMem(pBytes)

        EndPagePrinter(hPrinter)
        EndDocPrinter(hPrinter)
        ClosePrinter(hPrinter)
        Return True
    End Function
End Class
