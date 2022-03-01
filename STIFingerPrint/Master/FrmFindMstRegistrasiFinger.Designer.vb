<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFindMstRegistrasiFinger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFindMstRegistrasiFinger))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnChose = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNikNama = New System.Windows.Forms.TextBox()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.CadetBlue
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnChose)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.fg)
        Me.Panel1.Controls.Add(Me.btnChoose)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtNikNama)
        Me.Panel1.Controls.Add(Me.cboDept)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(683, 450)
        Me.Panel1.TabIndex = 0
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(88, 9)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(233, 21)
        Me.cboStatus.TabIndex = 238
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Status"
        '
        'btnChose
        '
        Me.btnChose.BackColor = System.Drawing.Color.MintCream
        Me.btnChose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChose.Image = CType(resources.GetObject("btnChose.Image"), System.Drawing.Image)
        Me.btnChose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnChose.Location = New System.Drawing.Point(512, 399)
        Me.btnChose.Name = "btnChose"
        Me.btnChose.Size = New System.Drawing.Size(75, 48)
        Me.btnChose.TabIndex = 236
        Me.btnChose.Text = "Choose"
        Me.btnChose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnChose.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.MintCream
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClose.Location = New System.Drawing.Point(593, 399)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 48)
        Me.btnClose.TabIndex = 235
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.fg.Location = New System.Drawing.Point(9, 85)
        Me.fg.Name = "fg"
        Me.fg.Rows.DefaultSize = 19
        Me.fg.Size = New System.Drawing.Size(659, 308)
        Me.fg.TabIndex = 234
        '
        'btnChoose
        '
        Me.btnChoose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChoose.BackColor = System.Drawing.Color.MintCream
        Me.btnChoose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChoose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChoose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChoose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChoose.Image = CType(resources.GetObject("btnChoose.Image"), System.Drawing.Image)
        Me.btnChoose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChoose.Location = New System.Drawing.Point(327, 28)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(65, 28)
        Me.btnChoose.TabIndex = 233
        Me.btnChoose.Text = "Find"
        Me.btnChoose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnChoose.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 60)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 232
        Me.Label13.Text = "Nik/Nama"
        '
        'txtNikNama
        '
        Me.txtNikNama.Location = New System.Drawing.Point(88, 57)
        Me.txtNikNama.Name = "txtNikNama"
        Me.txtNikNama.Size = New System.Drawing.Size(233, 20)
        Me.txtNikNama.TabIndex = 231
        '
        'cboDept
        '
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.Location = New System.Drawing.Point(88, 33)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(233, 21)
        Me.cboDept.TabIndex = 174
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 173
        Me.Label14.Text = "Departemen"
        '
        'FrmFindMstRegistrasiFinger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 474)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmFindMstRegistrasiFinger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Find Master Registrasi Finger"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents cboDept As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnChoose As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents txtNikNama As TextBox
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnChose As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label1 As Label
End Class
