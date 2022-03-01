<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnRestorRecodFinger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnRestorRecodFinger))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtNik = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtTanggal = New System.Windows.Forms.DateTimePicker()
        Me.btnCloseDevice = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.PowderBlue
        Me.Panel1.Controls.Add(Me.txtNik)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtTanggal)
        Me.Panel1.Controls.Add(Me.btnCloseDevice)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.fg)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(539, 710)
        Me.Panel1.TabIndex = 0
        '
        'txtNik
        '
        Me.txtNik.Location = New System.Drawing.Point(73, 36)
        Me.txtNik.Name = "txtNik"
        Me.txtNik.Size = New System.Drawing.Size(100, 20)
        Me.txtNik.TabIndex = 254
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 253
        Me.Label1.Text = "Nik"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Tanggal"
        '
        'dtTanggal
        '
        Me.dtTanggal.Location = New System.Drawing.Point(73, 10)
        Me.dtTanggal.Name = "dtTanggal"
        Me.dtTanggal.Size = New System.Drawing.Size(117, 20)
        Me.dtTanggal.TabIndex = 251
        '
        'btnCloseDevice
        '
        Me.btnCloseDevice.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCloseDevice.BackColor = System.Drawing.Color.MintCream
        Me.btnCloseDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseDevice.Image = CType(resources.GetObject("btnCloseDevice.Image"), System.Drawing.Image)
        Me.btnCloseDevice.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCloseDevice.Location = New System.Drawing.Point(272, 659)
        Me.btnCloseDevice.Name = "btnCloseDevice"
        Me.btnCloseDevice.Size = New System.Drawing.Size(75, 48)
        Me.btnCloseDevice.TabIndex = 250
        Me.btnCloseDevice.Text = "Close"
        Me.btnCloseDevice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCloseDevice.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.BackColor = System.Drawing.Color.MintCream
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.Location = New System.Drawing.Point(191, 659)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 48)
        Me.btnSave.TabIndex = 249
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.fg.Location = New System.Drawing.Point(14, 65)
        Me.fg.Name = "fg"
        Me.fg.Rows.DefaultSize = 19
        Me.fg.Size = New System.Drawing.Size(508, 588)
        Me.fg.TabIndex = 248
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.MintCream
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRefresh.Location = New System.Drawing.Point(281, 11)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(119, 48)
        Me.btnRefresh.TabIndex = 247
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'FrmTrnRestorRecodFinger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 732)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnRestorRecodFinger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restor Recod Finger"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCloseDevice As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dtTanggal As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNik As TextBox
    Friend WithEvents Label1 As Label
End Class
