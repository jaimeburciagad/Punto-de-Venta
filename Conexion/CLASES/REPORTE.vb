Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class REPORTE
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

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
    Friend WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(REPORTE))
        Me.CrystalReportViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CrystalReportViewer2
        '
        Me.CrystalReportViewer2.ActiveViewIndex = -1
        Me.CrystalReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer2.Name = "CrystalReportViewer2"
        Me.CrystalReportViewer2.ReportSource = Nothing
        Me.CrystalReportViewer2.Size = New System.Drawing.Size(744, 504)
        Me.CrystalReportViewer2.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(744, 502)
        Me.Controls.Add(Me.CrystalReportViewer2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public TITULO As String
    Public REPORTE As String
    Public SERVIDOR As String
    Public BASEDATOS As String
    Public USUARIO As String
    Public CLAVEACCESO As String
    Public SELECCIONAR As String
    Public BPARAMTIT As Boolean
    Public SCLAVE As String
    Public SDESCRIP As String
    Private ORPT As Object = Nothing

    Private WithEvents reportdoc As New ReportDocument

    Private Sub REPORTE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CONFIGURAREPORTE()
    End Sub
    Private Sub CONFIGURAREPORTE()
        Dim I As Integer
        Dim SPARAM As New ParameterDiscreteValue
        Dim SPARAM1 As New ParameterDiscreteValue
        Dim SPARAM2 As New ParameterDiscreteValue
        Me.Text = TITULO
        reportdoc.Load(REPORTE)
        For I = 0 To reportdoc.Database.Tables.Count - 1
            setlogoninfo(SERVIDOR, BASEDATOS, USUARIO, CLAVEACCESO, reportdoc.Database.Tables.Item(I).Name)

        Next
        reportdoc.RecordSelectionFormula = SELECCIONAR
        CrystalReportViewer2.DisplayGroupTree = False
        CrystalReportViewer2.ReportSource = reportdoc
        If BPARAMTIT Then
            SPARAM.Value = TITULO
            CrystalReportViewer2.ParameterFieldInfo.Item("Titulo").CurrentValues.Add(SPARAM)
            SPARAM1.Value = SCLAVE
            CrystalReportViewer2.ParameterFieldInfo.Item("Clave").CurrentValues.Add(SPARAM1)
            SPARAM2.Value = SDESCRIP
            CrystalReportViewer2.ParameterFieldInfo.Item("Descripcion").CurrentValues.Add(SPARAM2)
        End If

    End Sub
    Private Sub setlogoninfo(ByVal server As String, ByVal database As String, ByVal userid As String, ByVal password As String, ByVal table As String)
        Dim logoninfo As New TableLogOnInfo

        logoninfo.ConnectionInfo.ServerName = server
        logoninfo.ConnectionInfo.UserID = userid
        logoninfo.ConnectionInfo.DatabaseName = database
        logoninfo.ConnectionInfo.Password = password
        logoninfo.TableName = table

        reportdoc.Database.Tables(table).ApplyLogOnInfo(logoninfo)

    End Sub

    
End Class
