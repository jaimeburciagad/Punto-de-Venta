Imports FarPoint.Win.Spread
Imports FarPoint.Win.Spread.CellType

Public Class DiseñaSpread
    Public Property Name As String
    Public Property ColHeaderRows As Integer
    Public Property ColHeaderCols As Integer
    Public Property ColWidth As Integer
    Public Property RowIndex As Integer
    Public Property ColIndex As Integer
    Public Property ColAlign As CellHorizontalAlignment
    Public Property ColType As CellType.BaseCellType
    Public Property ColVisible As Boolean
    Public Property ColLocked As Boolean

    Public Sub New(ByVal Name As String,
                   ByVal ColHeaderRows As Integer,
                   ByVal ColHeaderCols As Integer,
                   ByVal ColWidth As Integer,
                   ByVal RowIndex As Integer,
                   ByVal ColIndex As Integer,
                   ByVal ColAlign As CellHorizontalAlignment,
                   ByVal ColType As CellType.BaseCellType,
                   ByVal ColVisible As Boolean,
                   ByVal ColLocked As Boolean)
        Me.Name = Name
        Me.ColHeaderRows = ColHeaderRows
        Me.ColHeaderCols = ColHeaderCols
        Me.ColWidth = ColWidth
        Me.RowIndex = RowIndex
        Me.ColIndex = ColIndex
        Me.ColAlign = ColAlign
        Me.ColType = ColType
        Me.ColVisible = ColVisible
        Me.ColLocked = ColLocked
    End Sub
    Public Shared ReadOnly Property NumeroCon4Decimal As BaseCellType
        Get
            Dim numCellType As New NumberCellType()
            numCellType.DecimalPlaces = 4
            numCellType.DecimalSeparator = "."
            numCellType.Separator = ","
            numCellType.ShowSeparator = True
            Return numCellType
        End Get
    End Property
    Public Shared ReadOnly Property NumeroConDecimal As BaseCellType
        Get
            Dim numCellType As New NumberCellType()
            numCellType.DecimalPlaces = 2
            numCellType.DecimalSeparator = "."
            numCellType.Separator = ","
            numCellType.ShowSeparator = True
            Return numCellType
        End Get
    End Property
    Public Shared ReadOnly Property NumeroSinDecimal As BaseCellType
        Get
            Dim numCellType As New NumberCellType()
            numCellType.DecimalPlaces = 0
            numCellType.ShowSeparator = False
            Return numCellType
        End Get
    End Property
    Public Shared ReadOnly Property Dinero As BaseCellType
        Get
            Dim currencyCellType As New CurrencyCellType()
            currencyCellType.DecimalPlaces = 2
            currencyCellType.CurrencySymbol = "$"
            currencyCellType.DecimalSeparator = "."
            currencyCellType.Separator = ","
            currencyCellType.ShowSeparator = True
            Return currencyCellType
        End Get
    End Property
    Public Shared ReadOnly Property Texto As BaseCellType
        Get
            Dim txtCellType As New TextCellType()
            Return txtCellType
        End Get
    End Property

    Public Shared ReadOnly Property FechaHora As BaseCellType
        Get
            Dim fechahoraCellType As New DateTimeCellType()
            fechahoraCellType.DateDefault = Now
            fechahoraCellType.DateTimeFormat = DateTimeFormat.ShortDateWithTime
            Return fechahoraCellType
        End Get
    End Property

    Public Shared ReadOnly Property Fecha As BaseCellType
        Get
            Dim fechahoraCellType As New DateTimeCellType()
            fechahoraCellType.DateDefault = Now
            fechahoraCellType.DateTimeFormat = DateTimeFormat.ShortDate
            Return fechahoraCellType
        End Get
    End Property

    Public Shared ReadOnly Property CheckBox As BaseCellType
        Get
            Dim chkboxCellType As New CheckBoxCellType()
            chkboxCellType.ThreeState = False
            Return chkboxCellType
        End Get
    End Property
    Public Shared ReadOnly Property NumericUpDown As BaseCellType
        Get
            Dim numUpDownCellType As New NumberCellType()
            numUpDownCellType.SpinButton = True
            numUpDownCellType.DecimalPlaces = 0
            numUpDownCellType.DecimalSeparator = "."
            numUpDownCellType.Separator = ","
            numUpDownCellType.ShowSeparator = True
            numUpDownCellType.SpinDecimalIncrement = 0
            numUpDownCellType.SpinIntegerIncrement = 1
            Return numUpDownCellType
        End Get
    End Property
    Public Shared ReadOnly Property PercentDecimal As BaseCellType
        Get
            Dim perdecCellType As New PercentCellType
            perdecCellType.DecimalPlaces = 1
            perdecCellType.DecimalSeparator = "."
            perdecCellType.Separator = ","
            perdecCellType.ShowSeparator = True
            perdecCellType.PercentSign = "%"
            Return perdecCellType
        End Get
    End Property
    Public Shared ReadOnly Property PercentSinDecimal As BaseCellType
        Get
            Dim perCellType As New PercentCellType
            perCellType.DecimalPlaces = 0
            perCellType.DecimalSeparator = "."
            perCellType.Separator = ","
            perCellType.ShowSeparator = True
            perCellType.PercentSign = "%"
            Return perCellType
        End Get
    End Property

    Public Shared ReadOnly Property Time As BaseCellType
        Get
            Dim timCellType As New DateTimeCellType
            timCellType.DateTimeFormat = DateTimeFormat.TimeOnly
            timCellType.DateDefault = Now
            Return timCellType
        End Get
    End Property

    Public Shared Sub DiseñaSpreadsGenérico(ByVal FpSpread As FpSpread, ColFormatting As List(Of DiseñaSpread), Optional ByVal ShCol As SheetViewCollection = Nothing, Optional Inicializando As Boolean = True)
        Dim MaxColRow As Integer = 0
        Dim MaxColIndex As Integer = 0

        FpSpread.SuspendLayout()
        FpSpread.ActiveSheet.RowHeader.Visible = False
        FpSpread.TabStripPolicy = TabStripPolicy.AsNeeded
        FpSpread.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded
        FpSpread.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded
        FpSpread.AllowDragDrop = False
        FpSpread.ClipboardPasteToFill = True
        FpSpread.EditModeReplace = True
        FpSpread.TabStripInsertTab = False

        Dim FpFont As Font = New System.Drawing.Font("Arial", 8.2, FontStyle.Regular)

        If ShCol Is Nothing Then ShCol = FpSpread.Sheets
        For Each Sh As SheetView In ShCol
            Sh.GrayAreaBackColor = Color.FromArgb(176, 196, 222)
            If ColFormatting.Count >= 1 Then


                For i As Integer = 0 To ColFormatting.Count - 1
                    MaxColRow = If(MaxColRow < ColFormatting.Item(i).ColHeaderRows, ColFormatting.Item(i).ColHeaderRows, MaxColRow)
                    MaxColIndex = If(MaxColIndex < ColFormatting.Item(i).ColIndex, ColFormatting.Item(i).ColIndex, MaxColIndex)
                Next
                Sh.ColumnCount = MaxColIndex + 1
                Sh.ColumnHeader.RowCount = MaxColRow

                Dim UltColMod As Integer = -1
                For Each i As DiseñaSpread In ColFormatting
                    If UltColMod <> i.ColIndex Then
                        UltColMod = i.ColIndex

                        Sh.SetColumnWidth(i.ColIndex, i.ColWidth)
                        Sh.Columns(i.ColIndex).Visible = i.ColVisible
                        Sh.Columns(i.ColIndex).HorizontalAlignment = i.ColAlign
                        Sh.Columns(i.ColIndex).CellType = i.ColType
                        Sh.Columns(i.ColIndex).Locked = i.ColLocked
                        Sh.Columns(i.ColIndex).VerticalAlignment = CellVerticalAlignment.Center
                    End If
                    For Each RO As FarPoint.Win.Spread.Row In FpSpread.ActiveSheet.ColumnHeader.Rows
                        If i.RowIndex = RO.Index Then
                            FpSpread.ActiveSheet.ColumnHeader.Cells(RO.Index, i.ColIndex).VerticalAlignment = CellVerticalAlignment.Center
                            FpSpread.ActiveSheet.ColumnHeader.Cells(RO.Index, i.ColIndex).Text = i.Name
                            FpSpread.ActiveSheet.ColumnHeader.Cells(RO.Index, i.ColIndex).RowSpan = i.ColHeaderRows
                            FpSpread.ActiveSheet.ColumnHeader.Cells(RO.Index, i.ColIndex).ColumnSpan = i.ColHeaderCols
                        End If
                        Dim cell As FarPoint.Win.Spread.Cell = FpSpread.ActiveSheet.ColumnHeader.Cells(RO.Index, i.ColIndex)
                        FpSpread.AsWorkbook().ActiveSheet.ColumnHeader.Cells(RO.Index, i.ColIndex).WrapText = True
                        cell.Locked = False
                        cell.Font = FpFont
                        cell.LockFont = FpFont
                    Next
                Next
            End If
            If Inicializando Then Sh.RowCount = 1
        Next
        FpSpread.ResumeLayout()
    End Sub
End Class
