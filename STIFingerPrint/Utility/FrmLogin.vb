Imports System.Data.SqlClient

Public Class FrmLogin

    Public Function GetComputerName() As String
        Dim ComputerName As String
        ComputerName = System.Net.Dns.GetHostName
        Return ComputerName
    End Function

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim Cn As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Sql, User As String
        Dim Pass As String
        Dim cmd As New SqlCommand
        Dim DR As SqlDataReader
        User = Trim(UCase(UsernameTextBox.Text))
        ModuleKoneksi.OpenKoneksi.Close()
        If User = String.Empty Then
            MsgBox("UserID Tidak Boleh Kosong !", vbCritical, AT)
            UsernameTextBox.Focus()
            Exit Sub
        End If
        If PasswordTextBox.Text = String.Empty Then
            MsgBox("Password Tidak Boleh Kosong !", vbCritical, AT)
            PasswordTextBox.Focus()
            Exit Sub
        End If
        Try
            PCName = GetComputerName()
            Sql = "select UserID,Password,GroupID from  tblUtlUserLogin Where UserID='" & Replace(User, "'", "") & "'"
            cmd.CommandText = Sql
            cmd.Connection = ModuleKoneksi.OpenKoneksi
            DR = cmd.ExecuteReader
            DR.Read()
            If DR.HasRows = True Then
                Pass = DecryptText(DR.Item("Password"), User)
                'MsgBox(DecryptText(DR.Item("Password"), User))
                If UCase(Pass) = UCase(PasswordTextBox.Text) Then
                    With MDIMenu
                        .Show()
                        GroupID = DR.Item("GroupID")
                        UserLogin = DR.Item("UserID")
                        .Text = "© STI Fingerprint " & Format(Year(Now)) & " | User : " & UserLogin & " | Computer : " & PCName & " |  Version : " & My.Application.Info.Version.Major.ToString() & "." & My.Application.Info.Version.Minor.ToString & "." _
                                                     & My.Application.Info.Version.Build.ToString & "." & My.Application.Info.Version.Revision.ToString

                    End With
                    Call VersionLoad()
                    If VersiApp <> VersiFromDB And GroupID <> 1 Then
                        MsgBox("Application Available Version : " & VersiFromDB & ", Please Update Your Application !!!", MessageBoxIcon.Information, "Information")
                        Exit Sub
                    End If
                    Call VisibleMenuAkses()
                    Me.Close()
                Else
                    MsgBox("Maaf .. Password Anda Salah  !", vbCritical, AT)
                    SendKeys.Send(("{Home}") + ("{End}"))
                    PasswordTextBox.Focus()
                End If
            Else
                MsgBox("Maaf .. UserID ( " & User & ") Belum Terdaftar.", vbInformation, AT)
                SendKeys.Send(("{Home}") + ("{End}"))
                UsernameTextBox.Focus()
            End If
            DR.Close()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub VersionLoad()
        Dim sql As String
        Try
            sql = " select AppVersion from tblVersiApp where ID=( select max(ID) from tblVersiApp)"
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        While DR.Read
                            VersiFromDB = Trim(DR!AppVersion)
                        End While
                    End If
                    DR.Close()
                End Using
            End Using
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tb As New DataTable
        tb.Clear()
        tb.Columns.Add("Site", GetType(String))
        tb.Columns.Add("Value", GetType(String))
        tb.Rows.Add("STI", "192.168.20.2")
        tb.Rows.Add("PSG", "192.168.3.33")
        cboSite.DataSource = tb
        cboSite.DisplayMember = "Site"
        cboSite.ValueMember = "Value"
        cboSite.SelectedIndex = 0
        AppServer = cboSite.SelectedValue
        UsernameTextBox.Focus()
    End Sub

    Private Sub FrmLogin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        UsernameTextBox.Focus()
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Try
            Dispose()
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetMenues(ByVal Current As ToolStripItem, ByRef menues As List(Of ToolStripItem))
        menues.Add(Current)
        If TypeOf (Current) Is ToolStripMenuItem Then
            For Each menu As ToolStripItem In DirectCast(Current, ToolStripMenuItem).DropDownItems
                GetMenues(menu, menues)
            Next
        End If
    End Sub

    Public Sub VisibleMenuAkses()
        Dim menues As New List(Of ToolStripItem), SQL As String
        Try
            SQL = "SELECT DetailID,GroupID,Tag,Menu FROM STISidikjari.dbo.tblUtlGroupDetail where GroupID='" & GroupID & "' Order By Tag" ' xample
            Using koneksi As New SqlCommand(SQL, OpenKoneksi)
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        Do While DR.Read()
                            For Each t As ToolStripItem In MDIMenu.MenuStrip.Items
                                GetMenues(t, menues)
                            Next
                            For Each t As ToolStripItem In menues
                                If (Val(t.Tag) - Val(DR!Tag)) = 0 Then
                                    t.Visible = True
                                    Exit For
                                ElseIf Val(t.Tag) = 0 Then
                                    t.Visible = True
                                End If
                            Next
                        Loop
                    End If
                    DR.Close()
                End Using
            End Using
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PasswordTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        If e.KeyChar = Chr(13) Then
            Call OK_Click(sender, New System.EventArgs())
        End If
    End Sub

    Private Sub UsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UsernameTextBox.TextChanged

    End Sub

    Private Sub UsernameTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UsernameTextBox.KeyPress
        If e.KeyChar = Chr(13) Then
            PasswordTextBox.Focus()
            UsernameTextBox.Text = Trim(UsernameTextBox.Text)
        End If
    End Sub

    Private Sub cboSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSite.SelectedIndexChanged

    End Sub

    Private Sub cboSite_TextUpdate(sender As Object, e As EventArgs) Handles cboSite.TextUpdate
        ValidCombo(cboSite)
    End Sub

    Private Sub cboSite_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSite.SelectionChangeCommitted
        AppServer = cboSite.SelectedValue
    End Sub
End Class
