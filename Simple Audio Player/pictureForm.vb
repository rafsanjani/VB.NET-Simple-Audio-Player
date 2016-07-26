Public Class pictureForm
    Dim img As System.Drawing.Image = Nothing
    Public Sub New(ByVal img As System.Drawing.Image)
        Me.img = img
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub pictureForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0
        Timer1.Enabled = True

        If Not img Is Nothing Then
            imageArea.Image = img.GetThumbnailImage(imageArea.Width, imageArea.Height, Nothing, IntPtr.Zero)
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Me.Opacity = 1 Then
            Timer1.Enabled = False
        Else
            Me.Opacity = Me.Opacity + 0.05
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Me.Opacity <= 0.05 Then
            Timer2.Enabled = False
            Close()
        Else
            Me.Opacity = Me.Opacity - 0.05
        End If

    End Sub

    Private Sub imageArea_Click(sender As Object, e As EventArgs) Handles imageArea.Click
        If Not Timer1.Enabled = True Then
            Timer2.Enabled = True
        End If

    End Sub
End Class