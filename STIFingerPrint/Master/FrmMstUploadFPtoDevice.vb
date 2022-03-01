Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports ZkSoftwareEU
Imports zkeuemkeeper
Imports System.ComponentModel
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMstUploadFPtoDevice : Inherits DockContent
    Public axCZKEM As New zkeuemkeeper.CZKEUEM
    Private Sub FrmMstUploadFPtoDevice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetDevice(cboDevice)
        Call GetDepartemen(cboDepartemen)
        Call SetGridDefult()
        Call GetStatusTK(cboStatus)
        btnKonek.BackColor = Color.Orange
    End Sub
    Private Sub cboDevice_TextUpdate(sender As Object, e As EventArgs) Handles cboDevice.TextUpdate
        ValidCombo(cboDevice)
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
            .AllowEditing = True
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 30
            .Cols.Frozen = 0
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pilih" : .Cols(1).Name = "Pilih" : .Cols(1).Width = 40 : .Cols(1).DataType = GetType(Boolean)
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "UserID" : .Cols(2).Name = "UserID" : .Cols(2).Width = 80
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nama" : .Cols(3).Name = "Nama" : .Cols(3).Width = 200
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Nik" : .Cols(4).Name = "Nik" : .Cols(4).Width = 100
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Departemen" : .Cols(5).Name = "Departemen" : .Cols(5).Width = 150
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Jabatan" : .Cols(6).Name = "Jabatan" : .Cols(6).Width = 200
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "FP" : .Cols(7).Name = "FP" : .Cols(7).Width = 40
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Status TK" : .Cols(8).Name = "StatusTk" : .Cols(8).Width = 100
        End With
    End Sub
    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 1
        Dim Status As String = ""
        Select Case cboStatus.SelectedValue
            Case 1
                Status = "KARYAWAN"
            Case 2
                Status = "HARIAN"
            Case Else
                Status = "TAMU"
        End Select
        Select Case cboStatus.SelectedValue
            Case 1, 2
                sql = "select a.RegNo,b.UserID,a.NIK,a.NAMA,a.JabatanName,a.Departemen,COUNT(c.FingerID) as FP,a.StatusTK from vwMstUser a join tblMstUser b on a.UserID=b.UserID " &
                " join tblMstFinger c on b.UserID=c.UserID where a.StatusTK='" & Status & "' "
            Case Else
                sql = "select a.RegNo,b.UserID,a.NIK,a.NAMA,a.JabatanName,a.Departemen,COUNT(c.FingerID) as FP,a.StatusTK from vwMstUserTamu a join tblMstUser b on a.UserID=b.UserID " &
                " join tblMstFinger c on b.UserID=c.UserID where a.StatusTK='" & Status & "' "
        End Select

        If Trim(txtNik.Text) <> "" And Trim(cboDepartemen.Text) <> "" Then
            sql = sql & " and a.NIK='" & Trim(txtNik.Text) & "' and a.DeptID=" & cboDepartemen.SelectedValue & " "
        ElseIf Trim(txtNik.Text) <> "" And Trim(cboDepartemen.Text) = "" Then
            sql = sql & " and a.NIK='" & Trim(txtNik.Text) & "' "
        ElseIf Trim(txtNik.Text) = "" And Trim(cboDepartemen.Text) <> "" Then
            sql = sql & " and a.DeptID=" & cboDepartemen.SelectedValue & " "
        End If
        sql = sql & " Group by a.RegNo,b.UserID,a.NIK,a.NAMA,a.JabatanName,a.Departemen,a.StatusTK Order By a.NAMA"

        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg.Rows.Count = 1
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "UserID") = DR!UserID
                            .Item(i, "NIK") = DR!NIK
                            .Item(i, "NAMA") = DR!NAMA
                            .Item(i, "Jabatan") = DR!JabatanName
                            .Item(i, "Departemen") = DR!Departemen
                            .Item(i, "FP") = DR!FP
                            .Item(i, "StatusTk") = DR!StatusTk
                            i = i + 1
                        End While
                    End With
                Else
                    fg.Rows.Count = 1
                    fg.Rows.Count = 2
                End If
            End Using
        End Using
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Trim(cboStatus.Text) = "" Then
            MsgBox("Status Belum Dipilih!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Call GetData()
        Me.Cursor = Cursors.Default
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
    Private Function UplaodTemplate(ByVal UserID As String, ByVal Nama As String) As Boolean
        Dim sql As String
        Dim dwErrCode As Long
        Dim ret As Boolean = False
        Try
            If axCZKEM.SSR_SetUserInfo(DeviceNumber, UserID, Nama, "", 0, True) Then
                sql = "SELECT * from tblMstFinger Where Userid='" & UserID & "' "
                Using koneksi As New SqlCommand(sql, OpenKoneksi)
                    koneksi.CommandTimeout = 0
                    Using DR = koneksi.ExecuteReader
                        If DR.HasRows Then
                            While DR.Read
                                If axCZKEM.SetUserTmpExStr(DeviceNumber, UserID, DR!FingerID, DR!iFlag, DR!FingerDataStr) Then
                                    axCZKEM.RefreshData(DeviceNumber)
                                    ret = True
                                Else
                                    axCZKEM.GetLastError(dwErrCode)
                                    If dwErrCode <> -5 Then
                                        MsgBox("Upload Fingerprint Failed" & vbNewLine & "Description")
                                    End If
                                End If
                            End While
                        End If
                    End Using
                    axCZKEM.EnableDevice(DeviceNumber, True)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return ret
    End Function

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim i, j, n As Integer
        Dim pilih As Boolean = False
        Dim ada As Boolean = False
        Dim ret As Boolean = False
        Me.Cursor = Cursors.WaitCursor

        If dConn Then
            With fg
                For j = 1 To .Rows.Count - 1
                    If .Item(j, "Pilih") = True Then
                        pilih = True
                    End If
                Next
                If pilih = False Then
                    Me.Cursor = Cursors.Default
                    MsgBox("Tidak Ada Data Yang Dipilih!", vbCritical, "Warning!")
                    Exit Sub
                End If
                If ada = True Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                For i = 1 To .Rows.Count - 1
                    If .Item(i, "Pilih") = True Then
                        ret = UplaodTemplate(.Item(i, "UserID"), .Item(i, "Nama"))
                    End If
                Next
            End With
            If ret = True Then
                MsgBox("Upload Finger Berhasil!", vbInformation)
            End If
        Else
            Me.Cursor = Cursors.Default
            MsgBox("Silakan Konekkan Mesin Finger Terlebih Dahulu!", vbCritical)
            Exit Sub
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FrmMstUploadFPtoDevice_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        axCZKEM.Disconnect()
        axCZKEM.Beep(20)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        dConn = False
        axCZKEM.Disconnect()
        axCZKEM.Beep(20)
        Me.Close()
    End Sub

    Private Sub CheckAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAll.CheckedChanged
        With fg
            If CheckAll.Checked = True Then
                For i As Integer = 1 To .Rows.Count - 1
                    .Item(i, "Pilih") = True
                Next
            Else
                For i As Integer = 1 To .Rows.Count - 1
                    .Item(i, "Pilih") = False
                Next
            End If
        End With
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged

    End Sub

    Private Sub cboStatus_TextUpdate(sender As Object, e As EventArgs) Handles cboStatus.TextUpdate
        ValidCombo(cboStatus)
    End Sub
End Class