﻿Imports System.Data
Imports System.Linq
Imports Reports
Imports Reports.ReportFunctions

Partial Class CraneMoves

    Partial Public Class Hatchcover1DataTable

        Private Sub Hatchcover1DataTable_TableNewRow(sender As Object, e As DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("actual_ob") = "Registry" 'Convert nalang pagkasave
        End Sub

        Friend ReadOnly Property TotalMoves(v As Integer) As Integer
            Get
                Dim boxes As Double = 0
                For Each row In Me.Rows
                    boxes += row($"cvrsze{v}").ToString
                Next
                Return boxes
            End Get
        End Property
    End Class

    Partial Public Class Gearbox1DataTable
        Private Sub Gearbox1DataTable_TableNewRow(sender As Object, e As DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("actual_ob") = "Registry" 'Convert nalang pagkasave
        End Sub

        Friend ReadOnly Property TotalMoves(v As Integer) As Integer
            Get
                Dim boxes As Double = 0
                For Each row In Me.Rows
                    boxes += row($"gbxsze{v}").ToString
                Next
                Return boxes
            End Get
        End Property
    End Class

    Partial Public Class GearboxDataTable

        Friend ReadOnly Property TotalMoves(v As Integer) As Integer
            Get
                Dim boxes As Double = 0
                For Each row In Me.Rows
                    boxes += row($"gbxsze{v}").ToString
                Next
                Return boxes
            End Get
        End Property

        Private Sub GearboxDataTable_TableNewRow(sender As Object, e As DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("actual_ib") = "Registry" 'Convert nalang pagkasave
        End Sub
    End Class

    Partial Public Class HatchcoverDataTable

        Friend ReadOnly Property TotalMoves(v As Integer) As Integer
            Get
                Dim boxes As Double = 0
                For Each row In Me.Rows
                    boxes += row($"cvrsze{v}").ToString
                Next
                Return boxes
            End Get
        End Property

        Private Sub HatchcoverDataTable_TableNewRow(sender As Object, e As DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("actual_ib") = "Registry" 'Convert nalang pagkasave
        End Sub
    End Class

    Partial Public Class ContainerDataTable

        Public ReadOnly Property TotalMoves(v As Integer, Optional freight As String = "", Optional bound As String = "") As Integer
            Get
                Dim boxes As Double = 0
                Dim wherecol As Collections.Generic.IEnumerable(Of System.Data.DataRow)

                With Me.AsEnumerable
                    If freight = "" And bound = "" Then
                        wherecol = Me.AsEnumerable
                    ElseIf freight <> "" And bound = "" Then
                        Select Case bound
                            Case "Discharge"
                                wherecol = .Where(Function(row) ParseDBNulltoString(row("actual_ib")) <> "")
                            Case "Loading"
                                wherecol = .Where(Function(row) ParseDBNulltoString(row("actual_ob")) <> "")
                        End Select
                        'wherecol = .Where(Function(row) row("move_kind") = bound)
                    ElseIf freight = "" And bound <> "" Then
                        wherecol = .Where(Function(row) row("freight_kind") = freight)
                    Else
                        Select Case bound
                            Case "Discharge"
                                wherecol = .Where(Function(row) ParseDBNulltoString(row("actual_ib")) <> "" And row("freight_kind") = freight)
                            Case "Loading"
                                wherecol = .Where(Function(row) ParseDBNulltoString(row("actual_ob")) <> "" And row("freight_kind") = freight)
                        End Select
                        'wherecol = .Where(Function(row) row("move_kind") = bound And row("freight_kind") = freight)
                    End If
                End With

                boxes = wherecol.Sum(Function(row) row($"cntsze{v}"))
                Return boxes
            End Get
        End Property

        Public ReadOnly Property TotalUnits(v As Integer, Optional freight As String = "", Optional bound As String = "") As Integer
            Get
                Dim boxes As Double = 0
                Dim wherecol As Collections.Generic.IEnumerable(Of System.Data.DataRow)

                With Me.AsEnumerable
                    If freight = "" And bound = "" Then
                        wherecol = Me.AsEnumerable
                    ElseIf freight <> "" And bound = "" Then
                        Select Case bound
                            Case "Discharge"
                                wherecol = .Where(Function(row) ParseDBNulltoString(row("actual_ib")) <> "" And
                                                      row("container") <> "SHFT")
                            Case "Loading"
                                wherecol = .Where(Function(row) ParseDBNulltoString(row("actual_ob")) <> "" And
                                                      row("container") <> "SHFT")
                        End Select
                        'wherecol = .Where(Function(row) row("move_kind") = bound)
                    ElseIf freight = "" And bound <> "" Then
                        wherecol = .Where(Function(row) row("freight_kind") = freight)
                    Else
                        Select Case bound
                            Case "Discharge"
                                wherecol = .Where(Function(row) ParseDBNulltoString(row("actual_ib")) <> "" And
                                                      row("freight_kind") = freight And
                                                      row("container") <> "SHFT")
                            Case "Loading"
                                wherecol = .Where(Function(row) ParseDBNulltoString(row("actual_ob")) <> "" And
                                                      row("freight_kind") = freight And
                                                      row("container") <> "SHFT")
                        End Select
                        'wherecol = .Where(Function(row) row("move_kind") = bound And row("freight_kind") = freight)
                    End If
                End With

                boxes = wherecol.Sum(Function(row) row($"cntsze{v}"))
                Return boxes
            End Get
        End Property

    End Class

    Public Function TotalMoves() As Double
        Return Container.TotalMoves(20) + Container.TotalMoves(40) + Container.TotalMoves(45) +
            Hatchcover.TotalMoves(20) + Hatchcover.TotalMoves(40) +
            Hatchcover1.TotalMoves(20) + Hatchcover1.TotalMoves(40) +
            Gearbox.TotalMoves(20) + Gearbox.TotalMoves(40) +
            Gearbox1.TotalMoves(20) + Gearbox1.TotalMoves(40)

    End Function

End Class
