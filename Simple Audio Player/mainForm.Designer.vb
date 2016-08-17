<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.pnlSongInfo = New System.Windows.Forms.Panel()
        Me.lblPlayerState = New System.Windows.Forms.Label()
        Me.lblSongInfo = New System.Windows.Forms.Label()
        Me.trkVolumeSlider = New System.Windows.Forms.TrackBar()
        Me.VisualStyler2 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.lblDuration = New System.Windows.Forms.Label()
        Me.musicTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblVolText = New System.Windows.Forms.Label()
        Me.sTimer = New System.Windows.Forms.Timer(Me.components)
        Me.myTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.trkBarSeek1 = New MB.Controls.ColorSlider()
        Me.tmrLabelTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlUtility = New System.Windows.Forms.Panel()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.VArrowButton1 = New VIBlend.WinForms.Controls.vArrowButton()
        Me.tmrPlaylist = New System.Windows.Forms.Timer(Me.components)
        Me.lvPlaylist = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.Title = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Time = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdBW = New System.ComponentModel.BackgroundWorker()
        Me.plLoader = New System.ComponentModel.BackgroundWorker()
        Me.shuffleButton = New System.Windows.Forms.PictureBox()
        Me.repeatButton = New System.Windows.Forms.PictureBox()
        Me.nextButton = New System.Windows.Forms.PictureBox()
        Me.openButton = New System.Windows.Forms.PictureBox()
        Me.playlistCtxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FileInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PhysicallyDeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.stopButton = New System.Windows.Forms.PictureBox()
        Me.prevButton = New System.Windows.Forms.PictureBox()
        Me.playButton = New System.Windows.Forms.PictureBox()
        Me.pnlSongInfo.SuspendLayout()
        CType(Me.trkVolumeSlider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VisualStyler2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.shuffleButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repeatButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nextButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.openButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.playlistCtxMenu.SuspendLayout()
        CType(Me.stopButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.prevButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.playButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSongInfo
        '
        Me.pnlSongInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.pnlSongInfo.Controls.Add(Me.lblPlayerState)
        Me.pnlSongInfo.Controls.Add(Me.lblSongInfo)
        Me.pnlSongInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSongInfo.Location = New System.Drawing.Point(0, 0)
        Me.pnlSongInfo.Name = "pnlSongInfo"
        Me.pnlSongInfo.Size = New System.Drawing.Size(372, 32)
        Me.pnlSongInfo.TabIndex = 0
        '
        'lblPlayerState
        '
        Me.lblPlayerState.AutoSize = True
        Me.lblPlayerState.Font = New System.Drawing.Font("Cooper Black", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayerState.ForeColor = System.Drawing.Color.Black
        Me.lblPlayerState.Location = New System.Drawing.Point(0, 10)
        Me.lblPlayerState.Name = "lblPlayerState"
        Me.lblPlayerState.Size = New System.Drawing.Size(52, 14)
        Me.lblPlayerState.TabIndex = 13
        Me.lblPlayerState.Text = "Playing"
        '
        'lblSongInfo
        '
        Me.lblSongInfo.AutoSize = True
        Me.lblSongInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblSongInfo.Font = New System.Drawing.Font("Lucida Fax", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSongInfo.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblSongInfo.Location = New System.Drawing.Point(82, 9)
        Me.lblSongInfo.Name = "lblSongInfo"
        Me.lblSongInfo.Size = New System.Drawing.Size(555, 15)
        Me.lblSongInfo.TabIndex = 12
        Me.lblSongInfo.Text = "   Rafs Simple Audio Player v1.0 (Rafsanjani Abdul Aziz Yaah Waduudu), March 2016" & _
    "    " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'trkVolumeSlider
        '
        Me.trkVolumeSlider.Location = New System.Drawing.Point(313, 45)
        Me.trkVolumeSlider.Name = "trkVolumeSlider"
        Me.trkVolumeSlider.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkVolumeSlider.Size = New System.Drawing.Size(45, 104)
        Me.trkVolumeSlider.TabIndex = 10
        Me.trkVolumeSlider.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.trkVolumeSlider.Value = 5
        '
        'VisualStyler2
        '
        Me.VisualStyler2.HookVisualStyles = True
        Me.VisualStyler2.HostForm = Me
        Me.VisualStyler2.License = CType(resources.GetObject("VisualStyler2.License"), SkinSoft.VisualStyler.Licensing.VisualStylerLicense)
        Me.VisualStyler2.LoadVisualStyle(Nothing, "XP Royale (Zune).vssf")
        '
        'bw
        '
        Me.bw.WorkerReportsProgress = True
        Me.bw.WorkerSupportsCancellation = True
        '
        'lblDuration
        '
        Me.lblDuration.AutoSize = True
        Me.lblDuration.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuration.ForeColor = System.Drawing.Color.White
        Me.lblDuration.Location = New System.Drawing.Point(297, 158)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(53, 15)
        Me.lblDuration.TabIndex = 13
        Me.lblDuration.Text = "0:00/0:00"
        '
        'musicTimer
        '
        '
        'lblVolText
        '
        Me.lblVolText.AutoSize = True
        Me.lblVolText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVolText.ForeColor = System.Drawing.Color.White
        Me.lblVolText.Location = New System.Drawing.Point(317, 35)
        Me.lblVolText.Name = "lblVolText"
        Me.lblVolText.Size = New System.Drawing.Size(37, 16)
        Me.lblVolText.TabIndex = 15
        Me.lblVolText.Text = "10%"
        '
        'sTimer
        '
        Me.sTimer.Enabled = True
        '
        'trkBarSeek1
        '
        Me.trkBarSeek1.BackColor = System.Drawing.Color.Transparent
        Me.trkBarSeek1.BorderRoundRectSize = New System.Drawing.Size(8, 8)
        Me.trkBarSeek1.LargeChange = CType(5UI, UInteger)
        Me.trkBarSeek1.Location = New System.Drawing.Point(12, 151)
        Me.trkBarSeek1.Name = "trkBarSeek1"
        Me.trkBarSeek1.Size = New System.Drawing.Size(280, 30)
        Me.trkBarSeek1.SmallChange = CType(1UI, UInteger)
        Me.trkBarSeek1.TabIndex = 19
        Me.trkBarSeek1.Text = "ColorSlider1"
        Me.trkBarSeek1.ThumbRoundRectSize = New System.Drawing.Size(8, 8)
        Me.trkBarSeek1.Value = 0
        '
        'tmrLabelTimer
        '
        Me.tmrLabelTimer.Enabled = True
        Me.tmrLabelTimer.Interval = 50
        '
        'pnlUtility
        '
        Me.pnlUtility.BackColor = System.Drawing.Color.Transparent
        Me.pnlUtility.Location = New System.Drawing.Point(12, 36)
        Me.pnlUtility.Name = "pnlUtility"
        Me.pnlUtility.Size = New System.Drawing.Size(299, 59)
        Me.pnlUtility.TabIndex = 20
        '
        'dlgOpenFile
        '
        Me.dlgOpenFile.Filter = "Audio Files|*.mp3*"
        Me.dlgOpenFile.Multiselect = True
        Me.dlgOpenFile.RestoreDirectory = True
        Me.dlgOpenFile.SupportMultiDottedExtensions = True
        Me.dlgOpenFile.Title = "OPEN AUDIO FILES"
        '
        'VArrowButton1
        '
        Me.VArrowButton1.AllowAnimations = True
        Me.VArrowButton1.ArrowDirection = System.Windows.Forms.ArrowDirection.Up
        Me.VArrowButton1.Location = New System.Drawing.Point(330, 177)
        Me.VArrowButton1.Maximum = 100
        Me.VArrowButton1.Minimum = 0
        Me.VArrowButton1.Name = "VArrowButton1"
        Me.VArrowButton1.Size = New System.Drawing.Size(23, 11)
        Me.VArrowButton1.TabIndex = 22
        Me.VArrowButton1.Text = "VArrowButton1"
        Me.VArrowButton1.Value = 0
        Me.VArrowButton1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE
        '
        'tmrPlaylist
        '
        Me.tmrPlaylist.Interval = 10
        '
        'lvPlaylist
        '
        Me.lvPlaylist.AllowDrop = True
        Me.lvPlaylist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPlaylist.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        '
        '
        Me.lvPlaylist.Border.Class = "ListViewBorder"
        Me.lvPlaylist.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lvPlaylist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Title, Me.Time})
        Me.lvPlaylist.ContextMenuStrip = Me.playlistCtxMenu
        Me.lvPlaylist.DisabledBackColor = System.Drawing.Color.Empty
        Me.lvPlaylist.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPlaylist.ForeColor = System.Drawing.Color.White
        Me.lvPlaylist.FullRowSelect = True
        Me.lvPlaylist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvPlaylist.HideSelection = False
        Me.lvPlaylist.LabelWrap = False
        Me.lvPlaylist.Location = New System.Drawing.Point(3, 204)
        Me.lvPlaylist.Name = "lvPlaylist"
        Me.lvPlaylist.Size = New System.Drawing.Size(367, 322)
        Me.lvPlaylist.TabIndex = 11
        Me.lvPlaylist.UseCompatibleStateImageBehavior = False
        Me.lvPlaylist.View = System.Windows.Forms.View.Details
        '
        'Title
        '
        Me.Title.Text = "Title"
        Me.Title.Width = 270
        '
        'Time
        '
        Me.Time.Text = "Time"
        Me.Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Time.Width = 80
        '
        'cmdBW
        '
        Me.cmdBW.WorkerReportsProgress = True
        Me.cmdBW.WorkerSupportsCancellation = True
        '
        'plLoader
        '
        Me.plLoader.WorkerReportsProgress = True
        Me.plLoader.WorkerSupportsCancellation = True
        '
        'shuffleButton
        '
        Me.shuffleButton.Image = Global.Simple_Audio_Player.My.Resources.Resources.shuffle_icon_normal
        Me.shuffleButton.Location = New System.Drawing.Point(244, 113)
        Me.shuffleButton.Name = "shuffleButton"
        Me.shuffleButton.Size = New System.Drawing.Size(30, 32)
        Me.shuffleButton.TabIndex = 24
        Me.shuffleButton.TabStop = False
        '
        'repeatButton
        '
        Me.repeatButton.Image = Global.Simple_Audio_Player.My.Resources.Resources._1459709386_button_synchronize_sticker
        Me.repeatButton.Location = New System.Drawing.Point(280, 113)
        Me.repeatButton.Name = "repeatButton"
        Me.repeatButton.Size = New System.Drawing.Size(35, 32)
        Me.repeatButton.TabIndex = 23
        Me.repeatButton.TabStop = False
        '
        'nextButton
        '
        Me.nextButton.Image = CType(resources.GetObject("nextButton.Image"), System.Drawing.Image)
        Me.nextButton.Location = New System.Drawing.Point(156, 101)
        Me.nextButton.Name = "nextButton"
        Me.nextButton.Size = New System.Drawing.Size(43, 44)
        Me.nextButton.TabIndex = 18
        Me.nextButton.TabStop = False
        Me.myTooltip.SetToolTip(Me.nextButton, "NEXT")
        '
        'openButton
        '
        Me.openButton.Image = CType(resources.GetObject("openButton.Image"), System.Drawing.Image)
        Me.openButton.Location = New System.Drawing.Point(205, 109)
        Me.openButton.Name = "openButton"
        Me.openButton.Size = New System.Drawing.Size(33, 36)
        Me.openButton.TabIndex = 17
        Me.openButton.TabStop = False
        Me.myTooltip.SetToolTip(Me.openButton, "OPEN")
        '
        'playlistCtxMenu
        '
        Me.playlistCtxMenu.BackColor = System.Drawing.Color.Maroon
        Me.playlistCtxMenu.BackgroundImage = Global.Simple_Audio_Player.My.Resources.Resources._123031540072I0Uc
        Me.playlistCtxMenu.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.playlistCtxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileInfoToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.DeleteAllToolStripMenuItem, Me.PhysicallyDeleteToolStripMenuItem})
        Me.playlistCtxMenu.Name = "playlistCtxMenu"
        Me.playlistCtxMenu.Size = New System.Drawing.Size(176, 92)
        '
        'FileInfoToolStripMenuItem
        '
        Me.FileInfoToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.FileInfoToolStripMenuItem.Name = "FileInfoToolStripMenuItem"
        Me.FileInfoToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.FileInfoToolStripMenuItem.Text = "File Info"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.DeleteToolStripMenuItem.Text = "Remove"
        '
        'DeleteAllToolStripMenuItem
        '
        Me.DeleteAllToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem"
        Me.DeleteAllToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.DeleteAllToolStripMenuItem.Text = "Clear"
        '
        'PhysicallyDeleteToolStripMenuItem
        '
        Me.PhysicallyDeleteToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.PhysicallyDeleteToolStripMenuItem.Name = "PhysicallyDeleteToolStripMenuItem"
        Me.PhysicallyDeleteToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.PhysicallyDeleteToolStripMenuItem.Text = "Physically Delete"
        '
        'stopButton
        '
        Me.stopButton.Image = CType(resources.GetObject("stopButton.Image"), System.Drawing.Image)
        Me.stopButton.Location = New System.Drawing.Point(62, 101)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(40, 44)
        Me.stopButton.TabIndex = 8
        Me.stopButton.TabStop = False
        Me.myTooltip.SetToolTip(Me.stopButton, "STOP")
        '
        'prevButton
        '
        Me.prevButton.Image = CType(resources.GetObject("prevButton.Image"), System.Drawing.Image)
        Me.prevButton.Location = New System.Drawing.Point(108, 101)
        Me.prevButton.Name = "prevButton"
        Me.prevButton.Size = New System.Drawing.Size(42, 44)
        Me.prevButton.TabIndex = 6
        Me.prevButton.TabStop = False
        Me.myTooltip.SetToolTip(Me.prevButton, "PREVIOUS")
        '
        'playButton
        '
        Me.playButton.Image = CType(resources.GetObject("playButton.Image"), System.Drawing.Image)
        Me.playButton.Location = New System.Drawing.Point(12, 101)
        Me.playButton.Name = "playButton"
        Me.playButton.Size = New System.Drawing.Size(44, 44)
        Me.playButton.TabIndex = 5
        Me.playButton.TabStop = False
        Me.myTooltip.SetToolTip(Me.playButton, "PLAY")
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(372, 529)
        Me.Controls.Add(Me.shuffleButton)
        Me.Controls.Add(Me.repeatButton)
        Me.Controls.Add(Me.VArrowButton1)
        Me.Controls.Add(Me.pnlUtility)
        Me.Controls.Add(Me.trkBarSeek1)
        Me.Controls.Add(Me.nextButton)
        Me.Controls.Add(Me.openButton)
        Me.Controls.Add(Me.lblVolText)
        Me.Controls.Add(Me.lblDuration)
        Me.Controls.Add(Me.lvPlaylist)
        Me.Controls.Add(Me.trkVolumeSlider)
        Me.Controls.Add(Me.stopButton)
        Me.Controls.Add(Me.prevButton)
        Me.Controls.Add(Me.playButton)
        Me.Controls.Add(Me.pnlSongInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "RAFS SIMPLE AUDIO PLAYER"
        Me.pnlSongInfo.ResumeLayout(False)
        Me.pnlSongInfo.PerformLayout()
        CType(Me.trkVolumeSlider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VisualStyler2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.shuffleButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repeatButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nextButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.openButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.playlistCtxMenu.ResumeLayout(False)
        CType(Me.stopButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.prevButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.playButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlSongInfo As System.Windows.Forms.Panel
    Friend WithEvents playButton As System.Windows.Forms.PictureBox
    Friend WithEvents prevButton As System.Windows.Forms.PictureBox
    Friend WithEvents stopButton As System.Windows.Forms.PictureBox
    Friend WithEvents trkVolumeSlider As System.Windows.Forms.TrackBar
    Friend WithEvents lblSongInfo As System.Windows.Forms.Label
    Friend WithEvents VisualStyler2 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents musicTimer As System.Windows.Forms.Timer
    Friend WithEvents lblVolText As System.Windows.Forms.Label
    Friend WithEvents sTimer As System.Windows.Forms.Timer
    Friend WithEvents openButton As System.Windows.Forms.PictureBox
    Friend WithEvents nextButton As System.Windows.Forms.PictureBox
    Friend WithEvents myTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents lblPlayerState As System.Windows.Forms.Label
    Friend WithEvents trkBarSeek1 As MB.Controls.ColorSlider
    Friend WithEvents tmrLabelTimer As System.Windows.Forms.Timer
    Friend WithEvents pnlUtility As System.Windows.Forms.Panel
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents VArrowButton1 As VIBlend.WinForms.Controls.vArrowButton
    Friend WithEvents tmrPlaylist As System.Windows.Forms.Timer
    Friend WithEvents shuffleButton As System.Windows.Forms.PictureBox
    Friend WithEvents repeatButton As System.Windows.Forms.PictureBox
    Friend WithEvents lvPlaylist As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents Title As System.Windows.Forms.ColumnHeader
    Friend WithEvents Time As System.Windows.Forms.ColumnHeader
    Friend WithEvents playlistCtxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FileInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PhysicallyDeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdBW As System.ComponentModel.BackgroundWorker
    Friend WithEvents plLoader As System.ComponentModel.BackgroundWorker

End Class
