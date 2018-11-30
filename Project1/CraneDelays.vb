
Partial Class CraneDelays
    Partial Public Class NondeductableDataTable
        Public Function Totalhours() As Double
            Dim hours As Double = 0
            For Each row In Me.Rows
                hours += row("delayhours").ToString
            Next
            Return hours
        End Function
    End Class

    Partial Public Class DeductableDataTable
        Public Function Totalhours() As Double
            Dim hours As Double = 0
            For Each row In Me.Rows
                hours += row("delayhours").ToString
            Next
            Return hours
        End Function
    End Class

    Partial Public Class BreakDataTable

        Public Function Totalhours() As Double
            Dim hours As Double = 0
            For Each row In Me.Rows
                hours += row("delayhours").ToString
            Next
            Return hours
        End Function

        Private Sub BreakDataTable_BreakRowChanging(sender As Object, e As BreakRowChangeEvent) Handles Me.BreakRowChanging

        End Sub

    End Class
End Class
