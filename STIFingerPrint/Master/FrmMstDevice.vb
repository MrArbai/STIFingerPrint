Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking
Imports zkeuemkeeper
Public Class FrmMstDevice : Inherits DockContent
    Public axCZKEM As New zkeuemkeeper.CZKEUEM
    Dim PerintahList As String
    Private Sub FrmMstDevice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call EnableBtnDevList(False)
        Call EnableTxtDevList(False)
        Call GetConectionType(cboConectionType)
        Call SetGridDefult()
        Call GetListDevice()
        Call GetSch()
        Call GetDevice(cboDevice)
        Call GetDevice(cboDeviceSch)
        PerintahList = ""
        dtDeviceTime.Value = Now
        dConn = False
        btnKonek.BackColor = Color.Orange
    End Sub
    Private Sub EnableTxtDevList(ByVal flag As Boolean)
        txtDeviceID.Enabled = False
        txtDeviceName.Enabled = flag
        cboConectionType.Enabled = flag
        txtComPort.Enabled = False
        txtBaudRate.Enabled = False
        txtIPAddress.Enabled = False
        txtPort.Enabled = False
    End Sub
    Private Sub EnableBtnDevList(ByVal flag As Boolean)
        btnAddDevice.Enabled = Not flag
        btnEditDevice.Enabled = Not flag
        btnSaveDevice.Enabled = flag
        btnDeleteDevice.Enabled = flag
        btnCancelDevice.Enabled = flag
        btnCloseDevice.Enabled = Not flag
    End Sub

    Private Sub CleareTxtDevList()
        txtDeviceID.Clear()
        txtDeviceName.Clear()
        cboConectionType.ResetText()
    End Sub

    Private Sub btnAddDevice_Click(sender As Object, e As EventArgs) Handles btnAddDevice.Click
        Call EnableBtnDevList(True)
        Call EnableTxtDevList(True)
        Call CleareTxtDevList()
        PerintahList = "ADD"
    End Sub

    Private Sub btnEditDevice_Click(sender As Object, e As EventArgs) Handles btnEditDevice.Click
        If Trim(txtDeviceID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Diedit!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Call EnableBtnDevList(True)
        Call EnableTxtDevList(True)
        PerintahList = "EDIT"
    End Sub

    Private Sub btnSaveDevice_Click(sender As Object, e As EventArgs) Handles btnSaveDevice.Click
        If Trim(txtDeviceName.Text) = "" Then
            MsgBox("Device Name Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(cboConectionType.Text) = "" Then
            MsgBox("Conecction Type Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(txtIPAddress.Text) = "" Then
            MsgBox("IP Address Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Trim(txtPort.Text) = "" Then
            MsgBox("Port Masih Kosong!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If CekIP() = True Then
            MsgBox("IP Address " & Trim(txtIPAddress.Text) & " Sudah Ada,Silakan Cek Kembali!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction

        Me.Cursor = Cursors.WaitCursor
        If SimpanDevice(Koneksi, Transaksi) = False Then
            MsgBox("Simpan Data Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
            Me.Cursor = Cursors.Default
            Transaksi.Rollback()
            Exit Sub
        End If
        Transaksi.Commit()
        Me.Cursor = Cursors.Default
        MsgBox("Simpan Data Berhasil!", vbInformation)
        Call EnableBtnDevList(False)
        Call EnableTxtDevList(False)
        Call CleareTxtDevList()
        Call GetListDevice()
        PerintahList = "SAVE"
    End Sub

    Private Sub btnDeleteDevice_Click(sender As Object, e As EventArgs) Handles btnDeleteDevice.Click
        If Trim(txtDeviceID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Hapus!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MessageBox.Show("Anda Ingin Menghapus IP Adrress : " & txtIPAddress.Text & " Ini?", "Delete", MessageBoxButtons.YesNo) = vbYes Then
            Call HapusDevList()
            Call EnableBtnDevList(False)
            Call EnableTxtDevList(False)
            Call CleareTxtDevList()
            Call GetListDevice()
            PerintahList = "DELETE"
        End If
    End Sub

    Private Sub btnCancelDevice_Click(sender As Object, e As EventArgs) Handles btnCancelDevice.Click
        Call EnableBtnDevList(False)
        Call EnableTxtDevList(False)
        Call CleareTxtDevList()
        PerintahList = "CANCEL"
    End Sub

    Private Sub btnCloseDevice_Click(sender As Object, e As EventArgs) Handles btnCloseDevice.Click
        Me.Close()
    End Sub

    Private Sub SetGridDefult()
        Dim txt As CellRange
        With fgDeviceList
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Thistle
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
            .Cols.Count = 8
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "DeviceID" : .Cols(1).Name = "DeviceID" : .Cols(1).Width = 40 : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Device Name" : .Cols(2).Name = "DeviceName" : .Cols(2).Width = 200
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "ConType" : .Cols(3).Name = "ConType" : .Cols(3).Width = 100 : .Cols(3).Visible = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "IP" : .Cols(4).Name = "IP" : .Cols(4).Width = 150
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Port" : .Cols(5).Name = "Port" : .Cols(5).Width = 40 : .Cols(5).Visible = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "ComPort" : .Cols(6).Name = "ComPort" : .Cols(6).Width = 130 : .Cols(6).Visible = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Baud Rate" : .Cols(7).Name = "BaudRate" : .Cols(7).Width = 130 : .Cols(7).Visible = False
        End With
        With fgSch
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Thistle
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
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Sch.Time" : .Cols(1).Name = "SchTime" : .Cols(1).Width = 60 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Device Name" : .Cols(2).Name = "DeviceName" : .Cols(2).Width = 200
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "ID" : .Cols(3).Name = "ID" : .Cols(3).Width = 100 : .Cols(3).Visible = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "DevID" : .Cols(4).Name = "DevID" : .Cols(4).Width = 150 : .Cols(4).Visible = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Service" : .Cols(5).Name = "Service" : .Cols(5).Width = 80 : .Cols(5).TextAlign = TextAlignEnum.CenterCenter
        End With
    End Sub

    Private Function SimpanDevice(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        SimpanDevice = False
        Dim mycon As SqlConnection = conn
        Dim mycontrans As SqlTransaction = trans
        Try
            With cmd
                .Connection = conn
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spMstDeviceSave"
                .Transaction = mycontrans
                .Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.BigInt, 3, ParameterDirection.ReturnValue, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .Parameters.Add("@DevID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(txtDeviceID.Text)
                .Parameters.Add("@DevName", SqlDbType.VarChar, 50).Value = UCase(Trim(txtDeviceName.Text))
                .Parameters.Add("@DevCon", SqlDbType.VarChar, 50).Value = cboConectionType.SelectedValue
                .Parameters.Add("@IPAddr", SqlDbType.VarChar, 50).Value = Trim(txtIPAddress.Text)
                .Parameters.Add("@Port", SqlDbType.VarChar, 20).Value = Trim(txtPort.Text)
                .Parameters.Add("@ComPort", SqlDbType.VarChar, 20).Value = Trim(txtComPort.Text)
                .Parameters.Add("@BaudRate", SqlDbType.VarChar, 20).Value = Trim(txtBaudRate.Text)
                .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
                .ExecuteNonQuery()
            End With
            If Val(cmd.Parameters("@DevID").Value) > 0 Then txtDeviceID.Text = Val(cmd.Parameters("@DevID").Value)
            If CInt(cmd.Parameters("@Flag").Value) <> 0 Then
                cmd.Dispose()
                Exit Function
            End If
            cmd.Dispose()
            SimpanDevice = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return SimpanDevice
    End Function

    Private Sub GetListDevice()
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "SELECT DevID,DevName,DevCon,IPAddr,Port,ComPort,BaudRate,PosSatpam,EnabledClearLog,SecurityCheck,NotActive FROM STISidikjari.dbo.tblMstDevice Order By IPAddr"
        Me.Cursor = Cursors.WaitCursor
        fgDeviceList.Rows.Count = 1
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    With fgDeviceList
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "DeviceID") = DR!DevID
                            If IsDBNull(DR!DevName) = False Then .Item(i, "DeviceName") = DR!DevName
                            If IsDBNull(DR!DevCon) = False Then .Item(i, "ConType") = DR!DevCon
                            If IsDBNull(DR!IPAddr) = False Then .Item(i, "IP") = DR!IPAddr
                            If IsDBNull(DR!Port) = False Then .Item(i, "Port") = DR!Port
                            If IsDBNull(DR!ComPort) = False Then .Item(i, "ComPort") = DR!ComPort
                            If IsDBNull(DR!BaudRate) = False Then .Item(i, "BaudRate") = DR!BaudRate
                            i = i + 1
                        End While
                    End With
                Else
                    fgDeviceList.Rows.Count = 1
                    fgDeviceList.Rows.Count = 2
                    MsgBox("Data Tidak Ditemukan!", MsgBoxStyle.Information)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End Using
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Function CekIP() As Boolean
        Dim cek As Boolean = False
        Dim sql As String
        sql = "SELECT * from tblMstDevice where IPAddr='" & Trim(txtIPAddress.Text) & "' "
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    cek = True
                End If
            End Using
        End Using
        Return cek
    End Function
    Private Sub HapusDevList()
        Try
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn
                .CommandType = CommandType.Text
                .CommandText = "Delete tblMstDevice WHERE DevID='" & txtDeviceID.Text & "' "
                .ExecuteNonQuery()
            End With
            MsgBox("IP Address Berhasil Hapus", vbInformation, "Success")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub btnGetDevTime1_Click(sender As Object, e As EventArgs) Handles btnGetDevTime1.Click
        Dim idwErrorCode As Long
        Dim idwYear As Long
        Dim idwMonth As Long
        Dim idwDay As Long
        Dim idwHour As Long
        Dim idwMinute As Long
        Dim idwSecond As Long
        Try
            If dConn = False Then
                MsgBox("Please Connect Device First!", MessageBoxIcon.Warning, "Device Not Connected")
                cboDevice.Focus()
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            If axCZKEM.GetDeviceTime(DeviceNumber, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond) Then
                axCZKEM.RefreshData(DeviceNumber)
                txtDeviceTime.Text = idwYear & "-" & idwMonth & "-" & idwDay & " " & idwHour & ":" & idwMinute & ":" & Format(idwSecond, "00")
                Me.Cursor = Cursors.Default
            Else
                axCZKEM.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode= " & idwErrorCode, vbExclamation, "Error")
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSetDevTime1_Click(sender As Object, e As EventArgs) Handles btnSetDevTime1.Click
        Dim idwErrorCode As Long
        Dim idwYear As Long
        Dim idwMonth As Long
        Dim idwDay As Long
        Dim idwHour As Long
        Dim idwMinute As Long
        Dim idwSecond As Long
        Try
            If dConn = False Then
                MsgBox("Please Connect Device First!", MessageBoxIcon.Warning, "Device Not Connected")
                cboDevice.Focus()
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            If axCZKEM.SetDeviceTime(DeviceNumber) Then
                axCZKEM.RefreshData(DeviceNumber)
                MsgBox("Succesfully Sync Device Time", MessageBoxIcon.Information, "Success")
                If axCZKEM.GetDeviceTime(DeviceNumber, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond) Then
                    axCZKEM.RefreshData(DeviceNumber)
                    txtDeviceTime.Text = idwYear & "-" & idwMonth & "-" & idwDay & " " & idwHour & ":" & idwMinute & ":" & Format(idwSecond, "00")
                    Me.Cursor = Cursors.Default
                End If
            Else
                axCZKEM.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode= " & idwErrorCode, vbExclamation, "Error")
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnGetDevTime2_Click(sender As Object, e As EventArgs) Handles btnGetDevTime2.Click
        Dim idwErrorCode As Long
        Dim idwYear As Long
        Dim idwMonth As Long
        Dim idwDay As Long
        Dim idwHour As Long
        Dim idwMinute As Long
        Dim idwSecond As Long
        Try
            If dConn = False Then
                MsgBox("Please Connect Device First!", MessageBoxIcon.Warning, "Device Not Connected")
                cboDevice.Focus()
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            If axCZKEM.GetDeviceTime(DeviceNumber, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond) Then
                axCZKEM.RefreshData(DeviceNumber)
                dtDeviceTime.Value = idwYear & "-" & idwMonth & "-" & idwDay & " " & idwHour & ":" & idwMinute & ":" & Format(idwSecond, "00")
                Me.Cursor = Cursors.Default
                MsgBox("Succesfully Sync Device Time", MessageBoxIcon.Information, "Success")
            Else
                axCZKEM.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode= " & idwErrorCode, vbExclamation, "Error")
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSetDevTime2_Click(sender As Object, e As EventArgs) Handles btnSetDevTime2.Click
        Dim iYear As Long
        Dim iMonth As Long
        Dim iDay As Long
        Dim iHour As Long
        Dim iMinute As Long
        Dim iSecond As Long
        Dim idwErrorCode As Long
        Try
            If dConn = False Then
                MsgBox("Please Connect Device First!", MessageBoxIcon.Warning, "Device Not Connected")
                cboDevice.Focus()
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            iYear = Format(dtDeviceTime.Value, "yyyy")
            iMonth = Format(dtDeviceTime.Value, "MM")
            iDay = Format(dtDeviceTime.Value, "dd")
            iHour = Format(dtDeviceTime.Value, "HH")
            iMinute = Format(dtDeviceTime.Value, "mm")
            iSecond = 0
            If axCZKEM.SetDeviceTime2(DeviceNumber, iYear, iMonth, iDay, iHour, iMinute, iSecond) Then
                axCZKEM.RefreshData(DeviceNumber)
                Me.Cursor = Cursors.Default
                MsgBox("Succesfully Sync Device Time", MessageBoxIcon.Information, "Success")
            Else
                axCZKEM.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode= " & idwErrorCode, vbExclamation, "Error")
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSetDevTime3_Click(sender As Object, e As EventArgs) Handles btnSetDevTime3.Click
        Dim iYear As Long
        Dim iMonth As Long
        Dim iDay As Long
        Dim iHour As Long
        Dim iMinute As Long
        Dim iSecond As Long
        Dim idwErrorCode As Long
        Try
            If dConn = False Then
                MsgBox("Please Connect Device First!", MessageBoxIcon.Warning, "Device Not Connected")
                cboDevice.Focus()
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            iYear = Format(Now, "yyyy")
            iMonth = Format(Now, "MM")
            iDay = Format(Now, "dd")
            iHour = Format(Now, "HH")
            iMinute = Format(Now, "mm")
            iSecond = 0
            If axCZKEM.SetDeviceTime2(DeviceNumber, iYear, iMonth, iDay, iHour, iMinute, iSecond) Then
                axCZKEM.RefreshData(DeviceNumber)
                Me.Cursor = Cursors.Default
                MsgBox("Succesfully Sync Device Time", MessageBoxIcon.Information, "Success")
            Else
                axCZKEM.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode= " & idwErrorCode, vbExclamation, "Error")
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSetDevTime4_Click(sender As Object, e As EventArgs) Handles btnSetDevTime4.Click
        Dim iYear As Long
        Dim iMonth As Long
        Dim iDay As Long
        Dim iHour As Long
        Dim iMinute As Long
        Dim iSecond As Long
        Dim idwErrorCode As Long
        Dim TglJam As String
        Try
            If dConn = False Then
                MsgBox("Please Connect Device First!", MessageBoxIcon.Warning, "Device Not Connected")
                cboDevice.Focus()
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            TglJam = GetDate()
            iYear = Format(CDate(TglJam), "yyyy")
            iMonth = Format(CDate(TglJam), "MM")
            iDay = Format(CDate(TglJam), "dd")
            iHour = Format(CDate(TglJam), "HH")
            iMinute = Format(CDate(TglJam), "mm")
            iSecond = 0
            If axCZKEM.SetDeviceTime2(DeviceNumber, iYear, iMonth, iDay, iHour, iMinute, iSecond) Then
                axCZKEM.RefreshData(DeviceNumber)
                Me.Cursor = Cursors.Default
                MsgBox("Succesfully Sync Device Time", MessageBoxIcon.Information, "Success")
            Else
                axCZKEM.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode= " & idwErrorCode, vbExclamation, "Error")
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
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

    Private Sub fgDeviceList_MouseHover(sender As Object, e As EventArgs) Handles fgDeviceList.MouseHover
        Try
            If fgDeviceList.MouseRow > 0 Then
                Dim tip As String = "Double Clik Disini Untuk Edit Data!"
                ToolTip1.SetToolTip(fgDeviceList, tip)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fgDeviceList_Click(sender As Object, e As EventArgs) Handles fgDeviceList.Click

    End Sub

    Private Sub fgDeviceList_DoubleClick(sender As Object, e As EventArgs) Handles fgDeviceList.DoubleClick
        With fgDeviceList
            If Convert.ToInt32(.Item(.Row, "DeviceID")) > 0 Then
                txtDeviceID.Text = .Item(.Row, "DeviceID")
                txtDeviceName.Text = .Item(.Row, "DeviceName")
                If .Item(.Row, "ConType") = 1 Then
                    cboConectionType.Text = "USB"
                Else
                    cboConectionType.Text = "ETHERNET"
                End If
                txtIPAddress.Text = .Item(.Row, "IP")
                txtPort.Text = .Item(.Row, "Port")
                txtComPort.Text = .Item(.Row, "ComPort")
                txtBaudRate.Text = .Item(.Row, "BaudRate")
            Else
                Call CleareTxtDevList()
            End If
        End With
    End Sub

    Private Sub cboDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDevice.SelectedIndexChanged

    End Sub

    Private Sub cboDevice_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDevice.SelectionChangeCommitted
        DeviceNumber = cboDevice.SelectedValue
    End Sub

    Private Sub cboDevice_TextUpdate(sender As Object, e As EventArgs) Handles cboDevice.TextUpdate
        ValidCombo(cboDevice)
    End Sub


    Private Sub cboConectionType_TextUpdate(sender As Object, e As EventArgs) Handles cboConectionType.TextUpdate
        ValidCombo(cboConectionType)
    End Sub

    Private Sub cboConectionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConectionType.SelectedIndexChanged

    End Sub

    Private Sub cboConectionType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboConectionType.SelectedValueChanged
        If PerintahList = "ADD" Or PerintahList = "EDIT" Then
            If Trim(cboConectionType.Text) = "USB" Then
                txtComPort.Enabled = True
                txtBaudRate.Enabled = True
                txtIPAddress.Enabled = False
                txtPort.Enabled = False
            ElseIf Trim(UCase(cboConectionType.Text)) = UCase("ETHERNET") Then
                txtComPort.Enabled = False
                txtBaudRate.Enabled = False
                txtIPAddress.Enabled = True
                txtPort.Enabled = True
            Else
                txtComPort.Enabled = False
                txtBaudRate.Enabled = False
                txtIPAddress.Enabled = False
                txtPort.Enabled = False
            End If
        End If
    End Sub

    Private Sub cboDeviceSch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDeviceSch.SelectedIndexChanged

    End Sub

    Private Sub cboDeviceSch_TextUpdate(sender As Object, e As EventArgs) Handles cboDeviceSch.TextUpdate
        ValidCombo(cboDeviceSch)
    End Sub
    Private Function SimpanSch(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        SimpanSch = False
        Dim mycon As SqlConnection = conn
        Dim mycontrans As SqlTransaction = trans
        Try
            With cmd
                .Connection = conn
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spUpd_Schedule"
                .Transaction = mycontrans
                .Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.BigInt, 3, ParameterDirection.ReturnValue, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .Parameters.Add("@ID", SqlDbType.BigInt, ParameterDirection.InputOutput).Value = Val(txtID.Text)
                .Parameters.Add("@AttDownloadTime", SqlDbType.VarChar, 5).Value = Trim(txtTime.Text)
                .Parameters.Add("@DevID", SqlDbType.BigInt).Value = cboDeviceSch.SelectedValue
                If rdSeviceSTI.Checked = True Then
                    .Parameters.Add("@ServiceSite", SqlDbType.VarChar, 10).Value = "STI"
                Else
                    .Parameters.Add("@ServiceSite", SqlDbType.VarChar, 10).Value = "PSG"
                End If
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = UserLogin
                .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
                .ExecuteNonQuery()
            End With
            'If Val(cmd.Parameters("@ID").Value) > 0 Then txtID.Text = Val(cmd.Parameters("@ID").Value)
            If CInt(cmd.Parameters("@Flag").Value) <> 0 Then
                cmd.Dispose()
                Exit Function
            End If
            cmd.Dispose()
            SimpanSch = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return SimpanSch
    End Function

    Private Sub btnSaveSch_Click(sender As Object, e As EventArgs) Handles btnSaveSch.Click
        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Try
            If Trim(cboDeviceSch.Text) = "" Then
                MsgBox("Device Belum Dipilih!!", MessageBoxIcon.Warning, "Warning!")
                Exit Sub
            End If
            If txtTime.Text = "  :" Then
                MsgBox("Jam Belum Diinputkan!", MessageBoxIcon.Warning, "Warning!")
                Exit Sub
            End If
            If CekSch() = True Then
                MsgBox("Jam : " & txtTime.Text & " Sudah Ada, Silakan Ganti Jam Lain!", MessageBoxIcon.Warning, "Warning!")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            If SimpanSch(Koneksi, Transaksi) = False Then
                MsgBox("Simpan Data Gagal,Silakan Cek Data Anda!", vbCritical, "Failed")
                Me.Cursor = Cursors.Default
                Transaksi.Rollback()
                Exit Sub
            End If
            Transaksi.Commit()
            Call CleareTxtSch()
            Call GetSch()
            Me.Cursor = Cursors.Default
            MsgBox("Simpan Data Berhasil!", vbInformation)
        Catch ex As Exception
            Transaksi.Rollback()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetSch()
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "SELECT ID,AttDownloadTime,a.DevID,b.DevName,AppDownload,ServiceSite FROM tblUpd_Schedule a join tblMstDevice b on a.DevID=b.DevID Order by AttDownloadTime"
        Me.Cursor = Cursors.WaitCursor
        fgSch.Rows.Count = 1
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    With fgSch
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            If IsDBNull(DR!AttDownloadTime) = False Then .Item(i, "SchTime") = DR!AttDownloadTime
                            If IsDBNull(DR!DevName) = False Then .Item(i, "DeviceName") = DR!DevName
                            If IsDBNull(DR!ID) = False Then .Item(i, "ID") = DR!ID
                            If IsDBNull(DR!DevID) = False Then .Item(i, "DevID") = DR!DevID
                            If IsDBNull(DR!ServiceSite) = False Then .Item(i, "Service") = DR!ServiceSite
                            i = i + 1
                        End While
                    End With
                Else
                    fgSch.Rows.Count = 1
                    fgSch.Rows.Count = 2
                    MsgBox("Data Tidak Ditemukan!", MsgBoxStyle.Information)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End Using
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fgSch_Click(sender As Object, e As EventArgs) Handles fgSch.Click

    End Sub
    Private Sub CleareTxtSch()
        txtTime.Clear()
        txtID.Clear()
        cboDeviceSch.ResetText()
    End Sub
    Private Sub fgSch_DoubleClick(sender As Object, e As EventArgs) Handles fgSch.DoubleClick
        With fgSch
            If Convert.ToInt32(.Item(.Row, "ID")) > 0 Then
                txtID.Text = .Item(.Row, "ID")
                txtTime.Text = .Item(.Row, "SchTime")
                cboDeviceSch.Text = .Item(.Row, "DeviceName")
            Else
                CleareTxtSch()
            End If
        End With
    End Sub

    Private Sub fgSch_MouseHover(sender As Object, e As EventArgs) Handles fgSch.MouseHover
        Try
            If fgSch.MouseRow > 0 Then
                Dim tip As String = "Double Clik Disini Untuk Edit Data!"
                ToolTip1.SetToolTip(fgSch, tip)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function CekSch() As Boolean
        Dim cek As Boolean = False
        Dim sql As String
        If rdServicePSG.Checked = True Then
            sql = "select * from tblUpd_Schedule where AttDownloadTime='" & Trim(txtTime.Text) & "' and ServiceSite='PSG' "
        Else
            sql = "select * from tblUpd_Schedule where AttDownloadTime='" & Trim(txtTime.Text) & "' and ServiceSite='STI'   "
        End If

        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    cek = True
                End If
            End Using
        End Using
        Return cek
    End Function

    Private Sub btnDeleteSch_Click(sender As Object, e As EventArgs) Handles btnDeleteSch.Click
        Try
            If Trim(txtID.Text) = "" Then
                MsgBox("Tidak Ada Data Yang Akan Hapus!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MessageBox.Show("Anda Ingin Menghapus Jam Downlaod : " & txtTime.Text & " Ini?", "Delete", MessageBoxButtons.YesNo) = vbYes Then
                Call OpenKoneksi()
                CMD = Conn.CreateCommand
                With CMD
                    .Connection = Conn
                    .CommandType = CommandType.Text
                    .CommandText = "Delete tblUpd_Schedule WHERE ID='" & txtID.Text & "' "
                    .ExecuteNonQuery()
                End With
                MsgBox("Data Berhasil di Hapus", vbInformation, "Success")
                Call GetSch()
                Call CleareTxtSch()
            End If
            Call CleareTxtSch()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class