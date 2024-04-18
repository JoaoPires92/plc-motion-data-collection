Imports System.IO
Module M_Dispense
    Public DispenseAxisLoadedOk As Boolean
    Public Sub Load_Dispense_Stations()

        Dim AuxStr As String
        Dim FilePointer As FileStream

        Try
            DispenseAxisLoadedOk = False

            FilePointer = New FileStream("Resources\Dispense_StationsList.Dat", FileMode.Open, FileAccess.Read)

            Dim StreamInput As New StreamReader(FilePointer)

            StreamInput.BaseStream.Seek(0, SeekOrigin.Begin)

            AuxStr = ""

            Do Until AuxStr = "End of Configuration File"

                AuxStr = StreamInput.ReadLine()

                If AuxStr <> "End of Configuration File" Then
                    F_Main.ComboBox2.Items.Add(AuxStr)
                Else
                    If AuxStr = "End of Configuration File" Then
                        DispenseAxisLoadedOk = True
                    Else
                        MsgBox("Load Machine Name File Error", MsgBoxStyle.Critical, "Load_Dispense_Axis()")
                        DispenseAxisLoadedOk = False
                        Exit Sub
                    End If

                End If
            Loop

            StreamInput.Close()
            FilePointer.Close()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: Load_Dispense_Axis()")
            DispenseAxisLoadedOk = False
        End Try

    End Sub

    Public Sub ReadDataFromPLC_Dispense()
        Try
            Select Case StationSelected
                Case "S30_1-Dispense1", "S30_1-Dispense1"
                Case "S40-ETester "
            End Select

            TotalCycleTime = StopWatch.Elapsed.TotalMilliseconds
            A_Time.Add(Now.ToString("dd-MM-yyyy hh:mm:ss.fff"))

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ReadDataFromPLC_Dispense()")
        End Try
    End Sub

End Module
