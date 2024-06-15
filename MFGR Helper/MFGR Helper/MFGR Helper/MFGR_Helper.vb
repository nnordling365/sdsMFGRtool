Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Ports
Imports System.Management
Imports System.Runtime.InteropServices
Imports System.Text

Public Class MFGR_Helper
    Public userFieldData(12), parameters(3), hexName, RawError, previousSerial, factoryPassword, portname As String
    Public lineCount As Integer = 6
    Public maxTime, maxTime2, fileSize, second As Decimal
    Public PsocProc As New Process
    Public AtmelProc As New Process
    Public prevFailed, codeScanned, psocDebug As Boolean
    Public dataLine(lineCount - 1), userFields(12) As TextBox
    Public helperDirectories() As String = {"MFGR_Ini\", "MFGR_CLI\", "MFGR_Datalog\", "MFGR_Files\", "MFGR_Images\"}
    Public passFailImages() As String = {"graycircle.png", "greencheck.png", "redx.png"}
    Public programResources As String = Directory.GetCurrentDirectory + "\Resources\"
    Public serialLocation As String = programResources + helperDirectories(Hdir.FILES) + "PsocData.hex"
    Public UserFieldIniLocation As String = programResources + helperDirectories(Hdir.INI) + "userFields.ini"
    Public atmelOutputLocation As String = programResources + helperDirectories(Hdir.CLI) + "atmelOutput.txt"
    Public psocOutputLocation As String = programResources + helperDirectories(Hdir.CLI) + "psocOutput.txt"
    Public batchLocation() As String = {programResources + helperDirectories(Hdir.CLI) + "LoadAtmel.bat",
                                        programResources + helperDirectories(Hdir.CLI) + "LoadPsoc.bat",
                                        programResources + helperDirectories(Hdir.CLI) + "C_sharp.exe"}
    Public iniSection() As String = {"generalInfo", "userFields", "technical"}
    Public technicalIni() As String = {"Previous_Failed", "Code__Scanned__"}
    Public dataName() As String = {"Serial__Number_: ", "Date__and__Time: ", "FactoryPassword: ", "Version__Number: ", "Output__Level__: ", "Input__GPM_____: ",
                                   "Pump__Mode_____: ", "Pump__Time_____: ", "Cell__Delay__1_: ", "Forward_On__Sec: ", "Reverse_On__Sec: ", "Contrast_______: ",
                                   "Backlight______: ", "GPM__Override__: ", "Forward_Off_Sec: ", "Reverse_Off_Sec: ", "Deadtime__Sec__: "}
    Public Enum Hdir
        INI = 0
        CLI = 1
        DATALOG = 2
        FILES = 3
        IMAGES = 4
    End Enum
    ''' <summary>
    ''' Returns whether or not there is a previous instance of the program running
    ''' </summary>
    ''' <returns></returns>
    Function PrevInstance() As Boolean
        If UBound(Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Occurs when main screen loads, calls initialization and load functions to set up all the fields in the program.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub HexConverter_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PrevInstance() Then
            MsgBox("Application is already running", vbCritical, "MFGR Helper 1.0")

            AdminMenu.Close()
            HexConverter.Close()
            Close()
        End If
        '  If HexConverter.txtAddr.Text Is "" Then
        ' HexConverter.txtAddr.Text = "0000"
        ' End If

        'Initialize some values
        second = 0
        factoryPassword = ""
        PassFailImageHandler(Pf.gray)
        psocDebug = False ' will be false unless set to true in the program method

        'Center program on screen and set default mouse selection so nothing shows up on start.
        CenterToScreen()
        ChkOutputLevel.Select()

        'set up user fields for group usage
        InitFields()

        'load everything into the program
        LoadAll(LoadX.all)

        'Initialize serial code, default state values, and output text
        txtSerialCode.Text = INIReadWrite.ReadINI(UserFieldIniLocation, iniSection(0), dataName(0).Replace(": ", ""))
        previousSerial = txtSerialCode.Text
        prevFailed = INIReadWrite.ReadINI(UserFieldIniLocation, iniSection(2), technicalIni(0))
        codeScanned = INIReadWrite.ReadINI(UserFieldIniLocation, iniSection(2), technicalIni(1))

        If txtSerialCode.Text = "000000" Then
            TxtOutput.Text = "Please scan a barcode..."
        Else
            TxtOutput.Text = "Please scan a new barcode..."
        End If



        'TODO: Hide folders before final/test usage

        'Hide folders from plain view and from hidden view by making them protected operating system files
        ' Dim hide As New Process
        ' hide.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        ' hide.StartInfo.FileName = "CMD"

        'hide the INI folder by uncommenting the first line, show it by uncommenting the second. In both cases uncomment start to begin the process.
        ' hide.StartInfo.Arguments = "/C attrib +s +h """ + programResources + helperDirectories(Hdir.INI) + """"
        ' hide.StartInfo.Arguments = "/C attrib -s -h """ + programResources + helperDirectories(Hdir.INI) + """"
        ' hide.Start()

        'hide the CLI folder by uncommenting the first line, show it by uncommenting the second. In both cases uncomment start to begin the process.
        ' hide.StartInfo.Arguments = "/C attrib +s +h """ + programResources + helperDirectories(Hdir.CLI) + """"
        ' hide.StartInfo.Arguments = "/C attrib -s -h """ + programResources + helperDirectories(Hdir.CLI) + """"
        ' hide.Start()

        'hide the IMAGES folder by uncommenting the first line, show it by uncommenting the second. In both cases uncomment start to begin the process.
        ' hide.StartInfo.Arguments = "/C attrib +s +h """ + programResources + helperDirectories(Hdir.IMAGES) + """"
        ' hide.StartInfo.Arguments = "/C attrib -s -h """ + programResources + helperDirectories(Hdir.IMAGES) + """"
        ' hide.Start()

        ComCheck()
        If Not portname = "" Then
            Try
                With ScannerPort
                    .PortName = portname '"COM8"
                    .BaudRate = 38400 '9600
                    .Parity = Parity.None
                    .DataBits = 8
                    .StopBits = StopBits.One
                End With
                ScannerPort.Open()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            MsgBox("Barcode Scanner not found", vbCritical, "MFGR Helper 1.0")
            Close()
        End If
    End Sub

    ''' <summary>
    ''' Loads all fields(specified) in the program: Ini directory, Admin Menu Fields, User Fields, the Hex File, and images.
    ''' </summary>
    Public Sub LoadAll(toLoad As Integer)
        If Not File.Exists(programResources) Then
            My.Computer.FileSystem.CreateDirectory(programResources)
        End If
        'creates directory for the filelocation textbox if it does not exist yet 
        For x = 0 To 4
            If Not File.Exists(programResources + helperDirectories(x)) Then
                My.Computer.FileSystem.CreateDirectory(programResources + helperDirectories(x))
            End If
        Next

        If toLoad = LoadX.init Or toLoad = LoadX.all Then
            'loads user initialization files for the Main Page
            UserInitLoad()
        End If

        'Loads default serial values from hex file that go into the Hexconverter page
        Loadfile()

        If toLoad = LoadX.admin Or toLoad = LoadX.all Then
            'loads default adminmenu fields from ini file using iniReadWrite
            'if they do not exist it creates them
            AdminMenu.AdminLoad()
        End If

        'puts the files packaged in the folder into their correct directories
        Dim packagedFiles() As String = {txtAtmelHexFileName.Text + ".hex", txtPsocHexFileName.Text + ".hex", "C_sharp.exe", "PP_COM_Wrapper.dll",
                                         passFailImages(0), passFailImages(1), passFailImages(2)}
        For x = 0 To packagedFiles.Length - 1
            If File.Exists(programResources + packagedFiles(x)) Then
                Dim b As Integer
                Select Case Strings.Right(packagedFiles(x), 3)
                    Case = "hex"
                        b = Hdir.FILES
                    Case = "png"
                        b = Hdir.IMAGES
                    Case = "exe", "dll"
                        b = Hdir.CLI
                End Select
                File.Move(programResources + packagedFiles(x), programResources + helperDirectories(b) + packagedFiles(x))
            End If
        Next
    End Sub
    Public Enum LoadX
        admin = 0
        init = 1
        all = 2
    End Enum

    ''' <summary>
    ''' Initialize arrays of textboxes For group usage.
    ''' </summary>
    Public Sub InitFields()
        'lines for the hex file
        dataLine(0) = HexConverter.txtSerialIn1
        dataLine(1) = HexConverter.txtSerialIn2
        dataLine(2) = HexConverter.txtSerialIn3
        dataLine(3) = HexConverter.txtSerialIn4
        dataLine(4) = HexConverter.txtSerialIn5
        dataLine(5) = HexConverter.txtSerialIn6

        'user fields for the device
        userFields = {txtOutputLevel, txtInputGPM, txtPumpMode, txtPumpTime, txtCellDelay1, txtForwardOnSec, txtReverseOnSec,
                      txtContrast, txtBacklight, txtGPMOverride, txtForwardOffSec, txtReverseOffSec, txtDeadtimeSec}

        'admin menu fields
        AdminMenu.adminFields = {AdminMenu.TxtAdminPass, txtAtmelHexFileName, txtPsocHexFileName, AdminMenu.TxtAtmelHexFileLoc, AdminMenu.TxtPsocHexFileLoc,
                                 AdminMenu.TxtDatalogLocation, AdminMenu.TxtDefaultProgTool, AdminMenu.TxtDefaultInterface, AdminMenu.TxtDefaultDevice}
    End Sub

    ''' <summary>
    '''Loads the Hex file from location into HexFile Page
    ''' </summary>
    Public Sub Loadfile()
        Dim fileReader, fileData(lineCount - 1) As String
        Dim i As Integer

        For x As Integer = 0 To dataLine.Length - 1
            dataLine(x).Text = "".PadLeft(128, "0"c)
        Next

        If File.Exists(serialLocation) Then
            fileReader = My.Computer.FileSystem.ReadAllText(serialLocation)
            i = 9
            For x As Integer = 0 To fileData.Count - 1
                fileData(x) = ""
                For y As Integer = i To i + 127
                    fileData(x) += fileReader(y)
                Next
                i += 141
            Next

            HexConverter.txtHexOut.Text = fileReader

            'instead of filling with 0's, fill with the barcode data
            For x As Integer = 0 To dataLine.Length - 1
                dataLine(x).Text = fileData(x)
            Next
        Else
            HexConverter.txtHexOut.Text = "File does not exist yet"
        End If
    End Sub

    ''' <summary>
    ''' Receives any strings read in from the serial port, outputs them to a textbox, and writes to the userfield ini.
    ''' </summary>
    ''' <param name="msg">the message sent from the serial port</param>
    Sub ReceiveSerialData(ByVal msg As String)
        ' Receive strings from a serial port.
        CheckForIllegalCrossThreadCalls = False
        previousSerial = txtSerialCode.Text
        TxtTestBox.Text = previousSerial
        txtSerialCode.Text = msg '& vbCrLf
        File.SetAttributes(UserFieldIniLocation, FileAttributes.Normal)
        Dim s As String = Strings.Left(msg, 6)
        INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(0), dataName(0).Replace(": ", ""), s)
        INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(2), technicalIni(1), "True")
        codeScanned = INIReadWrite.ReadINI(UserFieldIniLocation, iniSection(2), technicalIni(1))
        File.SetAttributes(UserFieldIniLocation, FileAttributes.ReadOnly)
    End Sub

    ''' <summary>
    ''' Reads serial port data and discards upon completion.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ScannerPort_DataReceived(sender As Object, e As Ports.SerialDataReceivedEventArgs) Handles ScannerPort.DataReceived
        Dim returnStr As String
        returnStr = ScannerPort.ReadExisting
        ReceiveSerialData(returnStr)
        ScannerPort.DiscardInBuffer()
    End Sub

    ''' <summary>
    ''' Saves user fields to ini file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveSettings_Click(sender As Object, e As EventArgs) Handles MnuSaveSettings.Click
        Select Case MsgBox("Do you want to overwrite the previous default values?", MsgBoxStyle.YesNo, "MFGR Helper 1.0")
            Case MsgBoxResult.Yes
                Dim decimalValues = True

                For x = 0 To userFields.Length - 1
                    If Not IsNumeric(userFields(x).Text) Then
                        decimalValues = False
                    End If
                Next

                If decimalValues Then
                    File.SetAttributes(UserFieldIniLocation, FileAttributes.Normal)
                    'INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(0), dataName(0).Replace(": ", ""), txtSerialCode.Text)
                    For x = 0 To userFields.Length - 1
                        INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(1), dataName(x + 4).Replace(": ", ""), userFields(x).Text)
                    Next

                    MsgBox("Settings Saved!", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
                    File.SetAttributes(UserFieldIniLocation, FileAttributes.ReadOnly)
                Else
                    MsgBox("Please enter decimal values into the fields", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
                End If
            Case MsgBoxResult.No
        End Select
    End Sub

    ''' <summary>
    ''' Loads User fields from ini file; 
    ''' If the file does not exist it will be created.
    ''' </summary>
    Private Sub UserInitLoad()
        'TODO: There is no real failsafe for values being deleted directly from the file, may need a warning in the readme file.
        Dim settingDefaults = {"10", "5", "1", "0", "30", "120", "120", "60", "100", "0", "25", "25", "5"}

        If Not File.Exists(UserFieldIniLocation) Then
            'if file does not exist, create the file with default values
            'serial code
            INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(0), dataName(0).Replace(": ", ""), "000000")
            'previous failed and code scanned variables, keep state for program upon closing.
            INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(2), technicalIni(0), "False")
            INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(2), technicalIni(1), "False")
            'user fields
            For x = 0 To userFields.Length - 1
                INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(1), dataName(x + 4).Replace(": ", ""), settingDefaults(x))
            Next
        End If

        'read the file and set values
        For x = 0 To userFields.Length - 1
            userFields(x).Text = INIReadWrite.ReadINI(UserFieldIniLocation, iniSection(1), dataName(x + 4).Replace(": ", ""))
        Next

        File.SetAttributes(UserFieldIniLocation, FileAttributes.ReadOnly)
    End Sub

    ''' <summary>
    ''' Whenever a User field textbox is changed,
    ''' it will be checked to make sure what was typed is a number and results in a number that does not exceed the maximum.
    ''' </summary>
    ''' <param name="textbox1"></param>
    Private Sub UserFieldHandler(textbox1 As TextBox)

        Dim x As Integer

        For x = 0 To userFields.Length - 1
            If textbox1.Name = userFields(x).Name Then
                Exit For
            End If
        Next
        If userFields(x).Text IsNot "" Then
            If IsNumeric(userFields(x).Text) Then
                If x = 3 Or x = 4 Or x = 7 Or x = 8 Or x = 9 Or x = 10 Then
                    If Convert.ToInt32(userFields(x).Text, 10) > 65535 Then
                        userFields(x).Text = 65535
                        MsgBox(Replace(userFields(x).Name, "txt", "") + " Cannot exceed a value of 65535", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
                    End If
                Else
                    If Convert.ToInt32(userFields(x).Text, 10) > 255 Then
                        userFields(x).Text = 255
                        MsgBox(Replace(userFields(x).Name, "txt", "") + " Cannot exceed a value of 255", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
                    End If
                End If
                userFieldData(x) = userFields(x).Text
            Else

                MsgBox("Please enter decimal values into the fields", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
                userFields(x).Text = userFieldData(x)
            End If

        End If
    End Sub

    ''' <summary>
    ''' Creates a log file that holds info about the serial number, date and time, factory password, version number, and all of the user fields.
    ''' It also creates the directory for its location.
    ''' </summary>
    Public Sub GenerateLogFile()
        Dim filePath, fileName, logString, logData(17) As String

        'generate factory password from serial code
        FactoryPassGen()

        'logData holds all the fields to later be added to the log file more easily
        logData(0) = Convert.ToInt32(txtSerialCode.Text).ToString.PadLeft(6, "0"c) ' Serial Num
        logData(1) = DateTime.Now.ToString() ' Local Date
        logData(2) = factoryPassword 'UDLR etc Password
        logData(3) = "1.0" ' Version

        'add the user fields as data below the first 4 strings
        For x = 0 To userFields.Length - 1
            logData(x + 4) = userFields(x).Text
        Next

        fileName = logData(0).PadLeft(6, "0"c) + " " + logData(1).Replace("/", "-").Replace(":", "_")
        filePath = "" + AdminMenu.TxtDatalogLocation.Text + "\" + fileName + ".txt"

        logString = dataName(0) + logData(0)
        For x = 1 To 16
            logString += vbNewLine + dataName(x) + logData(x)
        Next

        logString += RawError

        ' Create the file.
        Dim fs As FileStream = IO.File.Create(filePath)

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(logString)
        fs.Write(info, 0, info.Length)
        fs.Close()
    End Sub

    ''' <summary>
    ''' Generates a PsocData hex file based on the text fields in the HexFile page. 
    ''' <para>If it already exists, the file will be overwritten.</para>
    ''' <para>This function also creates the directory for the file location should it not exist yet. </para>
    ''' </summary>
    Public Sub GenerateHexFile()
        Try
            'a = address integer, b = iteration variable
            Dim a, x, datasum(lineCount - 1), checksum(lineCount - 1), recordType As Integer
            Dim addr(lineCount - 1), filePath, fileName, data(lineCount - 1), address As String
            Dim dataNum(lineCount - 1), addrNum(lineCount - 1) As IEnumerable(Of String)
            recordType = 0
            'If the fields are blank, default value used is 0
            address = HexConverter.txtAddr.Text
            If address IsNot "" Then
                a = Convert.ToInt32(address, 16)
            Else a = 0
            End If

            For x = 0 To lineCount - 1
                data(x) = "" + dataLine(x).Text.PadLeft(128, "0"c)
                addr(x) = Convert.ToString(a + 64 * x, 16).PadLeft(4, "0"c).ToUpper
            Next

            'Splits these strings into substrings 2 hex bits long
            For x = 0 To lineCount - 1
                Dim C As Integer = x
                dataNum(x) = Enumerable.Range(0, data(x).Length \ 2).Select(Function(y) data(C).Substring(y * 2, 2))
                addrNum(x) = Enumerable.Range(0, addr(x).Length \ 2).Select(Function(y) addr(C).Substring(y * 2, 2))
            Next

            For x = 0 To datasum.Count - 1
                datasum(x) = 0
                For y As Integer = 0 To dataNum(x).Count - 1
                    datasum(x) += 0 + Convert.ToInt32(dataNum(x)(y), 16)
                Next
            Next

            'checksum = 1 + NOT(<addition of each pair of bits in the line>)
            For x = 0 To lineCount - 1
                checksum(x) = 1 + ((Not (64 + Convert.ToInt32(addrNum(x)(0), 16) + Convert.ToInt32(addrNum(x)(1), 16) + recordType + datasum(x))) Mod 256)
            Next

            'format is :LLAAAATTDDDDDDDDCC
            'where LL is the record length
            'AAAA is the address of the data to be stored
            'TT is the record type
            'DD...DD is the data
            'CC is the checksum
            HexConverter.txtHexOut.Text = ""
            For x = 0 To lineCount - 1 '        :LL    AAAA       TT    DD...DD           CC
                HexConverter.txtHexOut.Text += ":40" + addr(x) + "00" + data(x).ToUpper + Strings.Right(Convert.ToString(checksum(x), 16).PadLeft(2, "0"c).ToUpper, 2) + vbNewLine
            Next
            HexConverter.txtHexOut.Text += ":00000001FF"

            fileName = "PsocData"
            filePath = "" + programResources + helperDirectories(Hdir.FILES) + fileName + ".hex"

            ' Create or overwrite the file.
            Dim fs As FileStream = IO.File.Create(filePath)

            ' Add text to the file.
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(HexConverter.txtHexOut.Text)
            fs.Write(info, 0, info.Length)
            fs.Close()

        Catch Exc As System.InvalidCastException
            MessageBox.Show("Please enter hex numbers to Serial Input and address values into the address fields", "Error")

            ' Print to the Output console
            Console.WriteLine("An error occurred")

        Catch Exc As Exception
            MessageBox.Show("An unknown error occurred", "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Takes User Field data from the main form, turns it into hex data that is concatenated and made into a .udata file for psoc_cli usage.
    ''' <para>The concatenation is "55AA" + 3 bytes serial code + 4 bytes password + 3 single, 2 double, 2 single, 4 double, and 3 single bytes of the userFields.</para>
    ''' </summary>
    Public Sub GeneratePsocData()
        Dim userDataString = "55AA"

        For x = 0 To userFields.Length - 1 ' add all the data from user inputs
            Select Case x
                Case = 4, 5, 6, 11
                    userDataString += Convert.ToString(Convert.ToInt32(userFields(x).Text), 16).PadLeft(4, "0"c).ToUpper
                Case = 10
                    userDataString += Convert.ToString(Convert.ToInt32(userFields(x).Text), 16).PadLeft(4, "0"c).ToUpper + "00"
                Case Else
                    userDataString += Convert.ToString(Convert.ToInt32(userFields(x).Text), 16).PadLeft(2, "0"c).ToUpper
            End Select
        Next

        ' serial code
        For x = 0 To 5
            userDataString += "3" + txtSerialCode.Text.Chars(x)
        Next

        'TODO: Version numbers for firmware, usb, and hardware.
        userDataString += "0000" + "0000" + "0000"

        HexConverter.TxtPsocData.Text = userDataString.PadRight(2048, "f"c)
        Dim filePath = "" + programResources + helperDirectories(Hdir.FILES) + "PsocData.udata"

        ' Create or overwrite the file.
        Dim fs As FileStream = IO.File.Create(filePath)

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(HexConverter.TxtPsocData.Text)
        fs.Write(info, 0, info.Length)
        fs.Close()

        ' Dim dataNum = Enumerable.Range(0, userDataString.Length \ 2).Select(Function(y) userDataString.Substring(y * 2, 2))
        ' Dim dataSum = 0

        'convert data to hex base
        ' For x = 0 To dataNum.Count - 1
        '  dataSum += 0 + Convert.ToInt32(dataNum(x), 16)
        ' Next

        'Dim checksum = 1 + ((Not (64 + datasum)) Mod 256)

        'line length, address, data type 
        '":40" + Convert.ToString(0, 16).PadLeft(4, "0"c).ToUpper + "00" +
        'checksum
        ' Strings.Right(Convert.ToString(checksum, 16).PadLeft(2, "0"c).ToUpper, 2)
        'txtSerialIn1.Text = userDataString.PadRight(128, "0"c)
    End Sub

    ''' <summary>
    ''' Generates a factory password based off the current serial code
    ''' </summary>
    Private Sub FactoryPassGen()
        factoryPassword = ""
        For x = 0 To txtSerialCode.Text.Length - 1
            Select Case txtSerialCode.Text.Chars(x)
                Case = "0", "4", "8"
                    factoryPassword += "U"
                Case = "1", "5", "9"
                    factoryPassword += "R"
                Case = "2", "6"
                    factoryPassword += "D"
                Case = "3", "7"
                    factoryPassword += "L"
                Case Else
            End Select
        Next
    End Sub

    ''' <summary>
    ''' Calls all of the core functions for programming: Generates Psoc Data, calls CLI for Psoc and Atmel, and generates a log file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnProgram_Click(sender As Object, e As EventArgs) Handles BtnProgram.Click
        'ls -t | head -n1
        'search for last created file in the datalog directory, read its name, parse serial code from that(first 6 characters or chunk of name)

        'functionality is halted if serial code is all 0's(default value) or there is a previous successful attempt with the same code.
        If txtSerialCode.Text = "000000" And Not ChkDebug.Checked Then
            MsgBox("Please scan a barcode", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
        ElseIf txtSerialCode.Text = previousSerial And Not ChkDebug.Checked And Not prevFailed Then
            MsgBox("Please scan a new barcode", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
        Else
            PassFailImageHandler(Pf.gray)

            'checks that atmel hex file is there
            If File.Exists(AdminMenu.TxtAtmelHexFileLoc.Text) Then

                'size of the hex file used to calculate how much time is necessary for the function, maxtime used for progress bar
                fileSize = FileLen(AdminMenu.TxtAtmelHexFileLoc.Text)                '
                maxTime = 0.00007 * fileSize + 2.3
            Else
                MsgBox("Default Atmel Hex file not found!" + vbNewLine +
                       "Please choose a new one from the Admin Menu or replace the default.", vbCritical, "MFGR Helper 1.0")
                Exit Sub
            End If
            'checks that Psoc hex file is there
            If Not File.Exists(AdminMenu.TxtPsocHexFileLoc.Text) Then
                MsgBox("Default Psoc Hex file not found!" + vbNewLine +
                       "Please choose a new one from the Admin Menu or replace the default.", vbCritical, "MFGR Helper 1.0")
                Exit Sub
            End If
            File.SetAttributes(UserFieldIniLocation, FileAttributes.Normal)
            INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(2), technicalIni(1), "False")
            codeScanned = INIReadWrite.ReadINI(UserFieldIniLocation, iniSection(2), technicalIni(1))
            File.SetAttributes(UserFieldIniLocation, FileAttributes.ReadOnly)
            previousSerial = txtSerialCode.Text
            GeneratePsocData()
            'GenerateHexFile()

            'Both are used in sequence, Atmel -> Psoc
            'for debug all here for individual use
            ' CLI_Atmel()
            'both the Psoc CLI and log file will be called in series with the Atmel CLI
            psocDebug = True
            CLI_Psoc()
            'GenerateLogFile()
        End If
    End Sub

    ''' <summary>
    ''' Creates a batch file and starts background worker which will call the Atmel CLI as a process.
    ''' </summary>
    Private Sub CLI_Atmel()
        RawError = ""
        'disables fields and menus
        ProgramEnable(False)

        If File.Exists(batchLocation(0)) Then
            File.SetAttributes(batchLocation(0), FileAttributes.Normal)
        End If
        If File.Exists(atmelOutputLocation) Then
            File.SetAttributes(atmelOutputLocation, FileAttributes.Normal)
        End If
        TxtOutput.Text = "Programming Atmel..."

        parameters = {AdminMenu.TxtDefaultProgTool.Text, AdminMenu.TxtDefaultInterface.Text, AdminMenu.TxtDefaultDevice.Text}
        hexName = """" + AdminMenu.TxtAtmelHexFileLoc.Text + """"

        'write loadatmel.bat string to file
        Dim fs As FileStream = File.Create(batchLocation(0))
        Dim atmelBatch = "cd ""C:\Program Files (x86)\Atmel\Studio\7.0\atbackend""" + vbNewLine +
                         "c:" + vbNewLine +
                         "atprogram -t " + parameters(0) + " -i " + parameters(1) + " -d " + parameters(2) +
                         " chiperase program -f " + hexName + " verify -f " + hexName + " > """ + atmelOutputLocation + """ 2>&1"

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(atmelBatch)
        fs.Write(info, 0, info.Length)
        fs.Close()

        'wipes output file
        fs = File.Create(atmelOutputLocation)
        info = New UTF8Encoding(True).GetBytes("")
        fs.Write(info, 0, info.Length)
        fs.Close()

        second = 0
        t.Start()

        Atmel_bgw.WorkerReportsProgress = True
        Atmel_bgw.RunWorkerAsync()
    End Sub

    ''' <summary>
    ''' Performs the Atmel process, calling the CLI and using the hex file described in the admin menu.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Atmel_bgw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Atmel_bgw.DoWork
        'Comment out to show the window
        If Not ChkViewCLI.Checked Then
            AtmelProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        End If
        AtmelProc.StartInfo.FileName = batchLocation(0)
        AtmelProc.Start()

        Do While Not AtmelProc.HasExited
            Threading.Thread.Sleep(5)
            'if actual time overflows above max(may happen at very low values),
            'rectify it so the progress bar will not overflow
            If second > maxTime Then
                second = maxTime
            End If
            Atmel_bgw.ReportProgress(Convert.ToInt32((second / (maxTime)) * 5000))
        Loop
    End Sub

    ''' <summary>
    ''' Activated from DoWork with ReportProgress method, used to update the visual value of the progressbar.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Atmel_bgw_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles Atmel_bgw.ProgressChanged
        ProgramProgressBar.Value = e.ProgressPercentage
    End Sub

    ''' <summary>
    ''' When Atmel CLI process finishes, close it and the timer, finish the progress bar to full, call the output updater, and make the helper files readOnly.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Atmel_bgw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Atmel_bgw.RunWorkerCompleted
        AtmelProc.Close()
        t.Stop()

        'atprocesstime ini used to debug and find the values of how long different file sizes take to process on the atmel function.
        ' INIReadWrite.WriteINI(programLocation + helperDirectories(Hdir.INI) + "atprocessTime.ini", "1", FileLen(AdminMenu.TxtHexFileLocation.Text), second)

        UpdateOutputAtmel()

        File.SetAttributes(batchLocation(0), FileAttributes.ReadOnly)
        File.SetAttributes(atmelOutputLocation, FileAttributes.ReadOnly)
    End Sub

    ''' <summary>
    ''' Updates the output textbox with the atmel cli's output data.
    ''' </summary>
    Private Sub UpdateOutputAtmel()
        Dim fileReader As String = ""
        Dim maxAttempt As Integer = 100
        Dim errorType() As String
        Dim atmelError As String = "Atmel Program Failed!" + vbNewLine
        Dim check As String = "Check that the main device is on, reset, and try again."

        File.SetAttributes(UserFieldIniLocation, FileAttributes.Normal)

        For i As Integer = maxAttempt To 0 Step -1
            Try
                fileReader = My.Computer.FileSystem.ReadAllText(atmelOutputLocation)
                'Successful Quit
                Exit For
            Catch
                Threading.Thread.Sleep(300)
            End Try
        Next

        'parse output file
        'If programming was successful, do the Psoc CLI, if not, end.
        If fileReader = "Firmware check OK" + vbNewLine + "Chiperase completed successfully" + vbNewLine +
                        "Programming completed successfully." + vbNewLine + "Verification OK" + vbNewLine Then
            TxtOutput.Text = "Atmel Program Successful!" + vbNewLine '+ vbNewLine + "Please scan a new barcode..." + vbNewLine
            'wait on Psoc to know whether to show green or not
            'PassFailImageHandler(Pf.green)
            ' prevFailed = False
            INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(2), technicalIni(0), "False")
            prevFailed = INIReadWrite.ReadINI(UserFieldIniLocation, iniSection(2), technicalIni(0))

            CLI_Psoc()
        Else
            PassFailImageHandler(Pf.red)
            'If there is an error, parse it for the last printed line to see where error occurred
            TxtOutput.Text = atmelError + vbNewLine + check + vbNewLine + "For further error info, please check the Datalog." +
                             vbNewLine + vbNewLine + "Please scan a barcode..."
            errorType = Split(fileReader, vbNewLine)
            Select Case errorType(errorType.Length - 2)
                Case = "Firmware check OK"
                    atmelError += "[Error Info] A chip erase error occurred:" + vbNewLine +
                                 "-The device may not be powered on or it may have not been reset properly." + vbNewLine +
                                 "-Make sure you have the correct arguments for the device inputted."
                Case = "Chiperase completed successfully"
                    atmelError += "[Error Info] A write error occurred:" + vbNewLine +
                                 "-The device may have been turned off during programming or there may be an error in the code file." + vbNewLine +
                                 "-Make sure connection is not interrupted while underway."
                Case = "Programming completed successfully."
                    atmelError += "[Error Info] A verification error occurred:" + vbNewLine +
                                 "-The device may have been turned off during verification." + vbNewLine +
                                 "-Make sure connection is not interrupted while underway."
                Case Else
                    atmelError += "[Error Info] An unknown error occurred:" + vbNewLine
            End Select

            'RawError is a string used in the log file generator.
            RawError = vbNewLine +
                       "" + vbNewLine +
                       atmelError +
                       "-" + check + vbNewLine +
                       "" + vbNewLine +
                       "Raw Error Data:" + vbNewLine +
                       fileReader
            ' prevFailed = True
            INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(2), technicalIni(0), "True")
            prevFailed = INIReadWrite.ReadINI(UserFieldIniLocation, iniSection(2), technicalIni(0))

            ProgramProgressBar.Value = 0
            GenerateLogFile()
            ProgramEnable(True)
        End If
        'turn fields and menus on again
        File.SetAttributes(UserFieldIniLocation, FileAttributes.ReadOnly)
    End Sub

    Private Sub T1_Tick(sender As Object, e As EventArgs) Handles t.Tick
        second += 0.1
    End Sub



    ''' <summary>
    ''' Calls the Psoc CLI 
    ''' </summary>
    Private Sub CLI_Psoc()
        If File.Exists(batchLocation(1)) Then
            File.SetAttributes(batchLocation(1), FileAttributes.Normal)
        End If
        If File.Exists(psocOutputLocation) Then
            File.SetAttributes(psocOutputLocation, FileAttributes.Normal)
        End If
        If psocDebug Then
            TxtOutput.Text = "Programming Psoc..."
        Else
            TxtOutput.Text += "Programming Psoc..."
        End If

        'only here for debugging but does nothing when run normally anyway.
        ProgramEnable(False)

        'write Psoc.bat string to file
        Dim hexLocation = """" + AdminMenu.TxtPsocHexFileLoc.Text + """"
        'Create Psoc batch to run using the file at hexLocation and send output to psocOutputLocation
        Dim PsocBatch = "cd Resources\MFGR_CLI" + vbNewLine +
                        "C_sharp.exe " + hexLocation + " > """ + psocOutputLocation + """ 2>&1"
        Dim fs As FileStream = File.Create(batchLocation(1))
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(PsocBatch)
        fs.Write(info, 0, info.Length)
        fs.Close()

        'wipes output file
        fs = File.Create(psocOutputLocation)
        info = New UTF8Encoding(True).GetBytes("")
        fs.Write(info, 0, info.Length)
        fs.Close()

        second = 0
        t.Start()

        Psoc_bgw.WorkerReportsProgress = True
        Psoc_bgw.RunWorkerAsync()
    End Sub

    ''' <summary>
    ''' Performs the Psoc process, calling the CLI and using the hex file described in the admin menu.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Psoc_bgw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Psoc_bgw.DoWork
        Dim logFileStream As New FileStream(psocOutputLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        Dim logFileReader As New StreamReader(logFileStream)
        Dim lineSplit() As String
        Dim lines As New ArrayList
        'Comment out to show the window
        PsocProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        PsocProc.StartInfo.FileName = batchLocation(1)

        PsocProc.Start()
        Threading.Thread.Sleep(500)
        lines.Add(logFileReader.ReadLine())
        lines.Add(logFileReader.ReadLine())

        Do While lines(1) = "" Or lines(1) Is Nothing
            Threading.Thread.Sleep(1000)
            logFileReader.DiscardBufferedData()
            logFileReader.BaseStream.Seek(0, SeekOrigin.Begin)
            lines(0) = "" + logFileReader.ReadLine()
            lines(1) = "" + logFileReader.ReadLine()
            'still show some small progress even if the program stalls.
            Psoc_bgw.ReportProgress(Convert.ToInt32((second / (second + 1000)) * 5000) + 5000)
        Loop
        If Not Strings.Left(lines(1), 6) = "Failed" Then
            lineSplit = Split(lines(1), ": ")
            'vague approximation for the time required utilizing the linecount as a metric.
            maxTime2 = 0.025 * Convert.ToInt32(lineSplit(1))

            Do While Not PsocProc.HasExited
                Threading.Thread.Sleep(5)
                'if actual time overflows above max(may happen at very low values),
                'rectify it so the progress bar will not overflow

                If second > maxTime2 Then
                    second = maxTime2
                End If
                'max bar is 10000
                Psoc_bgw.ReportProgress(Convert.ToInt32((second / (maxTime2)) * 5000) + 5000)
            Loop
        End If
        logFileReader.Close()
        logFileStream.Close()
    End Sub

    ''' <summary>
    ''' Activated from DoWork with ReportProgress method, used to update the visual value of the progressbar.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Psoc_bgw_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles Psoc_bgw.ProgressChanged
        ProgramProgressBar.Value = e.ProgressPercentage
    End Sub

    ''' <summary>
    ''' When Psoc CLI process finishes, close it and the timer, finish the progress bar to full, call the output updater, and make the helper files readOnly.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Psoc_bgw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Psoc_bgw.RunWorkerCompleted
        PsocProc.Close()

        'bring bar quickly up to 90% then gradually to 100, hitting many values in the middle to smoothly transition up.
        For x = ProgramProgressBar.Value To 10000 - 1
            If x < 9000 Then
                ProgramProgressBar.Value = x + 1
                ProgramProgressBar.Value = x
                ProgramProgressBar.Value = x + 1
                x += 5
            Else
                ProgramProgressBar.Value = x + 1
                ProgramProgressBar.Value = x
                ProgramProgressBar.Value = x + 1
            End If
            'Threading.Thread.Sleep(1)
        Next

        ProgramProgressBar.Value = 10000
        ProgramProgressBar.Value = 10000 - 1
        ProgramProgressBar.Value = 10000

        Threading.Thread.Sleep(100)

        'atprocesstime ini used to debug and find the values of how long different file sizes take to process on the atmel function.
        'TODO: rework to estimate for different sizes of Psoc hex files.
        ' INIReadWrite.WriteINI(programLocation + helperDirectories(Hdir.INI) + "atprocessTime.ini", "1", FileLen(AdminMenu.TxtHexFileLocation.Text), second)

        UpdateOutputPsoc()

        File.SetAttributes(psocOutputLocation, FileAttributes.ReadOnly)
        File.SetAttributes(batchLocation(1), FileAttributes.ReadOnly)
    End Sub

    ''' <summary>
    ''' Updates the output textbox with the psoc cli's output data.
    ''' </summary>
    Private Sub UpdateOutputPsoc()
        Dim fileReader As String = ""
        Dim maxAttempt As Integer = 100
        Dim passFail(), lines() As String
        Dim PsocError As String = "Psoc Program Failed!" + vbNewLine
        Dim check As String = "Check that the main device is on, reset, and try again."

        File.SetAttributes(UserFieldIniLocation, FileAttributes.Normal)

        For i As Integer = maxAttempt To 0 Step -1
            Try
                fileReader = My.Computer.FileSystem.ReadAllText(psocOutputLocation)
                'Successful Quit
                Exit For
            Catch
                Threading.Thread.Sleep(100)
            End Try
        Next

        'take the output file in text form from filereader and parse it to then create a user friendly output string.
        lines = Split(fileReader, vbNewLine)
        passFail = Split(lines(lines.Length - 3), ": ")
        Select Case passFail(0)
            Case = "Succeeded:"
                PassFailImageHandler(Pf.green)
                TxtOutput.Text = TxtOutput.Text.Replace("Programming Psoc...", "Psoc Program Successful!" + vbNewLine + vbNewLine + "Please scan a new barcode..." + vbNewLine)

                'prevFailed = false
                INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(2), technicalIni(0), "False")
                prevFailed = INIReadWrite.ReadINI(UserFieldIniLocation, iniSection(2), technicalIni(0))
            Case = "Failed"
                PassFailImageHandler(Pf.red)
                TxtOutput.Text = TxtOutput.Text.Replace("Programming Psoc...", PsocError + vbNewLine + check + vbNewLine + "For further error info, please check the Datalog." +
                                 vbNewLine + vbNewLine + "Please scan a barcode...")

                'substrings to look for to determine which error has occurred.
                Dim substr() As String = {"Connect any MiniProg3/DVKProg/FirstTouch/Gen-FX2LP device To the PC",
                                          "respond packet contains Failed status",
                                          "Failed to send packet",
                                          "PSoC device is not acquired",
                                          "Firmware is not fully loaded and device cannot be detected"}
                '    device not connected
                If Not passFail(1).IndexOf(substr(0)) = -1 Then
                    PsocError += "[Error Info] Connection to the device failed:" + vbNewLine +
                                 "-Connect any MiniProg3/DVKProg/FirstTouch/Gen-FX2LP device To the PC" + vbNewLine
                    'reg pow off
                ElseIf Not passFail(1).IndexOf(substr(1)) = -1 Or Not passFail(1).IndexOf(substr(2)) = -1 Then
                    PsocError += "[Error Info] Communication to the device failed:" + vbNewLine +
                                 "-The device may have been turned off during programming or there may be an error in the code file" + vbNewLine +
                                 "-Make sure connection is not interrupted while underway." + vbNewLine
                    'early fail or device off on startup
                ElseIf Not passFail(1).IndexOf(substr(3)) = -1 Then
                    PsocError += "[Error Info] PSoC device did not connect:" + vbNewLine +
                                 "-Check connection of the chip to the programmer." + vbNewLine
                    'buggy not fully loaded state
                ElseIf Not passFail(1).IndexOf(substr(4)) = -1 Then
                    PsocError += "[Error Info] Firmware is not fully loaded and device cannot be detected:" + vbNewLine +
                                 "-Please reconnect your Psoc device." + vbNewLine
                    'any other error
                Else
                    PsocError += "[Error Info] An unknown error occurred:" + vbNewLine
                End If




                'RawError is a string used in the log file generator.
                RawError = vbNewLine +
                            "" + vbNewLine +
                            PsocError +
                            "-" + check + vbNewLine +
                            "" + vbNewLine +
                            "Raw Error Data:" + vbNewLine +
                            passFail(1)
                TxtTestBox.Text = RawError
                'prevFailed = true
                INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(2), technicalIni(0), "True")
                prevFailed = INIReadWrite.ReadINI(UserFieldIniLocation, iniSection(2), technicalIni(0))
        End Select

        'turn fields and menus on again
        ProgramProgressBar.Value = 0
        GenerateLogFile()
        ProgramEnable(True)
        ' File.SetAttributes(UserFieldIniLocation, FileAttributes.ReadOnly)
    End Sub


    ''' <summary>
    ''' Handles any changes to the PassFail image
    ''' </summary>
    ''' <param name="color">color is the input as an enum, Pf which can be chosen to be gray(invisible), green, or red</param>
    Public Sub PassFailImageHandler(color As Integer)
        Dim gp As New GraphicsPath
        PicPassFail.Image = Image.FromFile(programResources + helperDirectories(Hdir.IMAGES) + passFailImages(color))
        gp.AddEllipse(PicPassFail.DisplayRectangle)
        PicPassFail.Region = New Region(gp)
    End Sub
    Public Enum Pf
        gray = 0
        green = 1
        red = 2
    End Enum

    ''' <summary>
    ''' Handles turning on or off the program's fields and menus
    ''' </summary>
    ''' <param name="enableOn">true if enabling features, false if turning them off</param>
    Private Sub ProgramEnable(enableOn As Boolean)
        If enableOn Then
            'buttons
            BtnProgram.Enabled = True
            MnuFile.Enabled = True
            MnuOptions.Enabled = True

            'userfields
            ChkOutputLevel.Enabled = True
            ChkPumpMode.Enabled = True
            ChkPumpTime.Enabled = True
            ChkCellDelay1.Enabled = True
            ChkContrast.Enabled = True
            ChkBacklight.Enabled = True
            ChkForwardOnSec.Enabled = True
            ChkForwardOffSec.Enabled = True
            ChkReverseOnSec.Enabled = True
            ChkReverseOffSec.Enabled = True
            ChkDeadtimeSec.Enabled = True
            ChkInputGPM.Enabled = True
            ChkGPMOverride.Enabled = True
        Else
            'buttons
            BtnProgram.Enabled = False
            MnuFile.Enabled = False
            MnuOptions.Enabled = False

            'userfields
            ChkOutputLevel.Enabled = False
            ChkPumpMode.Enabled = False
            ChkPumpTime.Enabled = False
            ChkCellDelay1.Enabled = False
            ChkContrast.Enabled = False
            ChkBacklight.Enabled = False
            ChkForwardOnSec.Enabled = False
            ChkForwardOffSec.Enabled = False
            ChkReverseOnSec.Enabled = False
            ChkReverseOffSec.Enabled = False
            ChkDeadtimeSec.Enabled = False
            ChkInputGPM.Enabled = False
            ChkGPMOverride.Enabled = False

            'checks the field boxes to lock them in
            ChkOutputLevel.Checked = True
            ChkPumpMode.Checked = True
            ChkPumpTime.Checked = True
            ChkCellDelay1.Checked = True
            ChkContrast.Checked = True
            ChkBacklight.Checked = True
            ChkForwardOnSec.Checked = True
            ChkForwardOffSec.Checked = True
            ChkReverseOnSec.Checked = True
            ChkReverseOffSec.Checked = True
            ChkDeadtimeSec.Checked = True
            ChkInputGPM.Checked = True
            ChkGPMOverride.Checked = True
        End If
    End Sub

    ''' <summary>
    ''' Hides the main form and shows the AdminMenu at the loction of the main form.
    ''' </summary>
    Public Sub ShowAdminMenu()
        Dim formLoc As Point
        formLoc = Location()
        Hide()
        AdminMenu.Show()
        AdminMenu.SetDesktopLocation(formLoc.X, formLoc.Y)
    End Sub

    ''' <summary>
    ''' Toggles a textbox's ReadOnly parameter whenever its corresponding checkpoint is clicked.
    ''' </summary>
    ''' <param name="textbox1"></param>
    ''' <param name="checked"></param>
    Public Sub TextBoxToggle(textbox1 As TextBox, checked As Boolean)
        'Performs Checkbox functionality
        If checked Then
            textbox1.ReadOnly = True
        Else
            textbox1.ReadOnly = False
        End If
    End Sub

    ''' <summary>
    ''' Shows Admin Password form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OptionsMenuAdmin_Click(sender As Object, e As EventArgs) Handles MnuAdminSettings.Click
        AdminPass.ShowDialog()
    End Sub

    ''' <summary>
    ''' Calls the LoadAll function to reload everything.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnReloadInit_Click(sender As Object, e As EventArgs) Handles MnuReload.Click
        LoadAll(LoadX.init)
        MsgBox("Values reloaded!", MsgBoxStyle.OkOnly, "MFGR Helper 1.0")
    End Sub

    Private Sub FileMenuExit_Click(sender As Object, e As EventArgs) Handles MnuExit.Click
        Close()
    End Sub

    ''' <summary>
    ''' On program close, checks if there was a code scanned that was not used; if that is the case load the previous serial number used back
    ''' <para>This makes it so a serial code that is unused will not be defaulted and unusable directly even though it was not programmed already.</para>
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Main_Close(sender As Object, e As EventArgs) Handles Me.Closed
        If codeScanned Then
            File.SetAttributes(UserFieldIniLocation, FileAttributes.Normal)
            INIReadWrite.WriteINI(UserFieldIniLocation, iniSection(0), dataName(0).Replace(": ", ""), previousSerial)
            File.SetAttributes(UserFieldIniLocation, FileAttributes.ReadOnly)
        End If
        HexConverter.Close()
        AdminMenu.Close()
    End Sub

    ''' <summary>
    ''' checks what is in com ports, sets the portname if the scanner is found
    ''' </summary>
    Private Sub ComCheck()
        Dim identPnpPorts As New Dictionary(Of String, String)
        Dim identSerialPorts As New Dictionary(Of String, String)
        Dim portNameData As String
        Dim comPortNumber As String

        Try
            Dim portSearcher As New ManagementObjectSearcher("\root\CIMV2", "Select Name from Win32_PnPEntity")
            For Each port As System.Management.ManagementObject In portSearcher.Get()

                'this check is to eliminate all PNP entries except COM Port connections 
                '     (there are some USB to Serial Devices that install as as PNP Entities)

                If port("Name").ToString.ToUpper.Contains("(COM") Then
                    portNameData = port("Name").ToString
                    comPortNumber = port("Name").ToString.Substring(port("Name").ToString.IndexOf("(COM") + 4)
                    comPortNumber = comPortNumber.TrimEnd(")"c)
                    identPnpPorts.Add(comPortNumber, portNameData)
                End If
            Next
        Catch ex As Exception
            'Need to handle possible errors
        End Try

        Try
            Dim portSearcher As New ManagementObjectSearcher("\root\CIMV2", "Select DeviceID, Name, ProviderType from win32_SerialPort")
            For Each port As ManagementObject In portSearcher.Get()

                'the Provider type indicates the type of COM Port normally such as RS232/RS422/RS485

                portNameData = port("ProviderType").ToString & " - " & port("Name").ToString
                comPortNumber = port("DeviceID").ToString.Substring(3)
                identSerialPorts.Add(comPortNumber, portNameData)
            Next
        Catch ex As Exception
            'Need to handle the possible errors
        End Try

        'This next loop is to prevent duplication as some usb to serial devices will be in both the PNPEntity and 

        For Each foundPort As KeyValuePair(Of String, String) In identPnpPorts
            If Not identSerialPorts.ContainsKey(foundPort.Key) Then
                identSerialPorts.Add(foundPort.Key, foundPort.Value)
            End If
        Next

        'Searches available ports for the scanner
        For Each foundPort As KeyValuePair(Of String, String) In identSerialPorts
            'shows available ports
            'TxtTestBox.Text += foundPort.Value
            If Strings.Left(foundPort.Value, 12) = "Voyager-1250" Then
                portname = "COM" + foundPort.Key
            End If
        Next
    End Sub

    Private Sub TxtOutputLevel_TextChanged(sender As Object, e As EventArgs) Handles txtOutputLevel.TextChanged
        UserFieldHandler(txtOutputLevel)
    End Sub

    Private Sub TxtPumpMode_TextChanged(sender As Object, e As EventArgs) Handles txtPumpMode.TextChanged
        UserFieldHandler(txtPumpMode)
    End Sub

    Private Sub TxtPumpTime_TextChanged(sender As Object, e As EventArgs) Handles txtPumpTime.TextChanged
        UserFieldHandler(txtPumpTime)
    End Sub

    Private Sub TxtCellDelay1_TextChanged(sender As Object, e As EventArgs) Handles txtCellDelay1.TextChanged
        UserFieldHandler(txtCellDelay1)
    End Sub

    Private Sub TxtContrast_TextChanged(sender As Object, e As EventArgs) Handles txtContrast.TextChanged
        UserFieldHandler(txtContrast)
    End Sub

    Private Sub TxtBacklight_TextChanged(sender As Object, e As EventArgs) Handles txtBacklight.TextChanged
        UserFieldHandler(txtBacklight)
    End Sub

    Private Sub TxtForwardOnSec_TextChanged(sender As Object, e As EventArgs) Handles txtForwardOnSec.TextChanged
        UserFieldHandler(txtForwardOnSec)
    End Sub

    Private Sub TxtForwardOffSec_TextChanged(sender As Object, e As EventArgs) Handles txtForwardOffSec.TextChanged
        UserFieldHandler(txtForwardOffSec)
    End Sub

    Private Sub TxtReverseOnSec_TextChanged(sender As Object, e As EventArgs) Handles txtReverseOnSec.TextChanged
        UserFieldHandler(txtReverseOnSec)
    End Sub

    Private Sub TxtReverseOffSec_TextChanged(sender As Object, e As EventArgs) Handles txtReverseOffSec.TextChanged
        UserFieldHandler(txtReverseOffSec)
    End Sub

    Private Sub TxtDeadtimeSec_TextChanged(sender As Object, e As EventArgs) Handles txtDeadtimeSec.TextChanged
        UserFieldHandler(txtDeadtimeSec)
    End Sub

    Private Sub TxtInputGPM_TextChanged(sender As Object, e As EventArgs) Handles txtInputGPM.TextChanged
        UserFieldHandler(txtInputGPM)
    End Sub

    Private Sub TxtGPMOverride_TextChanged(sender As Object, e As EventArgs) Handles txtGPMOverride.TextChanged
        UserFieldHandler(txtGPMOverride)
    End Sub

    Private Sub ChkOutputLevel_CheckedChanged(sender As Object, e As EventArgs) Handles ChkOutputLevel.CheckedChanged
        TextBoxToggle(txtOutputLevel, ChkOutputLevel.Checked)
    End Sub

    Private Sub ChkPumpMode_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPumpMode.CheckedChanged
        TextBoxToggle(txtPumpMode, ChkPumpMode.Checked)
    End Sub

    Private Sub ChkPumpTime_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPumpTime.CheckedChanged
        TextBoxToggle(txtPumpTime, ChkPumpTime.Checked)
    End Sub

    Private Sub ChkCellDelay1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCellDelay1.CheckedChanged
        TextBoxToggle(txtCellDelay1, ChkCellDelay1.Checked)
    End Sub

    Private Sub ChkContrast_CheckedChanged(sender As Object, e As EventArgs) Handles ChkContrast.CheckedChanged
        TextBoxToggle(txtContrast, ChkContrast.Checked)
    End Sub

    Private Sub ChkBacklight_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBacklight.CheckedChanged
        TextBoxToggle(txtBacklight, ChkBacklight.Checked)
    End Sub

    Private Sub ChkForwardOnSec_CheckedChanged(sender As Object, e As EventArgs) Handles ChkForwardOnSec.CheckedChanged
        TextBoxToggle(txtForwardOnSec, ChkForwardOnSec.Checked)
    End Sub

    Private Sub ChkForwardOffSec_CheckedChanged(sender As Object, e As EventArgs) Handles ChkForwardOffSec.CheckedChanged
        TextBoxToggle(txtForwardOffSec, ChkForwardOffSec.Checked)
    End Sub

    Private Sub ChkReverseOnSec_CheckedChanged(sender As Object, e As EventArgs) Handles ChkReverseOnSec.CheckedChanged
        TextBoxToggle(txtReverseOnSec, ChkReverseOnSec.Checked)
    End Sub

    Private Sub ChkReverseOffSec_CheckedChanged(sender As Object, e As EventArgs) Handles ChkReverseOffSec.CheckedChanged
        TextBoxToggle(txtReverseOffSec, ChkReverseOffSec.Checked)
    End Sub

    Private Sub ChkDeadtimeSec_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDeadtimeSec.CheckedChanged
        TextBoxToggle(txtDeadtimeSec, ChkDeadtimeSec.Checked)
    End Sub

    Private Sub ChkInputGPM_CheckedChanged(sender As Object, e As EventArgs) Handles ChkInputGPM.CheckedChanged
        TextBoxToggle(txtInputGPM, ChkInputGPM.Checked)
    End Sub

    Private Sub ChkGPMOverride_CheckedChanged(sender As Object, e As EventArgs) Handles ChkGPMOverride.CheckedChanged
        TextBoxToggle(txtGPMOverride, ChkGPMOverride.Checked)
    End Sub
End Class

'''<summary>
''' Class used to read and write the values in ini files used for initialization.
''' </summary>
Class INIReadWrite

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String,
                                                        ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String,
                                                          ByVal lpFileName As String) As Boolean
    End Function

    Public Shared Function ReadINI(ByVal File As String, ByVal Section As String, ByVal Key As String) As String
        Dim sb As New StringBuilder(500)
        GetPrivateProfileString(Section, Key, "", sb, sb.Capacity, File)
        Return sb.ToString
    End Function

    Public Shared Sub WriteINI(ByVal File As String, ByVal Section As String, ByVal Key As String, ByVal Value As String)
        WritePrivateProfileString(Section, Key, Value, File)
    End Sub

End Class

''' <summary>
''' Class used to override the picturebox so that images for it can be circular.
''' </summary>
Public Class CirclePictureBox
    Inherits PictureBox
    Public CirclePictureBox()

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim brushImege As Brush

        Try
            Dim Imagem As New Bitmap(Image)
            'get images of the same size as control
            Imagem = New Bitmap(Imagem, New Size(Width - 1, Height - 1))
            brushImege = New TextureBrush(Imagem)
        Catch
            Dim Imagem As New Bitmap(Width - 1, Height - 1, PixelFormat.Format24bppRgb)
            Dim grp As Graphics = Graphics.FromImage(Imagem)
            Using (grp)
                grp.FillRectangle(Brushes.White, 0, 0, Width - 1, Height - 1)
                Imagem = New Bitmap(Width - 1, Height - 1, grp)

                brushImege = New TextureBrush(Imagem)
            End Using
        End Try

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim Path As New GraphicsPath()
        Path.AddEllipse(0, 0, Width - 1, Height - 1)
        e.Graphics.FillPath(brushImege, Path)
        e.Graphics.DrawPath(Pens.Black, Path)
    End Sub
End Class