Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMstTenagaKerja : Inherits DockContent
    Dim perintah As String = ""
    Private Sub FrmMstTenagaKerja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        Call GetStatusTK(cboStatus)
        Call GetJabatan(cboJabatan)
        Call GetJenisKelamin(cboJenisKelamin)
        Call GetStatusJamKerja(cboStatusJamKerja)
        Call GetHari(cboLiburMinggaun)
        Call GetDepartemen(cboDepartemen)
        Call GetJabatan(cboJabatan)
        Call EnableBtn(False)
        Call EnableTxt(False)
        cboStatus.Enabled = False
        Call GetData()
    End Sub
    Private Sub EnableBtn(ByVal flag As Boolean)
        btnAdd.Enabled = Not flag
        btnEdit.Enabled = Not flag
        btnSave.Enabled = flag
        btnCancel.Enabled = flag
        fg.Enabled = Not flag
    End Sub

    Private Sub CleareTxt()
        cboStatus.ResetText()
        txtRegNo.Text = ""
        txtNik.Text = ""
        txtNama.Text = ""
        cboDepartemen.ResetText()
        cboJabatan.ResetText()
        cboBagian.ResetText()
        dtTanggalMasuk.Value = Now
        dtTanggalKeluar.Value = Now
        dtTanggalMasuk.Checked = False
        dtTanggalKeluar.Checked = False
        cboLiburMinggaun.ResetText()
        cboJenisKelamin.ResetText()
        cboStatusJamKerja.ResetText()
        txtJamKerjaPanjang.Text = 7
        txtJamKerjaPendek.Text = 5
    End Sub

    Private Sub EnableTxt(ByVal flag As Boolean)
        txtRegNo.Enabled = flag
        txtNik.Enabled = flag
        txtNama.Enabled = flag
        cboDepartemen.Enabled = flag
        cboJabatan.Enabled = flag
        cboBagian.Enabled = False
        dtTanggalMasuk.Enabled = flag
        dtTanggalKeluar.Enabled = flag
        cboLiburMinggaun.Enabled = flag
        cboJenisKelamin.Enabled = flag
        cboStatusJamKerja.Enabled = flag
        txtJamKerjaPanjang.Enabled = flag
        txtJamKerjaPendek.Enabled = flag
    End Sub

    Private Sub SetGridDefult()
        Dim txt As CellRange
        With fg
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Thistle
            .Styles.Fixed.ForeColor = Color.Black
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .BorderStyle = Util.BaseControls.BorderStyleEnum.None
            .SelectionMode = SelectionModeEnum.Row
            .Styles.Normal.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = False
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 30
            .Cols.Frozen = 3
            .Cols.Count = 18
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "RegNo" : .Cols(1).Name = "RegNo" : .Cols(1).Width = 60
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nik" : .Cols(2).Name = "Nik" : .Cols(2).Width = 80
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nama" : .Cols(3).Name = "Nama" : .Cols(3).Width = 200
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Jabatan" : .Cols(4).Name = "Jabatan" : .Cols(4).Width = 150
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "JabatanID" : .Cols(5).Name = "JabatanID" : .Cols(5).Width = 150 : .Cols(5).Visible = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Departemen" : .Cols(6).Name = "Departemen" : .Cols(6).Width = 130
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "DeptID" : .Cols(7).Name = "DeptID" : .Cols(7).Width = 100 : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Bagian" : .Cols(8).Name = "Bagian" : .Cols(8).Width = 130
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "BagianID" : .Cols(9).Name = "BagianID" : .Cols(9).Width = 100 : .Cols(9).Visible = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Tgl.Masuk" : .Cols(10).Name = "TglMasuk" : .Cols(10).Width = 100
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Tgl.Keluar" : .Cols(11).Name = "TglKeluar" : .Cols(11).Width = 100
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Jenis Kelamin" : .Cols(12).Name = "JenisKelamin" : .Cols(12).Width = 100
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Status Jam Kerja" : .Cols(13).Name = "StatusJamKerja" : .Cols(13).Width = 100 : .Cols(13).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Libur Mingguan" : .Cols(14).Name = "LiburMingguan" : .Cols(14).Width = 100
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Jam Kerja Panjang" : .Cols(15).Name = "JamKerjaPajang" : .Cols(15).Width = 100 : .Cols(15).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Jam Kerja Pendek" : .Cols(16).Name = "JamKerjaPendek" : .Cols(16).Width = 100 : .Cols(16).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Status TK" : .Cols(17).Name = "StatusTK" : .Cols(17).Width = 100
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call EnableBtn(True)
        perintah = "ADD"
        cboStatus.Enabled = True
        Call CleareTxt()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Trim(txtRegNo.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Diedit!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Call EnableBtn(True)
        perintah = "EDIT"
        cboStatus.Enabled = True
        Call EnableTxt(True)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(cboStatus.Text) = "" Then
            MsgBox("Status Belum Dipilih!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(txtRegNo.Text) = "" Then
            MsgBox("RegNo Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(txtNik.Text) = "" Then
            MsgBox("Nik Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(txtNama.Text) = "" Then
            MsgBox("Nama Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(cboDepartemen.Text) = "" Then
            MsgBox("Departemen Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(cboJabatan.Text) = "" Then
            MsgBox("Jabatan Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If dtTanggalMasuk.Checked = False Then
            MsgBox("Tanggal Masuk Belum Ditentukan!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        If Trim(cboJenisKelamin.Text) = "" Then
            MsgBox("Jenis Kelamin Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(cboStatusJamKerja.Text) = "" Then
            MsgBox("Status Jam Kerja Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(cboLiburMinggaun.Text) = "" Then
            MsgBox("Libut Mingguan Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(txtJamKerjaPanjang.Text) = "" Then
            MsgBox("Jam Kerja Panjang Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(txtJamKerjaPendek.Text) = "" Then
            MsgBox("Jam Kerja Pendek Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If GetCek() = True And perintah = "ADD" Then
            MsgBox("Tenaga Kerja Dengan RegNo : " & Trim(txtRegNo.Text) & " Sudah Ada!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        If GetCekNik() = True And perintah = "ADD" Then
            MsgBox("Tenaga Kerja Dengan Nik : " & Trim(txtNik.Text) & " Sudah Ada!", MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction

        Me.Cursor = Cursors.WaitCursor
        If Simpan(Koneksi, Transaksi) = False Then
            MsgBox("Simpan Data Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
            Me.Cursor = Cursors.Default
            Transaksi.Rollback()
            Exit Sub
        End If
        Transaksi.Commit()
        Me.Cursor = Cursors.Default
        MsgBox("Simpan Data Berhasil!", vbInformation)

        Call EnableBtn(False)
        perintah = "SAVE"
        cboStatus.Enabled = False
        Call EnableTxt(False)
        Call CleareTxt()
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call EnableBtn(False)
        perintah = "CANCEL"
        cboStatus.Enabled = False
        Call EnableTxt(False)
        Call CleareTxt()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged

    End Sub

    Private Sub cboStatus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboStatus.SelectionChangeCommitted
        If cboStatus.SelectedValue = 3 Then
            cboStatus.SelectedIndex = -1
            Call EnableTxt(False)
            MsgBox("Modul Ini Hanya Untuk Karyawan Dan Harian!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        If perintah = "ADD" Or perintah = "EDIT" Then
            Call EnableTxt(True)
        End If
    End Sub

    Private Sub cboStatus_TextUpdate(sender As Object, e As EventArgs) Handles cboStatus.TextUpdate
        ValidCombo(cboStatus)
        If Trim(cboStatus.Text) = "" Then
            cboDepartemen.DataSource = Nothing
        End If
    End Sub

    Private Function Simpan(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim ret As Boolean = False
        Simpan = False
        Try
            With cmd
                .Connection = Conn
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spMstTenagaKerjaSave"
                .Transaction = MyConTrans
                .Parameters.Add("@RegNo", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(txtRegNo.Text)
                .Parameters.Add("@Nama", SqlDbType.VarChar, 50).Value = UCase(Trim(txtNama.Text))
                .Parameters.Add("@Nik", SqlDbType.VarChar, 50).Value = Trim(txtNik.Text)
                .Parameters.Add("@DeptID", SqlDbType.Int).Value = cboDepartemen.SelectedValue
                .Parameters.Add("@BagianID", SqlDbType.Int).Value = DBNull.Value
                .Parameters.Add("@JabatanID", SqlDbType.Int).Value = cboJabatan.SelectedValue
                .Parameters.Add("@Sex", SqlDbType.VarChar, 5).Value = cboJenisKelamin.SelectedValue
                If dtTanggalMasuk.Checked = True Then
                    .Parameters.Add("@TglMasuk", SqlDbType.Date).Value = Format(dtTanggalMasuk.Value, "yyyy-MM-dd")
                Else
                    .Parameters.Add("@TglMasuk", SqlDbType.Date).Value = DBNull.Value
                End If
                If dtTanggalKeluar.Checked = True Then
                    .Parameters.Add("@TglKeluar", SqlDbType.Date).Value = Format(dtTanggalKeluar.Value, "yyyy-MM-dd")
                Else
                    .Parameters.Add("@TglKeluar", SqlDbType.Date).Value = DBNull.Value
                End If
                .Parameters.Add("@StatusJamKerjaID", SqlDbType.VarChar, 5).Value = cboStatusJamKerja.SelectedValue
                .Parameters.Add("@IDLiburMingguan", SqlDbType.Int).Value = cboLiburMinggaun.SelectedValue
                .Parameters.Add("@JamKerjaPanjang", SqlDbType.Int).Value = Trim(txtJamKerjaPanjang.Text)
                .Parameters.Add("@JamKerjaPendek", SqlDbType.Int).Value = Trim(txtJamKerjaPendek.Text)
                If cboStatus.SelectedValue = 1 Then
                    .Parameters.Add("@StatusTk", SqlDbType.VarChar, 50).Value = "KARYAWAN"
                Else
                    .Parameters.Add("@StatusTk", SqlDbType.VarChar, 50).Value = "HARIAN"
                End If
                .Parameters.Add("@UserLogin", SqlDbType.VarChar, 50).Value = UserLogin
                .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
                .ExecuteNonQuery()
                Simpan = True
                If CInt(cmd.Parameters("@Flag").Value) <> 0 Then
                    cmd.Dispose()
                    Exit Function
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
        cmd.Dispose()
        Return Simpan
    End Function
    Private Function GetCek() As Boolean
        Dim sql As String = ""
        Dim i As Integer = 1
        Dim ret As Boolean = False
        If cboStatus.SelectedValue = 1 Then
            sql = "SELECT * FROM tblMstTenagaKerjaKaryawan where RegNo='" & txtRegNo.Text & "' "
        Else
            sql = "SELECT * FROM tblMstTenagaKerjaHarian where RegNo='" & txtRegNo.Text & "' "
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
    Private Function GetCekNik() As Boolean
        Dim sql As String = ""
        Dim i As Integer = 1
        Dim ret As Boolean = False

        If cboStatus.SelectedValue = 1 Then
            sql = "SELECT * FROM tblMstTenagaKerjaKaryawan where Nik='" & Trim(txtNik.Text) & "' "
        Else
            sql = "SELECT * FROM tblMstTenagaKerjaHarian where Nik='" & (txtNik.Text) & "' "
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
    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "SELECT StatusTK,RegNo,NAMA,NIK,GroupID,DeptID,Departemen,ShortName,bagianID,JabatanID,Jabatan,JabatanName ,TGLMASUK,STS,AGAMA,Sex,Jk, " &
                " TGLKELUAR,StatusJamKerjaID,LiburMingguan,NamaHari,JamKerjaPanjang,JamKerjaPendek " &
                " FROM STISidikjari.dbo.vwMstKaryawan "
        If chkAktif.Checked = True Then
            sql = sql & " where TGLKELUAR is not null "
        Else
            sql = sql & " where TGLKELUAR is null "
        End If
        If Trim(txtNikNama.Text) <> "" Then
            sql = sql & " and (NIK='" & Trim(txtNikNama.Text) & "' or NAMA like '%" & Trim(txtNikNama.Text) & "%') "
        End If
        sql = sql & " Order By Departemen,JabatanName,StatusTK  "
        Me.Cursor = Cursors.WaitCursor
        fg.Rows.Count = 1
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    With fg
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            If IsDBNull(DR!RegNo) = False Then .Item(i, "RegNo") = DR!RegNo
                            If IsDBNull(DR!NIK) = False Then .Item(i, "Nik") = DR!NIK
                            If IsDBNull(DR!NAMA) = False Then .Item(i, "Nama") = DR!NAMA
                            If IsDBNull(DR!JabatanName) = False Then .Item(i, "Jabatan") = DR!JabatanName
                            If IsDBNull(DR!JabatanID) = False Then .Item(i, "JabatanID") = DR!JabatanID
                            If IsDBNull(DR!Departemen) = False Then .Item(i, "Departemen") = DR!Departemen
                            If IsDBNull(DR!DeptID) = False Then .Item(i, "DeptID") = DR!DeptID
                            If IsDBNull(DR!bagianID) = False Then .Item(i, "BagianID") = DR!bagianID
                            If IsDBNull(DR!TGLMASUK) = False Then .Item(i, "TglMasuk") = DR!TGLMASUK
                            If IsDBNull(DR!TGLKELUAR) = False Then .Item(i, "TglKeluar") = DR!TGLKELUAR

                            If IsDBNull(DR!Jk) = False Then .Item(i, "JenisKelamin") = DR!Jk
                            If IsDBNull(DR!StatusJamKerjaID) = False Then .Item(i, "StatusJamKerja") = DR!StatusJamKerjaID
                            If IsDBNull(DR!NamaHari) = False Then .Item(i, "LiburMingguan") = DR!NamaHari
                            If IsDBNull(DR!JamKerjaPanjang) = False Then .Item(i, "JamKerjaPajang") = DR!JamKerjaPanjang
                            If IsDBNull(DR!JamKerjaPendek) = False Then .Item(i, "JamKerjaPendek") = DR!JamKerjaPendek
                            If IsDBNull(DR!StatusTK) = False Then .Item(i, "StatusTK") = DR!StatusTK
                            i = i + 1
                        End While
                    End With
                Else
                    fg.Rows.Count = 1
                    fg.Rows.Count = 2
                    MsgBox("Data Tidak Ditemukan!", MsgBoxStyle.Information)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End Using
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboDepartemen_TextUpdate(sender As Object, e As EventArgs) Handles cboDepartemen.TextUpdate
        ValidCombo(cboDepartemen)
    End Sub

    Private Sub cboBagian_TextUpdate(sender As Object, e As EventArgs) Handles cboBagian.TextUpdate
        ValidCombo(cboBagian)
    End Sub

    Private Sub cboJabatan_TextUpdate(sender As Object, e As EventArgs) Handles cboJabatan.TextUpdate
        ValidCombo(cboJabatan)
    End Sub

    Private Sub cboJenisKelamin_TextUpdate(sender As Object, e As EventArgs) Handles cboJenisKelamin.TextUpdate
        ValidCombo(cboJenisKelamin)
    End Sub

    Private Sub cboStatusJamKerja_TextUpdate(sender As Object, e As EventArgs) Handles cboStatusJamKerja.TextUpdate
        ValidCombo(cboStatusJamKerja)
    End Sub

    Private Sub cboLiburMinggaun_TextUpdate(sender As Object, e As EventArgs) Handles cboLiburMinggaun.TextUpdate
        ValidCombo(cboLiburMinggaun)
    End Sub

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        Call GetData()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        With fg
            If Convert.ToDouble(.Item(.Row, "RegNo")) > 0 Then
                txtRegNo.Text = .Item(.Row, "regno")
                txtNik.Text = .Item(.Row, "Nik")
                txtNama.Text = .Item(.Row, "Nama")
                cboJabatan.Text = .Item(.Row, "Jabatan")
                cboDepartemen.Text = .Item(.Row, "Departemen")
                If IsNothing(.Item(.Row, "TglMasuk")) = False Then
                    dtTanggalMasuk.Checked = True
                    dtTanggalMasuk.Text = .Item(.Row, "TglMasuk")
                Else
                    dtTanggalMasuk.Checked = False
                End If
                If IsNothing(.Item(.Row, "TglKeluar")) = False Then
                    dtTanggalKeluar.Checked = True
                    dtTanggalKeluar.Value = .Item(.Row, "TglKeluar")
                Else
                    dtTanggalKeluar.Checked = False
                End If
                cboJenisKelamin.Text = .Item(.Row, "JenisKelamin")
                cboStatusJamKerja.Text = .Item(.Row, "StatusJamKerja")
                cboLiburMinggaun.Text = .Item(.Row, "LiburMingguan")
                txtJamKerjaPanjang.Text = .Item(.Row, "JamKerjaPajang")
                txtJamKerjaPendek.Text = .Item(.Row, "JamKerjaPendek")
                cboStatus.Text = .Item(.Row, "StatusTK")

            Else
                Call CleareTxt()
            End If
        End With
    End Sub

End Class