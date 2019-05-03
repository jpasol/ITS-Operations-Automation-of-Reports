Module ReeferExtractor
    Public Sub Main()
        Dim ReeferDataFromN4 As New ReeferData(Date.Now)

        Dim update As Integer
        Dim added As Integer
        For Each reefer As ReeferData.reefer In ReeferDataFromN4
            Dim saveData As New SaveData(reefer)
            Select Case saveData.Remarks
                Case "Update"
                    update += 1
                Case "Added"
                    added += 1
            End Select
        Next

        MsgBox($"Operation Completed:{vbNewLine}{update} Reefers Updated {vbNewLine} {added} Reefers Added")


    End Sub
End Module
