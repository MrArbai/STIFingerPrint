<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnKambalikanAbsensi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnKambalikanAbsensi))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cboDepartemen = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnCloseDevice = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtPeriode1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.PowderBlue
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.cboDepartemen)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.btnCloseDevice)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.fg)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtPeriode1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(439, 575)
        Me.Panel1.TabIndex = 0
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(87, 33)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(217, 21)
        Me.cboStatus.TabIndex = 274
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(13, 36)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(37, 13)
        Me.Label28.TabIndex = 273
        Me.Label28.Text = "Status"
        '
        'cboDepartemen
        '
        Me.cboDepartemen.FormattingEnabled = True
        Me.cboDepartemen.Location = New System.Drawing.Point(87, 59)
        Me.cboDepartemen.Name = "cboDepartemen"
        Me.cboDepartemen.Size = New System.Drawing.Size(217, 21)
        Me.cboDepartemen.TabIndex = 272
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(13, 62)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(65, 13)
        Me.Label27.TabIndex = 271
        Me.Label27.Text = "Departemen"
        '
        'btnCloseDevice
        '
        Me.btnCloseDevice.BackColor = System.Drawing.Color.MintCream
        Me.btnCloseDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseDevice.Image = CType(resources.GetObject("btnCloseDevice.Image"), System.Drawing.Image)
        Me.btnCloseDevice.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCloseDevice.Location = New System.Drawing.Point(222, 520)
        Me.btnCloseDevice.Name = "btnCloseDevice"
        Me.btnCloseDevice.Size = New System.Drawing.Size(75, 48)
        Me.btnCloseDevice.TabIndex = 246
        Me.btnCloseDevice.Text = "Close"
        Me.btnCloseDevice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCloseDevice.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.MintCream
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.Location = New System.Drawing.Point(141, 520)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 48)
        Me.btnSave.TabIndex = 245
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'fg
        '
        Me.fg.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.fg.Location = New System.Drawing.Point(16, 87)
        Me.fg.Name = "fg"
        Me.fg.Rows.DefaultSize = 19
        Me.fg.Size = New System.Drawing.Size(408, 427)
        Me.fg.TabIndex = 244
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.MintCream
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRefresh.Location = New System.Drawing.Point(310, 33)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(119, 48)
        Me.btnRefresh.TabIndex = 243
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 242
        Me.Label3.Text = "Periode"
        '
        'dtPeriode1
        '
        Me.dtPeriode1.CustomFormat = "MM/yyyy"
        Me.dtPeriode1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPeriode1.Location = New System.Drawing.Point(87, 9)
        Me.dtPeriode1.Name = "dtPeriode1"
        Me.dtPeriode1.ShowUpDown = True
        Me.dtPeriode1.Size = New System.Drawing.Size(120, 20)
        Me.dtPeriode1.TabIndex = 241
        '
        'FrmTrnKambalikanAbsensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 608)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnKambalikanAbsensi"
        Me.Text = "Kambalikan Absensi"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents dtPeriode1 As DateTimePicker
    Friend WithEvents btnCloseDevice As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents cboDepartemen As ComboBox
    Friend WithEvents Label27 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label28 As Label
End Class
