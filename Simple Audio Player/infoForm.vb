Imports System.Text

Public Class infoForm
    Dim fileTags As Music = Nothing
    Dim filePath As String = Nothing
    Dim duration As TimeSpan
    Dim artist, title, album, fileSize, genre, year, format As String
    Dim albumart As Image
    Private Sub infoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fileTags = New Music(filePath)
        txtFileName.Text = filePath

        Dim fileInfo As New IO.FileInfo(filePath)

        fileTags.SetAlbumTitle()
        fileTags.SetArtist()
        fileTags.SetBitrate()
        fileTags.SetDuration()
        fileTags.SetGenre()
        fileTags.SetSamplerate()
        fileTags.SetYear()
        fileTags.SetAlbumArt()

        artist = fileTags.GetArtist()
        album = fileTags.GetAlbumTitle()
        genre = fileTags.GetGenre()
        year = fileTags.GetYear()
        title = fileTags.GetTitle()
        duration = fileTags.GetDuration()

        lblTitle.Text = title
        lblArtist.Text = artist
        lblAlbum.Text = album
        lblGenre.Text = genre
        lblYear.Text = year
        lblFormat.Text = IO.Path.GetExtension(filePath).ToUpper.Substring(1)
        lblDuration.Text = duration.Minutes.ToString + ":" + duration.Seconds.ToString("D2")
        lblQuality.Text = CInt((fileTags.GetSamplerate() / 1000)).ToString() + "kHz, " + fileTags.GetBitrate().ToString + "kbps, " + fileTags.GetChannels.ToString

        albumart = fileTags.GetAlbumArt()
        Try
            imgAlbumArt.Image = albumart.GetThumbnailImage(imgAlbumArt.Width, imgAlbumArt.Height, Nothing, System.IntPtr.Zero)
        Catch ex As Exception
            albumart = My.Resources.DEFAULT_ALBUM_ART
            imgAlbumArt.Image = albumart.GetThumbnailImage(imgAlbumArt.Width, imgAlbumArt.Height, Nothing, System.IntPtr.Zero)
        End Try
        Dim totalSize As Integer = fileInfo.Length
        Dim mb As Double = fileInfo.Length / 1024 / 1024

        lblSize.Text = mb.ToString("N2") + " MB"
    End Sub

    Public Sub New(ByVal filePath As String)
        Me.filePath = filePath
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ALBUM_ART_MOUSEENTER(sender As Object, e As EventArgs) Handles imgAlbumArt.MouseEnter
        pnlAlbumArt.BackColor = Color.White
        Cursor = Cursors.Hand
    End Sub

    Private Sub ALBUM_ART_MOUSELEAVE(sender As Object, e As EventArgs) Handles imgAlbumArt.MouseLeave
        pnlAlbumArt.BackColor = Color.FromArgb(192, 192, 255)
        Cursor = Cursors.Default
    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub imgAlbumArt_Click(sender As Object, e As EventArgs) Handles imgAlbumArt.Click
        Dim _albumart As New pictureForm(albumart)
        _albumart.ShowDialog()
    End Sub
End Class