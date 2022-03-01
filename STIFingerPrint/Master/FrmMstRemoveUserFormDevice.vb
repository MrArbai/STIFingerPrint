Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking
Imports zkeuemkeeper
Public Class FrmMstRemoveUserFormDevice : Inherits DockContent
    Public axCZKEM As New zkeuemkeeper.CZKEUEM
    Private Sub FrmMstRemoveUserFormDevice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetDevice(cboDevice)
        Call SetGridDefult()
        btnKonek.BackColor = Color.Orange
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
            .AllowEditing = True
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 30
            .Cols.Frozen = 4
            .Cols.Count = 8
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pilih" : .Cols(1).Name = "Pilih" : .Cols(1).Width = 40 : .Cols(1).DataType = GetType(Boolean)
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "UserID" : .Cols(2).Name = "UserID" : .Cols(2).Width = 100
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nama" : .Cols(3).Name = "Nama" : .Cols(3).Width = 200
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Nik" : .Cols(4).Name = "Nik" : .Cols(4).Width = 100
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Departemen" : .Cols(5).Name = "Departemen" : .Cols(5).Width = 150
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Jabatan" : .Cols(6).Name = "Jabatan" : .Cols(6).Width = 200
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "FP" : .Cols(7).Name = "FP" : .Cols(7).Width = 40 : .Cols(7).Visible = False
        End With
    End Sub

    Private Sub btnKonek_Click(sender As Object, e As EventArgs) Handles btnKonek.Click
        Dim dwErrCode As Long
        Dim IPAddress As String
        Try
            If Trim(cboDevice.Text) = "" Then
                MsgBox("Device Belum Dipilih!", vbExclamation)
                Exit Sub
            End If
            IPAddress = GetDeviceIP(cboDevice.SelectedValue)
            DeviceNumber = cboDevice.SelectedValue
            Port = 4370
            Me.Cursor = Cursors.WaitCursor
            If btnKonek.Text = "Connect" Then
                dConn = axCZKEM.Connect_Net(IPAddress, Port)

                If dConn Then
                    axCZKEM.ACUnlock(DeviceNumber, 1)
                    btnKonek.Text = "Disconnect"
                    btnKonek.BackColor = Color.GreenYellow
                    axCZKEM.RegEvent(DeviceNumber, 65535)
                    Me.Cursor = Cursors.Default
                Else
                    axCZKEM.GetLastError(dwErrCode)
                    MsgBox("Error Description " & dwErrCode, vbCritical, "Can't Connect Device")
                    DeviceNumber = 0
                    Me.Cursor = Cursors.Default
                End If
            Else
                axCZKEM.Disconnect()
                axCZKEM.Beep(20)
                btnKonek.Text = "Connect"
                btnKonek.BackColor = Color.Orange
                dConn = False
                DeviceNumber = 0
                Me.Cursor = Cursors.Default
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("Errorr : " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ada As Boolean = False
        For i As Integer = 1 To fg.Rows.Count - 1
            If Convert.ToBoolean(fg.Item(i, "Pilih")) = True Then
                ada = True
                Exit For
            End If
        Next
        If ada = False Then
            MsgBox("Tidak Ada Data Yang Akan Dihapus!", MessageBoxIcon.Stop)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If HapusTemplate() = True Then
            MsgBox("Template Berhasil di hapus!", vbInformation)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        MsgBox("Template Gagal di hapus!", vbInformation)
        Me.Cursor = Cursors.Default
    End Sub
    Private Function HapusTemplate() As Boolean
        Dim EnrollNum As String
        Dim BkfNumber As Integer
        Dim ret As Boolean
        ret = False
        If dConn = False Then
            MsgBox("Please Connect Device First", vbCritical, "Connect Device")
            Exit Function
        End If
        Try
            With fg
                For i As Integer = 1 To fg.Rows.Count - 1
                    If Convert.ToBoolean(.Item(i, "Pilih")) = True And .Item(i, "UserID") <> "" Then
                        EnrollNum = .Item(i, "UserID")
                        BkfNumber = 12
                        If axCZKEM.SSR_DeleteEnrollData(DeviceNumber, EnrollNum, BkfNumber) Then

                        End If
                    End If
                Next
                axCZKEM.RefreshData(DeviceNumber)
                ret = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return ret
    End Function

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim EnrollNum As String
        Dim Nama As String, passWD As String
        Dim Privilege As Long
        Dim en As Boolean
        Dim i As Integer = 1

        If dConn = False Then
            MsgBox("Please Connect Device First", vbCritical, "Connect Device")
            Exit Sub
        End If
        Try
            With fg
                axCZKEM.EnableDevice(DeviceNumber, 1)
                axCZKEM.ReadAllUserID(DeviceNumber)
                .Rows.Count = 1
                While axCZKEM.SSR_GetAllUserInfo(DeviceNumber, EnrollNum, Nama, passWD, Privilege, en)
                    .AddItem("")
                    .Item(i, "No") = i
                    .Item(i, "UserID") = EnrollNum
                    .Item(i, "Nama") = Nama
                    Call GetData(EnrollNum, i)
                    i = i + 1
                End While

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GetData(ByVal userID As Long, ByVal baris As Integer)
        Dim sql As String = ""
        sql = "select * from vwMstUser where userID='" & userID & "' "
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg
                        While DR.Read
                            .Item(baris, "Nik") = DR!Nik
                            .Item(baris, "Departemen") = DR!Departemen
                            .Item(baris, "Jabatan") = DR!JabatanName
                        End While
                    End With
                End If
            End Using
        End Using
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        Select Case fg.Cols(e.Col).Name
            Case "Pilih"
                e.Cancel = False
            Case Else
                e.Cancel = True
        End Select
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked = True Then
            chkAll.Text = "UnChek All"
            For i As Integer = 1 To fg.Rows.Count - 1
                If Convert.ToDouble(fg.Item(i, "UserID")) > 0 Then
                    fg.Item(i, "Pilih") = True
                End If
            Next
        Else
            chkAll.Text = "Chek All"
            For i As Integer = 1 To fg.Rows.Count - 1
                If Convert.ToDouble(fg.Item(i, "UserID")) > 0 Then
                    fg.Item(i, "Pilih") = False
                End If
            Next
        End If
    End Sub
End Class