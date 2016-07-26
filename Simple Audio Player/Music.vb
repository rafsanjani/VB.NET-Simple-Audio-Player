Imports TagLib
Imports System.IO

Public Class Music
    Private myFilePath As String
    Private mySongTitle As String
    Private duration As TimeSpan
    Private myAlbumTitle, genre, artist As String
    Private bitrate, year, samplerate, channels As Integer
    Private mp3 As TagLib.File = Nothing
    Private albumart As Drawing.Image = Nothing

    Private tagsPresent As Boolean

    Public Sub New(ByVal filePath As String)
        myFilePath = filePath
        SetBasicTags()
    End Sub

    Private Sub SetBasicTags()
        Try
            mp3 = TagLib.File.Create(myFilePath)
            SetTitle()
            SetDuration()
            SetChannels()
            tagsPresent = True
        Catch ex As Exception
            tagsPresent = False
            Return
        End Try
    End Sub

    Public Function SetTitle()
        Try
            mySongTitle = mp3.Tag.Title
        Catch ex As Exception
            '   mySongTitle = ""
        End Try

        Return mySongTitle
    End Function
    Public Function GetAlbumArt() As Drawing.Image
        Return albumart
    End Function

    Public Sub SetAlbumArt()
        If mp3.Tag.Pictures.Length > 0 Then
            Dim pic As IPicture = mp3.Tag.Pictures(0)
            Dim ms As New MemoryStream(pic.Data.Data)
            If Not ms Is Nothing And ms.Length > 4096 Then
                albumart = System.Drawing.Image.FromStream(ms)
                ms.Close()
            End If
        End If
    End Sub

    Public Function HasTags() As Boolean
        Return tagsPresent
    End Function

    Public Sub SetGenre()
        genre = mp3.Tag.FirstGenre
    End Sub

    Public Sub SetAlbumTitle()
        Try
            myAlbumTitle = mp3.Tag.Album
        Catch ex As Exception
            myAlbumTitle = ""
        End Try

    End Sub
    Public Sub SetYear()
        year = mp3.Tag.Year
    End Sub

    Public Function GetArtist() As String
        Return artist
    End Function

    Public Function GetGenre() As String
        Return genre
    End Function

    Public Sub SetArtist()
        Try
            artist = mp3.Tag.Performers(0)
        Catch ex As Exception
            artist = ""
        End Try

    End Sub
    Public Sub SetSamplerate()
        samplerate = mp3.Properties.AudioSampleRate
    End Sub

    Public Sub SetBitrate()
        bitrate = mp3.Properties.AudioBitrate
    End Sub
    Public Function GetBitrate() As String
        Return bitrate.ToString
    End Function

    Public Function GetSamplerate() As String
        Return samplerate.ToString
    End Function

    Public Function GetYear() As String
        If year <> 0 Then
            Return year.ToString
        End If
        Return ""
    End Function

    Public Function GetTitle() As String

        If mySongTitle = Nothing Then
            Return IO.Path.GetFileNameWithoutExtension(myFilePath)
        End If

        Return mySongTitle
    End Function

    Public Function GetFilePath() As String
        Try
            Return myFilePath
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function GetDuration() As TimeSpan

        If duration = Nothing Then
            Return New TimeSpan(0, 0, 0)
        End If

        Return duration
    End Function

    Public Sub SetDuration()
        duration = mp3.Properties.Duration
    End Sub

    Public Function GetAlbumTitle() As String
        Return myAlbumTitle
    End Function

    Public Function GetAudioBitrate() As Integer
        Return bitrate
    End Function

    Public Sub SetChannels()
        channels = mp3.Properties.AudioChannels
    End Sub

    Public Function GetChannels()
        Return channels
    End Function
End Class
