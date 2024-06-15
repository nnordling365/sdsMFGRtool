<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class AdminPass
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents lblAdminPassword As System.Windows.Forms.Label
    Friend WithEvents txtAdminPassword As System.Windows.Forms.TextBox
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblAdminPassword = New System.Windows.Forms.Label()
        Me.txtAdminPassword = New System.Windows.Forms.TextBox()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblAdminPassword
        '
        Me.lblAdminPassword.Location = New System.Drawing.Point(12, 9)
        Me.lblAdminPassword.Name = "lblAdminPassword"
        Me.lblAdminPassword.Size = New System.Drawing.Size(220, 23)
        Me.lblAdminPassword.TabIndex = 2
        Me.lblAdminPassword.Text = "Admin Password"
        Me.lblAdminPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAdminPassword
        '
        Me.txtAdminPassword.Location = New System.Drawing.Point(14, 29)
        Me.txtAdminPassword.Name = "txtAdminPassword"
        Me.txtAdminPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAdminPassword.Size = New System.Drawing.Size(220, 20)
        Me.txtAdminPassword.TabIndex = 3
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(26, 55)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(94, 23)
        Me.BtnOK.TabIndex = 4
        Me.BtnOK.Text = "&OK"
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(126, 55)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "&Cancel"
        '
        'AdminPass
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(244, 102)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.txtAdminPassword)
        Me.Controls.Add(Me.lblAdminPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdminPass"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MFGR Helper 1.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
