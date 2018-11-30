Partial Class CraneMoves
    Partial Public Class GearboxDataTable
        Public Function Total20() As Double
            Dim boxes As Double = 0
            For Each row In Me.Rows
                boxes += row("gbxsze20").ToString
            Next
            Return boxes
        End Function

        Public Function Total40() As Double
            Dim boxes As Double = 0
            For Each row In Me.Rows
                boxes += row("gbxsze40").ToString
            Next
            Return boxes
        End Function

    End Class

    Partial Public Class HatchcoverDataTable

        Public Function Total20() As Double
            Dim boxes As Double = 0
            For Each row In Me.Rows
                boxes += row("cvrsze20").ToString
            Next
            Return boxes
        End Function

        Public Function Total40() As Double
            Dim boxes As Double = 0
            For Each row In Me.Rows
                boxes += row("cvrsze40").ToString
            Next
            Return boxes
        End Function

    End Class

    Partial Public Class ContainerDataTable
        Public Function Total20() As Double
            Dim boxes As Double = 0
            For Each row In Me.Rows
                boxes += row("cntsze20").ToString
            Next
            Return boxes
        End Function

        Public Function Total40() As Double
            Dim boxes As Double = 0
            For Each row In Me.Rows
                boxes += row("cntsze40").ToString
            Next
            Return boxes
        End Function

        Public Function Total45() As Double
            Dim boxes As Double = 0
            For Each row In Me.Rows
                boxes += row("cntsze45").ToString
            Next
            Return boxes
        End Function

    End Class

    Public Function TotalMoves() As Double
        Return Container.Total20 + Container.Total40 + Container.Total45 +
            Hatchcover.Total20 + Hatchcover.Total40 +
            Gearbox.Total20 + Gearbox.Total40

    End Function
End Class
