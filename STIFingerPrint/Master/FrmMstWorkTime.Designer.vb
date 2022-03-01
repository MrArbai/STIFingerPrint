<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstWorkTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstWorkTime))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPanjangKerjaSabtu = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPanjangKerjaJumat = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPanjangKerjaBiasa = New System.Windows.Forms.TextBox()
        Me.chk = New System.Windows.Forms.CheckBox()
        Me.txtGroupAbsenID = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtJamIstirahatJumat = New System.Windows.Forms.MaskedTextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLamaIstirahatJumat = New System.Windows.Forms.TextBox()
        Me.txtLamaIstNormal = New System.Windows.Forms.TextBox()
        Me.txtJamIstirahatNormal = New System.Windows.Forms.MaskedTextBox()
        Me.txtJamPulang = New System.Windows.Forms.MaskedTextBox()
        Me.txtJamMasuk = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.PowderBlue
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtPanjangKerjaSabtu)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtPanjangKerjaJumat)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtPanjangKerjaBiasa)
        Me.Panel1.Controls.Add(Me.chk)
        Me.Panel1.Controls.Add(Me.txtGroupAbsenID)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtJamIstirahatJumat)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.fg)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtLamaIstirahatJumat)
        Me.Panel1.Controls.Add(Me.txtLamaIstNormal)
        Me.Panel1.Controls.Add(Me.txtJamIstirahatNormal)
        Me.Panel1.Controls.Add(Me.txtJamPulang)
        Me.Panel1.Controls.Add(Me.txtJamMasuk)
        Me.Panel1.Location = New System.Drawing.Point(4, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(925, 443)
        Me.Panel1.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(780, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 13)
        Me.Label13.TabIndex = 246
        Me.Label13.Text = "Jam"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(780, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 13)
        Me.Label14.TabIndex = 245
        Me.Label14.Text = "Panjang Kerja Sabtu"
        '
        'txtPanjangKerjaSabtu
        '
        Me.txtPanjangKerjaSabtu.Location = New System.Drawing.Point(810, 34)
        Me.txtPanjangKerjaSabtu.Name = "txtPanjangKerjaSabtu"
        Me.txtPanjangKerjaSabtu.Size = New System.Drawing.Size(46, 20)
        Me.txtPanjangKerjaSabtu.TabIndex = 244
        Me.txtPanjangKerjaSabtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(673, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 243
        Me.Label11.Text = "Jam"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(673, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 13)
        Me.Label12.TabIndex = 242
        Me.Label12.Text = "Panjang Kerja Jumat"
        '
        'txtPanjangKerjaJumat
        '
        Me.txtPanjangKerjaJumat.Location = New System.Drawing.Point(703, 31)
        Me.txtPanjangKerjaJumat.Name = "txtPanjangKerjaJumat"
        Me.txtPanjangKerjaJumat.Size = New System.Drawing.Size(46, 20)
        Me.txtPanjangKerjaJumat.TabIndex = 241
        Me.txtPanjangKerjaJumat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(571, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 240
        Me.Label9.Text = "Jam"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(571, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 13)
        Me.Label10.TabIndex = 239
        Me.Label10.Text = "Panjang Kerja Biasa"
        '
        'txtPanjangKerjaBiasa
        '
        Me.txtPanjangKerjaBiasa.Location = New System.Drawing.Point(601, 31)
        Me.txtPanjangKerjaBiasa.Name = "txtPanjangKerjaBiasa"
        Me.txtPanjangKerjaBiasa.Size = New System.Drawing.Size(46, 20)
        Me.txtPanjangKerjaBiasa.TabIndex = 238
        Me.txtPanjangKerjaBiasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chk
        '
        Me.chk.AutoSize = True
        Me.chk.Location = New System.Drawing.Point(870, 36)
        Me.chk.Name = "chk"
        Me.chk.Size = New System.Drawing.Size(47, 17)
        Me.chk.TabIndex = 237
        Me.chk.Text = "Aktif"
        Me.chk.UseVisualStyleBackColor = True
        '
        'txtGroupAbsenID
        '
        Me.txtGroupAbsenID.Location = New System.Drawing.Point(3, 408)
        Me.txtGroupAbsenID.Name = "txtGroupAbsenID"
        Me.txtGroupAbsenID.Size = New System.Drawing.Size(46, 20)
        Me.txtGroupAbsenID.TabIndex = 236
        Me.txtGroupAbsenID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGroupAbsenID.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(247, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 13)
        Me.Label8.TabIndex = 235
        Me.Label8.Text = "Istirahat Keluar Jumat"
        '
        'txtJamIstirahatJumat
        '
        Me.txtJamIstirahatJumat.Location = New System.Drawing.Point(274, 31)
        Me.txtJamIstirahatJumat.Mask = "90:00"
        Me.txtJamIstirahatJumat.Name = "txtJamIstirahatJumat"
        Me.txtJamIstirahatJumat.Size = New System.Drawing.Size(46, 20)
        Me.txtJamIstirahatJumat.TabIndex = 234
        Me.txtJamIstirahatJumat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamIstirahatJumat.ValidatingType = GetType(Date)
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.MintCream
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.Location = New System.Drawing.Point(506, 392)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 48)
        Me.btnCancel.TabIndex = 233
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
        Me.btnClose.Location = New System.Drawing.Point(587, 392)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 48)
        Me.btnClose.TabIndex = 231
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
        Me.btnSave.Location = New System.Drawing.Point(425, 392)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 48)
        Me.btnSave.TabIndex = 230
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
        Me.btnEdit.Location = New System.Drawing.Point(344, 392)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 48)
        Me.btnEdit.TabIndex = 229
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
        Me.btnAdd.Location = New System.Drawing.Point(263, 392)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 48)
        Me.btnAdd.TabIndex = 228
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.fg.Location = New System.Drawing.Point(7, 72)
        Me.fg.Name = "fg"
        Me.fg.Rows.DefaultSize = 19
        Me.fg.Size = New System.Drawing.Size(910, 314)
        Me.fg.TabIndex = 173
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(354, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Menit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(464, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Menit"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(468, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Lama Istirahat Jumat"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(358, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Lama Istirahat Normal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(134, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Istirahat Keluar Normal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Jam Pulang"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Jam Masuk"
        '
        'txtLamaIstirahatJumat
        '
        Me.txtLamaIstirahatJumat.Location = New System.Drawing.Point(498, 31)
        Me.txtLamaIstirahatJumat.Name = "txtLamaIstirahatJumat"
        Me.txtLamaIstirahatJumat.Size = New System.Drawing.Size(46, 20)
        Me.txtLamaIstirahatJumat.TabIndex = 5
        Me.txtLamaIstirahatJumat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLamaIstNormal
        '
        Me.txtLamaIstNormal.Location = New System.Drawing.Point(388, 31)
        Me.txtLamaIstNormal.Name = "txtLamaIstNormal"
        Me.txtLamaIstNormal.Size = New System.Drawing.Size(46, 20)
        Me.txtLamaIstNormal.TabIndex = 4
        Me.txtLamaIstNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtJamIstirahatNormal
        '
        Me.txtJamIstirahatNormal.Location = New System.Drawing.Point(169, 31)
        Me.txtJamIstirahatNormal.Mask = "90:00"
        Me.txtJamIstirahatNormal.Name = "txtJamIstirahatNormal"
        Me.txtJamIstirahatNormal.Size = New System.Drawing.Size(46, 20)
        Me.txtJamIstirahatNormal.TabIndex = 2
        Me.txtJamIstirahatNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamIstirahatNormal.ValidatingType = GetType(Date)
        '
        'txtJamPulang
        '
        Me.txtJamPulang.Location = New System.Drawing.Point(74, 31)
        Me.txtJamPulang.Mask = "90:00"
        Me.txtJamPulang.Name = "txtJamPulang"
        Me.txtJamPulang.Size = New System.Drawing.Size(46, 20)
        Me.txtJamPulang.TabIndex = 1
        Me.txtJamPulang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamPulang.ValidatingType = GetType(Date)
        '
        'txtJamMasuk
        '
        Me.txtJamMasuk.Location = New System.Drawing.Point(7, 31)
        Me.txtJamMasuk.Mask = "90:00"
        Me.txtJamMasuk.Name = "txtJamMasuk"
        Me.txtJamMasuk.Size = New System.Drawing.Size(46, 20)
        Me.txtJamMasuk.TabIndex = 0
        Me.txtJamMasuk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtJamMasuk.ValidatingType = GetType(Date)
        '
        'FrmMstWorkTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 467)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMstWorkTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Work Time"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtJamMasuk As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLamaIstirahatJumat As TextBox
    Friend WithEvents txtLamaIstNormal As TextBox
    Friend WithEvents txtJamIstirahatNormal As MaskedTextBox
    Friend WithEvents txtJamPulang As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtJamIstirahatJumat As MaskedTextBox
    Friend WithEvents txtGroupAbsenID As TextBox
    Friend WithEvents chk As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtPanjangKerjaSabtu As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtPanjangKerjaJumat As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPanjangKerjaBiasa As TextBox
End Class
