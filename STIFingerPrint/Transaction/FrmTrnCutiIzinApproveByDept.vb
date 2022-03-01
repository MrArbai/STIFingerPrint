Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmTrnCutiIzinApproveByDept : Inherits DockContent
    Private Sub FrmTrnCutiIzinApproveByDept_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        Call GetDepartemenAksesn(cboDepartemen)
    End Sub
    Private Sub SetGridDefult()
        Dim txt As CellRange
        With fg1
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Aquamarine
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
            .Cols.Count = 15
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "HeaderID" : .Cols(1).Name = "HeaderID" : .Cols(1).Width = 100 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Approve" : .Cols(2).Name = "Approve" : .Cols(2).Width = 80 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).DataType = GetType(Boolean)
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Kembali Ke ADM" : .Cols(3).Name = "KembaliKeADM" : .Cols(3).Width = 80 : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).DataType = GetType(Boolean)
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Status Tk" : .Cols(4).Name = "StatusTk" : .Cols(4).Width = 150 : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Nama" : .Cols(5).Name = "Nama" : .Cols(5).Width = 200 : .Cols(5).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Nik" : .Cols(6).Name = "Nik" : .Cols(6).Width = 80 : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Departemen" : .Cols(7).Name = "Departemen" : .Cols(7).Width = 200 : .Cols(7).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Jenis" : .Cols(8).Name = "Jenis" : .Cols(8).Width = 130 : .Cols(8).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Tgl.Mulai" : .Cols(9).Name = "TglMuali" : .Cols(9).Width = 80 : .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Tgl.Akhir" : .Cols(10).Name = "TglAkhir" : .Cols(10).Width = 80 : .Cols(10).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Dibuat Oleh" : .Cols(11).Name = "CreateBy" : .Cols(11).Width = 100 : .Cols(11).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Dibuat Tanggal" : .Cols(12).Name = "CreatedDate" : .Cols(12).Width = 100 : .Cols(12).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Komputer" : .Cols(13).Name = "Computer" : .Cols(13).Width = 100 : .Cols(13).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Komputer Tanggal" : .Cols(14).Name = "ComputerDate" : .Cols(14).Width = 100 : .Cols(14).TextAlign = TextAlignEnum.CenterCenter

        End With
        With fg2
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Aquamarine
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
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Nama" : .Cols(1).Name = "Nama" : .Cols(1).Width = 200 : .Cols(1).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nik" : .Cols(2).Name = "Nik" : .Cols(2).Width = 100 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Jabatan" : .Cols(3).Name = "Jabatan" : .Cols(3).Width = 150 : .Cols(3).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Tanggal" : .Cols(4).Name = "Tanggal" : .Cols(4).Width = 120 : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Absen" : .Cols(5).Name = "Absen" : .Cols(5).Width = 80 : .Cols(5).TextAlign = TextAlignEnum.CenterCenter
        End With
    End Sub
    Private Sub GetDataHeader()
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "  SELECT DISTINCT HeaderID,StatusTk,Nik,Nama,Departemen,JabatanName,TglAwal,TglAkhir,NamaTidakKerja,Keterangan,CreateBy,CreateDate,Computer,ComputerDate " &
                " ,ApproveByDept,ApproveByDeptDate ,ApproveByPSN,ApproveByPSNDate FROM vwTrnCutiIzin WHERE DeptID ='" & cboDepartemen.SelectedValue & "' and Complete=1 and ApproveByDept is null Order By Nik,TglAwal,TglAkhir "

        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg1.Rows.Count = 1
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg1
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "HeaderID") = DR!HeaderID
                            .Item(i, "StatusTk") = DR!StatusTk
                            .Item(i, "Nik") = DR!Nik
                            .Item(i, "Nama") = DR!Nama
                            .Item(i, "Departemen") = DR!Departemen
                            .Item(i, "TglMuali") = Format(DR!TglAwal, "dd/MM/yyyy")
                            .Item(i, "TglAkhir") = Format(DR!TglAkhir, "dd/MM/yyyy")
                            .Item(i, "Jenis") = DR!NamaTidakKerja
                            If IsDBNull(DR!CreateBy) = False Then .Item(i, "CreateBy") = DR!CreateBy
                            If IsDBNull(DR!CreateDate) = False Then .Item(i, "CreatedDate") = DR!CreateDate
                            If IsDBNull(DR!Computer) = False Then .Item(i, "Computer") = DR!Computer
                            If IsDBNull(DR!ComputerDate) = False Then .Item(i, "ComputerDate") = DR!ComputerDate
                            i = i + 1
                        End While
                    End With
                Else
                    fg1.Rows.Count = 1
                    fg1.Rows.Count = 2
                    MsgBox("Data Tidak Ditemukan!", MessageBoxIcon.Stop, "Stop")
                    Exit Sub
                End If
            End Using
        End Using
    End Sub
    Private Sub GetDataDetail(ByVal HeaderID As Long)
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "  SELECT HeaderID,StatusTk,Nik,Nama,Departemen,JabatanName,TglAwal,TglAkhir,Tanggal,NamaTidakKerja,Absen,Keterangan,CreateBy,CreateDate,Computer,ComputerDate " &
                " ,ApproveByDept,ApproveByDeptDate ,ApproveByPSN,ApproveByPSNDate FROM vwTrnCutiIzin WHERE HeaderID=" & HeaderID & " Order By Nik,Tanggal "

        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg2.Rows.Count = 1
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg2
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "Nama") = DR!NAMA
                            .Item(i, "Nik") = DR!NIK
                            If IsDBNull(DR!JabatanName) = False Then .Item(i, "Jabatan") = DR!JabatanName
                            If IsDBNull(DR!Tanggal) = False Then .Item(i, "Tanggal") = Format(DR!Tanggal, "dd/MM/yyyy")
                            If IsDBNull(DR!Absen) = False Then .Item(i, "Absen") = DR!Absen
                            i = i + 1
                        End While
                    End With
                Else
                    fg2.Rows.Count = 1
                    fg2.Rows.Count = 2
                    MsgBox("Data Tidak Ditemukan!", MessageBoxIcon.Stop, "Stop")
                    Exit Sub
                End If
            End Using
        End Using
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Trim(cboDepartemen.Text) = "" Then
            MsgBox("Departemen Belum Dipilih!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Call GetDataHeader()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fg1_Click(sender As Object, e As EventArgs) Handles fg1.Click

    End Sub

    Private Sub fg1_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg1.BeforeEdit
        With fg1
            Select Case .Cols(e.Col).Name
                Case "Approve", "KembaliKeADM"
                    e.Cancel = False
                Case Else
                    e.Cancel = True
            End Select
        End With
    End Sub

    Private Sub fg1_DoubleClick(sender As Object, e As EventArgs) Handles fg1.DoubleClick
        Try
            If Convert.ToDouble(fg1.Item(fg1.Row, "HeaderID")) > 0 Then
                Call GetDataDetail(fg1.Item(fg1.Row, "HeaderID"))
            Else
                fg2.Rows.Count = 1
                fg2.Rows.Count = 2
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub fg1_MouseMove(sender As Object, e As MouseEventArgs) Handles fg1.MouseMove
        Try
            If fg1.MouseRow > 0 Then
                Dim tip As String = "Double Clik Untuk Lihat Data Detail!"
                ToolTip1.SetToolTip(fg1, tip)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub fg1_AfterEdit(sender As Object, e As RowColEventArgs) Handles fg1.AfterEdit
        With fg1
            If .Item(e.Row, "Approve") = True Then
                .Item(e.Row, "KembaliKeADM") = False
            End If
            If .Item(e.Row, "KembaliKeADM") = True Then
                .Item(e.Row, "Approve") = False
            End If
        End With
    End Sub
    Private Sub Simpan()
        Dim i As Integer = 1
        Dim ListHeaderID As String = ""
        Dim ListHeaderIDDToADM As String = ""
        Try
            For i = 1 To fg1.Rows.Count - 1
                If fg1.Item(i, "Approve") = True Then
                    If ListHeaderID = "" Then
                        ListHeaderID = fg1.Item(i, "HeaderID")
                    Else
                        ListHeaderID = ListHeaderID & "," & fg1.Item(i, "HeaderID")
                    End If
                ElseIf fg1.Item(i, "KembaliKeADM") = True Then
                    If ListHeaderIDDToADM = "" Then
                        ListHeaderIDDToADM = fg1.Item(i, "HeaderID")
                    Else
                        ListHeaderIDDToADM = ListHeaderIDDToADM & "," & fg1.Item(i, "HeaderID")
                    End If
                End If
            Next
            If ListHeaderIDDToADM = "" And ListHeaderID = "" Then
                MsgBox("Tidak Ada Data Yang Akan Disimpan!", MessageBoxIcon.Warning)
                Exit Sub
            End If
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn
                .CommandType = CommandType.Text
                If ListHeaderID <> "" Then
                    .CommandText = "Update tblTrnCutiIzinHdr set ApproveByDept='" & UserLogin & "',ApproveByDeptDate=getdate() where HeaderID in (" & ListHeaderID & ") "
                    .ExecuteNonQuery()
                End If
                If ListHeaderIDDToADM <> "" Then
                    .CommandText = "Update tblTrnCutiIzinHdr set Complete=0,ApproveByDept=null,ApproveByDeptDate=null where HeaderID in (" & ListHeaderIDDToADM & ") "
                    .ExecuteNonQuery()
                End If
            End With
            MsgBox("Data Berhasil Diapprove", vbInformation, "Success")
            Call GetDataHeader()
            fg2.Rows.Count = 1
            fg2.Rows.Count = 2
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub chkTick_CheckedChanged(sender As Object, e As EventArgs) Handles chkTick.CheckedChanged
        If chkTick.Checked = True Then
            For i As Integer = 1 To fg1.Rows.Count - 1
                If Convert.ToDouble(fg1.Item(i, "HeaderID")) > 0 Then
                    fg1.Item(i, "Approve") = True
                End If
            Next
        Else
            For i As Integer = 1 To fg1.Rows.Count - 1
                If Convert.ToDouble(fg1.Item(i, "HeaderID")) > 0 Then
                    fg1.Item(i, "Approve") = False
                End If
            Next
        End If
    End Sub

    Private Sub btnSaveDevice_Click(sender As Object, e As EventArgs) Handles btnSaveDevice.Click
        Me.Cursor = Cursors.WaitCursor
        Call Simpan()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCloseDevice_Click(sender As Object, e As EventArgs) Handles btnCloseDevice.Click
        Me.Close()
    End Sub
End Class