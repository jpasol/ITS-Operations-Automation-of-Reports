Imports Crane_Logs_Report_Creator
Imports System.Threading.Tasks
Imports ADODB

Public Class TSRClass
    Implements ITerminalStatusReport

    Private N4Connection As ADODB.Connection
    Private OPConnection As ADODB.Connection
    Dim day = Date.Now.Day
    Dim year = Date.Now.Year
    Dim month = Date.Now.Month
    Private ReadOnly StartofDay As DateTime = New DateTime(year, month, day)
    Private ReadOnly StartofMonth As DateTime = New DateTime(year, month, 1)
    Private ReadOnly StartofYear As DateTime = New DateTime(year, 1, 1)
    Public CraneLogCount As Integer
    Public ReadOnly Property TerminalStatusDate As Date Implements ITerminalStatusReport.TerminalStatusDate
    Public Property TotalGroundSlotTEU As Integer Implements ITerminalStatusReport.TotalGroundSlotTEU
    Public Property StaticCapacityTEU As Integer Implements ITerminalStatusReport.StaticCapacityTEU
    Public Property TotalYardCapacityTEU As Integer Implements ITerminalStatusReport.TotalYardCapacityTEU
    Public Property MTDAverageGrossCraneProductivity As Double Implements ITerminalStatusReport.MTDAverageGrossCraneProductivity
    Public Property MTDAverageGrossBerthProductivity As Double Implements ITerminalStatusReport.MTDAverageGrossBerthProductivity
    Public Property MTDAverageGrossVesselProductivity As Double Implements ITerminalStatusReport.MTDAverageGrossVesselProductivity
    Public Property MTDAverageNetCraneProductivity As Double Implements ITerminalStatusReport.MTDAverageNetCraneProductivity
    Public Property MTDAverageNetBerthProductivity As Double Implements ITerminalStatusReport.MTDAverageNetBerthProductivity
    Public Property MTDAverageNetVesselProductivity As Double Implements ITerminalStatusReport.MTDAverageNetVesselProductivity
    Public Property AverageImportDwellTime As Double Implements ITerminalStatusReport.AverageImportDwellTime
    Public Property MTDImportDwellTime As Double Implements ITerminalStatusReport.MTDImportDwellTime
    Public Property YTDImportDwellTime As Double Implements ITerminalStatusReport.YTDImportDwellTime
    Public Property MTDExportDwellTime As Double Implements ITerminalStatusReport.MTDExportDwellTime
    Public Property YTDExportDwellTime As Double Implements ITerminalStatusReport.YTDExportDwellTime
    Public Property DailyTEUInByTrucks As Double Implements ITerminalStatusReport.DailyTEUInByTrucks
    Public Property DailyTEUOutByTrucks As Double Implements ITerminalStatusReport.DailyTEUOutByTrucks
    Public Property MTDTEUInByTrucks As Double Implements ITerminalStatusReport.MTDTEUInByTrucks
    Public Property MTDTEUOutByTrucks As Double Implements ITerminalStatusReport.MTDTEUOutByTrucks
    Public Property YTDTEUInByTrucks As Double Implements ITerminalStatusReport.YTDTEUInByTrucks
    Public Property YTDTEUOutByTrucks As Double Implements ITerminalStatusReport.YTDTEUOutByTrucks
    Public Property OverstayingManilaCargo As Double Implements ITerminalStatusReport.OverstayingManilaCargo
    Public Property TotalOverstayingCargo As Double Implements ITerminalStatusReport.TotalOverstayingCargo
    Public Property ImportFullTEU As Double Implements ITerminalStatusReport.ImportFullTEU
    Public Property ImportEmptyTEU As Double Implements ITerminalStatusReport.ImportEmptyTEU
    Public Property ExportFullTEU As Double Implements ITerminalStatusReport.ExportFullTEU
    Public Property ExportEmptyTEU As Double Implements ITerminalStatusReport.ExportEmptyTEU
    Public Property StorageEmptyTEU As Double Implements ITerminalStatusReport.StorageEmptyTEU
    Public Property TotalInYardTEU As Double Implements ITerminalStatusReport.TotalInYardTEU
    Public Property TotalInYardECDTEU As Double Implements ITerminalStatusReport.TotalInYardECDTEU
    Public Property YardUtilization As Double Implements ITerminalStatusReport.YardUtilization
    Public Property YardUtilizationECD As Double Implements ITerminalStatusReport.YardUtilizationECD
    Public ReadOnly Property CraneLogReports As List(Of CLRClass) Implements ITerminalStatusReport.CraneLogReports
    Public ReadOnly Property ActiveUnits As List(Of ActiveUnit) Implements ITerminalStatusReport.ActiveUnits
    Public ReadOnly Property GateTransactions As List(Of GateTransaction) Implements ITerminalStatusReport.GateTransactions


    Public Sub New(TerminalStatusDate As Date)
        Dim tempConnections As New Reports.Connections
        Me.TerminalStatusDate = TerminalStatusDate
        Me.N4Connection = tempConnections.N4Connection
        Me.OPConnection = tempConnections.OPConnection


        CraneLogReports = New List(Of CLRClass)
        ActiveUnits = New List(Of ActiveUnit)
        GateTransactions = New List(Of GateTransaction)
        'Try

        If Exists() Then
            RetrieveTerminalStatusReport()
        Else
            CraneLogReports = New List(Of CLRClass)
            ActiveUnits = New List(Of ActiveUnit)
            GateTransactions = New List(Of GateTransaction)

            RetrieveGateTransactions()
            RetrieveActiveUnits()
            RetrieveCraneLogReports()
            Calculate()
        End If

        'Catch ex As Exception
        'MsgBox($"Error in Generating Terminal Status Report. {vbNewLine}Error Message: {ex.Message} ")
        'End Try
    End Sub

    Public Sub RetrieveTerminalStatusReport() Implements ITerminalStatusReport.RetrieveTerminalStatusReport
        OPConnection.Open()
        Dim retrieveTerminalStatus As New ADODB.Command
        retrieveTerminalStatus.ActiveConnection = OPConnection
        retrieveTerminalStatus.CommandText = $"
SELECT [groundslot]
    ,[staticcapacity]
    ,[totalcapacity]
    ,[grosscrane]
    ,[grossvessel]
    ,[grossberth]
    ,[netcrane]
    ,[netvessel]
    ,[netberth]
    ,[ave_importdwell]
    ,[mtd_importdwell]
    ,[mtd_exportdwell]
    ,[ytd_importdwell]
    ,[ytd_exportdwell]
    ,[daily_trucksin]
    ,[daily_trucksout]
    ,[mtd_trucksin]
    ,[mtd_trucksout]
    ,[ytd_trucksin]
    ,[ytd_trucksout]
    ,[mnl_overstaying]
    ,[total_overstaying]
    ,[importfull]
    ,[importempty]
    ,[exportfull]
    ,[exportempty]
    ,[storageempty]
    ,[yard_total]
    ,[yard_utilization]
    ,[created]
    ,[cranelogsreports_count]
FROM [opreports].[dbo].[reports_tsr] WHERE [created] = '{TerminalStatusDate}'
"
        RetrieveProperties(retrieveTerminalStatus.Execute)
        OPConnection.Close()
    End Sub

    Private Sub RetrieveProperties(execute As Recordset)
        With execute
            TotalGroundSlotTEU = .Fields("groundslot").Value
            StaticCapacityTEU = .Fields("staticcapacity").Value
            TotalYardCapacityTEU = .Fields("totalcapacity").Value
            MTDAverageGrossCraneProductivity = .Fields("grosscrane").Value
            MTDAverageGrossVesselProductivity = .Fields("grossvessel").Value
            MTDAverageGrossBerthProductivity = .Fields("grossberth").Value
            MTDAverageNetCraneProductivity = .Fields("netcrane").Value
            MTDAverageNetVesselProductivity = .Fields("netvessel").Value
            MTDAverageNetBerthProductivity = .Fields("netberth").Value
            AverageImportDwellTime = .Fields("ave_importdwell").Value
            MTDImportDwellTime = .Fields("mtd_importdwell").Value
            YTDImportDwellTime = .Fields("mtd_exportdwell").Value
            MTDExportDwellTime = .Fields("ytd_importdwell").Value
            YTDExportDwellTime = .Fields("ytd_exportdwell").Value
            DailyTEUInByTrucks = .Fields("daily_trucksin").Value
            DailyTEUOutByTrucks = .Fields("daily_trucksout").Value
            MTDTEUInByTrucks = .Fields("mtd_trucksin").Value
            MTDTEUOutByTrucks = .Fields("mtd_trucksout").Value
            YTDTEUInByTrucks = .Fields("ytd_trucksin").Value
            YTDTEUOutByTrucks = .Fields("ytd_trucksout").Value
            OverstayingManilaCargo = .Fields("mnl_overstaying").Value
            TotalOverstayingCargo = .Fields("total_overstaying").Value
            ImportFullTEU = .Fields("importfull").Value
            ImportEmptyTEU = .Fields("importempty").Value
            ExportFullTEU = .Fields("exportfull").Value
            ExportEmptyTEU = .Fields("exportempty").Value
            StorageEmptyTEU = .Fields("storageempty").Value
            TotalInYardTEU = .Fields("yard_total").Value
            YardUtilization = .Fields("yard_utilization").Value
            CraneLogCount = .Fields("cranelogsreports_count").Value
        End With
    End Sub

    Private Function CreateRegistryList() As List(Of String)
        Try
execute:
            Dim tempRegistryList As New List(Of String)
            Dim registryRecordset As New ADODB.Command
            N4Connection.Open()
            registryRecordset.ActiveConnection = N4Connection
            registryRecordset.CommandText = $"
SELECT acv.[id] as Registry
      ,[phase]
		,biz.[id] as Owner
  FROM [apex].[dbo].[argo_carrier_visit] acv
	inner join [vsl_vessel_visit_details] vvd
	on acv.cvcvd_gkey = vvd.vvd_gkey
	inner join [ref_bizunit_scoped] biz
	on vvd.bizu_gkey = biz.gkey
WHERE ATA > '{StartofMonth}' and carrier_mode = 'VESSEL' and phase like '%CLOSED'
"
            With registryRecordset.Execute()
                While Not .EOF
                    'If Not My.Settings.Exclude.Contains(.Fields("Owner").Value) Then
                    tempRegistryList.Add(.Fields("Registry").Value)
                    'End If 'Move to Crane Logs Report Generation 03192019


                    .MoveNext()
                End While
            End With

            N4Connection.Close()
            Return tempRegistryList
        Catch ex As Exception
            If ex.Message = "Query timeout expired" Then
                GoTo execute
            End If
        End Try
    End Function

    Public Sub RetrieveCraneLogReports() Implements ITerminalStatusReport.RetrieveCraneLogReports

        Dim CraneLogRegistries As List(Of String) = CreateRegistryList()
        For Each Registry As String In CraneLogRegistries
            Try

                Dim tempCLR As New CLRClass(Registry)
                CraneLogReports.Add(tempCLR)

                If tempCLR.Exists Then
                    'do nothing
                Else
                    Try
                        tempCLR.Save()
                    Catch ex As Exception
                        If ex.Message.Contains("Sequence contains no elements") Then
                            'MsgBox($"Error in Saving: {Registry}{vbNewLine}{ex.Message}")
                            CraneLogReports.Remove(tempCLR)
                        End If
                    End Try
                End If

            Catch ex As Exception
                Throw ex
            End Try

        Next
    End Sub

    Public Sub RetrieveActiveUnits() Implements ITerminalStatusReport.RetrieveActiveUnits
        For Each row As DataRow In activeUnitsRecordset().Rows
            Dim UnitNumber As String = row("UnitNbr").ToString
            Dim Registry As String = row("Registry").ToString
            Dim SizeMM As Double = row("Size").ToString
            Dim Category As String = row("Category").ToString
            Dim Freight As String = row("Freight").ToString
            Dim TimeIn As Date = CDate(row("TimeIn").ToString)
            Dim Group As String = (row("Group").ToString)

            Me.ActiveUnits.Add(New ActiveUnit(UnitNumber, Registry, SizeMM, Category, Freight, TimeIn, Group))
        Next
    End Sub

    Private Function activeUnitsRecordset() As DataTable
        N4Connection.Open()

        Try
execute:
            
            Dim activeUnits As New ADODB.Command
            activeUnits.ActiveConnection = N4Connection
            activeUnits.CommandText = $"
SELECT unit.[id] as UnitNbr
	  ,acv.[id] as Registry
	  ,[length_mm] as Size
      ,[category] as Category
      ,[freight_kind] as Freight
	  ,[time_in] as TimeIn
	  ,grp.[id] as 'Group'

  FROM [apex].[dbo].[inv_unit] unit
inner join [inv_unit_fcy_visit] ufv on unit.active_ufv = ufv.gkey
inner join [argo_carrier_visit] acv on ufv.[actual_ib_cv] = acv.gkey
inner join [inv_unit_equip] ueq on unit.gkey = ueq.unit_gkey
inner join [ref_equipment] req on ueq.eq_gkey = req.gkey
full outer join [ref_groups] grp on unit.group_gkey = grp.gkey

where ufv.transit_state = 'S40_YARD' and [time_in] < '{TerminalStatusDate}'
"

            activeUnitsRecordset = New DataTable
            Dim tempAdapter As New OleDb.OleDbDataAdapter
            tempAdapter.Fill(activeUnitsRecordset, activeUnits.Execute(Options:=ExecuteOptionEnum.adAsyncFetchNonBlocking))

        Catch ex As Exception
            If ex.Message = "Query timeout expired" Then
                GoTo execute
            End If
        End Try

        N4Connection.Close()

    End Function

    Public Sub RetrieveGateTransactions() Implements ITerminalStatusReport.RetrieveGateTransactions

        For Each row As DataRow In gateTransactionRecordset().Rows
            Dim ContainerNumber As String = row("ctr_id").ToString
            Dim NOMContainerSize As String = row("eqo_eq_length").ToString
            Dim TransactionType As String = row("sub_type").ToString
            Dim StartDate As String = row("created").ToString

            GateTransactions.Add(New GateTransaction(ContainerNumber, NOMContainerSize, TransactionType, StartDate))
        Next
    End Sub

    Private Function gateTransactionRecordset() As DataTable
        N4Connection.Open()
        Try
execute:

            Dim gateTransactions As New ADODB.Command
            gateTransactions.ActiveConnection = N4Connection
            gateTransactions.CommandText = $"
SELECT [sub_type]
	  ,[ctr_id]
      ,[eqo_eq_length]
      ,[created]
  FROM [apex].[dbo].[road_truck_transactions] where created > '{StartofYear}' and created < '{TerminalStatusDate}' and ([status] in ('OK','COMPLETE'))
"
            gateTransactionRecordset = New DataTable
            Dim tempAdapter As New OleDb.OleDbDataAdapter
            tempAdapter.Fill(gateTransactionRecordset, gateTransactions.Execute(Options:=ExecuteOptionEnum.adAsyncFetchNonBlocking))

        Catch ex As Exception
            If ex.Message = "Query timeout expired" Then
                GoTo execute
            End If
        End Try

        N4Connection.Close()

    End Function

    Public Sub Calculate() Implements ITerminalStatusReport.Calculate

        TotalGroundSlotTEU = My.Settings.TotalGroundSlot
        StaticCapacityTEU = My.Settings.StaticCapacity
        TotalYardCapacityTEU = My.Settings.TotalYardCapacity

        If CraneLogReports.Count > 0 Then
            CalculateUsingCraneLogReports()
        Else
            CopyProductivityofLastTerminalStatusUpdate()
        End If

        CalculateUsingActiveUnits()
        CalculateUsingGateTransactions()

    End Sub

    Private Sub CopyProductivityofLastTerminalStatusUpdate()
        Dim tsrDate As Date = GetLastTSRDate()
        Dim tempTSR As New TSRClass(tsrDate)
        With tempTSR
            Me.MTDAverageGrossCraneProductivity = .MTDAverageGrossCraneProductivity
            Me.MTDAverageGrossBerthProductivity = .MTDAverageGrossBerthProductivity
            Me.MTDAverageGrossVesselProductivity = .MTDAverageGrossVesselProductivity
            Me.MTDAverageNetCraneProductivity = .MTDAverageNetCraneProductivity
            Me.MTDAverageNetBerthProductivity = .MTDAverageNetBerthProductivity
            Me.MTDAverageNetVesselProductivity = .MTDAverageNetVesselProductivity
        End With
    End Sub

    Private Function GetLastTSRDate() As Date
        OPConnection.Open()
        Dim lastTSRDate As New ADODB.Command
        lastTSRDate.ActiveConnection = OPConnection
        lastTSRDate.CommandText = $"
    SELECT TOP 1 [created]
  FROM [opreports].[dbo].[reports_tsr] ORDER BY CREATED
"
        Dim latestTSRDate As Date = lastTSRDate.Execute.Fields(0).Value
        OPConnection.Close()
        Return latestTSRDate
    End Function

    Private Sub CalculateUsingGateTransactions()

        With GateTransactions.AsEnumerable
            DailyTEUInByTrucks = .Where(Function(gate) gate.StartDate > StartofDay And gate.TransactionType.Chars(0) = "R").Sum(Function(gate) gate.TEU)
            DailyTEUOutByTrucks = .Where(Function(gate) gate.StartDate > StartofDay And gate.TransactionType.Chars(0) = "D").Sum(Function(gate) gate.TEU)
            MTDTEUInByTrucks = .Where(Function(gate) gate.StartDate > StartofMonth And gate.TransactionType.Chars(0) = "R").Sum(Function(gate) gate.TEU)
            MTDTEUOutByTrucks = .Where(Function(gate) gate.StartDate > StartofMonth And gate.TransactionType.Chars(0) = "D").Sum(Function(gate) gate.TEU)
            YTDTEUInByTrucks = .Where(Function(gate) gate.StartDate > StartofYear And gate.TransactionType.Chars(0) = "R").Sum(Function(gate) gate.TEU)
            YTDTEUOutByTrucks = .Where(Function(gate) gate.StartDate > StartofYear And gate.TransactionType.Chars(0) = "D").Sum(Function(gate) gate.TEU)
        End With

    End Sub

    Private Sub CalculateUsingActiveUnits()
        With ActiveUnits.AsEnumerable
            AverageImportDwellTime = .Where(Function(unit) unit.Dwell(TerminalStatusDate) < 90).Average(Function(unit) unit.Dwell(TerminalStatusDate))
            MTDImportDwellTime = .Where(Function(unit) unit.TimeIn > StartofMonth And unit.Category = "IMPRT").DefaultIfEmpty.Average(Function(unit) unit.Dwell(TerminalStatusDate))
            MTDExportDwellTime = .Where(Function(unit) unit.TimeIn > StartofMonth And unit.Category = "EXPRT").DefaultIfEmpty.Average(Function(unit) unit.Dwell(TerminalStatusDate))
            YTDImportDwellTime = .Where(Function(unit) unit.TimeIn > StartofYear And unit.Category = "IMPRT").DefaultIfEmpty.Average(Function(unit) unit.Dwell(TerminalStatusDate))
            YTDExportDwellTime = .Where(Function(unit) unit.TimeIn > StartofYear And unit.Category = "EXPRT").DefaultIfEmpty.Average(Function(unit) unit.Dwell(TerminalStatusDate))

            OverstayingManilaCargo = .Where(Function(unit) unit.Registry = "SBITCTEST3" Or
                                                unit.Registry = "SBITCTEST5" Or
                                                unit.Registry = "SUB0005-14").Sum(Function(unit) unit.TEU)
            TotalOverstayingCargo = .Where(Function(unit) unit.Category = "IMPRT" And unit.Freight = "FCL" And unit.Dwell(TerminalStatusDate) >= 30).Sum(Function(unit) unit.TEU)
            ImportFullTEU = .Where(Function(unit) unit.Category = "IMPRT" And unit.Freight = "FCL").Sum(Function(unit) unit.TEU)
            ImportEmptyTEU = .Where(Function(unit) unit.Category = "IMPRT" And unit.Freight = "MTY").Sum(Function(unit) unit.TEU)
            ExportFullTEU = .Where(Function(unit) unit.Category = "EXPRT" And unit.Freight = "FCL").Sum(Function(unit) unit.TEU)
            ExportEmptyTEU = .Where(Function(unit) unit.Category = "EXPRT" And unit.Freight = "MTY").Sum(Function(unit) unit.TEU)
            StorageEmptyTEU = .Where(Function(unit) unit.Category = "STRGE" And unit.Freight = "MTY").Sum(Function(unit) unit.TEU)
            TotalInYardTEU = .Where(Function(unit) unit.Group <> "ECD").Sum(Function(unit) unit.TEU)
            TotalInYardECDTEU = .Where(Function(unit) unit.Group = "ECD").Sum(Function(unit) unit.TEU)

            YardUtilization = (TotalInYardTEU / StaticCapacityTEU) * 100
            YardUtilizationECD = (TotalInYardECDTEU / 3000) * 100
        End With
    End Sub

    Private Sub CalculateUsingCraneLogReports()

        With CraneLogReports.AsEnumerable
            MTDAverageGrossCraneProductivity = .Average(Function(clr) clr.GrossCraneProductivity)
            MTDAverageGrossVesselProductivity = .Average(Function(clr) clr.GrossVesselProdRate)
            MTDAverageGrossBerthProductivity = .Average(Function(clr) clr.GrossBerthProdRate)
            MTDAverageNetCraneProductivity = .Average(Function(clr) clr.NetCraneProductivity)
            MTDAverageNetVesselProductivity = .Average(Function(clr) clr.NetVesselProdRate)
            MTDAverageNetBerthProductivity = .Average(Function(clr) clr.NetBerthProdRate)
        End With

    End Sub

    Public Sub Save() Implements ITerminalStatusReport.Save
        Try
            OPConnection.Open()
            OPConnection.BeginTrans()

            Dim saveCommand As New ADODB.Command
            saveCommand.ActiveConnection = OPConnection
            saveCommand.CommandText = $"
INSERT INTO [opreports].[dbo].[reports_tsr]
           ([groundslot]
           ,[staticcapacity]
           ,[totalcapacity]
           ,[grosscrane]
           ,[grossvessel]
           ,[grossberth]
           ,[netcrane]
           ,[netvessel]
           ,[netberth]
           ,[ave_importdwell]
           ,[mtd_importdwell]
           ,[mtd_exportdwell]
           ,[ytd_importdwell]
           ,[ytd_exportdwell]
           ,[daily_trucksin]
           ,[daily_trucksout]
           ,[mtd_trucksin]
           ,[mtd_trucksout]
           ,[ytd_trucksin]
           ,[ytd_trucksout]
           ,[mnl_overstaying]
           ,[total_overstaying]
           ,[importfull]
           ,[importempty]
           ,[exportfull]
           ,[exportempty]
           ,[storageempty]
           ,[yard_total]
           ,[yard_utilization]
           ,[yard_utilization_ecd]
           ,[created]
           ,[cranelogsreports_count])
     VALUES
           ({TotalGroundSlotTEU}
           ,{StaticCapacityTEU}
           ,{TotalYardCapacityTEU}
           ,{MTDAverageGrossCraneProductivity}
           ,{MTDAverageGrossBerthProductivity}
           ,{MTDAverageGrossBerthProductivity}
           ,{MTDAverageNetCraneProductivity}
           ,{MTDAverageNetVesselProductivity}
           ,{MTDAverageNetBerthProductivity}
           ,{AverageImportDwellTime}
           ,{MTDImportDwellTime}
           ,{MTDExportDwellTime}
           ,{YTDImportDwellTime}
           ,{YTDExportDwellTime}
           ,{DailyTEUInByTrucks}
           ,{DailyTEUOutByTrucks}
           ,{MTDTEUInByTrucks}
           ,{MTDTEUOutByTrucks}
           ,{YTDTEUInByTrucks}
           ,{YTDTEUOutByTrucks}
           ,{OverstayingManilaCargo}
           ,{TotalOverstayingCargo}
           ,{ImportFullTEU}
           ,{ImportEmptyTEU}
           ,{ExportFullTEU}
           ,{ExportEmptyTEU}
           ,{StorageEmptyTEU}
           ,{TotalInYardTEU}
           ,{YardUtilization}
           ,{YardUtilizationECD}
           ,'{TerminalStatusDate}'
           ,{CraneLogReports.Count}
           )
"
            saveCommand.Execute()
            OPConnection.CommitTrans()
        Catch ex As Exception
            OPConnection.RollbackTrans()
            Throw ex
        End Try
        OPConnection.Close()
    End Sub

    Public Function Exists() As Boolean Implements ITerminalStatusReport.Exists
        OPConnection.Open()
        Dim existResult As New ADODB.Command
        existResult.ActiveConnection = OPConnection
        existResult.CommandText = $"
SELECT case 

when exists( 
select created from reports_tsr where [created] = '{TerminalStatusDate}')
then 
cast(1 as bit)
else 
cast(0 as bit)
end
"

        Dim result As Boolean = existResult.Execute().Fields(0).Value
        OPConnection.Close
        Return result
    End Function
End Class
