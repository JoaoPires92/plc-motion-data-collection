<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F_Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Main))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.B_About = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.BackgroundWorker_Simulator = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker_Laser = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker_Dispense = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.Label5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.WaitForAutoTrigger = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker_ISP = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 18)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Select Machine ID:"
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(9, 50)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(330, 26)
        Me.ComboBox1.TabIndex = 46
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(699, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(381, 47)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PLC Connection Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.IndianRed
        Me.Label2.Location = New System.Drawing.Point(8, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Disconnected"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Green
        Me.Button1.Location = New System.Drawing.Point(391, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(249, 39)
        Me.Button1.TabIndex = 43
        Me.Button1.Text = "Connect to PLC"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Gainsboro
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Green
        Me.Button2.Location = New System.Drawing.Point(391, 36)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(249, 39)
        Me.Button2.TabIndex = 49
        Me.Button2.Text = "Start Recording"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 18)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Select Station:"
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.White
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(11, 49)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(330, 26)
        Me.ComboBox2.TabIndex = 50
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.ComboBox4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(11, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(664, 148)
        Me.GroupBox2.TabIndex = 52
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Servo Drives  "
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.LightGray
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(391, 86)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(249, 39)
        Me.Button5.TabIndex = 61
        Me.Button5.Text = "Export Raw Data To Excel Sheet"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(212, 110)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(127, 28)
        Me.Button6.TabIndex = 57
        Me.Button6.Text = "Auto Trigger"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 18)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Cycle Duration:"
        '
        'ComboBox4
        '
        Me.ComboBox4.BackColor = System.Drawing.Color.White
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"Automatic Mode", "Manual Mode", "5s", "10s", "20s", "30s", "40s", "50s", "60s"})
        Me.ComboBox4.Location = New System.Drawing.Point(12, 110)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(176, 26)
        Me.ComboBox4.TabIndex = 59
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.LightGray
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(220, 46)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(176, 32)
        Me.Button3.TabIndex = 62
        Me.Button3.Text = "Export axis data  as .txt "
        Me.Button3.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.B_About)
        Me.GroupBox3.Controls.Add(Me.ComboBox1)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(11, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1101, 98)
        Me.GroupBox3.TabIndex = 61
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "PLC - Communication"
        '
        'B_About
        '
        Me.B_About.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_About.Location = New System.Drawing.Point(1021, 14)
        Me.B_About.Name = "B_About"
        Me.B_About.Size = New System.Drawing.Size(59, 25)
        Me.B_About.TabIndex = 62
        Me.B_About.Text = "About"
        Me.B_About.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        Me.Chart1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Chart1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(11, 262)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(1102, 607)
        Me.Chart1.TabIndex = 62
        Me.Chart1.Text = "Chart1"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.ComboBox6)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.ComboBox5)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.ComboBox3)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(699, 108)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(413, 148)
        Me.GroupBox4.TabIndex = 63
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Axis / Parameter Selection"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(217, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 18)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Axis Parameter 2:"
        '
        'ComboBox6
        '
        Me.ComboBox6.BackColor = System.Drawing.Color.White
        Me.ComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(220, 109)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(176, 26)
        Me.ComboBox6.TabIndex = 70
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 18)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Axis Parameter 1:"
        '
        'ComboBox5
        '
        Me.ComboBox5.BackColor = System.Drawing.Color.White
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(22, 109)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(176, 26)
        Me.ComboBox5.TabIndex = 68
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(19, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 18)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Axis Type:"
        '
        'ComboBox3
        '
        Me.ComboBox3.BackColor = System.Drawing.Color.White
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(22, 49)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(176, 26)
        Me.ComboBox3.TabIndex = 66
        '
        'BackgroundWorker_Simulator
        '
        Me.BackgroundWorker_Simulator.WorkerReportsProgress = True
        Me.BackgroundWorker_Simulator.WorkerSupportsCancellation = True
        '
        'BackgroundWorker_Laser
        '
        Me.BackgroundWorker_Laser.WorkerReportsProgress = True
        Me.BackgroundWorker_Laser.WorkerSupportsCancellation = True
        '
        'BackgroundWorker_Dispense
        '
        Me.BackgroundWorker_Dispense.WorkerReportsProgress = True
        Me.BackgroundWorker_Dispense.WorkerSupportsCancellation = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ProgressBar1, Me.Label5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 874)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1124, 22)
        Me.StatusStrip1.TabIndex = 64
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'Label5
        '
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 17)
        Me.Label5.Text = "ToolStripStatusLabel2"
        '
        'WaitForAutoTrigger
        '
        Me.WaitForAutoTrigger.Interval = 50
        '
        'BackgroundWorker_ISP
        '
        Me.BackgroundWorker_ISP.WorkerReportsProgress = True
        Me.BackgroundWorker_ISP.WorkerSupportsCancellation = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 30000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'F_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1124, 896)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ATS Condition Monitoring App V2.0"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Button5 As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BackgroundWorker_Simulator As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker_Laser As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker_Dispense As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ProgressBar1 As ToolStripProgressBar
    Friend WithEvents WaitForAutoTrigger As Timer
    Friend WithEvents Button6 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents BackgroundWorker_ISP As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label5 As ToolStripStatusLabel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents B_About As Button
End Class
