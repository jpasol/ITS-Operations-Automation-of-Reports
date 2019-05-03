Public Class EmptyChargeableUnits
    Inherits Report_EmptyIn

    Public Structure EmptyUnits
        Public Sub New(ContainerNumber As String,
                       FreightKind As String,
                       LineOperator As String,
                       Length As Integer,
                       Group As String)
            Me.ContainerNumber = ContainerNumber
            Me.FreightKind = FreightKind
            Me.LineOperator = LineOperator
            Me.Length = Length
            Me.Group = Group
        End Sub
        Public ReadOnly Property ContainerNumber As String
        Public ReadOnly Property FreightKind As String
        Public ReadOnly Property LineOperator As String
        Public ReadOnly Property Length As Integer
        Public ReadOnly Property TEU As Double
            Get
                Return Length / 20
            End Get
        End Property

        Public ReadOnly Property Group As String
    End Structure

    Public Sub New(Month As Integer, Day As Integer, Year As Integer)

        Me.Month = Month
        Me.Day = Day
        Me.Year = Year

        StartDate = New Date(month:=Month, day:=Day - 1, year:=Year)
        EndDate = New Date(month:=Month, day:=Day, year:=Year)
        ReportData = New ReportData
        NCTAllocation = New Dictionary(Of String, Double)
        ECDAllocation = New Dictionary(Of String, Double)
        ChargeableUnitEvents = New List(Of EmptyUnits)
        CoLoading = New Dictionary(Of String, String())

        GetNCTAllocation()
        GetECDAllocation()
        GetCoLoading()

        RetrieveChargeableUnits()
        GenerateChargeableUnits()
        GenerateInventory()
        Me.SetDataSource(ReportData)
    End Sub

    Private Sub GetCoLoading()
        Using Reader As New Microsoft.VisualBasic.FileIO.TextFieldParser($"{Application.StartupPath}\CoLoading.csv")
            Reader.TextFieldType = FileIO.FieldType.Delimited
            Reader.SetDelimiters(",")
            While Not Reader.EndOfData
                Dim current As String() = Reader.ReadFields()
                CoLoading.Add(current(0), current)
            End While
        End Using
    End Sub

    Private Sub GenerateInventory()
        Dim groups As String() = {"ECD", "NCT"}
        Dim InventoryDictionary As Dictionary(Of String, Double)
        For Each group As String In groups
            Select Case group
                Case "ECD"
                    InventoryDictionary = ECDAllocation
                Case "NCT"
                    InventoryDictionary = NCTAllocation
            End Select

            CreateEntry(InventoryDictionary, group)

        Next
    End Sub

    Private Sub CreateEntry(InventoryDictionary As Dictionary(Of String, Double), group As String)
        For Each key As String In InventoryDictionary.Keys
            With ReportData._ReportData
                Dim lineOP As String = key
                Dim allocation As Double = InventoryDictionary.Item(key)
                Dim inventory As Double = ChargeableUnitEvents.AsEnumerable.
                Where(Function(inv) inv.LineOperator = key And inv.Group = group).Sum(Function(inv) inv.TEU)

                Dim remaining As Double = allocation - inventory
                Dim CurrentVariance As Double = (inventory / allocation) * 100


                Dim day1 As Double = 0
                Dim day2 As Double = 0
                Dim day3 As Double = 0
                Dim day4 As Double = 0
                Dim day5 As Double = 0
                Dim day6 As Double = 0
                Dim day7 As Double = IIf(Double.IsNaN(CurrentVariance), 0, CurrentVariance)

                .AddReportDataRow(LineOperator:=key,
                                  Allocation:=allocation, Inventory:=inventory,
                                  Remaining:=remaining,
                                  Day1:=day1,
                                  Day2:=day2,
                                  Day3:=day3,
                                  Day4:=day4,
                                  Day5:=day5,
                                  Day6:=day6,
                                  Day7:=day7,
                                  Group:=group
                                  )
            End With
        Next
    End Sub

    Private Sub GenerateECDInventory()
    End Sub

    Private Sub GetECDAllocation()
        Dim Connection As New OleDb.OleDbConnection
        Connection.ConnectionString = $"
Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Application.StartupPath}\ECD Allocation.xlsx;
Extended Properties=""Excel 12.0 Xml;HDR=YES"";
"
        Connection.Open()

        Dim command As New OleDb.OleDbCommand
        command.Connection = Connection
        command.CommandText = "Select * from [Sheet1$]"

        Dim tempDatatable As New DataTable
        Dim tempAdapter As New OleDb.OleDbDataAdapter
        tempAdapter.SelectCommand = command

        tempAdapter.Fill(tempDatatable)

        For Each row As DataRow In tempDatatable.Rows
            ECDAllocation.Add(Trim(row(0)), row(1))
        Next
    End Sub

    Private Sub GetNCTAllocation()
        Dim Connection As New OleDb.OleDbConnection
        Connection.ConnectionString = $"
Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Application.StartupPath}\NCT Allocation.xlsx;
Extended Properties=""Excel 12.0 Xml;HDR=YES"";
"
        Connection.Open()

        Dim command As New OleDb.OleDbCommand
        command.Connection = Connection
        command.CommandText = "Select * from [Sheet1$]"

        Dim tempDatatable As New DataTable
        Dim tempAdapter As New OleDb.OleDbDataAdapter
        tempAdapter.SelectCommand = command

        tempAdapter.Fill(tempDatatable)
        For Each row As DataRow In tempDatatable.Rows
            NCTAllocation.Add(Trim(row(0)), row(1))
        Next
    End Sub


    Private Sub GenerateChargeableUnits()
        For Each row As DataRow In ReportData.ChargeableUnits.Rows
            Dim ContainerNumber As String = row("ContainerNumber")
            Dim FreightKind As String = row("FreightKind")
            Dim LineOperator As String = TranslateLineOP(Trim(row("LineOperator")))
            Dim Length As Integer = row("Length")
            Dim Group As String = IIf(row("Group") = "ECD", "ECD", "NCT")

            Select Case Group 'Convert Line Operator if Unknown
                Case "ECD"
                    If Not ECDAllocation.Keys.Contains(LineOperator) Then LineOperator = "OTHERS"
                Case "NCT"
                    If Not NCTAllocation.Keys.Contains(LineOperator) Then LineOperator = "OTHERS"
            End Select


            ChargeableUnitEvents.Add(New EmptyUnits(ContainerNumber:=ContainerNumber,
                                                             FreightKind:=FreightKind,
                                                             LineOperator:=LineOperator,
                                                             Length:=Length,
                                                             Group:=Group))

        Next
    End Sub

    Private Function TranslateLineOP(v As String) As String
        For Each lineop As String In CoLoading.Keys
            If CoLoading.Item(lineop).Contains(v) Then
                Return lineop
            End If
        Next
        Return "OTHERS"
    End Function

    Private Sub RetrieveChargeableUnits()
        Dim connections As New Reports.Connections
        Dim tempdatatable As New DataTable
        With connections
            .N4Connection.Open()

            Dim ChargeableUnitsRetriever As New ADODB.Command
            ChargeableUnitsRetriever.CommandTimeout = 0
            ChargeableUnitsRetriever.ActiveConnection = .N4Connection
            ChargeableUnitsRetriever.CommandText = $"
SELECT unit.id 'ContainerNumber'
		,[freight_kind] 'FreightKind'
		,round([length_mm] * 0.0032808399,0) 'Length'
		,bzu.id 'LineOperator'
		,grp.id 'Group' 
  FROM [apex].[dbo].[inv_unit] unit
inner join [inv_unit_fcy_visit] ufv on unit.gkey = ufv.unit_gkey
inner join [inv_unit_equip] ueq on unit.gkey = ueq.unit_gkey
inner join [ref_equipment] req on ueq.eq_gkey = req.gkey
inner join [ref_bizunit_scoped] bzu on unit.line_op = bzu.gkey
inner join [ref_groups] grp on unit.group_gkey = grp.gkey

where unit.[freight_kind] = 'MTY'
and ufv.[transit_state] like '%YARD%'
"


            Dim dataAdapter As New OleDb.OleDbDataAdapter
            dataAdapter.Fill(ReportData.ChargeableUnits, ChargeableUnitsRetriever.Execute(Options:=ADODB.ExecuteOptionEnum.adAsyncFetchNonBlocking))
            .N4Connection.Close()
        End With


    End Sub

    Private ReadOnly Month As Integer
    Private ReadOnly Day As Integer
    Private ReadOnly Year As Integer
    Public ReadOnly StartDate As Date
    Public ReadOnly EndDate As Date

    Private ReadOnly ChargeableUnitEvents As List(Of EmptyUnits)

    Private ReadOnly NCTAllocation As Dictionary(Of String, Double)
    Private ReadOnly ECDAllocation As Dictionary(Of String, Double)
    Private ReadOnly CoLoading As Dictionary(Of String, String())

    Private ReadOnly ReportData As ReportData

End Class
