Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMonCutiIzin : Inherits DockContent
    Private Sub FrmMonCutiIzin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetDepartemenAksesn(cboDepartemen)
        Call SetGridDefult()
    End Sub

    Private Sub cboDepartemen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartemen.SelectedIndexChanged

    End Sub

    Private Sub cboDepartemen_TextUpdate(sender As Object, e As EventArgs) Handles cboDepartemen.TextUpdate
        ValidCombo(cboDepartemen)
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
            .Cols.Frozen = 3
            .Cols.Count = 16
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Nama" : .Cols(1).Name = "Nama" : .Cols(1).Width = 200
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nik" : .Cols(2).Name = "Nik" : .Cols(2).Width = 60
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Departemen" : .Cols(3).Name = "Departemen" : .Cols(3).Width = 150
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Jabatan" : .Cols(4).Name = "Jabatan" : .Cols(4).Width = 200
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Status" : .Cols(5).Name = "Status" : .Cols(5).Width = 150
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Tgl.Mulai" : .Cols(6).Name = "TglMulai" : .Cols(6).Width = 100
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Tgl.Selesai" : .Cols(7).Name = "TglAkhir" : .Cols(7).Width = 100
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Absen" : .Cols(8).Name = "Absen" : .Cols(8).Width = 40
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Keterangan" : .Cols(9).Name = "Keterangan" : .Cols(9).Width = 200
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Dibuat Oleh" : .Cols(10).Name = "CreateBy" : .Cols(10).Width = 120
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Tgl.Dibuat" : .Cols(11).Name = "CreateDate" : .Cols(11).Width = 120
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Approve By Dept" : .Cols(12).Name = "ApproveByDept" : .Cols(12).Width = 120
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Approve Date Dept" : .Cols(13).Name = "ApproveDateDept" : .Cols(13).Width = 120
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Approve By PSN" : .Cols(14).Name = "ApproveByPSN" : .Cols(14).Width = 120
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Approve Date PSN" : .Cols(15).Name = "ApproveDatePSN" : .Cols(15).Width = 120
        End With
    End Sub

    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 1

        sql = "select a.StatusTk,b.Nik,b.Nama,b.Departemen,b.JabatanName,a.TglAwal,a.TglAkhir,c.Singkatan,c.Nama as NamaTidakHadir,a.CreateBy,a.CreateDate,a.Keterangan, " &
              "  a.ApproveByDept,a.ApproveByDeptDate,a.ApproveByPSN,a.ApproveByPSNDate from tblTrnCutiIzinHdr a join vwMstKaryawan b on a.RegNo=b.RegNo and a.StatusTk=b.StatusTK " &
              "  join tblMstTidakKerja c on a.IDTidakKerja=c.IDTidakKerja where ApproveByPSN is null "
        If Trim(cboDepartemen.Text) <> "" Then
            sql = sql & " and b.DeptID=" & cboDepartemen.SelectedValue & "  "
        End If

        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg.Rows.Count = 1
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "NIK") = DR!NIK
                            .Item(i, "NAMA") = DR!NAMA
                            If IsDBNull(DR!Departemen) = False Then .Item(i, "Departemen") = DR!Departemen
                            If IsDBNull(DR!JabatanName) = False Then .Item(i, "Jabatan") = DR!JabatanName
                            If IsDBNull(DR!StatusTk) = False Then .Item(i, "Status") = DR!StatusTk
                            If IsDBNull(DR!TglAwal) = False Then .Item(i, "TglMulai") = DR!TglAwal
                            If IsDBNull(DR!TglAkhir) = False Then .Item(i, "TglAkhir") = DR!TglAkhir
                            If IsDBNull(DR!NamaTidakHadir) = False Then .Item(i, "Absen") = DR!NamaTidakHadir
                            If IsDBNull(DR!Keterangan) = False Then .Item(i, "Keterangan") = DR!Keterangan
                            If IsDBNull(DR!CreateBy) = False Then .Item(i, "CreateBy") = DR!CreateBy
                            If IsDBNull(DR!CreateDate) = False Then .Item(i, "CreateDate") = DR!CreateDate
                            If IsDBNull(DR!ApproveByDept) = False Then .Item(i, "ApproveByDept") = DR!ApproveByDept
                            If IsDBNull(DR!ApproveByDeptDate) = False Then .Item(i, "ApproveDateDept") = DR!ApproveByDeptDate
                            If IsDBNull(DR!ApproveByPSN) = False Then .Item(i, "ApproveByPSN") = DR!ApproveByPSN
                            If IsDBNull(DR!ApproveByPSNDate) = False Then .Item(i, "ApproveDatePSN") = DR!ApproveByPSNDate
                            i = i + 1
                        End While
                    End With
                Else
                    fg.Rows.Count = 1
                    fg.Rows.Count = 2
                    MsgBox("Data Tidak Ditemukan!", MessageBoxIcon.Stop)
                End If
            End Using
        End Using
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        'If Trim(cboDepartemen.Text) = "" Then
        '    MsgBox("Departemen Belum Dipilih!", MessageBoxIcon.Stop)
        '    Exit Sub
        'End If
        Me.Cursor = Cursors.WaitCursor
        Call GetData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCloseDevice_Click(sender As Object, e As EventArgs) Handles btnCloseDevice.Click
        Me.Close()
    End Sub

    Private Sub btnExecl_Click(sender As Object, e As EventArgs) Handles btnExecl.Click
        ExportExcelInpoiFlexgrid(fg, 0, 0, True, "Monitoring Tidak Hadir")
    End Sub
End Class