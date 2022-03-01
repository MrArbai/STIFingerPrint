<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonAkumulasiKeterlambatan
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonAkumulasiKeterlambatan))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPeriode = New System.Windows.Forms.MaskedTextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fg1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnExecl = New System.Windows.Forms.Button()
        Me.btnCloseDevice = New System.Windows.Forms.Button()
        Me.fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cboDepartemen = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 749.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1047, 544)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.cboDepartemen)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.txtPeriode)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.fg1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(743, 538)
        Me.Panel1.TabIndex = 0
        '
        'txtPeriode
        '
        Me.txtPeriode.Location = New System.Drawing.Point(90, 11)
        Me.txtPeriode.Mask = "00/0000"
        Me.txtPeriode.Name = "txtPeriode"
        Me.txtPeriode.Size = New System.Drawing.Size(57, 20)
        Me.txtPeriode.TabIndex = 241
        Me.txtPeriode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.MintCream
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRefresh.Location = New System.Drawing.Point(313, 38)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(119, 48)
        Me.btnRefresh.TabIndex = 240
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 239
        Me.Label3.Text = "Periode"
        '
        'fg1
        '
        Me.fg1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg1.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.fg1.Location = New System.Drawing.Point(9, 92)
        Me.fg1.Name = "fg1"
        Me.fg1.Rows.DefaultSize = 19
        Me.fg1.Size = New System.Drawing.Size(734, 437)
        Me.fg1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnExecl)
        Me.Panel2.Controls.Add(Me.btnCloseDevice)
        Me.Panel2.Controls.Add(Me.fg2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(752, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(292, 538)
        Me.Panel2.TabIndex = 1
        '
        'btnExecl
        '
        Me.btnExecl.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnExecl.BackColor = System.Drawing.Color.MintCream
        Me.btnExecl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExecl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecl.Image = CType(resources.GetObject("btnExecl.Image"), System.Drawing.Image)
        Me.btnExecl.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExecl.Location = New System.Drawing.Point(68, 487)
        Me.btnExecl.Name = "btnExecl"
        Me.btnExecl.Size = New System.Drawing.Size(75, 48)
        Me.btnExecl.TabIndex = 236
        Me.btnExecl.Text = "Excel"
        Me.btnExecl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExecl.UseVisualStyleBackColor = False
        '
        'btnCloseDevice
        '
        Me.btnCloseDevice.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCloseDevice.BackColor = System.Drawing.Color.MintCream
        Me.btnCloseDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseDevice.Image = CType(resources.GetObject("btnCloseDevice.Image"), System.Drawing.Image)
        Me.btnCloseDevice.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCloseDevice.Location = New System.Drawing.Point(149, 487)
        Me.btnCloseDevice.Name = "btnCloseDevice"
        Me.btnCloseDevice.Size = New System.Drawing.Size(75, 48)
        Me.btnCloseDevice.TabIndex = 235
        Me.btnCloseDevice.Text = "Close"
        Me.btnCloseDevice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCloseDevice.UseVisualStyleBackColor = False
        '
        'fg2
        '
        Me.fg2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg2.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.fg2.Location = New System.Drawing.Point(0, 0)
        Me.fg2.Name = "fg2"
        Me.fg2.Rows.DefaultSize = 19
        Me.fg2.Size = New System.Drawing.Size(292, 481)
        Me.fg2.TabIndex = 0
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(90, 37)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(217, 21)
        Me.cboStatus.TabIndex = 278
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(16, 40)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(37, 13)
        Me.Label28.TabIndex = 277
        Me.Label28.Text = "Status"
        '
        'cboDepartemen
        '
        Me.cboDepartemen.FormattingEnabled = True
        Me.cboDepartemen.Location = New System.Drawing.Point(90, 63)
        Me.cboDepartemen.Name = "cboDepartemen"
        Me.cboDepartemen.Size = New System.Drawing.Size(217, 21)
        Me.cboDepartemen.TabIndex = 276
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(16, 66)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(65, 13)
        Me.Label27.TabIndex = 275
        Me.Label27.Text = "Departemen"
        '
        'FrmMonAkumulasiKeterlambatan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 544)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmMonAkumulasiKeterlambatan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Akumulasi Keterlambatan"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents fg1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnExecl As Button
    Friend WithEvents btnCloseDevice As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtPeriode As MaskedTextBox
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents cboDepartemen As ComboBox
    Friend WithEvents Label27 As Label
End Class
