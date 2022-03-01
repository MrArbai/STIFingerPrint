Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmUtlUserLogin
    Dim perintah As String = ""
    Private Sub frmSettingUserLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        Call EnableBtn(False)
        Call EnableTxt(False)
        Call GetStatusLogin(cboStatus)
        Call GetDataSudahDisimpan()
        Call GetGroupAkses(cboGroupAkses)
        txtNik.Enabled = False
        cboStatus.Enabled = False
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
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "ID" : .Cols(1).Name = "ID" : .Cols(1).Width = 40 : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "RegNo" : .Cols(2).Name = "RegNo" : .Cols(2).Width = 40 : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "User Name" : .Cols(3).Name = "UserName" : .Cols(3).Width = 110
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Nama" : .Cols(4).Name = "Nama" : .Cols(4).Width = 200
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Password" : .Cols(5).Name = "Password" : .Cols(5).Width = 40 : .Cols(5).Visible = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Group Akses" : .Cols(6).Name = "GroupAkses" : .Cols(6).Width = 130
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "StatusID" : .Cols(7).Name = "StatusID" : .Cols(7).Width = 130 : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Status" : .Cols(8).Name = "Status" : .Cols(8).Width = 130
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Nik" : .Cols(9).Name = "Nik" : .Cols(9).Width = 100 : .Cols(9).Visible = False
        End With
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction

        If Trim(cboStatus.Text) = "" Then
            MsgBox("Status Tidak Boleh Kosong!", vbCritical)
            Exit Sub
        End If
        If Trim(txtUserID.Text) = "" Then
            MsgBox("User Name Tidak Boleh Kosong!", vbCritical)
            Exit Sub
        End If
        If Trim(txtNamaLengkap.Text) = "" Then
            MsgBox("Nama Tidak Boleh Kosong!", vbCritical)
            Exit Sub
        End If
        If Trim(txtPassword.Text) = "" Then
            MsgBox("Password Tidak Boleh Kosong!", vbCritical)
            Exit Sub
        End If
        If Trim(cboGroupAkses.Text) = "" Then
            MsgBox("Group Akses Tidak Boleh Kosong!", vbCritical)
            Exit Sub
        End If
        If perintah = "ADD" Then
            If CekUser() = True Then
                MsgBox("User Name : " & txtUserID.Text & " Sudah Ada!", vbCritical)
                Exit Sub
            End If
        End If
        Me.Cursor = Cursors.WaitCursor
        If Simpan(Koneksi, Transaksi) = False Then
            MsgBox("Simpan Data Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
            Me.Cursor = Cursors.Default
            Transaksi.Rollback()
            Exit Sub
        End If
        Transaksi.Commit()
        Me.Cursor = Cursors.Default
        MsgBox("User Login Berhasil Dibuat", vbInformation)
        Call EnableBtn(False)
        cboStatus.Enabled = False
        Call CleareTxt()
        Call GetDataSudahDisimpan()
        Call EnableTxt(False)
        txtNamaLengkap.Enabled = False
        perintah = "SAVE"
        Exit Sub
    End Sub

    Private Sub EnableBtn(ByVal flag As Boolean)
        btnAdd.Enabled = Not flag
        btnEdit.Enabled = Not flag
        btnSave.Enabled = flag
        btnDelete.Enabled = flag
        btnCancel.Enabled = flag
        txtUserID.Focus()
    End Sub
    Private Sub EnableTxt(ByVal flag As Boolean)
        If cboStatus.SelectedValue = 1 Then
            txtNik.Enabled = flag
            txtUserID.Enabled = flag
            txtNamaLengkap.Enabled = Not flag
            txtPassword.Enabled = flag
            cboGroupAkses.Enabled = flag
        Else
            txtNik.Enabled = Not flag
            txtUserID.Enabled = flag
            txtNamaLengkap.Enabled = flag
            txtPassword.Enabled = flag
            cboGroupAkses.Enabled = flag
        End If
    End Sub

    Private Sub CleareTxt()
        txtRegNo.Text = ""
        cboStatus.ResetText()
        txtNik.Text = ""
        txtUserID.Text = ""
        txtID.Text = ""
        txtNamaLengkap.Text = ""
        txtPassword.Text = ""
        cboGroupAkses.ResetText()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call EnableBtn(True)
        Call CleareTxt()
        perintah = "ADD"
        cboStatus.Enabled = True
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Trim(txtID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Diedit!", vbCritical)
            Exit Sub
        End If
        Call EnableBtn(True)
        perintah = "EDIT"
        If cboStatus.SelectedValue = 1 Then
            txtNik.Enabled = True
            txtUserID.Enabled = True
            txtPassword.Enabled = True
            cboGroupAkses.Enabled = True
        Else
            txtNik.Enabled = False
            txtUserID.Enabled = True
            txtNamaLengkap.Enabled = True
            txtPassword.Enabled = True
            cboGroupAkses.Enabled = True
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Anda Ingin Menghapus User : " & txtNamaLengkap.Text & " Ini?", "Delete", MessageBoxButtons.YesNo) = vbYes Then
            Call Hapus()
            Call EnableBtn(False)
            perintah = "DELETE"
            Call GetDataSudahDisimpan()
            Call CleareTxt()
            cboStatus.Enabled = False
            txtNik.Enabled = False
            txtUserID.Enabled = False
            txtNamaLengkap.Enabled = False
            txtPassword.Enabled = False
            cboGroupAkses.Enabled = False
        End If
    End Sub
    Private Sub Hapus()
        Try
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn
                .CommandType = CommandType.Text
                .CommandText = "Delete tblUtlUserLogin WHERE ID='" & txtID.Text & "' "
                .ExecuteNonQuery()
            End With
            MsgBox("Password Anda Berhasil Diubah", vbInformation, "Success")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call CleareTxt()
        Call EnableBtn(False)
        cboStatus.Enabled = False
        txtNik.Enabled = False
        txtUserID.Enabled = False
        txtNamaLengkap.Enabled = False
        txtPassword.Enabled = False
        cboGroupAkses.Enabled = False
        perintah = "CANCEL"
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function Simpan(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        Simpan = False
        Dim mycon As SqlConnection = conn
        Dim mycontrans As SqlTransaction = trans
        Dim Pswd As String
        Pswd = EncryptText(txtPassword.Text, txtUserID.Text)

        Try
            With cmd
                .Connection = conn
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spUtlUserLoginSave"
                .Transaction = mycontrans
                .Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.BigInt, 3, ParameterDirection.ReturnValue, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .Parameters.Add("@ID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(txtID.Text)
                If Trim(txtRegNo.Text) = "" Then
                    .Parameters.Add("@RegNo", SqlDbType.VarChar, 50).Value = DBNull.Value
                Else
                    .Parameters.Add("@RegNo", SqlDbType.VarChar, 50).Value = Val(Trim(txtRegNo.Text))
                End If
                .Parameters.Add("@UserID", SqlDbType.VarChar, 50).Value = UCase(Trim(txtUserID.Text))
                .Parameters.Add("@Nama", SqlDbType.VarChar, 50).Value = UCase(Trim(txtNamaLengkap.Text))
                .Parameters.Add("@Password", SqlDbType.VarChar, 5000).Value = Pswd
                .Parameters.Add("@GroupID", SqlDbType.Int).Value = cboGroupAkses.SelectedValue
                .Parameters.Add("@Status", SqlDbType.Int).Value = cboStatus.SelectedValue
                .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
                .ExecuteNonQuery()
            End With
            If Val(cmd.Parameters("@ID").Value) > 0 Then txtID.Text = Val(cmd.Parameters("@ID").Value)
            If CInt(cmd.Parameters("@Flag").Value) <> 0 Then
                cmd.Dispose()
                Exit Function
            End If
            cmd.Dispose()
            Simpan = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return Simpan
    End Function

    Private Sub GetDataSudahDisimpan()
        Dim sql As String = ""
        Dim i As Integer = 1

        sql = "SELECT ID,a.RegNo,UserID,d.nik,a.Nama,Password,a.GroupID,b.GroupName,a.StatusID,c.Status FROM tblUtlUserLogin a left join tblUtlGroupHeader b on a.GroupID=b.GroupID  " &
                " join tblUtlStatus c on a.StatusID=C.StatusID Left Join vwMstKaryawan d on a.RegNo=d.RegNo and a.StatusID=case when d.StatusTK='KARYAWAN' THEN 1 ELSE 2 END "

        If Trim(txtCari.Text) <> "" Then
            sql = sql & " where UserID like '%" & Trim(txtCari.Text) & "%' Or d.Nik='" & Trim(txtCari.Text) & "' "
        End If
        Me.Cursor = Cursors.WaitCursor
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            fg.Rows.Count = 1
            fg.Rows.Count = 2
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    While DR.Read
                        With fg
                            .AddItem("")
                            .Item(i, "no") = i
                            If IsDBNull(DR!ID) = False Then .Item(i, "ID") = DR!ID
                            If IsDBNull(DR!RegNo) = False Then .Item(i, "RegNo") = DR!RegNo
                            If IsDBNull(DR!UserID) = False Then .Item(i, "UserName") = DR!UserID
                            If IsDBNull(DR!Nama) = False Then .Item(i, "Nama") = DR!Nama
                            If IsDBNull(DR!Password) = False Then .Item(i, "Password") = DR!Password
                            If IsDBNull(DR!GroupName) = False Then .Item(i, "GroupAkses") = DR!GroupName
                            If IsDBNull(DR!StatusID) = False Then .Item(i, "StatusID") = DR!StatusID
                            If IsDBNull(DR!Status) = False Then .Item(i, "Status") = DR!Status
                            If IsDBNull(DR!nik) = False Then .Item(i, "nik") = DR!nik
                            i = i + 1
                        End With
                    End While
                Else
                    If perintah <> "" Then
                        MsgBox("Data Tidak Ditemukan!")
                    End If
                    Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
            End Using
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "SELECT RegNo,NAMA,NIK,GroupID,DeptID,Departemen,TGLMASUK,STS,AGAMA,Sex,TGLKELUAR FROM STISidikjari.dbo.vwMstKaryawan"
        sql = sql & " where NIK='" & Trim(txtNik.Text) & "' Order By NAMA,TGLMASUK "
        Me.Cursor = Cursors.WaitCursor
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    While DR.Read
                        txtRegNo.Text = DR!RegNo
                        txtNamaLengkap.Text = DR!NAMA
                        lblInfo.Visible = False
                    End While
                Else
                    lblInfo.Visible = True
                    txtRegNo.Text = ""
                    txtUserID.Text = ""
                    txtNamaLengkap.Text = ""
                    txtPassword.Text = ""
                    cboGroupAkses.ResetText()
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End Using
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Function CekUser() As Boolean
        Dim cek As Boolean = False
        Dim sql As String
        sql = "SELECT * from tblUtlUserLogin where UserID='" & Trim(txtUserID.Text) & "' "
        Using koneksi As New SqlCommand(Sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    cek = True
                End If
            End Using
        End Using
        Return cek
    End Function

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        With fg
            If Convert.ToDouble(.Item(.Row, "ID")) > 0 Then
                txtNik.Text = .Item(.Row, "Nik")
                txtRegNo.Text = .Item(.Row, "RegNo")
                txtID.Text = .Item(.Row, "ID")
                txtUserID.Text = .Item(.Row, "UserName")
                txtNamaLengkap.Text = .Item(.Row, "Nama")
                txtPassword.Text = DecryptText(.Item(.Row, "Password"), .Item(.Row, "UserName"))
                cboGroupAkses.Text = .Item(.Row, "GroupAkses")
                cboStatus.Text = .Item(.Row, "Status")
            Else
                Call CleareTxt()
            End If
        End With
    End Sub

    Private Sub fg_MouseHover(sender As Object, e As EventArgs) Handles fg.MouseHover
        Try
            If fg.MouseRow > 0 Then
                Dim tip As String = "Double Clik Disini Untuk Edit Data!"
                ToolTip1.SetToolTip(fg, tip)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        Call GetDataSudahDisimpan()
    End Sub

    Private Sub cboGroupAkses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGroupAkses.SelectedIndexChanged

    End Sub

    Private Sub cboGroupAkses_TextUpdate(sender As Object, e As EventArgs) Handles cboGroupAkses.TextUpdate
        ValidCombo(cboGroupAkses)
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged

    End Sub

    Private Sub cboStatus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboStatus.SelectionChangeCommitted
        EnableTxt(True)
        txtNik.Text = ""
        txtUserID.Text = ""
        txtNamaLengkap.Text = ""
        txtPassword.Text = ""
        cboGroupAkses.ResetText()
    End Sub

    Private Sub cboStatus_TextUpdate(sender As Object, e As EventArgs) Handles cboStatus.TextUpdate
        ValidCombo(cboStatus)
    End Sub

    Private Sub txtNik_TextChanged(sender As Object, e As EventArgs) Handles txtNik.TextChanged
        Try
            If Trim(txtNik.Text) <> "" Then
                Call GetData()
            Else
                lblInfo.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class