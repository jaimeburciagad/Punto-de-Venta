Imports System.Globalization
Imports System.Linq
Imports System.Text
Imports ECVENTA4.crearcompras
Imports FarPoint.PDF
Imports FarPoint.Win
Imports FarPoint.Win.Spread
Imports FarPoint.Win.Spread.CellType
Imports FarPoint.Win.Spread.Model
Imports FarPoint.Win.Spread.Model.FormulaDependentInfos
Imports Org.BouncyCastle.Bcpg

Public Class ConfiguraSpread
    Public Shared Sub ConfiguraSpread(FpSpread As FpSpread, Optional FpFont As System.Drawing.Font = Nothing, Optional RowHeight As Decimal = 20, Optional HeaderBackColor As Color = Nothing, Optional HeaderBorderColor As Color = Nothing, Optional HeaderForeColor As Color = Nothing, Optional RowColumnBorderColor As Color = Nothing)
        If FpFont Is Nothing Then FpFont = New System.Drawing.Font("Arial", 8.2, FontStyle.Regular)
        If HeaderBackColor = Nothing Then HeaderBackColor = Color.FromArgb(230, 230, 230)
        If HeaderForeColor = Nothing Then HeaderForeColor = System.Drawing.SystemColors.Highlight
        If HeaderBorderColor = Nothing Then HeaderBorderColor = Color.LightGray
        If RowColumnBorderColor = Nothing Then RowColumnBorderColor = Color.LightGray
        If FpSpread.ActiveSheet.ColumnCount > 0 Then
            FpSpread.ActiveSheet.Columns(0, FpSpread.ActiveSheet.Columns.Count - 1).Font = FpFont
            FpSpread.ActiveSheet.Columns(0, FpSpread.ActiveSheet.Columns.Count - 1).BackColor = Color.White
            FpSpread.ActiveSheet.Columns(0, FpSpread.ActiveSheet.Columns.Count - 1).LockBackColor = Color.White
            FpSpread.ActiveSheet.Columns(0, FpSpread.ActiveSheet.Columns.Count - 1).ForeColor = Color.Black
            'FpSpread.ActiveSheet.Columns(0, FpSpread.ActiveSheet.Columns.Count - 1).LockForeColor = Color.Black

            For Each col As FarPoint.Win.Spread.Column In FpSpread.ActiveSheet.ColumnHeader.Columns
                For Each RO As FarPoint.Win.Spread.Row In FpSpread.ActiveSheet.ColumnHeader.Rows
                    Dim cell As FarPoint.Win.Spread.Cell = FpSpread.ActiveSheet.ColumnHeader.Cells(RO.Index, col.Index)
                    FpSpread.AsWorkbook().ActiveSheet.ColumnHeader.Cells(RO.Index, col.Index).WrapText = True
                    cell.Locked = False
                    'cell.Renderer = New GeneralCellType
                    cell.Font = FpFont
                    cell.LockFont = FpFont
                    cell.Border = New ComplexBorder(New ComplexBorderSide(ComplexBorderSideStyle.ThinLine, HeaderBorderColor))
                    cell.ForeColor = HeaderForeColor
                    cell.LockForeColor = HeaderForeColor
                    cell.LockBackColor = HeaderBackColor
                Next
            Next

            For Each col As FarPoint.Win.Spread.Column In FpSpread.ActiveSheet.Columns
                Dim cell As FarPoint.Win.Spread.Column = FpSpread.ActiveSheet.Columns(col.Index)
                cell.Border = New ComplexBorder(New ComplexBorderSide(ComplexBorderSideStyle.ThinLine, RowColumnBorderColor))
            Next
        End If

        If FpSpread.ActiveSheet.RowCount > 0 Then
            FpSpread.ActiveSheet.Rows(0, FpSpread.ActiveSheet.Rows.Count - 1).Height = RowHeight '20
        End If
        FpSpread.AllowUserFormulas = True

        FpSpread.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        FpSpread.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal
        FpSpread.ActiveSheet.SelectionUnit = SelectionUnit.Cell
        FpSpread.ActiveSheet.SelectionPolicy = SelectionPolicy.MultiRange
        FpSpread.TextTipDelay = 250
        FpSpread.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating

        FpSpread.ResizeZeroIndicator = FarPoint.Win.Spread.ResizeZeroIndicator.Default

        FpSpread.ActiveSheet.Protect = True
        FpSpread.AsWorkbook().ActiveSheet.Protect(GrapeCity.Spreadsheet.WorksheetLocks.Default And Not (GrapeCity.Spreadsheet.WorksheetLocks.FormatColumns Or GrapeCity.Spreadsheet.WorksheetLocks.FormatRows))
    End Sub
    Public Shared Sub ConfiguraRenglones(FpSpread As FpSpread, Renglon As Integer, Optional FpFont As System.Drawing.Font = Nothing, Optional FpColor As Color = Nothing, Optional RowHeight As Decimal = 20, Optional HorAlign As CellHorizontalAlignment = -1, Optional FpCellType As ICellType = Nothing)
        If FpFont Is Nothing Then FpFont = New System.Drawing.Font("Arial", 8.2, FontStyle.Regular)
        If FpColor = Nothing Then FpColor = Color.Black


        FpSpread.ActiveSheet.Rows(Renglon).Height = RowHeight
        FpSpread.ActiveSheet.Rows(Renglon).Font = FpFont
        FpSpread.ActiveSheet.Rows(Renglon).ForeColor = FpColor
        'FpSpread.ActiveSheet.Rows(Renglon).LockForeColor = FpColor
        If FpCellType IsNot Nothing Then
            FpSpread.ActiveSheet.Rows(Renglon).CellType = FpCellType
        End If
        If HorAlign >= 0 Then
            FpSpread.ActiveSheet.Rows(Renglon).HorizontalAlignment = HorAlign
        End If


    End Sub
    Public Shared Sub ConfiguraEnter(ByVal FpSpread As FpSpread, ByVal EnterAction As Object)
        Dim im As New FarPoint.Win.Spread.InputMap
        im = FpSpread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), EnterAction)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.StartEditingFormula)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None)

        im = FpSpread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), SpreadActions.StopEditing)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
    End Sub

    Public Shared Sub PintaClassOrig(FpSpread As FpSpread, ByVal FpRenglon As Integer, ByVal FpColor As Integer, Optional ByVal FpNewRenglon As Integer = -1, Optional ByVal FpColor2 As Integer = -1)
        If FpRenglon >= 0 Then
            Dim FilaAnt As FarPoint.Win.Spread.Cell
            Dim FilaAntDet, FilaAntDet1 As FarPoint.Win.Spread.Cell
            Dim FilaAntSaldo, FilaAntSaldo1 As FarPoint.Win.Spread.Cell
            Dim Pre1SugCol, RemCostoCol, DesCol As FarPoint.Win.Spread.Cell
            Dim FilaAntCant, FilaAntUPC, FilaAntDescUni2, FilaAntUnitSinImp, FIlaAntImpSinImpFactDesc, FilaAntMontoDescArtClave As FarPoint.Win.Spread.Cell
            Dim FilaAntSemanas, FilaAntCosto, FilaAntTotal, FilaAntCal, FilaAntCom, FilaAntUltInv As FarPoint.Win.Spread.Cell

            FilaAnt = FpSpread.ActiveSheet.Cells(FpRenglon, 0, FpRenglon, FpSpread.ActiveSheet.ColumnCount - 1)
            If FpSpread.ActiveSheet.Cells(FpRenglon, 0).Tag IsNot Nothing AndAlso FpSpread.ActiveSheet.Cells(FpRenglon, 0).Tag.ToString = "Saldo" Then
                FilaAntSaldo = FpSpread.ActiveSheet.Cells(FpRenglon, 0, FpRenglon, 30)
                FilaAntSaldo1 = FpSpread.ActiveSheet.Cells(FpRenglon, 33, FpRenglon, FpSpread.ActiveSheet.ColumnCount - 1)
            End If

            If FpSpread.Name = "FpSpreadDet" Then
                FilaAntDet = FpSpread.ActiveSheet.Cells(FpRenglon, 3, FpRenglon, 3)
                FilaAntDet1 = FpSpread.ActiveSheet.Cells(FpRenglon, 7, FpRenglon, FpSpread.ActiveSheet.ColumnCount - 1)
            ElseIf FpSpread.Name = "FpSpreadRevPrecios" Then
                Pre1SugCol = FpSpread.ActiveSheet.Cells(FpRenglon, 11)
                RemCostoCol = FpSpread.ActiveSheet.Cells(FpRenglon, 24)
                DesCol = FpSpread.ActiveSheet.Cells(FpRenglon, 5)
            ElseIf FpSpread.Name = "FpRegistroCompras" Then
                FilaAntCant = FpSpread.ActiveSheet.Cells(FpRenglon, 0)
                FilaAntUPC = FpSpread.ActiveSheet.Cells(FpRenglon, 1)
                FilaAntDescUni2 = FpSpread.ActiveSheet.Cells(FpRenglon, 2, FpRenglon, 6)
                FilaAntUnitSinImp = FpSpread.ActiveSheet.Cells(FpRenglon, 7)
                FIlaAntImpSinImpFactDesc = FpSpread.ActiveSheet.Cells(FpRenglon, 8, FpRenglon, 11)
                FilaAntMontoDescArtClave = FpSpread.ActiveSheet.Cells(FpRenglon, 12, FpRenglon, 19)
            ElseIf FpSpread.Name = "FpSpreadFaltantes" Then
                FilaAntSemanas = FpSpread.ActiveSheet.Cells(FpRenglon, 8, FpRenglon, 8)
                FilaAntCosto = FpSpread.ActiveSheet.Cells(FpRenglon, 17, FpRenglon, 18)
                FilaAntTotal = FpSpread.ActiveSheet.Cells(FpRenglon, 19, FpRenglon, 19)
                FilaAntCal = FpSpread.ActiveSheet.Cells(FpRenglon, 20, FpRenglon, 21)
                FilaAntCom = FpSpread.ActiveSheet.Cells(FpRenglon, 24, FpRenglon, 25)
                FilaAntUltInv = FpSpread.ActiveSheet.Cells(FpRenglon, 12, FpRenglon, 12)
            End If

            Select Case FpColor
                Case 1
                    If FpSpread.ActiveSheet.Cells(FpRenglon, 0).Tag IsNot Nothing AndAlso FpSpread.ActiveSheet.Cells(FpRenglon, 0).Tag.ToString = "Saldo" Then 'Modulo RevisaCompras
                        FilaAntSaldo.BackColor = System.Drawing.Color.LightBlue
                        FilaAntSaldo.LockBackColor = System.Drawing.Color.LightBlue
                        FilaAntSaldo1.BackColor = System.Drawing.Color.LightBlue
                        FilaAntSaldo1.LockBackColor = System.Drawing.Color.LightBlue
                    Else
                        FilaAnt.BackColor = System.Drawing.Color.LightBlue
                        FilaAnt.LockBackColor = System.Drawing.Color.LightBlue
                    End If
                Case 2
                    If FpSpread.ActiveSheet.Cells(FpRenglon, 0).Tag IsNot Nothing AndAlso FpSpread.ActiveSheet.Cells(FpRenglon, 0).Tag.ToString = "Vale" Then
                        FilaAnt.BackColor = System.Drawing.Color.LightGreen
                        FilaAnt.LockBackColor = System.Drawing.Color.LightGreen
                    ElseIf FpSpread.ActiveSheet.Cells(FpRenglon, 0).Tag IsNot Nothing AndAlso FpSpread.ActiveSheet.Cells(FpRenglon, 0).Tag.ToString = "Saldo" Then
                        FilaAntSaldo.BackColor = System.Drawing.Color.White
                        FilaAntSaldo.LockBackColor = System.Drawing.Color.White
                        FilaAntSaldo1.BackColor = System.Drawing.Color.White
                        FilaAntSaldo1.LockBackColor = System.Drawing.Color.White
                    Else
                        If FpSpread.Name = "FpSpreadDet" Then
                            FilaAnt.BackColor = System.Drawing.Color.White
                            FilaAnt.LockBackColor = System.Drawing.Color.White
                            FilaAntDet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
                            FilaAntDet1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
                            FilaAntDet.LockBackColor = System.Drawing.SystemColors.GradientInactiveCaption
                            FilaAntDet1.LockBackColor = System.Drawing.SystemColors.GradientInactiveCaption
                        ElseIf FpSpread.Name = "FpSpreadRevPrecios" Then
                            Select Case FpRenglon Mod 2
                                Case 0
                                    FilaAnt.LockBackColor = Color.FromArgb(220, 230, 241)
                                    FilaAnt.BackColor = Color.FromArgb(220, 230, 241)
                                Case Else
                                    FilaAnt.LockBackColor = Color.White
                                    FilaAnt.BackColor = Color.White
                            End Select
                            If FpSpread.ActiveSheet.Cells(FpRenglon, 33).Text = "*" Then
                                DesCol.LockBackColor = System.Drawing.Color.Lavender
                            End If
                            Pre1SugCol.LockBackColor = Color.FromArgb(252, 213, 180)
                            RemCostoCol.LockBackColor = System.Drawing.Color.LightGoldenrodYellow
                            Pre1SugCol.BackColor = Color.FromArgb(252, 213, 180)
                            RemCostoCol.BackColor = System.Drawing.Color.LightGoldenrodYellow
                        ElseIf FpSpread.Name = "FpRegistroCompras" Then
                            FilaAntCant.BackColor = Color.White
                            FilaAntUPC.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
                            FilaAntDescUni2.BackColor = Color.White
                            FilaAntUnitSinImp.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
                            FIlaAntImpSinImpFactDesc.BackColor = Color.White
                            FilaAntMontoDescArtClave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption

                            FilaAntCant.LockBackColor = Color.White
                            FilaAntUPC.LockBackColor = System.Drawing.SystemColors.GradientInactiveCaption
                            FilaAntDescUni2.LockBackColor = Color.White
                            FilaAntUnitSinImp.LockBackColor = System.Drawing.SystemColors.GradientInactiveCaption
                            FIlaAntImpSinImpFactDesc.LockBackColor = Color.White
                            FilaAntMontoDescArtClave.LockBackColor = System.Drawing.SystemColors.GradientInactiveCaption
                        ElseIf FpSpread.Name = "FpSpreadFaltantes" Then
                            FilaAnt.BackColor = System.Drawing.Color.White
                            FilaAntSemanas.BackColor = System.Drawing.Color.Lavender
                            FilaAntCosto.BackColor = System.Drawing.Color.LightGoldenrodYellow
                            FilaAntTotal.BackColor = System.Drawing.Color.Lavender
                            FilaAntCal.BackColor = System.Drawing.Color.LightGoldenrodYellow
                            FilaAntCom.BackColor = System.Drawing.Color.LightGoldenrodYellow
                            FilaAntUltInv.BackColor = System.Drawing.Color.Lavender

                            FilaAnt.LockBackColor = System.Drawing.Color.White
                            FilaAntSemanas.LockBackColor = System.Drawing.Color.Lavender
                            FilaAntCosto.LockBackColor = System.Drawing.Color.LightGoldenrodYellow
                            FilaAntTotal.LockBackColor = System.Drawing.Color.Lavender
                            FilaAntCal.LockBackColor = System.Drawing.Color.LightGoldenrodYellow
                            FilaAntCom.LockBackColor = System.Drawing.Color.LightGoldenrodYellow
                            FilaAntUltInv.LockBackColor = System.Drawing.Color.Lavender
                        ElseIf FpSpread.ActiveSheet.Cells(FpRenglon, 0).Tag IsNot Nothing AndAlso FpSpread.ActiveSheet.Cells(FpRenglon, 0).Tag.ToString = "RenGris" Then
                            FilaAnt.BackColor = System.Drawing.Color.LightGray
                            FilaAnt.LockBackColor = System.Drawing.Color.LightGray
                        Else
                            FilaAnt.BackColor = System.Drawing.Color.White
                            FilaAnt.LockBackColor = System.Drawing.Color.White
                        End If
                    End If
            End Select
        End If
        If FpNewRenglon >= 0 Then
            Dim FilaNew As FarPoint.Win.Spread.Cell
            FilaNew = FpSpread.ActiveSheet.Cells(FpNewRenglon, 0, FpNewRenglon, FpSpread.ActiveSheet.ColumnCount - 1)

            Dim FilaNewSaldo, FilaNewSaldo1 As FarPoint.Win.Spread.Cell
            If FpSpread.ActiveSheet.Cells(FpNewRenglon, 0).Tag IsNot Nothing AndAlso FpSpread.ActiveSheet.Cells(FpNewRenglon, 0).Tag.ToString = "Saldo" Then
                FilaNewSaldo = FpSpread.ActiveSheet.Cells(FpNewRenglon, 0, FpNewRenglon, 30)
                FilaNewSaldo1 = FpSpread.ActiveSheet.Cells(FpNewRenglon, 33, FpNewRenglon, FpSpread.ActiveSheet.ColumnCount - 1)
            End If

            Select Case FpColor2
                Case 1
                    If FpSpread.ActiveSheet.Cells(FpNewRenglon, 0).Tag IsNot Nothing AndAlso FpSpread.ActiveSheet.Cells(FpNewRenglon, 0).Tag.ToString = "Saldo" Then
                        FilaNewSaldo.BackColor = System.Drawing.Color.LightBlue
                        FilaNewSaldo.LockBackColor = System.Drawing.Color.LightBlue
                        FilaNewSaldo1.BackColor = System.Drawing.Color.LightBlue
                        FilaNewSaldo1.LockBackColor = System.Drawing.Color.LightBlue
                    Else
                        FilaNew.BackColor = System.Drawing.Color.LightBlue
                        FilaNew.LockBackColor = System.Drawing.Color.LightBlue
                    End If
                Case 2
                    If FpSpread.ActiveSheet.Cells(FpNewRenglon, 0).Tag IsNot Nothing AndAlso FpSpread.ActiveSheet.Cells(FpNewRenglon, 0).Tag.ToString = "Saldo" Then
                        FilaNewSaldo.BackColor = System.Drawing.Color.White
                        FilaNewSaldo.LockBackColor = System.Drawing.Color.White
                        FilaNewSaldo1.BackColor = System.Drawing.Color.White
                        FilaNewSaldo1.LockBackColor = System.Drawing.Color.White
                    Else
                        FilaNew.BackColor = System.Drawing.Color.White
                        FilaNew.LockBackColor = System.Drawing.Color.White
                    End If
            End Select
        End If
    End Sub
    Public Shared Function FpCellClick(e As CellClickEventArgs, FpSpread As FpSpread, FrmLabel As Label, isHeaderClicked As Boolean, Optional ColInd As Integer = -1) As Boolean
        If ColInd >= 0 Then
            FpSpread.ActiveSheet.ActiveColumnIndex = ColInd
        End If
        If e.Button = MouseButtons.Left Then
            PintaClass(FpSpread, FpSpread.ActiveSheet.ActiveRowIndex, 2, IIf(e.ColumnHeader, 0, e.Row), 1)
        ElseIf e.Button = MouseButtons.Right Then
            PintaClass(FpSpread, FpSpread.ActiveSheet.ActiveRowIndex, 2, IIf(e.ColumnHeader, 0, e.Row), 1)
            FpSpread.ActiveSheet.ActiveRowIndex = IIf(e.ColumnHeader, 0, e.Row)
            FpSpread.ActiveSheet.ActiveColumnIndex = e.Column
            FrmLabel.Text = Selecciona(FpSpread, isHeaderClicked, FrmLabel)
        End If
        Return e.ColumnHeader
    End Function

    Public Shared Sub FpLeaveCell(FpSpread As FpSpread, e As LeaveCellEventArgs, Optional ColInd As Integer = -1)
        If ColInd >= 0 Then
            FpSpread.ActiveSheet.ActiveColumnIndex = ColInd
        End If
        PintaClass(FpSpread, e.Row, 2, e.NewRow, 1)
    End Sub


    Public Shared Function Selecciona(FpSpread As FarPoint.Win.Spread.FpSpread, isHeaderClicked As Boolean, FrmLabel As Label, Optional ByVal TxtVentaSem As TextBox = Nothing, Optional ByVal TxtVentaSemRem As TextBox = Nothing) As String
        Selecciona = ""
        If FpSpread.ActiveSheet.RowCount <> 0 Then
            Dim range As CellRange
            Dim i As Integer
            Dim suma As Decimal = 0D
            Dim min As Decimal = Nothing
            Dim max As Decimal = Nothing
            Dim decValue As Decimal
            Dim simbolo As String = ""
            Dim cuenta As Integer = 0
            Dim RecuentoTotal As Integer = 0
            Dim texto As Boolean = False
            Dim nodinero As Boolean = False
            Dim inicia, colum As Integer
            Dim HayTexto, HayDinero As Boolean

            FrmLabel.Visible = False
            inicia = 0
            colum = 1

            HayDinero = True



            If isHeaderClicked Then
                Dim sheet As SheetView = FpSpread.ActiveSheet
                Dim ColumnasEnSeleccion As Integer = 1
                Dim StartingColumn As Integer

                ' Clear previous selections if you want to ensure only the clicked column is selected
                If FpSpread.ActiveSheet.SelectionCount = 0 Then
                    sheet.ClearSelection()
                    sheet.AddSelection(0, FpSpread.ActiveSheet.ActiveColumnIndex, 1, 1)
                ElseIf FpSpread.ActiveSheet.SelectionCount = 1 Then
                    ' Normaliza la selección para que funcione igual izq→der o der→izq
                    Dim sel = FpSpread.ActiveSheet.GetSelection(0)
                    Dim rawStart As Integer = sel.Column
                    Dim rawEnd As Integer = sel.Column + sel.ColumnCount - 1

                    ' left/right independientes de la dirección del arrastre
                    Dim leftCol As Integer = Math.Min(rawStart, rawEnd)
                    Dim rightCol As Integer = Math.Max(rawStart, rawEnd)

                    ' Clamps de seguridad
                    If leftCol < 0 Then leftCol = 0
                    If rightCol > sheet.ColumnCount - 1 Then rightCol = sheet.ColumnCount - 1

                    ' === EXPANDIR EL BORDE DERECHO si cae dentro de un merge horizontal ===
                    ' 1) Cuerpo
                    For r As Integer = 0 To sheet.RowCount - 1
                        Dim sp = sheet.GetSpanCell(r, rightCol)
                        If sp IsNot Nothing Then
                            Dim spRight As Integer = sp.Column + sp.ColumnCount - 1
                            If spRight > rightCol Then rightCol = Math.Min(spRight, sheet.ColumnCount - 1)
                        End If
                    Next

                    ' 2) Header
                    If sheet.ColumnHeader IsNot Nothing AndAlso sheet.ColumnHeader.RowCount > 0 Then
                        For hr As Integer = 0 To sheet.ColumnHeader.RowCount - 1
                            Dim spH = sheet.GetSpanCell(hr, rightCol)
                            If spH IsNot Nothing Then
                                Dim spHRight As Integer = spH.Column + spH.ColumnCount - 1
                                If spHRight > rightCol Then rightCol = Math.Min(spHRight, sheet.ColumnCount - 1)
                            End If
                        Next
                    End If

                    ' (Opcional) Si quieres simetría total estilo Excel, también expande el borde IZQUIERDO:
                    For r As Integer = 0 To sheet.RowCount - 1
                        Dim spL = sheet.GetSpanCell(r, leftCol)
                        If spL IsNot Nothing Then
                            Dim spLeft As Integer = spL.Column
                            If spLeft < leftCol Then leftCol = Math.Max(0, spLeft)
                        End If
                    Next
                    If sheet.ColumnHeader IsNot Nothing AndAlso sheet.ColumnHeader.RowCount > 0 Then
                        For hr As Integer = 0 To sheet.ColumnHeader.RowCount - 1
                            Dim spHL = sheet.GetSpanCell(hr, leftCol)
                            If spHL IsNot Nothing Then
                                Dim spLeft As Integer = spHL.Column
                                If spLeft < leftCol Then leftCol = Math.Max(0, spLeft)
                            End If
                        Next
                    End If

                    ' Recalcula ancho tras la (posible) expansión
                    StartingColumn = leftCol
                    ColumnasEnSeleccion = rightCol - leftCol + 1
                    If ColumnasEnSeleccion < 1 Then ColumnasEnSeleccion = 1

                    ' Selección a ALTURA COMPLETA, sin cortes por verticales
                    sheet.ClearSelection()
                    sheet.AddSelection(0, StartingColumn, sheet.RowCount, ColumnasEnSeleccion)
                    'ColumnasEnSeleccion = FpSpread.ActiveSheet.GetSelection(0).ColumnCount
                    'StartingColumn = FpSpread.ActiveSheet.GetSelection(0).Column
                    'sheet.ClearSelection()
                    'Dim FilaAg As Integer = 0
                    'Dim StartingR As Integer = 0
                    'For r As Integer = 0 To sheet.RowCount - 1
                    '    If sheet.GetSpanCell(r, ColumnasEnSeleccion) Is Nothing Then
                    '        FilaAg += 1
                    '    Else
                    '        sheet.AddSelection(StartingR, StartingColumn, FilaAg, ColumnasEnSeleccion)
                    '        FilaAg = 0
                    '        StartingR = r + 1
                    '    End If
                    'Next
                    'sheet.AddSelection(StartingR, StartingColumn, FilaAg, ColumnasEnSeleccion)
                    ''sheet.AddSelection(0, StartingColumn, sheet.RowCount, ColumnasEnSeleccion)
                Else
                    Dim StrColSel As String = ""
                    For s As Integer = 0 To FpSpread.ActiveSheet.SelectionCount - 1
                        StrColSel = IIf(StrColSel = "", FpSpread.ActiveSheet.GetSelection(s).Column & IIf(FpSpread.ActiveSheet.GetSelection(s).ColumnCount > 1, "-" & FpSpread.ActiveSheet.GetSelection(s).Column + FpSpread.ActiveSheet.GetSelection(s).ColumnCount - 1, ""), StrColSel & "," & FpSpread.ActiveSheet.GetSelection(s).Column & IIf(FpSpread.ActiveSheet.GetSelection(s).ColumnCount > 1, "-" & FpSpread.ActiveSheet.GetSelection(s).Column + FpSpread.ActiveSheet.GetSelection(s).ColumnCount - 1, ""))
                    Next

                    Dim ColArr() As String
                    ColArr = StrColSel.Split(",")
                    sheet.ClearSelection()
                    For FilArr As Integer = 0 To ColArr.Length - 1
                        If Not ColArr(FilArr).Contains("-") Then
                            sheet.AddSelection(0, ColArr(FilArr), sheet.RowCount, ColumnasEnSeleccion)
                        Else
                            Dim TableD As New DataTable()
                            TableD.Columns.Add("expression", GetType(Double), ColArr(FilArr))
                            Dim rowD As DataRow = TableD.NewRow
                            TableD.Rows.Add(rowD)
                            Dim Res As Double = Math.Abs(CDbl(rowD("expression")))

                            Dim StartColStr As String() = ColArr(FilArr).Split("-")

                            sheet.AddSelection(0, StartColStr(0), sheet.RowCount, Res + IIf(Res = 1, 1, 0))
                        End If
                    Next
                End If

                If FpSpread.ActiveSheet.SelectionCount >= 1 Then
                    ColumnasEnSeleccion = FpSpread.ActiveSheet.GetSelection(0).ColumnCount
                End If
            End If

            For i = 0 To FpSpread.ActiveSheet.SelectionCount - 1
                range = FpSpread.ActiveSheet.GetSelection(i)

                If range.RowCount = 1 And range.ColumnCount = 1 And FpSpread.ActiveSheet.SelectionCount <= 1 Then
                    Selecciona = ""
                    Return Selecciona
                End If


                Dim h, t As Integer
                h = FpSpread.ActiveSheet.ActiveColumnIndex

                Dim primerValorValido As Boolean = True ' Usamos esto para inicializar Min/Max

                For t = range.Row To range.Row + range.RowCount - 1
                    For h = range.Column To range.Column + range.ColumnCount - 1

                        Dim celda As FarPoint.Win.Spread.Cell = FpSpread.ActiveSheet.Cells(t, h)

                        ' --- 1. NORMALIZAR EL VALOR PARA LAS COMPROBACIONES ---

                        ' 1a. Obtener el valor de la celda.
                        Dim celdaValueOriginal As Object = celda.Value

                        ' 1b. Crear una variable temporal que trataremos como '0' si es nula/vacía/DBNull.
                        Dim valorNormalizado As Object = celdaValueOriginal

                        If celdaValueOriginal Is Nothing OrElse IsDBNull(celdaValueOriginal) OrElse celdaValueOriginal.ToString() = "" Then
                            ' Si es Nulo, DBNull o "", lo normalizamos a "0" para que IsNumeric sea True
                            valorNormalizado = "0"
                        End If

                        ' --- 2. VALIDACIÓN Y PROCESAMIENTO ---

                        Dim tieneContenido As Boolean = False

                        ' El RecuentoTotal se basa en el texto o en el valor original (no el "0" normalizado)
                        If celdaValueOriginal IsNot Nothing AndAlso IsDBNull(celdaValueOriginal) = False Then
                            tieneContenido = True
                        End If
                        If celda.Text <> "" Then
                            tieneContenido = True
                        End If

                        If tieneContenido Then

                            RecuentoTotal += 1

                            ' A partir de aquí, usamos valorNormalizado que es "0" para vacíos o el valor original.
                            If IsNumeric(valorNormalizado) Then

                                decValue = 0D

                                Try
                                    ' Usamos CDec sobre el valor NORMALIZADO (que ahora puede ser "0")
                                    decValue = CDec(valorNormalizado)

                                    ' Si el valor original era realmente vacío, decValue es 0D, y se suma 0.
                                    ' Si el valor original era un número grande, se convierte correctamente.

                                    suma += decValue
                                    cuenta += 1

                                    ' ... (Lógica de Min/Max, etc., se mantiene igual usando decValue) ...
                                    If primerValorValido Then
                                        min = decValue
                                        max = decValue
                                        primerValorValido = False
                                    End If

                                    If decValue > max Then max = decValue
                                    If decValue < min Then min = decValue

                                    If HayDinero Then
                                        If InStr(celda.Text, "$") > 0 Then
                                            HayDinero = True
                                        Else
                                            HayDinero = False
                                        End If
                                    End If

                                Catch ex As Exception
                                    ' Si falla CDec (ej. un formato numérico exótico), se marca como texto.
                                    HayTexto = True
                                End Try

                            Else
                                ' El valor original no era numérico (texto real)
                                HayTexto = True
                            End If
                        End If
                    Next
                Next

                'For t = range.Row To range.Row + range.RowCount - 1
                '    For h = range.Column To range.Column + range.ColumnCount - 1

                '        Dim celda As FarPoint.Win.Spread.Cell = FpSpread.ActiveSheet.Cells(t, h)
                '        Dim celdaValue As Object = celda.Value

                '        Dim tieneContenido As Boolean = False
                '        Dim valorDecimal As Decimal = 0D

                '        ' --- A) PRIMER FILTRO: ¿Tiene CONTENIDO? ---

                '        ' Opción 1: Validar si el .Value es usable (no nulo, no DBNull)
                '        If celdaValue IsNot Nothing AndAlso IsDBNull(celdaValue) = False Then
                '            tieneContenido = True
                '        End If

                '        ' Opción 2: Validar si el .Text contiene ALGO (maneja el caso de valor nulo con texto)
                '        ' Si el .Text tiene contenido, incluso si el .Value es Nothing/DBNull/0.0, lo procesamos.
                '        If celda.Text <> "" Then
                '            tieneContenido = True
                '        End If

                '        ' --- B) PROCESAMIENTO SOLO SI TIENE CONTENIDO ---

                '        If tieneContenido Then

                '            RecuentoTotal += 1 ' Contamos la celda como "llena"

                '            ' --- C) INTENTAR CONVERSIÓN SEGURA (Para Suma/Min/Max) ---

                '            If IsNumeric(celdaValue) Then
                '                ' Es numérico, intentamos convertir a Decimal con blindaje
                '                Try
                '                    ' Usamos CDec para forzar la conversión segura (maneja los > 10 millones)
                '                    valorDecimal = CDec(celdaValue)

                '                    ' Si la conversión es exitosa, se considera un valor sumable:
                '                    suma += valorDecimal
                '                    cuenta += 1

                '                    ' ... (Lógica de Min/Max usando valorDecimal) ...

                '                Catch ex As Exception
                '                    ' Si IsNumeric es True pero CDec falla (ej. Notación científica rara),
                '                    ' se ignora la suma y se marca como texto (HayTexto)
                '                    HayTexto = True
                '                End Try

                '            Else
                '                ' D) No es numérico (es texto real)
                '                HayTexto = True
                '            End If
                '        End If
                '    Next
                'Next

                If i = FpSpread.ActiveSheet.SelectionCount - 1 Then
                    FrmLabel.Visible = True
                    If RecuentoTotal > 0 Then
                        If Not HayTexto Then
                            If FpSpread.Name = "FpVentasSemLocal" Then
                                TxtVentaSem.Text = FormatNumber(suma / cuenta, 2)
                            ElseIf FpSpread.Name = "FpVentasSemRemoto" Then
                                TxtVentaSemRem.Text = FormatNumber(suma / cuenta, 2)
                            End If
                            If HayDinero Then
                                Selecciona = "Promedio: " & FormatCurrency(suma / cuenta, 2) & " | Recuento: " & FormatNumber(RecuentoTotal, 2) & " | Min: " & FormatCurrency(min, 2) & " | Max: " & FormatCurrency(max, 2) & " | Suma: " & FormatCurrency(suma, 2)
                            Else
                                Selecciona = "Promedio: " & FormatNumber(suma / cuenta, 2) & " | Recuento: " & FormatNumber(RecuentoTotal, 2) & " | Min: " & FormatNumber(min, 2) & " | Max: " & FormatNumber(max, 2) & " | Suma: " & FormatNumber(suma, 2)
                            End If
                        Else
                            Selecciona = "Recuento: " & FormatNumber(RecuentoTotal, 2)
                        End If

                    End If


                End If
            Next
        End If
        Return Selecciona
    End Function



    ' --- SIN FUNCIONES LOCALES DENTRO DEL SUB ---

    Public Shared Sub Buscar(FpSpread As FpSpread,
                         ColumnaBusq As Integer,
                         TxtBuscar As TextBox,
                         CmbColumnasBuscar As ComboBox,
                         ByRef Inicializando As Boolean,
                         ByRef FilaSig As Integer,
                         ByRef UltRowMatch As Integer,
                         ByRef UltStrBusc As String,
                         ByRef Looped As Boolean,
                         Optional ByRef TxtBusca As System.Windows.Forms.ToolStripTextBox = Nothing)

        Dim sh As SheetView = FpSpread.ActiveSheet
        If sh Is Nothing OrElse sh.RowCount = 0 Then
            MsgBox("No hay filas para buscar.", vbInformation, "Buscar")
            Exit Sub
        End If

        If TxtBusca IsNot Nothing Then
            TxtBuscar.Text = TxtBusca.Text
        End If

        If ColumnaBusq < 0 OrElse ColumnaBusq >= sh.ColumnCount Then
            MsgBox("Debe seleccionar del listado la columna a buscar.", vbExclamation, "Buscar Texto")
            CmbColumnasBuscar.Focus()
            Exit Sub
        End If

        Dim query As String = TxtBuscar.Text
        If String.IsNullOrWhiteSpace(query) Then
            MsgBox("Escriba un texto a buscar.", vbExclamation, "Buscar")
            If TxtBusca Is Nothing Then TxtBuscar.Focus() Else TxtBusca.Focus()
            Exit Sub
        End If

        ' Parámetros de búsqueda (ajústalos si quieres exacto/case/etc.)
        Dim exactMatch As Boolean = False       ' False = parcial ("Negra" encuentra "Bolsa Negra")
        Dim matchCase As Boolean = False        ' False = ignora mayúsculas
        Dim ignoreAccents As Boolean = True     ' True = "Á"=="A"
        Dim useFormattedText As Boolean = True  ' True = usa el texto visible en la celda

        ' ---------- INIT / RESET ----------
        If Inicializando Then
            UltRowMatch = -1
            UltStrBusc = query
            Looped = False
            FilaSig = 0
            Inicializando = False
        Else
            ' === CORRECCIÓN DEL BUG ===
            ' Si el texto es el mismo, pero el usuario se movió manualmente a otro lugar 
            ' (es decir, la celda activa ya no es la última que encontró el sistema),
            ' forzamos a buscar desde donde está el usuario ahora.
            If sh.ActiveRowIndex >= 0 AndAlso sh.ActiveRowIndex <> UltRowMatch Then
                FilaSig = sh.ActiveRowIndex
                ' Opcional: Resetear el loop flag si se movió manualmente
                Looped = False
                UltRowMatch = -1
            End If
        End If

        If UltStrBusc Is Nothing OrElse UltStrBusc <> query Then
            UltRowMatch = -1
            Looped = False
            FilaSig = If(sh.ActiveRowIndex >= 0, sh.ActiveRowIndex, 0)
            UltStrBusc = query
        End If
        If FilaSig < 0 OrElse FilaSig >= sh.RowCount Then FilaSig = 0

        ' ---------- CACHE COLUMNA (rápido) ----------
        Dim rowCount As Integer = sh.RowCount
        Dim disp(rowCount - 1) As String
        Dim norm(rowCount - 1) As String

        For r As Integer = 0 To rowCount - 1
            Dim t As String = GetShownText(sh, r, ColumnaBusq, useFormattedText)
            disp(r) = t
            norm(r) = NormalizeForSearch(t, matchCase, ignoreAccents)
        Next

        Dim qNorm As String = NormalizeForSearch(query, matchCase, ignoreAccents)

        ' ---------- BÚSQUEDA CON WRAP-AROUND ----------
        Dim foundRow As Integer = -1
        Dim start As Integer = FilaSig
        Dim wrapped As Boolean = False

        ' 1) De start al final
        For r As Integer = start To rowCount - 1
            If Not sh.Rows(r).Visible Then Continue For

            If r = UltRowMatch Then Continue For
            If exactMatch Then
                If String.Equals(norm(r), qNorm, StringComparison.Ordinal) Then
                    foundRow = r : Exit For
                End If
            Else
                If norm(r).IndexOf(qNorm, StringComparison.Ordinal) >= 0 Then
                    foundRow = r : Exit For
                End If
            End If
        Next

        ' 2) Wrap: 0 .. start-1
        If foundRow = -1 AndAlso rowCount > 1 AndAlso start > 0 Then
            For r As Integer = 0 To start - 1
                If r = UltRowMatch Then Continue For
                If exactMatch Then
                    If String.Equals(norm(r), qNorm, StringComparison.Ordinal) Then
                        foundRow = r : wrapped = True : Exit For
                    End If
                Else
                    If norm(r).IndexOf(qNorm, StringComparison.Ordinal) >= 0 Then
                        foundRow = r : wrapped = True : Exit For
                    End If
                End If
            Next
        End If

        If foundRow = -1 Then
            If UltRowMatch = -1 Then
                MsgBox("No se encontraron coincidencias.", vbInformation, "Buscar")
            Else
                MsgBox("No se encontraron coincidencias adicionales.", vbInformation, "Buscar")
            End If
            FilaSig = 0
            UltRowMatch = -1
            Looped = False
            Exit Sub
        End If

        ' ---------- Seleccionar / centrar ----------
        'Try
        '    ' Si quieres: PintaClass(FpSpread, sh.ActiveRowIndex, 2, foundRow, 1)
        '    sh.ActiveRowIndex = foundRow
        '    sh.SetActiveCell(foundRow, ColumnaBusq)
        '    sh.ClearSelection()
        '    sh.AddSelection(foundRow, ColumnaBusq, 1, 1)
        '    FpSpread.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center)
        'Catch
        'End Try
        Try
            Dim FilaVieja As Integer = sh.ActiveRowIndex

            ' 1. Movemos el foco lógico de FarPoint
            sh.ActiveRowIndex = foundRow
            sh.SetActiveCell(foundRow, ColumnaBusq)

            ' 2. Centramos la vista para que el usuario vea dónde cayó
            FpSpread.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center)

            ' 3. ¡MAGIA VISUAL! Llamamos a tu PintaClass Refactorizado
            ' Param 1: Grid
            ' Param 2: FilaVieja -> 2 (Restaurar color original)
            ' Param 3: FilaNueva (foundRow) -> 1 (Pintar Azul/Highlight)

            PintaClass(FpSpread, FilaVieja, 2, foundRow, 1)

            ' Opcional: Si quieres que también aparezca el recuadro de selección nativo
            sh.ClearSelection()
            sh.AddSelection(foundRow, ColumnaBusq, 1, 1)

        Catch ex As Exception
            Debug.WriteLine("Error visual al buscar: " & ex.Message)
        End Try
        ' ---------- Preparar siguiente ----------
        UltRowMatch = foundRow
        FilaSig = foundRow + 1
        If FilaSig >= rowCount Then FilaSig = 0
        Looped = wrapped

        If TxtBusca Is Nothing Then TxtBuscar.Focus() Else TxtBusca.Focus()
    End Sub

    ' ===================== HELPERS A NIVEL DE CLASE (no locales) =====================

    Private Shared Function GetShownText(sh As SheetView, r As Integer, c As Integer, useFormattedText As Boolean) As String
        If useFormattedText Then
            Try
                Dim t As String = sh.Cells(r, c).Text
                If Not String.IsNullOrEmpty(t) Then Return t
            Catch
            End Try
        End If
        Try
            Dim v As Object = sh.Cells(r, c).Value
            If v Is Nothing Then Return ""
            If TypeOf v Is Date Then Return DirectCast(v, Date).ToString(CultureInfo.CurrentCulture)
            Return v.ToString()
        Catch
            Return ""
        End Try
    End Function

    Private Shared Function NormalizeForSearch(s As String, matchCase As Boolean, ignoreAccents As Boolean) As String
        Dim t As String = If(s, "")
        If ignoreAccents Then t = RemoveDiacritics(t)
        If Not matchCase Then t = t.ToUpperInvariant()
        Return t
    End Function

    Private Shared Function RemoveDiacritics(s As String) As String
        If String.IsNullOrEmpty(s) Then Return ""
        Dim norm As String = s.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder(norm.Length)
        For Each ch As Char In norm
            If CharUnicodeInfo.GetUnicodeCategory(ch) <> UnicodeCategory.NonSpacingMark Then
                sb.Append(ch)
            End If
        Next
        Return sb.ToString().Normalize(NormalizationForm.FormC)
    End Function


    Public Shared Sub RellenaCmbBuscar(ByVal FpSpread As FpSpread, CmbColumnasBuscar As ComboBox, CmbBuscaIndex As ComboBox, Optional CheckedListBox1 As CheckedListBox = Nothing, Optional ColInd As Integer = 0, Optional ByVal InicializandoVista As Boolean = False)
        CmbColumnasBuscar.Items.Clear()
        CmbBuscaIndex.Items.Clear()

        Dim Titulo As String = ""
        Dim Subtitulo As String = ""
        Dim IndCol, SubIndCol As Integer
        Dim TitColSpan As Integer = 0
        Dim SubTitColSpan As Integer = 0
        For c As Integer = 0 To FpSpread.ActiveSheet.Columns.Count - 1
            If FpSpread.ActiveSheet.Columns(c).Visible Then
                If FpSpread.ActiveSheet.ColumnHeader.RowCount > 1 Then
                    If FpSpread.ActiveSheet.ColumnHeader.Cells(0, c).ColumnSpan > 1 Then
                        Titulo = FpSpread.ActiveSheet.ColumnHeader.Cells(0, c).Text
                        IndCol = c
                        TitColSpan = c + FpSpread.ActiveSheet.ColumnHeader.Cells(0, c).ColumnSpan - 1
                    Else
                        If c > TitColSpan Then
                            Titulo = ""
                        End If
                    End If

                    If FpSpread.ActiveSheet.ColumnHeader.RowCount = FpSpread.ActiveSheet.ColumnHeader.Cells(0, c).RowSpan Then
                        CmbColumnasBuscar.Items.Add(FpSpread.ActiveSheet.ColumnHeader.Cells(0, c).Text)
                        CmbBuscaIndex.Items.Add(c)
                    Else
                        Dim HeadCol As String = ""
                        For FC As Integer = 0 To FpSpread.ActiveSheet.ColumnHeader.RowCount - 1
                            If FC > 0 Then
                                If FpSpread.ActiveSheet.ColumnHeader.Cells(FC, c).ColumnSpan > 1 Then
                                    Subtitulo = FpSpread.ActiveSheet.ColumnHeader.Cells(FC, c).Text
                                    SubIndCol = c
                                    SubTitColSpan = c + FpSpread.ActiveSheet.ColumnHeader.Cells(FC, c).ColumnSpan - 1
                                End If
                            End If
                            HeadCol = (IIf(Titulo <> FpSpread.ActiveSheet.ColumnHeader.Cells(FC, c).Text And (c > IndCol And c <= TitColSpan) And HeadCol = "", Titulo & " - ", "") & IIf(Subtitulo <> FpSpread.ActiveSheet.ColumnHeader.Cells(FC, c).Text And (c > SubIndCol And c <= SubTitColSpan) And HeadCol = "", Subtitulo & " - ", "") & IIf(HeadCol = "", FpSpread.ActiveSheet.ColumnHeader.Cells(FC, c).Text, HeadCol & " - " & FpSpread.ActiveSheet.ColumnHeader.Cells(FC, c).Text)).ToString.Replace(" -  - ", " - ")

                            If FpSpread.ActiveSheet.ColumnHeader.Cells(FC, c).RowSpan > 1 Then
                                FC += FpSpread.ActiveSheet.ColumnHeader.Cells(FC, c).RowSpan - 1
                            End If
                        Next
                        If HeadCol.Replace(" - ", "").Trim = (Titulo & " - " & IIf(Subtitulo <> "", Subtitulo & " - ", "")).Replace(" - ", "").trim Then
                            HeadCol = ""
                        End If
                        CmbColumnasBuscar.Items.Add(HeadCol)
                        CmbBuscaIndex.Items.Add(c)
                    End If
                Else 'Headers es una sola fila
                    CmbColumnasBuscar.Items.Add(FpSpread.ActiveSheet.ColumnHeader.Cells(0, c).Text)
                    CmbBuscaIndex.Items.Add(c)
                End If
                FpSpread.ActiveSheet.Columns(c).Tag = CmbColumnasBuscar.Items(CmbColumnasBuscar.Items.Count - 1).ToString
            End If

        Next

        If InicializandoVista AndAlso CheckedListBox1 IsNot Nothing Then
            '            RemoveHandler CheckedListBox1.ItemCheck, AddressOf CheckedListBox1_ItemCheck
            CheckedListBox1.Items.Clear()
            For i As Integer = 0 To CmbColumnasBuscar.Items.Count - 1
                CheckedListBox1.Items.Add(CmbColumnasBuscar.Items(i).Trim)
                CheckedListBox1.SetItemChecked(CheckedListBox1.Items.Count - 1, True)
                If CmbColumnasBuscar.Items(i).ToString.Trim <> "" Then

                End If
            Next
            'AddHandler CheckedListBox1.ItemCheck, AddressOf CheckedListBox1_ItemCheck
        End If


        CmbColumnasBuscar.SelectedIndex = CmbBuscaIndex.Items.IndexOf(ColInd)
    End Sub
    Public Shared Sub Condicionales(ByVal FpSpread As FpSpread, LessThanValue As Double, EqualToValue As Double, GreaterThanValue As Double, LessThanColor As Color, EqualToColor As Color, GreaterThanColor As Color, Optional ByVal Col As String = "", Optional ByVal RowCol As Integer = -1)
        If Col <> "" Then
            Dim Cols() As String
            Cols = Col.Split(",")

            FpSpread.ActiveSheet.ClearConditionalFormatings()
            For ColI As Integer = 0 To UBound(Cols)

                Dim RuleBarato As New UnaryComparisonConditionalFormattingRule(UnaryComparisonOperator.LessThan, LessThanValue, False)
                Dim RuleIgual As New UnaryComparisonConditionalFormattingRule(UnaryComparisonOperator.EqualTo, EqualToValue, False)
                Dim RuleCaro As New UnaryComparisonConditionalFormattingRule(UnaryComparisonOperator.GreaterThan, GreaterThanValue, False)

                RuleBarato.ForeColor = LessThanColor
                RuleIgual.ForeColor = EqualToColor
                RuleCaro.ForeColor = GreaterThanColor

                FpSpread.ActiveSheet.SetConditionalFormatting(0, CInt(Cols(ColI)), FpSpread.ActiveSheet.RowCount, 1, RuleBarato)
                FpSpread.ActiveSheet.SetConditionalFormatting(0, CInt(Cols(ColI)), FpSpread.ActiveSheet.RowCount, 1, RuleIgual)
                FpSpread.ActiveSheet.SetConditionalFormatting(0, CInt(Cols(ColI)), FpSpread.ActiveSheet.RowCount, 1, RuleCaro)
            Next
        Else
            If RowCol > -1 Then
                FpSpread.ActiveSheet.ClearConditionalFormatings()

                Dim RR As New FormulaConditionalFormattingRule("IF(RC" & RowCol & "=TRUE,FASLE,TRUE)")
                MsgBox(RR.Formula)
                RR.ForeColor = LessThanColor

                FpSpread.ActiveSheet.SetConditionalFormatting(0, 0, FpSpread.ActiveSheet.RowCount, FpSpread.ActiveSheet.ColumnCount, RR)
            End If

        End If
    End Sub

    Public Shared Function PruebaConexion() As Boolean
        If My.Computer.Network.Ping(IIf(Remoto, sRemoto, sServidor)) Then
            Return True
        Else
            Return False
        End If


    End Function


    Public Shared Sub PintaClass(FpSpread As FpSpread, ByVal FpRenglonOld As Integer, ByVal FpColorOld As Integer, Optional ByVal FpNewRenglon As Integer = -1, Optional ByVal FpColorNew As Integer = -1)

        ' 1. Protección básica contra objetos nulos
        If FpSpread Is Nothing OrElse FpSpread.ActiveSheet Is Nothing Then Exit Sub

        ' 2. Congelamos pintado para evitar parpadeos y excepciones visuales
        FpSpread.SuspendLayout()

        Try
            ' 3. Procesar la Fila Vieja (Restaurar o lo que indique FpColorOld)
            If FpRenglonOld >= 0 AndAlso FpRenglonOld < FpSpread.ActiveSheet.RowCount Then
                AplicarColorFila(FpSpread, FpRenglonOld, FpColorOld)
            End If

            ' 4. Procesar la Fila Nueva (Pintar azul o lo que indique FpColorNew)
            If FpNewRenglon >= 0 AndAlso FpNewRenglon < FpSpread.ActiveSheet.RowCount Then
                AplicarColorFila(FpSpread, FpNewRenglon, FpColorNew)
            End If

        Catch ex As Exception
            ' Absorbemos excepciones de pintado para no tronar el flujo principal.
            ' Lo peor que pasa es que una fila no se pinte, pero el programa sigue.
            Debug.WriteLine("Error en PintaClass: " & ex.Message)
        Finally
            FpSpread.ResumeLayout(True)
        End Try
    End Sub

    ' --- MÉTODO HELPER PRIVADO (La magia ocurre aquí) ---
    ' --- MÉTODO HELPER PRIVADO (Lógica Idéntica al Original) ---
    ' --- MÉTODO HELPER PRIVADO CORREGIDO (Respeta el Amarillo de Error) ---
    Private Shared Sub AplicarColorFila(fp As FpSpread, rowIndex As Integer, colorCode As Integer)
        Dim sheet = fp.ActiveSheet
        Dim maxCol As Integer = sheet.ColumnCount - 1

        ' 1. LEEMOS AMBOS TAGS (LEGACY Y NUEVO)

        ' A) Tag de Celda 0 (Para tu lógica vieja: Saldo, Vale, RenGris)
        Dim CellTag As String = ""
        If sheet.Cells(rowIndex, 0).Tag IsNot Nothing Then CellTag = sheet.Cells(rowIndex, 0).Tag.ToString()

        ' B) Tag de Fila (Para la nueva lógica: ERROR_CLAVE)
        Dim RowTag As String = ""
        If sheet.Rows(rowIndex).Tag IsNot Nothing Then RowTag = sheet.Rows(rowIndex).Tag.ToString()

        ' =================================================================================
        ' CASO 1: SELECCIÓN (HIGHLIGHT - AZUL)
        ' =================================================================================
        If colorCode = 1 Then
            Dim HighlightColor As Color = Color.LightBlue

            If CellTag = "Saldo" Then
                SafePaint(sheet, rowIndex, 0, Math.Min(30, maxCol), HighlightColor)
                SafePaint(sheet, rowIndex, Math.Min(33, maxCol), maxCol, HighlightColor)
            Else
                SafePaint(sheet, rowIndex, 0, maxCol, HighlightColor)
            End If

            ' =================================================================================
            ' CASO 2: DESELECCIÓN (RESTORE - COLOR ORIGINAL)
            ' =================================================================================
        ElseIf colorCode = 2 Then

            ' --- A) REGLAS PRIORITARIAS (Usamos CellTag) ---
            If CellTag = "Vale" Then
                SafePaint(sheet, rowIndex, 0, maxCol, Color.LightGreen)
                Exit Sub
            End If

            If CellTag = "Saldo" Then
                SafePaint(sheet, rowIndex, 0, Math.Min(30, maxCol), Color.White)
                SafePaint(sheet, rowIndex, Math.Min(33, maxCol), maxCol, Color.White)
                Exit Sub
            End If

            ' --- B) LIMPIEZA BASE POR GRID ---
            Select Case fp.Name
                Case "FpSpreadDet"
                    SafePaint(sheet, rowIndex, 0, maxCol, Color.White)
                    SafePaint(sheet, rowIndex, 3, 3, SystemColors.GradientInactiveCaption)
                    SafePaint(sheet, rowIndex, 7, maxCol, SystemColors.GradientInactiveCaption)

                Case "FpSpreadRevPrecios"
                    ' Zebra Striping
                    Dim BaseColor As Color = If(rowIndex Mod 2 = 0, Color.FromArgb(220, 230, 241), Color.White)
                    SafePaint(sheet, rowIndex, 0, maxCol, BaseColor)

                    SafePaint(sheet, rowIndex, 11, 11, Color.FromArgb(252, 213, 180))
                    SafePaint(sheet, rowIndex, 24, 24, Color.LightGoldenrodYellow)

                    If sheet.Cells(rowIndex, Math.Min(33, maxCol)).Text = "*" Then
                        SafePaint(sheet, rowIndex, 5, 5, Color.Lavender)
                    End If

                Case "FpRegistroCompras"
                    Dim ColGris As Color = SystemColors.GradientInactiveCaption
                    SafePaint(sheet, rowIndex, 0, 0, Color.White)
                    SafePaint(sheet, rowIndex, 1, 1, ColGris)
                    SafePaint(sheet, rowIndex, 2, 6, Color.White)
                    SafePaint(sheet, rowIndex, 7, 7, ColGris)
                    SafePaint(sheet, rowIndex, 8, 11, Color.White)
                    SafePaint(sheet, rowIndex, 12, 19, ColGris)

                Case "FpSpreadFaltantes"
                    SafePaint(sheet, rowIndex, 0, maxCol, Color.White)
                    SafePaint(sheet, rowIndex, 8, 8, Color.Lavender)
                    SafePaint(sheet, rowIndex, 17, 18, Color.LightGoldenrodYellow)
                    SafePaint(sheet, rowIndex, 19, 19, Color.Lavender)
                    SafePaint(sheet, rowIndex, 20, 21, Color.LightGoldenrodYellow)
                    SafePaint(sheet, rowIndex, 24, 25, Color.LightGoldenrodYellow)
                    SafePaint(sheet, rowIndex, 12, 12, Color.Lavender)

                Case Else
                    ' GRIDS GENÉRICOS (Usamos CellTag aquí también por si acaso)
                    If CellTag = "RenGris" Then
                        SafePaint(sheet, rowIndex, 0, maxCol, Color.LightGray)
                    Else
                        SafePaint(sheet, rowIndex, 0, maxCol, Color.White)
                    End If
            End Select

            ' --- C) PERSISTENCIA DE ERRORES (Usamos RowTag) ---
            ' Verificamos el Tag de la FILA, que es donde Rellena() puso la marca
            If RowTag = "ERROR_CLAVE" Then
                SafePaint(sheet, rowIndex, 5, 5, Color.Yellow)
            End If

        End If
    End Sub
    ' --- MÉTODO PARA PINTAR SEGURO (Evita excepciones de índice) ---
    Private Shared Sub SafePaint(sheet As FarPoint.Win.Spread.SheetView, row As Integer, colStart As Integer, colEnd As Integer, c As Color)
        ' Validamos límites antes de intentar pintar
        If colStart > sheet.ColumnCount - 1 Then Exit Sub
        If colEnd > sheet.ColumnCount - 1 Then colEnd = sheet.ColumnCount - 1

        If colEnd >= colStart Then
            ' Usamos LockBackColor porque mencionaste que tus celdas suelen estar bloqueadas
            sheet.Cells(row, colStart, row, colEnd).LockBackColor = c
            sheet.Cells(row, colStart, row, colEnd).BackColor = c ' Opcional si alguna no está bloqueada
        End If
    End Sub


End Class
