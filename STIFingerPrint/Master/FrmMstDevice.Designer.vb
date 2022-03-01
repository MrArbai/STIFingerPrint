<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstDevice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstDevice))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnKonek = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDevice = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.fgDeviceList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBaudRate = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtComPort = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIPAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboConectionType = New System.Windows.Forms.ComboBox()
        Me.txtDeviceName = New System.Windows.Forms.TextBox()
        Me.txtDeviceID = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnSetDevTime4 = New System.Windows.Forms.Button()
        Me.btnSetDevTime3 = New System.Windows.Forms.Button()
        Me.btnSetDevTime2 = New System.Windows.Forms.Button()
        Me.btnGetDevTime2 = New System.Windows.Forms.Button()
        Me.dtDeviceTime = New System.Windows.Forms.DateTimePicker()
        Me.btnSetDevTime1 = New System.Windows.Forms.Button()
        Me.btnGetDevTime1 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDeviceTime = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnDeleteSch = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnSaveSch = New System.Windows.Forms.Button()
        Me.txtTime = New System.Windows.Forms.MaskedTextBox()
        Me.fgSch = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cboDeviceSch = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnCancelDevice = New System.Windows.Forms.Button()
        Me.btnDeleteDevice = New System.Windows.Forms.Button()
        Me.btnCloseDevice = New System.Windows.Forms.Button()
        Me.btnSaveDevice = New System.Windows.Forms.Button()
        Me.btnEditDevice = New System.Windows.Forms.Button()
        Me.btnAddDevice = New System.Windows.Forms.Button()
        Me.rdSeviceSTI = New System.Windows.Forms.RadioButton()
        Me.rdServicePSG = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.fgDeviceList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.fgSch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.PowderBlue
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 31)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(660, 524)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PowderBlue
        Me.Panel1.Controls.Add(Me.btnKonek)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboDevice)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(654, 461)
        Me.Panel1.TabIndex = 1
        '
        'btnKonek
        '
        Me.btnKonek.BackColor = System.Drawing.Color.MintCream
        Me.btnKonek.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKonek.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKonek.Location = New System.Drawing.Point(243, 3)
        Me.btnKonek.Name = "btnKonek"
        Me.btnKonek.Size = New System.Drawing.Size(119, 37)
        Me.btnKonek.TabIndex = 159
        Me.btnKonek.Text = "Connect"
        Me.btnKonek.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 158
        Me.Label2.Text = "Device"
        '
        'cboDevice
        '
        Me.cboDevice.FormattingEnabled = True
        Me.cboDevice.Location = New System.Drawing.Point(72, 13)
        Me.cboDevice.Name = "cboDevice"
        Me.cboDevice.Size = New System.Drawing.Size(165, 21)
        Me.cboDevice.TabIndex = 157
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(11, 46)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(632, 412)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.fgDeviceList)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cboConectionType)
        Me.TabPage1.Controls.Add(Me.txtDeviceName)
        Me.TabPage1.Controls.Add(Me.txtDeviceID)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(624, 384)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Device List"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'fgDeviceList
        '
        Me.fgDeviceList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fgDeviceList.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.fgDeviceList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fgDeviceList.Location = New System.Drawing.Point(6, 149)
        Me.fgDeviceList.Name = "fgDeviceList"
        Me.fgDeviceList.Rows.DefaultSize = 19
        Me.fgDeviceList.Size = New System.Drawing.Size(612, 226)
        Me.fgDeviceList.TabIndex = 164
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtBaudRate)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtComPort)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtPort)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtIPAddress)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(7, 85)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(611, 58)
        Me.Panel2.TabIndex = 163
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(246, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 170
        Me.Label7.Text = "Baud Rate"
        '
        'txtBaudRate
        '
        Me.txtBaudRate.Enabled = False
        Me.txtBaudRate.Location = New System.Drawing.Point(335, 32)
        Me.txtBaudRate.Name = "txtBaudRate"
        Me.txtBaudRate.Size = New System.Drawing.Size(155, 20)
        Me.txtBaudRate.TabIndex = 169
        Me.txtBaudRate.Text = "115200"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(246, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 168
        Me.Label8.Text = "Com Port"
        '
        'txtComPort
        '
        Me.txtComPort.Enabled = False
        Me.txtComPort.Location = New System.Drawing.Point(335, 6)
        Me.txtComPort.Name = "txtComPort"
        Me.txtComPort.Size = New System.Drawing.Size(155, 20)
        Me.txtComPort.TabIndex = 167
        Me.txtComPort.Text = "21"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 166
        Me.Label6.Text = "Port"
        '
        'txtPort
        '
        Me.txtPort.Enabled = False
        Me.txtPort.Location = New System.Drawing.Point(96, 32)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(144, 20)
        Me.txtPort.TabIndex = 165
        Me.txtPort.Text = "4370"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 164
        Me.Label5.Text = "IP Address"
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Enabled = False
        Me.txtIPAddress.Location = New System.Drawing.Point(96, 6)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(144, 20)
        Me.txtIPAddress.TabIndex = 163
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "Device ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 161
        Me.Label3.Text = "Device Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Connection Type"
        '
        'cboConectionType
        '
        Me.cboConectionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConectionType.FormattingEnabled = True
        Me.cboConectionType.Location = New System.Drawing.Point(93, 58)
        Me.cboConectionType.Name = "cboConectionType"
        Me.cboConectionType.Size = New System.Drawing.Size(201, 21)
        Me.cboConectionType.TabIndex = 159
        '
        'txtDeviceName
        '
        Me.txtDeviceName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceName.Location = New System.Drawing.Point(93, 32)
        Me.txtDeviceName.Name = "txtDeviceName"
        Me.txtDeviceName.Size = New System.Drawing.Size(201, 20)
        Me.txtDeviceName.TabIndex = 1
        '
        'txtDeviceID
        '
        Me.txtDeviceID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceID.Location = New System.Drawing.Point(93, 6)
        Me.txtDeviceID.Name = "txtDeviceID"
        Me.txtDeviceID.Size = New System.Drawing.Size(100, 20)
        Me.txtDeviceID.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnSetDevTime4)
        Me.TabPage2.Controls.Add(Me.btnSetDevTime3)
        Me.TabPage2.Controls.Add(Me.btnSetDevTime2)
        Me.TabPage2.Controls.Add(Me.btnGetDevTime2)
        Me.TabPage2.Controls.Add(Me.dtDeviceTime)
        Me.TabPage2.Controls.Add(Me.btnSetDevTime1)
        Me.TabPage2.Controls.Add(Me.btnGetDevTime1)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtDeviceTime)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(624, 384)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Device Time"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnSetDevTime4
        '
        Me.btnSetDevTime4.BackColor = System.Drawing.Color.MintCream
        Me.btnSetDevTime4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetDevTime4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetDevTime4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSetDevTime4.Location = New System.Drawing.Point(109, 181)
        Me.btnSetDevTime4.Name = "btnSetDevTime4"
        Me.btnSetDevTime4.Size = New System.Drawing.Size(206, 23)
        Me.btnSetDevTime4.TabIndex = 173
        Me.btnSetDevTime4.Text = "Set Device Time = Database Time"
        Me.btnSetDevTime4.UseVisualStyleBackColor = False
        '
        'btnSetDevTime3
        '
        Me.btnSetDevTime3.BackColor = System.Drawing.Color.MintCream
        Me.btnSetDevTime3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetDevTime3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetDevTime3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSetDevTime3.Location = New System.Drawing.Point(109, 152)
        Me.btnSetDevTime3.Name = "btnSetDevTime3"
        Me.btnSetDevTime3.Size = New System.Drawing.Size(206, 23)
        Me.btnSetDevTime3.TabIndex = 172
        Me.btnSetDevTime3.Text = "Set Device Time = Computer Time"
        Me.btnSetDevTime3.UseVisualStyleBackColor = False
        '
        'btnSetDevTime2
        '
        Me.btnSetDevTime2.BackColor = System.Drawing.Color.MintCream
        Me.btnSetDevTime2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetDevTime2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetDevTime2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSetDevTime2.Location = New System.Drawing.Point(215, 123)
        Me.btnSetDevTime2.Name = "btnSetDevTime2"
        Me.btnSetDevTime2.Size = New System.Drawing.Size(100, 23)
        Me.btnSetDevTime2.TabIndex = 171
        Me.btnSetDevTime2.Text = "Set Device Time"
        Me.btnSetDevTime2.UseVisualStyleBackColor = False
        '
        'btnGetDevTime2
        '
        Me.btnGetDevTime2.BackColor = System.Drawing.Color.MintCream
        Me.btnGetDevTime2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetDevTime2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetDevTime2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGetDevTime2.Location = New System.Drawing.Point(109, 123)
        Me.btnGetDevTime2.Name = "btnGetDevTime2"
        Me.btnGetDevTime2.Size = New System.Drawing.Size(100, 23)
        Me.btnGetDevTime2.TabIndex = 170
        Me.btnGetDevTime2.Text = "Get Device Time"
        Me.btnGetDevTime2.UseVisualStyleBackColor = False
        '
        'dtDeviceTime
        '
        Me.dtDeviceTime.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtDeviceTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtDeviceTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDeviceTime.Location = New System.Drawing.Point(109, 97)
        Me.dtDeviceTime.Name = "dtDeviceTime"
        Me.dtDeviceTime.Size = New System.Drawing.Size(200, 20)
        Me.dtDeviceTime.TabIndex = 169
        '
        'btnSetDevTime1
        '
        Me.btnSetDevTime1.BackColor = System.Drawing.Color.MintCream
        Me.btnSetDevTime1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetDevTime1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetDevTime1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSetDevTime1.Location = New System.Drawing.Point(215, 45)
        Me.btnSetDevTime1.Name = "btnSetDevTime1"
        Me.btnSetDevTime1.Size = New System.Drawing.Size(100, 23)
        Me.btnSetDevTime1.TabIndex = 168
        Me.btnSetDevTime1.Text = "Set Device Time"
        Me.btnSetDevTime1.UseVisualStyleBackColor = False
        '
        'btnGetDevTime1
        '
        Me.btnGetDevTime1.BackColor = System.Drawing.Color.MintCream
        Me.btnGetDevTime1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetDevTime1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetDevTime1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGetDevTime1.Location = New System.Drawing.Point(109, 45)
        Me.btnGetDevTime1.Name = "btnGetDevTime1"
        Me.btnGetDevTime1.Size = New System.Drawing.Size(100, 23)
        Me.btnGetDevTime1.TabIndex = 167
        Me.btnGetDevTime1.Text = "Get Device Time"
        Me.btnGetDevTime1.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 166
        Me.Label9.Text = "Device Time"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 165
        Me.Label10.Text = "Set Device Time"
        '
        'txtDeviceTime
        '
        Me.txtDeviceTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceTime.Location = New System.Drawing.Point(109, 19)
        Me.txtDeviceTime.Name = "txtDeviceTime"
        Me.txtDeviceTime.Size = New System.Drawing.Size(206, 20)
        Me.txtDeviceTime.TabIndex = 163
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.rdServicePSG)
        Me.TabPage3.Controls.Add(Me.rdSeviceSTI)
        Me.TabPage3.Controls.Add(Me.btnDeleteSch)
        Me.TabPage3.Controls.Add(Me.txtID)
        Me.TabPage3.Controls.Add(Me.btnSaveSch)
        Me.TabPage3.Controls.Add(Me.txtTime)
        Me.TabPage3.Controls.Add(Me.fgSch)
        Me.TabPage3.Controls.Add(Me.cboDeviceSch)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(624, 384)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Device Schedule"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnDeleteSch
        '
        Me.btnDeleteSch.BackColor = System.Drawing.Color.MintCream
        Me.btnDeleteSch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteSch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteSch.Image = CType(resources.GetObject("btnDeleteSch.Image"), System.Drawing.Image)
        Me.btnDeleteSch.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDeleteSch.Location = New System.Drawing.Point(314, 35)
        Me.btnDeleteSch.Name = "btnDeleteSch"
        Me.btnDeleteSch.Size = New System.Drawing.Size(75, 48)
        Me.btnDeleteSch.TabIndex = 238
        Me.btnDeleteSch.Text = "Delete"
        Me.btnDeleteSch.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDeleteSch.UseVisualStyleBackColor = False
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(278, 13)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(50, 20)
        Me.txtID.TabIndex = 237
        Me.txtID.Visible = False
        '
        'btnSaveSch
        '
        Me.btnSaveSch.BackColor = System.Drawing.Color.MintCream
        Me.btnSaveSch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveSch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveSch.Image = CType(resources.GetObject("btnSaveSch.Image"), System.Drawing.Image)
        Me.btnSaveSch.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveSch.Location = New System.Drawing.Point(233, 35)
        Me.btnSaveSch.Name = "btnSaveSch"
        Me.btnSaveSch.Size = New System.Drawing.Size(75, 48)
        Me.btnSaveSch.TabIndex = 236
        Me.btnSaveSch.Text = "Save"
        Me.btnSaveSch.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveSch.UseVisualStyleBackColor = False
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(107, 31)
        Me.txtTime.Mask = "90:00"
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(46, 21)
        Me.txtTime.TabIndex = 235
        Me.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTime.ValidatingType = GetType(Date)
        '
        'fgSch
        '
        Me.fgSch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fgSch.ColumnInfo = "10,1,0,0,0,95,Columns:"
        Me.fgSch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fgSch.Location = New System.Drawing.Point(6, 89)
        Me.fgSch.Name = "fgSch"
        Me.fgSch.Rows.DefaultSize = 19
        Me.fgSch.Size = New System.Drawing.Size(612, 289)
        Me.fgSch.TabIndex = 170
        '
        'cboDeviceSch
        '
        Me.cboDeviceSch.FormattingEnabled = True
        Me.cboDeviceSch.Location = New System.Drawing.Point(107, 6)
        Me.cboDeviceSch.Name = "cboDeviceSch"
        Me.cboDeviceSch.Size = New System.Drawing.Size(165, 23)
        Me.cboDeviceSch.TabIndex = 169
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 168
        Me.Label12.Text = "Shedule Time"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 163
        Me.Label11.Text = "Device Name"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnCancelDevice)
        Me.Panel3.Controls.Add(Me.btnDeleteDevice)
        Me.Panel3.Controls.Add(Me.btnCloseDevice)
        Me.Panel3.Controls.Add(Me.btnSaveDevice)
        Me.Panel3.Controls.Add(Me.btnEditDevice)
        Me.Panel3.Controls.Add(Me.btnAddDevice)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 470)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(654, 51)
        Me.Panel3.TabIndex = 2
        '
        'btnCancelDevice
        '
        Me.btnCancelDevice.BackColor = System.Drawing.Color.MintCream
        Me.btnCancelDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelDevice.Image = CType(resources.GetObject("btnCancelDevice.Image"), System.Drawing.Image)
        Me.btnCancelDevice.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelDevice.Location = New System.Drawing.Point(410, 2)
        Me.btnCancelDevice.Name = "btnCancelDevice"
        Me.btnCancelDevice.Size = New System.Drawing.Size(75, 48)
        Me.btnCancelDevice.TabIndex = 233
        Me.btnCancelDevice.Text = "Cancel"
        Me.btnCancelDevice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelDevice.UseVisualStyleBackColor = False
        '
        'btnDeleteDevice
        '
        Me.btnDeleteDevice.BackColor = System.Drawing.Color.MintCream
        Me.btnDeleteDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteDevice.Image = CType(resources.GetObject("btnDeleteDevice.Image"), System.Drawing.Image)
        Me.btnDeleteDevice.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDeleteDevice.Location = New System.Drawing.Point(329, 2)
        Me.btnDeleteDevice.Name = "btnDeleteDevice"
        Me.btnDeleteDevice.Size = New System.Drawing.Size(75, 48)
        Me.btnDeleteDevice.TabIndex = 232
        Me.btnDeleteDevice.Text = "Delete"
        Me.btnDeleteDevice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDeleteDevice.UseVisualStyleBackColor = False
        '
        'btnCloseDevice
        '
        Me.btnCloseDevice.BackColor = System.Drawing.Color.MintCream
        Me.btnCloseDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseDevice.Image = CType(resources.GetObject("btnCloseDevice.Image"), System.Drawing.Image)
        Me.btnCloseDevice.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCloseDevice.Location = New System.Drawing.Point(491, 2)
        Me.btnCloseDevice.Name = "btnCloseDevice"
        Me.btnCloseDevice.Size = New System.Drawing.Size(75, 48)
        Me.btnCloseDevice.TabIndex = 231
        Me.btnCloseDevice.Text = "Close"
        Me.btnCloseDevice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCloseDevice.UseVisualStyleBackColor = False
        '
        'btnSaveDevice
        '
        Me.btnSaveDevice.BackColor = System.Drawing.Color.MintCream
        Me.btnSaveDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveDevice.Image = CType(resources.GetObject("btnSaveDevice.Image"), System.Drawing.Image)
        Me.btnSaveDevice.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveDevice.Location = New System.Drawing.Point(248, 2)
        Me.btnSaveDevice.Name = "btnSaveDevice"
        Me.btnSaveDevice.Size = New System.Drawing.Size(75, 48)
        Me.btnSaveDevice.TabIndex = 230
        Me.btnSaveDevice.Text = "Save"
        Me.btnSaveDevice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveDevice.UseVisualStyleBackColor = False
        '
        'btnEditDevice
        '
        Me.btnEditDevice.BackColor = System.Drawing.Color.MintCream
        Me.btnEditDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditDevice.Image = CType(resources.GetObject("btnEditDevice.Image"), System.Drawing.Image)
        Me.btnEditDevice.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEditDevice.Location = New System.Drawing.Point(170, 2)
        Me.btnEditDevice.Name = "btnEditDevice"
        Me.btnEditDevice.Size = New System.Drawing.Size(75, 48)
        Me.btnEditDevice.TabIndex = 229
        Me.btnEditDevice.Text = "Edit"
        Me.btnEditDevice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEditDevice.UseVisualStyleBackColor = False
        '
        'btnAddDevice
        '
        Me.btnAddDevice.BackColor = System.Drawing.Color.MintCream
        Me.btnAddDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddDevice.Image = CType(resources.GetObject("btnAddDevice.Image"), System.Drawing.Image)
        Me.btnAddDevice.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddDevice.Location = New System.Drawing.Point(89, 2)
        Me.btnAddDevice.Name = "btnAddDevice"
        Me.btnAddDevice.Size = New System.Drawing.Size(75, 48)
        Me.btnAddDevice.TabIndex = 228
        Me.btnAddDevice.Text = "Add"
        Me.btnAddDevice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddDevice.UseVisualStyleBackColor = False
        '
        'rdSeviceSTI
        '
        Me.rdSeviceSTI.AutoSize = True
        Me.rdSeviceSTI.Checked = True
        Me.rdSeviceSTI.Location = New System.Drawing.Point(17, 64)
        Me.rdSeviceSTI.Name = "rdSeviceSTI"
        Me.rdSeviceSTI.Size = New System.Drawing.Size(97, 19)
        Me.rdSeviceSTI.TabIndex = 239
        Me.rdSeviceSTI.TabStop = True
        Me.rdSeviceSTI.Text = "Sevice Di STI"
        Me.rdSeviceSTI.UseVisualStyleBackColor = True
        '
        'rdServicePSG
        '
        Me.rdServicePSG.AutoSize = True
        Me.rdServicePSG.Location = New System.Drawing.Point(122, 64)
        Me.rdServicePSG.Name = "rdServicePSG"
        Me.rdServicePSG.Size = New System.Drawing.Size(108, 19)
        Me.rdServicePSG.TabIndex = 240
        Me.rdServicePSG.Text = "Service Di PSG"
        Me.rdServicePSG.UseVisualStyleBackColor = True
        '
        'FrmMstDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 567)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmMstDevice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Device"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.fgDeviceList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.fgSch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnKonek As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cboDevice As ComboBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents fgDeviceList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents txtBaudRate As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtComPort As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtIPAddress As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboConectionType As ComboBox
    Friend WithEvents txtDeviceName As TextBox
    Friend WithEvents txtDeviceID As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnSetDevTime4 As Button
    Friend WithEvents btnSetDevTime3 As Button
    Friend WithEvents btnSetDevTime2 As Button
    Friend WithEvents btnGetDevTime2 As Button
    Friend WithEvents dtDeviceTime As DateTimePicker
    Friend WithEvents btnSetDevTime1 As Button
    Friend WithEvents btnGetDevTime1 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtDeviceTime As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnCancelDevice As Button
    Friend WithEvents btnDeleteDevice As Button
    Friend WithEvents btnCloseDevice As Button
    Friend WithEvents btnSaveDevice As Button
    Friend WithEvents btnEditDevice As Button
    Friend WithEvents btnAddDevice As Button
    Friend WithEvents fgSch As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cboDeviceSch As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTime As MaskedTextBox
    Friend WithEvents btnSaveSch As Button
    Friend WithEvents txtID As TextBox
    Friend WithEvents btnDeleteSch As Button
    Friend WithEvents rdServicePSG As RadioButton
    Friend WithEvents rdSeviceSTI As RadioButton
End Class
