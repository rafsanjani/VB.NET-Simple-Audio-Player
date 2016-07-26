<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Spectrum_UC
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rSpectrum = New Animation.Spectrum()
        Me.lSpectrum = New Animation.Spectrum()
        Me.SuspendLayout()
        '
        'rSpectrum
        '
        Me.rSpectrum.BackColor = System.Drawing.Color.Black
        Me.rSpectrum.CurrentLEDWidth = 5
        Me.rSpectrum.DatedLEDWidth = 3
        Me.rSpectrum.DoubleBuffer = True
        Me.rSpectrum.DrawBorder = True
        Me.rSpectrum.Location = New System.Drawing.Point(3, 4)
        Me.rSpectrum.Name = "rSpectrum"
        Me.rSpectrum.Orientation = Animation.Spectrum.Flow.Right
        Me.rSpectrum.Size = New System.Drawing.Size(139, 60)
        Me.rSpectrum.SmoothTransition = False
        Me.rSpectrum.Space = 1
        Me.rSpectrum.Stretch = CType(50US, UShort)
        Me.rSpectrum.TabIndex = 2
        Me.rSpectrum.Value = 0
        '
        'lSpectrum
        '
        Me.lSpectrum.BackColor = System.Drawing.Color.Black
        Me.lSpectrum.CurrentLEDWidth = 5
        Me.lSpectrum.DatedLEDWidth = 3
        Me.lSpectrum.DoubleBuffer = True
        Me.lSpectrum.DrawBorder = True
        Me.lSpectrum.Location = New System.Drawing.Point(141, 4)
        Me.lSpectrum.Name = "lSpectrum"
        Me.lSpectrum.Orientation = Animation.Spectrum.Flow.Right
        Me.lSpectrum.Size = New System.Drawing.Size(134, 60)
        Me.lSpectrum.SmoothTransition = False
        Me.lSpectrum.Space = 1
        Me.lSpectrum.Stretch = CType(50US, UShort)
        Me.lSpectrum.TabIndex = 3
        Me.lSpectrum.Value = 0
        '
        'Spectrum_UC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lSpectrum)
        Me.Controls.Add(Me.rSpectrum)
        Me.Name = "Spectrum_UC"
        Me.Size = New System.Drawing.Size(279, 69)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rSpectrum As Animation.Spectrum
    Friend WithEvents lSpectrum As Animation.Spectrum

End Class
