Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmTrnCutiIzinInput : Inherits DockContent
    Dim perintah As String
    Private Sub FrmTrnCutiIzinInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        Call GetStatusTK(cboStatus)
        Call EnableBtn(False)
        Call EnableTxt(False)
        Call CleareTxt()
        Call GetJenisTidakHadir(cboJenisTidakHadir)
    End Sub
    Private Sub SetGridDefult()
        Dim txt As CellRange
        With fg
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Thistle
            .Styles.Fixed.ForeColor = Color.Black
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .BorderStyle = Util.BaseControls.BorderStyleEnum.None
            .Styles.Normal.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = False
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 30
            .Cols.Frozen = 0
            .Cols.Count = 11
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Nama" : .Cols(1).Name = "Nama" : .Cols(1).Width = 200
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nik" : .Cols(2).Name = "Nik" : .Cols(2).Width = 70 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Departemen" : .Cols(3).Name = "Departemen" : .Cols(3).Width = 140
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Jabatan" : .Cols(4).Name = "Jabatan" : .Cols(4).Width = 140
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "HeaderID" : .Cols(5).Name = "HeaderID" : .Cols(5).Width = 100 : .Cols(5).Visible = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "RegNo" : .Cols(6).Name = "RegNo" : .Cols(6).Width = 100 : .Cols(6).Visible = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Status TK" : .Cols(7).Name = "StatusTK" : .Cols(7).Width = 100 : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Tanggal" : .Cols(8).Name = "Tanggal" : .Cols(8).Width = 100
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Absensi" : .Cols(9).Name = "Absensi" : .Cols(9).Width = 80 : .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "DetailID" : .Cols(10).Name = "DetailID" : .Cols(10).Width = 100 : .Cols(10).Visible = False
        End With
    End Sub
    Private Sub EnableBtn(ByVal flag As Boolean)
        btnFind.Enabled = Not flag
        btnAdd.Enabled = Not flag
        btnEdit.Enabled = Not flag
        btnSave.Enabled = flag
        btnCancel.Enabled = flag
        btnDelete.Enabled = flag
    End Sub
    Private Sub EnableTxt(ByVal flag As Boolean)
        cboStatus.Enabled = flag
        txtNik.Enabled = flag
        cboJenisTidakHadir.Enabled = flag
        dtTanggalMulai.Enabled = flag
        dtTanggalAkhir.Enabled = flag
        txtKeterangan.Enabled = flag
        btnProses.Enabled = flag
        chkComplete.Enabled = flag
    End Sub
    Private Sub CleareTxt()
        cboStatus.ResetText()
        txtRegNo.Text = ""
        txtNik.Text = ""
        txtNama.Text = ""
        txtDepartemen.Text = ""
        txtJabatan.Text = ""
        cboJenisTidakHadir.ResetText()
        dtTanggalMulai.Value = Now
        dtTanggalAkhir.Value = Now
        chkComplete.Checked = False
        txtHeaderID.Text = ""
        txtKeterangan.Clear()
        fg.Rows.Count = 1
        fg.Rows.Count = 2
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        perintah = "FIND"
        Call CleareTxt()
        FrmTrnCutiIzinFind.ShowDialog()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        perintah = "ADD"
        Call EnableBtn(True)
        Call CleareTxt()
        Call EnableTxt(True)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Trim(txtHeaderID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Diedit!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Call EnableBtn(True)
        chkComplete.Enabled = True
        perintah = "EDIT"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Try

            If Trim(txtRegNo.Text) = "" Then
                MsgBox("RegNo Tidak Boleh Kosong!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Trim(txtNama.Text) = "" Then
                MsgBox("Nama Tidak Boleh Kosong!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Trim(cboJenisTidakHadir.Text) = "" Then
                MsgBox("Jenis Tidak Boleh Kosong!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Trim(txtKeterangan.Text) = "" Then
                MsgBox("Keterangan Tidak Boleh Kosong!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Convert.ToString(fg.Item(1, "Nik")) = "" Then
                MsgBox("Tidak Ada Data Yang Akan Disimpan, Klik Proses Terlebih Dahulu!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor

            If Simpan(Koneksi, Transaksi) = False Then
                MsgBox("Simpan Data Header Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
                Me.Cursor = Cursors.Default
                Transaksi.Rollback()
                Exit Sub
            End If
            If Trim(txtHeaderID.Text) = "" Then
                MsgBox("Simpan " & cboJenisTidakHadir.Text & " Dibatalkan!", vbCritical, "Failed")
                Me.Cursor = Cursors.Default
                Transaksi.Rollback()
                Exit Sub
            End If
            For i As Integer = 1 To fg.Rows.Count - 1
                If Convert.ToDouble(fg.Item(i, "Nik")) > 0 Then
                    If SimpanDtl(Koneksi, Transaksi, i) = False Then
                        MsgBox("Simpan Data Detail Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
                        Me.Cursor = Cursors.Default
                        Transaksi.Rollback()
                        Exit Sub
                    End If
                End If
            Next
            Transaksi.Commit()
            perintah = "SAVE"
            Me.Cursor = Cursors.Default
            MsgBox("Simpan " & cboJenisTidakHadir.Text & " Berhasil", vbInformation)
            Call EnableBtn(False)
            Call CleareTxt()
            Call EnableTxt(False)
            fg.Rows.Count = 1
            fg.Rows.Count = 2
        Catch ex As Exception
            Transaksi.Rollback()
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Trim(txtHeaderID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Dihapus!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        If MessageBox.Show("Anda Ingin Menghapus " & cboJenisTidakHadir.Text & " Nama : " & txtNama.Text & " Ini?", "Delete", MessageBoxButtons.YesNo) = vbYes Then
            perintah = "DELETE"
            Call HapusData()
            Call EnableBtn(False)
            Call CleareTxt()
            Call EnableTxt(False)
        End If
    End Sub

    Private Sub HapusData()
        Try
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn
                .CommandTimeout = 0
                .CommandType = CommandType.Text
                .CommandText = "Delete tblTrnCutiIzinHdr WHERE HeaderID='" & Trim(txtHeaderID.Text) & "' "
                .ExecuteNonQuery()
                .CommandText = "Delete tblTrnCutiIzinDetail WHERE HeaderID='" & Trim(txtHeaderID.Text) & "' "
                .ExecuteNonQuery()
            End With
            MsgBox("Data Berhasil Hapus", vbInformation, "Success")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        perintah = "CANCEL"
        Call EnableBtn(False)
        Call CleareTxt()
        Call EnableTxt(False)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub cboJenisTidakHadir_TextUpdate(sender As Object, e As EventArgs) Handles cboJenisTidakHadir.TextUpdate
        ValidCombo(cboJenisTidakHadir)
    End Sub

    Private Sub cboStatus_TextUpdate(sender As Object, e As EventArgs) Handles cboStatus.TextUpdate
        ValidCombo(cboStatus)
    End Sub

    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 1
        If cboStatus.SelectedValue = 1 Then
            sql = " select RegNo,NAMA,NIK,Departemen,JabatanName,LiburMingguan from vwMstKaryawan where   StatusTK='KARYAWAN' and NIK='" & Trim(txtNik.Text) & "' "
        Else
            sql = " select RegNo,NAMA,NIK,Departemen,JabatanName,LiburMingguan from vwMstKaryawan where   StatusTK='HARIAN' and NIK='" & Trim(txtNik.Text) & "' "
        End If
        lblPesan.Visible = False
        Me.Cursor = Cursors.WaitCursor
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows And DR.Read Then
                    If IsDBNull(DR!RegNo) = False Then txtRegNo.Text = DR!RegNo
                    If IsDBNull(DR!NAMA) = False Then txtNama.Text = DR!NAMA
                    If IsDBNull(DR!NIK) = False Then txtNik.Text = DR!NIK
                    If IsDBNull(DR!Departemen) = False Then txtDepartemen.Text = DR!Departemen
                    If IsDBNull(DR!JabatanName) = False Then txtJabatan.Text = DR!JabatanName
                    If IsDBNull(DR!LiburMingguan) = False Then txtIDLiburMingguan.Text = DR!LiburMingguan
                    lblPesan.Visible = False
                Else
                    lblPesan.Text = "Data Tidak Ditemukan!"
                    lblPesan.Visible = True
                    txtNama.Clear()
                    txtDepartemen.Clear()
                    txtJabatan.Clear()
                    cboJenisTidakHadir.ResetText()
                    txtRegNo.Clear()
                    txtHeaderID.Clear()
                    dtTanggalMulai.Value = Now
                    dtTanggalAkhir.Value = Now
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End Using
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtNik_TextChanged(sender As Object, e As EventArgs) Handles txtNik.TextChanged
        If perintah = "ADD" Then
            If Trim(cboStatus.Text) = "" Then
                MsgBox("Status Belum Dipilih!", MessageBoxIcon.Stop)
                txtNik.Text = ""
                Exit Sub
            End If
            Call GetData()
            If Trim(txtNik.Text) = "" Then
                lblPesan.Visible = False
            End If
        End If
    End Sub

    Private Sub txtNik_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNik.KeyPress
        If perintah = "ADD" Then
            If Trim(cboStatus.Text) = "" Then
                MsgBox("Status Belum Dipilih!", MessageBoxIcon.Stop)
                txtNik.Text = ""
                Exit Sub
            End If
            Call GetData()
            If Trim(txtNik.Text) = "" Then
                lblPesan.Visible = False
            End If
        End If
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged

    End Sub

    Private Sub cboStatus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboStatus.SelectionChangeCommitted
        txtRegNo.Text = ""
        txtNik.Text = ""
        txtNama.Text = ""
        txtDepartemen.Text = ""
        txtJabatan.Text = ""
        cboJenisTidakHadir.ResetText()
        dtTanggalMulai.Value = Now
        dtTanggalAkhir.Value = Now
        chkComplete.Checked = False
        txtHeaderID.Text = ""
        fg.Rows.Count = 1
        fg.Rows.Count = 2
    End Sub


    Private Function Simpan(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        Simpan = False
        Dim mycon As SqlConnection = conn
        Dim mycontrans As SqlTransaction = trans
        Dim StatusTK As String = ""
        If cboStatus.SelectedValue = 1 Then
            StatusTK = "KARYAWAN"
        Else
            StatusTK = "HARIAN"
        End If
        With cmd
            .Connection = conn
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spTrnCutiIzinHdrSave"
            .Transaction = mycontrans
            .Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.BigInt, 3, ParameterDirection.ReturnValue, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add("@HeaderID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(txtHeaderID.Text)
            .Parameters.Add("@StatusTk", SqlDbType.VarChar, 20).Value = StatusTK
            .Parameters.Add("@RegNo", SqlDbType.BigInt).Value = Trim(txtRegNo.Text)
            .Parameters.Add("@IDTidakKerja", SqlDbType.Int).Value = cboJenisTidakHadir.SelectedValue
            .Parameters.Add("@TglAwal", SqlDbType.Date).Value = Format(dtTanggalMulai.Value, "yyyy-MM-dd")
            .Parameters.Add("@TglAkhir", SqlDbType.Date).Value = Format(dtTanggalAkhir.Value, "yyyy-MM-dd")
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 100).Value = Trim(txtKeterangan.Text)
            If chkComplete.Checked = True Then
                .Parameters.Add("@Complete", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@Complete", SqlDbType.Int).Value = 0
            End If
            .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = UserLogin
            .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
            .Parameters("@HeaderID").Direction = ParameterDirection.InputOutput
            .ExecuteNonQuery()
            If Val(.Parameters("@HeaderID").Value) > 0 Then txtHeaderID.Text = Val(cmd.Parameters("@HeaderID").Value)
        End With
        If CInt(cmd.Parameters("@Flag").Value) <> 0 Then
            cmd.Dispose()
            Exit Function
        End If
        cmd.Dispose()
        Simpan = True
        Return Simpan
    End Function

    Private Function SimpanDtl(ByVal Conn As SqlConnection, ByVal trans As SqlTransaction, ByVal i As Integer) As Boolean
        SimpanDtl = False
        Dim cmd As New SqlCommand
        Dim kon As SqlConnection = Conn
        Dim mycontrans As SqlTransaction = trans
        With cmd
            .Connection = kon
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spTrnCutiIzinDetailSave"
            .Transaction = mycontrans
            .Parameters.Add("@DetailID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(fg.Item(i, "DetailID"))
            .Parameters.Add("@HeaderID", SqlDbType.BigInt, ParameterDirection.Input).Value = Val(txtHeaderID.Text)
            .Parameters.Add("@Tanggal", SqlDbType.Date, ParameterDirection.Input).Value = Format(CDate(fg.Item(i, "Tanggal")), "yyyy-MM-dd")
            .Parameters.Add("@Absen", SqlDbType.VarChar, 5).Value = fg.Item(i, "Absensi")
            .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 200).Value = UserLogin
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.Int, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
            If .Parameters("@Flag").Value <> 0 Then SimpanDtl = True
        End With
        cmd = Nothing
        Return SimpanDtl
    End Function

    Private Sub SetCuti()
        If perintah = "ADD" Then
            Dim TglAwal, TglAkhir As Date
            Dim baris As Integer = 0
            TglAwal = dtTanggalMulai.Value
            TglAkhir = dtTanggalAkhir.Value
            If Trim(txtRegNo.Text) = "" Then
                MsgBox("RegNo Tidak Boleh Kosong!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Trim(txtNama.Text) = "" Then
                MsgBox("Nama Tidak Boleh Kosong!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Trim(cboJenisTidakHadir.Text) = "" Then
                MsgBox("Jenis Tidak Boleh Kosong!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If DateDiff(DateInterval.Day, TglAwal, TglAkhir) < 0 Then
                MsgBox("Tanggal Akhir Tidak Boleh Kecil Dari Tanggal Awal!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            With fg
                .Rows.Count = 1
                TglAwal = DateAdd(DateInterval.Day, -1, TglAwal)
                While TglAwal < TglAkhir
                    .AddItem("")
                    baris = .Rows.Count - 1
                    .Item(baris, "No") = baris
                    .Item(baris, "Nama") = Trim(txtNama.Text)
                    .Item(baris, "Nik") = Trim(txtNik.Text)
                    .Item(baris, "Departemen") = Trim(txtDepartemen.Text)
                    .Item(baris, "Jabatan") = Trim(txtJabatan.Text)
                    .Item(baris, "Tanggal") = Format(DateAdd(DateInterval.Day, 1, TglAwal), "yyyy-MM-dd")
                    If Weekday(DateAdd(DateInterval.Day, 1, TglAwal)) = Val(txtIDLiburMingguan.Text) Then
                        .Item(baris, "Absensi") = "IM"
                        StyleForeColor(fg, Color.Red, baris, 9, 9, True)
                    Else
                        Select Case cboJenisTidakHadir.SelectedValue
                            Case 1
                                .Item(baris, "Absensi") = "I"
                            Case 2
                                .Item(baris, "Absensi") = "ID"
                            Case 3
                                .Item(baris, "Absensi") = "C"
                            Case 4
                                .Item(baris, "Absensi") = "S"
                            Case 5
                                .Item(baris, "Absensi") = "DL"
                        End Select
                    End If
                    TglAwal = DateAdd(DateInterval.Day, 1, TglAwal)
                    If TglAwal = TglAkhir Then
                        Exit While
                    End If
                End While
            End With
        End If
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        If GetCek() = True Then
            MsgBox("Data A/N : " & txtNama.Text & " Sudah Ada!, Silakan Klik Find.", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Call SetCuti()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub GetDataSudahDisimpan(ByVal HeaderID As Integer)
        Dim sql As String = ""
        Dim baris As Integer = 1

        sql = " select DetailID,HeaderID,TglAwal,TglAkhir,Tanggal,Absen,StatusTk,LiburMingguan,RegNo,Nik,Nama,Departemen,JabatanName,IDTidakKerja,NamaTidakKerja,Keterangan  " &
                    " from vwTrnCutiIzin where HeaderID=" & HeaderID & "  "
        Me.Cursor = Cursors.WaitCursor
        fg.Rows.Count = 1
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    While DR.Read
                        txtHeaderID.Text = DR!HeaderID
                        If IsDBNull(DR!StatusTk) = False Then cboStatus.Text = DR!StatusTk
                        If IsDBNull(DR!Nik) = False Then txtNik.Text = DR!Nik
                        If IsDBNull(DR!RegNo) = False Then txtRegNo.Text = DR!RegNo
                        If IsDBNull(DR!NAMA) = False Then txtNama.Text = DR!NAMA
                        If IsDBNull(DR!Departemen) = False Then txtDepartemen.Text = DR!Departemen
                        If IsDBNull(DR!JabatanName) = False Then txtJabatan.Text = DR!JabatanName
                        If IsDBNull(DR!LiburMingguan) = False Then txtIDLiburMingguan.Text = DR!LiburMingguan
                        If IsDBNull(DR!NamaTidakKerja) = False Then cboJenisTidakHadir.Text = DR!NamaTidakKerja
                        If IsDBNull(DR!TglAwal) = False Then dtTanggalMulai.Value = DR!TglAwal
                        If IsDBNull(DR!TglAkhir) = False Then dtTanggalAkhir.Value = DR!TglAkhir
                        If IsDBNull(DR!Keterangan) = False Then txtKeterangan.Text = DR!Keterangan

                        With fg
                            .AddItem("")
                            baris = .Rows.Count - 1
                            .Item(baris, "No") = baris
                            .Item(baris, "Nama") = DR!NAMA
                            .Item(baris, "Nik") = DR!Nik
                            If IsDBNull(DR!Departemen) = False Then .Item(baris, "Departemen") = DR!Departemen
                            If IsDBNull(DR!JabatanName) = False Then .Item(baris, "Jabatan") = DR!JabatanName
                            .Item(baris, "Tanggal") = Format(DR!Tanggal, "yyyy-MM-dd")
                            If DR!Absen = "IM" Then
                                .Item(baris, "Absensi") = DR!Absen
                                StyleForeColor(fg, Color.Red, baris, 9, 9, True)
                            Else
                                .Item(baris, "Absensi") = DR!Absen
                            End If
                            If IsDBNull(DR!DetailID) = False Then .Item(baris, "DetailID") = DR!DetailID
                        End With
                    End While
                Else
                    fg.Rows.Count = 2
                End If
            End Using
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Function GetCek() As Boolean
        Dim sql As String = ""
        Dim i As Integer = 1
        Dim ret As Boolean = False
        If cboStatus.SelectedValue = 1 Then
            sql = "SELECT * FROM vwTrnCutiIzin where Complete=0 and ApproveByDept is null and  StatusTK='KARYAWAN' and  Nik='" & Trim(txtNik.Text) & "' "
        Else
            sql = "SELECT * FROM vwTrnCutiIzin where Complete=0 and ApproveByDept is null and  StatusTK='HARIAN' and Nik='" & (txtNik.Text) & "' "
        End If
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    ret = True
                End If
            End Using
        End Using
        Return ret
    End Function
End Class