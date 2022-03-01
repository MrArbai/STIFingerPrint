Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMstDepartemen : Inherits DockContent
    Dim perintah As String = ""
    Private Sub FrmMstDepartemen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        txtSingkatan.Enabled = flag
        txtNamaDept.Enabled = flag
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
            .Cols.Count = 4
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "DeptID" : .Cols(1).Name = "DeptID" : .Cols(1).Width = 50
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Singkatan" : .Cols(2).Name = "Singkatan" : .Cols(2).Width = 100
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nama Dept" : .Cols(3).Name = "NamaDept" : .Cols(3).Width = 150
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call EnableBtn(True)
        perintah = "ADD"
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Trim(txtDeptID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Diedit!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Call EnableBtn(True)
        perintah = "EDIT"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtSingkatan.Text) = "" Then
            MsgBox("Singkatan Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(txtNamaDept.Text) = "" Then
            MsgBox("Nama Departemen Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If GetCek() = True And perintah = "ADD" Then
            MsgBox("Departemen : " & txtNamaDept.Text & " Sudah Ada!", MessageBoxIcon.Stop)
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
        txtDeptID.Clear()
        txtNamaDept.Clear()
        txtSingkatan.Clear()
        perintah = "SAVE"
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call EnableBtn(False)
        txtDeptID.Clear()
        txtNamaDept.Clear()
        txtSingkatan.Clear()
        perintah = "CANCEL"
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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
                .CommandText = "spMstDepartemenSave"
                .Transaction = MyConTrans
                .Parameters.Add("@DeptID", SqlDbType.Int, ParameterDirection.InputOutput).Value = Val(txtDeptID.Text)
                .Parameters.Add("@Singakatan", SqlDbType.VarChar, 50).Value = UCase(Trim(txtSingkatan.Text))
                .Parameters.Add("@NamaDept", SqlDbType.VarChar, 100).Value = UCase(Trim(txtNamaDept.Text))
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
        sql = "SELECT DeptID,DeptAbbr,DeptName,CreateBy,CreateDate,UpdateBy,UpdateDate FROM STISidikjari.dbo.tblMstDepartemen Order By DeptAbbr"

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
                            If IsDBNull(DR!DeptID) = False Then .Item(i, "DeptID") = DR!DeptID
                            If IsDBNull(DR!DeptAbbr) = False Then .Item(i, "Singkatan") = DR!DeptAbbr
                            If IsDBNull(DR!DeptName) = False Then .Item(i, "NamaDept") = DR!DeptName
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
            If Convert.ToInt32(.Item(.Row, "DeptID")) > 0 Then
                txtDeptID.Text = .Item(.Row, "DeptID")
                txtSingkatan.Text = .Item(.Row, "Singkatan")
                txtNamaDept.Text = .Item(.Row, "NamaDept")
            Else
                txtDeptID.Clear()
                txtNamaDept.Clear()
                txtSingkatan.Clear()
            End If
        End With
    End Sub

    Private Function GetCek() As Boolean
        Dim sql As String = ""
        Dim i As Integer = 1
        GetCek = False
        sql = "SELECT * FROM tblMstDepartemen where DeptName='" & UCase(Trim(txtNamaDept.Text)) & "' "
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