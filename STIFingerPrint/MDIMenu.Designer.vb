<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIMenu
    'Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIMenu))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MstDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFPFromDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveUserFingerFormDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TamuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TenagaKerjaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepartemenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JabatanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetWorkTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetShiftTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateShiftUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbsensiPerHariToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RekapAbsensiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KembalikanAbsensiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestorRecordAbsensiSudahDihapusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApprovalAbsensiByDepartemenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApprovalAbsensiByPersonaliaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutiIzinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InputCutiIzinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApproveByDepartemenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApproveByPSNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.RekapAbsensiToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AkumulasiKeterlambatanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecordFingerTamuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecordFingerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutiIzinToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CetakAkumulasiKeterlambatanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateVersiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttendanceManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.DockPanel1 = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.White
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.EditMenu, Me.ViewMenu, Me.ToolsMenu, Me.WindowsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MstDeviceToolStripMenuItem, Me.OpenToolStripMenuItem, Me.UploadFPFromDeviceToolStripMenuItem, Me.WorkTimeToolStripMenuItem, Me.RemoveUserFingerFormDeviceToolStripMenuItem, Me.TamuToolStripMenuItem, Me.TenagaKerjaToolStripMenuItem, Me.DepartemenToolStripMenuItem, Me.JabatanToolStripMenuItem})
        Me.FileMenu.Image = CType(resources.GetObject("FileMenu.Image"), System.Drawing.Image)
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(71, 20)
        Me.FileMenu.Tag = "1000"
        Me.FileMenu.Text = "Master"
        '
        'MstDeviceToolStripMenuItem
        '
        Me.MstDeviceToolStripMenuItem.Image = CType(resources.GetObject("MstDeviceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MstDeviceToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.MstDeviceToolStripMenuItem.Name = "MstDeviceToolStripMenuItem"
        Me.MstDeviceToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.MstDeviceToolStripMenuItem.Tag = "1001"
        Me.MstDeviceToolStripMenuItem.Text = "Master Device"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.OpenToolStripMenuItem.Tag = "1002"
        Me.OpenToolStripMenuItem.Text = "Registrasi Finger"
        '
        'UploadFPFromDeviceToolStripMenuItem
        '
        Me.UploadFPFromDeviceToolStripMenuItem.Image = CType(resources.GetObject("UploadFPFromDeviceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UploadFPFromDeviceToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.UploadFPFromDeviceToolStripMenuItem.Name = "UploadFPFromDeviceToolStripMenuItem"
        Me.UploadFPFromDeviceToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.UploadFPFromDeviceToolStripMenuItem.Tag = "1003"
        Me.UploadFPFromDeviceToolStripMenuItem.Text = "Upload Finger To Device"
        '
        'WorkTimeToolStripMenuItem
        '
        Me.WorkTimeToolStripMenuItem.Image = CType(resources.GetObject("WorkTimeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WorkTimeToolStripMenuItem.Name = "WorkTimeToolStripMenuItem"
        Me.WorkTimeToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.WorkTimeToolStripMenuItem.Tag = "1004"
        Me.WorkTimeToolStripMenuItem.Text = "Work Time"
        '
        'RemoveUserFingerFormDeviceToolStripMenuItem
        '
        Me.RemoveUserFingerFormDeviceToolStripMenuItem.Image = CType(resources.GetObject("RemoveUserFingerFormDeviceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RemoveUserFingerFormDeviceToolStripMenuItem.Name = "RemoveUserFingerFormDeviceToolStripMenuItem"
        Me.RemoveUserFingerFormDeviceToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.RemoveUserFingerFormDeviceToolStripMenuItem.Tag = "1005"
        Me.RemoveUserFingerFormDeviceToolStripMenuItem.Text = "Remove User Finger From Device"
        '
        'TamuToolStripMenuItem
        '
        Me.TamuToolStripMenuItem.Image = CType(resources.GetObject("TamuToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TamuToolStripMenuItem.Name = "TamuToolStripMenuItem"
        Me.TamuToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.TamuToolStripMenuItem.Tag = "1006"
        Me.TamuToolStripMenuItem.Text = "Tamu"
        '
        'TenagaKerjaToolStripMenuItem
        '
        Me.TenagaKerjaToolStripMenuItem.Image = CType(resources.GetObject("TenagaKerjaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TenagaKerjaToolStripMenuItem.Name = "TenagaKerjaToolStripMenuItem"
        Me.TenagaKerjaToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.TenagaKerjaToolStripMenuItem.Tag = "1007"
        Me.TenagaKerjaToolStripMenuItem.Text = "Tenaga Kerja"
        '
        'DepartemenToolStripMenuItem
        '
        Me.DepartemenToolStripMenuItem.Image = CType(resources.GetObject("DepartemenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DepartemenToolStripMenuItem.Name = "DepartemenToolStripMenuItem"
        Me.DepartemenToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.DepartemenToolStripMenuItem.Tag = "1008"
        Me.DepartemenToolStripMenuItem.Text = "Departemen"
        '
        'JabatanToolStripMenuItem
        '
        Me.JabatanToolStripMenuItem.Image = CType(resources.GetObject("JabatanToolStripMenuItem.Image"), System.Drawing.Image)
        Me.JabatanToolStripMenuItem.Name = "JabatanToolStripMenuItem"
        Me.JabatanToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.JabatanToolStripMenuItem.Tag = "1009"
        Me.JabatanToolStripMenuItem.Text = "Jabatan"
        '
        'EditMenu
        '
        Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetWorkTimeToolStripMenuItem, Me.SetShiftTimeToolStripMenuItem, Me.UpdateShiftUserToolStripMenuItem, Me.AbsensiPerHariToolStripMenuItem, Me.RekapAbsensiToolStripMenuItem, Me.KembalikanAbsensiToolStripMenuItem, Me.RestorRecordAbsensiSudahDihapusToolStripMenuItem, Me.ApprovalAbsensiByDepartemenToolStripMenuItem, Me.ApprovalAbsensiByPersonaliaToolStripMenuItem, Me.ToolStripMenuItem1, Me.CutiIzinToolStripMenuItem})
        Me.EditMenu.Image = CType(resources.GetObject("EditMenu.Image"), System.Drawing.Image)
        Me.EditMenu.Name = "EditMenu"
        Me.EditMenu.Size = New System.Drawing.Size(95, 20)
        Me.EditMenu.Tag = "2000"
        Me.EditMenu.Text = "Transaction"
        '
        'SetWorkTimeToolStripMenuItem
        '
        Me.SetWorkTimeToolStripMenuItem.Checked = True
        Me.SetWorkTimeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SetWorkTimeToolStripMenuItem.Name = "SetWorkTimeToolStripMenuItem"
        Me.SetWorkTimeToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.SetWorkTimeToolStripMenuItem.Tag = "2001"
        Me.SetWorkTimeToolStripMenuItem.Text = "Set Work Time"
        '
        'SetShiftTimeToolStripMenuItem
        '
        Me.SetShiftTimeToolStripMenuItem.Checked = True
        Me.SetShiftTimeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SetShiftTimeToolStripMenuItem.Name = "SetShiftTimeToolStripMenuItem"
        Me.SetShiftTimeToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.SetShiftTimeToolStripMenuItem.Tag = "2002"
        Me.SetShiftTimeToolStripMenuItem.Text = "Set Shift Time"
        '
        'UpdateShiftUserToolStripMenuItem
        '
        Me.UpdateShiftUserToolStripMenuItem.Checked = True
        Me.UpdateShiftUserToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UpdateShiftUserToolStripMenuItem.Name = "UpdateShiftUserToolStripMenuItem"
        Me.UpdateShiftUserToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.UpdateShiftUserToolStripMenuItem.Tag = "2003"
        Me.UpdateShiftUserToolStripMenuItem.Text = "Update Shift User"
        '
        'AbsensiPerHariToolStripMenuItem
        '
        Me.AbsensiPerHariToolStripMenuItem.Checked = True
        Me.AbsensiPerHariToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AbsensiPerHariToolStripMenuItem.Name = "AbsensiPerHariToolStripMenuItem"
        Me.AbsensiPerHariToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.AbsensiPerHariToolStripMenuItem.Tag = "2004"
        Me.AbsensiPerHariToolStripMenuItem.Text = "Absensi Per Hari"
        '
        'RekapAbsensiToolStripMenuItem
        '
        Me.RekapAbsensiToolStripMenuItem.Checked = True
        Me.RekapAbsensiToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RekapAbsensiToolStripMenuItem.Name = "RekapAbsensiToolStripMenuItem"
        Me.RekapAbsensiToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.RekapAbsensiToolStripMenuItem.Tag = "2005"
        Me.RekapAbsensiToolStripMenuItem.Text = "Cetak Absensi"
        '
        'KembalikanAbsensiToolStripMenuItem
        '
        Me.KembalikanAbsensiToolStripMenuItem.Checked = True
        Me.KembalikanAbsensiToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.KembalikanAbsensiToolStripMenuItem.Name = "KembalikanAbsensiToolStripMenuItem"
        Me.KembalikanAbsensiToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.KembalikanAbsensiToolStripMenuItem.Tag = "2006"
        Me.KembalikanAbsensiToolStripMenuItem.Text = "Kembalikan Absensi"
        '
        'RestorRecordAbsensiSudahDihapusToolStripMenuItem
        '
        Me.RestorRecordAbsensiSudahDihapusToolStripMenuItem.Checked = True
        Me.RestorRecordAbsensiSudahDihapusToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RestorRecordAbsensiSudahDihapusToolStripMenuItem.Name = "RestorRecordAbsensiSudahDihapusToolStripMenuItem"
        Me.RestorRecordAbsensiSudahDihapusToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.RestorRecordAbsensiSudahDihapusToolStripMenuItem.Tag = "2007"
        Me.RestorRecordAbsensiSudahDihapusToolStripMenuItem.Text = "Restor Record Finger Sudah Dihapus"
        '
        'ApprovalAbsensiByDepartemenToolStripMenuItem
        '
        Me.ApprovalAbsensiByDepartemenToolStripMenuItem.Checked = True
        Me.ApprovalAbsensiByDepartemenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ApprovalAbsensiByDepartemenToolStripMenuItem.Name = "ApprovalAbsensiByDepartemenToolStripMenuItem"
        Me.ApprovalAbsensiByDepartemenToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ApprovalAbsensiByDepartemenToolStripMenuItem.Tag = "2008"
        Me.ApprovalAbsensiByDepartemenToolStripMenuItem.Text = "Approval Absensi By Departemen"
        '
        'ApprovalAbsensiByPersonaliaToolStripMenuItem
        '
        Me.ApprovalAbsensiByPersonaliaToolStripMenuItem.Checked = True
        Me.ApprovalAbsensiByPersonaliaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ApprovalAbsensiByPersonaliaToolStripMenuItem.Name = "ApprovalAbsensiByPersonaliaToolStripMenuItem"
        Me.ApprovalAbsensiByPersonaliaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ApprovalAbsensiByPersonaliaToolStripMenuItem.Tag = "2009"
        Me.ApprovalAbsensiByPersonaliaToolStripMenuItem.Text = "Approval Absensi By Personalia"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(262, 6)
        '
        'CutiIzinToolStripMenuItem
        '
        Me.CutiIzinToolStripMenuItem.Checked = True
        Me.CutiIzinToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CutiIzinToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InputCutiIzinToolStripMenuItem, Me.ApproveByDepartemenToolStripMenuItem, Me.ApproveByPSNToolStripMenuItem})
        Me.CutiIzinToolStripMenuItem.Name = "CutiIzinToolStripMenuItem"
        Me.CutiIzinToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.CutiIzinToolStripMenuItem.Tag = "2010"
        Me.CutiIzinToolStripMenuItem.Text = "Cuti - Izin"
        '
        'InputCutiIzinToolStripMenuItem
        '
        Me.InputCutiIzinToolStripMenuItem.Name = "InputCutiIzinToolStripMenuItem"
        Me.InputCutiIzinToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.InputCutiIzinToolStripMenuItem.Tag = "2011"
        Me.InputCutiIzinToolStripMenuItem.Text = "Input Cuti - Izin"
        '
        'ApproveByDepartemenToolStripMenuItem
        '
        Me.ApproveByDepartemenToolStripMenuItem.Name = "ApproveByDepartemenToolStripMenuItem"
        Me.ApproveByDepartemenToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ApproveByDepartemenToolStripMenuItem.Tag = "2012"
        Me.ApproveByDepartemenToolStripMenuItem.Text = "Approve By Departemen"
        '
        'ApproveByPSNToolStripMenuItem
        '
        Me.ApproveByPSNToolStripMenuItem.Name = "ApproveByPSNToolStripMenuItem"
        Me.ApproveByPSNToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ApproveByPSNToolStripMenuItem.Tag = "2013"
        Me.ApproveByPSNToolStripMenuItem.Text = "Approve By PSN"
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RekapAbsensiToolStripMenuItem1, Me.AkumulasiKeterlambatanToolStripMenuItem, Me.RecordFingerTamuToolStripMenuItem, Me.RecordFingerToolStripMenuItem, Me.CutiIzinToolStripMenuItem1, Me.CetakAkumulasiKeterlambatanToolStripMenuItem})
        Me.ViewMenu.Image = CType(resources.GetObject("ViewMenu.Image"), System.Drawing.Image)
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(95, 20)
        Me.ViewMenu.Tag = "3000"
        Me.ViewMenu.Text = "Monitoring"
        '
        'RekapAbsensiToolStripMenuItem1
        '
        Me.RekapAbsensiToolStripMenuItem1.Image = CType(resources.GetObject("RekapAbsensiToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.RekapAbsensiToolStripMenuItem1.Name = "RekapAbsensiToolStripMenuItem1"
        Me.RekapAbsensiToolStripMenuItem1.Size = New System.Drawing.Size(243, 22)
        Me.RekapAbsensiToolStripMenuItem1.Tag = "3001"
        Me.RekapAbsensiToolStripMenuItem1.Text = "Rekap Absensi"
        '
        'AkumulasiKeterlambatanToolStripMenuItem
        '
        Me.AkumulasiKeterlambatanToolStripMenuItem.Image = CType(resources.GetObject("AkumulasiKeterlambatanToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AkumulasiKeterlambatanToolStripMenuItem.Name = "AkumulasiKeterlambatanToolStripMenuItem"
        Me.AkumulasiKeterlambatanToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.AkumulasiKeterlambatanToolStripMenuItem.Tag = "3002"
        Me.AkumulasiKeterlambatanToolStripMenuItem.Text = "Akumulasi Keterlambatan"
        '
        'RecordFingerTamuToolStripMenuItem
        '
        Me.RecordFingerTamuToolStripMenuItem.Image = CType(resources.GetObject("RecordFingerTamuToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RecordFingerTamuToolStripMenuItem.Name = "RecordFingerTamuToolStripMenuItem"
        Me.RecordFingerTamuToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.RecordFingerTamuToolStripMenuItem.Tag = "3003"
        Me.RecordFingerTamuToolStripMenuItem.Text = "Record Finger Tamu"
        '
        'RecordFingerToolStripMenuItem
        '
        Me.RecordFingerToolStripMenuItem.Image = CType(resources.GetObject("RecordFingerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RecordFingerToolStripMenuItem.Name = "RecordFingerToolStripMenuItem"
        Me.RecordFingerToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.RecordFingerToolStripMenuItem.Tag = "3004"
        Me.RecordFingerToolStripMenuItem.Text = "Record Finger"
        '
        'CutiIzinToolStripMenuItem1
        '
        Me.CutiIzinToolStripMenuItem1.Image = CType(resources.GetObject("CutiIzinToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.CutiIzinToolStripMenuItem1.Name = "CutiIzinToolStripMenuItem1"
        Me.CutiIzinToolStripMenuItem1.Size = New System.Drawing.Size(243, 22)
        Me.CutiIzinToolStripMenuItem1.Tag = "3005"
        Me.CutiIzinToolStripMenuItem1.Text = "Cuti - Izin"
        '
        'CetakAkumulasiKeterlambatanToolStripMenuItem
        '
        Me.CetakAkumulasiKeterlambatanToolStripMenuItem.Image = CType(resources.GetObject("CetakAkumulasiKeterlambatanToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CetakAkumulasiKeterlambatanToolStripMenuItem.Name = "CetakAkumulasiKeterlambatanToolStripMenuItem"
        Me.CetakAkumulasiKeterlambatanToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.CetakAkumulasiKeterlambatanToolStripMenuItem.Tag = "3006"
        Me.CetakAkumulasiKeterlambatanToolStripMenuItem.Text = "Cetak Akumulasi Keterlambatan"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.GroupManagementToolStripMenuItem, Me.UpdateVersiToolStripMenuItem, Me.AttendanceManualToolStripMenuItem})
        Me.ToolsMenu.Image = CType(resources.GetObject("ToolsMenu.Image"), System.Drawing.Image)
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(66, 20)
        Me.ToolsMenu.Tag = "4000"
        Me.ToolsMenu.Text = "Utility"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Image = CType(resources.GetObject("OptionsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.OptionsToolStripMenuItem.Tag = "4001"
        Me.OptionsToolStripMenuItem.Text = "User Name"
        '
        'GroupManagementToolStripMenuItem
        '
        Me.GroupManagementToolStripMenuItem.Image = CType(resources.GetObject("GroupManagementToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GroupManagementToolStripMenuItem.Name = "GroupManagementToolStripMenuItem"
        Me.GroupManagementToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.GroupManagementToolStripMenuItem.Tag = "4002"
        Me.GroupManagementToolStripMenuItem.Text = "Group Management"
        '
        'UpdateVersiToolStripMenuItem
        '
        Me.UpdateVersiToolStripMenuItem.Image = CType(resources.GetObject("UpdateVersiToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UpdateVersiToolStripMenuItem.Name = "UpdateVersiToolStripMenuItem"
        Me.UpdateVersiToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.UpdateVersiToolStripMenuItem.Tag = "4003"
        Me.UpdateVersiToolStripMenuItem.Text = "Update Versi"
        '
        'AttendanceManualToolStripMenuItem
        '
        Me.AttendanceManualToolStripMenuItem.Image = CType(resources.GetObject("AttendanceManualToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AttendanceManualToolStripMenuItem.Name = "AttendanceManualToolStripMenuItem"
        Me.AttendanceManualToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.AttendanceManualToolStripMenuItem.Tag = "4004"
        Me.AttendanceManualToolStripMenuItem.Text = "Attendance Manual"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem})
        Me.WindowsMenu.Image = CType(resources.GetObject("WindowsMenu.Image"), System.Drawing.Image)
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(84, 20)
        Me.WindowsMenu.Tag = "5000"
        Me.WindowsMenu.Text = "Windows"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpMenu.Image = CType(resources.GetObject("HelpMenu.Image"), System.Drawing.Image)
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(54, 20)
        Me.HelpMenu.Tag = "6000"
        Me.HelpMenu.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.AboutToolStripMenuItem.Tag = ""
        Me.AboutToolStripMenuItem.Text = "Log Out"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(632, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'DockPanel1
        '
        Me.DockPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.DockPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockPanel1.DockBackColor = System.Drawing.Color.DarkSeaGreen
        Me.DockPanel1.Location = New System.Drawing.Point(0, 24)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Size = New System.Drawing.Size(632, 407)
        Me.DockPanel1.TabIndex = 9
        '
        'MDIMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.DockPanel1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MDIMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MDIMenu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MstDeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadFPFromDeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents EditMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents GroupManagementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetWorkTimeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkTimeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbsensiPerHariToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetShiftTimeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateShiftUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RekapAbsensiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RekapAbsensiToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AkumulasiKeterlambatanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KembalikanAbsensiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestorRecordAbsensiSudahDihapusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ApprovalAbsensiByDepartemenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ApprovalAbsensiByPersonaliaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveUserFingerFormDeviceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TamuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecordFingerTamuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateVersiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecordFingerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TenagaKerjaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DepartemenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JabatanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents CutiIzinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InputCutiIzinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ApproveByDepartemenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ApproveByPSNToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutiIzinToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CetakAkumulasiKeterlambatanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AttendanceManualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DockPanel1 As WeifenLuo.WinFormsUI.Docking.DockPanel
End Class
