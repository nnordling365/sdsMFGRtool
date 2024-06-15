<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminMenu
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
        Me.AdminMenuBar = New System.Windows.Forms.MenuStrip()
        Me.MnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSaveReturn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReturnNoSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpenHexPage = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblAtmelHex = New System.Windows.Forms.Label()
        Me.TxtAtmelHexFileLoc = New System.Windows.Forms.TextBox()
        Me.BtnAtmelHexBrowse = New System.Windows.Forms.Button()
        Me.LblDatalog = New System.Windows.Forms.Label()
        Me.TxtDatalogLocation = New System.Windows.Forms.TextBox()
        Me.BtnDatalogBrowse = New System.Windows.Forms.Button()
        Me.LblDefaultProgTool = New System.Windows.Forms.Label()
        Me.LblDefaultInterface = New System.Windows.Forms.Label()
        Me.LblDefaultDevice = New System.Windows.Forms.Label()
        Me.TxtDefaultProgTool = New System.Windows.Forms.TextBox()
        Me.TxtDefaultDevice = New System.Windows.Forms.TextBox()
        Me.TxtDefaultInterface = New System.Windows.Forms.TextBox()
        Me.TxtAdminPass = New System.Windows.Forms.TextBox()
        Me.LblAdminPass = New System.Windows.Forms.Label()
        Me.LblPsocHex = New System.Windows.Forms.Label()
        Me.TxtPsocHexFileLoc = New System.Windows.Forms.TextBox()
        Me.BtnPsocHexBrowse = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.AdminMenuBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'AdminMenuBar
        '
        Me.AdminMenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFile})
        Me.AdminMenuBar.Location = New System.Drawing.Point(0, 0)
        Me.AdminMenuBar.Name = "AdminMenuBar"
        Me.AdminMenuBar.Size = New System.Drawing.Size(1084, 24)
        Me.AdminMenuBar.TabIndex = 0
        Me.AdminMenuBar.Text = "adminMenuBar"
        '
        'MnuFile
        '
        Me.MnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSaveReturn, Me.MnuReturnNoSave, Me.MnuReload, Me.MnuOpenHexPage})
        Me.MnuFile.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuFile.Name = "MnuFile"
        Me.MnuFile.Size = New System.Drawing.Size(37, 20)
        Me.MnuFile.Text = "File"
        '
        'MnuSaveReturn
        '
        Me.MnuSaveReturn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuSaveReturn.Name = "MnuSaveReturn"
        Me.MnuSaveReturn.Size = New System.Drawing.Size(204, 22)
        Me.MnuSaveReturn.Text = "Save Settings and Return"
        '
        'MnuReturnNoSave
        '
        Me.MnuReturnNoSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuReturnNoSave.Name = "MnuReturnNoSave"
        Me.MnuReturnNoSave.Size = New System.Drawing.Size(204, 22)
        Me.MnuReturnNoSave.Text = "Return Without Saving"
        '
        'MnuReload
        '
        Me.MnuReload.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuReload.Name = "MnuReload"
        Me.MnuReload.Size = New System.Drawing.Size(204, 22)
        Me.MnuReload.Text = "Reload Saved Values"
        '
        'MnuOpenHexPage
        '
        Me.MnuOpenHexPage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuOpenHexPage.Name = "MnuOpenHexPage"
        Me.MnuOpenHexPage.Size = New System.Drawing.Size(204, 22)
        Me.MnuOpenHexPage.Text = "Open Hex Page"
        Me.MnuOpenHexPage.Visible = False
        '
        'lblAtmelHex
        '
        Me.lblAtmelHex.AutoSize = True
        Me.lblAtmelHex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtmelHex.Location = New System.Drawing.Point(9, 79)
        Me.lblAtmelHex.Name = "lblAtmelHex"
        Me.lblAtmelHex.Size = New System.Drawing.Size(79, 13)
        Me.lblAtmelHex.TabIndex = 46
        Me.lblAtmelHex.Text = "Atmel Hex File"
        '
        'TxtAtmelHexFileLoc
        '
        Me.TxtAtmelHexFileLoc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAtmelHexFileLoc.Location = New System.Drawing.Point(12, 95)
        Me.TxtAtmelHexFileLoc.Name = "TxtAtmelHexFileLoc"
        Me.TxtAtmelHexFileLoc.ReadOnly = True
        Me.TxtAtmelHexFileLoc.Size = New System.Drawing.Size(963, 22)
        Me.TxtAtmelHexFileLoc.TabIndex = 45
        '
        'BtnAtmelHexBrowse
        '
        Me.BtnAtmelHexBrowse.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAtmelHexBrowse.Location = New System.Drawing.Point(981, 95)
        Me.BtnAtmelHexBrowse.Name = "BtnAtmelHexBrowse"
        Me.BtnAtmelHexBrowse.Size = New System.Drawing.Size(78, 23)
        Me.BtnAtmelHexBrowse.TabIndex = 49
        Me.BtnAtmelHexBrowse.Text = "Browse"
        Me.BtnAtmelHexBrowse.UseVisualStyleBackColor = True
        '
        'LblDatalog
        '
        Me.LblDatalog.AutoSize = True
        Me.LblDatalog.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDatalog.Location = New System.Drawing.Point(9, 161)
        Me.LblDatalog.Name = "LblDatalog"
        Me.LblDatalog.Size = New System.Drawing.Size(50, 13)
        Me.LblDatalog.TabIndex = 75
        Me.LblDatalog.Text = "DataLog"
        '
        'TxtDatalogLocation
        '
        Me.TxtDatalogLocation.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDatalogLocation.Location = New System.Drawing.Point(12, 177)
        Me.TxtDatalogLocation.Name = "TxtDatalogLocation"
        Me.TxtDatalogLocation.ReadOnly = True
        Me.TxtDatalogLocation.Size = New System.Drawing.Size(963, 22)
        Me.TxtDatalogLocation.TabIndex = 74
        '
        'BtnDatalogBrowse
        '
        Me.BtnDatalogBrowse.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDatalogBrowse.Location = New System.Drawing.Point(981, 177)
        Me.BtnDatalogBrowse.Name = "BtnDatalogBrowse"
        Me.BtnDatalogBrowse.Size = New System.Drawing.Size(78, 23)
        Me.BtnDatalogBrowse.TabIndex = 73
        Me.BtnDatalogBrowse.Text = "Browse"
        Me.BtnDatalogBrowse.UseVisualStyleBackColor = True
        '
        'LblDefaultProgTool
        '
        Me.LblDefaultProgTool.AutoSize = True
        Me.LblDefaultProgTool.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDefaultProgTool.Location = New System.Drawing.Point(12, 200)
        Me.LblDefaultProgTool.Name = "LblDefaultProgTool"
        Me.LblDefaultProgTool.Size = New System.Drawing.Size(100, 13)
        Me.LblDefaultProgTool.TabIndex = 76
        Me.LblDefaultProgTool.Text = "Programming tool"
        '
        'LblDefaultInterface
        '
        Me.LblDefaultInterface.AutoSize = True
        Me.LblDefaultInterface.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDefaultInterface.Location = New System.Drawing.Point(9, 239)
        Me.LblDefaultInterface.Name = "LblDefaultInterface"
        Me.LblDefaultInterface.Size = New System.Drawing.Size(52, 13)
        Me.LblDefaultInterface.TabIndex = 77
        Me.LblDefaultInterface.Text = "Interface"
        '
        'LblDefaultDevice
        '
        Me.LblDefaultDevice.AutoSize = True
        Me.LblDefaultDevice.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDefaultDevice.Location = New System.Drawing.Point(9, 278)
        Me.LblDefaultDevice.Name = "LblDefaultDevice"
        Me.LblDefaultDevice.Size = New System.Drawing.Size(40, 13)
        Me.LblDefaultDevice.TabIndex = 78
        Me.LblDefaultDevice.Text = "Device"
        '
        'TxtDefaultProgTool
        '
        Me.TxtDefaultProgTool.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDefaultProgTool.Location = New System.Drawing.Point(15, 216)
        Me.TxtDefaultProgTool.Name = "TxtDefaultProgTool"
        Me.TxtDefaultProgTool.Size = New System.Drawing.Size(209, 22)
        Me.TxtDefaultProgTool.TabIndex = 79
        '
        'TxtDefaultDevice
        '
        Me.TxtDefaultDevice.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDefaultDevice.Location = New System.Drawing.Point(15, 294)
        Me.TxtDefaultDevice.Name = "TxtDefaultDevice"
        Me.TxtDefaultDevice.Size = New System.Drawing.Size(209, 22)
        Me.TxtDefaultDevice.TabIndex = 80
        '
        'TxtDefaultInterface
        '
        Me.TxtDefaultInterface.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDefaultInterface.Location = New System.Drawing.Point(15, 255)
        Me.TxtDefaultInterface.Name = "TxtDefaultInterface"
        Me.TxtDefaultInterface.Size = New System.Drawing.Size(209, 22)
        Me.TxtDefaultInterface.TabIndex = 81
        '
        'TxtAdminPass
        '
        Me.TxtAdminPass.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdminPass.Location = New System.Drawing.Point(12, 54)
        Me.TxtAdminPass.Name = "TxtAdminPass"
        Me.TxtAdminPass.Size = New System.Drawing.Size(209, 22)
        Me.TxtAdminPass.TabIndex = 82
        '
        'LblAdminPass
        '
        Me.LblAdminPass.AutoSize = True
        Me.LblAdminPass.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdminPass.Location = New System.Drawing.Point(9, 38)
        Me.LblAdminPass.Name = "LblAdminPass"
        Me.LblAdminPass.Size = New System.Drawing.Size(92, 13)
        Me.LblAdminPass.TabIndex = 83
        Me.LblAdminPass.Text = "Admin Password"
        '
        'LblPsocHex
        '
        Me.LblPsocHex.AutoSize = True
        Me.LblPsocHex.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPsocHex.Location = New System.Drawing.Point(9, 120)
        Me.LblPsocHex.Name = "LblPsocHex"
        Me.LblPsocHex.Size = New System.Drawing.Size(73, 13)
        Me.LblPsocHex.TabIndex = 85
        Me.LblPsocHex.Text = "Psoc Hex File"
        '
        'TxtPsocHexFileLoc
        '
        Me.TxtPsocHexFileLoc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPsocHexFileLoc.Location = New System.Drawing.Point(12, 136)
        Me.TxtPsocHexFileLoc.Name = "TxtPsocHexFileLoc"
        Me.TxtPsocHexFileLoc.ReadOnly = True
        Me.TxtPsocHexFileLoc.Size = New System.Drawing.Size(963, 22)
        Me.TxtPsocHexFileLoc.TabIndex = 84
        '
        'BtnPsocHexBrowse
        '
        Me.BtnPsocHexBrowse.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPsocHexBrowse.Location = New System.Drawing.Point(981, 134)
        Me.BtnPsocHexBrowse.Name = "BtnPsocHexBrowse"
        Me.BtnPsocHexBrowse.Size = New System.Drawing.Size(78, 23)
        Me.BtnPsocHexBrowse.TabIndex = 86
        Me.BtnPsocHexBrowse.Text = "Browse"
        Me.BtnPsocHexBrowse.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(532, 393)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 23)
        Me.BtnCancel.TabIndex = 88
        Me.BtnCancel.Text = "&Cancel"
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(432, 393)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 23)
        Me.BtnOK.TabIndex = 87
        Me.BtnOK.Text = "&OK"
        '
        'AdminMenu
        '
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1084, 462)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnPsocHexBrowse)
        Me.Controls.Add(Me.LblPsocHex)
        Me.Controls.Add(Me.TxtPsocHexFileLoc)
        Me.Controls.Add(Me.LblAdminPass)
        Me.Controls.Add(Me.TxtAdminPass)
        Me.Controls.Add(Me.TxtDefaultInterface)
        Me.Controls.Add(Me.TxtDefaultDevice)
        Me.Controls.Add(Me.TxtDefaultProgTool)
        Me.Controls.Add(Me.LblDefaultDevice)
        Me.Controls.Add(Me.LblDefaultInterface)
        Me.Controls.Add(Me.LblDefaultProgTool)
        Me.Controls.Add(Me.LblDatalog)
        Me.Controls.Add(Me.TxtDatalogLocation)
        Me.Controls.Add(Me.BtnDatalogBrowse)
        Me.Controls.Add(Me.BtnAtmelHexBrowse)
        Me.Controls.Add(Me.lblAtmelHex)
        Me.Controls.Add(Me.TxtAtmelHexFileLoc)
        Me.Controls.Add(Me.AdminMenuBar)
        Me.MainMenuStrip = Me.AdminMenuBar
        Me.Name = "AdminMenu"
        Me.Text = "Admin Settings"
        Me.AdminMenuBar.ResumeLayout(False)
        Me.AdminMenuBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub



    Friend WithEvents AdminMenuBar As MenuStrip
    Friend WithEvents lblAtmelHex As Label
    Friend WithEvents TxtAtmelHexFileLoc As TextBox
    Friend WithEvents BtnAtmelHexBrowse As Button
    Friend WithEvents LblDatalog As Label
    Friend WithEvents TxtDatalogLocation As TextBox
    Friend WithEvents BtnDatalogBrowse As Button
    Friend WithEvents LblDefaultProgTool As Label
    Friend WithEvents LblDefaultInterface As Label
    Friend WithEvents LblDefaultDevice As Label
    Friend WithEvents TxtDefaultProgTool As TextBox
    Friend WithEvents TxtDefaultDevice As TextBox
    Friend WithEvents TxtDefaultInterface As TextBox
    Friend WithEvents MnuFile As ToolStripMenuItem
    Friend WithEvents MnuSaveReturn As ToolStripMenuItem
    Friend WithEvents MnuReturnNoSave As ToolStripMenuItem
    Friend WithEvents MnuReload As ToolStripMenuItem
    Friend WithEvents MnuOpenHexPage As ToolStripMenuItem
    Friend WithEvents TxtAdminPass As TextBox
    Friend WithEvents LblAdminPass As Label
    Friend WithEvents LblPsocHex As Label
    Friend WithEvents TxtPsocHexFileLoc As TextBox
    Friend WithEvents BtnPsocHexBrowse As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnOK As Button
End Class
