Public Class PortNotify
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
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Timer1.Stop()
        AnimateWindow(Me.Handle.ToInt32, 150, AW_SLIDE Or AW_VER_POSITIVE Or AW_HIDE)
        Me.Close()
    End Sub

    Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
        Get
            Return True
        End Get
        ''No stealing focus from Form1. ;)
    End Property
    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles Label1.MouseEnter
        Label1.Font = New Font(Label1.Font, FontStyle.Bold)
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.Font = New Font(Label1.Font, FontStyle.Bold = 0)
    End Sub

    Private Sub PortNotify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
        Label3.Text = "Port Status: " & Form1.Label15.Text & vbCrLf & "Checked Host: " & Form1.Host.Text & vbCrLf & "Checked Port: " & Form1.Port.Text

        Me.Location = New Point(SystemInformation.WorkingArea.Right - Me.Width, SystemInformation.WorkingArea.Bottom - Me.Height)
        ' AnimateWindow(Me.Handle.ToInt32, 500, AW_SLIDE Or AW_VER_NEGATIVE)
        AnimateWindow(Me.Handle.ToInt32, 250, AW_SLIDE Or AW_HOR_NEGATIVE)
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)

        e.Graphics.DrawRectangle(Pens.Black, rect)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        AnimateWindow(Me.Handle.ToInt32, 250, AW_SLIDE Or AW_VER_POSITIVE Or AW_HIDE)
        Me.Close()
    End Sub
End Class