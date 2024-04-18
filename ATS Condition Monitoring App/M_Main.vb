Imports System.IO
Imports Microsoft.Office.Interop

Module M_Main
    Public MachineSelected As String
    Public PLC_CommunicationLoadedOk As Boolean
    Public MachineNameloadedOk As Boolean
    Public boSimulatorMode As Boolean
    Public CycleDuration As Short
    Public MachineType As String
    Public StationSelected As String
    Public AxisTypeSelected As String
    Public AxisParameterSelected_1 As String
    Public AxisParameterSelected_2 As String
    Public Graph_CurrentScreen As String
    Public boAutomaticCycle As Boolean = False
    Public boManualCycle As Boolean = False
    Public CycleStart_Time As String
    Public CycleStop_Time As String
    Public boCycleAbort As Boolean
    Public StopWatch As New System.Diagnostics.Stopwatch
    Public ThreadSleepTime As Short
    Public TotalCycleTime As Integer = 0
    Public CycleTimeAverage As Double
    Public SimulatorCounter As Integer = 0
    Public boSimulatorAutoStartCycle As Boolean = False
    Public boSimulatorAutoStopCycle As Boolean = False
    Public boDataAvailableToDisplay As Boolean

    Public A_Time As New ArrayList

    Public Sub Load_AB_PLC_Communication()

        Dim AuxStr As String
        Dim FilePointer As FileStream
        Dim A_AuxStr() As String

        Try

            PLC_CommunicationLoadedOk = False

            FilePointer = New FileStream("Resources\AB_PLC_Communication.Dat", FileMode.Open, FileAccess.Read)

            Dim StreamInput As New StreamReader(FilePointer)

            StreamInput.BaseStream.Seek(0, SeekOrigin.Begin)

            AuxStr = ""

            Do Until AuxStr = "End of Configuration File"

                AuxStr = StreamInput.ReadLine()

                If Len(AuxStr) = 18 Then
                    A_AuxStr = AuxStr.Split("|")
                    If A_AuxStr(0) = "PLC_IP" Then AB_PLC_IP = A_AuxStr(1)
                Else
                    If AuxStr = "End of Configuration File" Then
                        PLC_CommunicationLoadedOk = True
                    Else
                        MsgBox("Load PLC communication file error.", MsgBoxStyle.Critical, "Load_PlcCommunication()")
                        PLC_CommunicationLoadedOk = False
                        Exit Sub
                    End If

                End If
            Loop

            StreamInput.Close()
            FilePointer.Close()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: Load_AB_PLC_Communication()")
            PLC_CommunicationLoadedOk = False
        End Try

    End Sub
    Public Sub Load_Machine_ID()

        Dim AuxStr As String
        Dim FilePointer As FileStream

        Try
            MachineNameloadedOk = False

            FilePointer = New FileStream("Resources\Machine_Name.Dat", FileMode.Open, FileAccess.Read)

            Dim StreamInput As New StreamReader(FilePointer)

            StreamInput.BaseStream.Seek(0, SeekOrigin.Begin)

            AuxStr = ""

            Do Until AuxStr = "End of Configuration File"

                AuxStr = StreamInput.ReadLine()

                If AuxStr <> "End of Configuration File" Then
                    F_Main.ComboBox1.Items.Add(AuxStr)
                Else
                    If AuxStr = "End of Configuration File" Then
                        MachineNameloadedOk = True
                    Else
                        MsgBox("Load Machine Name File Error", MsgBoxStyle.Critical, "Load_Machine_Name()")
                        MachineNameloadedOk = False
                        Exit Sub
                    End If

                End If
            Loop

            StreamInput.Close()
            FilePointer.Close()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: Load_AB_PLC_Communication()")
            MachineNameloadedOk = False
        End Try

    End Sub
    Public Function SaveDataIntoExcelSheet(ByVal FileName As String) As Boolean

        Dim objExcel As Excel.Application, objWorkbook As Excel.Workbook
        Dim objSheet As Excel.Worksheet
        Dim strFileName As String

        Try

            objExcel = CreateObject("Excel.Application")
            objExcel.Visible = True

            Select Case MachineType
                Case "Laser"
                    Select Case StationSelected
                        Case "S20-Manipulator1", "S40-Manipulator2"
                            strFileName = CurDir() & "\Resources\Template_S20_S40_Manipulator.xlsx"
                            objWorkbook = objExcel.Workbooks.Add(strFileName)
                            objSheet = objWorkbook.Sheets("X Axis")
                            objSheet.Name = StationSelected & "-X Axis"
                            objSheet.Select()
                            For i = 0 To A_Time.Count - 1
                                objSheet.Cells(2 + i, 1) = A_Position_S2040_Xaxis(i)
                                objSheet.Cells(2 + i, 2) = A_Current_S2040_Xaxis(i)
                                objSheet.Cells(2 + i, 3) = A_LagError_S2040_Xaxis(i)
                                objSheet.Cells(2 + i, 4) = A_Time(i)
                            Next
                            objSheet = objWorkbook.Sheets("Y Axis")
                            objSheet.Name = StationSelected & "-Y Axis"
                            objSheet.Select()
                            For i = 0 To A_Time.Count - 1
                                objSheet.Cells(2 + i, 1) = A_Position_S2040_Yaxis(i)
                                objSheet.Cells(2 + i, 2) = A_Current_S2040_Yaxis(i)
                                objSheet.Cells(2 + i, 3) = A_LagError_S2040_Yaxis(i)
                                objSheet.Cells(2 + i, 4) = A_Time(i)
                            Next
                            objSheet = objWorkbook.Sheets("Z Axis")
                            objSheet.Name = StationSelected & "-Z Axis"
                            objSheet.Select()
                            For i = 0 To A_Time.Count - 1
                                objSheet.Cells(2 + i, 1) = A_Position_S2040_Zaxis(i)
                                objSheet.Cells(2 + i, 2) = A_Current_S2040_Zaxis(i)
                                objSheet.Cells(2 + i, 4) = A_Force_S2040_Zaxis(i)
                                objSheet.Cells(2 + i, 5) = A_LagError_S2040_Zaxis(i)
                                objSheet.Cells(2 + i, 6) = A_Time(i)
                            Next
                            objSheet = objWorkbook.Sheets("Theta Axis")
                            objSheet.Name = StationSelected & "-Theta Axis"
                            objSheet.Select()
                            For i = 0 To A_Time.Count - 1
                                objSheet.Cells(2 + i, 1) = A_Position_S2040_Taxis(i)
                                objSheet.Cells(2 + i, 2) = A_Current_S2040_Taxis(i)
                                objSheet.Cells(2 + i, 4) = A_Torque_S2040_Taxis(i)
                                objSheet.Cells(2 + i, 5) = A_LagError_S2040_Taxis(i)
                                objSheet.Cells(2 + i, 6) = A_Time(i)
                            Next
                            objSheet = objWorkbook.Sheets(StationSelected & "-X Axis")
                            objSheet.Select()
                        Case "S25-Shuttle1", "S25-Shuttle2"
                            strFileName = CurDir() & "\Resources\Template_S25_Shuttle.xlsx"
                            objWorkbook = objExcel.Workbooks.Add(strFileName)
                            objSheet = objWorkbook.Sheets("S25-Shuttle")
                            objSheet.Name = StationSelected
                            For i = 0 To A_Time.Count - 1
                                objSheet.Cells(2 + i, 1) = A_Position_S25_Shuttle(i)
                                objSheet.Cells(2 + i, 2) = A_Current_S25_Shuttle(i)
                                objSheet.Cells(2 + i, 5) = A_LagError_S25_Shuttle(i)
                                objSheet.Cells(2 + i, 6) = A_Time(i)
                            Next
                    End Select

                Case "Dispense"
                    'Add when ready
                Case "ISP"
                    'Add when ready

            End Select

            objWorkbook.SaveAs(FileName, Excel.XlFileFormat.xlWorkbookDefault)
            objWorkbook.Close(False)
            objExcel.Quit()
            Return True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: SaveDataIntoExcelSheet() ")
            Return False
        End Try

    End Function

    Public Sub ExportToTextFile()
        Try

            Dim path As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim FILE_NAME As String

            ' Create File Name
            Select Case MachineType
                Case "Laser"
                    Select Case StationSelected
                        Case "S20-Manipulator1", "S40-Manipulator2"
                            FILE_NAME = path & "\" & MachineSelected & " - " & StationSelected & " - " & AxisTypeSelected & Now.ToString(" dd-MMM-yy") & ".txt"
                        Case "S25-Shuttle1", "S25-Shuttle2"
                            FILE_NAME = path & "\" & MachineSelected & " - " & StationSelected & Now.ToString(" dd-MMM-yy") & ".txt"
                    End Select
                Case "Dispense"
                    'Add when ready
                Case "ISP"
                    'Add when ready
            End Select

            ' Check if file already exists - If yes, do you want to replace it? Yes or No
            If System.IO.File.Exists(FILE_NAME) = False Then
                System.IO.File.Create(FILE_NAME).Dispose()
            Else
                Select Case MsgBox("File already exists in Location: " & FILE_NAME & vbNewLine & vbNewLine & "Do you want to replace it?", vbYesNoCancel Or vbExclamation Or vbDefaultButton1)
                    Case vbYes
                        System.IO.File.Delete(FILE_NAME)
                        System.IO.File.Create(FILE_NAME).Dispose()
                    Case vbNo
                        MsgBox("File not saved.", MsgBoxStyle.Critical)
                        Exit Sub
                    Case vbCancel
                        Exit Sub
                End Select
            End If

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)

            ' Write data to file
            Select Case MachineType
                Case "Laser"
                    Select Case StationSelected
                        Case "S20-Manipulator1", "S40-Manipulator2"
                            If AxisTypeSelected = "X Axis" Then
                                objWriter.WriteLine("Position(mm),Current(A),LagError(mm),Date&Time")
                                For i = 0 To A_Time.Count - 1
                                    objWriter.WriteLine(A_Position_S2040_Xaxis(i) & "," & A_Current_S2040_Xaxis(i) & "," & A_LagError_S2040_Xaxis(i) & "," & A_Time(i))
                                Next
                            ElseIf AxisTypeSelected = "Y Axis" Then
                                objWriter.WriteLine("Position(mm),Current(A),LagError(mm),Date&Time")
                                For i = 0 To A_Time.Count - 1
                                    objWriter.WriteLine(A_Position_S2040_Yaxis(i) & "," & A_Current_S2040_Yaxis(i) & "," & A_LagError_S2040_Yaxis(i) & "," & A_Time(i))
                                Next
                            ElseIf AxisTypeSelected = "Z Axis" Then
                                objWriter.WriteLine("Position(mm),Current(A),Force(N),LagError(mm),Date&Time")
                                For i = 0 To A_Time.Count - 1
                                    objWriter.WriteLine(A_Position_S2040_Zaxis(i) & "," & A_Current_S2040_Zaxis(i) & "," & A_LagError_S2040_Zaxis(i) & "," & A_Time(i))
                                Next
                            ElseIf AxisTypeSelected = "Theta Axis" Then
                                objWriter.WriteLine("Position(mm),Current(A),Torque(N),LagError(mm),Date&Time")
                                For i = 0 To A_Time.Count - 1
                                    objWriter.WriteLine(A_Position_S2040_Taxis(i) & "," & A_Current_S2040_Taxis(i) & "," & A_LagError_S2040_Taxis(i) & "," & A_Time(i))
                                Next
                            End If
                        Case "S25-Shuttle1", "S25-Shuttle2"
                            objWriter.WriteLine("Position(mm),Current(A),LagError(mm),Date&Time")
                            For i = 0 To A_Time.Count - 1
                                objWriter.WriteLine(A_Position_S25_Shuttle(i) & "," & A_Current_S25_Shuttle(i) & "," & A_LagError_S25_Shuttle(i) & "," & A_Time(i))
                            Next
                    End Select

                Case "Dispense"
                    'Add when ready

                Case "ISP"
                    'Add when ready

            End Select

            objWriter.Close()
            MsgBox("File Saved at Location: " & FILE_NAME, MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ExportToTextFile()")
        End Try

    End Sub
End Module
