Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmTrnApproveAbsensiByDept : Inherits DockContent
    Private Sub FrmTrnApproveAbsensiByDept_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        dtPeriode1.Value = Now
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
            .Cols.Count = 14
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "AbsenHdrID" : .Cols(1).Name = "AbsenHdrID" : .Cols(1).Width = 100 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Approve" : .Cols(2).Name = "Approve" : .Cols(2).Width = 80 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).DataType = GetType(Boolean)
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Kembali Ke ADM" : .Cols(3).Name = "KembaliKeADM" : .Cols(3).Width = 80 : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).DataType = GetType(Boolean)
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Status Tk" : .Cols(4).Name = "StatusTk" : .Cols(4).Width = 150 : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Departemen" : .Cols(5).Name = "Departemen" : .Cols(5).Width = 200 : .Cols(5).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Tanggal" : .Cols(6).Name = "Tanggal" : .Cols(6).Width = 80 : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Complete Status" : .Cols(7).Name = "CompleteStatus" : .Cols(7).Width = 100 : .Cols(7).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Dibuat Oleh" : .Cols(8).Name = "CreateBy" : .Cols(8).Width = 100 : .Cols(8).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Dibuat Tanggal" : .Cols(9).Name = "CreatedDate" : .Cols(9).Width = 100 : .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Diubah Oleh" : .Cols(10).Name = "UpdatedBy" : .Cols(10).Width = 100 : .Cols(10).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Diubah Tangggal" : .Cols(11).Name = "UpdatedDate" : .Cols(11).Width = 100 : .Cols(11).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Komputer" : .Cols(12).Name = "Computer" : .Cols(12).Width = 100 : .Cols(12).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Komputer Tanggal" : .Cols(13).Name = "ComputerDate" : .Cols(13).Width = 100 : .Cols(13).TextAlign = TextAlignEnum.CenterCenter

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
            .Cols.Frozen = 4
            .Cols.Count = 19
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "UseriD" : .Cols(1).Name = "UseriD" : .Cols(1).Width = 60 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama" : .Cols(2).Name = "Nama" : .Cols(2).Width = 200 : .Cols(2).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nik" : .Cols(3).Name = "Nik" : .Cols(3).Width = 100 : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Jabatan" : .Cols(4).Name = "Jabatan" : .Cols(4).Width = 150 : .Cols(4).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Absen Masuk" : .Cols(5).Name = "AbsenMasuk" : .Cols(5).Width = 120 : .Cols(5).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Absen Ist Keluar" : .Cols(6).Name = "AbsenIstKeluar" : .Cols(6).Width = 120 : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Absen Ist Masuk" : .Cols(7).Name = "AbsenIstMasuk" : .Cols(7).Width = 120 : .Cols(7).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Absen Pulang" : .Cols(8).Name = "AbsenPulang" : .Cols(8).Width = 120 : .Cols(8).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Total Jam" : .Cols(9).Name = "TotalJam" : .Cols(9).Width = 80 : .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Lama Istirahat (Menit)" : .Cols(10).Name = "LamaIstirahat" : .Cols(10).Width = 80 : .Cols(10).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Total Jam Kerja" : .Cols(11).Name = "TotalJamKerja" : .Cols(11).Width = 80 : .Cols(11).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Absen Str" : .Cols(12).Name = "AbsenStr" : .Cols(12).Width = 80 : .Cols(12).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Lembur" : .Cols(13).Name = "Lembur" : .Cols(13).Width = 80 : .Cols(13).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Lambat Masuk Kerja" : .Cols(14).Name = "LambatMasukKerja" : .Cols(14).Width = 80 : .Cols(14).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Cepat Ist Kelur" : .Cols(15).Name = "CepatIstKeluar" : .Cols(15).Width = 80 : .Cols(15).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Lambat Ist Masuk" : .Cols(16).Name = "LambatIstMasuk" : .Cols(16).Width = 80 : .Cols(16).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Cepat Pulang" : .Cols(17).Name = "CepatPulang" : .Cols(17).Width = 80 : .Cols(17).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "Keterangan" : .Cols(18).Name = "Keterangan" : .Cols(18).Width = 150 : .Cols(18).TextAlign = TextAlignEnum.CenterCenter
        End With
    End Sub
    Private Sub GetDataHeader()
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "SELECT AbsenHdrID,StatusTk,a.DeptID,b.Departemen,PeriodeTgl,PeriodeBln,a.CreatedBy, " &
            " CASE WHEN a.CompleteStatus=1 THEN 'SUDAH KOMPLIT' ELSE 'BELUM KOMPLIT' END AS StatusComplete,a.CreatedDate,UpdatedBy,UpdatedDate,a.Computer,a.ComputerDate  " &
            " FROM tblTrnAbsensiHdrKry A JOIN vwMstDept b ON a.DeptID=b.DeptID where a.DeptID='" & cboDepartemen.SelectedValue & "' and a.PeriodeBln='" & Format(dtPeriode1.Value, "yyyy-MM-01") & "' and Approve1 is null Order By PeriodeTgl "

        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg1.Rows.Count = 1
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg1
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "AbsenHdrID") = DR!AbsenHdrID
                            .Item(i, "StatusTk") = DR!StatusTk
                            .Item(i, "Departemen") = DR!Departemen
                            .Item(i, "Tanggal") = Format(DR!PeriodeTgl, "dd/MM/yyyy")
                            .Item(i, "CompleteStatus") = DR!StatusComplete
                            If DR!StatusComplete = "BELUM KOMPLIT" Then
                                StyleForeColor(fg1, Color.Red, i, 7, 7, True)
                            Else
                                StyleForeColor(fg1, Color.Blue, i, 7, 7, True)
                            End If
                            .Item(i, "CreateBy") = DR!CreatedBy
                            .Item(i, "CreatedDate") = DR!CreatedDate
                            .Item(i, "UpdatedBy") = DR!UpdatedBy
                            .Item(i, "UpdatedDate") = DR!UpdatedDate
                            .Item(i, "Computer") = DR!Computer
                            .Item(i, "ComputerDate") = DR!ComputerDate
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

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Trim(cboDepartemen.Text) = "" Then
            MsgBox("Departemen Belum Dipilih!", vbCritical)
            Exit Sub
        End If
        fg2.Rows.Count = 1
        fg2.Rows.Count = 2
        Me.Cursor = Cursors.WaitCursor
        Call GetDataHeader()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub GetDataDetail(ByVal HeaderID As Long)
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "SELECT a.UserID,b.NAMA,b.NIK,JabatanName ,AbsenMasuk,AbsenKeluarIst,AbsenMasukIst,AbsenPulang,TotalJamAll,TotalJam,Istirahat,AbsenStr,Lembur " &
            " ,LambatMasukKerja,CepatIstKeluar,LambatMasukIstirahat,PulangCepat,Keterangan " &
            " FROM tblTrnAbsensiDtlKry A JOIN vwMstUser b ON a.UserID=B.UserID where a.AbsenHdrID='" & HeaderID & "' Order By NAMA"

        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg2.Rows.Count = 1
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg2
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "UseriD") = DR!UserID
                            .Item(i, "Nama") = DR!NAMA
                            .Item(i, "Nik") = DR!NIK
                            If IsDBNull(DR!JabatanName) = False Then .Item(i, "Jabatan") = DR!JabatanName
                            If IsDBNull(DR!AbsenMasuk) = False Then .Item(i, "AbsenMasuk") = Format(DR!AbsenMasuk, "dd/MM/yyyy HH:mm")
                            If IsDBNull(DR!AbsenKeluarIst) = False Then .Item(i, "AbsenIstKeluar") = Format(DR!AbsenKeluarIst, "dd/MM/yyyy HH:mm")
                            If IsDBNull(DR!AbsenMasukIst) = False Then .Item(i, "AbsenIstMasuk") = Format(DR!AbsenMasukIst, "dd/MM/yyyy HH:mm")
                            If IsDBNull(DR!AbsenPulang) = False Then .Item(i, "AbsenPulang") = Format(DR!AbsenPulang, "dd/MM/yyyy HH:mm")
                            If IsDBNull(DR!TotalJamAll) = False Then .Item(i, "TotalJam") = DR!TotalJamAll
                            If IsDBNull(DR!Istirahat) = False Then .Item(i, "LamaIstirahat") = DR!Istirahat
                            If IsDBNull(DR!TotalJam) = False Then .Item(i, "TotalJamKerja") = DR!TotalJam
                            If IsDBNull(DR!AbsenStr) = False Then .Item(i, "AbsenStr") = DR!AbsenStr
                            If IsDBNull(DR!Lembur) = False Then .Item(i, "Lembur") = DR!Lembur
                            If IsDBNull(DR!LambatMasukKerja) = False Then .Item(i, "LambatMasukKerja") = DR!LambatMasukKerja
                            If IsDBNull(DR!CepatIstKeluar) = False Then .Item(i, "CepatIstKeluar") = DR!CepatIstKeluar
                            If IsDBNull(DR!LambatMasukIstirahat) = False Then .Item(i, "LambatIstMasuk") = DR!LambatMasukIstirahat
                            If IsDBNull(DR!PulangCepat) = False Then .Item(i, "CepatPulang") = DR!PulangCepat
                            If IsDBNull(DR!Keterangan) = False Then .Item(i, "Keterangan") = DR!Keterangan
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

    Private Sub fg1_Click(sender As Object, e As EventArgs) Handles fg1.Click

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

    Private Sub btnCloseDevice_Click(sender As Object, e As EventArgs) Handles btnCloseDevice.Click
        Me.Close()
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
            If Convert.ToDouble(fg1.Item(fg1.Row, "AbsenHdrID")) > 0 Then
                Call GetDataDetail(fg1.Item(fg1.Row, "AbsenHdrID"))
            Else
                fg2.Rows.Count = 1
                fg2.Rows.Count = 2
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fg1_AfterEdit(sender As Object, e As RowColEventArgs) Handles fg1.AfterEdit
        With fg1
            If .Item(e.Row, "Approve") = True Then
                .Item(e.Row, "KembaliKeADM") = False
                If .Item(e.Row, "CompleteStatus") = "BELUM KOMPLIT" Then
                    .Item(e.Row, "Approve") = False
                    MsgBox("Abensi Belum Dikomplit ADM!", MessageBoxIcon.Stop, "Stop")
                    Exit Sub
                End If
            End If
            If .Item(e.Row, "KembaliKeADM") = True Then
                .Item(e.Row, "Approve") = False
                If .Item(e.Row, "CompleteStatus") = "BELUM KOMPLIT" Then
                    .Item(e.Row, "KembaliKeADM") = False
                    MsgBox("Abensi Belum Dikomplit ADM!", MessageBoxIcon.Stop, "Stop")
                    Exit Sub
                End If
            End If

        End With
    End Sub

    Private Sub chkTick_CheckedChanged(sender As Object, e As EventArgs) Handles chkTick.CheckedChanged
        If chkTick.Checked = True Then
            For i As Integer = 1 To fg1.Rows.Count - 1
                If Convert.ToDouble(fg1.Item(i, "AbsenHdrID")) > 0 Then
                    fg1.Item(i, "Approve") = True
                End If
            Next
        Else
            For i As Integer = 1 To fg1.Rows.Count - 1
                If Convert.ToDouble(fg1.Item(i, "AbsenHdrID")) > 0 Then
                    fg1.Item(i, "Approve") = False
                End If
            Next
        End If
    End Sub

    Private Sub Simpan()
        Dim i As Integer = 1
        Dim ListAbsenHdrID As String = ""
        Dim ListAbsenHdrIDToADM As String = ""
        Try
            For i = 1 To fg1.Rows.Count - 1
                If fg1.Item(i, "Approve") = True Then
                    If ListAbsenHdrID = "" Then
                        ListAbsenHdrID = fg1.Item(i, "AbsenHdrID")
                    Else
                        ListAbsenHdrID = ListAbsenHdrID & "," & fg1.Item(i, "AbsenHdrID")
                    End If
                ElseIf fg1.Item(i, "KembaliKeADM") = True Then
                    If ListAbsenHdrIDToADM = "" Then
                        ListAbsenHdrIDToADM = fg1.Item(i, "AbsenHdrID")
                    Else
                        ListAbsenHdrIDToADM = ListAbsenHdrIDToADM & "," & fg1.Item(i, "AbsenHdrID")
                    End If
                End If
            Next
            If ListAbsenHdrIDToADM = "" And ListAbsenHdrID = "" Then
                MsgBox("Tidak Ada Data Yang Akan Disimpan!", MessageBoxIcon.Warning)
                Exit Sub
            End If
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn
                .CommandType = CommandType.Text
                If ListAbsenHdrID <> "" Then
                    .CommandText = "Update tblTrnAbsensiHdrKry set Approve1='" & UserLogin & "',Approve1Date=getdate() where AbsenHdrID in (" & ListAbsenHdrID & ") "
                    .ExecuteNonQuery()
                End If
                If ListAbsenHdrIDToADM <> "" Then
                    .CommandText = "Update tblTrnAbsensiHdrKry set CompleteStatus=0,Approve1=null,Approve1Date=null where AbsenHdrID in (" & ListAbsenHdrIDToADM & ") "
                    .ExecuteNonQuery()
                End If
            End With
            MsgBox("Absensi Berhasil Diapprove", vbInformation, "Success")
            Call GetDataHeader()
            fg2.Rows.Count = 1
            fg2.Rows.Count = 2
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSaveDevice_Click(sender As Object, e As EventArgs) Handles btnSaveDevice.Click
        Me.Cursor = Cursors.WaitCursor
        Call Simpan()
        Me.Cursor = Cursors.Default
    End Sub
End Class