Public Class IDailyTerminalStatusReport
    ReadOnly Property TerminalStatusReportDate As Date
    ReadOnly Property CraneLogReports() As Crane_Logs_Report_Creator.CLRClass
    Property TotalGroundSlotTEU As Integer = 5640
    Property StaticCapacityTEU As Integer = 16572
    Property TotalYardCapacityTEU As Integer = 559615

End Class
n