Imports System.Data.SqlClient
Imports C1.Win
Imports C1.Win.C1FlexGrid

Module ModulData
    Public dConn As Boolean
    Public DeviceNumber As Integer
    Public IPAddress, Port As String
    Public VersiApp, VersiFromDB As String

    Public Sub ValidCombo(cbo As ComboBox)
        Try
            If cbo.FindString(cbo.Text) < 0 Then
                cbo.Text = cbo.Text.Remove(cbo.Text.Length - 1)
                cbo.SelectionStart = cbo.Text.Length
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub ValidComboTes(cbo As ComboBox)
        Try
            'If cbo.FindString(cbo.Text) < 0 Then

            'cbo.SelectionStart = cbo.Text.Length
            'cbo.AutoCompleteSource = AutoCompleteSource.AllSystemSources
            'cbo.AutoCompleteMode = AutoCompleteMode.Append
            'Dim indek As Integer = cbo.FindString(cbo.Text)
            'If indek >= 0 Then
            '    cbo.SelectedIndex = indek
            'End If
            'cbo.Text = cbo.Text.Remove(cbo.Text.Length - 1)
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ValidAngka(sender As Object, e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
    Function GetValueDbl(sqlGetVluess As String) As Double
        Dim Nilai As Double
        Using koneksi As New SqlCommand(sqlGetVluess, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader()
                GetValueDbl = 0
                If DR.HasRows And DR.Read Then
                    Nilai = CDbl(DR!GetValue)
                End If
            End Using
        End Using
        GetValueDbl = Nilai
    End Function
    Public Function NamaHari(i As Integer) As String
        On Error Resume Next
        Select Case i
            Case 1 : NamaHari = "Minggu"
            Case 2 : NamaHari = "Senin"
            Case 3 : NamaHari = "Selasa"
            Case 4 : NamaHari = "Rabu"
            Case 5 : NamaHari = "Kamis"
            Case 6 : NamaHari = "Jum'at"
            Case 7 : NamaHari = "Sabtu"
        End Select
    End Function

    Public Sub GetStatusLogin(ByVal cbo As ComboBox)
        cbo.DataSource = IsiCombo(" Select * from tblUtlStatus").Tables(0)
        cbo.DisplayMember = "Status"
        cbo.ValueMember = "StatusID"
        cbo.SelectedIndex = -1
    End Sub
    Public Sub GetGroupAkses(ByVal cbo As ComboBox)
        cbo.DataSource = IsiCombo("select GroupID,GroupName from  tblUtlGroupHeader").Tables(0)
        cbo.DisplayMember = "GroupName"
        cbo.ValueMember = "GroupID"
        cbo.SelectedIndex = -1
    End Sub

    Public Sub GetConectionType(ByVal cbo As ComboBox)
        With cbo
            Dim tb As New DataTable
            tb.Columns.Add("Text", GetType(String))
            tb.Columns.Add("Value", GetType(Integer))
            tb.Rows.Add("USB", 1)
            tb.Rows.Add("ETHERNET", 2)
            .DataSource = tb
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
    End Sub
    Public Sub GetStatusTK(ByVal cbo As ComboBox)
        With cbo
            Dim tb As New DataTable
            tb.Columns.Add("Text", GetType(String))
            tb.Columns.Add("Value", GetType(Integer))
            tb.Rows.Add("KARYAWAN", 1)
            tb.Rows.Add("HARIAN", 2)
            tb.Rows.Add("TAMU", 3)
            .DataSource = tb
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
    End Sub
    Public Sub GetDevice(ByVal cbo As ComboBox)
        cbo.DataSource = IsiCombo("select DevID,DevName from  tblMstDevice").Tables(0)
        cbo.DisplayMember = "DevName"
        cbo.ValueMember = "DevID"
        cbo.SelectedIndex = -1
    End Sub
    Function GetDeviceIP(ByVal DevID As Integer) As String
        Dim IPAddr As String = ""
        Using koneksi As New SqlCommand("select IPAddr,DevName from  tblMstDevice where DevID='" & DevID & "' ", OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows And DR.Read Then
                    IPAddr = DR!IPAddr
                End If
            End Using
        End Using
        GetDeviceIP = IPAddr
    End Function
    Public Function GetDate() As String
        Dim Tgl As String = ""
        Using koneksi As New SqlCommand("select Getdate() as Tanggal ", OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows And DR.Read Then
                    Tgl = DR!Tanggal
                End If
            End Using
        End Using
        GetDate = Tgl
    End Function
    Public Sub GetJari(ByVal cbo As ComboBox)
        cbo.DataSource = IsiCombo("select IDJari,Jari from dbo.tblMstJari").Tables(0)
        cbo.DisplayMember = "Jari"
        cbo.ValueMember = "IDJari"
        cbo.SelectedIndex = -1
    End Sub
    Public Sub GetDepartemen(ByVal cbo As ComboBox)
        cbo.DataSource = IsiCombo("select DeptID,Departemen from  vwMstDept Order By Departemen ").Tables(0)
        cbo.DisplayMember = "Departemen"
        cbo.ValueMember = "DeptID"
        cbo.SelectedIndex = -1
    End Sub
    Public Sub GetDepartemenAksesn(ByVal cbo As ComboBox)
        Try
            cbo.DataSource = IsiCombo("select a.DeptID,Departemen from vwMstDept a join tblUtlGroupDepartemen b on a.DeptID=b.DeptID where b.GroupID ='" & GroupID & "' Order by Departemen").Tables(0)
            cbo.DisplayMember = "Departemen"
            cbo.ValueMember = "DeptID"
            cbo.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub GetDepartemenByStatus(ByVal cbo As ComboBox, ByVal status As Integer)
        If status = 1 Then
            cbo.DataSource = IsiCombo("select a.DeptID,Departemen from vwMstDept a join tblUtlGroupDepartemen b on a.DeptID=b.DeptID where b.GroupID ='" & GroupID & "' and a.ShortName<>'PT.STI HARIAN' Order by Departemen").Tables(0)
        Else
            cbo.DataSource = IsiCombo("select a.DeptID,Departemen from vwMstDept a join tblUtlGroupDepartemen b on a.DeptID=b.DeptID where b.GroupID ='" & GroupID & "' and a.ShortName='PT.STI HARIAN' Order by Departemen").Tables(0)
        End If
        cbo.DisplayMember = "Departemen"
        cbo.ValueMember = "DeptID"
        cbo.SelectedIndex = -1
    End Sub
    Public Function KeJam(ByVal JamAwal As String, ByVal JamAkhir As String, ByVal JamDinas As String, ByVal Tanggal As Date) As Integer
        Dim Hour As Long, Minute As Long, Jam As Long, TotMenit, Sisa As Long
        Dim RetJam As Integer = 0
        Dim Tgl As String
        Try
            If Len(JamAwal) > 5 Then
                JamAwal = Format(CDate(JamAwal), "HH:mm")
            End If
            If Len(JamAkhir) > 5 Then
                JamAkhir = Format(CDate(JamAkhir), "HH:mm")
            End If
            If Len(JamDinas) > 5 Then
                JamDinas = Format(CDate(JamDinas), "HH:mm")
            End If
            If JamAwal <> "" And JamAkhir <> "" And JamDinas <> "" Then
                If JamDinas > JamAkhir Then
                    Tgl = Format(CDate(Tanggal), "dd/MM/yyyy")
                    TotMenit = DateDiff("n", Tgl & " " & JamDinas, DateAdd("d", 1, Tgl) & " " & JamAkhir)
                Else
                    TotMenit = DateDiff("n", JamDinas, JamAkhir)
                End If
                Hour = Int(Math.Abs(TotMenit) / 60)
                If Hour > 0 Then
                    Sisa = Hour * 60
                End If
                Minute = TotMenit - Sisa
                If Minute < 45 Then
                    Jam = 0
                Else
                    Jam = 1
                End If
                RetJam = Hour + Jam
            ElseIf JamAwal <> "" And JamAkhir <> "" Then
                If JamAwal > JamAkhir Then
                    Tgl = Format(CDate(Tanggal), "dd/MM/yyyy")
                    TotMenit = DateDiff("n", Tgl & " " & JamAwal, DateAdd("d", 1, Tgl) & " " & JamAkhir)
                Else
                    TotMenit = DateDiff("n", JamAwal, JamAkhir)
                End If
                Hour = Int(Math.Abs(TotMenit) / 60)
                If Hour > 0 Then
                    Sisa = Hour * 60
                End If
                Minute = TotMenit - Sisa
                If Minute < 45 Then
                    Jam = 0
                Else
                    Jam = 1
                End If
                RetJam = Hour + Jam
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return RetJam
    End Function
    Public Function KeMenit(ByVal JamAwal As String, ByVal JamAkhir As String, ByVal JamDinas As String, ByVal Tanggal As Date) As Integer
        Dim menit As Long
        Dim Tgl As String
        Dim RetMenit As Integer = 0
        Try
            If Len(JamAwal) > 5 Then
                JamAwal = Format(CDate(JamAwal), "HH:mm")
            End If
            If Len(JamAkhir) > 5 Then
                JamAkhir = Format(CDate(JamAkhir), "HH:mm")
            End If
            If Len(JamDinas) > 5 Then
                JamDinas = Format(CDate(JamDinas), "HH:mm")
            End If
            If JamDinas <> "" And JamAkhir <> "" And JamDinas <> "" Then
                If JamDinas > JamAkhir Then
                    Tgl = Format(CDate(Tanggal), "dd/MM/yyyy")
                    menit = DateDiff("n", Tgl & " " & JamDinas, DateAdd("d", 1, Tgl) & " " & JamAkhir)
                Else
                    menit = DateDiff("n", JamDinas, JamAkhir)
                End If
            ElseIf JamAwal <> "" And JamAkhir <> "" Then
                If JamAwal > JamAkhir Then
                    Tgl = Format(CDate(Tanggal), "dd/MM/yyyy")
                    menit = DateDiff("n", Tgl & " " & JamAwal, DateAdd("d", 1, Tgl) & " " & JamAkhir)
                Else
                    menit = DateDiff("n", JamAwal, JamAkhir)
                End If
            End If
            RetMenit = Math.Abs(menit)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return RetMenit
    End Function
    Public Function MenitKeJam(ByVal TotMenit As Long) As Integer
        Dim hour As Long, minute As Long, Jam As Long
        Dim a As Long
        hour = 0 : minute = 0 : Jam = 0
        hour = Int(Math.Abs(TotMenit) / 60)
        If hour > 0 Then
            a = hour * 60
        End If
        minute = TotMenit - a
        If minute < 45 Then
            Jam = 0
        Else
            Jam = 1
        End If
        MenitKeJam = hour + Jam
    End Function
    Public Sub GetJabatan(ByVal cbo As ComboBox)
        cbo.DataSource = IsiCombo("select JabatanID,Jabatan from vwMstJabatan Order By Jabatan ").Tables(0)
        cbo.DisplayMember = "Jabatan"
        cbo.ValueMember = "JabatanID"
        cbo.SelectedIndex = -1
    End Sub
    'Public Function StyleColColor(ByVal FlexGrid As C1FlexGrid, ByVal ForeColor As Drawing.Color, ByVal Kolom As Integer) As C1.Win.C1FlexGrid.CellStyle
    '    Dim Style As C1.Win.C1FlexGrid.CellStyle = Nothing
    '    Style = FlexGrid.Styles.Add("Style" & Kolom)
    '    Style.ForeColor = ForeColor
    '    Return Style
    'End Function
    Public Sub StyleFontBold(ByVal FlexGrid As C1FlexGrid, ByVal baris As Integer, ByVal KolomAwal As Integer, ByVal KolomAkhir As Integer, ByVal FontBold As Boolean)
        Dim cs As CellStyle = FlexGrid.Styles.Add("FontBold" & baris)
        If FontBold = True Then
            cs.Font = New Font("ARIAL", 7, FontStyle.Bold)
        Else
            cs.Font = New Font("ARIAL", 7, FontStyle.Regular)
        End If
        Dim crg As CellRange
        For i As Integer = KolomAwal To KolomAkhir
            crg = FlexGrid.GetCellRange(baris, i)
            crg.Style = cs
        Next
    End Sub
    Public Sub StyleForeColor(ByVal FlexGrid As C1FlexGrid, ByVal Warna As Drawing.Color, ByVal baris As Integer, ByVal KolomAwal As Integer, ByVal KolomAkhir As Integer, ByVal FontBold As Boolean)
        Dim cs As CellStyle = FlexGrid.Styles.Add("ForeColor" & baris)
        cs.ForeColor = Warna
        If FontBold = True Then
            cs.Font = New Font("ARIAL", 7, FontStyle.Bold)
        Else
            cs.Font = New Font("ARIAL", 7, FontStyle.Regular)
        End If
        For i As Integer = KolomAwal To KolomAkhir
            Dim crg As CellRange = FlexGrid.GetCellRange(baris, i)
            crg.Style = cs
        Next
    End Sub
    Public Sub StyleBackColor(ByVal FlexGrid As C1FlexGrid, ByVal Warna As Drawing.Color, ByVal baris As Integer, ByVal KolomAwal As Integer, ByVal KolomAkhir As Integer)
        Dim cs As CellStyle = FlexGrid.Styles.Add("BackColor" & baris)
        cs.BackColor = Warna
        For i As Integer = KolomAwal To KolomAkhir
            Dim crg As CellRange = FlexGrid.GetCellRange(baris, i)
            crg.Style = cs
        Next
    End Sub

    Public Function GetLiburNasional(ByVal Tanggal As String) As Boolean
        Dim Libur As Boolean = False
        Using koneksi As New SqlCommand("select * from STIPayroll..tblMstHariLiburNasional where HariLibur='" & Format(CDate(Tanggal), "yyyy-MM-dd") & "' ", OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows And DR.Read Then
                    Libur = True
                End If
            End Using
        End Using
        GetLiburNasional = Libur
    End Function

    Public Sub SetPeriode(ByVal dtPicker1 As DateTimePicker, ByVal dtPicker2 As DateTimePicker, ByVal cboTanggal As ComboBox)
        Dim Tgl1, Tgl2 As Date
        Dim tb As New DataTable
        tb.Clear()
        cboTanggal.ResetText()
        tb.Columns.Add("Text", GetType(String))
        tb.Columns.Add("Value", GetType(Date))
        If dtPicker1.Value.Day <= 25 Then
            dtPicker1.Value = "01/" & Format(dtPicker1.Value, "MM/yyyy")
            Tgl1 = CDate("26/" & Format(DateAdd("m", -1, dtPicker1.Value), "MM/yyyy"))
            Tgl2 = DateAdd("d", -1, DateAdd("m", 1, Tgl1))
            While Tgl1 <= Tgl2
                tb.Rows.Add(Format(Tgl1, "dd/MM/yyyy"), Format(Tgl1, "dd/MM/yyyy"))
                Tgl1 = DateAdd(DateInterval.Day, 1, Tgl1)
            End While
        Else
            dtPicker1.Value = "01/" & Format(DateAdd("m", 1, dtPicker1.Value), "MM/yyyy")
            Tgl1 = CDate("26/" & Format(DateAdd("m", -1, dtPicker1.Value), "MM/yyyy"))
            Tgl2 = DateAdd("d", -1, DateAdd("m", 1, Tgl1))
            While Tgl1 <= Tgl2
                tb.Rows.Add(Format(Tgl1, "dd/MM/yyyy"), Format(Tgl1, "dd/MM/yyyy"))
                Tgl1 = DateAdd(DateInterval.Day, 1, Tgl1)
            End While
        End If

        cboTanggal.DataSource = tb
        cboTanggal.DisplayMember = "Text"
        cboTanggal.ValueMember = "Value"
        cboTanggal.SelectedIndex = -1
    End Sub
    Public Sub SetPeriode2(ByVal dtPicker1 As DateTimePicker, ByVal dtPicker2 As DateTimePicker)
        If dtPicker1.Value.Day <= 25 Then
            dtPicker1.Value = "01/" & Format(dtPicker1.Value, "MM/yyyy")
        Else
            dtPicker1.Value = "01/" & Format(DateAdd("m", 1, dtPicker1.Value), "MM/yyyy")
        End If
    End Sub

    Public Sub GetJenisKelamin(ByVal cbo As ComboBox)
        With cbo
            Dim tb As New DataTable
            tb.Columns.Add("Text", GetType(String))
            tb.Columns.Add("Value", GetType(String))
            tb.Rows.Add("LAKI-LAKI", "L")
            tb.Rows.Add("PEREMPUAN", "P")
            .DataSource = tb
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
    End Sub
    Public Sub GetStatusJamKerja(ByVal cbo As ComboBox)
        With cbo
            Dim tb As New DataTable
            tb.Columns.Add("Text", GetType(String))
            tb.Columns.Add("Value", GetType(String))
            tb.Rows.Add("AI", "AI")
            tb.Rows.Add("OT", "OT")
            .DataSource = tb
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
    End Sub
    Public Sub GetHari(ByVal cbo As ComboBox)
        With cbo
            Dim tb As New DataTable
            tb.Columns.Add("Text", GetType(String))
            tb.Columns.Add("Value", GetType(Integer))
            tb.Rows.Add("Minggu", 1)
            tb.Rows.Add("Senin", 2)
            tb.Rows.Add("Selasa", 3)
            tb.Rows.Add("Rabu", 4)
            tb.Rows.Add("Kamis", 5)
            tb.Rows.Add("Jumat", 6)
            tb.Rows.Add("Sabtu", 7)
            .DataSource = tb
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
    End Sub
    Public Sub GetJenisTidakHadir(ByVal cbo As ComboBox)
        cbo.DataSource = IsiCombo("SELECT  IDTidakKerja,Nama FROM STISidikjari.dbo.tblMstTidakKerja").Tables(0)
        cbo.DisplayMember = "Nama"
        cbo.ValueMember = "IDTidakKerja"
        cbo.SelectedIndex = -1
    End Sub
End Module
