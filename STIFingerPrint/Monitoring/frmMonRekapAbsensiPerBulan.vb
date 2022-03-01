Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class frmMonRekapAbsensiPerBulan : Inherits DockContent
    Dim isLiburNasional As Boolean = False
    Private Sub frmMonRekapAbsensiPerBulan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtPeriode1.Value = Now
        Call SetPeriode2(dtPeriode1, dtPeriode2)
        Call SetGridDefult()
        Call GetStatusTK(cboStatus)
        Call GetDepartemenAksesn(cboDepartemen)
    End Sub

    Private Sub SetGridDefult()
        Dim txt As CellRange
        Dim kolom As Integer = 0
        With fg1
            .Styles.Alternate.BackColor = Color.White
            .Styles.Fixed.BackColor = Color.Aquamarine
            .Styles.Fixed.ForeColor = Color.Black
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .BorderStyle = Util.BaseControls.BorderStyleEnum.None
            .Styles.Normal.WordWrap = True
            .SelectionMode = SelectionModeEnum.Row
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = False
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 35
            .Cols.Frozen = 5
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 30
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "UserID" : .Cols(1).Name = "UserID" : .Cols(1).Width = 60 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama" : .Cols(2).Name = "Nama" : .Cols(2).Width = 150
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "NIK" : .Cols(3).Name = "Nik" : .Cols(3).Width = 60 : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Departemen" : .Cols(4).Name = "Departemen" : .Cols(4).Width = 110 : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Jabatan" : .Cols(5).Name = "Jabatan" : .Cols(5).Width = 110 : .Cols(5).TextAlign = TextAlignEnum.CenterCenter
            Dim Tgl1, Tgl2 As Date
            If dtPeriode1.Value.Day <= 25 Then
                Tgl1 = CDate("26/" & Format(DateAdd("m", -1, dtPeriode1.Value), "MM/yyyy"))
                Tgl2 = DateAdd("d", -1, DateAdd("m", 1, Tgl1))
            Else
                Tgl1 = CDate("26/" & Format(DateAdd("m", 1, dtPeriode1.Value), "MM/yyyy"))
                Tgl2 = DateAdd("d", -1, DateAdd("m", 1, Tgl1))
            End If
            While Tgl1 <= Tgl2
                .Cols.Count = .Cols.Count + 1
                kolom = .Cols.Count - 1
                txt = .GetCellRange(0, kolom, 0, kolom) : txt.Data = Format(Tgl1, "dd") : .Cols(kolom).Name = Format(Tgl1, "yyyy-MM-dd") : .Cols(kolom).Width = 30 : .Cols(kolom).TextAlign = TextAlignEnum.CenterCenter
                If Weekday(Tgl1) = 1 Then
                    Call StyleBackColor(fg1, Color.OrangeRed, 0, kolom, kolom)
                End If
                isLiburNasional = GetLiburNasional(Tgl1)
                If isLiburNasional = 1 Then
                    Call StyleBackColor(fg1, Color.YellowGreen, 0, kolom, kolom)
                End If
                Tgl1 = DateAdd(DateInterval.Day, 1, Tgl1)
            End While
        End With
        With fg2
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Aquamarine
            .Styles.Fixed.ForeColor = Color.Black
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .BorderStyle = Util.BaseControls.BorderStyleEnum.None
            .Styles.Normal.WordWrap = True
            .SelectionMode = SelectionModeEnum.Row
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = False
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 35
            .Cols.Frozen = 0
            .Cols.Count = 3
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Tanggal" : .Cols(1).Name = "Tanggal" : .Cols(1).Width = 80 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Status" : .Cols(2).Name = "Status" : .Cols(2).Width = 100 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
        End With
        Call GetAbsenBelumKomplet()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Trim(cboStatus.Text) = "" Then
            MsgBox("Status Silakan Pilih Terlebih Dahulu!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        If Trim(cboDepartemen.Text) = "" Then
            MsgBox("Departemen Silakan Pilih Terlebih Dahulu!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Call GetDataTakAbsen()
        Call GetAbsenBelumKomplet()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dtPeriode1_ValueChanged(sender As Object, e As EventArgs) Handles dtPeriode1.ValueChanged
        SetGridDefult()
    End Sub

    Private Sub GetDataTakAbsen()
        Dim sql As String = ""
        Dim i As Integer = 0
        Dim UserID As Long = 0
        Dim Sts As String = ""
        If cboStatus.SelectedValue = 1 Then
            Sts = "KARYAWAN"
        Else
            Sts = "HARIAN"
        End If
        Try
            sql = "select * from vwAbsensiKry WHERE PeriodeBln='" & Format(dtPeriode1.Value, "yyyy-MM-dd") & "'  and DeptID='" & cboDepartemen.SelectedValue & "' AND StatusTk='" & Sts & "'  "
            If Trim(txtNikNama.Text) <> "" Then
                sql = sql & " and Nik='" & Trim(txtNikNama.Text) & "' Or Nama Like '%" & Trim(txtNikNama.Text) & "%' "
            End If
            sql = sql & " Order by NAMA,UserID,PeriodeTgl,Departemen"
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                fg1.Rows.Count = 1
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        With fg1
                            While DR.Read
                                If UserID <> DR!UserID Then
                                    .AddItem("")
                                    UserID = DR!UserID
                                    i = .Rows.Count - 1
                                    .Item(i, "No") = i
                                    If IsDBNull(DR!UserID) = False Then .Item(i, "UserID") = DR!UserID
                                    If IsDBNull(DR!NIK) = False Then .Item(i, "NIK") = DR!NIK
                                    If IsDBNull(DR!NAMA) = False Then .Item(i, "NAMA") = DR!NAMA
                                    If IsDBNull(DR!Departemen) = False Then .Item(i, "Departemen") = DR!Departemen
                                    If IsDBNull(DR!JabatanName) = False Then .Item(i, "Jabatan") = DR!JabatanName
                                End If
                                .Item(i, Format(DR!PeriodeTgl, "yyyy-MM-dd")) = DR!AbsenStr
                                Dim kolIndex As Integer = .Cols(Format(DR!PeriodeTgl, "yyyy-MM-dd")).Index
                                Select Case DR!AbsenStr
                                    Case "IM"
                                        StyleForeColor(fg1, Color.Red, i, kolIndex, kolIndex, True)
                                    Case "L"
                                        StyleForeColor(fg1, Color.Red, i, kolIndex, kolIndex, True)
                                    Case "A"
                                        StyleForeColor(fg1, Color.Red, i, kolIndex, kolIndex, True)
                                End Select
                            End While
                        End With
                    Else
                        fg1.Rows.Count = 1
                        fg1.Rows.Count = 2
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetAbsenBelumKomplet()
        Dim Tgl1, Tgl2 As Date
        fg2.Rows.Count = 1
        If dtPeriode1.Value.Day <= 25 Then
            Tgl1 = CDate("26/" & Format(DateAdd("m", -1, dtPeriode1.Value), "MM/yyyy"))
            Tgl2 = DateAdd("d", -1, DateAdd("m", 1, Tgl1))
        Else
            Tgl1 = CDate("26/" & Format(DateAdd("m", -1, dtPeriode1.Value), "MM/yyyy"))
            Tgl2 = DateAdd("d", -1, DateAdd("m", 1, Tgl1))
        End If
        While Tgl1 <= Tgl2
            fg2.AddItem("")
            fg2.Item(fg2.Rows.Count - 1, "No") = fg2.Rows.Count - 1
            fg2.Item(fg2.Rows.Count - 1, "Tanggal") = Format(Tgl1, "dd/MM/yyyy")
            Tgl1 = DateAdd(DateInterval.Day, 1, Tgl1)
        End While
        Dim sql As String = ""
        Dim i As Integer = 1
        Dim Sts As String = ""
        If cboStatus.SelectedValue = 1 Then
            Sts = "KARYAWAN"
        Else
            Sts = "HARIAN"
        End If
        Me.Cursor = Cursors.WaitCursor
        sql = "select * from tblTrnAbsensiHdrKry where PeriodeBln='" & Format(dtPeriode1.Value, "yyyy-MM-dd") & "' and DeptID='" & cboDepartemen.SelectedValue & "' AND StatusTk='" & Sts & "'  Order By PeriodeTgl "
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0

            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg2
                        While DR.Read
                            For i = 1 To .Rows.Count - 1
                                If .Item(i, "Tanggal") = Format(DR!PeriodeTgl, "dd/MM/yyyy") Then
                                    Dim kolIndex As Integer = .Cols("Status").Index
                                    If IsDBNull(DR!CompleteStatus) = False Then
                                        If DR!CompleteStatus = True Then
                                            .Item(i, "Status") = "Complete"
                                            StyleForeColor(fg2, Color.Blue, i, kolIndex, kolIndex, True)
                                        Else
                                            .Item(i, "Status") = "Belum Complete"
                                            StyleForeColor(fg2, Color.Red, i, kolIndex, kolIndex, True)
                                        End If
                                    End If
                                End If
                            Next
                        End While
                    End With
                Else
                    fg1.Rows.Count = 1
                    fg1.Rows.Count = 2
                End If
            End Using
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCloseDevice_Click(sender As Object, e As EventArgs) Handles btnCloseDevice.Click
        Me.Close()
    End Sub

    Private Sub btnExecl_Click(sender As Object, e As EventArgs) Handles btnExecl.Click
        Me.Cursor = Cursors.WaitCursor
        Call ExportExcelInpoiFlexgrid(fg1, 0, 0, True, "Rakap Absensi 01" & Format(dtPeriode1.Value, "MMyyyy"))
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboStatus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboStatus.SelectionChangeCommitted

    End Sub
End Class