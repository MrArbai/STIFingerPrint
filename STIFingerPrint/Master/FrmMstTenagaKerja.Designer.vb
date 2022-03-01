<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstTenagaKerja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstTenagaKerja))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkAktif = New System.Windows.Forms.CheckBox()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtJamKerjaPendek = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtJamKerjaPanjang = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboLiburMinggaun = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboStatusJamKerja = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboJenisKelamin = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNikNama = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtTanggalKeluar = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtTanggalMasuk = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboBagian = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDepartemen = New System.Windows.Forms.ComboBox()
        Me.cboJabatan = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtRegNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNik = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.PowderBlue
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.fg, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 258.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1127, 501)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fg.Location = New System.Drawing.Point(3, 261)
        Me.fg.Name = "fg"
        Me.fg.Rows.DefaultSize = 19
        Me.fg.Size = New System.Drawing.Size(1121, 179)
        Me.fg.TabIndex = 165
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkAktif)
        Me.Panel1.Controls.Add(Me.btnChoose)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtJamKerjaPendek)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtJamKerjaPanjang)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.cboLiburMinggaun)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.cboStatusJamKerja)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cboJenisKelamin)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtNikNama)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.dtTanggalKeluar)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dtTanggalMasuk)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cboBagian)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboDepartemen)
        Me.Panel1.Controls.Add(Me.cboJabatan)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtRegNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtNama)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtNik)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1121, 252)
        Me.Panel1.TabIndex = 0
        '
        'chkAktif
        '
        Me.chkAktif.AutoSize = True
        Me.chkAktif.Location = New System.Drawing.Point(453, 193)
        Me.chkAktif.Name = "chkAktif"
        Me.chkAktif.Size = New System.Drawing.Size(67, 17)
        Me.chkAktif.TabIndex = 235
        Me.chkAktif.Text = "Not Aktif"
        Me.chkAktif.UseVisualStyleBackColor = True
        '
        'btnChoose
        '
        Me.btnChoose.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnChoose.BackColor = System.Drawing.Color.MintCream
        Me.btnChoose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChoose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChoose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChoose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChoose.Image = CType(resources.GetObject("btnChoose.Image"), System.Drawing.Image)
        Me.btnChoose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChoose.Location = New System.Drawing.Point(684, 219)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(65, 28)
        Me.btnChoose.TabIndex = 234
        Me.btnChoose.Text = "Find"
        Me.btnChoose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnChoose.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(367, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(724, 72)
        Me.GroupBox1.TabIndex = 219
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Petunjuk!"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(297, 13)
        Me.Label19.TabIndex = 190
        Me.Label19.Text = "2. Jika Ingin Edit Maka RegNo Tidak Boleh Diganti"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(699, 13)
        Me.Label18.TabIndex = 189
        Me.Label18.Text = "1. Jika Ada Penambahan Tenaga Kerja Maka Harus Memasukkan RegNo Sesui Dari Payrol" &
    "l KARYAWAN Maupun HARIAN"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(664, 173)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(26, 13)
        Me.Label17.TabIndex = 218
        Me.Label17.Text = "Jam"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(491, 173)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(26, 13)
        Me.Label16.TabIndex = 217
        Me.Label16.Text = "Jam"
        '
        'txtJamKerjaPendek
        '
        Me.txtJamKerjaPendek.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJamKerjaPendek.Location = New System.Drawing.Point(626, 169)
        Me.txtJamKerjaPendek.Name = "txtJamKerjaPendek"
        Me.txtJamKerjaPendek.Size = New System.Drawing.Size(37, 21)
        Me.txtJamKerjaPendek.TabIndex = 215
        Me.txtJamKerjaPendek.Text = "5"
        Me.txtJamKerjaPendek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(530, 171)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 13)
        Me.Label15.TabIndex = 216
        Me.Label15.Text = "Jam Kerja Pendek"
        '
        'txtJamKerjaPanjang
        '
        Me.txtJamKerjaPanjang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJamKerjaPanjang.Location = New System.Drawing.Point(453, 169)
        Me.txtJamKerjaPanjang.Name = "txtJamKerjaPanjang"
        Me.txtJamKerjaPanjang.Size = New System.Drawing.Size(37, 21)
        Me.txtJamKerjaPanjang.TabIndex = 213
        Me.txtJamKerjaPanjang.Text = "7"
        Me.txtJamKerjaPanjang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(357, 171)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 13)
        Me.Label13.TabIndex = 214
        Me.Label13.Text = "Jam Kerja Panjang"
        '
        'cboLiburMinggaun
        '
        Me.cboLiburMinggaun.FormattingEnabled = True
        Me.cboLiburMinggaun.Location = New System.Drawing.Point(453, 142)
        Me.cboLiburMinggaun.Name = "cboLiburMinggaun"
        Me.cboLiburMinggaun.Size = New System.Drawing.Size(252, 21)
        Me.cboLiburMinggaun.TabIndex = 212
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(357, 145)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 211
        Me.Label12.Text = "Libur Mingguan"
        '
        'cboStatusJamKerja
        '
        Me.cboStatusJamKerja.FormattingEnabled = True
        Me.cboStatusJamKerja.Location = New System.Drawing.Point(453, 115)
        Me.cboStatusJamKerja.Name = "cboStatusJamKerja"
        Me.cboStatusJamKerja.Size = New System.Drawing.Size(252, 21)
        Me.cboStatusJamKerja.TabIndex = 210
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(357, 118)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 209
        Me.Label11.Text = "Status Jam Kerja"
        '
        'cboJenisKelamin
        '
        Me.cboJenisKelamin.FormattingEnabled = True
        Me.cboJenisKelamin.Location = New System.Drawing.Point(453, 88)
        Me.cboJenisKelamin.Name = "cboJenisKelamin"
        Me.cboJenisKelamin.Size = New System.Drawing.Size(252, 21)
        Me.cboJenisKelamin.TabIndex = 208
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(357, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 207
        Me.Label10.Text = "Jenis Kelamin"
        '
        'txtNikNama
        '
        Me.txtNikNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNikNama.Location = New System.Drawing.Point(426, 223)
        Me.txtNikNama.Name = "txtNikNama"
        Me.txtNikNama.Size = New System.Drawing.Size(252, 21)
        Me.txtNikNama.TabIndex = 205
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(364, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 206
        Me.Label9.Text = "Nik/Nama"
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(77, 9)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(252, 21)
        Me.cboStatus.TabIndex = 204
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 203
        Me.Label8.Text = "Status"
        '
        'dtTanggalKeluar
        '
        Me.dtTanggalKeluar.Checked = False
        Me.dtTanggalKeluar.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTanggalKeluar.Location = New System.Drawing.Point(77, 222)
        Me.dtTanggalKeluar.Name = "dtTanggalKeluar"
        Me.dtTanggalKeluar.ShowCheckBox = True
        Me.dtTanggalKeluar.Size = New System.Drawing.Size(200, 20)
        Me.dtTanggalKeluar.TabIndex = 202
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 222)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 201
        Me.Label7.Text = "Tgl. Keluar"
        '
        'dtTanggalMasuk
        '
        Me.dtTanggalMasuk.Checked = False
        Me.dtTanggalMasuk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTanggalMasuk.Location = New System.Drawing.Point(77, 196)
        Me.dtTanggalMasuk.Name = "dtTanggalMasuk"
        Me.dtTanggalMasuk.ShowCheckBox = True
        Me.dtTanggalMasuk.Size = New System.Drawing.Size(200, 20)
        Me.dtTanggalMasuk.TabIndex = 200
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 199
        Me.Label6.Text = "Tgl. Masuk"
        '
        'cboBagian
        '
        Me.cboBagian.Enabled = False
        Me.cboBagian.FormattingEnabled = True
        Me.cboBagian.Location = New System.Drawing.Point(77, 142)
        Me.cboBagian.Name = "cboBagian"
        Me.cboBagian.Size = New System.Drawing.Size(252, 21)
        Me.cboBagian.TabIndex = 198
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(8, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 197
        Me.Label2.Text = "Bagian"
        '
        'cboDepartemen
        '
        Me.cboDepartemen.FormattingEnabled = True
        Me.cboDepartemen.Location = New System.Drawing.Point(77, 115)
        Me.cboDepartemen.Name = "cboDepartemen"
        Me.cboDepartemen.Size = New System.Drawing.Size(252, 21)
        Me.cboDepartemen.TabIndex = 196
        '
        'cboJabatan
        '
        Me.cboJabatan.FormattingEnabled = True
        Me.cboJabatan.Location = New System.Drawing.Point(77, 169)
        Me.cboJabatan.Name = "cboJabatan"
        Me.cboJabatan.Size = New System.Drawing.Size(252, 21)
        Me.cboJabatan.TabIndex = 195
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 118)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 194
        Me.Label14.Text = "Departemen"
        '
        'txtRegNo
        '
        Me.txtRegNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegNo.Location = New System.Drawing.Point(77, 36)
        Me.txtRegNo.Name = "txtRegNo"
        Me.txtRegNo.Size = New System.Drawing.Size(100, 21)
        Me.txtRegNo.TabIndex = 187
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 188
        Me.Label1.Text = "RegNo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 189
        Me.Label3.Text = "Jabatan"
        '
        'txtNama
        '
        Me.txtNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNama.Location = New System.Drawing.Point(77, 88)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(252, 21)
        Me.txtNama.TabIndex = 190
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 193
        Me.Label5.Text = "Nik"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 191
        Me.Label4.Text = "Nama"
        '
        'txtNik
        '
        Me.txtNik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNik.Location = New System.Drawing.Point(77, 62)
        Me.txtNik.Name = "txtNik"
        Me.txtNik.Size = New System.Drawing.Size(100, 21)
        Me.txtNik.TabIndex = 192
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnEdit)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 446)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1121, 52)
        Me.Panel2.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.BackColor = System.Drawing.Color.MintCream
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.Location = New System.Drawing.Point(603, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 48)
        Me.btnCancel.TabIndex = 239
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClose.BackColor = System.Drawing.Color.MintCream
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClose.Location = New System.Drawing.Point(684, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 48)
        Me.btnClose.TabIndex = 237
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSave.BackColor = System.Drawing.Color.MintCream
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.Location = New System.Drawing.Point(523, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 48)
        Me.btnSave.TabIndex = 236
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnEdit.BackColor = System.Drawing.Color.MintCream
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.Location = New System.Drawing.Point(442, 2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 48)
        Me.btnEdit.TabIndex = 235
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAdd.BackColor = System.Drawing.Color.MintCream
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.Location = New System.Drawing.Point(361, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 48)
        Me.btnAdd.TabIndex = 234
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 46)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(173, 13)
        Me.Label20.TabIndex = 191
        Me.Label20.Text = "3. Nik Sesuaikan Dari Payroll"
        '
        'FrmMstTenagaKerja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1127, 501)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmMstTenagaKerja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Tenaga Kerja"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents cboBagian As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboDepartemen As ComboBox
    Friend WithEvents cboJabatan As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtRegNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNik As TextBox
    Friend WithEvents dtTanggalKeluar As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents dtTanggalMasuk As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtNikNama As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtJamKerjaPendek As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtJamKerjaPanjang As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cboLiburMinggaun As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cboStatusJamKerja As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cboJenisKelamin As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents btnChoose As Button
    Friend WithEvents chkAktif As CheckBox
    Friend WithEvents Label20 As Label
End Class
