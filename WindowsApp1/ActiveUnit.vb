Imports WindowsApp1
Imports Reports

Public Class ActiveUnit
    Implements IActiveUnit

    Public Sub New(unitNumber As String, registry As String, sizeMM As Double, category As String, freight As String, timeIn As Date)
        Me.UnitNumber = unitNumber
        Me.Registry = registry
        Me.sizeMM = sizeMM
        Me.Category = category
        Me.Freight = freight
        Me.TimeIn = timeIn
    End Sub

    Private ReadOnly sizeMM As Double

    Public ReadOnly Property UnitNumber As String Implements IActiveUnit.UnitNumber
    Public ReadOnly Property Registry As String Implements IActiveUnit.Registry
    Public ReadOnly Property Category As String Implements IActiveUnit.Category
    Public ReadOnly Property Freight As String Implements IActiveUnit.Freight
    Public ReadOnly Property TimeIn As Date Implements IActiveUnit.TimeIn
    Public ReadOnly Property Size As Integer Implements IActiveUnit.Size
        Get
            Return Math.Round(sizeMM / 304.8, 0)
        End Get
    End Property

    Public ReadOnly Property TEU As Double Implements IActiveUnit.TEU
        Get
            Return Format(Size / 20, "0.00")
        End Get
    End Property

    Public ReadOnly Property Dwell(EndDate As Date) As Double Implements IActiveUnit.Dwell
        Get
            Return ReportFunctions.GetSpanDays(TimeIn, EndDate) + 1
        End Get
    End Property

End Class
