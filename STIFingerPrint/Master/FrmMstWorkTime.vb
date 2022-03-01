Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMstWorkTime : Inherits DockContent
    Private Sub FrmMstWorkTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call EnableBtn(False)
        Call EnableTxt(False)
        Call SetGridDefult()
        Call GetData()
    End Sub
    Private Sub EnableBtn(ByVal flag As Boolean)
        btnAdd.Enabled = Not flag
        btnEdit.Enabled = Not flag
        btnSave.Enabled = flag
        btnCancel.Enabled = flag
    End Sub
    Private Sub EnableTxt(ByVal Flag As Boolean)
        txtJamMasuk.Enabled = Flag
        txtJamPulang.Enabled = Flag
        txtJamIstirahatNormal.Enabled = Flag
        txtJamIstirahatJumat.Enabled = Flag
        txtLamaIstNormal.Enabled = Flag
        txtLamaIstirahatJumat.Enabled = Flag
        txtPanjangKerjaBiasa.Enabled = Flag
        txtPanjangKerjaJumat.Enabled = Flag
        txtPanjangKerjaSabtu.Enabled = Flag
    End Sub
    Private Sub CleareTxt()
        txtGroupAbsenID.Clear()
        txtJamMasuk.Clear()
        txtJamPulang.Clear()
        txtJamIstirahatNormal.Clear()
        txtJamIstirahatJumat.Clear()
        txtLamaIstNormal.Clear()
        txtLamaIstirahatJumat.Clear()
        txtPanjangKerjaBiasa.Clear()
        txtPanjangKerjaJumat.Clear()
        txtPanjangKerjaSabtu.Clear()
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
            .Cols.Count = 13
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "GroupAbsenID" : .Cols(1).Name = "GroupAbsenID" : .Cols(1).Width = 100 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Jam" : .Cols(2).Name = "Jam" : .Cols(2).Width = 100 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Jam Masuk" : .Cols(3).Name = "JamMasuk" : .Cols(3).Width = 50 : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Jam Pulang" : .Cols(4).Name = "JamPulang" : .Cols(4).Width = 50 : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Jam Istirahat Normal" : .Cols(5).Name = "JamIstirahatNormal" : .Cols(5).Width = 70 : .Cols(5).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Jam Istirahat Jumat" : .Cols(6).Name = "JamIstirahatJumat" : .Cols(6).Width = 70 : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Lama Istirahat Normal" : .Cols(7).Name = "LamaIstirahatNormal" : .Cols(7).Width = 90 : .Cols(7).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Lama Istirahat Jumat" : .Cols(8).Name = "LamaIstirahatJumat" : .Cols(8).Width = 90 : .Cols(8).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Panjang Kerja Biasa" : .Cols(9).Name = "PanjangKerjaBiasa" : .Cols(9).Width = 90 : .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Panjang Kerja Jumat" : .Cols(10).Name = "PanjangKerjaJumat" : .Cols(10).Width = 90 : .Cols(10).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Panjang Kerja Sabtu" : .Cols(11).Name = "PanjangKerjaSabtu" : .Cols(11).Width = 90 : .Cols(11).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "AktifNotAktif" : .Cols(12).Name = "AktifNotAktif" : .Cols(12).Width = 90 : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).DataType = GetType(Boolean)
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call EnableBtn(True)
        Call EnableTxt(True)
        Call CleareTxt()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Trim(txtGroupAbsenID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Diedit!", MsgBoxStyle.Critical, "Warning!")
            Exit Sub
        End If
        Call EnableBtn(True)
        Call EnableTxt(True)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction

        If txtJamMasuk.Text = "  :" Then
            MsgBox("Jam Masuk Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamPulang.Text = "  :" Then
            MsgBox("Jam Pulang Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamIstirahatNormal.Text = "  :" Then
            MsgBox("Jam Istirahat Normal Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If txtJamIstirahatJumat.Text = "  :" Then
            MsgBox("Jam Istirahat Jumat Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If Trim(txtLamaIstNormal.Text) = "" Then
            MsgBox("Lama Istirahat Normal Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If Trim(txtLamaIstirahatJumat.Text) = "" Then
            MsgBox("Lama Istirahat Jumat Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Try
            If Simpan(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                MsgBox("Simpan Data Gagal", vbCritical, "Save Failed")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Transaksi.Commit()
            Call EnableBtn(False)
            Call EnableTxt(False)
            Call CleareTxt()
            MsgBox("Simpan Data Beshasil!", vbInformation)
            Call GetData()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Transaksi.Rollback()
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call EnableBtn(False)
        Call EnableTxt(False)
        Call CleareTxt()
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
                .CommandText = "spMstGroupAbsenSave"
                .Transaction = MyConTrans
                .Parameters.Add("@GroupAbsenID", SqlDbType.BigInt).Value = Val(txtGroupAbsenID.Text)
                .Parameters.Add("@Jam", SqlDbType.VarChar, 20).Value = txtJamMasuk.Text & "-" & txtJamPulang.Text
                .Parameters.Add("@JamMasuk", SqlDbType.VarChar, 5).Value = txtJamMasuk.Text
                .Parameters.Add("@JamPulang", SqlDbType.VarChar, 5).Value = txtJamPulang.Text
                .Parameters.Add("@JamIstirahatNormal", SqlDbType.VarChar, 5).Value = txtJamIstirahatNormal.Text
                .Parameters.Add("@JamIstirahatJumat", SqlDbType.VarChar, 5).Value = txtJamIstirahatJumat.Text
                .Parameters.Add("@LamaIstirahatNormal", SqlDbType.Int).Value = Trim(txtLamaIstNormal.Text)
                .Parameters.Add("@LamaIstirahatJumat", SqlDbType.Int).Value = Trim(txtLamaIstirahatJumat.Text)
                .Parameters.Add("@JamKerjaPanjangNormal", SqlDbType.Int).Value = Trim(txtPanjangKerjaBiasa.Text)
                .Parameters.Add("@JamKerjaPanjangJumat", SqlDbType.Int).Value = Trim(txtPanjangKerjaJumat.Text)
                .Parameters.Add("@JamKerjaPanjangSabtu", SqlDbType.Int).Value = Trim(txtPanjangKerjaSabtu.Text)
                .Parameters.Add("@LoginName", SqlDbType.VarChar, 50).Value = UserLogin
                If chk.Checked = True Then
                    .Parameters.Add("@NotActive", SqlDbType.VarChar, 50).Value = 1
                Else
                    .Parameters.Add("@NotActive", SqlDbType.VarChar, 50).Value = 0
                End If
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

    Private Sub chk_CheckedChanged(sender As Object, e As EventArgs) Handles chk.CheckedChanged
        If chk.Checked = True Then
            chk.Text = "Not Aktif"
        Else
            chk.Text = "Aktif"
        End If
    End Sub
    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "SELECT GroupAbsenID,Jam,JamMasuk,JamPulang,JamIstirahatNormal,JamIstirahatJumat,LamaIstirahatNormal,LamaIstirahatJumat,NotActive,JamKerjaPanjangNormal,JamKerjaPanjangJumat,JamKerjaPanjangSabtu FROM STISidikjari.dbo.tblMstGroupAbsen "

        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg.Rows.Count = 1
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "GroupAbsenID") = DR!GroupAbsenID
                            .Item(i, "Jam") = DR!Jam
                            .Item(i, "JamMasuk") = DR!JamMasuk
                            .Item(i, "JamPulang") = DR!JamPulang
                            .Item(i, "JamIstirahatNormal") = DR!JamIstirahatNormal
                            .Item(i, "JamIstirahatJumat") = DR!JamIstirahatJumat
                            .Item(i, "LamaIstirahatNormal") = DR!LamaIstirahatNormal
                            .Item(i, "LamaIstirahatJumat") = DR!LamaIstirahatJumat
                            .Item(i, "PanjangKerjaBiasa") = DR!JamKerjaPanjangNormal
                            .Item(i, "PanjangKerjaJumat") = DR!JamKerjaPanjangJumat
                            .Item(i, "PanjangKerjaSabtu") = DR!JamKerjaPanjangSabtu
                            .Item(i, "AktifNotAktif") = DR!NotActive
                            i = i + 1
                        End While
                    End With
                Else
                    fg.Rows.Count = 1
                    fg.Rows.Count = 2
                End If
            End Using
        End Using
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        With fg
            If Convert.ToDouble(.Item(.Row, "GroupAbsenID")) > 0 Then
                txtGroupAbsenID.Text = .Item(.Row, "GroupAbsenID")
                txtJamMasuk.Text = .Item(.Row, "JamMasuk")
                txtJamPulang.Text = .Item(.Row, "JamPulang")
                txtJamIstirahatNormal.Text = .Item(.Row, "JamIstirahatNormal")
                txtJamIstirahatJumat.Text = .Item(.Row, "JamIstirahatJumat")
                txtLamaIstNormal.Text = .Item(.Row, "LamaIstirahatNormal")
                txtLamaIstirahatJumat.Text = .Item(.Row, "LamaIstirahatJumat")
                If IsDBNull(.Item(.Row, "PanjangKerjaBiasa")) = False Then txtPanjangKerjaBiasa.Text = .Item(.Row, "PanjangKerjaBiasa")
                If IsDBNull(.Item(.Row, "PanjangKerjaJumat")) = False Then txtPanjangKerjaJumat.Text = .Item(.Row, "PanjangKerjaJumat")
                If IsDBNull(.Item(.Row, "PanjangKerjaSabtu")) = False Then txtPanjangKerjaSabtu.Text = .Item(.Row, "PanjangKerjaSabtu")
                chk.Checked = Convert.ToBoolean(.Item(.Row, "AktifNotAktif"))
            Else
                Call CleareTxt()
            End If
        End With
    End Sub
End Class