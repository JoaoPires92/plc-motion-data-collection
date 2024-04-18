Imports System.IO
Module M_Simulator
    Dim Aux As Integer = -1000
    Public Sub SimulatorMode()
        Try
            Select Case MachineType
                Case "Laser"
                    Select Case StationSelected
                        Case "S20-Manipulator1"
                            ' X Axis
                            A_Position_S2040_Xaxis.Add(SimulatorCounter)
                            A_Current_S2040_Xaxis.Add(Aux)
                            A_LagError_S2040_Xaxis.Add(SimulatorCounter)
                            'Y Axis
                            A_Position_S2040_Yaxis.Add(SimulatorCounter)
                            A_Current_S2040_Yaxis.Add(Aux)
                            A_LagError_S2040_Yaxis.Add(SimulatorCounter)
                            ' Z Axis
                            A_Position_S2040_Zaxis.Add(SimulatorCounter)
                            A_Current_S2040_Zaxis.Add(Aux)
                            A_Force_S2040_Zaxis.Add(SimulatorCounter)
                            A_LagError_S2040_Zaxis.Add(SimulatorCounter)
                            ' Theta Axis
                            A_Position_S2040_Taxis.Add(SimulatorCounter)
                            A_Current_S2040_Taxis.Add(Aux)
                            A_Torque_S2040_Taxis.Add(SimulatorCounter)
                            A_LagError_S2040_Taxis.Add(SimulatorCounter)
                        Case "S25-Shuttle1"
                            A_Position_S25_Shuttle.Add(SimulatorCounter)
                            A_Current_S25_Shuttle.Add(Aux)
                            A_LagError_S25_Shuttle.Add(SimulatorCounter)
                        Case "S25-Shuttle2"
                            A_Position_S25_Shuttle.Add(SimulatorCounter)
                            A_Current_S25_Shuttle.Add(Aux)
                            A_LagError_S25_Shuttle.Add(SimulatorCounter)
                        Case "S40-Manipulator2"
                            ' X Axis
                            A_Position_S2040_Xaxis.Add(SimulatorCounter)
                            A_Current_S2040_Xaxis.Add(Aux)
                            A_LagError_S2040_Xaxis.Add(SimulatorCounter)
                            'Y Axis
                            A_Position_S2040_Yaxis.Add(SimulatorCounter)
                            A_Current_S2040_Yaxis.Add(Aux)
                            A_LagError_S2040_Yaxis.Add(SimulatorCounter)
                            ' Z Axis
                            A_Position_S2040_Zaxis.Add(SimulatorCounter)
                            A_Current_S2040_Zaxis.Add(Aux)
                            A_Force_S2040_Zaxis.Add(SimulatorCounter)
                            A_LagError_S2040_Zaxis.Add(SimulatorCounter)
                            ' Theta Axis
                            A_Position_S2040_Taxis.Add(SimulatorCounter)
                            A_Current_S2040_Taxis.Add(Aux)
                            A_Torque_S2040_Taxis.Add(SimulatorCounter)
                            A_LagError_S2040_Taxis.Add(SimulatorCounter)
                    End Select
                Case "Dispense"
                    'Add when ready
                Case "ISP"
                    'Add when ready
            End Select
            SimulatorCounter = SimulatorCounter + 1
            Aux = Aux + 1

            TotalCycleTime = StopWatch.Elapsed.TotalMilliseconds
            A_Time.Add(Now.ToString("dd-MM-yyyy HH:mm:ss.fff"))

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: Thread_SimulatorMode()")
        End Try
    End Sub

End Module
