Imports System.Linq

Partial Class CraneMoves
    Partial Public Class InboundDataTable

    End Class

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
        Public Function Total20(Optional CraneMove As String = "", Optional Movekind As String = "") As Double
            Dim boxes As Double = 0
            Dim wherecol As Collections.Generic.IEnumerable(Of System.Data.DataRow)

            With Me.AsEnumerable
                If CraneMove = "" And Movekind = "" Then
                    wherecol = Me.AsEnumerable
                ElseIf CraneMove <> "" And Movekind = "" Then
                    wherecol = .Where(Function(row) row("ctrmve") = Movekind)
                ElseIf CraneMove = "" And Movekind <> "" Then
                    wherecol = .Where(Function(row) row("move_kind") = CraneMove)
                Else
                    wherecol = .Where(Function(row) row("ctrmve") = Movekind And row("move_kind") = CraneMove)
                End If
            End With
            boxes = wherecol.Sum(Function(row) row("cntsze20"))
            Return boxes
            'For Each row In Me.Rows
            '    boxes += row("cntsze20").ToString
            'Next
            'Return boxes
        End Function

        Public Function Total40(Optional CraneMove As String = "", Optional Movekind As String = "") As Double
            Dim boxes As Double = 0
            Dim wherecol As Collections.Generic.IEnumerable(Of System.Data.DataRow)

            With Me.AsEnumerable
                If CraneMove = "" And Movekind = "" Then
                    wherecol = Me.AsEnumerable
                ElseIf CraneMove <> "" And Movekind = "" Then
                    wherecol = .Where(Function(row) row("ctrmve") = Movekind)
                ElseIf CraneMove = "" And Movekind <> "" Then
                    wherecol = .Where(Function(row) row("move_kind") = CraneMove)
                Else
                    wherecol = .Where(Function(row) row("ctrmve") = Movekind And row("move_kind") = CraneMove)
                End If
            End With
            boxes = wherecol.Sum(Function(row) row("cntsze40"))
            Return boxes
            'For Each row In Me.Rows
            '    boxes += row("cntsze40").ToString
            'Next
            'Return boxes
        End Function

        Public Function Total45(Optional CraneMove As String = "", Optional Movekind As String = "") As Double
            Dim boxes As Double = 0
            Dim wherecol As Collections.Generic.IEnumerable(Of System.Data.DataRow)

            With Me.AsEnumerable
                If CraneMove = "" And Movekind = "" Then
                    wherecol = Me.AsEnumerable
                ElseIf CraneMove <> "" And Movekind = "" Then
                    wherecol = .Where(Function(row) row("ctrmve") = Movekind)
                ElseIf CraneMove = "" And Movekind <> "" Then
                    wherecol = .Where(Function(row) row("move_kind") = CraneMove)
                Else
                    wherecol = .Where(Function(row) row("ctrmve") = Movekind And row("move_kind") = CraneMove)
                End If
            End With
            boxes = wherecol.Sum(Function(row) row("cntsze45"))
            Return boxes
            'For Each row In Me.Rows
            '    boxes += row("cntsze45").ToString
            'Next
            'Return boxes
        End Function

    End Class

    Public Function TotalMoves() As Double
        Return Container.Total20 + Container.Total40 + Container.Total45 +
            Hatchcover.Total20 + Hatchcover.Total40 +
            Gearbox.Total20 + Gearbox.Total40

    End Function
End Class
