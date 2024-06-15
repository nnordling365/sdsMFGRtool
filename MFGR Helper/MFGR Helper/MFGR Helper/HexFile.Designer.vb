<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HexConverter
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
        Me.lblSerialData = New System.Windows.Forms.Label()
        Me.txtSerialIn6 = New System.Windows.Forms.TextBox()
        Me.txtSerialIn5 = New System.Windows.Forms.TextBox()
        Me.txtSerialIn4 = New System.Windows.Forms.TextBox()
        Me.txtSerialIn3 = New System.Windows.Forms.TextBox()
        Me.txtSerialIn2 = New System.Windows.Forms.TextBox()
        Me.txtSerialIn1 = New System.Windows.Forms.TextBox()
        Me.lblHexFile = New System.Windows.Forms.Label()
        Me.txtHexOut = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuReturn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuReloadDefaultSerialData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileMenuExit3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnGenerateHex = New System.Windows.Forms.Button()
        Me.lblSerialAddress = New System.Windows.Forms.Label()
        Me.txtAddr = New System.Windows.Forms.TextBox()
        Me.BtnGeneratePsocData = New System.Windows.Forms.Button()
        Me.LblDataToHex = New System.Windows.Forms.Label()
        Me.TxtPsocData = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSerialData
        '
        Me.lblSerialData.AutoSize = True
        Me.lblSerialData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialData.Location = New System.Drawing.Point(9, 112)
        Me.lblSerialData.Name = "lblSerialData"
        Me.lblSerialData.Size = New System.Drawing.Size(62, 13)
        Me.lblSerialData.TabIndex = 98
        Me.lblSerialData.Text = "Serial Data"
        '
        'txtSerialIn6
        '
        Me.txtSerialIn6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialIn6.Location = New System.Drawing.Point(12, 258)
        Me.txtSerialIn6.MaxLength = 128
        Me.txtSerialIn6.Name = "txtSerialIn6"
        Me.txtSerialIn6.Size = New System.Drawing.Size(1008, 22)
        Me.txtSerialIn6.TabIndex = 91
        '
        'txtSerialIn5
        '
        Me.txtSerialIn5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialIn5.Location = New System.Drawing.Point(12, 232)
        Me.txtSerialIn5.MaxLength = 128
        Me.txtSerialIn5.Name = "txtSerialIn5"
        Me.txtSerialIn5.Size = New System.Drawing.Size(1008, 22)
        Me.txtSerialIn5.TabIndex = 90
        '
        'txtSerialIn4
        '
        Me.txtSerialIn4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialIn4.Location = New System.Drawing.Point(12, 206)
        Me.txtSerialIn4.MaxLength = 128
        Me.txtSerialIn4.Name = "txtSerialIn4"
        Me.txtSerialIn4.Size = New System.Drawing.Size(1008, 22)
        Me.txtSerialIn4.TabIndex = 89
        '
        'txtSerialIn3
        '
        Me.txtSerialIn3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialIn3.Location = New System.Drawing.Point(12, 180)
        Me.txtSerialIn3.MaxLength = 128
        Me.txtSerialIn3.Name = "txtSerialIn3"
        Me.txtSerialIn3.Size = New System.Drawing.Size(1008, 22)
        Me.txtSerialIn3.TabIndex = 88
        '
        'txtSerialIn2
        '
        Me.txtSerialIn2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialIn2.Location = New System.Drawing.Point(12, 154)
        Me.txtSerialIn2.MaxLength = 128
        Me.txtSerialIn2.Name = "txtSerialIn2"
        Me.txtSerialIn2.Size = New System.Drawing.Size(1008, 22)
        Me.txtSerialIn2.TabIndex = 87
        '
        'txtSerialIn1
        '
        Me.txtSerialIn1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialIn1.Location = New System.Drawing.Point(12, 128)
        Me.txtSerialIn1.MaxLength = 128
        Me.txtSerialIn1.Name = "txtSerialIn1"
        Me.txtSerialIn1.Size = New System.Drawing.Size(1008, 22)
        Me.txtSerialIn1.TabIndex = 86
        '
        'lblHexFile
        '
        Me.lblHexFile.AutoSize = True
        Me.lblHexFile.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHexFile.Location = New System.Drawing.Point(9, 284)
        Me.lblHexFile.Name = "lblHexFile"
        Me.lblHexFile.Size = New System.Drawing.Size(47, 13)
        Me.lblHexFile.TabIndex = 85
        Me.lblHexFile.Text = "Hex File"
        '
        'txtHexOut
        '
        Me.txtHexOut.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHexOut.Location = New System.Drawing.Point(12, 300)
        Me.txtHexOut.Multiline = True
        Me.txtHexOut.Name = "txtHexOut"
        Me.txtHexOut.ReadOnly = True
        Me.txtHexOut.Size = New System.Drawing.Size(1008, 117)
        Me.txtHexOut.TabIndex = 84
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1084, 24)
        Me.MenuStrip1.TabIndex = 99
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuReturn, Me.MenuReloadDefaultSerialData, Me.ToolStripMenuItem1, Me.FileMenuExit3})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'MenuReturn
        '
        Me.MenuReturn.Name = "MenuReturn"
        Me.MenuReturn.Size = New System.Drawing.Size(209, 22)
        Me.MenuReturn.Text = "Return"
        '
        'MenuReloadDefaultSerialData
        '
        Me.MenuReloadDefaultSerialData.Name = "MenuReloadDefaultSerialData"
        Me.MenuReloadDefaultSerialData.Size = New System.Drawing.Size(209, 22)
        Me.MenuReloadDefaultSerialData.Text = "Reload Default Serial Data"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(206, 6)
        '
        'FileMenuExit3
        '
        Me.FileMenuExit3.Name = "FileMenuExit3"
        Me.FileMenuExit3.Size = New System.Drawing.Size(209, 22)
        Me.FileMenuExit3.Text = "Exit"
        '
        'BtnGenerateHex
        '
        Me.BtnGenerateHex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerateHex.Location = New System.Drawing.Point(879, 30)
        Me.BtnGenerateHex.Name = "BtnGenerateHex"
        Me.BtnGenerateHex.Size = New System.Drawing.Size(141, 53)
        Me.BtnGenerateHex.TabIndex = 100
        Me.BtnGenerateHex.Text = "Generate Hex File"
        Me.BtnGenerateHex.UseVisualStyleBackColor = True
        '
        'lblSerialAddress
        '
        Me.lblSerialAddress.AutoSize = True
        Me.lblSerialAddress.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialAddress.Location = New System.Drawing.Point(9, 35)
        Me.lblSerialAddress.Name = "lblSerialAddress"
        Me.lblSerialAddress.Size = New System.Drawing.Size(123, 13)
        Me.lblSerialAddress.TabIndex = 105
        Me.lblSerialAddress.Text = "Serial Starting Address"
        '
        'txtAddr
        '
        Me.txtAddr.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddr.Location = New System.Drawing.Point(12, 51)
        Me.txtAddr.MaxLength = 4
        Me.txtAddr.Name = "txtAddr"
        Me.txtAddr.Size = New System.Drawing.Size(210, 22)
        Me.txtAddr.TabIndex = 104
        '
        'BtnGeneratePsocData
        '
        Me.BtnGeneratePsocData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGeneratePsocData.Location = New System.Drawing.Point(732, 30)
        Me.BtnGeneratePsocData.Name = "BtnGeneratePsocData"
        Me.BtnGeneratePsocData.Size = New System.Drawing.Size(141, 53)
        Me.BtnGeneratePsocData.TabIndex = 118
        Me.BtnGeneratePsocData.Text = "Generate Psoc Data"
        Me.BtnGeneratePsocData.UseVisualStyleBackColor = True
        '
        'LblDataToHex
        '
        Me.LblDataToHex.AutoSize = True
        Me.LblDataToHex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDataToHex.Location = New System.Drawing.Point(9, 73)
        Me.LblDataToHex.Name = "LblDataToHex"
        Me.LblDataToHex.Size = New System.Drawing.Size(85, 13)
        Me.LblDataToHex.TabIndex = 117
        Me.LblDataToHex.Text = "Psoc Data (Hex)"
        '
        'TxtPsocData
        '
        Me.TxtPsocData.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPsocData.Location = New System.Drawing.Point(12, 89)
        Me.TxtPsocData.Name = "TxtPsocData"
        Me.TxtPsocData.Size = New System.Drawing.Size(1008, 22)
        Me.TxtPsocData.TabIndex = 116
        '
        'HexConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1084, 462)
        Me.Controls.Add(Me.BtnGeneratePsocData)
        Me.Controls.Add(Me.LblDataToHex)
        Me.Controls.Add(Me.TxtPsocData)
        Me.Controls.Add(Me.lblSerialAddress)
        Me.Controls.Add(Me.txtAddr)
        Me.Controls.Add(Me.BtnGenerateHex)
        Me.Controls.Add(Me.lblSerialData)
        Me.Controls.Add(Me.txtSerialIn6)
        Me.Controls.Add(Me.txtSerialIn5)
        Me.Controls.Add(Me.txtSerialIn4)
        Me.Controls.Add(Me.txtSerialIn3)
        Me.Controls.Add(Me.txtSerialIn2)
        Me.Controls.Add(Me.txtSerialIn1)
        Me.Controls.Add(Me.lblHexFile)
        Me.Controls.Add(Me.txtHexOut)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "HexConverter"
        Me.Text = "HexConverter"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSerialData As Label
    Friend WithEvents txtSerialIn6 As TextBox
    Friend WithEvents txtSerialIn5 As TextBox
    Friend WithEvents txtSerialIn4 As TextBox
    Friend WithEvents txtSerialIn3 As TextBox
    Friend WithEvents txtSerialIn2 As TextBox
    Friend WithEvents txtSerialIn1 As TextBox
    Friend WithEvents lblHexFile As Label
    Friend WithEvents txtHexOut As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuReturn As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents FileMenuExit3 As ToolStripMenuItem
    Friend WithEvents MenuReloadDefaultSerialData As ToolStripMenuItem
    Friend WithEvents BtnGenerateHex As Button
    Friend WithEvents lblSerialAddress As Label
    Friend WithEvents txtAddr As TextBox
    Friend WithEvents BtnGeneratePsocData As Button
    Friend WithEvents LblDataToHex As Label
    Friend WithEvents TxtPsocData As TextBox
End Class
