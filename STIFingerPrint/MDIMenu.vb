Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports WeifenLuo.WinFormsUI.Docking

Public Class MDIMenu : Inherits DockContent
    Public VersiSekrang As String
    Private Sub GetMenues(ByVal Current As ToolStripItem, ByRef menues As List(Of ToolStripItem))
        menues.Add(Current)
        If TypeOf (Current) Is ToolStripMenuItem Then
            For Each menu As ToolStripItem In DirectCast(Current, ToolStripMenuItem).DropDownItems
                GetMenues(menu, menues)
            Next
        End If
    End Sub
    Private Sub VisibleMenu()
        Dim menues As New List(Of ToolStripItem)
        Try
            For Each t As ToolStripItem In Me.MenuStrip.Items
                GetMenues(t, menues)
            Next
            For Each t As ToolStripItem In menues
                Select Case t.Text
                    Case "Master", "Transaction", "Monitoring", "Utility", "Windows", "Exit", "Log Out"
                    Case Else
                        t.Visible = False
                End Select
            Next
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private m_ChildFormNumber As Integer

    Private Sub MDIMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VersiSekrang = My.Application.Info.Version.ToString

        Me.client = Me.Controls.OfType(Of MdiClient).First()
        Call VisibleMenu()
    End Sub
    Private Sub MDIMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        VersiApp = My.Application.Info.Version.ToString
        If Me.Visible = False Then
            Me.Visible = True
            FrmLogin.ShowDialog()
        End If
    End Sub

    Private Sub SimpanVersiNet()
        Dim cmd As New SqlCommand
        Dim kon As SqlConnection = ModuleKoneksi.OpenKoneksi
        Try
            With cmd
                cmd.CommandTimeout = 0
                .Connection = kon
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSaveVersiApp"
                .Parameters.Add("@Versi", SqlDbType.VarChar, 20).Value = Trim(VersiSekrang)
                .Parameters.Add("@UserLogin", SqlDbType.VarChar, 50).Value = UserLogin
                .ExecuteNonQuery()
            End With
            cmd = Nothing
            MsgBox("Versi Terupdate!", MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenForm(frmMstRegistrasiFinger, True)
    End Sub

    Private WithEvents client As MdiClient

    Private Sub client_Paint(ByVal sender As Object,
                             ByVal e As PaintEventArgs) Handles client.Paint
        Using Brush As New Drawing2D.LinearGradientBrush(Me.client.Bounds,
                                                         Color.FromArgb(0, 200, 200),
                                                         Color.FromArgb(0, 200, 255),
                                                         Drawing2D.LinearGradientMode.ForwardDiagonal)
            e.Graphics.FillRectangle(Brush, Me.client.Bounds)
        End Using

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        OpenForm(frmUtlUserLogin, True)
    End Sub

    Private Sub GroupManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GroupManagementToolStripMenuItem.Click
        OpenForm(FrmutlGroupManagement, True)
    End Sub

    Private Sub MstDeviceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MstDeviceToolStripMenuItem.Click
        OpenForm(FrmMstDevice, True)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadFPFromDeviceToolStripMenuItem.Click
        OpenForm(FrmMstUploadFPtoDevice, True)
    End Sub

    Private Sub WorkTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkTimeToolStripMenuItem.Click
        OpenForm(FrmMstWorkTime, True)
    End Sub

    Private Sub SetWorkTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetWorkTimeToolStripMenuItem.Click
        OpenForm(FrmTrnSetWorkTime, True)
    End Sub

    Private Sub AbsensiPerHariToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbsensiPerHariToolStripMenuItem.Click
        OpenForm(FrmTrnAbsensiPerhari, True)
    End Sub

    Private Sub SetShiftTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetShiftTimeToolStripMenuItem.Click
        OpenForm(FrmSetShiftTime, True)
    End Sub

    Private Sub UpdateShiftUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateShiftUserToolStripMenuItem.Click
        OpenForm(FrmTrnUpdateShiftUser, True)
    End Sub

    Private Sub RekapAbsensiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RekapAbsensiToolStripMenuItem1.Click
        OpenForm(frmMonRekapAbsensiPerBulan, True)
    End Sub

    Private Sub RekapAbsensiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RekapAbsensiToolStripMenuItem.Click
        OpenForm(FrmTrnCetakAbsensi, True)
    End Sub

    Private Sub AkumulasiKeterlambatanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AkumulasiKeterlambatanToolStripMenuItem.Click
        OpenForm(FrmMonAkumulasiKeterlambatan, True)
    End Sub

    Private Sub KembalikanAbsensiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KembalikanAbsensiToolStripMenuItem.Click
        OpenForm(FrmTrnKambalikanAbsensi, True)
    End Sub

    Private Sub RestorRecordAbsensiSudahDihapusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestorRecordAbsensiSudahDihapusToolStripMenuItem.Click
        OpenForm(FrmTrnRestorRecodFinger, True)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dispose()
        Application.Exit()
    End Sub

    Private Sub ApprovalAbsensiByDepartemenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApprovalAbsensiByDepartemenToolStripMenuItem.Click
        OpenForm(FrmTrnApproveAbsensiByDept, True)
    End Sub

    Private Sub ApprovalAbsensiByPersonaliaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApprovalAbsensiByPersonaliaToolStripMenuItem.Click
        OpenForm(FrmTrnApproveAbsensiByPSN, True)
    End Sub

    Private Sub RemoveUserFingerFormDeviceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveUserFingerFormDeviceToolStripMenuItem.Click
        OpenForm(FrmMstRemoveUserFormDevice, True)
    End Sub

    Private Sub TamuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TamuToolStripMenuItem.Click
        OpenForm(FrmMstTamu, True)
    End Sub

    Private Sub RecordFingerTamuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecordFingerTamuToolStripMenuItem.Click
        OpenForm(FrmMonFingerTamu, True)
    End Sub

    Private Sub UpdateVersiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateVersiToolStripMenuItem.Click
        Call SimpanVersiNet()
    End Sub

    Private Sub RecordFingerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecordFingerToolStripMenuItem.Click
        OpenForm(FrmMonLogFinger, True)
    End Sub

    Private Sub TenagaKerjaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TenagaKerjaToolStripMenuItem.Click
        OpenForm(FrmMstTenagaKerja, True)
    End Sub

    Private Sub DepartemenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartemenToolStripMenuItem.Click
        OpenForm(FrmMstDepartemen, True)
    End Sub

    Private Sub JabatanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JabatanToolStripMenuItem.Click
        OpenForm(FrmMstJabatan, True)
    End Sub

    Private Sub InputCutiIzinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputCutiIzinToolStripMenuItem.Click
        OpenForm(FrmTrnCutiIzinInput, True)
    End Sub

    Private Sub ApproveByDepartemenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApproveByDepartemenToolStripMenuItem.Click
        OpenForm(FrmTrnCutiIzinApproveByDept, True)
    End Sub

    Private Sub ApproveByPSNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApproveByPSNToolStripMenuItem.Click
        OpenForm(FrmTrnCutiIzinApproveByPSN, True)
    End Sub

    Private Sub CutiIzinToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CutiIzinToolStripMenuItem1.Click
        OpenForm(FrmMonCutiIzin, True)
    End Sub

    Private Sub CetakAkumulasiKeterlambatanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CetakAkumulasiKeterlambatanToolStripMenuItem.Click
        OpenForm(FrmCetakAkumulasiKeterlambatan, True)
    End Sub

    Private Sub AttendanceManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AttendanceManualToolStripMenuItem.Click
        OpenForm(FrmAttendanceManual, True)
    End Sub
End Class
