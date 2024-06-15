Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Text

Public Class AdminMenu
    Public div As Integer = 6
    Public adminFields(8) As TextBox
    Public Defaults(8) As String
    Public Section() As String = {"adminSettings", "atmel"}
    Public dataName() As String = {"Admin__Password____", "Default_PsocHexName", "DefaultAtmelHexName", "Default_AtmelHexLoc", "Default__PsocHexLoc",
                                   "Database__Location_", "Programming__Tool__", "Default__Interface_", "Default__Device____"}
    Public settingsFilePath As String = MFGR_Helper.programResources + MFGR_Helper.helperDirectories(MFGR_Helper.Hdir.INI) + "adminSettings.ini"

    ''' <summary>
    ''' When Closed, show the main form again.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Menu_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ShowMain()
    End Sub

    ''' <summary>
    ''' Calls AdminLoad function.
    ''' </summary>
    Private Sub Menu_Load() Handles Me.Load
        AdminLoad()
    End Sub

    ''' <summary>
    ''' Reads from adminSettings ini file, initializing fields and setting default variables.
    ''' If the file does not exist it is created with default values.
    ''' <para>Locations are loaded whether or not the files that should be there exist in that location yet.</para>
    ''' </summary>
    Public Sub AdminLoad()
        Dim settingDefaults = {"11334242", "ElectroSeaSAMD21E", "Clearline",
                               MFGR_Helper.programResources + MFGR_Helper.helperDirectories(MFGR_Helper.Hdir.FILES) + "ElectroSeaSAMD21E.hex",
                               MFGR_Helper.programResources + MFGR_Helper.helperDirectories(MFGR_Helper.Hdir.FILES) + "Clearline.hex",
                               MFGR_Helper.programResources + MFGR_Helper.helperDirectories(MFGR_Helper.Hdir.DATALOG), "atmelice", "SWD", "atsamd21e18a"}

        If Not File.Exists(settingsFilePath) Then
            'if file does not exist, create the file with default values
            For x = 0 To settingDefaults.Length - 1
                'section integer divided to split into two sections
                INIReadWrite.WriteINI(settingsFilePath, Section(x \ div), dataName(x), settingDefaults(x))
            Next
        End If

        'read the file and set values
        For x = 0 To settingDefaults.Length - 1
            Defaults(x) = INIReadWrite.ReadINI(settingsFilePath, Section(x \ div), dataName(x))
            adminFields(x).Text = Defaults(x)
        Next

        File.SetAttributes(settingsFilePath, FileAttributes.ReadOnly)
    End Sub

    ''' <summary>
    ''' Hides Admin Menu and shows main form.
    ''' </summary>
    Private Sub ShowMain()
        Dim formLocA As Point
        formLocA = Location()
        Hide()
        MFGR_Helper.Show()
        MFGR_Helper.SetDesktopLocation(formLocA.X, formLocA.Y)
    End Sub

    ''' <summary>
    ''' Browses to a file directory which is used as the new location for the hex and data log files.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnBrowseToDatabase_Click(sender As Object, e As EventArgs) Handles BtnDatalogBrowse.Click
        BtnBrowseToFileDirectory_Click(TxtDatalogLocation)
    End Sub

    ''' <summary>
    ''' Browses to a file directory and stores that location in a textbox
    ''' </summary>
    ''' <param name="txt">textbox used to store file directory</param>
    Private Sub BtnBrowseToFileDirectory_Click(txt As TextBox)
        Using fld As New FolderBrowserDialog()
            fld.Description = "Select the directory that you want to use as the default."
            'fld.RootFolder = Environment.SpecialFolder.MyComputer
            fld.SelectedPath = txt.Text

            If fld.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txt.Text = fld.SelectedPath
                MFGR_Helper.Loadfile()
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Browse to hex file used for the CLI functions.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnHexFileBrowse_Click(sender As Object, e As EventArgs) Handles BtnAtmelHexBrowse.Click
        BtnBrowseToFileLocation_Click(TxtAtmelHexFileLoc, MFGR_Helper.txtAtmelHexFileName, Strings.Right(TxtAtmelHexFileLoc.Text, 4))
    End Sub

    Private Sub BtnPsocHexBrowse_Click(sender As Object, e As EventArgs) Handles BtnPsocHexBrowse.Click
        BtnBrowseToFileLocation_Click(TxtPsocHexFileLoc, MFGR_Helper.txtPsocHexFileName, Strings.Right(TxtPsocHexFileLoc.Text, 4))
    End Sub

    ''' <summary>
    ''' Browses to a file and stores that file's path in a textbox
    ''' </summary>
    ''' <param name="txt">textbox used to store file location</param>
    ''' <param name="origName">Name of the previous file used, is taken out of the path for the initial directory</param>
    ''' <param name="origExtension">the file extension which is used for handling the file to be displayed without</param>
    Private Sub BtnBrowseToFileLocation_Click(txt As TextBox, origName As TextBox, origExtension As String)
        Dim ofd As New OpenFileDialog With {
            .InitialDirectory = Strings.Left(txt.Text, txt.Text.Length - (origName.Text + origExtension).Length)
        }

        Using ofd
            If ofd.ShowDialog() = DialogResult.OK Then
                If Strings.Right(ofd.FileName, origExtension.Length) = origExtension Then
                    txt.Text = ofd.FileName
                    Dim filenam = Path.GetFileName(ofd.FileName)
                    origName.Text = Strings.Left(filenam, filenam.Length - origExtension.Length)
                Else
                    MsgBox("File is not the correct type" + vbNewLine + "Please try again", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
                End If
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Opens the hex file page and closes the other forms, may be temporary.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MnuOpenHexPage_Click(sender As Object, e As EventArgs) Handles MnuOpenHexPage.Click
        ShowHexFilePage()
    End Sub

    Public Sub ShowHexFilePage()
        Dim formLocA As Point
        formLocA = Location()
        Hide()
        HexConverter.Show()
        HexConverter.SetDesktopLocation(formLocA.X, formLocA.Y)
    End Sub

    ''' <summary>
    ''' Copies all data in the textboxes to the default variables, and writes over the adminSettings ini file.
    ''' If the ini file does not exist, it will be created.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MnuSaveReturn_Click(sender As Object, e As EventArgs) Handles MnuSaveReturn.Click
        File.SetAttributes(settingsFilePath, FileAttributes.Normal)

        For x = 0 To Defaults.Length - 1
            Defaults(x) = adminFields(x).Text
            INIReadWrite.WriteINI(settingsFilePath, Section(x \ div), dataName(x), adminFields(x).Text)
        Next

        MFGR_Helper.PassFailImageHandler(MFGR_Helper.Pf.gray)
        MFGR_Helper.TxtOutput.Text = "Please scan a barcode..."
        MsgBox("Settings Saved!", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
        File.SetAttributes(settingsFilePath, FileAttributes.ReadOnly)
        ShowMain()
    End Sub

    ''' <summary>
    ''' Sets textboxes back to default variables and return to the main form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MnuReturnNoSave_Click(sender As Object, e As EventArgs) Handles MnuReturnNoSave.Click
        MFGR_Helper.PassFailImageHandler(MFGR_Helper.Pf.gray)

        For x = 0 To Defaults.Length - 1
            adminFields(x).Text = Defaults(x)
        Next

        MFGR_Helper.TxtOutput.Text = "Please scan a barcode..."
        ShowMain()
    End Sub

    Private Sub MnuReload_Click(sender As Object, e As EventArgs) Handles MnuReload.Click
        MFGR_Helper.LoadAll(MFGR_Helper.LoadX.admin)
        MsgBox("Values reloaded!", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
    End Sub
End Class