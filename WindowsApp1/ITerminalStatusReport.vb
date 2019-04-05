Public Interface ITerminalStatusReport
    ReadOnly Property TerminalStatusDate As Date
    Property TotalGroundSlotTEU As Integer
    Property StaticCapacityTEU As Integer
    Property TotalYardCapacityTEU As Integer
    Property MTDAverageGrossCraneProductivity As Double
    Property MTDAverageGrossBerthProductivity As Double
    Property MTDAverageGrossVesselProductivity As Double
    Property MTDAverageNetCraneProductivity As Double
    Property MTDAverageNetBerthProductivity As Double
    Property MTDAverageNetVesselProductivity As Double
    Property AverageImportDwellTime As Double
    Property MTDImportDwellTime As Double
    Property YTDImportDwellTime As Double
    Property MTDExportDwellTime As Double
    Property YTDExportDwellTime As Double
    Property DailyTEUInByTrucks As Double
    Property DailyTEUOutByTrucks As Double
    Property MTDTEUInByTrucks As Double
    Property MTDTEUOutByTrucks As Double
    Property YTDTEUInByTrucks As Double
    Property YTDTEUOutByTrucks As Double
    Property OverstayingManilaCargo As Double
    Property TotalOverstayingCargo As Double
    Property ImportFullTEU As Double
    Property ImportEmptyTEU As Double
    Property ExportFullTEU As Double
    Property ExportEmptyTEU As Double
    Property StorageEmptyTEU As Double
    Property TotalInYardTEU As Double
    Property YardUtilization As Double
    ReadOnly Property CraneLogReports As List(Of Crane_Logs_Report_Creator.CLRClass)
    ReadOnly Property ActiveUnits As List(Of ActiveUnit)
    ReadOnly Property GateTransactions As List(Of GateTransaction)
    Property YardUtilizationECD As Double
    Property TotalInYardECDTEU As Double
    Function Exists() As Boolean 'Check for Existing

    Sub RetrieveTerminalStatusReport() 'Retrieve TSR if existing
    Sub RetrieveCraneLogReports() ' Scratch Method 
    Sub RetrieveActiveUnits() 'Scratch Method
    Sub RetrieveGateTransactions() 'Scratch Method
    Sub Calculate() ' Scratch Method
    Sub Save()

End Interface
