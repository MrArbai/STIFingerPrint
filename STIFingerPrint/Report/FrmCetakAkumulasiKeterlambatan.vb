Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmCetakAkumulasiKeterlambatan : Inherits DockContent
    Private Sub btnCloseDevice_Click(sender As Object, e As EventArgs) Handles btnCloseDevice.Click
        Me.Close()
    End Sub

    Private Sub FrmCetakAkumulasiKeterlambatan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPeriode.Text = Format(Now, "MM/yyyy")
        Call GetStatusTK(cboStatus)
        Call GetDepartemenAksesn(cboDepartemen)
        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Function GetRekapHasil() As DataTable
        Dim tbl As New DataTable()
        Dim Sql As String = ""
        Dim UserID As Long = 0
        Dim baris As Integer = 0
        Dim sqlCondition As String = ""
        Dim Sts As String
        Dim Periode As String
        Dim Total As Long = 0
        Periode = "01/" & txtPeriode.Text
        With tbl
            .Columns.Add("No")
            .Columns.Add("Nama")
            .Columns.Add("Nik")
            .Columns.Add("Jabatan")
            .Columns.Add("Periode")
            .Columns.Add("Departemen")
            .Columns.Add("LambatMasuk")
            .Columns.Add("CepatIstOut")
            .Columns.Add("LambatIstIn")
            .Columns.Add("CepatPulang")
            .Columns.Add("Total")
            .Rows.Clear()

            If cboStatus.SelectedValue = 1 Then
                Sts = "KARYAWAN"
            Else
                Sts = "HARIAN"
            End If

            Sql = "select convert(varchar,PeriodeBln,103) as PeriodeBln,UserID,NAMA,NIK,Departemen,JabatanName,ISNULL(SUM(LambatMasukKerja),0) as LambatMasukKerja,ISNULL(SUM(CepatIstKeluar),0) AS CepatIstKeluar,ISNULL(SUM(LambatMasukIstirahat),0) as LambatMasukIstirahat, " &
                    " ISNULL(SUM(PulangCepat),0) as PulangCepat from vwAbsensiKry WHERE PeriodeBln='" & Format(CDate(Periode), "yyyy-MM-dd") & "' and DeptID='" & cboDepartemen.SelectedValue & "' AND StatusTk='" & Sts & "' "
            Sql = Sql & " Group By UserID,NAMA,NIK,Departemen,JabatanName,PeriodeBln order by LambatMasukKerja desc  "
            Using koneksi As New SqlCommand(Sql, OpenKoneksi)
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        While DR.Read
                            If DR!UserID <> UserID Then
                                UserID = DR!UserID
                                .Rows.Add()
                                Total = 0
                                baris = .Rows.Count - 1
                                .Rows(baris).Item("No") = baris + 1
                                .Rows(baris).Item("Nama") = DR!Nama
                                .Rows(baris).Item("Nik") = DR!Nik
                                .Rows(baris).Item("Periode") = DR!PeriodeBln
                                .Rows(baris).Item("Departemen") = DR!Departemen
                                If IsDBNull(DR!JabatanName) = False Then .Rows(baris).Item("Jabatan") = DR!JabatanName
                                If IsDBNull(DR!LambatMasukKerja) = False Then
                                    .Rows(baris).Item("LambatMasuk") = ConversiMenitKeJam(DR!LambatMasukKerja)
                                    Total = DR!LambatMasukKerja
                                End If
                                If IsDBNull(DR!CepatIstKeluar) = False Then
                                    .Rows(baris).Item("CepatIstOut") = ConversiMenitKeJam(DR!CepatIstKeluar)
                                    Total = Total + DR!CepatIstKeluar
                                End If
                                If IsDBNull(DR!LambatMasukIstirahat) = False Then
                                    .Rows(baris).Item("LambatIstIn") = ConversiMenitKeJam(DR!LambatMasukIstirahat)
                                    Total = Total + DR!LambatMasukIstirahat
                                End If
                                If IsDBNull(DR!PulangCepat) = False Then
                                    .Rows(baris).Item("CepatPulang") = ConversiMenitKeJam(DR!PulangCepat)
                                    Total = Total + DR!PulangCepat
                                End If
                                .Rows(baris).Item("Total") = ConversiMenitKeJam(Total)
                            End If
                        End While
                    End If
                End Using
            End Using
        End With
        Return tbl
    End Function

    Private Function ConversiMenitKeJam(ByVal TotMenit As Integer) As String
        Dim hour As Long, minute As Long
        Dim a As Long
        hour = Int(TotMenit / 60)
        If hour > 0 Then
            a = hour * 60
        End If
        minute = TotMenit - a
        If hour > 0 Then
            ConversiMenitKeJam = CStr(hour) & " Jam "
            ConversiMenitKeJam = ConversiMenitKeJam & Format$(minute, "00") & " Menit"
        Else
            If minute = 0 Then
                ConversiMenitKeJam = 0
            Else
                ConversiMenitKeJam = minute & " Menit"
            End If
        End If
    End Function

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Trim(cboStatus.Text) = "" Then
            MsgBox("Status Belum Dipilih!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        If Trim(cboDepartemen.Text) = "" Then
            MsgBox("Departemen Belum Dipilih!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        If GetRekapHasil.Rows.Count = 0 Then
            MsgBox("Data Tidak Ditemukan!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Dim Drs = New ReportDataSource("DataSet1", GetRekapHasil)
        Dim paramList As New Generic.List(Of ReportParameter)
        'paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pemborong", Txt, True))
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".rptAkumulasiKeterlambatan.rdlc"
        'Me.ReportViewer1.LocalReport.SetParameters(paramList)
        Me.ReportViewer1.LocalReport.DataSources.Add(Drs)
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.RefreshReport()
    End Sub
End Class