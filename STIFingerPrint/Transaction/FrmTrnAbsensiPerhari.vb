Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmTrnAbsensiPerhari : Inherits DockContent
    Dim Tanggal As Date
    Dim isLiburNasional As Boolean = False
    Dim isComplete As Boolean = False
    Dim UbahAbsensi As Boolean = False
    Dim RowEdited As Integer
    Dim Perintah As String = ""
    Dim StatusTK As String
    Dim CutiIzin, CutiIzinKeterangan As String
    Dim TglJamMasukGet, TglJamIstOutGet, TglJamIstInGet, TglJamPulangGet As String
    Private Sub btnCloseDevice_Click(sender As Object, e As EventArgs) Handles btnCloseDevice.Click
        Me.Close()
    End Sub
    Private Sub SetGridDefult()
        Dim txt As CellRange
        With fg
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
            .Cols.Frozen = 3
            .Cols.Count = 36
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "UserID" : .Cols(1).Name = "UserID" : .Cols(1).Width = 60 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama" : .Cols(2).Name = "Nama" : .Cols(2).Width = 200
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "NIK" : .Cols(3).Name = "Nik" : .Cols(3).Width = 60 : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Departemen" : .Cols(4).Name = "Departemen" : .Cols(4).Width = 150 : .Cols(4).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Jabatan" : .Cols(5).Name = "Jabatan" : .Cols(5).Width = 150 : .Cols(5).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Tanggal" : .Cols(6).Name = "Tanggal" : .Cols(6).Width = 70 : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "DetailID" : .Cols(7).Name = "DetailID" : .Cols(7).Width = 100 : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Dinas Masuk" : .Cols(8).Name = "DinasMasuk" : .Cols(8).Width = 50 : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).Visible = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Masuk" : .Cols(9).Name = "Masuk" : .Cols(9).Width = 50 : .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Ist.Out" : .Cols(10).Name = "IstOut" : .Cols(10).Width = 50 : .Cols(10).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Ist.In" : .Cols(11).Name = "IstIn" : .Cols(11).Width = 50 : .Cols(11).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Pulang" : .Cols(12).Name = "Pulang" : .Cols(12).Width = 50 : .Cols(12).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Total Jam" : .Cols(13).Name = "TotalJam" : .Cols(13).Width = 50 : .Cols(13).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Istirahat  (Menit)" : .Cols(14).Name = "IstirahatMenit" : .Cols(14).Width = 50 : .Cols(14).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Tot.Jam Kerja" : .Cols(15).Name = "TotJam" : .Cols(15).Width = 50 : .Cols(15).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Lembur" : .Cols(16).Name = "Lembur" : .Cols(16).Width = 50 : .Cols(16).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Absensi" : .Cols(17).Name = "Absensi" : .Cols(17).Width = 50 : .Cols(17).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "AL/OT" : .Cols(18).Name = "ALOT" : .Cols(18).Width = 50 : .Cols(18).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "Shift" & vbCrLf & "Non Shift" : .Cols(19).Name = "ShiftNonShift" : .Cols(19).Width = 70 : .Cols(19).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "Lambat Masuk" & vbCrLf & "(Menit)" : .Cols(20).Name = "LambatMasuk" : .Cols(20).Width = 80 : .Cols(20).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "Cepat Ist Keluar" & vbCrLf & "(Menit)" : .Cols(21).Name = "CepatIstKeluar" : .Cols(21).Width = 85 : .Cols(21).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "Lambat Ist Masuk" & vbCrLf & "(Menit)" : .Cols(22).Name = "LambatIstirahat" : .Cols(22).Width = 85 : .Cols(22).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 23, 0, 23) : txt.Data = "Pulang Cepat" & vbCrLf & "(Menit)" : .Cols(23).Name = "PulangCepat" : .Cols(23).Width = 80 : .Cols(23).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 24, 0, 24) : txt.Data = "Keterangan" : .Cols(24).Name = "Keterangan" : .Cols(24).Width = 200 : .Cols(24).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 25, 0, 25) : txt.Data = "Dinas Istirahat Out" : .Cols(25).Name = "DinasIstOut" : .Cols(25).Width = 70 : .Cols(25).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 26, 0, 26) : txt.Data = "Dinas Istirahat In" : .Cols(26).Name = "DinasIstIn" : .Cols(26).Width = 60 : .Cols(26).TextAlign = TextAlignEnum.CenterCenter : .Cols(26).Visible = True
            txt = .GetCellRange(0, 27, 0, 27) : txt.Data = "LiburMingguan" : .Cols(27).Name = "LiburMingguan" : .Cols(27).Width = 50 : .Cols(27).TextAlign = TextAlignEnum.CenterCenter : .Cols(27).Visible = False
            txt = .GetCellRange(0, 28, 0, 28) : txt.Data = "JamKerja" : .Cols(28).Name = "JamKerja" : .Cols(28).Width = 50 : .Cols(28).TextAlign = TextAlignEnum.CenterCenter : .Cols(28).Visible = False
            txt = .GetCellRange(0, 29, 0, 29) : txt.Data = "Dinas Pulang" : .Cols(29).Name = "DinasPulang" : .Cols(29).Width = 50 : .Cols(29).TextAlign = TextAlignEnum.CenterCenter : .Cols(29).Visible = False
            txt = .GetCellRange(0, 30, 0, 30) : txt.Data = "TglJamMasuk" : .Cols(30).Name = "TglJamMasuk" : .Cols(30).Width = 50 : .Cols(30).TextAlign = TextAlignEnum.CenterCenter : .Cols(30).Visible = False
            txt = .GetCellRange(0, 31, 0, 31) : txt.Data = "TglJamIstOut" : .Cols(31).Name = "TglJamIstOut" : .Cols(31).Width = 50 : .Cols(31).TextAlign = TextAlignEnum.CenterCenter : .Cols(31).Visible = False
            txt = .GetCellRange(0, 32, 0, 32) : txt.Data = "TglJamIstIn" : .Cols(32).Name = "TglJamIstIn" : .Cols(32).Width = 50 : .Cols(32).TextAlign = TextAlignEnum.CenterCenter : .Cols(32).Visible = False
            txt = .GetCellRange(0, 33, 0, 33) : txt.Data = "TglJamPulang" : .Cols(33).Name = "TglJamPulang" : .Cols(33).Width = 50 : .Cols(33).TextAlign = TextAlignEnum.CenterCenter : .Cols(33).Visible = False
            txt = .GetCellRange(0, 34, 0, 34) : txt.Data = "GroupAbsenID" : .Cols(34).Name = "GroupAbsenID" : .Cols(34).Width = 50 : .Cols(34).TextAlign = TextAlignEnum.CenterCenter : .Cols(34).Visible = False
            txt = .GetCellRange(0, 35, 0, 35) : txt.Data = "ShiftID" : .Cols(35).Name = "ShiftID" : .Cols(35).Width = 50 : .Cols(35).TextAlign = TextAlignEnum.CenterCenter : .Cols(35).Visible = False
        End With
    End Sub
    Private Sub PindahData(ByVal baris As Integer)
        With fg
            Call ClearetxtEdit()
            If Convert.ToDouble(.Item(baris, "UserID")) > 0 Then
                RowEdited = baris
                txtDetailID.Text = .Item(baris, "DetailID")
                txtUserID.Text = .Item(baris, "UserID")
                txtNik.Text = .Item(baris, "Nik")
                txtNama.Text = .Item(baris, "Nama")
                txtDepartemen.Text = .Item(baris, "Departemen")
                txtJabatan.Text = .Item(baris, "Jabatan")
                txtTanggal.Text = .Item(baris, "Tanggal")
                If IsNothing(.Item(baris, "TglJamMasuk")) = False Then cboJamMasuk.Text = .Item(baris, "TglJamMasuk")
                If IsNothing(.Item(baris, "TglJamIstOut")) = False Then cboIstOut.Text = .Item(baris, "TglJamIstOut")
                If IsNothing(.Item(baris, "TglJamIstIn")) = False Then cboIstIn.Text = .Item(baris, "TglJamIstIn")
                If IsNothing(.Item(baris, "TglJamPulang")) = False Then cboJamPulang.Text = .Item(baris, "TglJamPulang")

                If IsNothing(.Item(baris, "DinasMasuk")) = False Then cboDinasMasuk.Text = txtTanggal.Text & " " & .Item(baris, "DinasMasuk")
                If IsNothing(.Item(baris, "DinasIstOut")) = False Then cboDinasIstOut.Text = txtTanggal.Text & " " & .Item(baris, "DinasIstOut")
                If IsNothing(.Item(baris, "DinasIstIn")) = False Then cboDinasIst.Text = txtTanggal.Text & " " & .Item(baris, "DinasIstIn")
                If IsNothing(.Item(baris, "DinasPulang")) = False Then txtDinasPulang.Text = txtTanggal.Text & " " & .Item(baris, "DinasPulang")
                txtGroupAbsen.Text = .Item(baris, "GroupAbsenID")
                If IsDBNull(.Item(baris, "ShiftID")) = False Then txtShiftID.Text = .Item(baris, "ShiftID")

                If IsNothing(.Item(baris, "TotalJam")) = False Then txtTotalJamAll.Text = .Item(baris, "TotalJam")
                If IsNothing(.Item(baris, "IstirahatMenit")) = False Then txtIstMenit.Text = .Item(baris, "IstirahatMenit")
                If IsNothing(.Item(baris, "TotJam")) = False Then txtTotalJamKerja.Text = .Item(baris, "TotJam")
                If IsNothing(.Item(baris, "Absensi")) = False Then txtAbsenStr.Text = .Item(baris, "Absensi")
                If IsNothing(.Item(baris, "LambatMasuk")) = False Then txtLambatIn.Text = .Item(baris, "LambatMasuk")
                If IsNothing(.Item(baris, "CepatIstKeluar")) = False Then txtCepatIstOut.Text = .Item(baris, "CepatIstKeluar")
                If IsNothing(.Item(baris, "LambatIstirahat")) = False Then txtLambatIstIn.Text = .Item(baris, "LambatIstirahat")
                If IsNothing(.Item(baris, "PulangCepat")) = False Then txtCepatOut.Text = .Item(baris, "PulangCepat")
                If IsNothing(.Item(baris, "LiburMingguan")) = False Then lblLiburMingguan.Text = .Item(baris, "LiburMingguan")
                If IsNothing(.Item(baris, "JamKerja")) = False Then lblJamKerjaPanjangPendek.Text = .Item(baris, "JamKerja")
                If IsNothing(.Item(baris, "ALOT")) = False Then lblAlOT.Text = .Item(baris, "ALOT")
                If IsNothing(.Item(baris, "Keterangan")) = False Then txtKeterangan.Text = .Item(baris, "Keterangan")
            End If
        End With
    End Sub
    Private Sub FrmTrnAbsensiPerhari_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        dtPeriode1.Value = Now
        Call SetPeriode(dtPeriode1, dtPeriode2, cboTanggal)
        Call GetDepartemenAksesn(cboDepartemen)
        Call GetStatusTK(cboStatus)
        Call EnableBtn(False)
        Call EnableTxtEdit(False)
    End Sub
    Private Sub GetAbsensiBelumDisimpan()
        Dim sql As String = ""
        Dim i As Integer = 0
        Dim UserID As Long = 0
        Dim ListUserID As String = ""
        Try
            For j As Integer = 1 To fg.Rows.Count - 1
                If Convert.ToDouble(fg.Item(j, "UserID")) > 0 Then
                    If ListUserID = "" Then
                        ListUserID = fg.Item(j, "UserID")
                    Else
                        ListUserID = ListUserID & "," & fg.Item(j, "UserID")
                    End If
                End If
            Next
            If ListUserID = "" Then
                ListUserID = "''"
                fg.Rows.Count = 1
                fg.Rows.Count = 2
            End If
            sql = "Select * FROM STISidikjari.dbo.vwTrnImportHistory where PeriodeTgl='" & Format(Tanggal, "yyyy-MM-dd") & "' and StatusTK='" & StatusTK & "' and DeptID='" & cboDepartemen.SelectedValue & "' "
            If Trim(ListUserID) <> "" Then
                sql = sql & " AND UserID NOT IN(" & ListUserID & ") "
            End If
            If Trim(txtNikNama.Text) <> "" Then
                sql = sql & " and NIK='" & Trim(txtNikNama.Text) & "' or Nama like'" & Trim(txtNikNama.Text) & "' "
            End If
            sql = sql & " Order By NAMA,UserID,TglJam "
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        With fg
                            While DR.Read
                                If IsNothing(.Item(1, "UserID")) = True Then
                                    .Rows.Count = 1
                                End If
                                If UserID <> DR!UserID Then
                                    .AddItem("")
                                    UserID = DR!UserID
                                    i = .Rows.Count - 1
                                    Call GetAbsenKosong(DR!UserID)
                                End If
                                .Item(i, "No") = i
                                .Item(i, "UserID") = DR!UserID
                                .Item(i, "NIK") = DR!NIK
                                .Item(i, "NAMA") = DR!NAMA
                                .Item(i, "Departemen") = DR!Departemen
                                .Item(i, "Jabatan") = DR!JabatanName
                                .Item(i, "Tanggal") = Format(DR!PeriodeTgl, "dd/MM/yyyy")

                                If IsDBNull(DR!GroupAbsenID) = False Then
                                    If DR!GroupAbsenID > 0 Then 'NON SHIFT
                                        .Item(i, "DinasMasuk") = DR!JamMasuk
                                        .Item(i, "DinasPulang") = DR!JamPulang
                                        Select Case DR!CICO
                                            Case "CI"
                                                If IsNothing(.Item(i, "Masuk")) = True Then
                                                    .Item(i, "Masuk") = Format(DR!TglJam, "HH:mm")
                                                    .Item(i, "TglJamMasuk") = Format(DR!TglJam, "dd/MM/yyyy HH:mm")
                                                End If
                                            Case "BO"
                                                .Item(i, "IstOut") = Format(DR!TglJam, "HH:mm")
                                                .Item(i, "TglJamIstOut") = Format(DR!TglJam, "dd/MM/yyyy HH:mm")
                                            Case "BI"
                                                .Item(i, "IstIn") = Format(DR!TglJam, "HH:mm")
                                                .Item(i, "TglJamIstIn") = Format(DR!TglJam, "dd/MM/yyyy HH:mm")
                                            Case "CO"
                                                .Item(i, "Pulang") = Format(DR!TglJam, "HH:mm")
                                                .Item(i, "TglJamPulang") = Format(DR!TglJam, "dd/MM/yyyy HH:mm")
                                        End Select

                                        If IsNothing(.Item(i, "Masuk")) = True And TglJamMasukGet <> "" Then
                                            .Item(i, "Masuk") = Format(CDate(TglJamMasukGet), "HH:mm")
                                            .Item(i, "TglJamMasuk") = Format(CDate(TglJamMasukGet), "dd/MM/yyyy HH:mm")
                                        End If
                                        If IsNothing(.Item(i, "IstOut")) = True And TglJamIstOutGet <> "" Then
                                            .Item(i, "IstOut") = Format(CDate(TglJamIstOutGet), "HH:mm")
                                            .Item(i, "TglJamIstOut") = Format(CDate(TglJamIstOutGet), "dd/MM/yyyy HH:mm")
                                        End If
                                        If IsNothing(.Item(i, "IstIn")) = True And TglJamIstInGet <> "" Then
                                            .Item(i, "IstIn") = Format(CDate(TglJamIstInGet), "HH:mm")
                                            .Item(i, "TglJamIstIn") = Format(CDate(TglJamIstInGet), "dd/MM/yyyy HH:mm")
                                        End If
                                        If IsNothing(.Item(i, "Pulang")) = True And TglJamPulangGet <> "" Then
                                            .Item(i, "Pulang") = Format(CDate(TglJamPulangGet), "HH:mm")
                                            .Item(i, "TglJamPulang") = Format(CDate(TglJamPulangGet), "dd/MM/yyyy HH:mm")
                                        End If

                                        .Item(i, "ShiftNonShift") = "NON SHIFT"
                                        If Weekday(Tanggal) = 6 Then
                                            If IsDBNull(DR!LamaIstirahatJumat) = False Then .Item(i, "IstirahatMenit") = DR!LamaIstirahatJumat
                                        ElseIf Weekday(Tanggal) = 7 Then
                                            .Item(i, "IstirahatMenit") = 0
                                        Else
                                            If IsDBNull(DR!LamaIstirahatNormal) = False Then .Item(i, "IstirahatMenit") = DR!LamaIstirahatNormal
                                        End If


                                        If Weekday(Tanggal) = 6 Then
                                            If IsDBNull(DR!JamIstirahatJumat) = False Then .Item(i, "DinasIstOut") = DR!JamIstirahatJumat
                                        Else
                                            If IsDBNull(DR!JamIstirahatNormal) = False Then .Item(i, "DinasIstOut") = DR!JamIstirahatNormal
                                        End If
                                        If Weekday(Tanggal) = 6 Then
                                            If IsDBNull(DR!JamIstirahatJumat) = False Then .Item(i, "DinasIstIn") = Format(DateAdd(DateInterval.Minute, DR!LamaIstirahatJumat, Format(Tanggal, "dd/MM/yyyy") & " " & DR!JamIstirahatJumat), "HH:mm")
                                        Else
                                            If IsDBNull(DR!JamIstirahatNormal) = False Then .Item(i, "DinasIstIn") = Format(DateAdd(DateInterval.Minute, DR!LamaIstirahatNormal, Format(Tanggal, "dd/MM/yyyy") & " " & DR!JamIstirahatNormal), "HH:mm")
                                        End If
                                        If Weekday(Tanggal) = 6 Then
                                            .Item(i, "JamKerja") = DR!JamKerjaPanjangJumat
                                        ElseIf Weekday(Tanggal) = 7 Then
                                            .Item(i, "JamKerja") = DR!JamKerjaPanjangSabtu
                                        Else
                                            .Item(i, "JamKerja") = DR!JamKerjaPanjangNormal
                                        End If
                                        .Item(i, "GroupAbsenID") = DR!GroupAbsenID
                                    Else '=========== SHIFT ================================================
                                        .Item(i, "GroupAbsenID") = 0
                                        Select Case DR!ICODE
                                            Case 1
                                                .Item(i, "Masuk") = Format(DR!TglJam, "HH:mm")
                                                .Item(i, "TglJamMasuk") = Format(DR!TglJam, "dd/MM/yyyy HH:mm")
                                            Case 2
                                                .Item(i, "IstOut") = Format(DR!TglJam, "HH:mm")
                                                .Item(i, "TglJamIstOut") = Format(DR!TglJam, "dd/MM/yyyy HH:mm")
                                            Case 3
                                                .Item(i, "IstIn") = Format(DR!TglJam, "HH:mm")
                                                .Item(i, "TglJamIstIn") = Format(DR!TglJam, "dd/MM/yyyy HH:mm")
                                            Case 4
                                                .Item(i, "Pulang") = Format(DR!TglJam, "HH:mm")
                                                .Item(i, "TglJamPulang") = Format(DR!TglJam, "dd/MM/yyyy HH:mm")
                                        End Select
                                        .Item(i, "ShiftNonShift") = "SHIFT"
                                        If DR!ICODE = 1 And IsDBNull(DR!ShiftKe) = False Then
                                            Select Case Val(DR!ShiftKe)
                                                Case 1
                                                    .Item(i, "DinasMasuk") = DR!Shift1_Masuk
                                                    .Item(i, "DinasIstOut") = DR!shift1_istout
                                                    .Item(i, "DinasIstIn") = DR!shift1_istin
                                                    .Item(i, "DinasPulang") = DR!Shift1_Pulang
                                                    If Weekday(Tanggal) = 6 Then
                                                        If IsDBNull(DR!Shift1_IstirahatPendek) = False Then .Item(i, "IstirahatMenit") = DR!Shift1_IstirahatPendek
                                                    ElseIf Weekday(Tanggal) = 7 Then
                                                        .Item(i, "IstirahatMenit") = 0
                                                    Else
                                                        If IsDBNull(DR!Shift1_Istirahat) = False Then .Item(i, "IstirahatMenit") = DR!Shift1_Istirahat
                                                    End If
                                                Case 2
                                                    .Item(i, "DinasMasuk") = DR!Shift2_Masuk
                                                    .Item(i, "DinasIstOut") = DR!shift2_istout
                                                    .Item(i, "DinasIstIn") = DR!shift2_istin
                                                    .Item(i, "DinasPulang") = DR!Shift2_Pulang
                                                    If Weekday(Tanggal) = 6 Then
                                                        If IsDBNull(DR!Shift2_IstirahatPendek) = False Then .Item(i, "IstirahatMenit") = DR!Shift2_IstirahatPendek
                                                    ElseIf Weekday(Tanggal) = 7 Then
                                                        .Item(i, "IstirahatMenit") = 0
                                                    Else
                                                        If IsDBNull(DR!Shift2_Istirahat) = False Then .Item(i, "IstirahatMenit") = DR!Shift2_Istirahat
                                                    End If
                                                Case 3
                                                    .Item(i, "DinasMasuk") = DR!Shift3_Masuk
                                                    .Item(i, "DinasIstOut") = DR!shift3_istout
                                                    .Item(i, "DinasIstIn") = DR!shift3_istin
                                                    .Item(i, "DinasPulang") = DR!Shift3_Pulang
                                                    If Weekday(Tanggal) = 6 Then
                                                        If IsDBNull(DR!Shift3_IstirahatPendek) = False Then .Item(i, "IstirahatMenit") = DR!Shift3_IstirahatPendek
                                                    ElseIf Weekday(Tanggal) = 7 Then
                                                        .Item(i, "IstirahatMenit") = 0
                                                    Else
                                                        If IsDBNull(DR!Shift3_Istirahat) = False Then .Item(i, "IstirahatMenit") = DR!Shift3_Istirahat
                                                    End If
                                            End Select

                                        End If
                                        If IsDBNull(DR!ShiftID) = False Then .Item(i, "ShiftID") = DR!ShiftID

                                        If Weekday(Tanggal) = 6 Then
                                            .Item(i, "JamKerja") = DR!JamKerjaPanjangJumat
                                        ElseIf Weekday(Tanggal) = 7 Then
                                            .Item(i, "JamKerja") = DR!JamKerjaPanjangSabtu
                                        Else
                                            .Item(i, "JamKerja") = DR!JamKerjaPanjangNormal
                                        End If
                                    End If
                                Else '======== BELUM SETTING JAM KERJA
                                    StyleBackColor(fg, Color.YellowGreen, i, 1, .Cols.Count - 1)
                                    StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                End If
                                If Weekday(Tanggal) = 7 Then 'HARI SABTU
                                    .Item(i, "DinasPulang") = "12:00"
                                End If
                                If IsDBNull(DR!LiburMingguan) = False Then .Item(i, "LiburMingguan") = DR!LiburMingguan
                                If IsDBNull(DR!StatusJamKerjaID) = False Then .Item(i, "ALOT") = UCase(DR!StatusJamKerjaID)
                                .Item(i, "TotalJam") = KeJam(.Item(i, "Masuk"), .Item(i, "Pulang"), .Item(i, "DinasMasuk"), Tanggal)
                                .Item(i, "TotJam") = MenitKeJam(KeMenit(.Item(i, "Masuk"), .Item(i, "Pulang"), .Item(i, "DinasMasuk"), Tanggal) - Val(.Item(i, "IstirahatMenit")))
                                If Val(.Item(i, "TotJam")) > Val(.Item(i, "JamKerja")) And .Item(i, "ALOT") = "OT" Then 'LEMBUR
                                    .Item(i, "Lembur") = Val(.Item(i, "TotJam")) - Val(.Item(i, "JamKerja"))
                                End If
                                If SelisihMenit(.Item(i, "DinasMasuk"), .Item(i, "Masuk")) > 5 Then
                                    .Item(i, "LambatMasuk") = SelisihMenit(.Item(i, "DinasMasuk"), .Item(i, "Masuk")) - 5 'DISPENSASI 5 MENIT
                                Else
                                    .Item(i, "LambatMasuk") = 0
                                End If
                                .Item(i, "LambatIstirahat") = SelisihMenit(.Item(i, "DinasIstIn"), .Item(i, "IstIn"))
                                .Item(i, "PulangCepat") = SelisihMenit(.Item(i, "Pulang"), .Item(i, "DinasPulang"))
                                .Item(i, "CepatIstKeluar") = SelisihMenit(.Item(i, "IstOut"), .Item(i, "DinasIstOut"))
                                If Weekday(Tanggal) = DR!LiburMingguan And Absen(i) = 0 Then
                                    .Item(i, "Absensi") = "IM"
                                Else
                                    If Convert.ToInt32(.Item(i, "GroupAbsenID")) > 0 Then 'NON SHIFT
                                        If Absen(i) = 4 Then
                                            If Weekday(Tanggal) = 6 Then 'HARI JUMAT
                                                .Item(i, "Absensi") = 7
                                            Else
                                                .Item(i, "Absensi") = 7
                                            End If
                                        ElseIf Absen(i) >= 2 And Absen(i) < 4 Then
                                            If Weekday(Tanggal) = 6 Then 'HARI JUMAT
                                                .Item(i, "Absensi") = 7
                                                .Item(i, "LambatMasuk") = 60
                                            ElseIf Weekday(Tanggal) = 7 Then 'HARI SABTU
                                                .Item(i, "Absensi") = 5
                                            Else
                                                .Item(i, "Absensi") = 7 'DIKURANG 1 JAM KARENA FINGER TIDAK 4 KALI
                                                .Item(i, "LambatMasuk") = 60
                                            End If
                                        Else
                                            If isLiburNasional = True Then
                                                .Item(i, "Absensi") = "L"
                                            Else
                                                .Item(i, "Absensi") = "A"
                                            End If
                                        End If
                                    Else
                                        If Absen(i) = 2 Then
                                            If Weekday(Tanggal) = 6 Then 'HARI JUMAT
                                                .Item(i, "Absensi") = 7
                                            ElseIf Weekday(Tanggal) = 7 Then 'HARI SABTU
                                                .Item(i, "Absensi") = 5
                                            Else
                                                .Item(i, "Absensi") = 7
                                            End If
                                        Else
                                            If isLiburNasional = True Then
                                                .Item(i, "Absensi") = "L"
                                            Else
                                                .Item(i, "Absensi") = "A"
                                            End If
                                        End If
                                    End If
                                End If
                                If IsNothing(.Item(i, "Absensi")) = False Then
                                    Select Case .Item(i, "Absensi").ToString
                                        Case "A"
                                            StyleFontBold(fg, i, 1, .Cols.Count - 1, False)
                                            StyleBackColor(fg, Color.Yellow, i, 9, 17)
                                            StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                        Case "IM"
                                            StyleFontBold(fg, i, 1, .Cols.Count - 1, False)
                                            StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                        Case "L"
                                            StyleFontBold(fg, i, 1, .Cols.Count - 1, False)
                                            StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                        Case Else
                                            StyleFontBold(fg, i, 1, .Cols.Count - 1, False)
                                    End Select
                                End If
                            End While
                        End With
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Trim(cboTanggal.Text) = "" Then
            MsgBox("Silakan Pilih Tanggal Terlebih Dahulu!", MessageBoxIcon.Stop, "Warning")
            Exit Sub
        End If

        If Tanggal > Now Then
            MsgBox("Sekarang Masih Tanggal : " & Format(Tanggal, "dd/MM/yyyy"), MessageBoxIcon.Stop, "Warning")
            Exit Sub
        End If
        If Trim(cboStatus.Text) = "" Then
            MsgBox("Status Belum Dipih!", MessageBoxIcon.Stop, "Warning")
            Exit Sub
        End If
        If Trim(cboDepartemen.Text) = "" Then
            MsgBox("Departemen Belum Dipih!", MessageBoxIcon.Stop, "Warning")
            Exit Sub
        End If
        isLiburNasional = GetLiburNasional(Tanggal)
        isComplete = CekKomplete()
        If isComplete = True Then
            MsgBox("Absensi Sudah Dikomplet, Silakan Kembalikan Absensi Untuk Membuka Ulang!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If cboStatus.SelectedValue = 1 Then
            StatusTK = "KARYAWAN"
        Else
            StatusTK = "HARIAN"
        End If
        Me.Cursor = Cursors.WaitCursor
        Call GetDataAbsenSudahDisimpan()
        Call GetAbsensiBelumDisimpan()
        Call GetDataTakAbsen()
        Perintah = "REFRESH"
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub GetDataTakAbsen()
        Dim sql As String = ""
        Dim i As Integer = 0
        Dim UserID As Long = 0
        Dim ListUserID As String = ""

        Try
            For j As Integer = 1 To fg.Rows.Count - 1
                If Convert.ToDouble(fg.Item(j, "UserID")) > 0 Then
                    If ListUserID = "" Then
                        ListUserID = fg.Item(j, "UserID")
                    Else
                        ListUserID = ListUserID & "," & fg.Item(j, "UserID")
                    End If
                End If
            Next
            If ListUserID = "" Then
                ListUserID = "''"
                fg.Rows.Count = 1
                fg.Rows.Count = 2
            End If
            sql = "select UserID,RegNo,NAMA,NIK,Departemen ,JabatanName,JamMasuk,JamPulang,JamIstirahatNormal,JamIstirahatJumat,LiburMingguan,StatusJamKerjaID " &
                ",LamaIstirahatJumat,LamaIstirahatNormal,GroupAbsenID,ShiftID from vwMstUser where TglKeluar Is NUll and TglMasuk<='" & Format(Tanggal, "yyyy-MM-dd") & "' and UserID Not In(" & ListUserID & ") and StatusTK='" & StatusTK & "' and DeptID='" & cboDepartemen.SelectedValue & "' "
            If Trim(txtNikNama.Text) <> "" Then
                sql = sql & " AND (NIK='" & Trim(txtNikNama.Text) & "' or NAMA like '%" & Trim(txtNikNama.Text) & "%') "
            End If
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        With fg
                            If IsNothing(.Item(1, "UserID")) = True Then
                                .Rows.Count = 1
                            End If
                            While DR.Read
                                If UserID <> DR!UserID Then
                                    .AddItem("")
                                    UserID = DR!UserID
                                    i = .Rows.Count - 1
                                End If
                                .Item(i, "No") = i
                                If IsDBNull(DR!UserID) = False Then .Item(i, "UserID") = DR!UserID
                                .Item(i, "NIK") = DR!NIK
                                .Item(i, "NAMA") = DR!NAMA
                                .Item(i, "Departemen") = DR!Departemen
                                .Item(i, "Jabatan") = DR!JabatanName
                                .Item(i, "Tanggal") = Format(Tanggal, "dd/MM/yyyy")
                                If IsDBNull(DR!JamMasuk) = False Then .Item(i, "DinasMasuk") = DR!JamMasuk
                                If IsDBNull(DR!LiburMingguan) = False Then .Item(i, "LiburMingguan") = DR!LiburMingguan
                                If IsDBNull(DR!StatusJamKerjaID) = False Then .Item(i, "ALOT") = UCase(DR!StatusJamKerjaID)
                                If IsDBNull(DR!GroupAbsenID) = False Then
                                    Select Case DR!GroupAbsenID
                                        Case 0
                                            .Item(i, "ShiftNonShift") = "SHIFT"
                                            .Item(i, "ShiftID") = DR!ShiftID
                                        Case Else
                                            .Item(i, "ShiftNonShift") = "NON SHIFT"
                                            .Item(i, "GroupAbsenID") = DR!GroupAbsenID
                                    End Select
                                    If Weekday(Tanggal) = DR!LiburMingguan Then
                                        .Item(i, "Absensi") = "IM"
                                        StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                    Else
                                        If isLiburNasional = True Then
                                            .Item(i, "Absensi") = "L"
                                            StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                        Else
                                            .Item(i, "Absensi") = "A"
                                            StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                        End If
                                    End If
                                Else
                                    .Item(i, "Absensi") = "A"
                                    StyleBackColor(fg, Color.YellowGreen, i, 1, .Cols.Count - 1)
                                    StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                End If
                                Call GetCutiIzin(DR!RegNo)
                                If CutiIzin <> "" Then
                                    .Item(i, "Absensi") = CutiIzin
                                    .Item(i, "Keterangan") = CutiIzinKeterangan
                                End If
                            End While
                        End With
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function SelisihMenit(ByVal JamAwal As String, ByVal JamAkhir As String) As Integer
        Dim ret As Integer = 0
        Dim JamAwal1, JamAkhir1 As DateTime
        Try
            If JamAwal <> "" And JamAkhir <> "" Then
                JamAwal1 = JamAwal : JamAkhir1 = JamAkhir
                ret = Int(DateDiff(DateInterval.Minute, JamAwal1, JamAkhir1))
            End If
            If ret < 0 Then
                ret = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return ret
    End Function
    Private Function Absen(ByVal baris As Integer) As Integer

        Dim Hit As Integer = 0
        With fg
            If IsNothing(.Item(baris, "Masuk")) = False Then
                Hit = 1
            End If
            If IsNothing(.Item(baris, "IstOut")) = False Then
                Hit = Hit + 1
            End If
            If IsNothing(.Item(baris, "IstIn")) = False Then
                Hit = Hit + 1
            End If
            If IsNothing(.Item(baris, "Pulang")) = False Then
                Hit = Hit + 1
            End If
        End With
        Return Hit
    End Function
    Private Function AbsenEdit() As Integer
        Dim Hit As Integer = 0
        If Trim(cboJamMasuk.Text) <> "" Then
            Hit = 1
        End If
        If Trim(cboIstOut.Text) <> "" Then
            Hit = Hit + 1
        End If
        If Trim(cboIstIn.Text) <> "" Then
            Hit = Hit + 1
        End If
        If Trim(cboJamPulang.Text) <> "" Then
            Hit = Hit + 1
        End If
        Return Hit
    End Function

    Private Sub dtPeriode1_ValueChanged(sender As Object, e As EventArgs) Handles dtPeriode1.ValueChanged
        Call SetPeriode(dtPeriode1, dtPeriode2, cboTanggal)
    End Sub

    Private Sub cboTanggal_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTanggal.SelectionChangeCommitted
        Tanggal = Format(CDate(cboTanggal.SelectedValue), "yyyy-MM-dd")
        fg.Rows.Count = 1
        fg.Rows.Count = 2
        txtHeaderID.Clear()
        Call ClearetxtEdit()
        Call EnableBtn(False)
        Call EnableTxtEdit(False)
        fg.Enabled = True
    End Sub

    Private Sub cboTanggal_TextUpdate(sender As Object, e As EventArgs) Handles cboTanggal.TextUpdate
        ValidCombo(cboTanggal)
    End Sub

    Private Sub EnableBtn(ByVal flag As Boolean)
        btnEUbah.Enabled = Not flag
        btnEHapus.Enabled = flag
        btnESimpan.Enabled = flag
        btnEBatal.Enabled = flag
    End Sub
    Private Sub EnableTxtEdit(ByVal flag As Boolean)
        txtNik.Enabled = False
        txtUserID.Enabled = False
        txtNama.Enabled = False
        txtDetailID.Enabled = False
        txtDepartemen.Enabled = False
        txtJabatan.Enabled = False
        txtTanggal.Enabled = False
        cboJamMasuk.Enabled = flag
        cboIstOut.Enabled = flag
        cboIstIn.Enabled = flag
        cboJamPulang.Enabled = flag
        cboDinasMasuk.Enabled = flag
        cboDinasIst.Enabled = flag
        cboDinasIstOut.Enabled = flag
        txtKeterangan.Enabled = flag
    End Sub
    Private Sub ClearetxtEdit()
        txtNik.Clear()
        txtUserID.Clear()
        txtNama.Clear()
        txtDetailID.Clear()
        txtDepartemen.Clear()
        txtJabatan.Clear()
        txtTanggal.Clear()

        cboJamMasuk.Text = String.Empty
        cboIstOut.Text = String.Empty
        cboIstIn.Text = String.Empty
        cboJamPulang.Text = String.Empty
        cboDinasMasuk.Text = String.Empty
        cboDinasIst.Text = String.Empty
        cboDinasIstOut.Text = String.Empty

        txtKeterangan.Clear()
        txtShiftID.Clear()
        txtGroupAbsen.Clear()
        txtAbsenStr.Clear()
        txtLambatIn.Clear()
        txtCepatIstOut.Clear()
        txtLambatIstIn.Clear()
        txtCepatOut.Clear()
        txtDinasPulang.Clear()
        lblLiburMingguan.Text = 0
        txtTotalJamAll.Clear()
        txtIstMenit.Clear()
        txtTotalJamKerja.Clear()
        lblJamKerjaPanjangPendek.Text = 0
        lblAlOT.Text = Nothing
    End Sub

    Private Sub btnEUbah_Click(sender As Object, e As EventArgs) Handles btnEUbah.Click
        If Trim(txtUserID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Diedit!", MessageBoxIcon.Stop, "Stop")
            Exit Sub
        End If
        If GetJamDinasMasuk() = True Then
            Call GetJamDinasIstirahat()
            Call GetJam()
            Call EnableBtn(True)
            Call EnableTxtEdit(True)
            fg.Enabled = False
            UbahAbsensi = True

            cboTanggal.Enabled = False
            cboStatus.Enabled = False
            cboDepartemen.Enabled = False
            btnRefresh.Enabled = False
            dtPeriode1.Enabled = False
            txtNikNama.Enabled = False
        End If

    End Sub

    Private Sub btnEHapus_Click(sender As Object, e As EventArgs) Handles btnEHapus.Click
        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Try
            If Trim(txtUserID.Text) = "" Then
                MsgBox("Tidak Ada Data Yang Akan Dihapus!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Trim(cboTanggal.Text) = "" Then
                MsgBox("Tanggal Tidak Boleh Kosong!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If MessageBox.Show("Anda Ingin Menghapus Absensi Nama : " & txtNama.Text & " ini?", "Delete", MessageBoxButtons.YesNo) = vbYes Then
                If Trim(txtDetailID.Text) <> "" Then
                    Call DeleteAbsenPerOrang(txtDetailID.Text)
                Else
                    If HapusAbsensiPerOrang(Koneksi, Transaksi) = False Then
                        MsgBox("Hapus Data Gagal!", vbCritical, "Failed")
                        Me.Cursor = Cursors.Default
                        Transaksi.Rollback()
                        Exit Sub
                    End If
                End If
                Transaksi.Commit()
                Me.Cursor = Cursors.Default
                Call EnableBtn(False)
                Call EnableTxtEdit(False)
                Call ClearetxtEdit()
                fg.Enabled = True
                UbahAbsensi = False

                cboTanggal.Enabled = True
                cboStatus.Enabled = True
                cboDepartemen.Enabled = True
                btnRefresh.Enabled = True
                dtPeriode1.Enabled = True
                txtNikNama.Enabled = True
                MsgBox("Absensi Berhasil Dihapus", MessageBoxIcon.Information, "Information")
            Else
                Transaksi.Rollback()
            End If
        Catch ex As Exception
            Transaksi.Rollback()
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function DeleteAbsenPerOrang(ByVal DetailID As Long) As Boolean
        Dim ret As Boolean = False
        Try
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn
                .CommandType = CommandType.Text
                .CommandText = "delete tblTrnAbsensiDtlKry where AbsenDtlID='" & DetailID & "' "
                .ExecuteNonQuery()
            End With
            ret = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return ret
    End Function

    Private Sub btnESimpan_Click(sender As Object, e As EventArgs) Handles btnESimpan.Click
        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Try
            Perintah = "SAVE EDIT"
            If Trim(txtUserID.Text) = "" Then
                MsgBox("Tidak Ada Data Yang Akan Disimpan!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Trim(cboTanggal.Text) = "" Then
                MsgBox("Tanggal Tidak Boleh Kosong!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor

            If Simpan(Koneksi, Transaksi) = False Then
                MsgBox("Simpan Data Header Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
                Me.Cursor = Cursors.Default
                Transaksi.Rollback()
                Exit Sub
            End If
            If Trim(txtHeaderID.Text) = "" Then
                MsgBox("Simpan Absensi Dibatalkan,Silakan Aplikasi Anda!", vbCritical, "Failed")
                Me.Cursor = Cursors.Default
                Transaksi.Rollback()
                Exit Sub
            End If

            If SimpanDtlEdit(Koneksi, Transaksi) = False Then
                MsgBox("Simpan Data Detail Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
                Me.Cursor = Cursors.Default
                Transaksi.Rollback()
                Exit Sub
            End If

            Transaksi.Commit()
            Call GetRefreshEdit()
            Me.Cursor = Cursors.Default
            Call EnableBtn(False)
            Call EnableTxtEdit(False)
            Call ClearetxtEdit()
            fg.Enabled = True
            UbahAbsensi = False

            cboTanggal.Enabled = True
            cboStatus.Enabled = True
            cboDepartemen.Enabled = True
            btnRefresh.Enabled = True
            dtPeriode1.Enabled = True
            txtNikNama.Enabled = True
        Catch ex As Exception
            Transaksi.Rollback()
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnEBatal_Click(sender As Object, e As EventArgs) Handles btnEBatal.Click
        Call EnableBtn(False)
        Call EnableTxtEdit(False)
        Call ClearetxtEdit()
        fg.Enabled = True
        UbahAbsensi = False

        cboTanggal.Enabled = True
        cboStatus.Enabled = True
        cboDepartemen.Enabled = True
        btnRefresh.Enabled = True
        dtPeriode1.Enabled = True
        txtNikNama.Enabled = True
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        Call PindahData(fg.Row)
    End Sub

    Private Function GetJamDinasMasuk() As Boolean
        Dim ret As Boolean
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim tgl, TglJam As Date
        dt.Clear()
        dt.Columns.Add("TglJam", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        cboDinasMasuk.ClearFields()
        ret = False
        Try

            If Val(txtGroupAbsen.Text) = 0 And Val(txtShiftID.Text) = 0 Then
                MsgBox("Nama : " & txtNama.Text & " Belum Setting Jam Kerja!", MessageBoxIcon.Stop, "Stop")
                Return ret
                Exit Function
            End If
            If Val(txtGroupAbsen.Text) > 0 Then
                sql = "select JamMasuk,JamPulang from tblMstGroupAbsen where GroupAbsenID='" & Val(txtGroupAbsen.Text) & "' "
            Else
                sql = "select Shift1_Masuk,Shift2_Masuk,Shift3_Masuk,* from tblMstShift where ShiftID='" & Val(txtShiftID.Text) & "' "
            End If
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        While DR.Read
                            If Val(txtGroupAbsen.Text) > 0 Then
                                TglJam = Tanggal & " " & DR!JamMasuk
                                dt.Rows.Add(CStr(Format(TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(TglJam, "dd/MM/yyyy HH:mm")))
                            Else
                                TglJam = Tanggal & " " & DR!Shift1_Masuk
                                dt.Rows.Add(CStr(Format(TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(TglJam, "dd/MM/yyyy HH:mm")))
                                TglJam = Tanggal & " " & DR!Shift2_Masuk
                                dt.Rows.Add(CStr(Format(TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(TglJam, "dd/MM/yyyy HH:mm")))
                                TglJam = Tanggal & " " & DR!Shift3_Masuk
                                dt.Rows.Add(CStr(Format(TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(TglJam, "dd/MM/yyyy HH:mm")))

                                tgl = DateAdd(DateInterval.Day, 1, Tanggal)
                                If DR!Shift1_Masuk = "00:00" Then dt.Rows.Add(CStr(Format(tgl & " " & DR!Shift1_Masuk, "dd/MM/yyyy HH:mm")), CStr(Format(tgl & " " & DR!Shift1_Masuk, "dd/MM/yyyy HH:mm")))
                                If DR!Shift2_Masuk = "00:00" Then dt.Rows.Add(CStr(Format(tgl & " " & DR!Shift2_Masuk, "dd/MM/yyyy HH:mm")), CStr(Format(tgl & " " & DR!Shift2_Masuk, "dd/MM/yyyy HH:mm")))
                                If DR!Shift1_Masuk = "00:00" Then dt.Rows.Add(CStr(Format(tgl & " " & DR!Shift3_Masuk, "dd/MM/yyyy HH:mm")), CStr(Format(tgl & " " & DR!Shift3_Masuk, "dd/MM/yyyy HH:mm")))
                            End If
                        End While
                        ret = True
                    Else
                        MsgBox("Nama : " & txtNama.Text & " Belum Setting Jam Kerja!", MessageBoxIcon.Stop, "Stop")
                        Return ret
                        Exit Function
                    End If
                End Using
                If dt.Rows.Count > 0 Then
                    cboDinasMasuk.DataSource = dt
                    cboDinasMasuk.DisplayMember = "TglJam"
                    cboDinasMasuk.ValueMember = "Value"
                    cboDinasMasuk.SelectedIndex = 0
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return ret
    End Function
    Private Sub GetJam()
        Dim sql As String = ""
        Dim tbMasuk, tbIstOut, tbIstIn, tbPulang As New DataTable

        tbMasuk.Clear()
        tbIstOut.Clear()
        tbIstIn.Clear()
        tbPulang.Clear()

        cboJamMasuk.ClearFields()
        cboIstOut.ClearFields()
        cboIstIn.ClearFields()
        cboJamPulang.ClearFields()

        tbMasuk.Columns.Add("TglJam", GetType(String))
        tbMasuk.Columns.Add("Value", GetType(String))

        tbIstOut.Columns.Add("TglJam", GetType(String))
        tbIstOut.Columns.Add("Value", GetType(String))

        tbIstIn.Columns.Add("TglJam", GetType(String))
        tbIstIn.Columns.Add("Value", GetType(String))

        tbPulang.Columns.Add("TglJam", GetType(String))
        tbPulang.Columns.Add("Value", GetType(String))

        Try
            If Trim(txtGroupAbsen.Text) <> "" Then
                sql = "select * from dbo.fnGetEditAbsensiNonShift ('" & txtUserID.Text & "','" & Format(Tanggal, "yyyy-MM-dd") & "') "
            Else
                sql = "SELECT DISTINCT CICO,CONVERT(smalldatetime,B.TglJam) AS TglJam FROM tblTrnImportHistory A RIGHT OUTER JOIN tblTrnTempLog B ON A.UserID=B.UserID AND A.TglJam=B.TglJam " &
                        " WHERE (CONVERT(DATETIME,B.TglJam) BETWEEN DATEADD(HOUR,-6,'" & Format(Tanggal, "yyyy-MM-dd") & "') AND DATEADD(HOUR,72,CONVERT(DATETIME,'" & Format(Tanggal, "yyyy-MM-dd") & "'))) AND B.UserID='" & txtUserID.Text & "'"
            End If
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        While DR.Read
                            If Val(txtGroupAbsen.Text) > 0 And IsDBNull(DR!CICO) = False Then
                                Select Case DR!CICO
                                    Case "CI"
                                        tbMasuk.Rows.Add(CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")))
                                    Case "BO"
                                        tbIstOut.Rows.Add(CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")))
                                    Case "BI"
                                        tbIstIn.Rows.Add(CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")))
                                    Case "CO"
                                        tbPulang.Rows.Add(CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")))
                                End Select
                            Else
                                tbMasuk.Rows.Add(CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")))
                                tbIstOut.Rows.Add(CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")))
                                tbIstIn.Rows.Add(CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")))
                                tbPulang.Rows.Add(CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")), CStr(Format(DR!TglJam, "dd/MM/yyyy HH:mm")))
                            End If
                        End While
                    End If
                End Using
            End Using
            If tbMasuk.Rows.Count > 0 Then
                cboJamMasuk.DataSource = tbMasuk
                cboJamMasuk.DisplayMember = "TglJam"
                cboJamMasuk.ValueMember = "Value"
                cboJamMasuk.SelectedIndex = 0
            End If

            If tbIstOut.Rows.Count > 0 Then
                cboIstOut.DataSource = tbIstOut
                cboIstOut.DisplayMember = "TglJam"
                cboIstOut.ValueMember = "Value"
                cboIstOut.SelectedIndex = 0
            End If

            If tbIstIn.Rows.Count > 0 Then
                cboIstIn.DataSource = tbIstIn
                cboIstIn.DisplayMember = "TglJam"
                cboIstIn.ValueMember = "Value"
                cboIstIn.SelectedIndex = 0
            End If

            If tbPulang.Rows.Count > 0 Then
                cboJamPulang.DataSource = tbPulang
                cboJamPulang.DisplayMember = "TglJam"
                cboJamPulang.ValueMember = "Value"
                cboJamPulang.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetJamDinasIstirahat()
        Dim sql As String = ""
        Dim tb, tbl2 As New DataTable
        Dim TglJam, TglJamOut As Date
        tb.Clear()
        tb.Columns.Add("TglJam", GetType(String))
        tb.Columns.Add("Value", GetType(String))
        tbl2.Clear()
        tbl2.Columns.Add("TglJam", GetType(String))
        tbl2.Columns.Add("Value", GetType(String))
        cboDinasIst.ClearFields()
        cboDinasIstOut.ClearFields()

        Try
            If Trim(txtGroupAbsen.Text) <> "" Then
                sql = "SELECT CONVERT(VARCHAR(5),(DATEADD(MINUTE,LamaIstirahatNormal,JamIstirahatNormal)),108) AS JamIstirahatNormal,CONVERT(VARCHAR(5),(DATEADD(MINUTE,LamaIstirahatJumat,JamIstirahatJumat)),108) AS JamIstirahatJumat,JamIstirahatNormal as JamIstirahatNormalOut,JamIstirahatJumat as JamIstirahatJumatOut FROM tblMstGroupAbsen WHERE GroupAbsenID='" & Convert.ToDouble(txtGroupAbsen.Text) & "' "
            Else
                sql = "SELECT shift1_istout,shift1_istin,shift2_istout,shift2_istin,shift3_istout,shift3_istin FROM tblMstShift WHERE ShiftID='" & Convert.ToDouble(txtShiftID.Text) & "' "
            End If
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        While DR.Read
                            If Val(txtGroupAbsen.Text) > 0 Then
                                If Weekday(Tanggal) = 6 Then
                                    TglJam = Tanggal & " " & DR!JamIstirahatJumat
                                    TglJamOut = Tanggal & " " & DR!JamIstirahatJumatOut
                                Else
                                    TglJam = Tanggal & " " & DR!JamIstirahatNormal
                                    TglJamOut = Tanggal & " " & DR!JamIstirahatNormalOut
                                End If
                                tb.Rows.Add(Format(TglJam, "dd/MM/yyyy HH:mm"), Format(TglJam, "dd/MM/yyyy HH:mm"))
                                tbl2.Rows.Add(Format(TglJamOut, "dd/MM/yyyy HH:mm"), Format(TglJamOut, "dd/MM/yyyy HH:mm"))
                            Else
                                TglJam = Tanggal & " " & DR!shift1_istin
                                tb.Rows.Add(Format(TglJam, "dd/MM/yyyy HH:mm"), Format(TglJam, "dd/MM/yyyy HH:mm"))
                                TglJam = Tanggal & " " & DR!shift2_istin
                                tb.Rows.Add(Format(TglJam, "dd/MM/yyyy HH:mm"), Format(TglJam, "dd/MM/yyyy HH:mm"))
                                TglJam = Tanggal & " " & DR!shift3_istin
                                tb.Rows.Add(Format(TglJam, "dd/MM/yyyy HH:mm"), Format(TglJam, "dd/MM/yyyy HH:mm"))

                                TglJamOut = Tanggal & " " & DR!shift1_istout
                                tbl2.Rows.Add(Format(TglJamOut, "dd/MM/yyyy HH:mm"), Format(TglJamOut, "dd/MM/yyyy HH:mm"))
                                TglJamOut = Tanggal & " " & DR!shift2_istout
                                tbl2.Rows.Add(Format(TglJamOut, "dd/MM/yyyy HH:mm"), Format(TglJamOut, "dd/MM/yyyy HH:mm"))
                                TglJamOut = Tanggal & " " & DR!shift3_istout
                                tbl2.Rows.Add(Format(TglJamOut, "dd/MM/yyyy HH:mm"), Format(TglJamOut, "dd/MM/yyyy HH:mm"))
                            End If
                        End While
                    End If
                End Using
                If tb.Rows.Count > 0 Then
                    cboDinasIst.DataSource = tb
                    cboDinasIst.DisplayMember = "TglJam"
                    cboDinasIst.ValueMember = "Value"
                    cboDinasIst.SelectedIndex = 0
                End If
                If tbl2.Rows.Count > 0 Then
                    cboDinasIstOut.DataSource = tbl2
                    cboDinasIstOut.DisplayMember = "TglJam"
                    cboDinasIstOut.ValueMember = "Value"
                    cboDinasIstOut.SelectedIndex = 0
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function Simpan(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        Simpan = False
        Dim mycon As SqlConnection = conn
        Dim mycontrans As SqlTransaction = trans
        With cmd
            .Connection = conn
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spTrnAbsensiKryHdrSave"
            .Transaction = mycontrans
            .Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.BigInt, 3, ParameterDirection.ReturnValue, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add("@AbsenHdrID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(txtHeaderID.Text)
            .Parameters.Add("@StatusTk", SqlDbType.VarChar, 20).Value = StatusTK
            .Parameters.Add("@DeptID", SqlDbType.Int).Value = cboDepartemen.SelectedValue
            .Parameters.Add("@PeriodeTgl", SqlDbType.DateTime).Value = Format(Tanggal, "yyyy-MM-dd")
            .Parameters.Add("@PeriodeBln", SqlDbType.DateTime).Value = Format(dtPeriode1.Value, "yyyy-MM-01")
            .Parameters.Add("@LoginName", SqlDbType.VarChar, 50).Value = UserLogin
            If Perintah = "SAVE EDIT" Then
                .Parameters.Add("@CompleteStatus", SqlDbType.Bit).Value = 0
            Else
                .Parameters.Add("@CompleteStatus", SqlDbType.Bit).Value = 1
            End If
            .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
            .Parameters("@AbsenHdrID").Direction = ParameterDirection.InputOutput
            .ExecuteNonQuery()
            If Val(.Parameters("@AbsenHdrID").Value) > 0 Then txtHeaderID.Text = Val(cmd.Parameters("@AbsenHdrID").Value)
        End With
        If CInt(cmd.Parameters("@Flag").Value) <> 0 Then
            cmd.Dispose()
            Exit Function
        End If
        cmd.Dispose()
        Simpan = True
        Return Simpan
    End Function
    Private Function SimpanDtl(ByVal Conn As SqlConnection, ByVal trans As SqlTransaction, ByVal i As Integer) As Boolean
        SimpanDtl = False
        Dim cmd As New SqlCommand
        Dim kon As SqlConnection = Conn
        Dim mycontrans As SqlTransaction = trans
        With cmd
            .Connection = kon
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spTrnAbsensiKryDetailSave"
            .Transaction = mycontrans
            .Parameters.Add("@AbsenDtlID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(fg.Item(i, "DetailID"))
            .Parameters.Add("@AbsenHdrID", SqlDbType.BigInt, ParameterDirection.Input).Value = Val(txtHeaderID.Text)
            .Parameters.Add("@UserID", SqlDbType.BigInt, ParameterDirection.Input).Value = Val(fg.Item(i, "UserID"))
            .Parameters.Add("@AbsenMasuk", SqlDbType.DateTime).Value = IIf(IsNothing(fg.Item(i, "TglJamMasuk")), DBNull.Value, fg.Item(i, "TglJamMasuk"))
            .Parameters.Add("@AbsenKeluarIst", SqlDbType.DateTime).Value = IIf(IsNothing(fg.Item(i, "TglJamIstOut")), DBNull.Value, fg.Item(i, "TglJamIstOut"))
            .Parameters.Add("@AbsenMasukIst", SqlDbType.DateTime).Value = IIf(IsNothing(fg.Item(i, "TglJamIstIn")), DBNull.Value, fg.Item(i, "TglJamIstIn"))
            .Parameters.Add("@AbsenPulang", SqlDbType.DateTime).Value = IIf(IsNothing(fg.Item(i, "TglJamPulang")), DBNull.Value, fg.Item(i, "TglJamPulang"))
            .Parameters.Add("@TotalJamAll", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "TotalJam")), DBNull.Value, Val(fg.Item(i, "TotalJam")))
            .Parameters.Add("@TotalJam", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "TotJam")), DBNull.Value, Val(fg.Item(i, "TotJam")))

            .Parameters.Add("@Istirahat", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "IstirahatMenit")), DBNull.Value, Val(fg.Item(i, "IstirahatMenit")))
            .Parameters.Add("@AbsenStr", SqlDbType.VarChar, 5).Value = IIf(IsNothing(fg.Item(i, "Absensi")), DBNull.Value, fg.Item(i, "Absensi"))
            .Parameters.Add("@Lembur", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "Lembur")), DBNull.Value, Val(fg.Item(i, "Lembur")))
            .Parameters.Add("@DinasMasuk", SqlDbType.VarChar, 5).Value = IIf(IsNothing(fg.Item(i, "DinasMasuk")), DBNull.Value, fg.Item(i, "DinasMasuk"))
            .Parameters.Add("@DinasPulang", SqlDbType.VarChar, 5).Value = IIf(IsNothing(fg.Item(i, "DinasPulang")), DBNull.Value, fg.Item(i, "DinasPulang"))
            .Parameters.Add("@DinasIstirahat", SqlDbType.VarChar, 5).Value = IIf(IsNothing(fg.Item(i, "DinasIstIn")), DBNull.Value, fg.Item(i, "DinasIstIn"))
            .Parameters.Add("@LambatMasukKerja", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "LambatMasuk")), DBNull.Value, Val(fg.Item(i, "LambatMasuk")))
            .Parameters.Add("@CepatIstKeluar", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "CepatIstKeluar")), DBNull.Value, Val(fg.Item(i, "CepatIstKeluar")))
            .Parameters.Add("@LambatMasukIstirahat", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "LambatIstirahat")), DBNull.Value, Val(fg.Item(i, "LambatIstirahat")))
            .Parameters.Add("@PulangCepat", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "PulangCepat")), DBNull.Value, Val(fg.Item(i, "PulangCepat")))
            .Parameters.Add("@JamKerjaPanjangPendek", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "JamKerja")), DBNull.Value, Val(fg.Item(i, "JamKerja")))

            .Parameters.Add("@LiburMingguan", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "LiburMingguan")), DBNull.Value, Val(fg.Item(i, "LiburMingguan")))
            .Parameters.Add("@GroupAbsenCurrent", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "GroupAbsenID")), 0, Val(fg.Item(i, "GroupAbsenID")))
            '.Parameters.Add("@ShiftID", SqlDbType.Int).Value = IIf(IsNothing(fg.Item(i, "ShiftID")), DBNull.Value, Val(fg.Item(i, "ShiftID")))
            If Convert.ToString(fg.Item(i, "ShiftID")) <> "" Then
                .Parameters.Add("@ShiftID", SqlDbType.Int).Value = Val(fg.Item(i, "ShiftID"))
            Else
                .Parameters.Add("@ShiftID", SqlDbType.Int).Value = DBNull.Value
            End If
            .Parameters.Add("@DeptID", SqlDbType.Int).Value = DBNull.Value
            .Parameters.Add("@BagianID", SqlDbType.Int).Value = DBNull.Value
            .Parameters.Add("@JabatanID", SqlDbType.Int).Value = DBNull.Value
            .Parameters.Add("@KetID", SqlDbType.Int).Value = DBNull.Value
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 200).Value = IIf(IsNothing(fg.Item(i, "Keterangan")), DBNull.Value, fg.Item(i, "Keterangan"))
            .Parameters.Add("@LoginName", SqlDbType.VarChar, 200).Value = UserLogin
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.Int, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
            If .Parameters("@Flag").Value <> 0 Then SimpanDtl = True
        End With
        cmd = Nothing
        Return SimpanDtl
    End Function

    Private Function SimpanDtlEdit(ByVal Conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
        SimpanDtlEdit = False
        Dim cmd As New SqlCommand
        Dim kon As SqlConnection = Conn
        Dim mycontrans As SqlTransaction = trans
        With cmd
            .Connection = kon
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spTrnAbsensiKryDetailEditSave"
            .Transaction = mycontrans
            .Parameters.Add("@AbsenDtlID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(txtDetailID.Text)
            .Parameters.Add("@AbsenHdrID", SqlDbType.BigInt, ParameterDirection.Input).Value = Val(txtHeaderID.Text)
            .Parameters.Add("@UserID", SqlDbType.BigInt, ParameterDirection.Input).Value = Val(txtUserID.Text)
            .Parameters.Add("@AbsenMasuk", SqlDbType.DateTime).Value = IIf(Trim(cboJamMasuk.Text) = "", DBNull.Value, cboJamMasuk.Text)
            .Parameters.Add("@AbsenKeluarIst", SqlDbType.DateTime).Value = IIf(Trim(cboIstOut.Text) = "", DBNull.Value, cboIstOut.Text)
            .Parameters.Add("@AbsenMasukIst", SqlDbType.DateTime).Value = IIf(Trim(cboIstIn.Text) = "", DBNull.Value, cboIstIn.Text)
            .Parameters.Add("@AbsenPulang", SqlDbType.DateTime).Value = IIf(Trim(cboJamPulang.Text) = "", DBNull.Value, cboJamPulang.Text)
            .Parameters.Add("@TotalJamAll", SqlDbType.Int).Value = IIf(Trim(txtTotalJamAll.Text) = "", DBNull.Value, Val(txtTotalJamAll.Text))
            .Parameters.Add("@TotalJam", SqlDbType.Int).Value = IIf(Trim(txtTotalJamKerja.Text) = "", DBNull.Value, Val(txtTotalJamKerja.Text))

            .Parameters.Add("@Istirahat", SqlDbType.Int).Value = IIf(Trim(txtIstMenit.Text) = "", DBNull.Value, Val(txtIstMenit.Text))
            .Parameters.Add("@AbsenStr", SqlDbType.VarChar, 5).Value = IIf(IsNothing(Trim(txtAbsenStr.Text)), DBNull.Value, txtAbsenStr.Text)
            .Parameters.Add("@Lembur", SqlDbType.Int).Value = IIf(Trim(txtLembur.Text) = "", DBNull.Value, Val(txtLembur.Text))
            '.Parameters.Add("@DinasMasuk", SqlDbType.VarChar, 5).Value = IIf(Trim(cboDinasMasuk.Text) = "", DBNull.Value, Format(CDate(cboDinasMasuk.Text), "HH:mm"))
            If Trim(cboDinasMasuk.Text) = "" Then
                .Parameters.Add("@DinasMasuk", SqlDbType.VarChar, 5).Value = DBNull.Value
            Else
                .Parameters.Add("@DinasMasuk", SqlDbType.VarChar, 5).Value = Format(CDate(cboDinasMasuk.Text), "HH:mm")
            End If
            If Trim(txtDinasPulang.Text) = "" Then
                .Parameters.Add("@DinasPulang", SqlDbType.VarChar, 5).Value = DBNull.Value
            Else
                .Parameters.Add("@DinasPulang", SqlDbType.VarChar, 5).Value = Format(CDate(txtDinasPulang.Text), "HH:mm")
            End If
            '.Parameters.Add("@DinasIstirahat", SqlDbType.VarChar, 5).Value = IIf(Trim(cboDinasIst.Text) = "", DBNull.Value, Format(CDate(cboDinasIst.Text), "HH:mm"))
            If Trim(cboDinasIst.Text) = "" Then
                .Parameters.Add("@DinasIstirahat", SqlDbType.VarChar, 5).Value = DBNull.Value
            Else
                .Parameters.Add("@DinasIstirahat", SqlDbType.VarChar, 5).Value = Format(CDate(cboDinasIst.Text), "HH:mm")
            End If
            .Parameters.Add("@LambatMasukKerja", SqlDbType.Int).Value = IIf(Trim(txtLambatIn.Text) = "", DBNull.Value, Val(txtLambatIn.Text))
            .Parameters.Add("@CepatIstKeluar", SqlDbType.Int).Value = IIf(Trim(txtCepatIstOut.Text) = "", DBNull.Value, Val(txtCepatIstOut.Text))
            .Parameters.Add("@LambatMasukIstirahat", SqlDbType.Int).Value = IIf(Trim(txtLambatIstIn.Text) = "", DBNull.Value, Val(txtLambatIstIn.Text))
            .Parameters.Add("@PulangCepat", SqlDbType.Int).Value = IIf(Trim(txtCepatOut.Text) = "", DBNull.Value, Val(txtCepatOut.Text))
            .Parameters.Add("@JamKerjaPanjangPendek", SqlDbType.Int).Value = IIf(lblJamKerjaPanjangPendek.Text = "", DBNull.Value, Val(lblJamKerjaPanjangPendek.Text))

            .Parameters.Add("@LiburMingguan", SqlDbType.Int).Value = IIf(lblLiburMingguan.Text = "", DBNull.Value, Val(lblLiburMingguan.Text))
            .Parameters.Add("@GroupAbsenCurrent", SqlDbType.Int).Value = IIf(IsNothing(Trim(txtGroupAbsen.Text)), 0, Val(txtGroupAbsen.Text))
            .Parameters.Add("@ShiftID", SqlDbType.Int).Value = IIf(IsNothing(Trim(txtShiftID.Text)), DBNull.Value, Val(txtShiftID.Text))
            .Parameters.Add("@DeptID", SqlDbType.Int).Value = DBNull.Value
            .Parameters.Add("@BagianID", SqlDbType.Int).Value = DBNull.Value
            .Parameters.Add("@JabatanID", SqlDbType.Int).Value = DBNull.Value
            .Parameters.Add("@KetID", SqlDbType.Int).Value = DBNull.Value
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 200).Value = IIf(IsNothing(Trim(txtKeterangan.Text)), DBNull.Value, Trim(txtKeterangan.Text))
            .Parameters.Add("@LoginName", SqlDbType.VarChar, 200).Value = UserLogin
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.Int, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
            If .Parameters("@Flag").Value <> 0 Then SimpanDtlEdit = True
        End With
        cmd = Nothing
        Return SimpanDtlEdit
    End Function

    Private Sub btnSaveDevice_Click(sender As Object, e As EventArgs) Handles btnSaveDevice.Click
        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Try
            Perintah = "SAVE"
            If IsNothing(fg.Item(1, "UserID")) = True Then
                MsgBox("Tidak Ada Data Yang Akan Disimpan!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Trim(cboTanggal.Text) = "" Then
                MsgBox("Tanggal Tidak Boleh Kosong!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor

            If Simpan(Koneksi, Transaksi) = False Then
                MsgBox("Simpan Data Header Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
                Me.Cursor = Cursors.Default
                Transaksi.Rollback()
                Exit Sub
            End If
            If Trim(txtHeaderID.Text) = "" Then
                MsgBox("Simpan Absensi Dibatalkan,Silakan Aplikasi Anda!", vbCritical, "Failed")
                Me.Cursor = Cursors.Default
                Transaksi.Rollback()
                Exit Sub
            End If
            For i As Integer = 1 To fg.Rows.Count - 1
                If Convert.ToDouble(fg.Item(i, "UserID")) > 0 Then
                    If SimpanDtl(Koneksi, Transaksi, i) = False Then
                        MsgBox("Simpan Data Detail Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
                        Me.Cursor = Cursors.Default
                        Transaksi.Rollback()
                        Exit Sub
                    End If
                End If
            Next
            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MsgBox("Simpan Absensi Berhasil", vbInformation)
            Call ClearetxtEdit()
            txtHeaderID.Clear()
            fg.Rows.Count = 1
            fg.Rows.Count = 2
        Catch ex As Exception
            Transaksi.Rollback()
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetDataAbsenSudahDisimpan()
        Dim sql As String = ""
        Dim i As Integer = 0
        Dim UserID As Long = 0

        Try
            sql = "SELECT * FROM vwAbsensiKry WHERE PeriodeTgl='" & Format(Tanggal, "yyyy-MM-dd") & "' and StatusTk='" & StatusTK & "' and DeptID='" & cboDepartemen.SelectedValue & "' "
            If Trim(txtNikNama.Text) <> "" Then
                sql = sql & " and Nik='" & Trim(txtNikNama.Text) & "' or Nama Like '%" & Trim(txtNikNama.Text) & "%' "
            End If
            sql = sql & " Order By NAMA,UserID"

            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                Using DR = koneksi.ExecuteReader()
                    fg.Rows.Count = 1
                    fg.Rows.Count = 2
                    If DR.HasRows Then
                        With fg
                            If IsNothing(.Item(1, "UserID")) = True Then
                                .Rows.Count = 1
                            End If
                            While DR.Read
                                If UserID <> DR!UserID Then
                                    .AddItem("")
                                    UserID = DR!UserID
                                    i = .Rows.Count - 1
                                End If
                                txtHeaderID.Text = DR!AbsenHdrID
                                .Item(i, "No") = i
                                .Item(i, "DetailID") = DR!AbsenDtlID
                                .Item(i, "UserID") = DR!UserID
                                .Item(i, "NIK") = DR!NIK
                                .Item(i, "NAMA") = DR!NAMA
                                .Item(i, "Departemen") = DR!Departemen
                                .Item(i, "Jabatan") = DR!JabatanName
                                .Item(i, "Tanggal") = Format(DR!PeriodeTgl, "dd/MM/yyyy")
                                If IsDBNull(DR!DinasMasuk) = False Then .Item(i, "DinasMasuk") = DR!DinasMasuk
                                If IsDBNull(DR!DinasIstirahat) = False Then .Item(i, "DinasIstIn") = DR!DinasIstirahat
                                If IsDBNull(DR!DinasPulang) = False Then .Item(i, "DinasPulang") = DR!DinasPulang

                                If IsDBNull(DR!AbsenMasuk) = False Then .Item(i, "Masuk") = Format(DR!AbsenMasuk, "HH:mm")
                                If IsDBNull(DR!AbsenKeluarIst) = False Then .Item(i, "IstOut") = Format(DR!AbsenKeluarIst, "HH:mm")
                                If IsDBNull(DR!AbsenMasukIst) = False Then .Item(i, "IstIn") = Format(DR!AbsenMasukIst, "HH:mm")
                                If IsDBNull(DR!AbsenPulang) = False Then .Item(i, "Pulang") = Format(DR!AbsenPulang, "HH:mm")

                                If IsDBNull(DR!AbsenMasuk) = False Then .Item(i, "TglJamMasuk") = Format(DR!AbsenMasuk, "dd/MM/yyyy HH:mm")
                                If IsDBNull(DR!AbsenKeluarIst) = False Then .Item(i, "TglJamIstOut") = Format(DR!AbsenKeluarIst, "dd/MM/yyyy HH:mm")
                                If IsDBNull(DR!AbsenMasukIst) = False Then .Item(i, "TglJamIstIn") = Format(DR!AbsenMasukIst, "dd/MM/yyyy HH:mm")
                                If IsDBNull(DR!AbsenPulang) = False Then .Item(i, "TglJamPulang") = Format(DR!AbsenPulang, "dd/MM/yyyy HH:mm")

                                If IsDBNull(DR!TotalJamAll) = False Then .Item(i, "TotalJam") = DR!TotalJamAll
                                If IsDBNull(DR!Istirahat) = False Then .Item(i, "IstirahatMenit") = DR!Istirahat
                                If IsDBNull(DR!TotalJam) = False Then .Item(i, "TotJam") = DR!TotalJam
                                .Item(i, "Absensi") = DR!AbsenStr
                                Select Case .Item(i, "Absensi").ToString
                                    Case "A"
                                        StyleFontBold(fg, i, 1, .Cols.Count - 1, True)
                                        StyleBackColor(fg, Color.Yellow, i, 9, 17)
                                        StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                    Case "IM"
                                        StyleFontBold(fg, i, 1, .Cols.Count - 1, True)
                                        StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                    Case "L"
                                        StyleFontBold(fg, i, 1, .Cols.Count - 1, True)
                                        StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                    Case Else
                                        StyleFontBold(fg, i, 1, .Cols.Count - 1, True)
                                End Select
                                If IsDBNull(DR!Lembur) = False Then .Item(i, "Lembur") = DR!Lembur
                                If IsDBNull(DR!LiburMingguan) = False Then .Item(i, "LiburMingguan") = DR!LiburMingguan
                                If IsDBNull(DR!StatusJamKerjaID) = False Then .Item(i, "ALOT") = UCase(DR!StatusJamKerjaID)
                                Select Case DR!GroupAbsenID
                                    Case 0
                                        .Item(i, "ShiftNonShift") = "SHIFT"
                                        .Item(i, "ShiftID") = DR!ShiftID
                                    Case Else
                                        .Item(i, "ShiftNonShift") = "NON SHIFT"
                                        .Item(i, "GroupAbsenID") = DR!GroupAbsenID
                                End Select
                                If DR!GroupAbsenID > 0 And IsDBNull(DR!DinasIstirahat) = False And IsDBNull(DR!LamaIstirahatNormal) = False Then
                                    If Weekday(Tanggal) = 6 Then
                                        If IsDBNull(DR!DinasIstirahat) = False Then .Item(i, "DinasIstOut") = Format(DateAdd(DateInterval.Minute, -DR!LamaIstirahatJumat, DR!DinasIstirahat), "HH:mm")
                                    Else
                                        If IsDBNull(DR!DinasIstirahat) = False Then .Item(i, "DinasIstOut") = Format(DateAdd(DateInterval.Minute, -DR!LamaIstirahatNormal, DR!DinasIstirahat), "HH:mm")
                                    End If
                                Else
                                    'SHIFT KOSONG KAN
                                End If
                                If IsDBNull(DR!DinasIstirahat) = False Then .Item(i, "DinasIstIn") = DR!DinasIstirahat
                                If IsDBNull(DR!LambatMasukKerja) = False Then .Item(i, "LambatMasuk") = DR!LambatMasukKerja
                                If IsDBNull(DR!CepatIstKeluar) = False Then .Item(i, "CepatIstKeluar") = DR!CepatIstKeluar

                                If IsDBNull(DR!LambatMasukIstirahat) = False Then .Item(i, "LambatIstirahat") = DR!LambatMasukIstirahat
                                If IsDBNull(DR!PulangCepat) = False Then .Item(i, "PulangCepat") = DR!PulangCepat
                                If IsDBNull(DR!Keterangan) = False Then .Item(i, "Keterangan") = DR!Keterangan
                                If DR!GroupAbsenID = 0 Then

                                    If IsDBNull(DR!ShiftID) = True Then
                                        StyleBackColor(fg, Color.YellowGreen, i, 1, .Cols.Count - 1) 'BELUM SETTING JAM KERJA
                                        StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                    End If
                                End If
                            End While
                        End With
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub KalkulasiAbsensi()
        Try
            If UbahAbsensi = True Then
                Dim LambatIn, TotalJamAll, TotalJam, CepatIstOut, LambatIstIn, CepatOut As Integer
                TotalJamAll = KeJam(cboJamMasuk.Text, cboJamPulang.Text, cboDinasMasuk.Text, Tanggal)
                If Trim(cboIstOut.Text) <> "" And Trim(cboIstIn.Text) <> "" Then
                    If Weekday(Tanggal) = 6 Then
                        txtIstMenit.Text = 180
                    Else
                        txtIstMenit.Text = 90
                    End If
                Else
                    txtIstMenit.Text = 0
                End If
                TotalJam = MenitKeJam(KeMenit(cboJamMasuk.Text, cboJamPulang.Text, cboDinasMasuk.Text, Tanggal) - Val(txtIstMenit.Text))
                LambatIn = SelisihMenit(cboDinasMasuk.Text, cboJamMasuk.Text)
                CepatIstOut = SelisihMenit(cboIstOut.Text, cboDinasIstOut.Text)
                LambatIstIn = SelisihMenit(cboDinasIst.Text, cboIstIn.Text)
                CepatOut = SelisihMenit(cboJamPulang.Text, txtDinasPulang.Text)

                If TotalJamAll > 0 Then
                    txtTotalJamAll.Text = TotalJamAll
                Else
                    txtTotalJamAll.Text = 0
                End If
                If TotalJam > 0 Then
                    txtTotalJamKerja.Text = TotalJam
                Else
                    txtTotalJamKerja.Text = 0
                End If
                If lblAlOT.Text = "OT" Then
                    If isLiburNasional = True Or Weekday(Tanggal) <> lblLiburMingguan.Text Then
                        txtLembur.Text = TotalJam
                    Else
                        If TotalJam > Val(lblJamKerjaPanjangPendek.Text) Then
                            txtLembur.Text = TotalJam - Val(lblJamKerjaPanjangPendek.Text)
                        Else
                            txtLembur.Text = 0
                        End If
                    End If
                Else
                    txtLembur.Text = 0
                End If

                If CepatIstOut > 0 Then
                    txtCepatIstOut.Text = CepatIstOut
                Else
                    txtCepatIstOut.Text = 0
                End If

                If LambatIstIn > 0 Then
                    txtLambatIstIn.Text = LambatIstIn
                Else
                    txtLambatIstIn.Text = 0
                End If
                If CepatOut > 0 Then
                    txtCepatOut.Text = CepatOut
                Else
                    txtCepatOut.Text = 0
                End If
                If LambatIn > 5 Then
                    txtLambatIn.Text = LambatIn - 5 'DISPENSASI 5 MENIT
                Else
                    txtLambatIn.Text = 0
                End If
                If Val(txtGroupAbsen.Text) > 0 Then
                    If AbsenEdit() = 4 Then
                        If Weekday(Tanggal) = 6 Then 'HARI JUMAT
                            txtAbsenStr.Text = 7
                        Else
                            txtAbsenStr.Text = 7
                        End If
                    ElseIf AbsenEdit() >= 2 And AbsenEdit() < 4 Then
                        If Weekday(Tanggal) = 7 Then 'HARI SABTU
                            txtAbsenStr.Text = 5
                        ElseIf Weekday(Tanggal) = 6 Then 'HARI JUMAT
                            txtAbsenStr.Text = 7
                            txtLambatIn.Text = 60
                        Else
                            txtAbsenStr.Text = 7
                            txtLambatIn.Text = 60
                        End If
                    Else
                        If isLiburNasional = True Then
                            txtAbsenStr.Text = "L"
                        Else
                            txtAbsenStr.Text = "A"
                        End If
                    End If
                Else
                    If AbsenEdit() = 2 Then
                        If Weekday(Tanggal) = 6 Then 'HARI JUMAT
                            txtAbsenStr.Text = 7
                        ElseIf Weekday(Tanggal) = 7 Then 'HARI SABTU
                            txtAbsenStr.Text = 5
                        Else
                            txtAbsenStr.Text = 7
                        End If
                    Else
                        If isLiburNasional = True Then
                            txtAbsenStr.Text = "L"
                        Else
                            txtAbsenStr.Text = "A"
                        End If
                    End If
                End If

                If isLiburNasional = True Then
                    txtAbsenStr.Text = "L"
                ElseIf Weekday(Tanggal) = lblLiburMingguan.Text Then
                    txtAbsenStr.Text = "IM"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboJamMasuk_TextChanged(sender As Object, e As EventArgs) Handles cboJamMasuk.TextChanged
        Call KalkulasiAbsensi()
    End Sub

    Private Sub cboIstOut_TextChanged(sender As Object, e As EventArgs) Handles cboIstOut.TextChanged
        Call KalkulasiAbsensi()
    End Sub

    Private Sub cboIstIn_TextChanged(sender As Object, e As EventArgs) Handles cboIstIn.TextChanged
        Call KalkulasiAbsensi()
    End Sub

    Private Sub cboJamPulang_TextChanged(sender As Object, e As EventArgs) Handles cboJamPulang.TextChanged
        Call KalkulasiAbsensi()
    End Sub

    Private Sub cboDinasMasuk_TextChanged(sender As Object, e As EventArgs) Handles cboDinasMasuk.TextChanged

        Call KalkulasiAbsensi()
    End Sub

    Private Sub cboDinasIst_TextChanged(sender As Object, e As EventArgs) Handles cboDinasIst.TextChanged

    End Sub

    Private Sub cboTanggal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTanggal.SelectedIndexChanged

    End Sub

    Private Sub btnDeleteDevice_Click(sender As Object, e As EventArgs) Handles btnDeleteDevice.Click
        Try
            If Trim(txtHeaderID.Text) = "" Then
                MsgBox("Absensi Belum Bisa Dihapus, Silakan Disimpan Dahulu Baru Bisa Dihapus!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MessageBox.Show("Anda Ingin Menghapus Absensi Tanggal : " & cboTanggal.Text & " Ini?", "Delete", MessageBoxButtons.YesNo) = vbYes Then
                Call OpenKoneksi()
                CMD = Conn.CreateCommand
                With CMD
                    .Connection = Conn
                    .CommandType = CommandType.Text
                    .CommandText = "delete tblTrnAbsensiDtlKry where AbsenHdrID='" & Trim(txtHeaderID.Text) & "' "
                    .ExecuteNonQuery()
                    .CommandText = "delete tblTrnAbsensiHdrKry where AbsenHdrID='" & Trim(txtHeaderID.Text) & "' "
                    .ExecuteNonQuery()
                End With
                MsgBox("Absensi Berhasil Hapus", vbInformation, "Success")
                txtHeaderID.Clear()
                fg.Rows.Count = 1
                fg.Rows.Count = 2
                Call ClearetxtEdit()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GetRefreshEdit()
        Dim sql As String = ""
        Dim i As Integer = 0
        Dim UserID As Long = 0

        Try
            sql = "SELECT * FROM vwAbsensiKry WHERE StatusTk='" & StatusTK & "' and DeptID='" & cboDepartemen.SelectedValue & "' and PeriodeTgl='" & Format(Tanggal, "yyyy-MM-dd") & "' and UserID='" & txtUserID.Text & "' "
            sql = sql & " Order By NAMA,UserID"

            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        With fg
                            While DR.Read
                                .AddItem("")
                                UserID = DR!UserID
                                i = .Rows.Count - 1
                                txtHeaderID.Text = DR!AbsenHdrID
                                .Item(i, "No") = i
                                .Item(i, "DetailID") = DR!AbsenDtlID
                                .Item(i, "UserID") = DR!UserID
                                .Item(i, "NIK") = DR!NIK
                                .Item(i, "NAMA") = DR!NAMA
                                .Item(i, "Departemen") = DR!Departemen
                                .Item(i, "Jabatan") = DR!JabatanName
                                .Item(i, "Tanggal") = Format(DR!PeriodeTgl, "dd/MM/yyyy")
                                If IsDBNull(DR!DinasMasuk) = False Then .Item(i, "DinasMasuk") = DR!DinasMasuk
                                If IsDBNull(DR!DinasIstirahat) = False Then .Item(i, "DinasIstIn") = DR!DinasIstirahat
                                If IsDBNull(DR!DinasPulang) = False Then .Item(i, "DinasPulang") = DR!DinasPulang

                                If IsDBNull(DR!AbsenMasuk) = False Then .Item(i, "Masuk") = Format(DR!AbsenMasuk, "HH:mm")
                                If IsDBNull(DR!AbsenKeluarIst) = False Then .Item(i, "IstOut") = Format(DR!AbsenKeluarIst, "HH:mm")
                                If IsDBNull(DR!AbsenMasukIst) = False Then .Item(i, "IstIn") = Format(DR!AbsenMasukIst, "HH:mm")
                                If IsDBNull(DR!AbsenPulang) = False Then .Item(i, "Pulang") = Format(DR!AbsenPulang, "HH:mm")

                                If IsDBNull(DR!AbsenMasuk) = False Then .Item(i, "TglJamMasuk") = Format(DR!AbsenMasuk, "dd/MM/yyyy HH:mm")
                                If IsDBNull(DR!AbsenKeluarIst) = False Then .Item(i, "TglJamIstOut") = Format(DR!AbsenKeluarIst, "dd/MM/yyyy HH:mm")
                                If IsDBNull(DR!AbsenMasukIst) = False Then .Item(i, "TglJamIstIn") = Format(DR!AbsenMasukIst, "dd/MM/yyyy HH:mm")
                                If IsDBNull(DR!AbsenPulang) = False Then .Item(i, "TglJamPulang") = Format(DR!AbsenPulang, "dd/MM/yyyy HH:mm")

                                If IsDBNull(DR!TotalJamAll) = False Then .Item(i, "TotalJam") = DR!TotalJamAll
                                If IsDBNull(DR!Istirahat) = False Then .Item(i, "IstirahatMenit") = DR!Istirahat
                                If IsDBNull(DR!TotalJam) = False Then .Item(i, "TotJam") = DR!TotalJam
                                .Item(i, "Absensi") = DR!AbsenStr
                                Select Case .Item(i, "Absensi").ToString
                                    Case "A"
                                        StyleFontBold(fg, i, 1, .Cols.Count - 1, True)
                                        StyleBackColor(fg, Color.Yellow, i, 9, 17)
                                        StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                    Case "IM"
                                        StyleFontBold(fg, i, 1, .Cols.Count - 1, True)
                                        StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                    Case "L"
                                        StyleFontBold(fg, i, 1, .Cols.Count - 1, True)
                                        StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                    Case Else
                                        StyleFontBold(fg, i, 1, .Cols.Count - 1, True)
                                End Select
                                If IsDBNull(DR!Lembur) = False Then .Item(i, "Lembur") = DR!Lembur
                                If IsDBNull(DR!LiburMingguan) = False Then .Item(i, "LiburMingguan") = DR!LiburMingguan
                                If IsDBNull(DR!StatusJamKerjaID) = False Then .Item(i, "ALOT") = UCase(DR!StatusJamKerjaID)
                                Select Case DR!GroupAbsenID
                                    Case 0
                                        .Item(i, "ShiftNonShift") = "SHIFT"
                                        .Item(i, "ShiftID") = DR!ShiftID
                                    Case Else
                                        .Item(i, "ShiftNonShift") = "NON SHIFT"
                                        .Item(i, "GroupAbsenID") = DR!GroupAbsenID
                                End Select
                                If DR!GroupAbsenID > 0 Then
                                    If Weekday(Tanggal) = 6 Then
                                        If IsDBNull(DR!DinasIstirahat) = False Then .Item(i, "DinasIstOut") = Format(DateAdd(DateInterval.Minute, -DR!LamaIstirahatJumat, DR!DinasIstirahat), "HH:mm")
                                    Else
                                        If IsDBNull(DR!DinasIstirahat) = False Then .Item(i, "DinasIstOut") = Format(DateAdd(DateInterval.Minute, -DR!LamaIstirahatNormal, DR!DinasIstirahat), "HH:mm")
                                    End If
                                Else
                                    'SHIFT KOSONG KAN
                                End If
                                If IsDBNull(DR!DinasIstirahat) = False Then .Item(i, "DinasIstIn") = DR!DinasIstirahat
                                If IsDBNull(DR!LambatMasukKerja) = False Then .Item(i, "LambatMasuk") = DR!LambatMasukKerja
                                If IsDBNull(DR!CepatIstKeluar) = False Then .Item(i, "CepatIstKeluar") = DR!CepatIstKeluar
                                If IsDBNull(DR!LambatMasukIstirahat) = False Then .Item(i, "LambatIstirahat") = DR!LambatMasukIstirahat
                                If IsDBNull(DR!PulangCepat) = False Then .Item(i, "PulangCepat") = DR!PulangCepat
                                If IsDBNull(DR!Keterangan) = False Then .Item(i, "Keterangan") = DR!Keterangan
                                If DR!GroupAbsenID = 0 Then

                                    If IsDBNull(DR!ShiftID) = True Then
                                        StyleBackColor(fg, Color.YellowGreen, i, 1, .Cols.Count - 1) 'BELUM SETTING JAM KERJA
                                        StyleForeColor(fg, Color.Red, i, 17, 17, True)
                                    End If
                                End If
                            End While
                            .RemoveItem(RowEdited)
                        End With
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Function HapusAbsensiPerOrang(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        HapusAbsensiPerOrang = False
        Dim mycon As SqlConnection = conn
        Dim mycontrans As SqlTransaction = trans
        With cmd
            .Connection = conn
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spHistoriDeleteAbsensi"
            .Transaction = mycontrans
            .Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.BigInt, 3, ParameterDirection.ReturnValue, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add("@PeriodeTgl", SqlDbType.DateTime).Value = Format(Tanggal, "yyyy-MM-dd")
            .Parameters.Add("@UserID", SqlDbType.BigInt).Value = Trim(txtUserID.Text)
            .Parameters.Add("@AbsenHdrID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(txtHeaderID.Text)
            .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
            .ExecuteNonQuery()
        End With
        If CInt(cmd.Parameters("@Flag").Value) <> 0 Then
            cmd.Dispose()
            Exit Function
        End If
        cmd.Dispose()
        HapusAbsensiPerOrang = True
        Return HapusAbsensiPerOrang
    End Function

    Private Function CekKomplete() As Boolean
        Dim sql As String = ""
        Dim ret As Boolean = False
        Try
            sql = "select * from tblTrnAbsensiHdrKry where StatusTk='" & StatusTK & "' and DeptID='" & cboDepartemen.SelectedValue & "' and PeriodeTgl='" & Format(Tanggal, "yyyy-MM-dd") & "' and CompleteStatus=1"
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows And DR.Read Then
                        ret = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return ret
    End Function


    Private Sub cboDepartemen_TextUpdate(sender As Object, e As EventArgs) Handles cboDepartemen.TextUpdate
        ValidCombo(cboDepartemen)
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged

    End Sub

    Private Sub cboStatus_TextUpdate(sender As Object, e As EventArgs) Handles cboStatus.TextUpdate
        ValidCombo(cboStatus)
    End Sub

    Private Sub cboStatus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboStatus.SelectionChangeCommitted

        fg.Rows.Count = 1
        fg.Rows.Count = 2
        Call ClearetxtEdit()
    End Sub

    Private Sub btnExecl_Click(sender As Object, e As EventArgs) Handles btnExecl.Click
        ExportExcelInpoiFlexgrid(fg, 0, 0, True, "Absensi " & Format(CDate(cboTanggal.Text), "ddMMyyyy"))
    End Sub

    Private Sub cboDepartemen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartemen.SelectedIndexChanged

    End Sub

    Private Sub cboDepartemen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDepartemen.SelectionChangeCommitted
        fg.Rows.Count = 1
        fg.Rows.Count = 2
        Call ClearetxtEdit()
    End Sub



    Private Sub cboJamPulang_BeforeOpen(sender As Object, e As CancelEventArgs) Handles cboJamPulang.BeforeOpen
        KalkulasiAbsensi()
    End Sub

    Private Sub cboJamMasuk_BeforeOpen(sender As Object, e As CancelEventArgs) Handles cboJamMasuk.BeforeOpen
        KalkulasiAbsensi()
    End Sub

    Private Sub cboIstOut_BeforeOpen(sender As Object, e As CancelEventArgs) Handles cboIstOut.BeforeOpen
        KalkulasiAbsensi()
    End Sub

    Private Sub cboIstIn_BeforeOpen(sender As Object, e As CancelEventArgs) Handles cboIstIn.BeforeOpen
        KalkulasiAbsensi()
    End Sub

    Private Sub GetAbsenKosong(ByVal userId As Long)
        TglJamMasukGet = "" : TglJamIstOutGet = "" : TglJamIstInGet = "" : TglJamPulangGet = ""
        Using koneksi As New SqlCommand("select TglJam,CICO from dbo.fnGetEditAbsensiNonShift (" & userId & ",'" & Format(Tanggal, "yyyy-MM-dd") & "')  ", OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    While DR.Read
                        If IsDBNull(DR!CICO) = False Then
                            Select Case DR!CICO
                                Case "CI"
                                    TglJamMasukGet = DR!TglJam
                                Case "BO"
                                    TglJamIstOutGet = DR!TglJam
                                Case "BI"
                                    TglJamIstInGet = DR!TglJam
                                Case "CO"
                                    TglJamPulangGet = DR!TglJam
                            End Select
                        End If
                    End While
                End If
            End Using
        End Using
    End Sub

    Private Sub GetCutiIzin(ByVal RegNo As Long)
        Dim sql As String
        CutiIzin = "" : CutiIzinKeterangan = ""
        If cboStatus.SelectedValue = 1 Then
            sql = "select top 1 Absen,Keterangan from vwTrnCutiIzin where RegNo=" & RegNo & " and Tanggal='" & Format(Tanggal, "yyyy-MM-dd") & "' and StatusTk='KARYAWAN'  and ApproveByPSN is not null "
        Else
            sql = "select top 1 Absen,Keterangan from vwTrnCutiIzin where RegNo=" & RegNo & " and Tanggal='" & Format(Tanggal, "yyyy-MM-dd") & "' and StatusTk='HARIAN' and ApproveByPSN is not null "
        End If
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    While DR.Read
                        CutiIzin = DR!Absen
                        CutiIzinKeterangan = DR!Keterangan
                    End While
                End If
            End Using
        End Using
    End Sub
End Class