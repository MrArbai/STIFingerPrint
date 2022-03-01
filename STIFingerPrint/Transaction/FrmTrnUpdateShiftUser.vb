Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmTrnUpdateShiftUser : Inherits DockContent
    Private Sub FrmTrnUpdateShiftUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetDepartemen(cboDepartemen)
        Call GetJabatan(cboJabatan)
        Call GetSetWorkTime(cboShiftUser)
        Call SetGridDefult()
    End Sub

    Private Sub cboDepartemen_TextUpdate(sender As Object, e As EventArgs) Handles cboDepartemen.TextUpdate
        ValidCombo(cboDepartemen)
    End Sub
    Private Sub cboJabatan_TextUpdate(sender As Object, e As EventArgs) Handles cboJabatan.TextUpdate
        ValidCombo(cboJabatan)
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
            .Cols.Count = 11
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "UserID" : .Cols(1).Name = "UserID" : .Cols(1).Width = 80 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "ShiftID" : .Cols(2).Name = "ShiftID" : .Cols(2).Width = 100 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nama" : .Cols(3).Name = "Nama" : .Cols(3).Width = 200 : .Cols(3).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Nik" : .Cols(4).Name = "Nik" : .Cols(4).Width = 70 : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Departemen" : .Cols(5).Name = "Departemen" : .Cols(5).Width = 150
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Jabatan" : .Cols(6).Name = "Jabatan" : .Cols(6).Width = 150
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Shift 1" : .Cols(7).Name = "Shift1" : .Cols(7).Width = 100 : .Cols(7).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Shift 2" : .Cols(8).Name = "Shift2" : .Cols(8).Width = 100 : .Cols(8).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Shift 3" : .Cols(9).Name = "Shift3" : .Cols(9).Width = 100 : .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Update" : .Cols(10).Name = "Update" : .Cols(10).Width = 70 : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).DataType = GetType(Boolean)
        End With
    End Sub
    Private Sub GetSetWorkTime(ByVal cbo As ComboBox)
        cbo.DataSource = IsiCombo("select TipeShift,Shift1 + '  |  ' + Shift2 + '  |  ' +Shift3 as Jam  FROM tblMstShift").Tables(0)
        cbo.DisplayMember = "Jam"
        cbo.ValueMember = "TipeShift"
        cbo.SelectedIndex = -1
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


    Private Sub cboShiftUser_TextUpdate(sender As Object, e As EventArgs) Handles cboShiftUser.TextUpdate
        ValidCombo(cboShiftUser)
    End Sub

    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "select a.UserID,a.NAMA,a.NIK,a.Departemen,a.JabatanName,Shift1,Shift2,Shift3 " &
                " from vwMstUser a left join tblMstShift b on a.TipeShift=b.TipeShift  where GroupAbsenID=0 "
        If Trim(cboDepartemen.Text) <> "" Then
            sql = sql & " and a.DeptID='" & cboDepartemen.SelectedValue & "'  "
        End If
        If Trim(cboJabatan.Text) <> "" Then
            sql = sql & " and a.JabatanID='" & cboJabatan.SelectedValue & "'  "
        End If
        If Trim(txtNikNama.Text) <> "" Then
            sql = sql & " and NIK='" & Trim(txtNikNama.Text) & "' or Nama LIKE '%" & Trim(txtNikNama.Text) & "%'  "
        End If
        sql = sql & " Order By NIK,NAMA"
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
                            If IsDBNull(DR!Shift1) = False Then .Item(i, "Shift1") = DR!Shift1
                            If IsDBNull(DR!Shift2) = False Then .Item(i, "Shift2") = DR!Shift2
                            If IsDBNull(DR!Shift3) = False Then .Item(i, "Shift3") = DR!Shift3
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function UpdateShift(ByVal userID As Long, ByVal TipeShift As Integer) As Boolean
        Dim ret As Boolean = False
        Try
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn
                .CommandType = CommandType.Text
                .CommandText = "Update tblMstUser Set TipeShift='" & TipeShift & "' WHERE UserID='" & userID & "' "
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
        If Trim(cboShiftUser.Text) = "" Then
            MsgBox("Silakan Pilih Shift Time Update!", MsgBoxStyle.Critical)
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
                    ret = UpdateShift(.Item(i, "UserID"), cboShiftUser.SelectedValue)
                End If
                'If ret = True Then
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