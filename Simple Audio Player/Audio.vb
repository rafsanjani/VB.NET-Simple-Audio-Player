Imports System.ComponentModel

Public Class Audio
    Implements IDisposable

    Dim stream As IntPtr = Nothing

    Private fileName As String



    Private Const BASS_POS_BYTE As UInteger = 0
    Private Const BASS_DEVICE_DEFAULT As UInteger = 2
    Private Const BASS_ATTRIB_VOL As UInteger = 2
    Private fileLoaded As Boolean

    Private length As Long

    'BASS PLAYER STATES
    'Private Const BASS_ACTIVE_STOPPED As UInteger = 0
    'Private Const BASS_ACTIVE_PLAYING As UInteger = 1
    'Private Const BASS_ACTIVE_STALLED As UInteger = 2
    'Private Const BASS_ACTIVE_PAUSED As UInteger = 3


    'PLAYER EVENTS
    Public Event MediaPlaying()
    Public Event MediaPaused()
    Public Event MediaStopped()
    Public Event MediaCompleted()

    Private Declare Function BASS_Init Lib "bass.dll" (ByVal device As Integer, ByVal freq As UInteger, ByVal flags As UInteger, ByVal win As IntPtr, ByVal clsid As UInteger) As Boolean
    Private Declare Function BASS_Free Lib "bass.dll" () As Boolean
    Private Declare Function BASS_ChannelStop Lib "bass.dll" (ByVal handle As IntPtr) As Boolean
    Private Declare Function BASS_ChannelGetLength Lib "bass.dll" (ByVal handle As IntPtr, ByVal mode As Integer) As Integer
    Private Declare Function BASS_StreamFree Lib "bass.dll" (ByVal handle As IntPtr) As Boolean
    Private Declare Function BASS_ChannelGetPosition Lib "bass.dll" (ByVal handle As IntPtr, ByVal mode As Integer) As Integer
    Private Declare Function BASS_ChannelBytes2Seconds Lib "bass.dll" (ByVal handle As IntPtr, ByVal len As Int64) As Double
    Private Declare Function BASS_ChannelSetPosition Lib "bass.dll" (ByVal handle As IntPtr, ByVal len As Int64, ByVal mode As Integer) As Boolean
    Private Declare Function BASS_ChannelIsActive Lib "bass.dll" (ByVal handle As IntPtr) As UInteger
    Private Declare Function BASS_ChannelPlay Lib "bass.dll" (ByVal handle As IntPtr, ByVal restart As Boolean) As Boolean
    Private Declare Function BASS_ChannelPause Lib "bass.dll" (ByVal handle As IntPtr) As Boolean
    Private Declare Function BASS_ChannelSetDevice Lib "bass.dll" (ByVal handle As IntPtr, ByVal device As IntPtr) As Boolean
    Private Declare Function BASS_ChannelGetDevice Lib "bass.dll" (ByVal handle As IntPtr) As Integer
    Private Declare Function BASS_ChannelSetAttribute Lib "bass.dll" (ByVal handle As IntPtr, ByVal attrib As IntPtr, ByVal value As Single) As Boolean
    Private Declare Function BASS_SetVolume Lib "bass.dll" (ByVal volume As Single) As Boolean
    Private Declare Function BASS_StreamCreateFile Lib "bass.dll" Alias "BASS_StreamCreateFile" (ByVal mem As Boolean, ByVal file As String, ByVal offset As UInteger, ByVal offsethigh As UInteger, ByVal length As UInteger, ByVal lengthhigh As UInteger, ByVal flags As UInteger) As IntPtr
    Private Declare Function BASS_SampleLoad Lib "bass.dll" Alias "BASS_SampleLoad" (ByVal mem As Boolean, ByVal file As String, ByVal offset As UInteger, ByVal offsethigh As UInteger, ByVal length As UInteger, ByVal max As UInteger, ByVal flags As UInteger) As IntPtr
    Private Declare Function BASS_SampleFree Lib "bass.dll" (ByVal handle As IntPtr) As Boolean
    Private Declare Function BASS_SampleGetChannel Lib "bass.dll" (ByVal handle As IntPtr, ByVal onlynew As Boolean) As IntPtr
    Private Declare Function BASS_SampleStop Lib "bass.dll" (ByVal handle As IntPtr) As Boolean
    Private Declare Function BASS_ChannelGetAttribute Lib "bass.dll" (handle As IntPtr, attrib As IntPtr, ByRef output As Double) As Double
    Private Declare Function BASS_GetVolume Lib "bass.dll" () As Double

    Public Sub New(Optional ByVal fileName As String = "")
        BASS_Init(-1, 44100, BASS_DEVICE_DEFAULT, IntPtr.Zero, Nothing)
        Me.fileName = fileName
    End Sub

    Private Sub SetDevice()
        BASS_ChannelSetDevice(stream, 1)
    End Sub

    


    Public Function PlayMusic(fileName As String) As Boolean
        Me.fileName = fileName
        stream = BASS_StreamCreateFile(False, fileName, 0, 0, 0, 0, 0)

        If BASS_ChannelPlay(stream, False) Then
            fileLoaded = True
            RaiseEvent MediaPlaying()
            Return True
        End If

        Return False
    End Function
    Public Function GetCurrentFile() As String
        Return fileName
    End Function


    'Public Function GetDevice() As Integer
    '    Return BASS_ChannelGetDevice(stream)
    'End Function

    Public Function GetPosition() As Long
        Return BASS_ChannelGetPosition(stream, BASS_POS_BYTE)
    End Function

    Public Function GetElapsedTime() As TimeSpan
        length = BASS_ChannelGetPosition(stream, BASS_POS_BYTE)
        Dim lltell As Long = BASS_ChannelBytes2Seconds(stream, length)
        Dim secs As Short = lltell Mod 60
        Dim mins As Short = (lltell - secs) / 60

        Return New TimeSpan(0, mins, secs)
    End Function

    Public Function GetTotalTime() As TimeSpan

        If stream = Nothing Then
            stream = BASS_StreamCreateFile(False, fileName, 0, 0, 0, 0, 0)
        End If
        length = BASS_ChannelGetLength(stream, BASS_POS_BYTE)
        Dim lltell As Long = BASS_ChannelBytes2Seconds(stream, length)
        Dim secs As Short = lltell Mod 60
        Dim mins As Short = (lltell - secs) / 60

        Return New TimeSpan(0, mins, secs)
    End Function

    Public Function GetLength() As Integer
        Return BASS_ChannelGetLength(stream, BASS_POS_BYTE)
    End Function

    Public Sub PauseMusic()
        BASS_ChannelPause(stream)
        RaiseEvent MediaPaused()
    End Sub

    Public Sub ResumeMusic()
        BASS_ChannelPlay(stream, False)
        RaiseEvent MediaPlaying()
    End Sub


    Public Function SeekFile(ByVal pos As Long) As Boolean
        If BASS_ChannelSetPosition(stream, pos, BASS_POS_BYTE) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub SetVolume(ByVal value As Double)
        BASS_ChannelSetAttribute(stream, BASS_ATTRIB_VOL, value)
    End Sub


    Enum PlayerStates
        Playing
        Stopped
        Stalled
        Paused
    End Enum

    Public Sub StopMusic()
        BASS_ChannelStop(stream)
        BASS_StreamFree(stream)

        fileLoaded = False
        RaiseEvent MediaStopped()
    End Sub

    Public Sub CheckPlayerState()
        If GetPosition() = GetLength() Then
            RaiseEvent MediaCompleted()
        End If
    End Sub
    Function GetState() As PlayerStates
        Select Case BASS_ChannelIsActive(stream)
            Case 0
                Return PlayerStates.Stopped
            Case 1
                Return PlayerStates.Playing
            Case 2
                Return PlayerStates.Stalled
            Case 3
                Return PlayerStates.Paused
        End Select

        Return PlayerStates.Stopped
    End Function

    Public Sub Dispose() Implements System.IDisposable.Dispose
        StopMusic()
        BASS_Free()
    End Sub
End Class

