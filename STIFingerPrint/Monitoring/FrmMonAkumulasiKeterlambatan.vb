Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMonAkumulasiKeterlambatan : Inherits DockContent
    Dim txt As CellRange
    Private Sub FrmMonAkumulasiKeterlambatan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        'dtPeriode1.Value = Now
        txtPeriode.Text = Format(Now, "MM/yyyy")
        Call GetStatusTK(cboStatus)
        Call GetDepartemenAksesn(cboDepartemen)
    End Sub
    Private Sub SetGridDefult()

        With fg1
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Aquamarine
            .Styles.Fixed.ForeColor = Color.Black
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .BorderStyle = Util.BaseControls.BorderStyleEnum.None
            .Styles.Normal.WordWrap = True
            .SelectionMode = SelectionModeEnum.Row
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = False
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 35
            .Cols.Frozen = 3
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "UserID" : .Cols(1).Name = "UserID" : .Cols(1).Width = 80 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama" : .Cols(2).Name = "Nama" : .Cols(2).Width = 200 : .Cols(2).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nik" : .Cols(3).Name = "NIK" : .Cols(3).Width = 80 : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Departemen" : .Cols(4).Name = "Departemen" : .Cols(4).Width = 100 : .Cols(4).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Keterlambatan" & vbCrLf & "Masuk" : .Cols(5).Name = "LambatMasuk" : .Cols(5).Width = 100 : .Cols(5).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Cepat Ist Keluar" : .Cols(6).Name = "CepatIstKeluar" : .Cols(6).Width = 100 : .Cols(6).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Keterlambatan" & vbCrLf & "Ist Masuk" : .Cols(7).Name = "LambatIstirahat" : .Cols(7).Width = 100 : .Cols(7).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Cepat Pulang" : .Cols(8).Name = "CepatPulang" : .Cols(8).Width = 100 : .Cols(8).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Total" : .Cols(9).Name = "Total" : .Cols(9).Width = 100 : .Cols(9).TextAlign = TextAlignEnum.RightCenter
        End With
        With fg2
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Aquamarine
            .Styles.Fixed.ForeColor = Color.Black
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .BorderStyle = Util.BaseControls.BorderStyleEnum.None
            .Styles.Normal.WordWrap = True
            .SelectionMode = SelectionModeEnum.Row
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = False
            .Rows.Fixed = 2
            .Rows.Count = 3
            .Rows(0).Height = 35
            .Cols.Frozen = 0
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40 : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 0, 9) : txt.Data = "Nama" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : StyleBackColor(fg2, Color.Aquamarine, 0, 1, .Cols.Count - 1)
            txt = .GetCellRange(1, 1, 1, 1) : txt.Data = "Tanggal" : .Cols(1).Name = "Tanggal" : .Cols(1).Width = 80 : .Cols(1).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(1, 2, 1, 2) : txt.Data = "Masuk" : .Cols(2).Name = "Masuk" : .Cols(2).Width = 110 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 3, 1, 3) : txt.Data = "Istirahat Keluar" : .Cols(3).Name = "IstirahatKeluar" : .Cols(3).Width = 110 : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 4, 1, 4) : txt.Data = "Istirahat Masuk" : .Cols(4).Name = "IstirahatMasuk" : .Cols(4).Width = 110 : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 5, 1, 5) : txt.Data = "Pulang" : .Cols(5).Name = "Pulang" : .Cols(5).Width = 110 : .Cols(5).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 6, 1, 6) : txt.Data = "Lambat Masuk" : .Cols(6).Name = "LambatMasuk" : .Cols(6).Width = 110 : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 7, 1, 7) : txt.Data = "Lambat Ist Masuk" : .Cols(7).Name = "LambatIstMasuk" : .Cols(7).Width = 110 : .Cols(7).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 8, 1, 8) : txt.Data = "Pulang Cepat" : .Cols(8).Name = "PulangCepat" : .Cols(8).Width = 110 : .Cols(8).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 9, 1, 9) : txt.Data = "Keterangan" : .Cols(9).Name = "Keterangan" : .Cols(9).Width = 200 : .Cols(9).TextAlign = TextAlignEnum.CenterCenter
        End With
    End Sub
    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 0
        Dim Total As Integer = 0
        Dim Sts As String = ""
        If cboStatus.SelectedValue = 1 Then
            Sts = "KARYAWAN"
        Else
            Sts = "HARIAN"
        End If
        Try
            sql = "select UserID,NAMA,NIK,Departemen,ISNULL(SUM(LambatMasukKerja),0) as LambatMasukKerja,ISNULL(SUM(CepatIstKeluar),0) AS CepatIstKeluar,ISNULL(SUM(LambatMasukIstirahat),0) as LambatMasukIstirahat, " &
                    " ISNULL(SUM(PulangCepat),0) as PulangCepat from vwAbsensiKry WHERE PeriodeBln='" & Format(CDate(txtPeriode.Text), "yyyy-MM") & "-01" & "' and DeptID='" & cboDepartemen.SelectedValue & "' AND StatusTk='" & Sts & "' "
            sql = sql & " Group By UserID,NAMA,NIK,Departemen order by LambatMasukKerja desc "
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                fg1.Rows.Count = 1
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        With fg1
                            While DR.Read
                                .AddItem("")
                                i = .Rows.Count - 1
                                .Item(i, "No") = i
                                If IsDBNull(DR!UserID) = False Then .Item(i, "UserID") = DR!UserID
                                If IsDBNull(DR!NIK) = False Then .Item(i, "NIK") = DR!NIK
                                If IsDBNull(DR!NAMA) = False Then .Item(i, "NAMA") = DR!NAMA
                                If IsDBNull(DR!Departemen) = False Then .Item(i, "Departemen") = DR!Departemen
                                If IsDBNull(DR!LambatMasukKerja) = False Then
                                    .Item(i, "LambatMasuk") = ConversiMenitKeJam(DR!LambatMasukKerja)
                                    Total = DR!LambatMasukKerja
                                End If
                                If IsDBNull(DR!CepatIstKeluar) = False Then
                                    .Item(i, "CepatIstKeluar") = ConversiMenitKeJam(DR!CepatIstKeluar)
                                    Total = Total + DR!CepatIstKeluar
                                End If
                                If IsDBNull(DR!LambatMasukIstirahat) = False Then
                                    .Item(i, "LambatIstirahat") = ConversiMenitKeJam(DR!LambatMasukIstirahat)
                                    Total = Total + DR!LambatMasukIstirahat
                                End If
                                If IsDBNull(DR!PulangCepat) = False Then
                                    .Item(i, "CepatPulang") = ConversiMenitKeJam(DR!PulangCepat)
                                    Total = Total + DR!PulangCepat
                                End If
                                .Item(i, "Total") = ConversiMenitKeJam(Total)
                            End While
                        End With
                    Else
                        fg1.Rows.Count = 1
                        fg1.Rows.Count = 2
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If txtPeriode.Text = "  :" Then
            MsgBox("Periode Belum Diisi!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If Trim(cboStatus.Text) = "" Then
            MsgBox("Status Silakan Pilih Terlebih Dahulu!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        If Trim(cboDepartemen.Text) = "" Then
            MsgBox("Departemen Silakan Pilih Terlebih Dahulu!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        fg2.Rows.Count = 2
        fg2.Rows.Count = 3
        Me.Cursor = Cursors.WaitCursor
        Call GetData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function ConversiMenitKeJam(ByVal TotMenit As Integer) As String
        Dim hour As Long, minute As Long
        Dim a As Long
        hour = Int(TotMenit / 60)
        If hour > 0 Then
            a = hour * 60
        End If
        minute = TotMenit - a
        If hour > 0 Then
            ConversiMenitKeJam = CStr(hour) & " Jam "
            ConversiMenitKeJam = ConversiMenitKeJam & Format$(minute, "00") & " Menit"
        Else
            If minute = 0 Then
                ConversiMenitKeJam = 0
            Else
                ConversiMenitKeJam = minute & " Menit"
            End If
        End If
    End Function
    Private Sub GetDataDetail(ByVal UserID As String)
        Dim sql As String = ""
        Dim i As Integer = 0
        Try
            sql = "select * from vwAbsensiKry WHERE PeriodeBln='" & Format(CDate(txtPeriode.Text), "yyyy-MM") & "-01" & "' and UseriD='" & UserID & "' "
            sql = sql & "  order by PeriodeTgl "
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                fg2.Rows.Count = 2
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        With fg2
                            While DR.Read
                                .AddItem("")
                                i = .Rows.Count - 1
                                .Item(i, "No") = i - 1
                                If IsDBNull(DR!PeriodeTgl) = False Then .Item(i, "Tanggal") = Format(DR!PeriodeTgl, "dd/MM/yyyy")
                                If IsDBNull(DR!AbsenMasuk) = False Then .Item(i, "Masuk") = Format(DR!AbsenMasuk, "dd/MM/yyyy HH:mm")
                                If IsDBNull(DR!AbsenKeluarIst) = False Then .Item(i, "IstirahatKeluar") = Format(DR!AbsenKeluarIst, "dd/MM/yyyy HH:mm")
                                If IsDBNull(DR!AbsenMasukIst) = False Then .Item(i, "IstirahatMasuk") = Format(DR!AbsenMasukIst, "dd/MM/yyyy HH:mm")
                                If IsDBNull(DR!AbsenPulang) = False Then .Item(i, "Pulang") = Format(DR!AbsenPulang, "dd/MM/yyyy HH:mm")
                                If IsDBNull(DR!LambatMasukKerja) = False Then .Item(i, "LambatMasuk") = DR!LambatMasukKerja
                                If IsDBNull(DR!LambatMasukIstirahat) = False Then .Item(i, "LambatIstMasuk") = DR!LambatMasukIstirahat
                                If IsDBNull(DR!PulangCepat) = False Then .Item(i, "PulangCepat") = DR!PulangCepat
                                If IsDBNull(DR!Keterangan) = False Then .Item(i, "Keterangan") = DR!Keterangan
                            End While
                            .Subtotal(AggregateEnum.Clear)
                            .SubtotalPosition = SubtotalPositionEnum.BelowData
                            For j As Integer = 6 To 9
                                .Subtotal(AggregateEnum.Sum, -1, -1, j, "Total")
                            Next
                        End With
                    Else
                        fg2.Rows.Count = 2
                        fg2.Rows.Count = 3
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub fg1_Click(sender As Object, e As EventArgs) Handles fg1.Click

    End Sub

    Private Sub fg1_DoubleClick(sender As Object, e As EventArgs) Handles fg1.DoubleClick

        If Convert.ToDouble(fg1.Item(fg1.Row, "UseriD")) > 0 Then
            txt = fg2.GetCellRange(0, 1, 0, 9) : txt.Data = fg1.Item(fg1.Row, "Nama")
            Me.Cursor = Cursors.WaitCursor
            Call GetDataDetail(fg1.Item(fg1.Row, "UseriD"))
            Me.Cursor = Cursors.Default
        Else
            fg2.Rows.Count = 2
            fg2.Rows.Count = 3
            fg2.Item(0, 9) = ""
        End If
    End Sub

    Private Sub btnCloseDevice_Click(sender As Object, e As EventArgs) Handles btnCloseDevice.Click
        Me.Close()
    End Sub

    Private Sub btnExecl_Click(sender As Object, e As EventArgs) Handles btnExecl.Click
        Me.Cursor = Cursors.WaitCursor
        Call ExportExcelInpoiFlexgrid(fg2, 0, 0, True, "Akumulasi Absensi 01" & Format(CDate(txtPeriode.Text), "MMyyyy"))
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fg1_MouseMove(sender As Object, e As MouseEventArgs) Handles fg1.MouseMove
        Try
            If fg1.MouseRow > 0 Then
                Dim tip As String = "Double Clik Untuk Lihat Data Detail!"
                ToolTip1.SetToolTip(fg1, tip)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cboStatus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboStatus.SelectionChangeCommitted
        'Call GetDepartemenByStatus(cboDepartemen, cboStatus.SelectedValue)
    End Sub
End Class