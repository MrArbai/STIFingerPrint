Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports NPOI.HPSF
Imports NPOI.HSSF.UserModel
Imports NPOI.HSSF.Util
Imports NPOI.SS.UserModel
'Imports NPOI.XSSF.UserModel

Module ModuleInpoi
    Public Sub ExportExcelInpoiFlexgrid(ByVal fg As C1FlexGrid, ByVal BarisMulai As Integer, ByVal KolomMulai As Integer, ByVal TampilHidden As Boolean, ByVal NamaFile As String)
        Try
            Dim dt As New DataTable
            Dim minrow As Integer = 0
            dt.Columns.Clear()
            dt.Rows.Clear()

            For kol As Integer = KolomMulai To fg.Cols.Count - 1
                If fg.Cols(kol).Visible = TampilHidden Then
                    If IsNumeric(fg.Cols(kol).Name) = False And fg.Cols(kol).Name.ToString <> "" Then
                        dt.Columns.Add(fg.Cols(kol).Name, GetType(String))
                    Else
                        dt.Columns.Add(fg.Cols(kol).Index, GetType(String))
                    End If
                End If
            Next
            Dim barisfg As Integer = fg.Rows.Fixed - 1
            For i As Integer = barisfg To fg.Rows.Count - 1
                dt.Rows.Add()
                For n As Integer = KolomMulai To dt.Columns.Count - 1
                    If IsNumeric(dt.Columns(n).Caption) = False Then
                        dt.Rows(dt.Rows.Count - 1)(dt.Columns(n).Caption) = fg.Item(i, dt.Columns(n).Caption)
                    Else
                        dt.Rows(dt.Rows.Count - 1)(dt.Columns(n).Caption) = fg.Item(i, CInt(dt.Columns(n).Caption))
                    End If
                Next n
            Next

            Dim hssfworkbook As New HSSFWorkbook()
            'Dim hssfworkbook2 As New XSSFWorkbook()
            Dim si As SummaryInformation = PropertySetFactory.CreateSummaryInformation()
            si.Subject = "ExportExcel"
            hssfworkbook.SummaryInformation = si
            Dim sheet1 As ISheet = hssfworkbook.CreateSheet("Sheet1") 'SET nama sheet
            DirectCast(hssfworkbook.GetSheetAt(0), HSSFSheet).AlternativeFormula = False
            DirectCast(hssfworkbook.GetSheetAt(0), HSSFSheet).AlternativeExpression = False

            Dim row As IRow
            Dim cell As ICell

            Dim sd As New SaveFileDialog
            sd.FileName = NamaFile & ".xls"
            sd.Title = "Export Excel"
            sd.Filter = "Excel files (All files|.xls|.xls|*.*"
            If sd.ShowDialog = Windows.Forms.DialogResult.OK Then

                ' Set style normal + bordernya
                Dim style As ICellStyle = hssfworkbook.CreateCellStyle()
                style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                style.BottomBorderColor = HSSFColor.Black.Index
                style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                style.LeftBorderColor = HSSFColor.Black.Index
                style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                style.RightBorderColor = HSSFColor.Black.Index
                style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
                style.TopBorderColor = HSSFColor.Black.Index

                For idx = 0 To dt.Rows.Count - 1
                    row = sheet1.CreateRow(idx)
                    For k As Integer = 0 To dt.Columns.Count - 1
                        cell = row.CreateCell(k)
                        cell.SetCellValue(dt.Rows(idx).Item(dt.Columns(k).ColumnName).ToString)
                        cell.CellStyle = style
                    Next k
                Next

                'Set Style Title + border
                Dim styleTitle As ICellStyle = hssfworkbook.CreateCellStyle()
                styleTitle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                styleTitle.BottomBorderColor = HSSFColor.Black.Index
                styleTitle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                styleTitle.LeftBorderColor = HSSFColor.Black.Index
                styleTitle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                styleTitle.RightBorderColor = HSSFColor.Black.Index
                styleTitle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
                styleTitle.TopBorderColor = HSSFColor.Black.Index
                styleTitle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center
                styleTitle.VerticalAlignment = VerticalAlignment.Center


                Dim boldFont As HSSFFont = hssfworkbook.CreateFont
                boldFont.Boldweight = NPOI.SS.UserModel.FontBoldWeight.Bold

                styleTitle.SetFont(boldFont)

                ' Create Title
                Dim kolom As Integer = 0
                row = sheet1.CreateRow(0)
                For k As Integer = 0 To dt.Columns.Count - 1
                    cell = row.CreateCell(kolom)
                    cell.SetCellValue(dt.Rows(0).Item(dt.Columns(k).ColumnName).ToString)
                    cell.CellStyle = styleTitle
                    kolom = kolom + 1
                Next


                Dim fileMemory As New IO.MemoryStream()
                hssfworkbook.Write(fileMemory)

                Dim fileFisik As New IO.FileStream(sd.FileName, IO.FileMode.Create, IO.FileAccess.Write)
                fileMemory.WriteTo(fileFisik)
                fileFisik.Close()
                fileMemory.Close()
                MsgBox("Export Selesai!", vbInformation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub
End Module
