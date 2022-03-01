Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmutlGroupManagement
    Dim perintah As String
    Private Sub FrmutlGroupManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        Call GetGroupAkses()

        Call EnableBtn(False)
    End Sub
    Private Sub SetGridDefult()
        Dim txt As CellRange
        With fg1
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Thistle
            .Styles.Fixed.ForeColor = Color.Black
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .BorderStyle = Util.BaseControls.BorderStyleEnum.None
            .Styles.Normal.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = False
            .Rows.Fixed = 1
            .Rows(0).Height = 30
            .Rows.Count = 2
            .Cols.Frozen = 0
            .Cols.Count = 3
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "GroupID" : .Cols(1).Name = "GroupID" : .Cols(1).Width = 40 : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Group Name" : .Cols(2).Name = "GroupName" : .Cols(2).Width = 200
        End With
        With fg2
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Thistle
            .Styles.Fixed.ForeColor = Color.Black
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .BorderStyle = Util.BaseControls.BorderStyleEnum.None
            .Styles.Normal.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = True
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 30
            .Cols.Frozen = 0
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pilih" : .Cols(1).Name = "Pilih" : .Cols(1).Width = 40 : .Cols(1).DataType = GetType(Boolean)
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Tag ID" : .Cols(2).Name = "TagID" : .Cols(2).Width = 40 : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Menu Name" : .Cols(3).Name = "MenuName" : .Cols(3).Width = 200
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "DetailID" : .Cols(4).Name = "DetailID" : .Cols(4).Width = 100 : .Cols(4).Visible = False
        End With
        With fg3
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Thistle
            .Styles.Fixed.ForeColor = Color.Black
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .BorderStyle = Util.BaseControls.BorderStyleEnum.None
            .Styles.Normal.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = True
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 30
            .Cols.Frozen = 0
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pilih" : .Cols(1).Name = "Pilih" : .Cols(1).Width = 40 : .Cols(1).DataType = GetType(Boolean)
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "DeptID" : .Cols(2).Name = "DeptID" : .Cols(2).Width = 40 : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Departemen" : .Cols(3).Name = "Departemen" : .Cols(3).Width = 200
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "ID" : .Cols(4).Name = "ID" : .Cols(4).Width = 100 : .Cols(4).Visible = False
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub EnableBtn(ByVal flag As Boolean)
        btnAdd.Enabled = Not flag
        btnEdit.Enabled = Not flag
        btnSave.Enabled = flag
        btnCancel.Enabled = flag
        fg1.Enabled = flag
        fg2.Enabled = flag
        fg3.Enabled = flag
        txtGroupName.Enabled = False
    End Sub

    Private Sub HapusFg()
        fg2.Rows.Count = 1
        fg2.Rows.Count = 2
        fg3.Rows.Count = 1
        fg3.Rows.Count = 2
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call EnableBtn(True)
        perintah = "ADD"
        txtGroupName.Enabled = True
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Call EnableBtn(True)
        perintah = "EDIT"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If perintah = "ADD" Then
            If Trim(txtGroupName.Text) = "" Then
                MsgBox("Group Name Masih Kosong!", vbCritical)
                Exit Sub
            End If
            If CekGroup() = True Then
                MsgBox("Group User Ini : " & Trim(txtGroupName.Text) & " Sudah Ada!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If SimpanGroupHeader() = False Then
                MsgBox("Simpan Group Akses Gagal", , MessageBoxIcon.Stop)
                Exit Sub
            End If
            Call GetGroupAkses()
            txtGroupID.Text = ""
            txtGroupName.Text = ""
            HapusFg()
        Else
            If Trim(txtGroupID.Text) = "" Then
                MsgBox("Group Akses Belum Dilipih!", vbCritical)
                Exit Sub
            End If

            Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
            Dim Transaksi As SqlTransaction
            Transaksi = Koneksi.BeginTransaction
            Try
                Me.Cursor = Cursors.WaitCursor
                For i As Integer = 1 To fg2.Rows.Count - 1
                    If Simpan(Koneksi, Transaksi, i) = False Then
                        MsgBox("Simpan Data Menu Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
                        Me.Cursor = Cursors.Default
                        Transaksi.Rollback()
                        Exit Sub
                    End If
                Next
                For j As Integer = 1 To fg3.Rows.Count - 1
                    If SimpanDepertemen(Koneksi, Transaksi, j) = False Then
                        MsgBox("Simpan Data Departemen Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
                        Me.Cursor = Cursors.Default
                        Transaksi.Rollback()
                        Exit Sub
                    End If
                Next

                Transaksi.Commit()
                Call MenuListItem()
                Call GetMenu()
                Call GetDepartemen()
                Call GetDepartemenSudahSimpan()
                Me.Cursor = Cursors.Default
                MsgBox("Menu Akses Berhasil Dibuat", vbInformation)
                Call EnableBtn(False)
                perintah = "SAVE"
            Catch ex As Exception
                Transaksi.Rollback()
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub
    Private Function SimpanGroupHeader() As Boolean
        Dim simpan As Boolean = False
        Try
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblUtlGroupHeader (GroupName) VALUES('" & UCase(Trim(txtGroupName.Text)) & "')"
                .ExecuteNonQuery()
            End With
            Conn.Close()
            MsgBox("Group Akses Berhasil Dibuat", vbInformation, "Success")
            simpan = True
        Catch ex As Exception
            simpan = False
            MessageBox.Show(ex.Message)
        End Try
        Return simpan
    End Function

    Private Function CekGroup() As Boolean
        Dim cek As Boolean = False
        Dim sql As String
        sql = "SELECT * FROM tblUtlGroupHeader where GroupName='" & Trim(txtGroupName.Text) & "' "
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    cek = True
                End If
            End Using
        End Using
        Return cek
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call EnableBtn(False)
        perintah = "CANCEL"
        txtGroupID.Text = ""
        txtGroupName.Text = ""
        HapusFg()
    End Sub

    Private Sub fg2_Click(sender As Object, e As EventArgs) Handles fg2.Click

    End Sub

    Private Sub fg2_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg2.BeforeEdit
        Select Case fg2.Cols(e.Col).Name
            Case "Pilih"
                e.Cancel = False
            Case Else
                e.Cancel = True
        End Select
    End Sub
    Private Sub GetGroupAkses()
        Dim sql As String
        sql = "SELECT * FROM tblUtlGroupHeader Order By GroupName "
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg1.Rows.Count = 1
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    With fg1
                        While DR.Read
                            .AddItem("")
                            .Item(.Rows.Count - 1, "No") = .Rows.Count - 1
                            .Item(.Rows.Count - 1, "GroupID") = DR!GroupID
                            .Item(.Rows.Count - 1, "GroupName") = DR!GroupName
                        End While
                    End With
                End If
            End Using
        End Using
    End Sub

    Private Sub GetMenues(ByVal Current As ToolStripItem, ByRef menues As List(Of ToolStripItem))
        menues.Add(Current)
        If TypeOf (Current) Is ToolStripMenuItem Then
            For Each menu As ToolStripItem In DirectCast(Current, ToolStripMenuItem).DropDownItems
                GetMenues(menu, menues)
            Next
        End If
    End Sub
    Private Sub MenuListItem()
        Dim Menu As New List(Of ToolStripItem), i As Integer
        For Each t As ToolStripItem In MDIMenu.MenuStrip.Items
            GetMenues(t, Menu)
        Next
        i = 0
        fg2.Rows.Count = 1
        For Each t As ToolStripItem In Menu
            i += 1
            Select Case Trim(t.Text)
                Case "Master", "Transaction", "Monitoring", "Utility", "Windows", "Exit", String.Empty
                Case Else
                    If t.Tag <> String.Empty Then
                        fg2.AddItem("")
                        fg2.Item(fg2.Rows.Count - 1, "No") = fg2.Rows.Count - 1
                        fg2.Item(fg2.Rows.Count - 1, "TagID") = t.Tag
                        fg2.Item(fg2.Rows.Count - 1, "MenuName") = t.Text
                    End If
            End Select
        Next
    End Sub

    Private Sub fg1_Click(sender As Object, e As EventArgs) Handles fg1.Click

    End Sub

    Private Sub fg1_DoubleClick(sender As Object, e As EventArgs) Handles fg1.DoubleClick
        If Convert.ToDouble(fg1.Item(fg1.Row, "GroupID")) > 0 Then
            Call MenuListItem()
            Call GetDepartemen()
            txtGroupID.Text = fg1.Item(fg1.Row, "GroupID")
            Call GetMenu()
            Call GetDepartemenSudahSimpan()
        Else
            txtGroupID.Text = ""
            fg1.Rows.Count = 2
        End If
    End Sub

    Private Function Simpan(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal baris As Integer) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        Simpan = False
        Dim mycon As SqlConnection = conn
        Dim mycontrans As SqlTransaction = trans
        Try
            With cmd
                .Connection = conn
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spUtlUserDetailSave"
                .Transaction = mycontrans
                .Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.BigInt, 3, ParameterDirection.ReturnValue, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .Parameters.Add("@DetailID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(fg2.Item(baris, "DetailID"))
                .Parameters.Add("@GroupID", SqlDbType.BigInt).Value = Val(Trim(txtGroupID.Text))
                .Parameters.Add("@Tag", SqlDbType.BigInt).Value = Val(fg2.Item(baris, "TagID"))
                .Parameters.Add("@Menu", SqlDbType.VarChar, 5000).Value = Convert.ToString(fg2.Item(baris, "MenuName"))
                .Parameters.Add("@Pilih", SqlDbType.Bit).Value = Convert.ToBoolean(fg2.Item(baris, "pilih"))
                .Parameters.Add("@CreateBy", SqlDbType.VarChar, 20).Value = UserLogin
                .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
                .ExecuteNonQuery()
            End With
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
    Private Function SimpanDepertemen(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal baris As Integer) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        SimpanDepertemen = False
        Dim mycon As SqlConnection = conn
        Dim mycontrans As SqlTransaction = trans
        Try
            With cmd
                .Connection = conn
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spUtlUserDepartemen"
                .Transaction = mycontrans
                .Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.BigInt, 3, ParameterDirection.ReturnValue, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .Parameters.Add("@DetailID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(fg3.Item(baris, "ID"))
                .Parameters.Add("@GroupID", SqlDbType.BigInt).Value = Val(Trim(txtGroupID.Text))
                .Parameters.Add("@DeptID", SqlDbType.BigInt).Value = Val(fg3.Item(baris, "DeptID"))
                .Parameters.Add("@DepartemenName", SqlDbType.VarChar, 5000).Value = Convert.ToString(fg3.Item(baris, "Departemen"))
                .Parameters.Add("@Pilih", SqlDbType.Bit).Value = Convert.ToBoolean(fg3.Item(baris, "pilih"))
                .Parameters.Add("@CreateBy", SqlDbType.VarChar, 20).Value = UserLogin
                .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
                .ExecuteNonQuery()
            End With
            If CInt(cmd.Parameters("@Flag").Value) <> 0 Then
                cmd.Dispose()
                Exit Function
            End If
            cmd.Dispose()
            SimpanDepertemen = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return SimpanDepertemen
    End Function
    Private Sub GetMenu()
        Dim sql As String
        Dim i As Integer = 1
        sql = "SELECT * FROM tblUtlGroupDetail where GroupID='" & Trim(txtGroupID.Text) & "' "
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    With fg2
                        While DR.Read
                            For i = 1 To .Rows.Count - 1
                                If DR!Tag = Val(.Item(i, "TagID")) Then
                                    .Item(i, "Pilih") = True
                                End If
                            Next
                        End While
                    End With
                End If
            End Using
        End Using
    End Sub
    Private Sub GetDepartemen()
        Dim sql As String
        Dim i As Integer = 1
        sql = "select DeptID,Departemen from vwMstDept Order By Departemen"
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                fg3.Rows.Count = 1
                If DR.HasRows Then
                    With fg3
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "DeptID") = DR!DeptID
                            .Item(i, "Departemen") = DR!Departemen
                            i = i + 1
                        End While
                    End With
                Else
                    fg3.Rows.Count = 1
                    fg3.Rows.Count = 2
                End If
            End Using
        End Using
    End Sub
    Private Sub GetDepartemenSudahSimpan()
        Dim sql As String
        Dim i As Integer = 1
        sql = "select DeptID,Departemen  from vwMstDept where DeptID in (select DeptID from tblUtlGroupDepartemen where GroupID='" & txtGroupID.Text & "') Order By Departemen"
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    With fg3
                        While DR.Read
                            For i = 1 To .Rows.Count - 1
                                If DR!DeptID = Val(.Item(i, "DeptID")) Then
                                    .Item(i, "Pilih") = True
                                End If
                            Next
                        End While
                    End With
                End If
            End Using
        End Using
    End Sub

    Private Sub fg1_MouseMove(sender As Object, e As MouseEventArgs) Handles fg1.MouseMove
        Try
            If fg1.MouseRow > 0 Then
                Dim tip As String = "Double Klik Disini Untuk Pilih Menu!"
                ToolTip1.SetToolTip(fg1, tip)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fg3_Click(sender As Object, e As EventArgs) Handles fg3.Click

    End Sub

    Private Sub fg3_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg3.BeforeEdit
        Select Case fg3.Cols(e.Col).Name
            Case "Pilih"
                e.Cancel = False
            Case Else
                e.Cancel = True
        End Select
    End Sub
End Class