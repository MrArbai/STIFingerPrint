Imports System.Data.SqlClient
Imports WeifenLuo.WinFormsUI.Docking

Module ModuleKoneksi
    Public AT As String = "Finger Print"
    Public Conn As SqlConnection
    Public DA As SqlDataAdapter
    Public DS As DataSet
    Public CMD As SqlCommand
    Public UserLogin As String
    Public GroupID As Integer
    Public PCName As String

    'Public Const AppServer As String = "192.168.20.2"
    'Public Const AppServer As String = "192.168.3.33"
    Public AppServer As String
    Public Const AppDB As String = "STISidikjari"
    Public Const AppUser As String = "sa"
    Public Const apppwd As String = "sti2016.com"

    Function OpenKoneksi() As SqlConnection
        Conn = New SqlConnection("server= " & AppServer & "; database=" & AppDB & "; user= " & AppUser & "; password=" & apppwd & ";" & "pooling=false;" & "Max Pool Size=1000;" & "Connection Timeout=10; ")
        If Conn.State = ConnectionState.Closed Then
            Try
                Conn.Open()
            Catch ex As Exception
                MsgBox("Koneksi Ke Server Gagal !", vbExclamation)
            End Try
        End If
        Return Conn
    End Function
    Public Sub CloseConnect()
        If Conn.State = ConnectionState.Open Then
            Try
                Conn.Close()
            Catch ex As Exception
                MsgBox("Gagal Menutup Koneksi Database  !", vbCritical, AT)
            End Try
        End If
    End Sub
    Public Sub CenterForm(ByVal frm As Form)
        frm.Width = 788
        frm.Height = 645
        frm.Left = (Screen.PrimaryScreen.WorkingArea.Width - frm.Width) / 2
        frm.Top = (Screen.PrimaryScreen.WorkingArea.Height - frm.Height) / 2
    End Sub
    Public Sub OpenForm(ByVal Frm As Form, ByVal Penuh As Boolean)
        'Dim i As Integer
        Dim f As New DockContent
        f = Frm
        f.MdiParent = MDIMenu
        If Penuh = True Then
            f.WindowState = FormWindowState.Maximized
        End If
        f.Show(MDIMenu.DockPanel1, DockState.Document)
        f.BackColor = Color.LightSteelBlue
        'For i = 0 To Application.OpenForms.Count - 1
        '    If Application.OpenForms.Item(i).Name.ToString = Frm.Name.ToString Then
        '        Frm.Focus()
        '    Else
        '        Frm.MdiParent = MDIMenu
        '        If Penuh = True Then
        '            Frm.WindowState = FormWindowState.Maximized
        '        End If
        '        Frm.Show()
        '        Frm.BackColor = Color.LightSteelBlue
        '        Dim ctl As Control
        '        For Each ctl In Frm.Controls
        '            If TypeOf ctl Is Label Or TypeOf ctl Is RadioButton Then ctl.ForeColor = Color.White
        '            If TypeOf ctl Is GroupBox Then
        '                Dim Ctl1 As Control
        '                For Each Ctl1 In ctl.Controls
        '                    If TypeOf Ctl1 Is Label Or TypeOf ctl Is RadioButton Then
        '                        ctl.ForeColor = Color.Black
        '                    End If
        '                Next
        '            End If
        '        Next
        '    End If
        'Next i
    End Sub

    Public Function IsiCombo(ByVal sql As String) As DataSet
        Dim ds As New DataSet
        Dim da As SqlDataAdapter
        Try
            da = New SqlDataAdapter(sql, ModuleKoneksi.OpenKoneksi)
            da.Fill(ds)
        Catch ex As Exception
            ds = Nothing
            MsgBox(ex.Message)
        End Try
        Return ds
    End Function

    Public Function EncryptText(strText As String, ByVal Kunci As String)
        Dim i As Integer, c As Integer
        Dim strBuff As String = ""

#If Not CASE_SENSITIVE_PASSWORD Then
        Kunci = UCase$(Kunci)

#End If

        If Len(Kunci) Then
            For i = 1 To Len(strText)
                c = Asc(Mid$(strText, i, 1))
                c = c + Asc(Mid$(Kunci, (i Mod Len(Kunci)) + 1, 1))
                strBuff = strBuff & Chr(c And &HFF)

            Next i
        Else
            strBuff = strText
        End If
        EncryptText = strBuff
    End Function
    Public Function DecryptText(strText As String, ByVal Kunci As String)
        Dim i As Integer, c As Integer, strBuff As String = ""

#If Not CASE_SENSITIVE_PASSWORD Then
        Kunci = UCase$(Kunci)
#End If

        If Len(Kunci) Then
            For i = 1 To Len(strText)
                c = Asc(Mid$(strText, i, 1))
                c = c - Asc(Mid$(Kunci, (i Mod Len(Kunci)) + 1, 1))
                strBuff = strBuff & Chr(c And &HFF)
            Next i
        Else
            strBuff = strText
        End If
        DecryptText = strBuff
    End Function

End Module
