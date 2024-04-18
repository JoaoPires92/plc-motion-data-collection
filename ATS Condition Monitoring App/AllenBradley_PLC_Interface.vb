Imports HslCommunication.Profinet.AllenBradley
Imports HslCommunication
Module AllenBradley_PLC_Interface
    Public AllenBradleyPLC As AllenBradleyNet 'Initial access to the PLC object
    Public AB_PLC_IP As String
    Public PLC_Connection As Boolean

    Public Sub ConnectTo_AB_PLC(PLC_IP As String)
        'PLC connection
        Try
            PLC_Connection = False
            AllenBradleyPLC = New AllenBradleyNet(PLC_IP)
            AllenBradleyPLC.ConnectTimeOut = 5000
            Dim Connect As OperateResult = AllenBradleyPLC.ConnectServer()
            If Connect.IsSuccess Then
                PLC_Connection = True
            Else
                PLC_Connection = False
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ConnectTo_AB_PLC()")
            PLC_Connection = False
        End Try
    End Sub

    Public Sub DisconnectFrom_AB_PLC()
        'Disconnect the PLC
        Try
            AllenBradleyPLC.ConnectClose()
            PLC_Connection = False

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: DisconnectFrom_AB_PLC()")
            PLC_Connection = False
        End Try
    End Sub
    Public Function ReadFromAB_Float(Tag_Name As String) As Double

        Try

            Dim PLC_DataReceived As Double
            PLC_DataReceived = AllenBradleyPLC.ReadFloat(Tag_Name).Content
            Return PLC_DataReceived

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ReadFromAB_Float()")
        End Try
    End Function

    Public Function ReadFromAB_Bool(Tag_Name As String) As Boolean

        Try
            Dim PLC_DataReceived As Boolean
            PLC_DataReceived = AllenBradleyPLC.ReadBool(Tag_Name).Content
            Return PLC_DataReceived

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ReadFromAB_Bool()")
        End Try
    End Function

    Public Function ReadFromAB_DINT(Tag_Name As String) As Integer

        Try
            Dim PLC_DataReceived As Integer
            PLC_DataReceived = AllenBradleyPLC.ReadInt32(Tag_Name).Content
            Return PLC_DataReceived

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: ReadFromAB_DINT()")
        End Try
    End Function

    Public Function Dint_to_BitArray(DINT As Integer) As BitArray

        Try
            If DINT <> Nothing Then
                Dim myBinaryString As String = Convert.ToString(DINT, 2)
                Dim myBitArray As New BitArray(32)

                'Store True for every "1" and False for every "0".
                For i = 0 To myBinaryString.Length - 1 Step 1
                    If i + 1 <= myBinaryString.Length Then
                        myBitArray(i) = (myBinaryString.Chars(myBinaryString.Length - 1 - i) = "1"c)
                    End If
                Next i
                Return myBitArray
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Failed to Execute: Dint_to_BitArray()")
        End Try

    End Function

End Module
