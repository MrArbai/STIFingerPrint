Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMstJabatan : Inherits DockContent
    Dim perintah As String
    Private Sub FrmMstJabatan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        Call EnableBtn(False)
        Call GetData()
    End Sub
    Private Sub EnableBtn(ByVal flag As Boolean)
        btnAdd.Enabled = Not flag
        btnEdit.Enabled = Not flag
        btnSave.Enabled = flag
        btnCancel.Enabled = flag
        Call EnableTxt(flag)
    End Sub
    Private Sub EnableTxt(ByVal flag As Boolean)
        txtNamaJabatan.Enabled = flag
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
            .Cols.Count = 3
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "JabatanID" : .Cols(1).Name = "JabatanID" : .Cols(1).Width = 100
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama Jabatan" : .Cols(2).Name = "NamaJabatan" : .Cols(2).Width = 200
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call EnableBtn(True)
        txtJabatanID.Clear()
        txtNamaJabatan.Clear()
        perintah = "ADD"
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Trim(txtJabatanID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Diedit!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Call EnableBtn(True)
        perintah = "EDIT"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtNamaJabatan.Text) = "" Then
            MsgBox("Nama Jabatan Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If GetCek() = True And perintah = "ADD" Then
            MsgBox("Jabatan : " & txtNamaJabatan.Text & " Sudah Ada!", MessageBoxIcon.Stop)
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
        Call GetData()

        Call EnableBtn(False)
        txtJabatanID.Clear()
        txtNamaJabatan.Clear()
        perintah = "SAVE"
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call EnableBtn(False)
        txtJabatanID.Clear()
        txtNamaJabatan.Clear()
        perintah = "CANCEL"
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        With fg
            If Convert.ToInt32(.Item(.Row, "JabatanID")) > 0 Then
                txtJabatanID.Text = .Item(.Row, "JabatanID")
                txtNamaJabatan.Text = .Item(.Row, "NamaJabatan")
            Else
                txtJabatanID.Clear()
                txtNamaJabatan.Clear()
            End If
        End With
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
                .CommandText = "spMstJabatanSave"
                .Transaction = MyConTrans
                .Parameters.Add("@JabatanID", SqlDbType.Int, ParameterDirection.InputOutput).Value = Val(txtJabatanID.Text)
                .Parameters.Add("@NamaJabatan", SqlDbType.VarChar, 50).Value = UCase(Trim(txtNamaJabatan.Text))
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
        sql = "SELECT JabatanID,NamaJabatan,CreateBy,CreateDate,UpdateBy,UpdateDate FROM STISidikjari.dbo.tblMstJabatan Order By NamaJabatan"

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
                            If IsDBNull(DR!JabatanID) = False Then .Item(i, "JabatanID") = DR!JabatanID
                            If IsDBNull(DR!NamaJabatan) = False Then .Item(i, "NamaJabatan") = DR!NamaJabatan
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
    Private Function GetCek() As Boolean
        Dim sql As String = ""
        Dim i As Integer = 1
        GetCek = False
        sql = "SELECT * FROM STISidikjari.dbo.tblMstJabatan where NamaJabatan='" & UCase(Trim(txtNamaJabatan.Text)) & "' "
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    GetCek = True
                End If
            End Using
        End Using
        Return GetCek
    End Function
End Class