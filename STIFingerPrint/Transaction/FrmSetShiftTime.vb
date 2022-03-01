Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmSetShiftTime : Inherits DockContent
    Dim Perintah As String = ""
    Private Sub FrmSetShiftTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetDepartemen(cboDepartemen)
        Call GetDepartemen(cboDepartemenFilter)
        Call GetJabatan(cboJabatan)
        Call GetJabatan(cboJabatanFilter)
        Call SetGridDefult()
        Call EnableBtn(False)
        Call EnablelCleare()
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
            .Rows.Fixed = 2
            .Rows.Count = 3
            .Rows(0).Height = 30
            .Cols.Frozen = 3
            .Cols.Count = 26
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40 : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "ShiftID" : .Cols(1).Name = "ShiftID" : .Cols(1).Width = 100 : .Cols(1).AllowMerging = True : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "Departemen" : .Cols(2).Name = "Departemen" : .Cols(2).Width = 150 : .Cols(2).AllowMerging = True
            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "Jabatan" : .Cols(3).Name = "Jabatan" : .Cols(3).Width = 150 : .Cols(3).AllowMerging = True
            txt = .GetCellRange(0, 4, 0, 7) : txt.Data = "Shift 1" : .Cols(7).AllowMerging = True
            txt = .GetCellRange(1, 4, 1, 4) : txt.Data = "Masuk" : .Cols(4).Name = "MasukShift1" : .Cols(4).Width = 70 : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 5, 1, 5) : txt.Data = "Ist Out" : .Cols(5).Name = "IstOutShift1" : .Cols(5).Width = 70 : .Cols(5).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 6, 1, 6) : txt.Data = "Ist In" : .Cols(6).Name = "IstInShift1" : .Cols(6).Width = 70 : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 7, 1, 7) : txt.Data = "Pulang" : .Cols(7).Name = "PulangShift1" : .Cols(7).Width = 70 : .Cols(7).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 11) : txt.Data = "Shift 2" : .Cols(11).AllowMerging = True
            txt = .GetCellRange(1, 8, 1, 8) : txt.Data = "Masuk" : .Cols(8).Name = "MasukShift2" : .Cols(8).Width = 70 : .Cols(8).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 9, 1, 9) : txt.Data = "Ist Out" : .Cols(9).Name = "IstOutShift2" : .Cols(9).Width = 70 : .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 10, 1, 10) : txt.Data = "Ist In" : .Cols(10).Name = "IstInShift2" : .Cols(10).Width = 70 : .Cols(10).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 11, 1, 11) : txt.Data = "Pulang" : .Cols(11).Name = "PulangShift2" : .Cols(11).Width = 70 : .Cols(11).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 12, 0, 15) : txt.Data = "Shift 3" : .Cols(15).AllowMerging = True
            txt = .GetCellRange(1, 12, 1, 12) : txt.Data = "Masuk" : .Cols(12).Name = "MasukShift3" : .Cols(12).Width = 70 : .Cols(12).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 13, 1, 13) : txt.Data = "Ist Out" : .Cols(13).Name = "IstOutShift3" : .Cols(13).Width = 70 : .Cols(13).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 14, 1, 14) : txt.Data = "Ist In" : .Cols(14).Name = "IstInShift3" : .Cols(14).Width = 70 : .Cols(14).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 15, 1, 15) : txt.Data = "Pulang" : .Cols(15).Name = "PulangShift3" : .Cols(15).Width = 70 : .Cols(15).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 16, 1, 16) : txt.Data = "TipeShift" : .Cols(16).Name = "TipeShift" : .Cols(16).Width = 70 : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).Visible = False

            txt = .GetCellRange(1, 17, 1, 17) : txt.Data = "NewDeptID" : .Cols(17).Name = "NewDeptID" : .Cols(17).Width = 70 : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).Visible = False
            txt = .GetCellRange(1, 18, 1, 18) : txt.Data = "StatusTK" : .Cols(18).Name = "StatusTK" : .Cols(18).Width = 70 : .Cols(18).TextAlign = TextAlignEnum.CenterCenter : .Cols(18).Visible = False
            txt = .GetCellRange(1, 19, 1, 19) : txt.Data = "JabatanID" : .Cols(19).Name = "JabatanID" : .Cols(19).Width = 70 : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).Visible = False

            txt = .GetCellRange(1, 20, 1, 20) : txt.Data = "Ist Normal 1" : .Cols(20).Name = "IstNormal1" : .Cols(20).Width = 70 : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).Visible = False
            txt = .GetCellRange(1, 21, 1, 21) : txt.Data = "Ist Jumat 1" : .Cols(21).Name = "IstJumat1" : .Cols(21).Width = 70 : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).Visible = False
            txt = .GetCellRange(1, 22, 1, 22) : txt.Data = "Ist Normal 2" : .Cols(22).Name = "IstNormal2" : .Cols(22).Width = 70 : .Cols(22).TextAlign = TextAlignEnum.CenterCenter : .Cols(22).Visible = False
            txt = .GetCellRange(1, 23, 1, 23) : txt.Data = "Ist Jumat 2" : .Cols(23).Name = "IstJumat2" : .Cols(23).Width = 70 : .Cols(23).TextAlign = TextAlignEnum.CenterCenter : .Cols(23).Visible = False
            txt = .GetCellRange(1, 24, 1, 24) : txt.Data = "Ist Normal 3" : .Cols(24).Name = "IstNormal3" : .Cols(24).Width = 70 : .Cols(24).TextAlign = TextAlignEnum.CenterCenter : .Cols(24).Visible = False
            txt = .GetCellRange(1, 25, 1, 25) : txt.Data = "Ist Jumat 3" : .Cols(25).Name = "IstJumat3" : .Cols(25).Width = 70 : .Cols(25).TextAlign = TextAlignEnum.CenterCenter : .Cols(25).Visible = False
        End With
    End Sub
    Private Sub EnableBtn(ByVal flag As Boolean)
        btnAdd.Enabled = Not flag
        btnEdit.Enabled = Not flag
        btnSave.Enabled = flag
        btnCancel.Enabled = flag
        Call EnablelTxt(flag)
    End Sub
    Private Sub EnablelTxt(ByVal flag As Boolean)
        cboDepartemen.Enabled = flag
        cboJabatan.Enabled = flag
        txtIstJumatShift1.Enabled = flag
        txtIstJumatShift2.Enabled = flag
        txtIstJumatShift3.Enabled = flag
        txtIstNormalMenitShift1.Enabled = flag
        txtIstNormalMenitShift2.Enabled = flag
        txtIstNormalMenitShift3.Enabled = flag
        txtJamIstInShift1.Enabled = flag
        txtJamIstInShift2.Enabled = flag
        txtJamIstInShift3.Enabled = flag
        txtJamIstOutShift1.Enabled = flag
        txtJamIstOutShift2.Enabled = flag
        txtJamIstOutShift3.Enabled = flag
        txtJamMasukShit1.Enabled = flag
        txtJamMasukShit2.Enabled = flag
        txtJamMasukShit3.Enabled = flag
        txtJamPulangShift1.Enabled = flag
        txtJamPulangShift2.Enabled = flag
        txtJamPulangShift3.Enabled = flag
    End Sub
    Private Sub EnablelCleare()
        cboDepartemen.ResetText()
        cboJabatan.ResetText()
        txtIstJumatShift1.Clear()
        txtIstJumatShift2.Clear()
        txtIstJumatShift3.Clear()
        txtIstNormalMenitShift1.Clear()
        txtIstNormalMenitShift2.Clear()
        txtIstNormalMenitShift3.Clear()
        txtJamIstInShift1.Clear()
        txtJamIstInShift2.Clear()
        txtJamIstInShift3.Clear()
        txtJamIstOutShift1.Clear()
        txtJamIstOutShift2.Clear()
        txtJamIstOutShift3.Clear()
        txtJamMasukShit1.Clear()
        txtJamMasukShit2.Clear()
        txtJamMasukShit3.Clear()
        txtJamPulangShift1.Clear()
        txtJamPulangShift2.Clear()
        txtJamPulangShift3.Clear()
        txtTipeShift.Clear()
        txtShiftID.Clear()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call EnableBtn(True)
        Call EnablelCleare()
        Perintah = "ADD"
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Trim(txtShiftID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Diedit!", MessageBoxIcon.Stop, "Stop")
            Exit Sub
        End If
        Call EnableBtn(True)
        Perintah = "EDIT"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction

        If Trim(cboDepartemen.Text) = "" Then
            MsgBox("Departemen Belum Dipilih!", MessageBoxIcon.Warning, "Warning")
            Exit Sub
        End If
        If Trim(cboJabatan.Text) = "" Then
            MsgBox("Jabatan Belum Dipilih!", MessageBoxIcon.Warning, "Warning")
            Exit Sub
        End If
        If txtJamMasukShit1.Text = "  :" Then
            MsgBox("Jam Masuk Shift 1 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamIstOutShift1.Text = "  :" Then
            MsgBox("Jam Ist Out Shift 1 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamIstInShift1.Text = "  :" Then
            MsgBox("Jam Ist In Shift 1 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamPulangShift1.Text = "  :" Then
            MsgBox("Jam Pulang Shift 1 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtIstNormalMenitShift1.Text = "  :" Then
            MsgBox("Ist Normal Shift 1 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtIstJumatShift1.Text = "  :" Then
            MsgBox("Ist Jumat Shift 1 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If

        If txtJamMasukShit2.Text = "  :" Then
            MsgBox("Jam Masuk Shift 2 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamIstOutShift2.Text = "  :" Then
            MsgBox("Jam Ist Out Shift 2 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamIstInShift2.Text = "  :" Then
            MsgBox("Jam Ist In Shift 2 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamPulangShift2.Text = "  :" Then
            MsgBox("Jam Pulang Shift 2 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtIstNormalMenitShift2.Text = "  :" Then
            MsgBox("Ist Normal Shift 2 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtIstJumatShift2.Text = "  :" Then
            MsgBox("Ist Jumat Shift 2 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If

        If txtJamMasukShit3.Text = "  :" Then
            MsgBox("Jam Masuk Shift 3 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamIstOutShift3.Text = "  :" Then
            MsgBox("Jam Ist Out Shift 3 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamIstInShift3.Text = "  :" Then
            MsgBox("Jam Ist In Shift 3 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamPulangShift3.Text = "  :" Then
            MsgBox("Jam Pulang Shift 3 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtIstNormalMenitShift3.Text = "  :" Then
            MsgBox("Ist Normal Shift 3 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtIstJumatShift3.Text = "  :" Then
            MsgBox("Ist Jumat Shift 3 Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        If Simpan(Koneksi, Transaksi) = False Then
            MsgBox("Simpan Data Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
            Me.Cursor = Cursors.Default
            Transaksi.Rollback()
            Exit Sub
        End If
        Transaksi.Commit()
        Call GetData()
        Me.Cursor = Cursors.Default
        MsgBox("User Login Berhasil Dibuat", vbInformation)
        Call EnableBtn(False)
        Call EnablelCleare()
        Perintah = "SAVE"
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call EnableBtn(False)
        Call EnablelCleare()
        Perintah = "CANCEL"
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Function Simpan(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim ret As Boolean = False
        Try
            With cmd
                .Connection = Conn
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spMstShiftDeptSave"
                .Transaction = MyConTrans
                .Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.BigInt, 3, ParameterDirection.ReturnValue, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .Parameters.Add("@ShiftID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(txtShiftID.Text)
                .Parameters.Add("@Perintah", SqlDbType.VarChar, 20).Value = Perintah
                .Parameters.Add("@NewDeptID", SqlDbType.BigInt).Value = cboDepartemen.SelectedValue
                .Parameters.Add("@JabatanID", SqlDbType.BigInt).Value = cboJabatan.SelectedValue
                .Parameters.Add("@StatusTK", SqlDbType.BigInt).Value = 1
                If Trim(txtTipeShift.Text) = "" Then
                    .Parameters.Add("@TipeShift", SqlDbType.Int).Value = DBNull.Value
                Else
                    .Parameters.Add("@TipeShift", SqlDbType.Int).Value = Val(txtTipeShift.Text)
                End If

                .Parameters.Add("@Shift1", SqlDbType.VarChar, 15).Value = txtJamMasukShit1.Text & " " & txtJamPulangShift1.Text
                .Parameters.Add("@Shift1_Masuk", SqlDbType.VarChar, 5).Value = txtJamMasukShit1.Text
                .Parameters.Add("@Shift1_Pulang", SqlDbType.VarChar, 5).Value = txtJamPulangShift1.Text

                .Parameters.Add("@Shift1_Istirahat", SqlDbType.Int).Value = Val(txtIstNormalMenitShift1.Text)
                .Parameters.Add("@Shift1_IstirahatPendek", SqlDbType.Int).Value = Val(txtIstJumatShift1.Text)

                .Parameters.Add("@Shift2", SqlDbType.VarChar, 15).Value = txtJamMasukShit2.Text & " " & txtJamPulangShift2.Text
                .Parameters.Add("@Shift2_Masuk", SqlDbType.VarChar, 5).Value = txtJamMasukShit2.Text
                .Parameters.Add("@Shift2_Pulang", SqlDbType.VarChar, 5).Value = txtJamPulangShift2.Text
                .Parameters.Add("@Shift2_Istirahat", SqlDbType.Int).Value = Val(txtIstNormalMenitShift2.Text)
                .Parameters.Add("@Shift2_IstirahatPendek", SqlDbType.Int).Value = Val(txtIstJumatShift2.Text)

                .Parameters.Add("@Shift3", SqlDbType.VarChar, 15).Value = txtJamMasukShit3.Text & " " & txtJamPulangShift3.Text
                .Parameters.Add("@Shift3_Masuk", SqlDbType.VarChar, 5).Value = txtJamMasukShit3.Text
                .Parameters.Add("@Shift3_Pulang", SqlDbType.VarChar, 5).Value = txtJamPulangShift3.Text
                .Parameters.Add("@Shift3_Istirahat", SqlDbType.Int).Value = Val(txtIstNormalMenitShift3.Text)
                .Parameters.Add("@Shift3_IstirahatPendek", SqlDbType.Int).Value = Val(txtIstJumatShift3.Text)

                .Parameters.Add("@Shift1_IstOut", SqlDbType.VarChar, 5).Value = txtJamIstOutShift1.Text
                .Parameters.Add("@Shift1_IstIn", SqlDbType.VarChar, 5).Value = txtJamIstInShift1.Text
                .Parameters.Add("@Shift2_IstOut", SqlDbType.VarChar, 5).Value = txtJamIstOutShift2.Text
                .Parameters.Add("@Shift2_IstIn", SqlDbType.VarChar, 5).Value = txtJamIstInShift2.Text
                .Parameters.Add("@Shift3_IstOut", SqlDbType.VarChar, 5).Value = txtJamIstOutShift3.Text
                .Parameters.Add("@Shift3_IstIn", SqlDbType.VarChar, 5).Value = txtJamIstInShift3.Text

                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = UserLogin
                .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
                .ExecuteNonQuery()
                ret = True
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
        cmd.Dispose()
        Return ret
    End Function

    Private Sub cboDepartemen_TextUpdate(sender As Object, e As EventArgs) Handles cboDepartemen.TextUpdate
        ValidCombo(cboDepartemen)
    End Sub
    Private Sub cboJabatan_TextUpdate(sender As Object, e As EventArgs) Handles cboJabatan.TextUpdate
        ValidCombo(cboJabatan)
    End Sub
    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 2
        sql = "select a.ShiftID,a.NewDeptID,a.StatusTK,a.JabatanID,a.TipeShift,a.Shift1,a.Shift1_Masuk,a.Shift1_Pulang,a.Shift1_Istirahat,a.Shift1_IstirahatPendek " &
            ",a.Shift2,a.Shift2_Masuk,a.Shift2_Pulang,a.Shift2_Istirahat,a.Shift2_IstirahatPendek,a.Shift3,a.Shift3_Masuk,a.Shift3_Pulang,a.Shift3_Istirahat " &
            ",a.Shift3_IstirahatPendek,a.CreatedBy,a.CreatedDate,a.UpdatedBy,a.UpdatedDate,a.Computer,a.ComputerDate,a.NotActive,a.shift1_istout,a.shift1_istin,a.shift2_istout " &
            ",a.shift2_istin,a.shift3_istout,a.shift3_istin,b.Jabatan,c.Departemen from tblMstShift a left join  vwMstJabatan b on a.JabatanID=b.JabatanID " &
            "join vwMstDept c on a.NewDeptID=c.DeptID "
        If Trim(cboDepartemenFilter.Text) <> "" And Trim(cboJabatanFilter.Text) = "" Then
            sql = sql & " Where a.NewDeptID=" & cboDepartemenFilter.SelectedValue & " "
        End If
        If Trim(cboDepartemenFilter.Text) <> "" And Trim(cboJabatanFilter.Text) <> "" Then
            sql = sql & " Where a.NewDeptID=" & cboDepartemenFilter.SelectedValue & " and a.JabatanID=" & cboJabatanFilter.SelectedValue & " "
        End If
        If Trim(cboDepartemenFilter.Text) = "" And Trim(cboJabatanFilter.Text) <> "" Then
            sql = sql & " Where  a.JabatanID=" & cboJabatanFilter.SelectedValue & " "
        End If
        sql = sql & " Order By c.Departemen,b.Jabatan"
        Me.Cursor = Cursors.WaitCursor
        fg.Rows.Count = 2
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    With fg
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i - 1
                            .Item(i, "ShiftID") = DR!ShiftID
                            If IsDBNull(DR!Departemen) = False Then .Item(i, "Departemen") = DR!Departemen
                            If IsDBNull(DR!Jabatan) = False Then .Item(i, "Jabatan") = DR!Jabatan
                            If IsDBNull(DR!Shift1_Masuk) = False Then .Item(i, "MasukShift1") = DR!Shift1_Masuk
                            If IsDBNull(DR!shift1_istout) = False Then .Item(i, "IstOutShift1") = DR!shift1_istout
                            If IsDBNull(DR!shift1_istin) = False Then .Item(i, "IstInShift1") = DR!shift1_istin
                            If IsDBNull(DR!Shift1_Pulang) = False Then .Item(i, "PulangShift1") = DR!Shift1_Pulang

                            If IsDBNull(DR!Shift2_Masuk) = False Then .Item(i, "MasukShift2") = DR!Shift2_Masuk
                            If IsDBNull(DR!shift2_istout) = False Then .Item(i, "IstOutShift2") = DR!shift2_istout
                            If IsDBNull(DR!shift2_istin) = False Then .Item(i, "IstInShift2") = DR!shift2_istin
                            If IsDBNull(DR!Shift2_Pulang) = False Then .Item(i, "PulangShift2") = DR!Shift2_Pulang

                            If IsDBNull(DR!Shift3_Masuk) = False Then .Item(i, "MasukShift3") = DR!Shift3_Masuk
                            If IsDBNull(DR!shift3_istout) = False Then .Item(i, "IstOutShift3") = DR!shift3_istout
                            If IsDBNull(DR!shift3_istin) = False Then .Item(i, "IstInShift3") = DR!shift3_istin
                            If IsDBNull(DR!Shift3_Pulang) = False Then .Item(i, "PulangShift3") = DR!Shift3_Pulang

                            If IsDBNull(DR!TipeShift) = False Then .Item(i, "TipeShift") = DR!TipeShift
                            If IsDBNull(DR!NewDeptID) = False Then .Item(i, "NewDeptID") = DR!NewDeptID
                            If IsDBNull(DR!StatusTK) = False Then .Item(i, "StatusTK") = DR!StatusTK
                            If IsDBNull(DR!JabatanID) = False Then .Item(i, "JabatanID") = DR!JabatanID

                            If IsDBNull(DR!Shift1_Istirahat) = False Then .Item(i, "IstNormal1") = DR!Shift1_Istirahat
                            If IsDBNull(DR!Shift1_IstirahatPendek) = False Then .Item(i, "IstJumat1") = DR!Shift1_IstirahatPendek
                            If IsDBNull(DR!Shift2_Istirahat) = False Then .Item(i, "IstNormal2") = DR!Shift2_Istirahat
                            If IsDBNull(DR!Shift2_IstirahatPendek) = False Then .Item(i, "IstJumat2") = DR!Shift2_IstirahatPendek
                            If IsDBNull(DR!Shift3_Istirahat) = False Then .Item(i, "IstNormal3") = DR!Shift3_Istirahat
                            If IsDBNull(DR!Shift3_IstirahatPendek) = False Then .Item(i, "IstJumat3") = DR!Shift3_IstirahatPendek
                            i = i + 1
                        End While
                    End With
                Else
                    fg.Rows.Count = 2
                    fg.Rows.Count = 3
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
        Try
            With fg
                If Convert.ToInt32(.Item(.Row, "ShiftID")) > 0 Then
                    txtShiftID.Text = .Item(.Row, "ShiftID")
                    txtTipeShift.Text = .Item(.Row, "TipeShift")
                    cboDepartemen.Text = .Item(.Row, "Departemen")
                    cboJabatan.Text = .Item(.Row, "Jabatan")

                    txtJamMasukShit1.Text = .Item(.Row, "MasukShift1")
                    txtJamIstOutShift1.Text = .Item(.Row, "IstOutShift1")
                    txtJamIstInShift1.Text = .Item(.Row, "IstInShift1")
                    txtJamPulangShift1.Text = .Item(.Row, "PulangShift1")
                    txtIstNormalMenitShift1.Text = .Item(.Row, "IstNormal1")
                    txtIstJumatShift1.Text = .Item(.Row, "IstJumat1")

                    txtJamMasukShit2.Text = .Item(.Row, "MasukShift2")
                    txtJamIstOutShift2.Text = .Item(.Row, "IstOutShift2")
                    txtJamIstInShift2.Text = .Item(.Row, "IstInShift2")
                    txtJamPulangShift2.Text = .Item(.Row, "PulangShift2")
                    txtIstNormalMenitShift2.Text = .Item(.Row, "IstNormal2")
                    txtIstJumatShift2.Text = .Item(.Row, "IstJumat2")

                    txtJamMasukShit3.Text = .Item(.Row, "MasukShift3")
                    txtJamIstOutShift3.Text = .Item(.Row, "IstOutShift3")
                    txtJamIstInShift3.Text = .Item(.Row, "IstInShift3")
                    txtJamPulangShift3.Text = .Item(.Row, "PulangShift3")
                    txtIstNormalMenitShift3.Text = .Item(.Row, "IstNormal3")
                    txtIstJumatShift3.Text = .Item(.Row, "IstJumat3")
                Else
                    Call EnablelCleare()
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call GetData()
    End Sub
End Class