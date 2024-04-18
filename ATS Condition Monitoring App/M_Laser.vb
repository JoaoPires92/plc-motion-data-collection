Imports System.IO
Module M_Laser

    Public LaserAxisLoadedOk As Boolean
    Public boLaserCycleStartAuto As Boolean = False
    Public LaserPLCTags_LoadedOK As Boolean

    ' S20 Load Manipulator & S40 Unload Manipulator
    Public A_Position_S2040_Xaxis As New ArrayList
    Public A_Position_S2040_Yaxis As New ArrayList
    Public A_Position_S2040_Zaxis As New ArrayList
    Public A_Position_S2040_Taxis As New ArrayList

    Public A_Current_S2040_Xaxis As New ArrayList
    Public A_Current_S2040_Yaxis As New ArrayList
    Public A_Current_S2040_Zaxis As New ArrayList
    Public A_Current_S2040_Taxis As New ArrayList

    Public A_Speed_S2040_Zaxis As New ArrayList
    Public A_Speed_S2040_Taxis As New ArrayList

    Public A_Force_S2040_Zaxis As New ArrayList
    Public A_Torque_S2040_Taxis As New ArrayList

    Public A_LagError_S2040_Xaxis As New ArrayList
    Public A_LagError_S2040_Yaxis As New ArrayList
    Public A_LagError_S2040_Zaxis As New ArrayList
    Public A_LagError_S2040_Taxis As New ArrayList

    'S25 Shuttles
    Public A_Position_S25_Shuttle As New ArrayList
    Public A_Current_S25_Shuttle As New ArrayList
    Public A_Speed_S25_Shuttle As New ArrayList
    Public A_Force_S25_Shuttle As New ArrayList
    Public A_LagError_S25_Shuttle As New ArrayList

    Public Structure LaserAxes
        Public XAxis As String
        Public YAxis As String
        Public ZAxis As String
        Public TAxis As String
    End Structure
    Public Structure LaserS2040AxesParameters
        Public Position As LaserAxes
        Public Current As LaserAxes
        Public Speed As LaserAxes
        Public Force As LaserAxes
        Public Torque As LaserAxes
        Public LagError As LaserAxes
    End Structure
    Public Structure LaserS25Parameters
        Public Position As String
        Public Current As String
        Public Speed As String
        Public Force As String
        Public LagError As String
    End Structure

    Public Laser_S20_Man1_PlcTag As LaserS2040AxesParameters
    Public Laser_S40_Man2_PlcTag As LaserS2040AxesParameters
    Public Laser_S25Shuttle1_PlcTag As LaserS25Parameters
    Public Laser_S25Shuttle2_PlcTag As LaserS25Parameters

    Public Structure Laser_AutoStartStop
        Public PLC_Tag As String
        Public Bit_1 As Short
        Public Bit1_State As String
        Public Bit_2 As Short
        Public Bit2_State As String
    End Structure

    Public Laser_S20_Man1_AutoTrigger As Laser_AutoStartStop
    Public Laser_S20_Man1_AutoStop As Laser_AutoStartStop
    Public Laser_S25Shuttle1_AutoTrigger As Laser_AutoStartStop
    Public Laser_S25Shuttle1_AutoStop As Laser_AutoStartStop
    Public Laser_S25Shuttle2_AutoTrigger As Laser_AutoStartStop
    Public Laser_S25Shuttle2_AutoStop As Laser_AutoStartStop
    Public Laser_S40_Man2_AutoTrigger As Laser_AutoStartStop
    Public Laser_S40_Man2_AutoStop As Laser_AutoStartStop

    Public Sub Load_Laser_Stations()

        Dim AuxStr As String
        Dim FilePointer As FileStream

        Try
            LaserAxisLoadedOk = False

            FilePointer = New FileStream("Resources\Laser_StationsList.Dat", FileMode.Open, FileAccess.Read)

            Dim StreamInput As New StreamReader(FilePointer)

            StreamInput.BaseStream.Seek(0, SeekOrigin.Begin)
            AuxStr = ""

            Do Until AuxStr = "End of Configuration File"

                AuxStr = StreamInput.ReadLine()

                If AuxStr <> "End of Configuration File" Then
                    F_Main.ComboBox2.Items.Add(AuxStr)
                Else
                    If AuxStr = "End of Configuration File" Then
                        LaserAxisLoadedOk = True
                    Else
                        MsgBox("Load Machine Name File Error", MsgBoxStyle.Critical, "Load_Dispense_Axis()")
                        LaserAxisLoadedOk = False
                        Exit Sub
                    End If

                End If
            Loop

            StreamInput.Close()
            FilePointer.Close()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: Load_Dispense_Axis()")
            LaserAxisLoadedOk = False
        End Try

    End Sub
    Public Sub LoadLaserPLCTags()

        Dim AuxStr As String
        Dim FilePointer As FileStream
        Dim A_AuxStr() As String

        Try

            FilePointer = New FileStream("Resources\Laser_PLCTags.Dat", FileMode.Open, FileAccess.Read)

            Dim StreamInput As New StreamReader(FilePointer)

            StreamInput.BaseStream.Seek(0, SeekOrigin.Begin)

            AuxStr = ""

            Do Until AuxStr = "End of Configuration File"

                AuxStr = StreamInput.ReadLine()

                If Len(AuxStr) > 25 Then

                    A_AuxStr = AuxStr.Split("|")

                    Select Case A_AuxStr(0)
                        Case "S20-Manipulator1"
                            If A_AuxStr(1) = "X Axis" Then
                                Laser_S20_Man1_PlcTag.Position.XAxis = A_AuxStr(2)
                                Laser_S20_Man1_PlcTag.Current.XAxis = A_AuxStr(3)
                                Laser_S20_Man1_PlcTag.LagError.XAxis = A_AuxStr(4)
                            ElseIf A_AuxStr(1) = "Y Axis" Then
                                Laser_S20_Man1_PlcTag.Position.YAxis = A_AuxStr(2)
                                Laser_S20_Man1_PlcTag.Current.YAxis = A_AuxStr(3)
                                Laser_S20_Man1_PlcTag.LagError.YAxis = A_AuxStr(4)
                            ElseIf A_AuxStr(1) = "Z Axis" Then
                                Laser_S20_Man1_PlcTag.Position.ZAxis = A_AuxStr(2)
                                Laser_S20_Man1_PlcTag.Current.ZAxis = A_AuxStr(3)
                                Laser_S20_Man1_PlcTag.Force.ZAxis = A_AuxStr(4)
                                Laser_S20_Man1_PlcTag.LagError.ZAxis = A_AuxStr(5)
                            ElseIf A_AuxStr(1) = "Theta Axis" Then
                                Laser_S20_Man1_PlcTag.Position.TAxis = A_AuxStr(2)
                                Laser_S20_Man1_PlcTag.Current.TAxis = A_AuxStr(3)
                                Laser_S20_Man1_PlcTag.Torque.TAxis = A_AuxStr(4)
                                Laser_S20_Man1_PlcTag.LagError.TAxis = A_AuxStr(5)
                            ElseIf A_AuxStr(1) = "AutoTrigger" Then
                                ' AutoTrigger
                                Laser_S20_Man1_AutoTrigger.PLC_Tag = A_AuxStr(2)
                                Laser_S20_Man1_AutoTrigger.Bit_1 = A_AuxStr(3)
                                Laser_S20_Man1_AutoTrigger.Bit1_State = A_AuxStr(4)
                                Laser_S20_Man1_AutoTrigger.Bit_2 = A_AuxStr(5)
                                Laser_S20_Man1_AutoTrigger.Bit2_State = A_AuxStr(6)
                                'AutoStop
                                Laser_S20_Man1_AutoStop.PLC_Tag = A_AuxStr(8)
                                Laser_S20_Man1_AutoStop.Bit_1 = A_AuxStr(9)
                                Laser_S20_Man1_AutoStop.Bit1_State = A_AuxStr(10)
                                Laser_S20_Man1_AutoStop.Bit_2 = A_AuxStr(11)
                                Laser_S20_Man1_AutoStop.Bit2_State = A_AuxStr(12)
                            End If
                        Case "S40-Manipulator2"
                            If A_AuxStr(1) = "X Axis" Then
                                Laser_S40_Man2_PlcTag.Position.XAxis = A_AuxStr(2)
                                Laser_S40_Man2_PlcTag.Current.XAxis = A_AuxStr(3)
                                Laser_S40_Man2_PlcTag.LagError.XAxis = A_AuxStr(4)
                            ElseIf A_AuxStr(1) = "Y Axis" Then
                                Laser_S40_Man2_PlcTag.Position.YAxis = A_AuxStr(2)
                                Laser_S40_Man2_PlcTag.Current.YAxis = A_AuxStr(3)
                                Laser_S40_Man2_PlcTag.LagError.YAxis = A_AuxStr(4)
                            ElseIf A_AuxStr(1) = "Z Axis" Then
                                Laser_S40_Man2_PlcTag.Position.ZAxis = A_AuxStr(2)
                                Laser_S40_Man2_PlcTag.Current.ZAxis = A_AuxStr(3)
                                Laser_S40_Man2_PlcTag.Force.ZAxis = A_AuxStr(4)
                                Laser_S40_Man2_PlcTag.LagError.ZAxis = A_AuxStr(5)
                            ElseIf A_AuxStr(1) = "Theta Axis" Then
                                Laser_S40_Man2_PlcTag.Position.TAxis = A_AuxStr(2)
                                Laser_S40_Man2_PlcTag.Current.TAxis = A_AuxStr(3)
                                Laser_S40_Man2_PlcTag.Torque.TAxis = A_AuxStr(4)
                                Laser_S40_Man2_PlcTag.LagError.TAxis = A_AuxStr(5)
                            ElseIf A_AuxStr(1) = "AutoTrigger" Then
                                ' AutoTrigger
                                Laser_S40_Man2_AutoTrigger.PLC_Tag = A_AuxStr(2)
                                Laser_S40_Man2_AutoTrigger.Bit_1 = A_AuxStr(3)
                                Laser_S40_Man2_AutoTrigger.Bit1_State = A_AuxStr(4)
                                Laser_S40_Man2_AutoTrigger.Bit_2 = A_AuxStr(5)
                                Laser_S40_Man2_AutoTrigger.Bit2_State = A_AuxStr(6)
                                'AutoStop
                                Laser_S40_Man2_AutoStop.PLC_Tag = A_AuxStr(8)
                                Laser_S40_Man2_AutoStop.Bit_1 = A_AuxStr(9)
                                Laser_S40_Man2_AutoStop.Bit1_State = A_AuxStr(10)
                                Laser_S40_Man2_AutoStop.Bit_2 = A_AuxStr(11)
                                Laser_S40_Man2_AutoStop.Bit2_State = A_AuxStr(12)
                            End If
                        Case "S25-Shuttle1"
                            If A_AuxStr(1) = "AutoTrigger" Then
                                ' AutoTrigger
                                Laser_S25Shuttle1_AutoTrigger.PLC_Tag = A_AuxStr(2)
                                Laser_S25Shuttle1_AutoTrigger.Bit_1 = A_AuxStr(3)
                                Laser_S25Shuttle1_AutoTrigger.Bit1_State = A_AuxStr(4)
                                Laser_S25Shuttle1_AutoTrigger.Bit_2 = A_AuxStr(5)
                                Laser_S25Shuttle1_AutoTrigger.Bit2_State = A_AuxStr(6)
                                'AutoStop
                                Laser_S25Shuttle1_AutoStop.PLC_Tag = A_AuxStr(8)
                                Laser_S25Shuttle1_AutoStop.Bit_1 = A_AuxStr(9)
                                Laser_S25Shuttle1_AutoStop.Bit1_State = A_AuxStr(10)
                                Laser_S25Shuttle1_AutoStop.Bit_2 = A_AuxStr(11)
                                Laser_S25Shuttle1_AutoStop.Bit2_State = A_AuxStr(12)
                            Else
                                Laser_S25Shuttle1_PlcTag.Position = A_AuxStr(1)
                                Laser_S25Shuttle1_PlcTag.Current = A_AuxStr(2)
                                Laser_S25Shuttle1_PlcTag.LagError = A_AuxStr(3)
                            End If
                        Case "S25-Shuttle2"
                            If A_AuxStr(1) = "AutoTrigger" Then
                                ' AutoTrigger
                                Laser_S25Shuttle2_AutoTrigger.PLC_Tag = A_AuxStr(2)
                                Laser_S25Shuttle2_AutoTrigger.Bit_1 = A_AuxStr(3)
                                Laser_S25Shuttle2_AutoTrigger.Bit1_State = A_AuxStr(4)
                                Laser_S25Shuttle2_AutoTrigger.Bit_2 = A_AuxStr(5)
                                Laser_S25Shuttle2_AutoTrigger.Bit2_State = A_AuxStr(6)
                                'AutoStop
                                Laser_S25Shuttle2_AutoStop.PLC_Tag = A_AuxStr(8)
                                Laser_S25Shuttle2_AutoStop.Bit_1 = A_AuxStr(9)
                                Laser_S25Shuttle2_AutoStop.Bit1_State = A_AuxStr(10)
                                Laser_S25Shuttle2_AutoStop.Bit_2 = A_AuxStr(11)
                                Laser_S25Shuttle2_AutoStop.Bit2_State = A_AuxStr(12)
                            Else
                                Laser_S25Shuttle2_PlcTag.Position = A_AuxStr(1)
                                Laser_S25Shuttle2_PlcTag.Current = A_AuxStr(2)
                                Laser_S25Shuttle2_PlcTag.LagError = A_AuxStr(3)
                            End If
                    End Select

                Else
                    If AuxStr = "End of Configuration File" Then
                        LaserPLCTags_LoadedOK = True
                    Else
                        MsgBox("Load Laser PLC Tags error.", MsgBoxStyle.Critical, "LoadLaserPLCTags()")
                        LaserPLCTags_LoadedOK = False
                        Exit Sub
                    End If

                End If
            Loop

            StreamInput.Close()
            FilePointer.Close()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: LoadLaserPLCTags()")
            LaserPLCTags_LoadedOK = False
        End Try

    End Sub

    Public Sub ReadDataFromPLC_Laser()
        Try
            Select Case StationSelected
                Case "S20-Manipulator1"
                    ' X Axis
                    A_Position_S2040_Xaxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.Position.XAxis))
                    A_Current_S2040_Xaxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.Current.XAxis))
                    A_LagError_S2040_Xaxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.LagError.XAxis))
                    'Y Axis
                    A_Position_S2040_Yaxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.Position.YAxis))
                    A_Current_S2040_Yaxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.Current.YAxis))
                    A_LagError_S2040_Yaxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.LagError.YAxis))
                    ' Z Axis
                    A_Position_S2040_Zaxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.Position.ZAxis))
                    A_Current_S2040_Zaxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.Current.ZAxis))
                    A_Force_S2040_Zaxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.Force.ZAxis))
                    A_LagError_S2040_Zaxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.LagError.ZAxis))
                    ' Theta Axis
                    A_Position_S2040_Taxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.Position.TAxis))
                    A_Current_S2040_Taxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.Current.TAxis))
                    A_Torque_S2040_Taxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.Torque.TAxis))
                    A_LagError_S2040_Taxis.Add(ReadFromAB_Float(Laser_S20_Man1_PlcTag.LagError.TAxis))

                Case "S25-Shuttle1"
                    A_Position_S25_Shuttle.Add(ReadFromAB_Float(Laser_S25Shuttle1_PlcTag.Position))
                    A_Current_S25_Shuttle.Add(ReadFromAB_Float(Laser_S25Shuttle1_PlcTag.Current))
                    A_LagError_S25_Shuttle.Add(ReadFromAB_Float(Laser_S25Shuttle1_PlcTag.LagError))

                Case "S25-Shuttle2"
                    A_Position_S25_Shuttle.Add(ReadFromAB_Float(Laser_S25Shuttle2_PlcTag.Position))
                    A_Current_S25_Shuttle.Add(ReadFromAB_Float(Laser_S25Shuttle2_PlcTag.Current))
                    A_LagError_S25_Shuttle.Add(ReadFromAB_Float(Laser_S25Shuttle2_PlcTag.LagError))

                Case "S40-Manipulator2"
                    ' X Axis
                    A_Position_S2040_Xaxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.Position.XAxis))
                    A_Current_S2040_Xaxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.Current.XAxis))
                    A_LagError_S2040_Xaxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.LagError.XAxis))
                    'Y Axis
                    A_Position_S2040_Yaxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.Position.YAxis))
                    A_Current_S2040_Yaxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.Current.YAxis))
                    A_LagError_S2040_Yaxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.LagError.YAxis))
                    ' Z Axis
                    A_Position_S2040_Zaxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.Position.ZAxis))
                    A_Current_S2040_Zaxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.Current.ZAxis))
                    A_Force_S2040_Zaxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.Force.ZAxis))
                    A_LagError_S2040_Zaxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.LagError.ZAxis))
                    ' Theta Axis
                    A_Position_S2040_Taxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.Position.TAxis))
                    A_Current_S2040_Taxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.Current.TAxis))
                    A_Torque_S2040_Taxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.Torque.TAxis))
                    A_LagError_S2040_Taxis.Add(ReadFromAB_Float(Laser_S40_Man2_PlcTag.LagError.TAxis))

            End Select

            TotalCycleTime = StopWatch.Elapsed.TotalMilliseconds
            A_Time.Add(Now.ToString("dd-MM-yyyy HH:mm:ss.fff"))

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ReadDataFromPLC_Laser()")
        End Try
    End Sub

    Public Sub AutomaticCycle_MonitorCycleStop()

        Select Case StationSelected
            Case "S20-Manipulator1"
                ' "Output tag = DINT - 32 bits" - Sequence Step from bit 0 to 31
                With Dint_to_BitArray(ReadFromAB_DINT(Laser_S20_Man1_AutoStop.PLC_Tag)) ' convert DINT to bit array of 32 bits
                    If .Item(Laser_S20_Man1_AutoStop.Bit_1) = Laser_S20_Man1_AutoStop.Bit1_State And .Item(Laser_S20_Man1_AutoStop.Bit_2) = Laser_S20_Man1_AutoStop.Bit2_State Then
                        boLaserCycleStartAuto = False
                    End If
                End With
            Case "S25-Shuttle1"
                ' "Output tag = DINT - 32 bits" - Sequence Step from bit 0 to 31
                With Dint_to_BitArray(ReadFromAB_DINT(Laser_S25Shuttle1_AutoStop.PLC_Tag)) ' convert DINT to bit array of 32 bits
                    If .Item(Laser_S25Shuttle1_AutoStop.Bit_1) = Laser_S25Shuttle1_AutoStop.Bit1_State And .Item(Laser_S25Shuttle1_AutoStop.Bit_2) = Laser_S25Shuttle1_AutoStop.Bit2_State Then
                        boLaserCycleStartAuto = False
                    End If
                End With
            Case "S25-Shuttle2"
                ' "Output tag = DINT - 32 bits" - Sequence Step from bit 0 to 31
                With Dint_to_BitArray(ReadFromAB_DINT(Laser_S25Shuttle2_AutoStop.PLC_Tag)) ' convert DINT to bit array of 32 bits
                    If .Item(Laser_S25Shuttle2_AutoStop.Bit_1) = Laser_S25Shuttle2_AutoStop.Bit1_State And .Item(Laser_S25Shuttle2_AutoStop.Bit_2) = Laser_S25Shuttle2_AutoStop.Bit2_State Then
                        boLaserCycleStartAuto = False
                    End If
                End With
            Case "S40-Manipulator2"
                ' "Output tag = DINT - 32 bits" - Sequence Step from bit 0 to 31
                With Dint_to_BitArray(ReadFromAB_DINT(Laser_S40_Man2_AutoStop.PLC_Tag)) ' convert DINT to bit array of 32 bits
                    If .Item(Laser_S40_Man2_AutoStop.Bit_1) = Laser_S40_Man2_AutoStop.Bit1_State And .Item(Laser_S40_Man2_AutoStop.Bit_2) = Laser_S40_Man2_AutoStop.Bit2_State Then
                        boLaserCycleStartAuto = False
                    End If
                End With
        End Select
    End Sub

End Module
