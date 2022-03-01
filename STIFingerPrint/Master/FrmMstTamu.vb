Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMstTamu : Inherits DockContent
    Private Sub FrmMstTamu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        Call EnableBtn(False)
        Call EnableTxt(False)
        Call GetJabatan(cboJabatan)
        Call GetDepartemen(cboDepartemen)
        Call GetData()
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
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Nik" : .Cols(1).Name = "Nik" : .Cols(1).Width = 80
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama" : .Cols(2).Name = "Nama" : .Cols(2).Width = 200
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Jabatan" : .Cols(3).Name = "Jabatan" : .Cols(3).Width = 150
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "JabatanID" : .Cols(4).Name = "JabatanID" : .Cols(4).Width = 150 : .Cols(4).Visible = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Departemen" : .Cols(5).Name = "Departemen" : .Cols(5).Width = 200
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "DeptID" : .Cols(6).Name = "DeptID" : .Cols(6).Width = 100 : .Cols(6).Visible = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "ID" : .Cols(7).Name = "ID" : .Cols(7).Width = 130 : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Status Aktif" : .Cols(8).Name = "StatusAktif" : .Cols(8).Width = 100 : .Cols(8).TextAlign = TextAlignEnum.CenterCenter
        End With
    End Sub
    Private Sub EnableBtn(ByVal flag As Boolean)
        btnAdd.Enabled = Not flag
        btnEdit.Enabled = Not flag
        btnSave.Enabled = flag
        btnDelete.Enabled = flag
        btnCancel.Enabled = flag
        Call EnableTxt(flag)
    End Sub

    Private Sub EnableTxt(ByVal flag As Boolean)
        txtNik.Enabled = flag
        txtNama.Enabled = flag
        cboDepartemen.Enabled = flag
        cboJabatan.Enabled = flag
        ckhAktif.Enabled = flag
    End Sub
    Private Sub CleareTxt()
        txtID.Clear()
        txtNik.Clear()
        txtNama.Clear()
        cboJabatan.ResetText()
        cboDepartemen.ResetText()
        ckhAktif.Checked = False
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call EnableBtn(True)
        Call CleareTxt()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Trim(txtID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Diedit!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Call EnableBtn(True)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtNik.Text) = "" Then
            MsgBox("Nik Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(txtNama.Text) = "" Then
            MsgBox("Nama Masih Kosong!", MsgBoxStyle.Critical)
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
        Call CleareTxt()
        Call GetData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Trim(txtID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Hapus!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MessageBox.Show("Anda Ingin Menghapus Nama : " & txtNama.Text & " Ini?", "Delete", MessageBoxButtons.YesNo) = vbYes Then
            Call HapusTamu()
            Call EnableBtn(False)
            Call CleareTxt()
            Call GetData()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call EnableBtn(False)
        Call CleareTxt()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cboJabatan_TextUpdate(sender As Object, e As EventArgs) Handles cboJabatan.TextUpdate
        ValidCombo(cboJabatan)
    End Sub

    Private Sub cboDepartemen_TextUpdate(sender As Object, e As EventArgs) Handles cboDepartemen.TextUpdate
        ValidCombo(cboDepartemen)
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
                .CommandText = "spMstTamuSave"
                .Transaction = MyConTrans
                .Parameters.Add("@id", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(txtID.Text)
                .Parameters.Add("@Nik", SqlDbType.VarChar, 50).Value = Trim(txtNik.Text)
                .Parameters.Add("@Nama", SqlDbType.VarChar, 100).Value = UCase(Trim(txtNama.Text))
                If Trim(cboDepartemen.Text) <> "" Then
                    .Parameters.Add("@IDDept", SqlDbType.Int).Value = cboDepartemen.SelectedValue
                Else
                    .Parameters.Add("@IDDept", SqlDbType.Int).Value = DBNull.Value
                End If
                If Trim(cboJabatan.Text) <> "" Then
                    .Parameters.Add("@JabatanID", SqlDbType.Int).Value = cboJabatan.SelectedValue
                Else
                    .Parameters.Add("@JabatanID", SqlDbType.Int).Value = DBNull.Value
                End If
                If ckhAktif.Checked = False Then
                    .Parameters.Add("@ActiveNonActive", SqlDbType.Int).Value = 0
                Else
                    .Parameters.Add("@ActiveNonActive", SqlDbType.Int).Value = 1
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

    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "SELECT ID,NIk,a.Nama,A.JabatanID,C.Jabatan,a.IDDept,b.Departemen,a.ActiveNonActive FROM tblMstTamu a left join vwMstDept b on a.IDDept=b.DeptID " &
               "left join vwMstJabatan c ON a.JabatanID=c.JabatanID Order By a.ActiveNonActive "

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
                            If IsDBNull(DR!Nik) = False Then .Item(i, "Nik") = DR!Nik
                            If IsDBNull(DR!Nama) = False Then .Item(i, "Nama") = DR!Nama
                            If IsDBNull(DR!Jabatan) = False Then .Item(i, "Jabatan") = DR!Jabatan
                            If IsDBNull(DR!JabatanID) = False Then .Item(i, "JabatanID") = DR!JabatanID
                            If IsDBNull(DR!Departemen) = False Then .Item(i, "Departemen") = DR!Departemen
                            If IsDBNull(DR!IDDept) = False Then .Item(i, "DeptID") = DR!IDDept
                            If IsDBNull(DR!ID) = False Then .Item(i, "ID") = DR!ID
                            If DR!ActiveNonActive = False Then
                                .Item(i, "StatusAktif") = "AKTIF"
                            Else
                                .Item(i, "StatusAktif") = "NON AKTIF"
                            End If
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

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        With fg
            If Convert.ToDouble(.Item(.Row, "ID")) > 0 Then
                txtID.Text = .Item(.Row, "ID")
                txtNik.Text = .Item(.Row, "Nik")
                txtNama.Text = .Item(.Row, "Nama")
                cboDepartemen.Text = .Item(.Row, "Departemen")
                cboJabatan.Text = .Item(.Row, "Jabatan")
                If Convert.ToString(.Item(.Row, "StatusAktif")) = "AKTIF" Then
                    ckhAktif.Checked = False
                Else
                    ckhAktif.Checked = True
                End If
            Else
                Call CleareTxt()
            End If
        End With
    End Sub
    Private Sub HapusTamu()
        Try
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn
                .CommandType = CommandType.Text
                .CommandText = "Delete tblMstTamu WHERE ID='" & txtID.Text & "' "
                .ExecuteNonQuery()
            End With
            MsgBox("Tamu Berhasil Hapus", vbInformation, "Success")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class