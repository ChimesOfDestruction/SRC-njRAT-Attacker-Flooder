Public Class SplashScreen

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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        AnimateWindow(Me.Handle.ToInt32, 500, AW_BLEND Or AW_ACTIVATE)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        AnimateWindow(Me.Handle.ToInt32, 500, AW_BLEND Or AW_HIDE)
        Form1.Show()
        Me.Visible = False
    End Sub
End Class