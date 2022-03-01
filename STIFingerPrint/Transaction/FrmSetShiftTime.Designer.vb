<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetShiftTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSetShiftTime))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTipeShift = New System.Windows.Forms.TextBox()
        Me.txtShiftID = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.cboJabatanFilter = New System.Windows.Forms.ComboBox()
        Me.cboDepartemenFilter = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboJabatan = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboDepartemen = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtIstJumatShift3 = New System.Windows.Forms.TextBox()
        Me.txtIstNormalMenitShift3 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtJamPulangShift3 = New System.Windows.Forms.MaskedTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtJamIstInShift3 = New System.Windows.Forms.MaskedTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtJamIstOutShift3 = New System.Windows.Forms.MaskedTextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtJamMasukShit3 = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIstJumatShift2 = New System.Windows.Forms.TextBox()
        Me.txtIstNormalMenitShift2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtJamPulangShift2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtJamIstInShift2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtJamIstOutShift2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtJamMasukShit2 = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIstJumatShift1 = New System.Windows.Forms.TextBox()
        Me.txtIstNormalMenitShift1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtJamPulangShift1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtJamIstInShift1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtJamIstOutShift1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtJamMasukShit1 = New System.Windows.Forms.MaskedTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.PowderBlue
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 264.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1194, 791)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PowderBlue
        Me.Panel1.Controls.Add(Me.txtTipeShift)
        Me.Panel1.Controls.Add(Me.txtShiftID)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.cboJabatan)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.cboDepartemen)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1188, 258)
        Me.Panel1.TabIndex = 1
        '
        'txtTipeShift
        '
        Me.txtTipeShift.Location = New System.Drawing.Point(335, 36)
        Me.txtTipeShift.Name = "txtTipeShift"
        Me.txtTipeShift.Size = New System.Drawing.Size(46, 20)
        Me.txtTipeShift.TabIndex = 229
        Me.txtTipeShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTipeShift.Visible = False
        '
        'txtShiftID
        '
        Me.txtShiftID.Location = New System.Drawing.Point(283, 37)
        Me.txtShiftID.Name = "txtShiftID"
        Me.txtShiftID.Size = New System.Drawing.Size(46, 20)
        Me.txtShiftID.TabIndex = 228
        Me.txtShiftID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtShiftID.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.MintCream
        Me.GroupBox4.Controls.Add(Me.btnRefresh)
        Me.GroupBox4.Controls.Add(Me.cboJabatanFilter)
        Me.GroupBox4.Controls.Add(Me.cboDepartemenFilter)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Location = New System.Drawing.Point(591, 106)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(302, 143)
        Me.GroupBox4.TabIndex = 227
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filter"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.MintCream
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRefresh.Location = New System.Drawing.Point(87, 78)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(195, 48)
        Me.btnRefresh.TabIndex = 225
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'cboJabatanFilter
        '
        Me.cboJabatanFilter.FormattingEnabled = True
        Me.cboJabatanFilter.Location = New System.Drawing.Point(87, 50)
        Me.cboJabatanFilter.Name = "cboJabatanFilter"
        Me.cboJabatanFilter.Size = New System.Drawing.Size(195, 21)
        Me.cboJabatanFilter.TabIndex = 24
        '
        'cboDepartemenFilter
        '
        Me.cboDepartemenFilter.FormattingEnabled = True
        Me.cboDepartemenFilter.Location = New System.Drawing.Point(87, 23)
        Me.cboDepartemenFilter.Name = "cboDepartemenFilter"
        Me.cboDepartemenFilter.Size = New System.Drawing.Size(195, 21)
        Me.cboDepartemenFilter.TabIndex = 23
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(16, 52)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(45, 13)
        Me.Label25.TabIndex = 10
        Me.Label25.Text = "Jabatan"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(16, 26)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(65, 13)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "Departemen"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(15, 39)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 13)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Jabatan"
        '
        'cboJabatan
        '
        Me.cboJabatan.FormattingEnabled = True
        Me.cboJabatan.Location = New System.Drawing.Point(86, 36)
        Me.cboJabatan.Name = "cboJabatan"
        Me.cboJabatan.Size = New System.Drawing.Size(181, 21)
        Me.cboJabatan.TabIndex = 22
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(15, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 13)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "Departemen"
        '
        'cboDepartemen
        '
        Me.cboDepartemen.FormattingEnabled = True
        Me.cboDepartemen.Location = New System.Drawing.Point(86, 9)
        Me.cboDepartemen.Name = "cboDepartemen"
        Me.cboDepartemen.Size = New System.Drawing.Size(181, 21)
        Me.cboDepartemen.TabIndex = 20
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.MintCream
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtIstJumatShift3)
        Me.GroupBox3.Controls.Add(Me.txtIstNormalMenitShift3)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.txtJamPulangShift3)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.txtJamIstInShift3)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtJamIstOutShift3)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.txtJamMasukShit3)
        Me.GroupBox3.Location = New System.Drawing.Point(407, 64)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(178, 185)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "SHIFT 3"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 156)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Ist Jumat (Menit)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 130)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Ist Normal (Menit)"
        '
        'txtIstJumatShift3
        '
        Me.txtIstJumatShift3.Location = New System.Drawing.Point(108, 153)
        Me.txtIstJumatShift3.Name = "txtIstJumatShift3"
        Me.txtIstJumatShift3.Size = New System.Drawing.Size(46, 20)
        Me.txtIstJumatShift3.TabIndex = 16
        Me.txtIstJumatShift3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIstNormalMenitShift3
        '
        Me.txtIstNormalMenitShift3.Location = New System.Drawing.Point(108, 127)
        Me.txtIstNormalMenitShift3.Name = "txtIstNormalMenitShift3"
        Me.txtIstNormalMenitShift3.Size = New System.Drawing.Size(46, 20)
        Me.txtIstNormalMenitShift3.TabIndex = 15
        Me.txtIstNormalMenitShift3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Jam Pulang"
        '
        'txtJamPulangShift3
        '
        Me.txtJamPulangShift3.Location = New System.Drawing.Point(108, 101)
        Me.txtJamPulangShift3.Mask = "90:00"
        Me.txtJamPulangShift3.Name = "txtJamPulangShift3"
        Me.txtJamPulangShift3.Size = New System.Drawing.Size(46, 20)
        Me.txtJamPulangShift3.TabIndex = 13
        Me.txtJamPulangShift3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamPulangShift3.ValidatingType = GetType(Date)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 78)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Jam Ist In"
        '
        'txtJamIstInShift3
        '
        Me.txtJamIstInShift3.Location = New System.Drawing.Point(108, 75)
        Me.txtJamIstInShift3.Mask = "90:00"
        Me.txtJamIstInShift3.Name = "txtJamIstInShift3"
        Me.txtJamIstInShift3.Size = New System.Drawing.Size(46, 20)
        Me.txtJamIstInShift3.TabIndex = 11
        Me.txtJamIstInShift3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamIstInShift3.ValidatingType = GetType(Date)
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(16, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Jam Ist Out"
        '
        'txtJamIstOutShift3
        '
        Me.txtJamIstOutShift3.Location = New System.Drawing.Point(108, 49)
        Me.txtJamIstOutShift3.Mask = "90:00"
        Me.txtJamIstOutShift3.Name = "txtJamIstOutShift3"
        Me.txtJamIstOutShift3.Size = New System.Drawing.Size(46, 20)
        Me.txtJamIstOutShift3.TabIndex = 9
        Me.txtJamIstOutShift3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamIstOutShift3.ValidatingType = GetType(Date)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 26)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 13)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Jam Masuk"
        '
        'txtJamMasukShit3
        '
        Me.txtJamMasukShit3.Location = New System.Drawing.Point(108, 23)
        Me.txtJamMasukShit3.Mask = "90:00"
        Me.txtJamMasukShit3.Name = "txtJamMasukShit3"
        Me.txtJamMasukShit3.Size = New System.Drawing.Size(46, 20)
        Me.txtJamMasukShit3.TabIndex = 7
        Me.txtJamMasukShit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamMasukShit3.ValidatingType = GetType(Date)
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.MintCream
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtIstJumatShift2)
        Me.GroupBox2.Controls.Add(Me.txtIstNormalMenitShift2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtJamPulangShift2)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtJamIstInShift2)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtJamIstOutShift2)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtJamMasukShit2)
        Me.GroupBox2.Location = New System.Drawing.Point(212, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(178, 185)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SHIFT 2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Ist Jumat (Menit)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Ist Normal (Menit)"
        '
        'txtIstJumatShift2
        '
        Me.txtIstJumatShift2.Location = New System.Drawing.Point(108, 153)
        Me.txtIstJumatShift2.Name = "txtIstJumatShift2"
        Me.txtIstJumatShift2.Size = New System.Drawing.Size(46, 20)
        Me.txtIstJumatShift2.TabIndex = 16
        Me.txtIstJumatShift2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIstNormalMenitShift2
        '
        Me.txtIstNormalMenitShift2.Location = New System.Drawing.Point(108, 127)
        Me.txtIstNormalMenitShift2.Name = "txtIstNormalMenitShift2"
        Me.txtIstNormalMenitShift2.Size = New System.Drawing.Size(46, 20)
        Me.txtIstNormalMenitShift2.TabIndex = 15
        Me.txtIstNormalMenitShift2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Jam Pulang"
        '
        'txtJamPulangShift2
        '
        Me.txtJamPulangShift2.Location = New System.Drawing.Point(108, 101)
        Me.txtJamPulangShift2.Mask = "90:00"
        Me.txtJamPulangShift2.Name = "txtJamPulangShift2"
        Me.txtJamPulangShift2.Size = New System.Drawing.Size(46, 20)
        Me.txtJamPulangShift2.TabIndex = 13
        Me.txtJamPulangShift2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamPulangShift2.ValidatingType = GetType(Date)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Jam Ist In"
        '
        'txtJamIstInShift2
        '
        Me.txtJamIstInShift2.Location = New System.Drawing.Point(108, 75)
        Me.txtJamIstInShift2.Mask = "90:00"
        Me.txtJamIstInShift2.Name = "txtJamIstInShift2"
        Me.txtJamIstInShift2.Size = New System.Drawing.Size(46, 20)
        Me.txtJamIstInShift2.TabIndex = 11
        Me.txtJamIstInShift2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamIstInShift2.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Jam Ist Out"
        '
        'txtJamIstOutShift2
        '
        Me.txtJamIstOutShift2.Location = New System.Drawing.Point(108, 49)
        Me.txtJamIstOutShift2.Mask = "90:00"
        Me.txtJamIstOutShift2.Name = "txtJamIstOutShift2"
        Me.txtJamIstOutShift2.Size = New System.Drawing.Size(46, 20)
        Me.txtJamIstOutShift2.TabIndex = 9
        Me.txtJamIstOutShift2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamIstOutShift2.ValidatingType = GetType(Date)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Jam Masuk"
        '
        'txtJamMasukShit2
        '
        Me.txtJamMasukShit2.Location = New System.Drawing.Point(108, 23)
        Me.txtJamMasukShit2.Mask = "90:00"
        Me.txtJamMasukShit2.Name = "txtJamMasukShit2"
        Me.txtJamMasukShit2.Size = New System.Drawing.Size(46, 20)
        Me.txtJamMasukShit2.TabIndex = 7
        Me.txtJamMasukShit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamMasukShit2.ValidatingType = GetType(Date)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.MintCream
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtIstJumatShift1)
        Me.GroupBox1.Controls.Add(Me.txtIstNormalMenitShift1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtJamPulangShift1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtJamIstInShift1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtJamIstOutShift1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtJamMasukShit1)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(178, 185)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SHIFT 1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Ist Jumat (Menit)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Ist Normal (Menit)"
        '
        'txtIstJumatShift1
        '
        Me.txtIstJumatShift1.Location = New System.Drawing.Point(108, 153)
        Me.txtIstJumatShift1.Name = "txtIstJumatShift1"
        Me.txtIstJumatShift1.Size = New System.Drawing.Size(46, 20)
        Me.txtIstJumatShift1.TabIndex = 16
        Me.txtIstJumatShift1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIstNormalMenitShift1
        '
        Me.txtIstNormalMenitShift1.Location = New System.Drawing.Point(108, 127)
        Me.txtIstNormalMenitShift1.Name = "txtIstNormalMenitShift1"
        Me.txtIstNormalMenitShift1.Size = New System.Drawing.Size(46, 20)
        Me.txtIstNormalMenitShift1.TabIndex = 15
        Me.txtIstNormalMenitShift1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Jam Pulang"
        '
        'txtJamPulangShift1
        '
        Me.txtJamPulangShift1.Location = New System.Drawing.Point(108, 101)
        Me.txtJamPulangShift1.Mask = "90:00"
        Me.txtJamPulangShift1.Name = "txtJamPulangShift1"
        Me.txtJamPulangShift1.Size = New System.Drawing.Size(46, 20)
        Me.txtJamPulangShift1.TabIndex = 13
        Me.txtJamPulangShift1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamPulangShift1.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Jam Ist In"
        '
        'txtJamIstInShift1
        '
        Me.txtJamIstInShift1.Location = New System.Drawing.Point(108, 75)
        Me.txtJamIstInShift1.Mask = "90:00"
        Me.txtJamIstInShift1.Name = "txtJamIstInShift1"
        Me.txtJamIstInShift1.Size = New System.Drawing.Size(46, 20)
        Me.txtJamIstInShift1.TabIndex = 11
        Me.txtJamIstInShift1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamIstInShift1.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Jam Ist Out"
        '
        'txtJamIstOutShift1
        '
        Me.txtJamIstOutShift1.Location = New System.Drawing.Point(108, 49)
        Me.txtJamIstOutShift1.Mask = "90:00"
        Me.txtJamIstOutShift1.Name = "txtJamIstOutShift1"
        Me.txtJamIstOutShift1.Size = New System.Drawing.Size(46, 20)
        Me.txtJamIstOutShift1.TabIndex = 9
        Me.txtJamIstOutShift1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamIstOutShift1.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Jam Masuk"
        '
        'txtJamMasukShit1
        '
        Me.txtJamMasukShit1.Location = New System.Drawing.Point(108, 23)
        Me.txtJamMasukShit1.Mask = "90:00"
        Me.txtJamMasukShit1.Name = "txtJamMasukShit1"
        Me.txtJamMasukShit1.Size = New System.Drawing.Size(46, 20)
        Me.txtJamMasukShit1.TabIndex = 7
        Me.txtJamMasukShit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamMasukShit1.ValidatingType = GetType(Date)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnEdit)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 734)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1188, 54)
        Me.Panel2.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.MintCream
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.Location = New System.Drawing.Point(626, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 48)
        Me.btnCancel.TabIndex = 239
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.MintCream
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClose.Location = New System.Drawing.Point(707, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 48)
        Me.btnClose.TabIndex = 237
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.MintCream
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.Location = New System.Drawing.Point(545, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 48)
        Me.btnSave.TabIndex = 236
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.MintCream
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.Location = New System.Drawing.Point(464, 2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 48)
        Me.btnEdit.TabIndex = 235
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.MintCream
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.Location = New System.Drawing.Point(383, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 48)
        Me.btnAdd.TabIndex = 234
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.fg)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 267)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1188, 461)
        Me.Panel3.TabIndex = 3
        '
        'fg
        '
        Me.fg.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(0, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.DefaultSize = 19
        Me.fg.Size = New System.Drawing.Size(1188, 461)
        Me.fg.TabIndex = 227
        '
        'FrmSetShiftTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1201, 806)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmSetShiftTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Shift Time"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents cboJabatanFilter As ComboBox
    Friend WithEvents cboDepartemenFilter As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cboJabatan As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cboDepartemen As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtIstJumatShift3 As TextBox
    Friend WithEvents txtIstNormalMenitShift3 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtJamPulangShift3 As MaskedTextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtJamIstInShift3 As MaskedTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtJamIstOutShift3 As MaskedTextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtJamMasukShit3 As MaskedTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtIstJumatShift2 As TextBox
    Friend WithEvents txtIstNormalMenitShift2 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtJamPulangShift2 As MaskedTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtJamIstInShift2 As MaskedTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtJamIstOutShift2 As MaskedTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtJamMasukShit2 As MaskedTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtIstJumatShift1 As TextBox
    Friend WithEvents txtIstNormalMenitShift1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtJamPulangShift1 As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtJamIstInShift1 As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtJamIstOutShift1 As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtJamMasukShit1 As MaskedTextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtShiftID As TextBox
    Friend WithEvents txtTipeShift As TextBox
End Class
