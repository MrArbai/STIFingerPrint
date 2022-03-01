Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmFindMstRegistrasiFinger : Inherits DockContent
    Dim StatusTK As String
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmFindMstRegistrasiFinger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Call GetDepartemen(cboDept)
        Call GetStatusTK(cboStatus)
        Call SetGridDefult()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDept.SelectedIndexChanged

    End Sub

    Private Sub cboDept_TextUpdate(sender As Object, e As EventArgs) Handles cboDept.TextUpdate
        ValidCombo(cboDept)
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
            .Rows.Count = 1
            .Rows.Count = 2
            .Rows(0).Height = 30
            .Cols.Frozen = 0
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "RegNo" : .Cols(1).Name = "RegNo" : .Cols(1).Width = 100 : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama" : .Cols(2).Name = "Nama" : .Cols(2).Width = 200
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nik" : .Cols(3).Name = "Nik" : .Cols(3).Width = 100
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Departemen" : .Cols(4).Name = "Departemen" : .Cols(4).Width = 150
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Jabatan" : .Cols(5).Name = "Jabatan" : .Cols(5).Width = 170
        End With
    End Sub
    Private Sub GetDataKaryawan()
        Dim sql As String = ""
        Dim i As Integer = 1
        If StatusTK = "TAMU" Then
            sql = "SELECT ID as RegNo,a.NIk,a.Nama,a.JabatanID,a.Jabatan as JabatanName,a.IDDept,a.Departemen,a.ActiveNonActive  " &
                    " FROM STISidikjari.dbo.vwMstTamu a left join tblMstUser b on a.ID=b.RegNo and A.StatusTK=b.StatusTK where ActiveNonActive=0 and b.RegNo is null Order By a.Nama "
        Else
            sql = "SELECT   a.RegNo,a.NAMA,NIK,GroupID,DeptID,Departemen,JabatanID,Jabatan,JabatanName,TGLMASUK,STS,AGAMA,Sex,TGLKELUAR " &
            " FROM STISidikjari.dbo.vwMstKaryawan a left Join tblMstUser b on a.RegNo=b.RegNo AND A.StatusTK=B.StatusTK where TGLKELUAR Is null and a.RegNo is NOT null  AND B.RegNo IS NULL  and a.StatusTK='" & StatusTK & "' "
            If Trim(cboDept.Text) <> "" Then
                sql = sql & " and DeptID=" & cboDept.SelectedValue & " "
            End If
            If Trim(txtNikNama.Text) <> "" Then
                sql = sql & " And (NIK='" & Trim(txtNikNama.Text) & "' or a.NAMA like '%" & Trim(txtNikNama.Text) & "%') "
            End If
            sql = sql & " Order By NIK,a.NAMA,Departemen"
        End If

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
                            .Item(i, "RegNo") = DR!RegNo
                            If IsDBNull(DR!Nama) = False Then .Item(i, "Nama") = DR!Nama
                            If IsDBNull(DR!Nik) = False Then .Item(i, "Nik") = DR!Nik
                            If IsDBNull(DR!Departemen) = False Then .Item(i, "Departemen") = DR!Departemen
                            If IsDBNull(DR!JabatanName) = False Then .Item(i, "Jabatan") = DR!JabatanName
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

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        If cboStatus.SelectedValue = 1 Then
            StatusTK = "KARYAWAN"
        ElseIf cboStatus.SelectedValue = 2 Then
            StatusTK = "HARIAN"
        Else
            StatusTK = "TAMU"
        End If
        If Trim(cboStatus.Text) = "" Then
            MsgBox("Status Belum Dipilih!", MessageBoxIcon.Stop, "Stop")
            Exit Sub
        End If
        Call GetDataKaryawan()
    End Sub
    Private Sub Choose()
        Dim baris As Integer = fg.Row
        If Convert.ToDouble(fg.Item(baris, "RegNo")) > 0 Then
            With frmMstRegistrasiFinger
                .txtRegNo.Text = fg.Item(baris, "RegNo")
                If cboStatus.SelectedValue = 1 Then
                    .txtUserID.Text = 3000000 + fg.Item(baris, "RegNo")
                ElseIf cboStatus.SelectedValue = 2 Then
                    .txtUserID.Text = 4000000 + fg.Item(baris, "RegNo")
                Else
                    .txtUserID.Text = 5000000 + fg.Item(baris, "RegNo")
                End If
                .txtNik.Text = fg.Item(baris, "Nik")
                .txtNama.Text = fg.Item(baris, "Nama")
                .txtDepartemen.Text = fg.Item(baris, "Departemen")
                .txtJabatan.Text = fg.Item(baris, "Jabatan")
            End With
            Me.Close()
        End If
    End Sub

    Private Sub btnChose_Click(sender As Object, e As EventArgs) Handles btnChose.Click
        Call Choose()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        Call Choose()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged

    End Sub

    Private Sub cboStatus_TextUpdate(sender As Object, e As EventArgs) Handles cboStatus.TextUpdate
        ValidCombo(cboStatus)
    End Sub
End Class