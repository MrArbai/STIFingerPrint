Imports System.Data.SqlClient

Imports zkeuemkeeper
Imports System.Collections.Specialized
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports WeifenLuo.WinFormsUI.Docking

Public Class frmMstRegistrasiFinger : Inherits DockContent
    Public axCZKEM As New zkeuemkeeper.CZKEUEM
    Dim DeviceNumber As Integer

    Dim UserID As Long, FingerID As Integer
    Dim mpath As String, fName As String

    Dim sEnrollNumber As String
    Dim iIsInValid As Integer
    Dim iAttState As Integer
    Dim iVerifyMethod As Integer
    Dim iYear As Integer
    Dim iMonth As Integer
    Dim iDay As Integer
    Dim iHour As Integer
    Dim iMinute As Integer
    Dim iSecond As Integer
    Dim iWorkCode As Integer
    Dim startEnroll As Boolean
    Dim idFinger As Integer

    Private Sub frmMstRegistrasiFinger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetDevice(cboDevice)
        Call GetJari(cboJari)

        Call SetGridDefult()
        Call EnableBtn(False)
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
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Finger" : .Cols(1).Name = "Finger" : .Cols(1).Width = 200
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Result" : .Cols(2).Name = "Result" : .Cols(2).Width = 100
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "IDFinger" : .Cols(3).Name = "IDFinger" : .Cols(3).Width = 100 : .Cols(3).Visible = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Template" : .Cols(4).Name = "Template" : .Cols(4).Width = 150 : .Cols(4).Visible = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "tmpDataStrLength" : .Cols(5).Name = "tmpDataStrLength" : .Cols(5).Width = 40 : .Cols(5).Visible = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "iFlag" : .Cols(6).Name = "iFlag" : .Cols(6).Width = 130 : .Cols(6).Visible = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "HdrID" : .Cols(7).Name = "HdrID" : .Cols(7).Width = 130 : .Cols(7).Visible = False
        End With
        With fg2
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
            .Cols.Frozen = 4
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "UserID" : .Cols(1).Name = "UserID" : .Cols(1).Width = 100 : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "RegNo" : .Cols(2).Name = "RegNo" : .Cols(2).Width = 100 : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nama" : .Cols(3).Name = "Nama" : .Cols(3).Width = 200
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Nik" : .Cols(4).Name = "Nik" : .Cols(4).Width = 70
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Jabatan" : .Cols(5).Name = "Jabatan" : .Cols(5).Width = 150
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Departemen" : .Cols(6).Name = "Departemen" : .Cols(6).Width = 200
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "ID" : .Cols(7).Name = "ID" : .Cols(7).Width = 100 : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "FP" : .Cols(8).Name = "FP" : .Cols(8).Width = 60
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Status" : .Cols(9).Name = "Status" : .Cols(9).Width = 150
        End With
    End Sub

    Private Sub EnableBtn(ByVal flag As Boolean)
        btnAdd.Enabled = Not flag
        btnEdit.Enabled = Not flag
        btnSave.Enabled = flag
        btnDelete.Enabled = flag
        btnCancel.Enabled = flag

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
                lbrInfoRekam.Visible = False
                Me.Cursor = Cursors.Default
            End If
            If axCZKEM.RegEvent(DeviceNumber, 65535) Then
                AddHandler axCZKEM.OnEnrollFinger, AddressOf AxCZKEM1_OnEnrollFinger
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("Errorr : " & ex.Message)
        End Try
    End Sub

    Private Sub AxCZKEM1_OnEnrollFinger(EnrollNumber As Long, FingerIndex As Integer, ActionResult As Integer, TemplateLength As Integer)
        Dim tmpDataStr As String, tmpDataStrLength As Long
        Dim iFlag As Long
        Dim baris As Integer
        Dim i As Integer
        Dim ada As Boolean = False
        Select Case ActionResult
            Case 0
                Me.Cursor = Cursors.WaitCursor
                axCZKEM.GetUserTmpExStr(DeviceNumber, CStr(UserID), CLng(FingerID), iFlag, tmpDataStr, tmpDataStrLength)
                With fg
                    For i = 1 To fg.Rows.Count - 1
                        If Convert.ToInt32(fg.Item(i, "IDFinger")) = FingerID And IsNothing(fg.Item(i, "IDFinger")) = False Then
                            ada = True
                        End If
                    Next
                    Select Case iFlag
                        Case 0, 3
                        Case Else
                            If ada = False Then
                                idFinger = FingerID
                                .AddItem("")
                                baris = .Rows.Count - 2
                                .Item(baris, "No") = baris
                                .Item(baris, "IDFinger") = FingerID
                                .Item(baris, "Result") = "VALID"
                                .Item(baris, "iFlag") = iFlag
                                Select Case FingerID
                                    Case 0 : .Item(baris, "Finger") = "Jempol Kiri"
                                    Case 1 : .Item(baris, "Finger") = "Telunjuk Kiri"
                                    Case 2 : .Item(baris, "Finger") = "Jari Tengah Kiri"
                                    Case 3 : .Item(baris, "Finger") = "Jari Manis Kiri"
                                    Case 4 : .Item(baris, "Finger") = "Jari Kelingking Kiri"
                                    Case 5 : .Item(baris, "Finger") = "Jempol Kanan"
                                    Case 6 : .Item(baris, "Finger") = "Telunjuk Kanan"
                                    Case 7 : .Item(baris, "Finger") = "Jari Tengah Kanan"
                                    Case 8 : .Item(baris, "Finger") = "Jari Manis Kanan"
                                    Case 9 : .Item(baris, "Finger") = "Jari Kelingking Kanan"
                                End Select
                                If IsDBNull(tmpDataStr) = False Then .Item(baris, "Template") = tmpDataStr
                                .Item(baris, "tmpDataStrLength") = tmpDataStrLength
                                lbrInfoRekam.Visible = False
                            End If
                            Me.Cursor = Cursors.Default
                    End Select
                End With
            Case 3
                fg.RemoveItem(fg.Rows.Count - 2)
            Case 4
        End Select
    End Sub

    Private Sub txtNik_TextChanged(sender As Object, e As EventArgs) Handles txtNik.TextChanged

    End Sub


    Private Sub ClearTxt()
        txtUserID.Text = ""
        txtNama.Text = ""
        txtJabatan.Text = ""
        txtDepartemen.Text = ""
        txtNik.Text = ""
        PictureBox1.Image = Nothing
        fg.Rows.Count = 1
        fg.Rows.Count = 2
    End Sub

    Private Sub cboJari_TextUpdate(sender As Object, e As EventArgs) Handles cboJari.TextUpdate
        ValidCombo(cboJari)
    End Sub

    Private Sub cboJari_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboJari.SelectedIndexChanged

    End Sub

    Private Sub cboDevice_TextUpdate(sender As Object, e As EventArgs) Handles cboDevice.TextUpdate
        ValidCombo(cboDevice)
    End Sub

    Private Sub btnCancelEnroll_Click(sender As Object, e As EventArgs) Handles btnCancelEnroll.Click
        Try
            If dConn = False Then
                MsgBox("Silakan Konekkan Mesin Terlebih Dahulu!", vbCritical)
                Exit Sub
            End If
            If Convert.ToInt32(fg.Item(1, "IDFinger")) > 0 Then
                fg.RemoveItem(fg.Rows.Count - 2)
            End If
            lbrInfoRekam.Visible = False
            lbrInfoRekam.Visible = False
            axCZKEM.CancelOperation()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnDeleteEnroll_Click(sender As Object, e As EventArgs) Handles btnDeleteEnroll.Click
        Try
            If dConn = False Then
                MsgBox("Silakan Konekkan Mesin Terlebih Dahulu!", vbCritical)
                Exit Sub
            End If
            If Convert.ToInt32(fg.Item(1, "IDFinger")) > 0 Then
                If axCZKEM.SSR_DelUserTmpExt(DeviceNumber, CStr(UserID), CLng(fg.Item(fg.Rows.Count - 2, "IDFinger"))) Then
                    axCZKEM.RefreshData(DeviceNumber)
                    fg.RemoveItem(fg.Rows.Count - 2)
                    lbrInfoRekam.Visible = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btnStartEnroll_Click(sender As Object, e As EventArgs) Handles btnStartEnroll.Click
        If dConn = False Then
            MsgBox("Silakan Konekkan Mesin Terlebih Dahulu!", vbCritical)
            Exit Sub
        End If
        If Trim(txtUserID.Text) = "" Then
            MsgBox("Silakan Masukkan User Terlebih Dahulu!", vbCritical)
            txtNik.Focus()
            Exit Sub
        End If
        If Trim(cboJari.Text) = "" Then
            MsgBox("Silakan Pilih Jari User!", vbCritical)
            cboJari.Focus()
            Exit Sub
        End If

        Dim iFlag As Long
        Dim i As Integer
        Dim ada As Boolean = False
        Try
            For i = 1 To fg.Rows.Count - 1
                If Convert.ToInt32(fg.Item(i, "IDFinger")) = FingerID And IsNothing(fg.Item(i, "IDFinger")) = False Then
                    ada = True
                End If
            Next
            If ada = True Then
                MsgBox("Jari " & cboJari.Text & " Sudah Ada!", MsgBoxStyle.Critical, "Warning")
                Exit Sub
            End If
            startEnroll = False
            Me.Cursor = Cursors.WaitCursor
            UserID = Trim(txtUserID.Text)
            axCZKEM.CancelOperation()
            axCZKEM.SSR_DelUserTmpExt(DeviceNumber, UserID, FingerID)
            If axCZKEM.StartEnrollEx(UserID, FingerID, iFlag) Then
                axCZKEM.StartIdentify()
                axCZKEM.RegEvent(DeviceNumber, 8)
                startEnroll = True
                lbrInfoRekam.Visible = True
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDevice.SelectedIndexChanged

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call EnableBtn(True)
        Call ClearTxt()
        FrmFindMstRegistrasiFinger.ShowDialog()
        fg2.Enabled = True
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Call EnableBtn(True)
        fg2.Enabled = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call save()
        fg2.Enabled = True
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Trim(txtUserID.Text) = "" Then
            MsgBox("Tidak Ada Data Yang Akan Hapus!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MessageBox.Show("Anda Ingin Menghapus Template : " & txtNama.Text & " Ini?", "Delete", MessageBoxButtons.YesNo) = vbYes Then
            Call Hapus()
            Call EnableBtn(False)
            Call ClearTxt()
            fg2.Rows.Count = 1
            fg2.Rows.Count = 2
            fg2.Enabled = True
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call EnableBtn(False)
        Call ClearTxt()
        fg2.Enabled = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        axCZKEM.Disconnect()
        Me.Close()
    End Sub

    Private Sub cboJari_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboJari.SelectionChangeCommitted

        If rdKiri.Checked = True Then FingerID = cboJari.SelectedValue
        If rdKanan.Checked = True Then FingerID = 5 + cboJari.SelectedValue
        lbrInfoRekam.Visible = False
        axCZKEM.CancelOperation()
    End Sub

    Private Sub frmMstRegistrasiFinger_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        axCZKEM.Disconnect()
        axCZKEM.Beep(20)
    End Sub


    Private Sub save()
        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Dim i As Integer = 1
        Me.Cursor = Cursors.WaitCursor
        If IsNothing(fg.Item(1, "IDFinger")) = True Then
            MsgBox("Tidak Ada Data Yang Akan Disimpan!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Try
            For i = 1 To fg.Rows.Count - 1
                If Convert.ToInt32(fg.Item(i, "IDFinger")) >= 0 And fg.Item(i, "Result") = "VALID" Then
                    If Simpan(Koneksi, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        MsgBox("Simpan Data Template Gagal", vbCritical, "Save Template Failed")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
            Next
            If SimpanUser(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                MsgBox("Simpan Data User Gagal", vbCritical, "Save User Failed")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            Transaksi.Commit()
            Call EnableBtn(False)
            Call ClearTxt()
            MsgBox("Simpan Data Berhasil!", vbInformation)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Transaksi.Rollback()
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function Simpan(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal baris As Integer) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim ret As Boolean = False
        Try
            With cmd
                .Connection = Conn
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spMstFingerSave"
                .Transaction = MyConTrans
                .Parameters.Add("@HdrID", SqlDbType.BigInt).Value = Convert.ToInt32(fg.Item(baris, "HdrID"))
                .Parameters.Add("@UserID", SqlDbType.BigInt).Value = Val(txtUserID.Text)
                .Parameters.Add("@FingerID", SqlDbType.BigInt).Value = fg.Item(baris, "IDFinger")
                .Parameters.Add("@FingerDataStr", SqlDbType.VarChar, 50000).Value = fg.Item(baris, "Template")
                .Parameters.Add("@FingerDataLength", SqlDbType.BigInt).Value = fg.Item(baris, "tmpDataStrLength")
                .Parameters.Add("@iFlag", SqlDbType.Int).Value = fg.Item(baris, "iFlag")
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = UserLogin
                .Parameters.Add("@UpdatedBy", SqlDbType.VarChar, 50).Value = UserLogin
                .ExecuteNonQuery()
                ret = True
            End With
        Catch ex As Exception
            fg.RemoveItem(fg.Rows.Count - 2)
            lbrInfoRekam.Visible = False
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
        cmd.Dispose()
        Return ret
    End Function

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        Me.Cursor = Cursors.WaitCursor
        Call GetData()
        Call GetDataTamu()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fg2_Click(sender As Object, e As EventArgs) Handles fg2.Click

    End Sub

    Private Function SimpanUser(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim ret As Boolean = False
        Try
            With cmd
                .Connection = Conn
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spMstUserSave"
                .Transaction = MyConTrans
                .Parameters.Add("@UserID", SqlDbType.BigInt).Value = Val(txtUserID.Text)
                .Parameters.Add("@RegNo", SqlDbType.BigInt).Value = Val(txtRegNo.Text)
                .Parameters.Add("@FixNo", SqlDbType.BigInt).Value = DBNull.Value
                .Parameters.Add("@Nama", SqlDbType.VarChar, 50000).Value = UCase(Trim(txtNama.Text))
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = UserLogin
                .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
                .ExecuteNonQuery()
                If CInt(cmd.Parameters("@Flag").Value) <> 0 Then
                    cmd.Dispose()
                    Exit Function
                End If
                ret = True
            End With
        Catch ex As Exception
            fg.RemoveItem(fg.Rows.Count - 2)
            lbrInfoRekam.Visible = False
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
        cmd.Dispose()
        Return ret
    End Function

    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 1
        sql = "select a.StatusTk,a.RegNo,b.UserID,a.NIK,a.NAMA,a.JabatanName,a.Departemen,COUNT(c.FingerID) as FP from vwMstUser a join tblMstUser b on a.UserID=b.UserID " &
                " join tblMstFinger c on b.UserID=c.UserID  "
        If Trim(txtNikNama.Text) <> "" Then
            sql = sql & " where a.NIK='" & Trim(txtNikNama.Text) & "' or a.NAMA like '%" & Trim(txtNikNama.Text) & "%' "
        End If
        sql = sql & " Group by a.StatusTk,a.RegNo,b.UserID,a.NIK,a.NAMA,a.JabatanName,a.Departemen,A.ShortName Order By a.NAMA"
        fg2.Rows.Count = 1
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg2
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "RegNo") = DR!RegNo
                            .Item(i, "UserID") = DR!UserID
                            .Item(i, "NIK") = DR!NIK
                            .Item(i, "NAMA") = DR!NAMA
                            .Item(i, "Jabatan") = DR!JabatanName
                            .Item(i, "Departemen") = DR!Departemen
                            .Item(i, "FP") = DR!FP
                            .Item(i, "Status") = DR!StatusTk
                            i = i + 1
                        End While
                    End With
                Else
                    fg2.Rows.Count = 1
                End If
            End Using
        End Using
    End Sub
    Private Sub GetDataTamu()
        Dim sql As String = ""
        Dim i As Integer
        sql = "select a.StatusTk,a.RegNo,b.UserID,a.NIK,a.NAMA,a.JabatanName,a.Departemen,COUNT(c.FingerID) as FP from vwMstUserTamu a join tblMstUser b on a.UserID=b.UserID " &
                " join tblMstFinger c on b.UserID=c.UserID  "
        If Trim(txtNikNama.Text) <> "" Then
            sql = sql & " where a.NIK='" & Trim(txtNikNama.Text) & "' or a.NAMA like '%" & Trim(txtNikNama.Text) & "%' "
        End If
        sql = sql & " Group by a.StatusTk,a.RegNo,b.UserID,a.NIK,a.NAMA,a.JabatanName,a.Departemen Order By a.NAMA  "
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg2
                        While DR.Read
                            .AddItem("")
                            i = .Rows.Count - 1
                            .Item(i, "No") = i
                            .Item(i, "RegNo") = DR!RegNo
                            .Item(i, "UserID") = DR!UserID
                            .Item(i, "NIK") = DR!NIK
                            .Item(i, "NAMA") = DR!NAMA
                            .Item(i, "Jabatan") = DR!JabatanName
                            .Item(i, "Departemen") = DR!Departemen
                            .Item(i, "FP") = DR!FP
                            .Item(i, "Status") = DR!StatusTk
                            i = i + 1
                        End While
                    End With
                End If
            End Using
        End Using
    End Sub
    Private Sub GetDataTemplate(ByVal userID As Long)
        Dim sql As String = ""
        Dim i As Integer = 1
        Dim Finger As String = ""
        If Microsoft.VisualBasic.Left(userID, 1) = 3 Or Microsoft.VisualBasic.Left(userID, 1) = 4 Then
            sql = "SELECT B.REGNO,A.HdrID,FingerID,a.FingerDataStr,a.FingerDataStrLength,a.iFlag,a.UserID,c.NIK,c.NAMA,c.JabatanName,c.Departemen " &
               " FROM tblMstFinger A JOIN tblMstUser B ON A.UserID=B.UserID JOIN vwMstKaryawan C ON B.REGNO=C.REGNO and c.StatusTK=case WHEN LEFT(a.UserID,1)=3 THEN 'KARYAWAN' ELSE 'HARIAN' END where a.UserID='" & userID & "' "
        Else
            sql = "SELECT B.REGNO,A.HdrID,FingerID,a.FingerDataStr,a.FingerDataStrLength,a.iFlag,a.UserID,c.NIK,c.NAMA,c.Jabatan as JabatanName,c.Departemen " &
                " FROM tblMstFinger A JOIN tblMstUser B ON A.UserID=B.UserID JOIN vwMstTamu C ON B.REGNO=C.ID where a.UserID='" & userID & "' "
        End If

        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg.Rows.Count = 1
            fg.Rows.Count = 2
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg
                        While DR.Read
                            txtUserID.Text = DR!UserID
                            txtRegNo.Text = DR!REGNO
                            txtNik.Text = DR!NIK
                            txtNama.Text = DR!NAMA
                            If IsDBNull(DR!JabatanName) = False Then txtJabatan.Text = DR!JabatanName
                            If IsDBNull(DR!Departemen) = False Then txtDepartemen.Text = DR!Departemen
                            .AddItem("")
                            .Item(i, "No") = i
                            Select Case DR!FingerID
                                Case 1
                                    Finger = "Kiri Telujuk"
                                Case 2
                                    Finger = "Kiri Tengah"
                                Case 3
                                    Finger = "Kiri Manis"
                                Case 4
                                    Finger = "Kiri Kelingking"
                                Case 5
                                    Finger = "Kanan Jempol"
                                Case 6
                                    Finger = "Kanan Telujuk"
                                Case 7
                                    Finger = "Kanan Tengah"
                                Case 8
                                    Finger = "Kanan Manis"
                                Case 9
                                    Finger = "Kanan Kelingking"
                                Case 0
                                    Finger = "Jempol"
                            End Select
                            .Item(i, "Finger") = Finger
                            .Item(i, "Result") = "VALID"
                            .Item(i, "IDFinger") = DR!FingerID
                            .Item(i, "Template") = DR!FingerDataStr
                            .Item(i, "tmpDataStrLength") = DR!FingerDataStrLength
                            .Item(i, "iFlag") = DR!iFlag
                            .Item(i, "HdrID") = DR!HdrID
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

    Private Sub rdKiri_CheckedChanged(sender As Object, e As EventArgs) Handles rdKiri.CheckedChanged
        cboJari.ResetText()
    End Sub

    Private Sub rdKanan_CheckedChanged(sender As Object, e As EventArgs) Handles rdKanan.CheckedChanged
        cboJari.ResetText()
    End Sub



    Private Sub fg2_DoubleClick(sender As Object, e As EventArgs) Handles fg2.DoubleClick
        If Convert.ToDouble(fg2.Item(fg2.Row, "UserID")) > 0 And Convert.ToDouble(fg2.Item(fg2.Row, "FP")) > 0 Then
            Call GetDataTemplate(fg2.Item(fg2.Row, "UserID"))
        End If
    End Sub
    Private Sub Hapus()
        Dim Sql As String = ""
        Try
            Sql = "INSERT INTO tblMstUserHistoryDelete " &
                          " (UserID, RegNo, FixNo, Nama, GroupAbsenID, TipeShift, Passwd, Privilege, Enabled " &
                          " ,PathPhoto,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,Computer,ComputerDate) " &
                        " Select UserID,RegNo,FixNo,Nama,GroupAbsenID,TipeShift,Passwd,Privilege,Enabled  " &
                        ",PathPhoto,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,Computer,ComputerDate FROM tblMstUser WHERE UserID='" & txtUserID.Text & "' " &
                        "INSERT INTO tblMstFingerHistoryDelete " &
                         "  (UserID,FingerID,FingerDataStr,FingerDataStrLength,iFlag,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,Computer,ComputerDate)  " &
                        "Select UserID,FingerID,FingerDataStr,FingerDataStrLength,iFlag,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,Computer,ComputerDate FROM tblMstFinger WHERE UserID='" & txtUserID.Text & "' "
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn
                .CommandType = CommandType.Text
                .CommandText = Sql
                .ExecuteNonQuery()
                .CommandText = "Delete tblMstFinger WHERE UserID='" & txtUserID.Text & "' "
                .ExecuteNonQuery()
                .CommandText = "Delete tblMstUser WHERE UserID='" & txtUserID.Text & "' "
                .ExecuteNonQuery()
            End With
            MsgBox("Template Berhasil Hapus", vbInformation, "Success")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class