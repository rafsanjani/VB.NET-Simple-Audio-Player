﻿Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Xml
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.FileIO


Public Class MainForm
    Private WithEvents MusicControl As New Audio()


    Private _currentMusic As Music = Nothing
    Const AppName As String = "Rafs Simple Audio Player"

    '    Public WithEvents lblSlideTimer As New System.Timers.Timer

    Private _initPos As Integer
    Private _initPlaylistItemCount As Integer
    Private _shuffle As Boolean = False
    Private _repeat As Boolean = False
    ' Private normalPlay As Boolean = True

    Private ReadOnly _playedItems As New Stack(Of Integer)

    ReadOnly _logouc As New Logo_UC
    ReadOnly _spectrum As New Spectrum_UC
    Dim _playingFileIndex As Integer = 0


    Private Sub nextButton_MouseDown(sender As Object, e As MouseEventArgs) Handles nextButton.MouseDown
        nextButton.Top = nextButton.Top + 3
    End Sub


    Private Sub PictureBox3_MouseEnter(sender As Object, e As EventArgs) Handles nextButton.MouseEnter
        nextButton.Image = My.Resources.next_icon_pressed
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles nextButton.MouseLeave
        '  nextButton.Top = nextButton.Top - 3
        nextButton.Image = My.Resources.next_icon_normal

    End Sub

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles playButton.MouseDown
        playButton.Top = playButton.Top + 3
    End Sub

    Private Sub PictureBox1_MouseEnter1(sender As Object, e As EventArgs) Handles playButton.MouseEnter
        If MusicControl.GetState = Audio.PlayerState.Stopped Or MusicControl.GetState = Audio.PlayerState.Paused Then
            playButton.Image = My.Resources.play_icon_pressed
        Else
            playButton.Image = My.Resources.paused_icon_pressed
        End If

    End Sub

    Private Sub PictureBox1_MouseLeave1(sender As Object, e As EventArgs) Handles playButton.MouseLeave
        If MusicControl.GetState = Audio.PlayerState.Stopped Or MusicControl.GetState = Audio.PlayerState.Paused Then
            playButton.Image = My.Resources.play_icon_normal
        Else
            playButton.Image = My.Resources.paused_icon_normal
        End If

    End Sub

    Private Sub playButton_MouseLeave(sender As Object, e As EventArgs) Handles playButton.MouseUp
        playButton.Top = playButton.Top - 3
    End Sub


    Private Sub stopButton_Click(sender As Object, e As EventArgs) Handles stopButton.MouseDown
        stopButton.Top = stopButton.Top + 3
    End Sub

    Private Sub stopButton_MouseEnter(sender As Object, e As EventArgs) Handles stopButton.MouseEnter
        stopButton.Image = My.Resources.stop_icon_pressed
    End Sub

    Private Sub stopButton_MouseLeave(sender As Object, e As EventArgs) Handles stopButton.MouseLeave
        stopButton.Image = My.Resources.stop_icon_normal
    End Sub

    Private Sub stopButton_MouseUp(sender As Object, e As MouseEventArgs) Handles stopButton.MouseUp
        stopButton.Top = stopButton.Top - 3
    End Sub

    Private Sub prevButton_MouseDown(sender As Object, e As MouseEventArgs) Handles prevButton.MouseDown
        prevButton.Top = prevButton.Top + 3
    End Sub

    Private Sub prevButton_MouseEnter(sender As Object, e As EventArgs) Handles prevButton.MouseEnter
        prevButton.Image = My.Resources.previous_icon_pressed
    End Sub

    Private Sub prevButton_MouseLeave(sender As Object, e As EventArgs) Handles prevButton.MouseLeave
        prevButton.Image = My.Resources.previous_icon_normal
    End Sub

    Private Sub prevButton_MouseUp(sender As Object, e As MouseEventArgs) Handles prevButton.MouseUp
        prevButton.Top = prevButton.Top - 3
    End Sub

    Private Sub nextButton_MouseUp(sender As Object, e As MouseEventArgs) Handles nextButton.MouseUp
        nextButton.Top = nextButton.Top - 3
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles trkVolumeSlider.Scroll
        MusicControl.SetVolume(trkVolumeSlider.Value / 10)
        lblVolText.Text = (trkVolumeSlider.Value * 10).ToString() + "%"
    End Sub

    Private Sub lvPlaylist_KeyDown(sender As Object, e As KeyEventArgs) Handles lvPlaylist.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                ActivateItem()

            Case Keys.Delete
                DeleteItem()
        End Select


    End Sub


    Private Sub ListView1_ItemDoubleClicked(sender As Object, e As EventArgs) Handles lvPlaylist.MouseDoubleClick

        ActivateItem()
    End Sub

    Private Sub ActivateItem()
        lblSongInfo.Left = _initPos
        If MusicControl.GetState = Audio.PlayerState.Playing Or MusicControl.GetState = Audio.PlayerState.Paused Then
            MusicControl.StopMusic()
        End If

        'SAVE THE CURRENT FILE'S INDEX 
        _playingFileIndex = lvPlaylist.FocusedItem.Index

        MusicControl.PlayMusic(lvPlaylist.Items(lvPlaylist.FocusedItem.Index).Tag.ToString)
        MusicControl.SetVolume(trkVolumeSlider.Value / 10)
    End Sub

    ''DEBUGGING CONTROL
    'Private Sub ShowLog(ByVal msg As Object)
    '    '  rtb.Text = msg.ToString() + vbNewLine + rtb.Text + "------------------------"
    'End Sub
    Dim _volBeforeCrossFade As Double
    Dim _crossVol As Double

    Private Sub stopButton_Click_1(sender As Object, e As EventArgs) Handles stopButton.Click
        ' Dim currentVolume = CDbl(lblVolText.Text / 10)


        'MusicControl.StopMusic()
        'trkBarSeek1.Value = 0

        CrossFade()
    End Sub

    Private Sub CrossFade()
        _volBeforeCrossFade = CDbl(lblVolText.Text.Substring(0, lblVolText.Text.Length - 1) / 100)
        _crossVol = _volBeforeCrossFade
        myTimer1.Enabled = True
    End Sub

    Private Sub myTimer1_Tick(sender As Object, e As EventArgs) Handles myTimer1.Tick
        If _crossVol > 0 Then
            _crossVol -= 0.1
            MusicControl.SetVolume(_crossVol)
        Else
            MusicControl.StopMusic()
            MusicControl.SetVolume(_volBeforeCrossFade)
            trkBarSeek1.Value = 0
            myTimer1.Enabled = False
        End If

    End Sub



    'Dim volBeforeCrossFade, crossVol As Double
    'Private Sub CrossFade()
    '    volBeforeCrossFade = CDbl(lblVolText.Text.Substring(0, lblVolText.Text.Length - 1) / 100)

    '    crossVol = volBeforeCrossFade
    '    crossFadeTimer.Enabled = True
    'End Sub

    'Private Sub crossFadeTimer_Tick(sender As Object, e As EventArgs) Handles crossFadeTimer.Tick
    '    Me.Text = "running"
    '    If crossVol > 0 Then
    '        crossVol -= 0.1
    '        MusicControl.SetVolume(crossVol)
    '        Me.Text = "greater than 0"
    '    Else
    '        MusicControl.SetVolume(volBeforeCrossFade)
    '        MusicControl.StopMusic()
    '        crossFadeTimer.Enabled = False
    '        trkBarSeek1.Value = 0

    '    End If

    'End Sub



    Private Sub playButton_Click(sender As Object, e As EventArgs) Handles playButton.Click
        If lvPlaylist.Items.Count <> 0 Then
            OnPlay()
            Return
        End If
        OpenFiles()

    End Sub

    Private Sub OnPlay()
        If MusicControl.GetState = Audio.PlayerState.Playing Then
            MusicControl.PauseMusic()

        ElseIf MusicControl.GetState = Audio.PlayerState.Paused Then
            MusicControl.ResumeMusic()

        ElseIf MusicControl.GetState = Audio.PlayerState.Stopped Then
            'load selected item from playlist and start playing
            'CHECK WHETHER AN ITEM IS FOCUSED AND WHETHER THERE ARE ITEMS STILL IN THE PLAYLIST
            Try
                _playingFileIndex = lvPlaylist.FocusedItem.Index
                MusicControl.PlayMusic(lvPlaylist.Items(lvPlaylist.FocusedItem.Index).Tag.ToString)

            Catch ex As Exception
                'NO ITEM IS SELECTED FROM PLAYLIST SO DO NOTHING
            End Try

        End If

        MusicControl.SetVolume(trkVolumeSlider.Value / 10)
    End Sub

    Dim _files() As String
    Private Sub ListView1_DragDrop(sender As Object, e As DragEventArgs) Handles lvPlaylist.DragDrop
        _files = e.Data.GetData(DataFormats.FileDrop)
        bw.RunWorkerAsync(_files)
    End Sub

    'RECURSIVELY ADD FILES TO THE PLAYLIST
    Private Sub AddToPlaylist(ByVal targetDirectory As String)
        If Directory.Exists(targetDirectory) Then
            Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
            ' Process the list of files found in the directory.
            Dim fileName As String
            For Each fileName In fileEntries
                'ListView1.Invoke(Sub() ListView1.Items.Add(fileName))
                Processfile(fileName)
            Next fileName
            Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
            ' Recurse into subdirectories of this directory.
            Dim subdirectory As String
            For Each subdirectory In subdirectoryEntries
                AddToPlaylist(subdirectory)
            Next subdirectory
        Else
            Processfile(targetDirectory)
        End If

    End Sub

    Private Sub Processfile(ByVal musicFile As String)
        If Path.GetExtension(musicFile) = ".mp3" Then
            Dim myMusic As New Music(musicFile)
            Dim item As New ListViewItem

            Dim sec As Integer
            Dim min As Integer
            'Dim llength As Integer

            Try
                item = New ListViewItem(myMusic.GetTitle.ToString)
            Catch ex As Exception
                'MsgBox(ex.Message) ' for testing only
            End Try

            item.Tag = myMusic.GetFilePath
            Dim tss As TimeSpan = myMusic.GetDuration

            If tss.Minutes = 0 And tss.Seconds = 0 Then
                'SOMETHING WAS WRONG ACQUIRING THIS PROPERTY, SET IT USING BASS
                Dim temp As New Audio(musicFile)
                tss = temp.GetTotalTime()
                '  temp.Dispose()
            End If

            'EVERYTHING WENT OKAY, PROCEED
            sec = tss.Seconds
            min = tss.Minutes

            item.SubItems.Add(min.ToString + ":" + sec.ToString("D2"))
            lvPlaylist.Invoke(Sub() lvPlaylist.Items.Add(item))
        End If

    End Sub


    Private Sub ListView1_DragEnter(sender As Object, e As DragEventArgs) Handles lvPlaylist.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub


    Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw.DoWork
        _initPlaylistItemCount = lvPlaylist.Items.Count

        Dim aFile() As String = e.Argument
        Dim totalFiles As Integer = aFile.Length
        Dim count As Integer

        For Each file In aFile
            AddToPlaylist(file)
            count += 1
            bw.ReportProgress(count / totalFiles * 100)
        Next
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        'If there was no item in the playlist prior to the addition of these entries, start playing the first file
        If _initPlaylistItemCount = 0 And MusicControl.GetState() <> Audio.PlayerState.Playing Then
            _playingFileIndex = 0
            MusicControl.PlayMusic(lvPlaylist.Items(0).Tag.ToString)
        End If

    End Sub


    Private Sub MediaPaused() Handles MusicControl.MediaPaused

        lblPlayerState.Text = "  PAUSED: "
        musicTimer.Enabled = False

        playButton.Image = My.Resources.play_icon_normal
        Text = AppName + " - Paused"
    End Sub

    Private Sub MusicControl_MediaPlaying() Handles MusicControl.MediaPlaying
        'TODO EVENT HANDLING CODE HERE

        MusicControl.SetVolume(trkVolumeSlider.Value / 10)
        _spectrum.Show()
        _logouc.Hide()

        Try
            SetCurrentItemColors()
        Catch ex As Exception
            'COOL EXCEPTION
        End Try

        Try
            lvPlaylist.EnsureVisible(_playingFileIndex)
        Catch ex As Exception
        End Try

        Dim streamLength As Long = MusicControl.GetLength()
        trkBarSeek1.Maximum = streamLength / 100

        lblPlayerState.Text = "  PLAYING: "
        musicTimer.Enabled = True
        playButton.Image = My.Resources.paused_icon_normal

        Try
            _currentMusic = New Music(MusicControl.GetCurrentFile())
            _currentMusic.SetArtist()
            _currentMusic.SetSamplerate()
            _currentMusic.SetBitrate()

            Dim a As TimeSpan = _currentMusic.GetDuration()
            lblSongInfo.Text = "  " + _currentMusic.GetArtist() + " - " + _currentMusic.GetTitle() + " :: " + CInt((_currentMusic.GetSamplerate() / 1000)).ToString() + "kHz, " + _currentMusic.GetBitrate().ToString + "kbps, " + a.Minutes.ToString() + ":" + a.Seconds.ToString("D2") + "  "
        Catch ex As Exception
            lblSongInfo.Text = "  " + Path.GetFileNameWithoutExtension(_currentMusic.GetFilePath()) + "  "

            'SET SONG INFO TO JUST FILENAME
        End Try

        Text = AppName + " - Playing"
    End Sub

    Private Sub MusicControl_MediaStopped() Handles MusicControl.MediaStopped
        'TODO EVENT HANDLING CODE HERE
        'RAISED WHEN THE PLAYING ITEM IS STOPPED EITHER BY ACTIVATING AN ITEM ON THE PLAYLIST OR BY CLICKING THE STOP BUTTON

        DoMediaStop()
        Text = AppName + " - Stopped"
    End Sub


    Private Sub DoMediaStop()
        lblPlayerState.Text = "STOPPED: "
        lblDuration.Text = "0:00/0:00"
        _logouc.Show()
        _spectrum.Hide()

        MusicControl.SeekFile(0)
        trkBarSeek1.Value = 0
        musicTimer.Enabled = False

        playButton.Image = My.Resources.play_icon_normal
        Try
            SetPrevItemColors()
        Catch ex As Exception
        End Try


    End Sub

    Private Sub mainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'SAVE APPLICATION STATE AND EXIT
        'Me.Hide()
        SaveSettings()
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVolText.Text = (trkVolumeSlider.Value * 10).ToString + "%"
        _initPos = lblSongInfo.Left

        pnlUtility.Controls.AddRange({_logouc, _spectrum})
        _logouc.Show() : _logouc.Dock = DockStyle.Fill
        _spectrum.Show() : _spectrum.Dock = DockStyle.Fill

        'PROCESS COMMAND LINE ARGUMENTS
        Dim cmdArgs As String() = Environment.GetCommandLineArgs()

        'set the application's height to hide the playlist on startup

        If cmdArgs.Length <> 1 Then
            If PreviousInstanceRunning() Then
                KillPreviousinstances()
            End If
            cmdBW.RunWorkerAsync(cmdArgs)
        Else
            LoadSettings()
        End If

    End Sub

    Private Function PreviousInstanceRunning() As Boolean
        Dim x As Integer
        For Each p As Process In Process.GetProcesses()
            If p.ProcessName.Contains("Simple Audio Player") Then
                x = x + 1
            End If
        Next

        Return x > 1

    End Function

    Private Sub KillPreviousinstances()
        For Each p In Process.GetProcesses()
            Try
                If p.MainWindowTitle.Contains("Stopped") Or p.MainWindowTitle.Contains("Playing") Or p.MainWindowTitle.Contains("Paused") Then
                    p.Kill()
                End If
            Catch ex As Win32Exception

            Catch ex As InvalidOperationException
            End Try
        Next p
    End Sub


    Dim _moveRight As Boolean = False
    Dim _moveLeft As Boolean = True

    Private Sub LoadSettings()
        trkVolumeSlider.Value = My.Settings.Volume

        MusicControl.SetVolume(trkVolumeSlider.Value / 10)
        lblVolText.Text = (trkVolumeSlider.Value * 10).ToString() + "%"
        Location = My.Settings.Location

        'Loadplaylist and leave the rest to the background thread to handle
        'LoadPlaylist()
        plLoader.RunWorkerAsync()

    End Sub

    Private Sub LoadPlaylist()

        Dim mitem As ListViewItem

        Dim doc As New XmlDocument
        ' doc.Load(Application.StartupPath + "\Playlist.xml")
        Try
            doc.Load(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Simple Audio Player\Playlist.xml")
        Catch ex As Exception
            My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Simple Audio Player")
            Return
        End Try

        Dim nl As XmlNodeList = doc.GetElementsByTagName("Music")


        For Each node As XmlNode In nl
            mitem = New ListViewItem(node("Title").InnerText)
            mitem.SubItems.Add(node("Duration").InnerText)
            mitem.Tag = node("Path").InnerText
            lvPlaylist.Invoke(Sub() lvPlaylist.Items.Add(mitem))
            '  lvPlaylist.Items.Add(mitem)

        Next

        GC.Collect()
        GC.WaitForPendingFinalizers()

        'Return nl.Count
    End Sub
    Private Sub SaveSettings()
        My.Settings.Location = Location

        My.Settings.Volume = (trkVolumeSlider.Value)
        My.Settings.LastFileIndex = _playingFileIndex
        My.Settings.PlayingPosition = MusicControl.GetPosition()
        My.Settings.PlayerState = MusicControl.GetState.ToString()

        SavePlaylist()

    End Sub

    Private Sub SavePlaylist()
        'Dim writer As New XmlTextWriter(Application.StartupPath + "\Playlist.xml", Encoding.UTF8)
        Dim writer As XmlTextWriter
        Try
            writer = New XmlTextWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Simple Audio Player\Playlist.xml", Encoding.UTF8)
        Catch ex As Exception
            Return
        End Try
        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        writer.WriteStartElement("Playlist")
        For Each item As ListViewItem In lvPlaylist.Items
            createNode(item.Text, item.Tag, item.SubItems(1).Text, writer)
        Next
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()

        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub



    Private Sub createNode(songTitle As String, songFilePath As String, duration As String, writer As XmlTextWriter)
        writer.WriteStartElement("Music")
        writer.WriteStartElement("Title")
        writer.WriteString(songTitle)
        writer.WriteEndElement()
        writer.WriteStartElement("Path")
        writer.WriteString(songFilePath)
        writer.WriteEndElement()
        writer.WriteStartElement("Duration")
        writer.WriteString(Duration)
        writer.WriteEndElement()
        writer.WriteEndElement()
    End Sub

    Private Sub SlideText()
        Const padding As Integer = 5

        If _moveLeft Then
            If lblSongInfo.Right - padding > pnlSongInfo.ClientSize.Width Then
                lblSongInfo.Left = lblSongInfo.Left - 1
                _moveRight = True
            Else
                _moveLeft = False
                _moveRight = True
            End If

        ElseIf _moveRight Then

            If lblSongInfo.Left < lblPlayerState.ClientSize.Width Then
                lblSongInfo.Left = lblSongInfo.Left + 1
            Else
                _moveLeft = True
                _moveRight = False
            End If
        End If
    End Sub

    Private Sub sTimer_Tick(sender As Object, e As EventArgs) Handles sTimer.Tick
        _spectrum.SetAudioSource()
    End Sub


    Private Sub nextButton_MouseLeave(sender As Object, e As EventArgs) Handles nextButton.MouseLeave
        nextButton.Image = My.Resources.next_icon_normal
    End Sub

    Private Sub musicTimer_Tick(sender As Object, e As EventArgs) Handles musicTimer.Tick

        'checks whether media is done playing or not if yes, raises an event else take P.C to next statement
        MusicControl.CheckPlayerState()

        Dim dt, ds As TimeSpan

        Dim secs As Short
        Dim mins As Short

        dt = _currentMusic.GetDuration()
        ds = MusicControl.GetElapsedTime()

        secs = dt.Seconds
        mins = dt.Minutes

        If secs = 0 Or mins = 0 Then
            dt = MusicControl.GetTotalTime()
            secs = dt.Seconds
            mins = dt.Minutes
        End If

        lblDuration.Text = ds.Minutes.ToString + ":" + ds.Seconds.ToString("D2") + "/" + mins.ToString + ":" + secs.ToString("D2")

        UpdateSlider()
    End Sub

    Private Sub MediaFinished() Handles MusicControl.MediaCompleted

        'PLAYING FILE IS AT THE END NOW SO MOVE TO NEXT IF PLAYLIST IS NOT EMPTY, ELSE STOP
        If lvPlaylist.Items.Count <> 0 Then
            SkipTrack(True)
        Else
            DoMediaStop()
        End If

    End Sub

    Private Sub SkipTrack(Optional ByVal nextTrack As Boolean = False)
        'PLAY ANOTHER FILE IF PLAYLIST IS NOT EMPTY
        'CHECK WHETHER WE ARE THE END OF THE LIST, IF TRUE THEN RETURN TO THE TOP
        Try
            SetPrevItemColors()
        Catch ex As Exception
            'DO NOTHING EXCEPTION
        End Try

        If _shuffle Then
            _playedItems.Push(_playingFileIndex)
            _playingFileIndex = GetRandomIndex()
            MusicControl.PlayMusic(lvPlaylist.Items(_playingFileIndex).Tag.ToString)

        ElseIf _repeat Then
            MusicControl.PlayMusic(lvPlaylist.Items(_playingFileIndex).Tag.ToString)
        Else
            If nextTrack Then ' SKIP FORWARD
                If _playingFileIndex + 1 >= lvPlaylist.Items.Count Then
                    _playingFileIndex = 0
                Else
                    _playingFileIndex += 1
                End If

                MusicControl.PlayMusic(lvPlaylist.Items(_playingFileIndex).Tag.ToString)

            Else ' PREVIOUS
                If _playingFileIndex - 1 < 0 Then
                    _playingFileIndex = lvPlaylist.Items.Count - 1
                Else
                    _playingFileIndex -= 1
                End If

                MusicControl.PlayMusic(lvPlaylist.Items(_playingFileIndex).Tag.ToString)

            End If
        End If

        MusicControl.SetVolume(trkVolumeSlider.Value / 10)

    End Sub


    Private Sub SetPrevItemColors()
        If lvPlaylist.Items.Count <> 0 Then
            lvPlaylist.Items(_playingFileIndex).BackColor = Color.Transparent
            lvPlaylist.Items(_playingFileIndex).ForeColor = Color.White
            lvPlaylist.Items(_playingFileIndex).SubItems(1).BackColor = Color.Transparent
            lvPlaylist.Items(_playingFileIndex).SubItems(1).ForeColor = Color.White
        End If

    End Sub

    Private Sub SetCurrentItemColors()
        lvPlaylist.Items(_playingFileIndex).BackColor = Color.Aquamarine
        lvPlaylist.Items(_playingFileIndex).ForeColor = Color.Black
        lvPlaylist.Items(_playingFileIndex).SubItems(1).BackColor = Color.Aquamarine
        lvPlaylist.Items(_playingFileIndex).SubItems(1).ForeColor = Color.Black
    End Sub

    Private Sub UpdateSlider()

        Dim a As Int32 = MusicControl.GetPosition / 100

        If a <= trkBarSeek1.Maximum Then trkBarSeek1.Value = a Else trkBarSeek1.Value = 0

    End Sub

    Private Sub trkBarSeek_ValueChanged(sender As Object, e As EventArgs) Handles trkBarSeek1.Scroll, trkBarSeek1.Click
        MusicControl.SeekFile(trkBarSeek1.Value * 100)
    End Sub



    Private Sub openButton_Click(sender As Object, e As EventArgs) Handles openButton.Click
        OpenFiles()
    End Sub

    Private Sub OpenFiles()
        If dlgOpenFile.ShowDialog = DialogResult.OK Then
            bw.RunWorkerAsync(dlgOpenFile.FileNames)
        End If
    End Sub


    Private Sub tmrLabelTimer_Tick(sender As Object, e As EventArgs) Handles tmrLabelTimer.Tick
        SlideText()
    End Sub

    Private Sub openButton_MouseDown(sender As Object, e As MouseEventArgs) Handles openButton.MouseDown
        openButton.Top = openButton.Top + 3
    End Sub

    Private Sub openButton_MouseEnter(sender As Object, e As EventArgs) Handles openButton.MouseEnter
        openButton.Image = My.Resources.open_icon_pressed
    End Sub

    Private Sub openButton_MouseLeave(sender As Object, e As EventArgs) Handles openButton.MouseLeave
        openButton.Image = My.Resources.open_icon_normal
    End Sub

    Private Sub openButton_MouseUp(sender As Object, e As MouseEventArgs) Handles openButton.MouseUp
        openButton.Top = openButton.Top - 3
    End Sub

    Private Sub nextButton_Click(sender As Object, e As EventArgs) Handles nextButton.Click
        If lvPlaylist.Items.Count <> 0 Then
            MusicControl.StopMusic()
            SkipTrack(True)
        End If

    End Sub

    Private Function GetRandomIndex() As Integer
        Dim ranNum As Integer
        Dim plstCount As Integer

        plstCount = lvPlaylist.Items.Count
        Dim rnd As New Random

        Do
            ranNum = rnd.Next(0, plstCount)
        Loop While IsPlayed(ranNum)

        If _playedItems.Count - 1 = lvPlaylist.Items.Count Then
            _playedItems.Clear()
        Else

        End If


        Return ranNum

    End Function

    Private Function IsPlayed(ByVal index As Integer) As Boolean
        Dim a As Short = lvPlaylist.Items.Count
        If _playedItems.Count = a Then
            _playedItems.Clear()
        End If

        If _playedItems.Count = 0 Then
            Return False
        Else
            If _playedItems.Contains(index) Then
                'ShowLog("exists")
                Return True
            End If
        End If

        Return False

    End Function


    Private Sub prevButton_Click(sender As Object, e As EventArgs) Handles prevButton.Click
        If lvPlaylist.Items.Count <> 0 Then     'do nothing if playlist is empty
            Try
                MusicControl.StopMusic()
                If _shuffle Then
                    Try
                        _playingFileIndex = _playedItems.First()
                        _playedItems.Pop()
                        MusicControl.PlayMusic(lvPlaylist.Items(_playingFileIndex).Tag.ToString)
                    Catch ex As InvalidOperationException
                        'NO PLAYED ITEM AGAIN SO DO THE NORMAL PREVIOUS THINGIE
                        SkipTrack(False)
                    End Try

                Else
                    SkipTrack(False)
                End If
            Catch ex As Exception
            End Try

        End If

    End Sub


    Dim _playlistShown As Boolean = True
    Private Sub VArrowButton1_Click(sender As Object, e As EventArgs) Handles VArrowButton1.Click
        tmrPlaylist.Enabled = True
        If VArrowButton1.ArrowDirection = ArrowDirection.Down Then
            VArrowButton1.ArrowDirection = ArrowDirection.Up
        Else
            VArrowButton1.ArrowDirection = ArrowDirection.Down
        End If
    End Sub

    Dim target As Integer = 232
    Dim targetShn As Integer = 508

    Private Sub tmrPlaylist_Tick(sender As Object, e As EventArgs) Handles tmrPlaylist.Tick
        If _playlistShown Then
            If Height > target Then
                Height = Height - 20
            Else
                _playlistShown = False
                tmrPlaylist.Enabled = False
                Try
                    lvPlaylist.EnsureVisible(_playingFileIndex)
                Catch ex As Exception
                    'no item is playing or no item is in the list: DO NOTHING
                End Try

            End If

        Else
            If Height < targetShn Then
                Height = Height + 20

            Else

                _playlistShown = True

                tmrPlaylist.Enabled = False
                Try
                    lvPlaylist.EnsureVisible(_playingFileIndex)
                Catch ex As Exception
                    'no item is playing or no item is in the list
                End Try
            End If
        End If

    End Sub


    Private Sub toggleButton_MouseDown(sender As Object, e As MouseEventArgs) Handles repeatButton.MouseDown
        repeatButton.Top = repeatButton.Top + 2
    End Sub


    Private Sub repeatButton_MouseEnter(sender As Object, e As EventArgs) Handles repeatButton.MouseEnter
        If _repeat Then
            repeatButton.Image = My.Resources.repeat_icon_normal
        Else
            repeatButton.Image = My.Resources.repeat_icon_pressed
        End If

    End Sub

    Private Sub repeatButton_MouseLeave(sender As Object, e As EventArgs) Handles repeatButton.MouseLeave
        If _repeat Then
            repeatButton.Image = My.Resources.repeat_icon_pressed
        Else
            repeatButton.Image = My.Resources.repeat_icon_normal
        End If

    End Sub


    Private Sub repeatButton_MouseUp(sender As Object, e As MouseEventArgs) Handles repeatButton.MouseUp
        repeatButton.Top = repeatButton.Top - 2
    End Sub

    Private Sub repeatButton_Click(sender As Object, e As EventArgs) Handles repeatButton.Click
        If _repeat Then
            _repeat = False
            repeatButton.Image = My.Resources.repeat_icon_pressed

        Else
            _repeat = True
            repeatButton.Image = My.Resources.repeat_icon_normal
            myTooltip.SetToolTip(repeatButton, "Repeating Current Track")
        End If

    End Sub

    Private Sub shuffleButton_Click(sender As Object, e As EventArgs) Handles shuffleButton.Click
        If _shuffle Then
            _shuffle = False
            shuffleButton.Image = My.Resources.shuffle_icon_normal
            myTooltip.SetToolTip(shuffleButton, "Playing Normal")
        Else
            _shuffle = True
            shuffleButton.Image = My.Resources.shuffle_icon_pressed
            myTooltip.SetToolTip(shuffleButton, "Shuffling")
        End If
    End Sub

    Private Sub shuffleButton_MouseDown(sender As Object, e As MouseEventArgs) Handles shuffleButton.MouseDown
        shuffleButton.Top = shuffleButton.Top + 2
    End Sub

    Private Sub shuffleButton_MouseEnter(sender As Object, e As EventArgs) Handles shuffleButton.MouseEnter
        If _shuffle Then
            shuffleButton.Image = My.Resources.shuffle_icon_normal
        Else
            shuffleButton.Image = My.Resources.shuffle_icon_pressed
        End If

    End Sub

    Private Sub shuffleButton_MouseLeave(sender As Object, e As EventArgs) Handles shuffleButton.MouseLeave
        If _shuffle Then
            shuffleButton.Image = My.Resources.shuffle_icon_pressed
        Else
            shuffleButton.Image = My.Resources.shuffle_icon_normal
        End If
    End Sub

    Private Sub shuffleButton_MouseUp(sender As Object, e As MouseEventArgs) Handles shuffleButton.MouseUp
        shuffleButton.Top = shuffleButton.Top - 2
    End Sub

    Private Sub DeleteAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAllToolStripMenuItem.Click
        lvPlaylist.Items.Clear()
        MusicControl.StopMusic()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteItem()
        If lvPlaylist.Items.Count = 0 Then MusicControl.StopMusic()
    End Sub

    Private Sub DeleteItem()
        For Each item As ListViewItem In lvPlaylist.SelectedItems
            Try
                'If lvPlaylist.Items(_playingFileIndex).Tag.ToString = item.Tag.ToString Then
                '    MusicControl.StopMusic()
                'End If

                lvPlaylist.Items.Remove(item)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub

    Private Sub FileInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileInfoToolStripMenuItem.Click
        If lvPlaylist.Items.Count <> 0 Then
            Dim a As New infoForm(lvPlaylist.Items(lvPlaylist.FocusedItem.Index).Tag.ToString)
            a.ShowDialog()
        End If
    End Sub


    Private Sub cmdBW_DoWork(sender As Object, e As DoWorkEventArgs) Handles cmdBW.DoWork
        Dim aFile() As String = e.Argument
        For Each file In aFile
            AddToPlaylist(file)
        Next
    End Sub

    Private Sub cmdBW_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles cmdBW.RunWorkerCompleted

        If lvPlaylist.Items.Count = 1 And MusicControl.GetState <> Audio.PlayerState.Playing Then
            MusicControl.PlayMusic(lvPlaylist.Items(0).Tag.ToString)
        End If
    End Sub



    'DELETE A FILE FROM DISK TO RECYCLE BIN. IF IT'S CURRENTLY PLAYING, GO TO NEXT AND DELETE IT TO PREVENT FILE LOCK ISSUES
    Private Sub PhysicallyDeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhysicallyDeleteToolStripMenuItem.Click
        If lvPlaylist.SelectedItems.Count <> 0 Then
            If MessageBox.Show("This will delete selected files from disk, Proceed?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DeleteFromDisk()
            End If
        End If
    End Sub

    Private Sub DeleteFromDisk()
        For Each item As ListViewItem In lvPlaylist.SelectedItems
            If lvPlaylist.Items(_playingFileIndex).Tag.ToString = item.Tag.ToString Then
                MusicControl.StopMusic()

                If lvPlaylist.Items.Count <> 1 Then SkipTrack(True)

            End If

            My.Computer.FileSystem.DeleteFile(item.Tag.ToString, UIOption.AllDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing)
            lvPlaylist.Items.Remove(item)
        Next
    End Sub

    Private Sub plLoader_DoWork(sender As Object, e As DoWorkEventArgs) Handles plLoader.DoWork
        Invoke(Sub() Visible = False)
        LoadPlaylist()
    End Sub

    Private Sub plLoader_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles plLoader.RunWorkerCompleted
        If lvPlaylist.Items.Count <> 0 Then
            Try
                Select Case My.Settings.PlayerState
                    Case "Playing"
                        _playingFileIndex = My.Settings.LastFileIndex
                        MusicControl.PlayMusic(lvPlaylist.Items(_playingFileIndex).Tag)

                        MusicControl.SeekFile(My.Settings.PlayingPosition)
                End Select
            Catch ex As Exception

            End Try

        End If

        Visible = True

    End Sub


    Dim _mousex As Integer
    Dim _drag As Boolean
    Private Sub lblSongInfo_MouseDown(sender As Object, e As MouseEventArgs) Handles lblSongInfo.MouseDown
        _drag = True
        _mousex = Cursor.Position.X - lblSongInfo.Left
        tmrLabelTimer.Enabled = False
    End Sub


    Private Sub lblSongInfo_MouseMove(sender As Object, e As MouseEventArgs) Handles lblSongInfo.MouseMove
        If _drag Then
            lblSongInfo.Left = Cursor.Position.X - _mousex
        End If
    End Sub

    Private Sub lblSongInfo_MouseUp(sender As Object, e As MouseEventArgs) Handles lblSongInfo.MouseUp
        _drag = False
        tmrLabelTimer.Enabled = True
    End Sub

    Private Sub MainForm_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        'notify the control that we are ready to drop items
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub MainForm_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        'Clear the playlist when an item is dropped onto the media player
        lvPlaylist.Items.Clear()
        MusicControl.StopMusic()

        _files = e.Data.GetData(DataFormats.FileDrop)
        bw.RunWorkerAsync(_files)
    End Sub

   
End Class
'RAFS
