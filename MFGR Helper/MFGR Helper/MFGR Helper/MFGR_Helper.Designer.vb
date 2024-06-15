<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MFGR_Helper
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MFGR_Helper))
        Me.TxtTestBox2 = New System.Windows.Forms.TextBox()
        Me.ChkViewCLI = New System.Windows.Forms.CheckBox()
        Me.LblPsocHexFileName = New System.Windows.Forms.Label()
        Me.txtPsocHexFileName = New System.Windows.Forms.TextBox()
        Me.TxtTestBox = New System.Windows.Forms.TextBox()
        Me.ChkDebug = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PicPassFail = New System.Windows.Forms.PictureBox()
        Me.PicElectroseaLogo = New System.Windows.Forms.PictureBox()
        Me.ProgramProgressBar = New System.Windows.Forms.ProgressBar()
        Me.LblOutput = New System.Windows.Forms.Label()
        Me.TxtOutput = New System.Windows.Forms.TextBox()
        Me.ChkDeadtimeSec = New System.Windows.Forms.CheckBox()
        Me.ChkInputGPM = New System.Windows.Forms.CheckBox()
        Me.ChkGPMOverride = New System.Windows.Forms.CheckBox()
        Me.txtGPMOverride = New System.Windows.Forms.TextBox()
        Me.txtInputGPM = New System.Windows.Forms.TextBox()
        Me.txtDeadtimeSec = New System.Windows.Forms.TextBox()
        Me.txtReverseOffSec = New System.Windows.Forms.TextBox()
        Me.txtReverseOnSec = New System.Windows.Forms.TextBox()
        Me.ChkReverseOnSec = New System.Windows.Forms.CheckBox()
        Me.ChkReverseOffSec = New System.Windows.Forms.CheckBox()
        Me.ChkBacklight = New System.Windows.Forms.CheckBox()
        Me.ChkForwardOnSec = New System.Windows.Forms.CheckBox()
        Me.ChkForwardOffSec = New System.Windows.Forms.CheckBox()
        Me.txtForwardOffSec = New System.Windows.Forms.TextBox()
        Me.txtForwardOnSec = New System.Windows.Forms.TextBox()
        Me.txtBacklight = New System.Windows.Forms.TextBox()
        Me.txtContrast = New System.Windows.Forms.TextBox()
        Me.txtCellDelay1 = New System.Windows.Forms.TextBox()
        Me.txtPumpTime = New System.Windows.Forms.TextBox()
        Me.txtPumpMode = New System.Windows.Forms.TextBox()
        Me.txtOutputLevel = New System.Windows.Forms.TextBox()
        Me.BtnProgram = New System.Windows.Forms.Button()
        Me.lblAtmelHexFileName = New System.Windows.Forms.Label()
        Me.lblSerialCode = New System.Windows.Forms.Label()
        Me.ChkPumpMode = New System.Windows.Forms.CheckBox()
        Me.ChkPumpTime = New System.Windows.Forms.CheckBox()
        Me.ChkCellDelay1 = New System.Windows.Forms.CheckBox()
        Me.ChkContrast = New System.Windows.Forms.CheckBox()
        Me.ChkOutputLevel = New System.Windows.Forms.CheckBox()
        Me.txtAtmelHexFileName = New System.Windows.Forms.TextBox()
        Me.txtSerialCode = New System.Windows.Forms.TextBox()
        Me.Mnu = New System.Windows.Forms.MenuStrip()
        Me.MnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSaveSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.Divider1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAdminSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScannerPort = New System.IO.Ports.SerialPort(Me.components)
        Me.t = New System.Windows.Forms.Timer(Me.components)
        Me.Atmel_bgw = New System.ComponentModel.BackgroundWorker()
        Me.Psoc_bgw = New System.ComponentModel.BackgroundWorker()
        Me.LblDebugOutput = New System.Windows.Forms.Label()
        CType(Me.PicPassFail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicElectroseaLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Mnu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtTestBox2
        '
        Me.TxtTestBox2.Location = New System.Drawing.Point(820, 91)
        Me.TxtTestBox2.Multiline = True
        Me.TxtTestBox2.Name = "TxtTestBox2"
        Me.TxtTestBox2.Size = New System.Drawing.Size(241, 78)
        Me.TxtTestBox2.TabIndex = 165
        '
        'ChkViewCLI
        '
        Me.ChkViewCLI.AutoSize = True
        Me.ChkViewCLI.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkViewCLI.Location = New System.Drawing.Point(726, 49)
        Me.ChkViewCLI.Name = "ChkViewCLI"
        Me.ChkViewCLI.Size = New System.Drawing.Size(89, 17)
        Me.ChkViewCLI.TabIndex = 164
        Me.ChkViewCLI.Text = "View CLI exe"
        Me.ChkViewCLI.UseVisualStyleBackColor = True
        '
        'LblPsocHexFileName
        '
        Me.LblPsocHexFileName.AutoSize = True
        Me.LblPsocHexFileName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPsocHexFileName.Location = New System.Drawing.Point(248, 78)
        Me.LblPsocHexFileName.Name = "LblPsocHexFileName"
        Me.LblPsocHexFileName.Size = New System.Drawing.Size(111, 15)
        Me.LblPsocHexFileName.TabIndex = 163
        Me.LblPsocHexFileName.Text = "Psoc Hex File Name"
        '
        'txtPsocHexFileName
        '
        Me.txtPsocHexFileName.Location = New System.Drawing.Point(251, 94)
        Me.txtPsocHexFileName.Name = "txtPsocHexFileName"
        Me.txtPsocHexFileName.ReadOnly = True
        Me.txtPsocHexFileName.Size = New System.Drawing.Size(181, 20)
        Me.txtPsocHexFileName.TabIndex = 162
        '
        'TxtTestBox
        '
        Me.TxtTestBox.Location = New System.Drawing.Point(820, 175)
        Me.TxtTestBox.Multiline = True
        Me.TxtTestBox.Name = "TxtTestBox"
        Me.TxtTestBox.Size = New System.Drawing.Size(241, 218)
        Me.TxtTestBox.TabIndex = 161
        '
        'ChkDebug
        '
        Me.ChkDebug.AutoSize = True
        Me.ChkDebug.Checked = True
        Me.ChkDebug.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkDebug.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkDebug.Location = New System.Drawing.Point(756, 27)
        Me.ChkDebug.Name = "ChkDebug"
        Me.ChkDebug.Size = New System.Drawing.Size(61, 17)
        Me.ChkDebug.TabIndex = 160
        Me.ChkDebug.Text = "Debug"
        Me.ChkDebug.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(124, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "Lock"
        '
        'PicPassFail
        '
        Me.PicPassFail.ErrorImage = CType(resources.GetObject("PicPassFail.ErrorImage"), System.Drawing.Image)
        Me.PicPassFail.Image = CType(resources.GetObject("PicPassFail.Image"), System.Drawing.Image)
        Me.PicPassFail.InitialImage = CType(resources.GetObject("PicPassFail.InitialImage"), System.Drawing.Image)
        Me.PicPassFail.Location = New System.Drawing.Point(590, 94)
        Me.PicPassFail.Name = "PicPassFail"
        Me.PicPassFail.Size = New System.Drawing.Size(60, 60)
        Me.PicPassFail.TabIndex = 158
        Me.PicPassFail.TabStop = False
        '
        'PicElectroseaLogo
        '
        Me.PicElectroseaLogo.Location = New System.Drawing.Point(820, 27)
        Me.PicElectroseaLogo.Name = "PicElectroseaLogo"
        Me.PicElectroseaLogo.Size = New System.Drawing.Size(100, 50)
        Me.PicElectroseaLogo.TabIndex = 157
        Me.PicElectroseaLogo.TabStop = False
        '
        'ProgramProgressBar
        '
        Me.ProgramProgressBar.ForeColor = System.Drawing.Color.Aqua
        Me.ProgramProgressBar.Location = New System.Drawing.Point(438, 143)
        Me.ProgramProgressBar.MarqueeAnimationSpeed = 10000
        Me.ProgramProgressBar.Maximum = 10000
        Me.ProgramProgressBar.Name = "ProgramProgressBar"
        Me.ProgramProgressBar.Size = New System.Drawing.Size(146, 10)
        Me.ProgramProgressBar.Step = 1
        Me.ProgramProgressBar.TabIndex = 154
        '
        'LblOutput
        '
        Me.LblOutput.AutoSize = True
        Me.LblOutput.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOutput.Location = New System.Drawing.Point(248, 159)
        Me.LblOutput.Name = "LblOutput"
        Me.LblOutput.Size = New System.Drawing.Size(45, 13)
        Me.LblOutput.TabIndex = 156
        Me.LblOutput.Text = "Output"
        '
        'TxtOutput
        '
        Me.TxtOutput.Location = New System.Drawing.Point(251, 175)
        Me.TxtOutput.Multiline = True
        Me.TxtOutput.Name = "TxtOutput"
        Me.TxtOutput.Size = New System.Drawing.Size(554, 217)
        Me.TxtOutput.TabIndex = 155
        '
        'ChkDeadtimeSec
        '
        Me.ChkDeadtimeSec.AutoSize = True
        Me.ChkDeadtimeSec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkDeadtimeSec.Checked = True
        Me.ChkDeadtimeSec.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkDeadtimeSec.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkDeadtimeSec.Location = New System.Drawing.Point(38, 371)
        Me.ChkDeadtimeSec.Name = "ChkDeadtimeSec"
        Me.ChkDeadtimeSec.Size = New System.Drawing.Size(108, 19)
        Me.ChkDeadtimeSec.TabIndex = 153
        Me.ChkDeadtimeSec.Text = "DEADTIME_SEC"
        Me.ChkDeadtimeSec.UseVisualStyleBackColor = True
        '
        'ChkInputGPM
        '
        Me.ChkInputGPM.AutoSize = True
        Me.ChkInputGPM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkInputGPM.Checked = True
        Me.ChkInputGPM.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkInputGPM.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkInputGPM.Location = New System.Drawing.Point(55, 84)
        Me.ChkInputGPM.Name = "ChkInputGPM"
        Me.ChkInputGPM.Size = New System.Drawing.Size(91, 19)
        Me.ChkInputGPM.TabIndex = 152
        Me.ChkInputGPM.Text = "INPUT_GPM"
        Me.ChkInputGPM.UseVisualStyleBackColor = True
        '
        'ChkGPMOverride
        '
        Me.ChkGPMOverride.AutoSize = True
        Me.ChkGPMOverride.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkGPMOverride.Checked = True
        Me.ChkGPMOverride.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkGPMOverride.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkGPMOverride.Location = New System.Drawing.Point(36, 293)
        Me.ChkGPMOverride.Name = "ChkGPMOverride"
        Me.ChkGPMOverride.Size = New System.Drawing.Size(110, 19)
        Me.ChkGPMOverride.TabIndex = 151
        Me.ChkGPMOverride.Text = "GPM_OVERRIDE"
        Me.ChkGPMOverride.UseVisualStyleBackColor = True
        '
        'txtGPMOverride
        '
        Me.txtGPMOverride.Location = New System.Drawing.Point(152, 292)
        Me.txtGPMOverride.MaxLength = 3
        Me.txtGPMOverride.Name = "txtGPMOverride"
        Me.txtGPMOverride.ReadOnly = True
        Me.txtGPMOverride.Size = New System.Drawing.Size(68, 20)
        Me.txtGPMOverride.TabIndex = 150
        '
        'txtInputGPM
        '
        Me.txtInputGPM.Location = New System.Drawing.Point(152, 83)
        Me.txtInputGPM.MaxLength = 3
        Me.txtInputGPM.Name = "txtInputGPM"
        Me.txtInputGPM.ReadOnly = True
        Me.txtInputGPM.Size = New System.Drawing.Size(68, 20)
        Me.txtInputGPM.TabIndex = 149
        '
        'txtDeadtimeSec
        '
        Me.txtDeadtimeSec.Location = New System.Drawing.Point(152, 370)
        Me.txtDeadtimeSec.MaxLength = 3
        Me.txtDeadtimeSec.Name = "txtDeadtimeSec"
        Me.txtDeadtimeSec.ReadOnly = True
        Me.txtDeadtimeSec.Size = New System.Drawing.Size(68, 20)
        Me.txtDeadtimeSec.TabIndex = 148
        '
        'txtReverseOffSec
        '
        Me.txtReverseOffSec.Location = New System.Drawing.Point(152, 344)
        Me.txtReverseOffSec.MaxLength = 5
        Me.txtReverseOffSec.Name = "txtReverseOffSec"
        Me.txtReverseOffSec.ReadOnly = True
        Me.txtReverseOffSec.Size = New System.Drawing.Size(68, 20)
        Me.txtReverseOffSec.TabIndex = 147
        '
        'txtReverseOnSec
        '
        Me.txtReverseOnSec.Location = New System.Drawing.Point(152, 213)
        Me.txtReverseOnSec.MaxLength = 5
        Me.txtReverseOnSec.Name = "txtReverseOnSec"
        Me.txtReverseOnSec.ReadOnly = True
        Me.txtReverseOnSec.Size = New System.Drawing.Size(68, 20)
        Me.txtReverseOnSec.TabIndex = 146
        '
        'ChkReverseOnSec
        '
        Me.ChkReverseOnSec.AutoSize = True
        Me.ChkReverseOnSec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkReverseOnSec.Checked = True
        Me.ChkReverseOnSec.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkReverseOnSec.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkReverseOnSec.Location = New System.Drawing.Point(27, 214)
        Me.ChkReverseOnSec.Name = "ChkReverseOnSec"
        Me.ChkReverseOnSec.Size = New System.Drawing.Size(119, 19)
        Me.ChkReverseOnSec.TabIndex = 145
        Me.ChkReverseOnSec.Text = "REVERSE_ON_SEC"
        Me.ChkReverseOnSec.UseVisualStyleBackColor = True
        '
        'ChkReverseOffSec
        '
        Me.ChkReverseOffSec.AutoSize = True
        Me.ChkReverseOffSec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkReverseOffSec.Checked = True
        Me.ChkReverseOffSec.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkReverseOffSec.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkReverseOffSec.Location = New System.Drawing.Point(24, 345)
        Me.ChkReverseOffSec.Name = "ChkReverseOffSec"
        Me.ChkReverseOffSec.Size = New System.Drawing.Size(122, 19)
        Me.ChkReverseOffSec.TabIndex = 144
        Me.ChkReverseOffSec.Text = "REVERSE_OFF_SEC"
        Me.ChkReverseOffSec.UseVisualStyleBackColor = True
        '
        'ChkBacklight
        '
        Me.ChkBacklight.AutoSize = True
        Me.ChkBacklight.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkBacklight.Checked = True
        Me.ChkBacklight.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBacklight.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBacklight.Location = New System.Drawing.Point(57, 267)
        Me.ChkBacklight.Name = "ChkBacklight"
        Me.ChkBacklight.Size = New System.Drawing.Size(89, 19)
        Me.ChkBacklight.TabIndex = 143
        Me.ChkBacklight.Text = "BACKLIGHT"
        Me.ChkBacklight.UseVisualStyleBackColor = True
        '
        'ChkForwardOnSec
        '
        Me.ChkForwardOnSec.AutoSize = True
        Me.ChkForwardOnSec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkForwardOnSec.Checked = True
        Me.ChkForwardOnSec.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkForwardOnSec.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkForwardOnSec.Location = New System.Drawing.Point(16, 188)
        Me.ChkForwardOnSec.Name = "ChkForwardOnSec"
        Me.ChkForwardOnSec.Size = New System.Drawing.Size(130, 19)
        Me.ChkForwardOnSec.TabIndex = 142
        Me.ChkForwardOnSec.Text = "FORWARD_ON_SEC"
        Me.ChkForwardOnSec.UseVisualStyleBackColor = True
        '
        'ChkForwardOffSec
        '
        Me.ChkForwardOffSec.AutoSize = True
        Me.ChkForwardOffSec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkForwardOffSec.Checked = True
        Me.ChkForwardOffSec.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkForwardOffSec.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkForwardOffSec.Location = New System.Drawing.Point(13, 319)
        Me.ChkForwardOffSec.Name = "ChkForwardOffSec"
        Me.ChkForwardOffSec.Size = New System.Drawing.Size(133, 19)
        Me.ChkForwardOffSec.TabIndex = 141
        Me.ChkForwardOffSec.Text = "FORWARD_OFF_SEC"
        Me.ChkForwardOffSec.UseVisualStyleBackColor = True
        '
        'txtForwardOffSec
        '
        Me.txtForwardOffSec.Location = New System.Drawing.Point(152, 318)
        Me.txtForwardOffSec.MaxLength = 5
        Me.txtForwardOffSec.Name = "txtForwardOffSec"
        Me.txtForwardOffSec.ReadOnly = True
        Me.txtForwardOffSec.Size = New System.Drawing.Size(68, 20)
        Me.txtForwardOffSec.TabIndex = 140
        '
        'txtForwardOnSec
        '
        Me.txtForwardOnSec.Location = New System.Drawing.Point(152, 187)
        Me.txtForwardOnSec.MaxLength = 5
        Me.txtForwardOnSec.Name = "txtForwardOnSec"
        Me.txtForwardOnSec.ReadOnly = True
        Me.txtForwardOnSec.Size = New System.Drawing.Size(68, 20)
        Me.txtForwardOnSec.TabIndex = 139
        '
        'txtBacklight
        '
        Me.txtBacklight.Location = New System.Drawing.Point(152, 266)
        Me.txtBacklight.MaxLength = 3
        Me.txtBacklight.Name = "txtBacklight"
        Me.txtBacklight.ReadOnly = True
        Me.txtBacklight.Size = New System.Drawing.Size(68, 20)
        Me.txtBacklight.TabIndex = 138
        '
        'txtContrast
        '
        Me.txtContrast.Location = New System.Drawing.Point(152, 239)
        Me.txtContrast.MaxLength = 3
        Me.txtContrast.Name = "txtContrast"
        Me.txtContrast.ReadOnly = True
        Me.txtContrast.Size = New System.Drawing.Size(68, 20)
        Me.txtContrast.TabIndex = 137
        '
        'txtCellDelay1
        '
        Me.txtCellDelay1.Location = New System.Drawing.Point(152, 159)
        Me.txtCellDelay1.MaxLength = 5
        Me.txtCellDelay1.Name = "txtCellDelay1"
        Me.txtCellDelay1.ReadOnly = True
        Me.txtCellDelay1.Size = New System.Drawing.Size(68, 20)
        Me.txtCellDelay1.TabIndex = 136
        '
        'txtPumpTime
        '
        Me.txtPumpTime.Location = New System.Drawing.Point(152, 133)
        Me.txtPumpTime.MaxLength = 3
        Me.txtPumpTime.Name = "txtPumpTime"
        Me.txtPumpTime.ReadOnly = True
        Me.txtPumpTime.Size = New System.Drawing.Size(68, 20)
        Me.txtPumpTime.TabIndex = 135
        '
        'txtPumpMode
        '
        Me.txtPumpMode.Location = New System.Drawing.Point(152, 107)
        Me.txtPumpMode.MaxLength = 3
        Me.txtPumpMode.Name = "txtPumpMode"
        Me.txtPumpMode.ReadOnly = True
        Me.txtPumpMode.Size = New System.Drawing.Size(68, 20)
        Me.txtPumpMode.TabIndex = 134
        '
        'txtOutputLevel
        '
        Me.txtOutputLevel.Location = New System.Drawing.Point(152, 58)
        Me.txtOutputLevel.MaxLength = 3
        Me.txtOutputLevel.Name = "txtOutputLevel"
        Me.txtOutputLevel.ReadOnly = True
        Me.txtOutputLevel.Size = New System.Drawing.Size(68, 20)
        Me.txtOutputLevel.TabIndex = 133
        '
        'BtnProgram
        '
        Me.BtnProgram.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProgram.Location = New System.Drawing.Point(438, 94)
        Me.BtnProgram.Name = "BtnProgram"
        Me.BtnProgram.Size = New System.Drawing.Size(146, 46)
        Me.BtnProgram.TabIndex = 132
        Me.BtnProgram.Text = "Program"
        Me.BtnProgram.UseVisualStyleBackColor = True
        '
        'lblAtmelHexFileName
        '
        Me.lblAtmelHexFileName.AutoSize = True
        Me.lblAtmelHexFileName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtmelHexFileName.Location = New System.Drawing.Point(248, 39)
        Me.lblAtmelHexFileName.Name = "lblAtmelHexFileName"
        Me.lblAtmelHexFileName.Size = New System.Drawing.Size(118, 15)
        Me.lblAtmelHexFileName.TabIndex = 131
        Me.lblAtmelHexFileName.Text = "Atmel Hex File Name"
        '
        'lblSerialCode
        '
        Me.lblSerialCode.AutoSize = True
        Me.lblSerialCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialCode.Location = New System.Drawing.Point(248, 117)
        Me.lblSerialCode.Name = "lblSerialCode"
        Me.lblSerialCode.Size = New System.Drawing.Size(65, 13)
        Me.lblSerialCode.TabIndex = 130
        Me.lblSerialCode.Text = "Serial Code"
        '
        'ChkPumpMode
        '
        Me.ChkPumpMode.AutoSize = True
        Me.ChkPumpMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPumpMode.Checked = True
        Me.ChkPumpMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPumpMode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPumpMode.Location = New System.Drawing.Point(48, 108)
        Me.ChkPumpMode.Name = "ChkPumpMode"
        Me.ChkPumpMode.Size = New System.Drawing.Size(98, 19)
        Me.ChkPumpMode.TabIndex = 129
        Me.ChkPumpMode.Text = "PUMP_MODE"
        Me.ChkPumpMode.UseVisualStyleBackColor = True
        '
        'ChkPumpTime
        '
        Me.ChkPumpTime.AutoSize = True
        Me.ChkPumpTime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPumpTime.Checked = True
        Me.ChkPumpTime.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPumpTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPumpTime.Location = New System.Drawing.Point(55, 134)
        Me.ChkPumpTime.Name = "ChkPumpTime"
        Me.ChkPumpTime.Size = New System.Drawing.Size(91, 19)
        Me.ChkPumpTime.TabIndex = 128
        Me.ChkPumpTime.Text = "PUMP_TIME"
        Me.ChkPumpTime.UseVisualStyleBackColor = True
        '
        'ChkCellDelay1
        '
        Me.ChkCellDelay1.AutoSize = True
        Me.ChkCellDelay1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkCellDelay1.Checked = True
        Me.ChkCellDelay1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCellDelay1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkCellDelay1.Location = New System.Drawing.Point(48, 162)
        Me.ChkCellDelay1.Name = "ChkCellDelay1"
        Me.ChkCellDelay1.Size = New System.Drawing.Size(98, 19)
        Me.ChkCellDelay1.TabIndex = 127
        Me.ChkCellDelay1.Text = "CELL_DELAY1"
        Me.ChkCellDelay1.UseVisualStyleBackColor = True
        '
        'ChkContrast
        '
        Me.ChkContrast.AutoSize = True
        Me.ChkContrast.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkContrast.Checked = True
        Me.ChkContrast.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkContrast.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkContrast.Location = New System.Drawing.Point(59, 241)
        Me.ChkContrast.Name = "ChkContrast"
        Me.ChkContrast.Size = New System.Drawing.Size(87, 19)
        Me.ChkContrast.TabIndex = 126
        Me.ChkContrast.Text = "CONTRAST"
        Me.ChkContrast.UseVisualStyleBackColor = True
        '
        'ChkOutputLevel
        '
        Me.ChkOutputLevel.AutoSize = True
        Me.ChkOutputLevel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkOutputLevel.Checked = True
        Me.ChkOutputLevel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkOutputLevel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkOutputLevel.Location = New System.Drawing.Point(38, 61)
        Me.ChkOutputLevel.Name = "ChkOutputLevel"
        Me.ChkOutputLevel.Size = New System.Drawing.Size(108, 19)
        Me.ChkOutputLevel.TabIndex = 125
        Me.ChkOutputLevel.Text = "OUTPUT_LEVEL"
        Me.ChkOutputLevel.UseVisualStyleBackColor = True
        '
        'txtAtmelHexFileName
        '
        Me.txtAtmelHexFileName.Location = New System.Drawing.Point(251, 55)
        Me.txtAtmelHexFileName.Name = "txtAtmelHexFileName"
        Me.txtAtmelHexFileName.ReadOnly = True
        Me.txtAtmelHexFileName.Size = New System.Drawing.Size(181, 20)
        Me.txtAtmelHexFileName.TabIndex = 124
        '
        'txtSerialCode
        '
        Me.txtSerialCode.Location = New System.Drawing.Point(251, 133)
        Me.txtSerialCode.Name = "txtSerialCode"
        Me.txtSerialCode.ReadOnly = True
        Me.txtSerialCode.Size = New System.Drawing.Size(181, 20)
        Me.txtSerialCode.TabIndex = 123
        '
        'Mnu
        '
        Me.Mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFile, Me.MnuOptions})
        Me.Mnu.Location = New System.Drawing.Point(0, 0)
        Me.Mnu.Name = "Mnu"
        Me.Mnu.Size = New System.Drawing.Size(1084, 24)
        Me.Mnu.TabIndex = 122
        Me.Mnu.Text = "MenuStrip1"
        '
        'MnuFile
        '
        Me.MnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSaveSettings, Me.MnuReload, Me.Divider1, Me.MnuExit})
        Me.MnuFile.Name = "MnuFile"
        Me.MnuFile.Size = New System.Drawing.Size(37, 20)
        Me.MnuFile.Text = "File"
        '
        'MnuSaveSettings
        '
        Me.MnuSaveSettings.Name = "MnuSaveSettings"
        Me.MnuSaveSettings.Size = New System.Drawing.Size(181, 22)
        Me.MnuSaveSettings.Text = "Save Settings"
        '
        'MnuReload
        '
        Me.MnuReload.Name = "MnuReload"
        Me.MnuReload.Size = New System.Drawing.Size(181, 22)
        Me.MnuReload.Text = "Reload Saved Values"
        '
        'Divider1
        '
        Me.Divider1.Name = "Divider1"
        Me.Divider1.Size = New System.Drawing.Size(178, 6)
        '
        'MnuExit
        '
        Me.MnuExit.Name = "MnuExit"
        Me.MnuExit.Size = New System.Drawing.Size(181, 22)
        Me.MnuExit.Text = "Exit"
        '
        'MnuOptions
        '
        Me.MnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAdminSettings})
        Me.MnuOptions.Name = "MnuOptions"
        Me.MnuOptions.Size = New System.Drawing.Size(61, 20)
        Me.MnuOptions.Text = "Options"
        '
        'MnuAdminSettings
        '
        Me.MnuAdminSettings.Name = "MnuAdminSettings"
        Me.MnuAdminSettings.Size = New System.Drawing.Size(180, 22)
        Me.MnuAdminSettings.Text = "Admin Settings"
        '
        'ScannerPort
        '
        Me.ScannerPort.PortName = "COM8"
        '
        't
        '
        '
        'Atmel_bgw
        '
        '
        'Psoc_bgw
        '
        '
        'LblDebugOutput
        '
        Me.LblDebugOutput.AutoSize = True
        Me.LblDebugOutput.Location = New System.Drawing.Point(987, 75)
        Me.LblDebugOutput.Name = "LblDebugOutput"
        Me.LblDebugOutput.Size = New System.Drawing.Size(74, 13)
        Me.LblDebugOutput.TabIndex = 166
        Me.LblDebugOutput.Text = "Debug Output"
        '
        'MFGR_Helper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 462)
        Me.Controls.Add(Me.LblDebugOutput)
        Me.Controls.Add(Me.TxtTestBox2)
        Me.Controls.Add(Me.ChkViewCLI)
        Me.Controls.Add(Me.LblPsocHexFileName)
        Me.Controls.Add(Me.txtPsocHexFileName)
        Me.Controls.Add(Me.TxtTestBox)
        Me.Controls.Add(Me.ChkDebug)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PicPassFail)
        Me.Controls.Add(Me.PicElectroseaLogo)
        Me.Controls.Add(Me.ProgramProgressBar)
        Me.Controls.Add(Me.LblOutput)
        Me.Controls.Add(Me.TxtOutput)
        Me.Controls.Add(Me.ChkDeadtimeSec)
        Me.Controls.Add(Me.ChkInputGPM)
        Me.Controls.Add(Me.ChkGPMOverride)
        Me.Controls.Add(Me.txtGPMOverride)
        Me.Controls.Add(Me.txtInputGPM)
        Me.Controls.Add(Me.txtDeadtimeSec)
        Me.Controls.Add(Me.txtReverseOffSec)
        Me.Controls.Add(Me.txtReverseOnSec)
        Me.Controls.Add(Me.ChkReverseOnSec)
        Me.Controls.Add(Me.ChkReverseOffSec)
        Me.Controls.Add(Me.ChkBacklight)
        Me.Controls.Add(Me.ChkForwardOnSec)
        Me.Controls.Add(Me.ChkForwardOffSec)
        Me.Controls.Add(Me.txtForwardOffSec)
        Me.Controls.Add(Me.txtForwardOnSec)
        Me.Controls.Add(Me.txtBacklight)
        Me.Controls.Add(Me.txtContrast)
        Me.Controls.Add(Me.txtCellDelay1)
        Me.Controls.Add(Me.txtPumpTime)
        Me.Controls.Add(Me.txtPumpMode)
        Me.Controls.Add(Me.txtOutputLevel)
        Me.Controls.Add(Me.BtnProgram)
        Me.Controls.Add(Me.lblAtmelHexFileName)
        Me.Controls.Add(Me.lblSerialCode)
        Me.Controls.Add(Me.ChkPumpMode)
        Me.Controls.Add(Me.ChkPumpTime)
        Me.Controls.Add(Me.ChkCellDelay1)
        Me.Controls.Add(Me.ChkContrast)
        Me.Controls.Add(Me.ChkOutputLevel)
        Me.Controls.Add(Me.txtAtmelHexFileName)
        Me.Controls.Add(Me.txtSerialCode)
        Me.Controls.Add(Me.Mnu)
        Me.Name = "MFGR_Helper"
        Me.Text = "MFGR Helper 1.0"
        CType(Me.PicPassFail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicElectroseaLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Mnu.ResumeLayout(False)
        Me.Mnu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtTestBox2 As TextBox
    Friend WithEvents ChkViewCLI As CheckBox
    Friend WithEvents LblPsocHexFileName As Label
    Friend WithEvents txtPsocHexFileName As TextBox
    Friend WithEvents TxtTestBox As TextBox
    Friend WithEvents ChkDebug As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PicPassFail As PictureBox
    Friend WithEvents PicElectroseaLogo As PictureBox
    Friend WithEvents ProgramProgressBar As ProgressBar
    Friend WithEvents LblOutput As Label
    Friend WithEvents TxtOutput As TextBox
    Friend WithEvents ChkDeadtimeSec As CheckBox
    Friend WithEvents ChkInputGPM As CheckBox
    Friend WithEvents ChkGPMOverride As CheckBox
    Friend WithEvents txtGPMOverride As TextBox
    Friend WithEvents txtInputGPM As TextBox
    Friend WithEvents txtDeadtimeSec As TextBox
    Friend WithEvents txtReverseOffSec As TextBox
    Friend WithEvents txtReverseOnSec As TextBox
    Friend WithEvents ChkReverseOnSec As CheckBox
    Friend WithEvents ChkReverseOffSec As CheckBox
    Friend WithEvents ChkBacklight As CheckBox
    Friend WithEvents ChkForwardOnSec As CheckBox
    Friend WithEvents ChkForwardOffSec As CheckBox
    Friend WithEvents txtForwardOffSec As TextBox
    Friend WithEvents txtForwardOnSec As TextBox
    Friend WithEvents txtBacklight As TextBox
    Friend WithEvents txtContrast As TextBox
    Friend WithEvents txtCellDelay1 As TextBox
    Friend WithEvents txtPumpTime As TextBox
    Friend WithEvents txtPumpMode As TextBox
    Friend WithEvents txtOutputLevel As TextBox
    Friend WithEvents BtnProgram As Button
    Friend WithEvents lblAtmelHexFileName As Label
    Friend WithEvents lblSerialCode As Label
    Friend WithEvents ChkPumpMode As CheckBox
    Friend WithEvents ChkPumpTime As CheckBox
    Friend WithEvents ChkCellDelay1 As CheckBox
    Friend WithEvents ChkContrast As CheckBox
    Friend WithEvents ChkOutputLevel As CheckBox
    Friend WithEvents txtAtmelHexFileName As TextBox
    Friend WithEvents txtSerialCode As TextBox
    Friend WithEvents Mnu As MenuStrip
    Friend WithEvents MnuFile As ToolStripMenuItem
    Friend WithEvents MnuSaveSettings As ToolStripMenuItem
    Friend WithEvents MnuReload As ToolStripMenuItem
    Friend WithEvents Divider1 As ToolStripSeparator
    Friend WithEvents MnuExit As ToolStripMenuItem
    Friend WithEvents MnuOptions As ToolStripMenuItem
    Friend WithEvents MnuAdminSettings As ToolStripMenuItem
    Friend WithEvents ScannerPort As IO.Ports.SerialPort
    Friend WithEvents t As Timer
    Friend WithEvents Atmel_bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents Psoc_bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents LblDebugOutput As Label
End Class
