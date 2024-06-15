Public Class HexConverter
    Private Sub HexFileReturn_Click(sender As Object, e As EventArgs) Handles MenuReturn.Click
        ShowAdminMenu()
    End Sub
    Private Sub HexFile_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ShowAdminMenu()
    End Sub

    ''' <summary>
    ''' Closes the page, shows Admin Menu.
    ''' </summary>
    Private Sub ShowAdminMenu()
        Dim formLocA As Point
        formLocA = Location()
        Hide()
        AdminMenu.Show()
        AdminMenu.SetDesktopLocation(formLocA.X, formLocA.Y)
    End Sub

    Private Sub FileMenuExit2_Click(sender As Object, e As EventArgs) Handles FileMenuExit3.Click
        Close()
        AdminMenu.Close()
        MFGR_Helper.Close()
    End Sub

    ''' <summary>
    ''' Reloads the Hex File.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnReload_Click(sender As Object, e As EventArgs) Handles MenuReloadDefaultSerialData.Click
        MFGR_Helper.Loadfile()
        MsgBox("Values reloaded!", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
    End Sub

    Private Sub GenerateHexFile(sender As Object, e As EventArgs) Handles BtnGenerateHex.Click
        MFGR_Helper.GenerateHexFile()
    End Sub

    Private Sub BtnGeneratePsocData_Click(sender As Object, e As EventArgs) Handles BtnGeneratePsocData.Click
        MFGR_Helper.GeneratePsocData()
    End Sub
End Class