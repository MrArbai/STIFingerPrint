<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnCutiIzinInput
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnCutiIzinInput))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtIDLiburMingguan = New System.Windows.Forms.TextBox()
        Me.lblPesan = New System.Windows.Forms.Label()
        Me.txtHeaderID = New System.Windows.Forms.TextBox()
        Me.txtRegNo = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.cboJenisTidakHadir = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkComplete = New System.Windows.Forms.CheckBox()
        Me.dtTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtTanggalMulai = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtJabatan = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDepartemen = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNik = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnProses = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.PowderBlue
        Me.Panel1.Controls.Add(Me.btnProses)
        Me.Panel1.Controls.Add(Me.txtKeterangan)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtIDLiburMingguan)
        Me.Panel1.Controls.Add(Me.lblPesan)
        Me.Panel1.Controls.Add(Me.txtHeaderID)
        Me.Panel1.Controls.Add(Me.txtRegNo)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnFind)
        Me.Panel1.Controls.Add(Me.cboJenisTidakHadir)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.chkComplete)
        Me.Panel1.Controls.Add(Me.dtTanggalAkhir)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.dtTanggalMulai)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtJabatan)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtDepartemen)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.txtNama)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtNik)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.fg)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(872, 691)
        Me.Panel1.TabIndex = 2
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeterangan.Location = New System.Drawing.Point(479, 84)
        Me.txtKeterangan.Multiline = True
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(368, 43)
        Me.txtKeterangan.TabIndex = 260
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(403, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 261
        Me.Label9.Text = "Keterangan"
        '
        'txtIDLiburMingguan
        '
        Me.txtIDLiburMingguan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDLiburMingguan.Location = New System.Drawing.Point(664, 7)
        Me.txtIDLiburMingguan.Name = "txtIDLiburMingguan"
        Me.txtIDLiburMingguan.Size = New System.Drawing.Size(25, 21)
        Me.txtIDLiburMingguan.TabIndex = 259
        Me.txtIDLiburMingguan.Visible = False
        '
        'lblPesan
        '
        Me.lblPesan.AutoSize = True
        Me.lblPesan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesan.ForeColor = System.Drawing.Color.Red
        Me.lblPesan.Location = New System.Drawing.Point(281, 34)
        Me.lblPesan.Name = "lblPesan"
        Me.lblPesan.Size = New System.Drawing.Size(42, 13)
        Me.lblPesan.TabIndex = 258
        Me.lblPesan.Text = "Pesan"
        Me.lblPesan.Visible = False
        '
        'txtHeaderID
        '
        Me.txtHeaderID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeaderID.Location = New System.Drawing.Point(281, 3)
        Me.txtHeaderID.Name = "txtHeaderID"
        Me.txtHeaderID.Size = New System.Drawing.Size(85, 21)
        Me.txtHeaderID.TabIndex = 257
        Me.txtHeaderID.Visible = False
        '
        'txtRegNo
        '
        Me.txtRegNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegNo.Location = New System.Drawing.Point(281, 30)
        Me.txtRegNo.Name = "txtRegNo"
        Me.txtRegNo.Size = New System.Drawing.Size(85, 21)
        Me.txtRegNo.TabIndex = 256
        Me.txtRegNo.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnDelete.BackColor = System.Drawing.Color.MintCream
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.Location = New System.Drawing.Point(479, 635)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 48)
        Me.btnDelete.TabIndex = 255
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnFind
        '
        Me.btnFind.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnFind.BackColor = System.Drawing.Color.MintCream
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFind.Location = New System.Drawing.Point(157, 635)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 48)
        Me.btnFind.TabIndex = 254
        Me.btnFind.Text = "Find"
        Me.btnFind.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'cboJenisTidakHadir
        '
        Me.cboJenisTidakHadir.FormattingEnabled = True
        Me.cboJenisTidakHadir.Location = New System.Drawing.Point(479, 7)
        Me.cboJenisTidakHadir.Name = "cboJenisTidakHadir"
        Me.cboJenisTidakHadir.Size = New System.Drawing.Size(179, 21)
        Me.cboJenisTidakHadir.TabIndex = 252
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(403, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 251
        Me.Label7.Text = "Jenis"
        '
        'chkComplete
        '
        Me.chkComplete.AutoSize = True
        Me.chkComplete.Location = New System.Drawing.Point(404, 110)
        Me.chkComplete.Name = "chkComplete"
        Me.chkComplete.Size = New System.Drawing.Size(70, 17)
        Me.chkComplete.TabIndex = 250
        Me.chkComplete.Text = "Complete"
        Me.chkComplete.UseVisualStyleBackColor = True
        '
        'dtTanggalAkhir
        '
        Me.dtTanggalAkhir.Checked = False
        Me.dtTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTanggalAkhir.Location = New System.Drawing.Point(479, 60)
        Me.dtTanggalAkhir.Name = "dtTanggalAkhir"
        Me.dtTanggalAkhir.Size = New System.Drawing.Size(200, 20)
        Me.dtTanggalAkhir.TabIndex = 249
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(403, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 248
        Me.Label5.Text = "Tgl. Akhir"
        '
        'dtTanggalMulai
        '
        Me.dtTanggalMulai.Checked = False
        Me.dtTanggalMulai.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTanggalMulai.Location = New System.Drawing.Point(479, 34)
        Me.dtTanggalMulai.Name = "dtTanggalMulai"
        Me.dtTanggalMulai.Size = New System.Drawing.Size(200, 20)
        Me.dtTanggalMulai.TabIndex = 247
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(403, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 246
        Me.Label6.Text = "Tgl. Mulai"
        '
        'txtJabatan
        '
        Me.txtJabatan.Enabled = False
        Me.txtJabatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJabatan.Location = New System.Drawing.Point(96, 111)
        Me.txtJabatan.Name = "txtJabatan"
        Me.txtJabatan.Size = New System.Drawing.Size(270, 21)
        Me.txtJabatan.TabIndex = 244
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 245
        Me.Label4.Text = "Jabatan"
        '
        'txtDepartemen
        '
        Me.txtDepartemen.Enabled = False
        Me.txtDepartemen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartemen.Location = New System.Drawing.Point(96, 84)
        Me.txtDepartemen.Name = "txtDepartemen"
        Me.txtDepartemen.Size = New System.Drawing.Size(270, 21)
        Me.txtDepartemen.TabIndex = 242
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 243
        Me.Label2.Text = "Departemen"
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(96, 4)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(179, 21)
        Me.cboStatus.TabIndex = 241
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 240
        Me.Label8.Text = "Status"
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.BackColor = System.Drawing.Color.MintCream
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.Location = New System.Drawing.Point(399, 635)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 48)
        Me.btnSave.TabIndex = 236
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAdd.BackColor = System.Drawing.Color.MintCream
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.Location = New System.Drawing.Point(238, 635)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 48)
        Me.btnAdd.TabIndex = 234
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEdit.BackColor = System.Drawing.Color.MintCream
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.Location = New System.Drawing.Point(319, 635)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 48)
        Me.btnEdit.TabIndex = 235
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.BackColor = System.Drawing.Color.MintCream
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.Location = New System.Drawing.Point(560, 635)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 48)
        Me.btnCancel.TabIndex = 239
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnClose.BackColor = System.Drawing.Color.MintCream
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClose.Location = New System.Drawing.Point(641, 635)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 48)
        Me.btnClose.TabIndex = 237
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtNama
        '
        Me.txtNama.Enabled = False
        Me.txtNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNama.Location = New System.Drawing.Point(96, 57)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(270, 21)
        Me.txtNama.TabIndex = 180
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 181
        Me.Label3.Text = "Nama"
        '
        'txtNik
        '
        Me.txtNik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNik.Location = New System.Drawing.Point(96, 30)
        Me.txtNik.Name = "txtNik"
        Me.txtNik.Size = New System.Drawing.Size(179, 21)
        Me.txtNik.TabIndex = 176
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "Nik"
        '
        'fg
        '
        Me.fg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.fg.Location = New System.Drawing.Point(28, 138)
        Me.fg.Name = "fg"
        Me.fg.Rows.DefaultSize = 19
        Me.fg.Size = New System.Drawing.Size(819, 491)
        Me.fg.TabIndex = 1
        '
        'btnProses
        '
        Me.btnProses.Location = New System.Drawing.Point(685, 55)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(75, 23)
        Me.btnProses.TabIndex = 262
        Me.btnProses.Text = "Proses"
        Me.btnProses.UseVisualStyleBackColor = True
        '
        'FrmTrnCutiIzinInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 715)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmTrnCutiIzinInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Cuti Izin"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents txtNama As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNik As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtJabatan As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDepartemen As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtTanggalAkhir As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents dtTanggalMulai As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents chkComplete As CheckBox
    Friend WithEvents cboJenisTidakHadir As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnFind As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents txtRegNo As TextBox
    Friend WithEvents txtHeaderID As TextBox
    Friend WithEvents lblPesan As Label
    Friend WithEvents txtIDLiburMingguan As TextBox
    Friend WithEvents txtKeterangan As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnProses As Button
End Class
