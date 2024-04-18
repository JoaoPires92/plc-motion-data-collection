
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Threading
Imports System.IO

Public Class F_Main
    Public CycleDuration_SelectedValue As String
    Private Sub F_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Simulator Mode
            boSimulatorMode = False
            ' Time in ms
            ThreadSleepTime = 1
            ' Initialise
            Button1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            ComboBox4.Enabled = False
            ComboBox5.Enabled = False
            ComboBox6.Enabled = False
            Button2.Enabled = False
            Button5.Enabled = False
            Button3.Enabled = False
            Label5.Visible = False
            Button6.Visible = False
            ProgressBar1.Visible = False
            AxisParameterSelected_1 = "Position"
            AxisParameterSelected_2 = "Current"
            AxisTypeSelected = "X Axis"
            CheckForIllegalCrossThreadCalls = True
            boDataAvailableToDisplay = False
            ' Load Machine ID List
            Load_Machine_ID()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: F_Main_Load()")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Bt Connect / Disconnect from PLC
        Try
            ' Simulator Mode Bypass
            'boSimulatorMode = True

            If Button1.Text = "Connect to PLC" Then
                Load_AB_PLC_Communication()
                If boSimulatorMode Then
                    PLC_Connection = True
                Else
                    ' Call Function to Load AB PLC communication IP address
                    If PLC_CommunicationLoadedOk Then
                        ConnectTo_AB_PLC(AB_PLC_IP) ' Call function to connect to AB PLC (Returns PLC_Connection)
                    End If
                End If

                If PLC_Connection Then
                    Button1.ForeColor = Color.IndianRed
                    Button1.Text = "Disconect from PLC"
                    Label2.ForeColor = Color.Green
                    If boSimulatorMode Then
                        Label2.Text = "Simulator Mode - Active"
                    Else
                        Label2.Text = "Connected to PLC: " & AB_PLC_IP
                    End If
                    ComboBox2.Enabled = True
                    ComboBox1.Enabled = False

                    ComboBox2.SelectedIndex = 0
                    UpdateSelectedStation()

                Else
                    Label2.ForeColor = Color.IndianRed
                    Label2.Text = "Unable to Connect to PLC"
                    MsgBox("Unable to Connect to PLC", MsgBoxStyle.Critical, "PLC Connection Timeout")
                End If

            Else ' Bt Disconnect From PLC

                If boSimulatorMode = False Then
                    DisconnectFrom_AB_PLC()
                ElseIf boSimulatorMode = True Then
                    PLC_Connection = False
                End If
                boSimulatorMode = False

                If PLC_Connection = False Then
                    Button1.ForeColor = Color.Green
                    Button1.Text = "Connect to PLC"
                    Label2.ForeColor = Color.IndianRed
                    Label2.Text = "Disconnected"
                    ComboBox2.Enabled = False
                    Button1.Enabled = False
                    ComboBox1.Enabled = True
                    ComboBox1.SelectedItem = Nothing
                    ComboBox2.SelectedItem = Nothing
                    ComboBox4.SelectedItem = Nothing
                    ComboBox3.SelectedItem = Nothing
                    ComboBox3.Items.Clear()
                    ComboBox5.Enabled = False
                    ComboBox6.Enabled = False
                    ComboBox5.SelectedItem = Nothing
                    ComboBox6.SelectedItem = Nothing
                    ComboBox5.Items.Clear()
                    ComboBox6.Items.Clear()
                    ComboBox3.Enabled = False
                    ComboBox5.Enabled = False
                    ComboBox6.Enabled = False
                    ComboBox5.SelectedItem = Nothing
                    ComboBox5.Items.Clear()
                    ComboBox6.SelectedItem = Nothing
                    ComboBox6.Items.Clear()
                    Button2.Enabled = False
                    ComboBox4.Enabled = False
                    Button5.Enabled = False
                    Button5.BackColor = Color.LightGray
                    Button3.Enabled = False
                    Button3.BackColor = Color.LightGray
                    Label5.Visible = False
                    ProgressBar1.Visible = False
                    ProgressBar1.Value = 0
                    Chart1.Titles.Clear()
                    Chart1.Series.Clear()
                    boDataAvailableToDisplay = False
                    Button6.Visible = False

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: Button1_Click()")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Bt Start Recording
        Try
            If Button2.Text = "Start Recording" Then

                Select Case MachineType
                    Case "Laser"
                        Select Case StationSelected
                            Case "S20-Manipulator1", "S40-Manipulator2"
                                A_Position_S2040_Xaxis.Clear()
                                A_Position_S2040_Yaxis.Clear()
                                A_Position_S2040_Zaxis.Clear()
                                A_Position_S2040_Taxis.Clear()
                                A_Current_S2040_Xaxis.Clear()
                                A_Current_S2040_Yaxis.Clear()
                                A_Current_S2040_Zaxis.Clear()
                                A_Current_S2040_Taxis.Clear()
                                A_Speed_S2040_Zaxis.Clear()
                                A_Speed_S2040_Taxis.Clear()
                                A_Force_S2040_Zaxis.Clear()
                                A_Torque_S2040_Taxis.Clear()
                                A_LagError_S2040_Xaxis.Clear()
                                A_LagError_S2040_Yaxis.Clear()
                                A_LagError_S2040_Zaxis.Clear()
                                A_LagError_S2040_Taxis.Clear()
                            Case "S25-Shuttle1", "S25-Shuttle2"
                                'S25 Shuttles
                                A_Position_S25_Shuttle.Clear()
                                A_Current_S25_Shuttle.Clear()
                                A_Speed_S25_Shuttle.Clear()
                                A_Force_S25_Shuttle.Clear()
                                A_LagError_S25_Shuttle.Clear()
                        End Select

                    Case "Dispense"
                        'Add when ready
                    Case "ISP"
                        'add when ready
                End Select
                A_Time.Clear()
                Chart1.Titles.Clear()
                Chart1.Series.Clear()
                Chart1.Annotations.Clear()
                Button5.Enabled = False
                Button5.BackColor = Color.LightGray
                Button3.Enabled = False
                Button3.BackColor = Color.LightGray
                Button2.ForeColor = Color.IndianRed
                ComboBox3.Enabled = False
                ComboBox2.Enabled = False
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                ComboBox6.Enabled = False
                Button1.Enabled = False
                TotalCycleTime = 0
                boDataAvailableToDisplay = False

                If boManualCycle Then
                    Button2.Text = "Stop Recording"
                Else
                    Button2.Text = "Abort"
                End If
                ProgressBar1.Value = 0

                If boAutomaticCycle Then
                    WaitForAutoTrigger.Enabled = True
                Else
                    If boSimulatorMode Then
                        BackgroundWorker_Simulator.RunWorkerAsync()
                    Else
                        Select Case MachineType
                            Case "Laser"
                                BackgroundWorker_Laser.RunWorkerAsync()
                            Case "Dispense"
                                BackgroundWorker_Laser.RunWorkerAsync()
                            Case "ISP"
                                'add when ready
                        End Select
                    End If
                End If

                If boManualCycle Or boAutomaticCycle Then
                    ProgressBar1.Visible = False
                Else
                    ProgressBar1.Value = 0
                    ProgressBar1.Visible = True
                    ProgressBar1.Maximum = CycleDuration * 1000
                End If

                Label5.Visible = True
                Thread.CurrentThread.Priority = ThreadPriority.Highest

            Else ' Bt Stop / Abort

                If boManualCycle = True Then
                    boManualCycle = False
                Else
                    boCycleAbort = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: Button2_Click()")
        End Try
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            boDataAvailableToDisplay = False
            UpdateSelectedStation()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ComboBox2_SelectedIndexChanged()")
        End Try
    End Sub
    Private Sub UpdateSelectedStation()
        ' Select Station
        Try
            If (ComboBox1.SelectedItem <> "") Then
                StationSelected = ComboBox2.SelectedItem
                ComboBox4.Enabled = True
                ComboBox4.SelectedIndex = 0
                UpdateCycleDuration()
                ComboBox3.Items.Clear()
                If MachineType = "Laser" Then
                    Select Case StationSelected
                        Case "S20-Manipulator1", "S40-Manipulator2"
                            ComboBox3.Items.Add("X Axis")
                            ComboBox3.Items.Add("Y Axis")
                            ComboBox3.Items.Add("Z Axis")
                            ComboBox3.Items.Add("Theta Axis")
                            ComboBox3.SelectedIndex = 0
                        Case "S25-Shuttle1", "S25-Shuttle2"
                            ComboBox3.Items.Add("Disabled")
                            ComboBox3.SelectedIndex = 0
                    End Select

                ElseIf MachineType = "Dispense" Then
                    'Add when ready
                ElseIf MachineType = "ISP" Then
                    'Add when ready
                End If

                UpdateAxisType()

                Chart1.Titles.Clear()
                Chart1.Series.Clear()
                Chart1.Annotations.Clear()
                Button5.Enabled = False
                ComboBox3.Enabled = False
                Button5.BackColor = Color.LightGray
                Label5.Visible = False
                ComboBox5.Enabled = False
                ComboBox6.Enabled = False

            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: UpdateSelectedStation()")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Select Machine ComboBox
        Try
            Dim MachineSelected_SubString As String

            If (ComboBox1.SelectedItem <> "") Then
                MachineSelected = ComboBox1.SelectedItem
                ComboBox2.Items.Clear()

                If MachineSelected.StartsWith("W") Then

                    MachineSelected_SubString = MachineSelected.Substring(3, 3)

                    Select Case MachineSelected_SubString
                        Case "DIS"
                            boSimulatorMode = False
                            Load_Dispense_Stations()
                            MachineType = "Dispense"
                        Case "LAS"
                            boSimulatorMode = False
                            Load_Laser_Stations()
                            LoadLaserPLCTags()
                            MachineType = "Laser"
                        Case "ISP"
                            boSimulatorMode = False
                            MachineType = "ISP"
                    End Select

                ElseIf MachineSelected = "Dispense - Simulator" Then
                    boSimulatorMode = True
                    Load_Dispense_Stations()
                    MachineType = "Dispense"
                ElseIf MachineSelected = "Laser - Simulator" Then
                    boSimulatorMode = True
                    Load_Laser_Stations()
                    LoadLaserPLCTags()
                    MachineType = "Laser"
                ElseIf MachineSelected = "ISP - Simulator" Then
                    boSimulatorMode = True
                    MachineType = "ISP"
                ElseIf MachineSelected = "HVL03-50 - Laser 5" Then
                    boSimulatorMode = False
                    Load_Laser_Stations()
                    LoadLaserPLCTags()
                    MachineType = "Laser"
                Else
                    MsgBox(MsgBoxStyle.Critical, "Failed to Load Parameters of Selected Mahine ID. Device not found within program")
                    Exit Sub
                End If
                Button1.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ComboBox1_SelectedIndexChanged()")
        End Try
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Try
            UpdateAxisType()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ComboBox3_SelectedIndexChanged()")
        End Try
    End Sub

    Private Sub UpdateAxisType()
        Try
            If (ComboBox3.SelectedItem <> "") Then
                AxisTypeSelected = ComboBox3.SelectedItem

                ComboBox5.Items.Clear()
                ComboBox6.Items.Clear()

                If MachineType = "Laser" Then

                    Select Case StationSelected
                        Case "S20-Manipulator1", "S40-Manipulator2"
                            Select Case AxisTypeSelected
                                Case "X Axis", "Y Axis"
                                    ComboBox5.Items.Add("Position")
                                    ComboBox5.Items.Add("Current")
                                    ComboBox5.Items.Add("Lag Error")
                                    ComboBox5.SelectedIndex = 0

                                    ComboBox6.Items.Add("Position")
                                    ComboBox6.Items.Add("Current")
                                    ComboBox6.Items.Add("Lag Error")
                                    ComboBox6.SelectedIndex = 1
                                Case "Z Axis"
                                    ComboBox5.Items.Add("Position")
                                    ComboBox5.Items.Add("Current")
                                    ComboBox5.Items.Add("Force")
                                    ComboBox5.Items.Add("Lag Error")
                                    ComboBox5.SelectedIndex = 0

                                    ComboBox6.Items.Add("Position")
                                    ComboBox6.Items.Add("Current")
                                    ComboBox6.Items.Add("Force")
                                    ComboBox6.Items.Add("Lag Error")
                                    ComboBox6.SelectedIndex = 1
                                Case "Theta Axis"
                                    ComboBox5.Items.Add("Position")
                                    ComboBox5.Items.Add("Current")
                                    ComboBox5.Items.Add("Torque")
                                    ComboBox5.Items.Add("Lag Error")
                                    ComboBox5.SelectedIndex = 0

                                    ComboBox6.Items.Add("Position")
                                    ComboBox6.Items.Add("Current")
                                    ComboBox6.Items.Add("Torque")
                                    ComboBox6.Items.Add("Lag Error")
                                    ComboBox6.SelectedIndex = 1
                            End Select
                        Case "S25-Shuttle1", "S25-Shuttle2"
                            ComboBox5.Items.Add("Position")
                            ComboBox5.Items.Add("Current")
                            ComboBox5.Items.Add("Lag Error")
                            ComboBox5.SelectedIndex = 0

                            ComboBox6.Items.Add("Position")
                            ComboBox6.Items.Add("Current")
                            ComboBox6.Items.Add("Lag Error")
                            ComboBox6.SelectedIndex = 1
                    End Select

                ElseIf MachineType = "Dispense" Then
                    'Add when ready
                ElseIf MachineType = "ISP" Then
                    'Add when ready
                End If
                UpdateAxisParameter()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: UpdateAxisType()")
        End Try
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        Try
            UpdateAxisParameter()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ComboBox5_SelectedIndexChanged()")
        End Try
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        Try
            UpdateAxisParameter()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ComboBox6_SelectedIndexChanged()")
        End Try
    End Sub

    Private Sub UpdateAxisParameter()
        Try
            If (ComboBox5.SelectedItem <> "") Then
                AxisParameterSelected_1 = ComboBox5.SelectedItem
            End If

            If (ComboBox6.SelectedItem <> "") Then
                AxisParameterSelected_2 = ComboBox6.SelectedItem
            End If

            If AxisParameterSelected_1 = AxisParameterSelected_2 Then Exit Sub

            If MachineType = "Laser" Then
                If boDataAvailableToDisplay Then DrawChart_Laser()
            ElseIf MachineType = "Dispense" Then
                'Add when ready
            ElseIf MachineType = "ISP" Then
                'Add when ready
            End If

            Chart1.Annotations.Clear()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: UpdateAxisParameter()")
        End Try
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Try
            UpdateCycleDuration()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ComboBox4_SelectedIndexChanged()")
        End Try
    End Sub

    Private Sub UpdateCycleDuration()
        ' Select Cycle Duration
        Try
            If ComboBox4.SelectedItem <> "" Then
                CycleDuration_SelectedValue = ComboBox4.SelectedItem
                boAutomaticCycle = False
                boManualCycle = False
                Button6.Visible = False
                CycleDuration = 0
                Select Case CycleDuration_SelectedValue
                    Case "5s"
                        CycleDuration = 5
                    Case "10s"
                        CycleDuration = 10
                    Case "15s"
                        CycleDuration = 15
                    Case "20s"
                        CycleDuration = 20
                    Case "25s"
                        CycleDuration = 25
                    Case "30s"
                        CycleDuration = 30
                    Case "35s"
                        CycleDuration = 30
                    Case "40s"
                        CycleDuration = 35
                    Case "45s"
                        CycleDuration = 40
                    Case "45s"
                        CycleDuration = 45
                    Case "50s"
                        CycleDuration = 50
                    Case "55s"
                        CycleDuration = 55
                    Case "60s"
                        CycleDuration = 60
                    Case "Manual Mode"
                        boManualCycle = True
                    Case "Automatic Mode"
                        boAutomaticCycle = True
                        If boSimulatorMode Then Button6.Visible = True
                End Select
            End If
            Button2.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: UpdateCycleDuration()")
        End Try
    End Sub
    Private Sub Chart1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Chart1.MouseWheel
        If boDataAvailableToDisplay Then
            Dim XMin As Double = Chart1.ChartAreas("MyArea").AxisX.Minimum
            Dim XMax As Double = Chart1.ChartAreas("MyArea").AxisX.Maximum
            Dim YMin As Double = Chart1.ChartAreas("MyArea").AxisY.Minimum
            Dim YMax As Double = Chart1.ChartAreas("MyArea").AxisY.Maximum
            Static zoom As Double

            zoom += CInt(1 * (e.Delta) / 12)
            zoom = Math.Max(zoom, 0)
            zoom = Math.Min(zoom, 100)

            Dim x1Min As Double = XMin * (1 - zoom / 100)
            Dim x1Max As Double = XMax * (1 - zoom / 100)
            Dim y1Min As Double = YMin * (1 - zoom / 100)
            Dim y1Max As Double = YMax * (1 - zoom / 100)
            Chart1.ChartAreas("MyArea").AxisX.ScaleView.Zoom(x1Min, x1Max)
            Chart1.ChartAreas("MyArea").AxisY.ScaleView.Zoom(y1Min, y1Max)
        End If
    End Sub
    Private Sub Chart1_GetToolTipText(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs) Handles Chart1.GetToolTipText

        Dim result As HitTestResult = Chart1.HitTest(e.X, e.Y)
        Dim mousepoint As Point = New Point(e.X, e.Y)

        If result.ChartElementType = ChartElementType.DataPoint Then
            If e.HitTestResult.PointIndex >= 0 Then
                Chart1.ChartAreas("MyArea").CursorX.LineColor = Color.Purple
                Chart1.ChartAreas("MyArea").CursorX.SetCursorPixelPosition(mousepoint, True)
                If e.HitTestResult.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
                    ToolTip1.SetToolTip(Chart1, AxisParameterSelected_1 & ": " & Chart1.Series(AxisParameterSelected_1).Points(result.PointIndex).YValues(0).ToString() & vbNewLine & AxisParameterSelected_2 & ": " & Chart1.Series(AxisParameterSelected_2).Points(result.PointIndex).YValues(0).ToString())
                End If
            End If

        End If
    End Sub

    Public Sub DrawChart_Laser()
        ' setup the Chart Area
        Try
            GraphCurrentScreen()

            Chart1.Titles.Clear()
            Dim Title = New Title()
            Title.Font = New Font("Arial", 16, FontStyle.Bold)
            Title.Text = Graph_CurrentScreen
            Title.ForeColor = Color.Blue
            Chart1.Titles.Add(Title)

            Chart1.ChartAreas.Clear()
            Chart1.ChartAreas.Add("MyArea")

            Chart1.ChartAreas("MyArea").CursorX.IsUserSelectionEnabled = True
            Chart1.ChartAreas("MyArea").CursorY.IsUserSelectionEnabled = True
            Chart1.ChartAreas("MyArea").AxisX.ScaleView.Zoomable = True
            Chart1.ChartAreas("MyArea").AxisY.ScaleView.Zoomable = True
            Chart1.ChartAreas("MyArea").CursorX.AutoScroll = True
            Chart1.ChartAreas("MyArea").CursorY.AutoScroll = True

            With Chart1.ChartAreas("MyArea")
                .AxisX.TitleFont = New Font("Arial", 10, FontStyle.Bold)
                .AxisX.Title = "Date & Time"
                .AxisX.MajorGrid.LineColor = Color.LightGray
                .AxisY.MajorGrid.LineColor = Color.LightGray
                .AxisY.TitleFont = New Font("Arial", 10, FontStyle.Bold)
                .AxisY2.MajorGrid.LineDashStyle = ChartDashStyle.DashDotDot
                .AxisY2.MajorGrid.LineColor = Color.LightGray
                .AxisY2.TitleFont = New Font("Arial", 10, FontStyle.Bold)

                Select Case AxisParameterSelected_1
                    Case "Position"
                        Select Case AxisTypeSelected
                            Case "Theta Axis"
                                .AxisY.Title = "Position (°)"
                            Case Else
                                .AxisY.Title = "Position (mm)"
                        End Select
                    Case "Current"
                        .AxisY.Title = "Current (A)"
                    Case "Speed"
                        .AxisY.Title = "Speed (m/s)"
                    Case "Torque"
                        .AxisY.Title = "Torque (N)"
                    Case "Force"
                        .AxisY.Title = "Force (N)"
                    Case "Lag Error"
                        .AxisY.Title = "Lag Error (mm)"
                End Select

                Select Case AxisParameterSelected_2
                    Case "Position"
                        Select Case AxisTypeSelected
                            Case "Theta Axis"
                                .AxisY2.Title = "Position (°)"
                            Case Else
                                .AxisY2.Title = "Position (mm)"
                        End Select
                    Case "Current"
                        .AxisY2.Title = "Current (A)"
                    Case "Speed"
                        .AxisY2.Title = "Speed (m/s)"
                    Case "Torque"
                        .AxisY2.Title = "Torque (N)"
                    Case "Force"
                        .AxisY2.Title = "Force (N)"
                    Case "Lag Error"
                        .AxisY2.Title = "Lag Error (mm)"
                End Select

            End With

            ' Specify Series Plot Lines
            Chart1.Series.Clear()

            Chart1.Series.Add(AxisParameterSelected_1)
            Chart1.Series(AxisParameterSelected_1).YAxisType = AxisType.Primary
            Chart1.Series(AxisParameterSelected_1).Color = Color.Blue
            Chart1.Series(AxisParameterSelected_1).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Chart1.Series.Add(AxisParameterSelected_2)
            Chart1.Series(AxisParameterSelected_2).YAxisType = AxisType.Secondary
            Chart1.Series(AxisParameterSelected_2).Color = Color.Red
            Chart1.Series(AxisParameterSelected_2).ChartType = DataVisualization.Charting.SeriesChartType.Line


            Select Case StationSelected
                Case "S20-Manipulator1", "S40-Manipulator2"
                    Select Case AxisTypeSelected
                        Case "X Axis"
                            If A_Time.Count - 1 = A_Position_S2040_Xaxis.Count - 1 Then
                                For i As Integer = 0 To A_Time.Count - 1
                                    Select Case AxisParameterSelected_1
                                        Case "Position"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Position_S2040_Xaxis(i))
                                        Case "Current"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Current_S2040_Xaxis(i))
                                        Case "Lag Error"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_LagError_S2040_Xaxis(i))
                                    End Select
                                    Select Case AxisParameterSelected_2
                                        Case "Position"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Position_S2040_Xaxis(i))
                                        Case "Current"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Current_S2040_Xaxis(i))
                                        Case "Lag Error"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_LagError_S2040_Xaxis(i))
                                    End Select
                                Next
                            End If
                        Case "Y Axis"
                            If A_Time.Count - 1 = A_Position_S2040_Yaxis.Count - 1 Then
                                For i As Integer = 0 To A_Time.Count - 1
                                    Select Case AxisParameterSelected_1
                                        Case "Position"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Position_S2040_Yaxis(i))
                                        Case "Current"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Current_S2040_Yaxis(i))
                                        Case "Lag Error"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_LagError_S2040_Yaxis(i))
                                    End Select
                                    Select Case AxisParameterSelected_2
                                        Case "Position"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Position_S2040_Yaxis(i))
                                        Case "Current"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Current_S2040_Yaxis(i))
                                        Case "Lag Error"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_LagError_S2040_Yaxis(i))
                                    End Select
                                Next
                            End If
                        Case "Z Axis"
                            If A_Time.Count - 1 = A_Position_S2040_Zaxis.Count - 1 Then
                                For i As Integer = 0 To A_Time.Count - 1
                                    Select Case AxisParameterSelected_1
                                        Case "Position"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Position_S2040_Zaxis(i))
                                        Case "Current"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Current_S2040_Zaxis(i))
                                        Case "Force"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Force_S2040_Zaxis(i))
                                        Case "Lag Error"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_LagError_S2040_Zaxis(i))
                                    End Select
                                    Select Case AxisParameterSelected_2
                                        Case "Position"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Position_S2040_Zaxis(i))
                                        Case "Current"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Current_S2040_Zaxis(i))
                                        Case "Force"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Force_S2040_Zaxis(i))
                                        Case "Lag Error"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_LagError_S2040_Zaxis(i))
                                    End Select
                                Next
                            End If
                        Case "Theta Axis"
                            If A_Time.Count - 1 = A_Position_S2040_Taxis.Count - 1 Then
                                For i As Integer = 0 To A_Time.Count - 1
                                    Select Case AxisParameterSelected_1
                                        Case "Position"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Position_S2040_Taxis(i))
                                        Case "Current"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Current_S2040_Taxis(i))
                                        Case "Force"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Torque_S2040_Taxis(i))
                                        Case "Lag Error"
                                            Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_LagError_S2040_Taxis(i))
                                    End Select
                                    Select Case AxisParameterSelected_2
                                        Case "Position"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Position_S2040_Taxis(i))
                                        Case "Current"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Current_S2040_Taxis(i))
                                        Case "Force"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Torque_S2040_Taxis(i))
                                        Case "Lag Error"
                                            Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_LagError_S2040_Taxis(i))
                                    End Select
                                Next
                            End If
                    End Select
                Case "S25-Shuttle1", "S25-Shuttle2"
                    If A_Time.Count - 1 = A_Position_S25_Shuttle.Count - 1 Then
                        For i As Integer = 0 To A_Time.Count - 1
                            Select Case AxisParameterSelected_1
                                Case "Position"
                                    Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Position_S25_Shuttle(i))
                                Case "Current"
                                    Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_Current_S25_Shuttle(i))
                                Case "Lag Error"
                                    Chart1.Series(AxisParameterSelected_1).Points.AddXY(A_Time(i), A_LagError_S25_Shuttle(i))
                            End Select
                            Select Case AxisParameterSelected_2
                                Case "Position"
                                    Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Position_S25_Shuttle(i))
                                Case "Current"
                                    Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_Current_S25_Shuttle(i))
                                Case "Lag Error"
                                    Chart1.Series(AxisParameterSelected_2).Points.AddXY(A_Time(i), A_LagError_S25_Shuttle(i))
                            End Select
                        Next
                    End If
            End Select

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: DrawChart_Laser()")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Export to Excel File 
        Try
            Dim AuxStr As String

            SaveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            DialogResult = SaveFileDialog1.ShowDialog()
            AuxStr = SaveFileDialog1.FileName

            If AuxStr <> Nothing And DialogResult <> Windows.Forms.DialogResult.Cancel Then
                If SaveDataIntoExcelSheet(AuxStr) Then
                    MsgBox("File Saved.", MsgBoxStyle.Information)
                Else
                    MsgBox("Failed to Save File.", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("File not  saved.", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: Button5_Click()")
        End Try
    End Sub
    Private Sub BackgroundWorker_Simulator_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Simulator.DoWork
        ' Simulator Thread - Start
        Try
            TotalCycleTime = 0
            SimulatorCounter = 0
            StopWatch.Reset()
            StopWatch.Start()
            CycleStart_Time = Now.ToString("dd-MM-yyyy HH:mm:ss.fff")

            If boManualCycle Then
                Do While boManualCycle = True
                    SimulatorMode()
                    BackgroundWorker_Simulator.ReportProgress(TotalCycleTime)
                    Thread.Sleep(ThreadSleepTime)
                Loop

            ElseIf boAutomaticCycle Then
                Do While boSimulatorAutoStopCycle = False And boCycleAbort = False
                    SimulatorMode()
                    BackgroundWorker_Simulator.ReportProgress(TotalCycleTime)
                    Thread.Sleep(ThreadSleepTime)
                Loop
            Else
                Do While TotalCycleTime < CycleDuration * 1000 And boCycleAbort = False
                    SimulatorMode()
                    BackgroundWorker_Simulator.ReportProgress(TotalCycleTime)
                    Thread.Sleep(ThreadSleepTime)
                Loop
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: BackgroundWorker_Simulator_DoWork()")
        End Try
    End Sub
    Private Sub BackgroundWorker_Simulator_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker_Simulator.ProgressChanged
        ' Simulator Thread - Progress Update
        Try
            If boManualCycle = False Then
                If ProgressBar1.Maximum < e.ProgressPercentage Then
                    ProgressBar1.Maximum = e.ProgressPercentage
                End If
                ProgressBar1.Value = e.ProgressPercentage
            End If
            Label5.Text = "Recording - Cycle Duration: " & Format(TotalCycleTime / 1000, "0.0") & "s"
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: BackgroundWorker_Simulator_ProgressChanged")
        End Try
    End Sub
    Private Sub BackgroundWorker_Simulator_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Simulator.RunWorkerCompleted
        ' Simulator Thread - Process Completed
        Try
            If CycleDuration_SelectedValue = "Manual Mode" Then boManualCycle = True
            boSimulatorAutoStopCycle = False
            CycleFinished_ShowResults()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: BackgroundWorker_Simulator_RunWorkerCompleted")
        End Try
    End Sub

    Private Sub BackgroundWorker_Laser_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Laser.DoWork
        ' Laser Thread - Start
        Try
            TotalCycleTime = 0
            StopWatch.Reset()
            StopWatch.Start()
            CycleStart_Time = Now.ToString("dd-MM-yyyy HH:mm:ss.fff")

            If boManualCycle Then
                Do While boManualCycle = True
                    ReadDataFromPLC_Laser()
                    BackgroundWorker_Laser.ReportProgress(TotalCycleTime)
                    Thread.Sleep(ThreadSleepTime)
                Loop

            ElseIf boAutomaticCycle Then
                Do While boLaserCycleStartAuto = True And boCycleAbort = False
                    ReadDataFromPLC_Laser()
                    AutomaticCycle_MonitorCycleStop()
                    BackgroundWorker_Laser.ReportProgress(TotalCycleTime)
                    Thread.Sleep(ThreadSleepTime)
                Loop

            Else
                Do While TotalCycleTime < CycleDuration * 1000 And boCycleAbort = False
                    ReadDataFromPLC_Laser()
                    BackgroundWorker_Laser.ReportProgress(TotalCycleTime)
                    Thread.Sleep(ThreadSleepTime)
                Loop
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: BackgroundWorker_Laser_DoWork()")
        End Try
    End Sub

    Private Sub BackgroundWorker_Laser_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker_Laser.ProgressChanged
        ' Laser Thread - Progress Update
        Try
            If boManualCycle = False Then
                If ProgressBar1.Maximum < e.ProgressPercentage Then
                    ProgressBar1.Maximum = e.ProgressPercentage
                End If
                ProgressBar1.Value = e.ProgressPercentage
            End If
            Label5.Text = "Recording - Cycle Duration: " & Format(TotalCycleTime / 1000, "0.0") & "s"
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: BackgroundWorker_Laser_ProgressChanged()")
        End Try
    End Sub

    Private Sub BackgroundWorker_Laser_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Laser.RunWorkerCompleted
        ' Laser Thread - Process Completed
        Try
            If CycleDuration_SelectedValue = "Manual Mode" Then boManualCycle = True
            boLaserCycleStartAuto = False
            CycleFinished_ShowResults()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: BackgroundWorker_Laser_RunWorkerCompleted")
        End Try
    End Sub

    Private Sub BackgroundWorker_Dispense_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Dispense.DoWork
        ' Dispense Thread - Start
        Try
            TotalCycleTime = 0
            StopWatch.Reset()
            StopWatch.Start()
            CycleStart_Time = Now.ToString("dd-MM-yyyy HH:mm:ss.fff")

            If boManualCycle Then
                Do While boManualCycle = True
                    ReadDataFromPLC_Dispense()
                    BackgroundWorker_Dispense.ReportProgress(TotalCycleTime)
                    Thread.Sleep(ThreadSleepTime)
                Loop
            Else
                Do While TotalCycleTime < CycleDuration * 1000 And boCycleAbort = False
                    ReadDataFromPLC_Dispense()
                    BackgroundWorker_Dispense.ReportProgress(TotalCycleTime)
                    Thread.Sleep(ThreadSleepTime)
                Loop
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: BackgroundWorker_Dispense_DoWork()")
        End Try
    End Sub

    Private Sub BackgroundWorker_Dispense_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker_Dispense.ProgressChanged
        ' Dispense Thread - Progress Update
        Try
            If boManualCycle = False Then
                If ProgressBar1.Maximum < e.ProgressPercentage Then
                    ProgressBar1.Maximum = e.ProgressPercentage
                End If
                ProgressBar1.Value = e.ProgressPercentage
            End If
            Label5.Text = "Recording - Cycle Duration: " & Format(TotalCycleTime / 1000, "0.0") & "s"
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: BackgroundWorker_Dispense_ProgressChanged()")
        End Try
    End Sub

    Private Sub BackgroundWorker_Dispense_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Dispense.RunWorkerCompleted
        ' Dispense Thread - Process Completed
        Try
            If CycleDuration_SelectedValue = "Manual Mode" Then boManualCycle = True
            CycleFinished_ShowResults()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: BackgroundWorker_Dispense_RunWorkerCompleted")
        End Try
    End Sub
    Private Sub CycleFinished_ShowResults()
        ' Cycle Finished Sub routine 
        Try
            StopWatch.Stop()
            StopWatch.Reset()
            Button2.ForeColor = Color.Green
            Button2.Text = "Start Recording"
            Button5.Enabled = True
            Button5.BackColor = Color.LightGreen
            Button3.Enabled = True
            Button3.BackColor = Color.LightGreen
            ComboBox5.Enabled = True
            ComboBox6.Enabled = True

            If boCycleAbort = True Then
                boDataAvailableToDisplay = False
            Else
                boDataAvailableToDisplay = True
            End If

            Select Case MachineType
                Case "Laser"
                    Select Case StationSelected
                        Case "S20-Manipulator1", "S40-Manipulator2"
                            ComboBox3.Enabled = True
                    End Select
                    If boDataAvailableToDisplay Then DrawChart_Laser()
                Case "Dispense"
                    'Add when ready
                Case "ISP"
                    'Add when ready
            End Select

            CycleTimeAverage = Format(TotalCycleTime / A_Time.Count - 1, "0.00")
            CycleStop_Time = Now.ToString("dd-MM-yyyy HH:mm:ss.fff ")

            If boCycleAbort = True Then
                Label5.Text = "Recording Cycle Aborted - Cycle Duration: " & Format(TotalCycleTime / 1000, "0.0") & "s"
                If boAutomaticCycle And TotalCycleTime = 0 Then
                    Chart1.Titles.Clear()
                    Chart1.Series.Clear()
                    MsgBox("Recording Cycle Aborted!", MsgBoxStyle.Information)
                Else
                    MsgBox("Recording Cycle Aborted! " & vbNewLine & vbNewLine & vbNewLine & "Cycle Start: " & CycleStart_Time & vbNewLine & "Cycle Finish: " & CycleStop_Time & vbNewLine & "Cycle Time (Average): " & CycleTimeAverage & "ms" & vbNewLine & "PLC Data Readings: " & A_Time.Count - 1, MsgBoxStyle.Information)

                End If
                boCycleAbort = False
            Else
                Label5.Text = "Recording Cycle Completed - Cycle Duration: " & Format(TotalCycleTime / 1000, "0.0") & "s"
                MsgBox("Recording Cycle Completed! " & vbNewLine & vbNewLine & vbNewLine & "Cycle Start: " & CycleStart_Time & vbNewLine & "Cycle Finish: " & CycleStop_Time & vbNewLine & "Cycle Time (Average): " & CycleTimeAverage & "ms" & vbNewLine & "PLC Data Readings: " & A_Time.Count - 1, MsgBoxStyle.Information)
            End If

            ProgressBar1.Value = 0
            ProgressBar1.Visible = False
            ComboBox2.Enabled = True
            ComboBox4.Enabled = True
            ComboBox5.Enabled = True
            ComboBox6.Enabled = True
            Button1.Enabled = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: CycleFinished_ShowResults()")
        End Try
    End Sub

    Private Sub WaitForAutoTrigger_Tick(sender As Object, e As EventArgs) Handles WaitForAutoTrigger.Tick
        Try
            Label5.Text = "Waiting for PLC Trigger Signal"

            If boSimulatorMode Then
                If boSimulatorAutoStartCycle Then
                    BackgroundWorker_Simulator.RunWorkerAsync()
                    boSimulatorAutoStartCycle = False
                    WaitForAutoTrigger.Enabled = False
                End If
            Else
                If MachineType = "Laser" Then
                    Select Case StationSelected
                        Case "S20-Manipulator1"
                            ' "Output tag = DINT - 32 bits" - Sequence Step from bit 0 to 31
                            With Dint_to_BitArray(ReadFromAB_DINT(Laser_S20_Man1_AutoTrigger.PLC_Tag)) ' convert DINT to bit array of 32 bits
                                If .Item(Laser_S20_Man1_AutoTrigger.Bit_1) = Laser_S20_Man1_AutoTrigger.Bit1_State And .Item(Laser_S20_Man1_AutoTrigger.Bit_2) = Laser_S20_Man1_AutoTrigger.Bit2_State Then
                                    boLaserCycleStartAuto = True
                                    BackgroundWorker_Laser.RunWorkerAsync()
                                    WaitForAutoTrigger.Enabled = False
                                End If
                            End With
                        Case "S25-Shuttle1"
                            ' "Output tag = DINT - 32 bits" - Sequence Step from bit 0 to 31
                            With Dint_to_BitArray(ReadFromAB_DINT(Laser_S25Shuttle1_AutoTrigger.PLC_Tag)) ' convert DINT to bit array of 32 bits
                                If .Item(Laser_S25Shuttle1_AutoTrigger.Bit_1) = Laser_S25Shuttle1_AutoTrigger.Bit1_State And .Item(Laser_S25Shuttle1_AutoTrigger.Bit_2) = Laser_S25Shuttle1_AutoTrigger.Bit2_State Then
                                    boLaserCycleStartAuto = True
                                    BackgroundWorker_Laser.RunWorkerAsync()
                                    WaitForAutoTrigger.Enabled = False
                                End If
                            End With
                        Case "S25-Shuttle2"
                            ' "Output tag = DINT - 32 bits" - Sequence Step from bit 0 to 31
                            With Dint_to_BitArray(ReadFromAB_DINT(Laser_S25Shuttle2_AutoTrigger.PLC_Tag)) ' convert DINT to bit array of 32 bits
                                If .Item(Laser_S25Shuttle2_AutoTrigger.Bit_1) = Laser_S25Shuttle2_AutoTrigger.Bit1_State And .Item(Laser_S25Shuttle2_AutoTrigger.Bit_2) = Laser_S25Shuttle2_AutoTrigger.Bit2_State Then
                                    boLaserCycleStartAuto = True
                                    BackgroundWorker_Laser.RunWorkerAsync()
                                    WaitForAutoTrigger.Enabled = False
                                End If
                            End With
                        Case "S40-Manipulator2"
                            ' "Output tag = DINT - 32 bits" - Sequence Step from bit 0 to 31
                            With Dint_to_BitArray(ReadFromAB_DINT(Laser_S40_Man2_AutoTrigger.PLC_Tag)) ' convert DINT to bit array of 32 bits
                                If .Item(Laser_S40_Man2_AutoTrigger.Bit_1) = Laser_S40_Man2_AutoTrigger.Bit1_State And .Item(Laser_S40_Man2_AutoTrigger.Bit_2) = Laser_S40_Man2_AutoTrigger.Bit2_State Then
                                    boLaserCycleStartAuto = True
                                    BackgroundWorker_Laser.RunWorkerAsync()
                                    WaitForAutoTrigger.Enabled = False
                                End If
                            End With
                    End Select

                ElseIf MachineType = "Dispense" Then
                    'Add when ready
                ElseIf MachineType = "ISP" Then
                    'Add when ready

                End If

            End If

            If boCycleAbort Then
                WaitForAutoTrigger.Enabled = False
                CycleFinished_ShowResults()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: WaitForAutoTrigger_Tick()")
        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            If Button6.Text = "Auto Trigger" Then
                boSimulatorAutoStartCycle = True
                Button6.Text = "Stop"
            Else
                boSimulatorAutoStopCycle = True
                Button6.Text = "Auto Trigger"
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: Button6_Click()")
        End Try
    End Sub

    Private Sub GraphCurrentScreen()
        Try
            Select Case MachineType
                Case "Laser"
                    Select Case StationSelected
                        Case "S20-Manipulator1", "S40-Manipulator2"
                            Graph_CurrentScreen = StationSelected & "-" & AxisTypeSelected & " - " & AxisParameterSelected_1 & " / " & AxisParameterSelected_2
                        Case Else
                            Graph_CurrentScreen = StationSelected & " - " & AxisParameterSelected_1 & " / " & AxisParameterSelected_2
                    End Select
                Case "Dispense"
                    'Add when ready
                Case "ISP"
                    'Add when ready
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: GraphCurrentScreen()")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Export Axis Data as .txt button
        ExportToTextFile()
    End Sub

    Private Sub B_About_Click(sender As Object, e As EventArgs) Handles B_About.Click
        F_About.Show()
    End Sub
End Class


