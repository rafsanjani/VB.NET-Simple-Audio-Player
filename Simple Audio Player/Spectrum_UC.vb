Imports Animation

Public Class Spectrum_UC
    Shared _AUDIOAPI As New AudioAPI



    Private Sub Spectrum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With lSpectrum
            .DrawBorder = False
            '    BackColor = Color.FromArgb(200)
            '    .CurrentLEDWidth = 4
            '.DatedLEDWidth = 2
            .CurrentLEDColor = Brushes.HotPink
            '    .DatedLEDColor = Brushes.Lavender
            .Orientation = Spectrum.Flow.Left
            .Stretch = True
            .SmoothTransition = True
        End With

        With rSpectrum
            .DrawBorder = False
            '    .BackColor = Color.FromArgb(200)
            '.CurrentLEDWidth = 4
            '.DatedLEDWidth = 2
            .SmoothTransition = True
            .CurrentLEDColor = Brushes.HotPink
            '    .DatedLEDColor = Brushes.Lavender
            .Orientation = Spectrum.Flow.Right
            .Stretch = True
        End With
    End Sub

    Public Sub SetAudioSource()
        lSpectrum.Value = _AUDIOAPI.GetPeakValue(AudioAPI.AudioChannels.GET_OUT_LeftPeak)
        rSpectrum.Value = _AUDIOAPI.GetPeakValue(AudioAPI.AudioChannels.GET_OUT_RightPeak)
    End Sub
    
     
End Class
