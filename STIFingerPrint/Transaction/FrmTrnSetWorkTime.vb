Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmTrnSetWorkTime : Inherits DockContent
    Private Sub FrmTrnSetWorkTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetSetWorkTime(cboGroupAbsen)
        Call GetDepartemen(cboDepartemen)
        Call SetGridDefult()
    End Sub
    Private Sub GetSetWorkTime(ByVal cbo As ComboBox)
        cbo.DataSource = IsiCombo("select GroupAbsenID,Jam + '    [ Ist Out Normal '+JamIstirahatNormal+' ]    [ Ist Out Jumat'+JamIstirahatJumat+' ]' as Jam from tblMstGroupAbsen " &
                                " UNION ALL SELECT 0 as GroupAbsenID, 'SHIFT' AS Jam").Tables(0)
        cbo.DisplayMember = "Jam"
        cbo.ValueMember = "GroupAbsenID"
        cbo.SelectedIndex = -1
    End Sub

    Private Sub cboGroupAbsen_TextUpdate(sender As Object, e As EventArgs) Handles cboGroupAbsen.TextUpdate
        ValidCombo(cboGroupAbsen)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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
            .AllowEditing = True
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 30
            .Cols.Frozen = 0
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "User ID" : .Cols(1).Name = "UserID" : .Cols(1).Width = 100 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama" : .Cols(2).Name = "Nama" : .Cols(2).Width = 200 : .Cols(2).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nik" : .Cols(3).Name = "Nik" : .Cols(3).Width = 70 : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Departemen" : .Cols(4).Name = "Departemen" : .Cols(4).Width = 200
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Jabatan" : .Cols(5).Name = "Jabatan" : .Cols(5).Width = 150
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Work Time" : .Cols(6).Name = "WorkTime" : .Cols(6).Width = 120 : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Update" : .Cols(7).Name = "Update" : .Cols(7).Width = 50 : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).DataType = GetType(Boolean)
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "GroupAbsenID" : .Cols(8).Name = "GroupAbsenID" : .Cols(8).Width = 50 : .Cols(8).Visible = False
        End With
    End Sub

    Private Sub cboDepartemen_TextUpdate(sender As Object, e As EventArgs) Handles cboDepartemen.TextUpdate
        ValidCombo(cboDepartemen)
    End Sub
    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "select a.UserID,a.GroupAbsenID,b.NIK,b.NAMA,b.JabatanName,b.Departemen,CASE WHEN A.GroupAbsenID>0 THEN c.Jam WHEN a.GroupAbsenID=0 then 'SHIFT' END AS Jam from tblMstUser a join vwMstKaryawan b on a.RegNo=b.RegNo and a.StatusTK=b.StatusTK " &
            " left join tblMstGroupAbsen c on a.GroupAbsenID=c.GroupAbsenID "
        If Trim(cboDepartemen.Text) <> "" And Trim(txtNik.Text) <> "" Then
            sql = sql & " Where b.DeptID='" & cboDepartemen.SelectedValue & "' and b.NIK='" & Trim(txtNik.Text) & "' "
        ElseIf Trim(cboDepartemen.Text) <> "" And Trim(txtNik.Text) = "" Then
            sql = sql & " Where b.DeptID='" & cboDepartemen.SelectedValue & "'  "
        ElseIf Trim(cboDepartemen.Text) = "" And Trim(txtNik.Text) <> "" Then
            sql = sql & " Where   b.NIK='" & Trim(txtNik.Text) & "' "
        End If
        sql = sql & " Order By b.NIK,b.NAMA"
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg.Rows.Count = 1
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "UserID") = DR!UserID
                            .Item(i, "Nama") = DR!Nama
                            .Item(i, "Nik") = DR!Nik
                            If IsDBNull(DR!Departemen) = False Then .Item(i, "Departemen") = DR!Departemen
                            If IsDBNull(DR!JabatanName) = False Then .Item(i, "Jabatan") = DR!JabatanName
                            If IsDBNull(DR!Jam) = False Then .Item(i, "WorkTime") = DR!Jam
                            If IsDBNull(DR!GroupAbsenID) = False Then .Item(i, "GroupAbsenID") = DR!GroupAbsenID
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

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        Call GetData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        Select Case fg.Cols(e.Col).Name
            Case "Update"
                e.Cancel = False
            Case Else
                e.Cancel = True
        End Select
    End Sub
    Private Function UpdateGroupID(ByVal userID As Long, ByVal GroupAbsenID As Integer) As Boolean
        Dim ret As Boolean = False
        Try
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn

                If GroupAbsenID = 0 Then
                    .CommandType = CommandType.Text
                    .CommandText = "Update tblMstUser set GroupAbsenID='" & GroupAbsenID & "' WHERE UserID='" & userID & "' "
                Else
                    .CommandType = CommandType.Text
                    .CommandText = "Update tblMstUser set GroupAbsenID='" & GroupAbsenID & "',TipeShift=null WHERE UserID='" & userID & "' "
                End If
                .ExecuteNonQuery()
            End With
            ret = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return ret
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim i As Integer = 1
        Dim ret As Boolean = False
        Dim ada As Boolean = False
        If Trim(cboGroupAbsen.Text) = "" Then
            MsgBox("Silakan Pilih Work Time Update!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        With fg
            For j As Integer = 1 To .Rows.Count - 1
                If Convert.ToBoolean(.Item(j, "Update")) = True Then
                    ada = True
                    Exit For
                End If
            Next
            If ada = False Then
                MsgBox("Tidak Ada Yang Akan Diupdate!", MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            For i = 1 To .Rows.Count - 1
                If Convert.ToBoolean(.Item(i, "Update")) = True Then
                    ret = UpdateGroupID(.Item(i, "UserID"), cboGroupAbsen.SelectedValue)
                End If
                'If ret = False Then
                '    Exit For
                'End If
            Next
            If ret = True Then
                MsgBox("Simpan Data Berhasil!", MsgBoxStyle.Information, "Sucsess")
                Me.Cursor = Cursors.WaitCursor
                Call GetData()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            MsgBox("Simpan Data Gagal!", MessageBoxIcon.Stop, "Stop!")
        End With
    End Sub
End Class