Imports CoreAudioApi
Imports System.ComponentModel
Imports System.Runtime.InteropServices


<BrowsableAttribute(True), ComVisible(True), DescriptionAttribute("Simplified Class for using CoreAudioAPI.dll.")> _
Public NotInheritable Class AudioAPI
    Friend deviceCapture As MMDevice
    Friend deviceRender As MMDevice
    Friend DevEnum As New MMDeviceEnumerator()
    Public Sub New()
        deviceCapture = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia)
        deviceRender = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia)
    End Sub
    <BrowsableAttribute(True), DescriptionAttribute("Audio Channels.")> _
    Public Enum AudioChannels As Integer
        GET_IN_LeftPeak = 1
        GET_IN_RightPeak = 2
        GET_IN_MasterPeak = 3
        GET_OUT_LeftPeak = 4
        GET_OUT_RightPeak = 5
        GET_OUT_MasterPeak = 6
    End Enum
    <BrowsableAttribute(True), DescriptionAttribute("Get Output Value of selected Audio Channel.")>
    Public Overloads Function GetPeakValue(ByVal AudioChannel As AudioChannels) As Int32
        Dim value As Integer
        Select Case AudioChannel
            Case AudioChannels.GET_IN_LeftPeak
                value = deviceCapture.AudioMeterInformation.PeakValues(0) * 100
            Case AudioChannels.GET_IN_RightPeak
                value = deviceCapture.AudioMeterInformation.PeakValues(1) * 100
            Case AudioChannels.GET_IN_MasterPeak
                value = deviceCapture.AudioMeterInformation.MasterPeakValue * 100
            Case AudioChannels.GET_OUT_LeftPeak
                value = deviceRender.AudioMeterInformation.PeakValues(0) * 100
            Case AudioChannels.GET_OUT_RightPeak
                value = deviceRender.AudioMeterInformation.PeakValues(1) * 100
            Case AudioChannels.GET_OUT_MasterPeak
                value = deviceRender.AudioMeterInformation.MasterPeakValue * 100
            Case Else
                Throw New ArgumentOutOfRangeException("Method: GetPeakValue(value As AudioAPI.AudioChannels)" _
                                            & vbNewLine & "AudioChannel" & """" & AudioChannel.ToString & """" & " doesn't exist!")
                MyBase.Finalize()
        End Select
        Return value
    End Function
    Public Property IN_MasterScalar As Single
        Get
            Return deviceCapture.AudioEndpointVolume.MasterVolumeLevelScalar
        End Get
        Set(ByVal value As Single)
            deviceCapture.AudioEndpointVolume.MasterVolumeLevelScalar = value
        End Set
    End Property
    Public Property OUT_MasterScalar As Single
        Get
            Return deviceRender.AudioEndpointVolume.MasterVolumeLevelScalar
        End Get
        Set(ByVal value As Single)
            deviceRender.AudioEndpointVolume.MasterVolumeLevelScalar = value
        End Set
    End Property
    Public Property IN_MUTE As Boolean
        Get
            Return deviceCapture.AudioEndpointVolume.Mute
        End Get
        Set(ByVal value As Boolean)
            deviceCapture.AudioEndpointVolume.Mute = value
        End Set
    End Property
    Public Property OUT_MUTE As Boolean
        Get
            Return deviceRender.AudioEndpointVolume.Mute
        End Get
        Set(ByVal value As Boolean)
            deviceRender.AudioEndpointVolume.Mute = value
        End Set
    End Property
End Class