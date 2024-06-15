Public Class AdminPass
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Dim password = txtAdminPassword.Text

        If password = AdminMenu.TxtAdminPass.Text Then
            'open admin menu
            Me.Close()
            MFGR_Helper.ShowAdminMenu()
            'ElseIf password = "devhexfilebackend123" Then
            '     Me.Close()
            '    HexConverter.ShowAdminMenu()
            '     AdminMenu.ShowHexFilePage()
        Else
            MsgBox("Sorry, password incorrect", MsgBoxStyle.OkOnly, "Invalid")
        End If

        txtAdminPassword.Text = ""
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class
