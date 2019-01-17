Public Class ITerminalStatusReport
    ReadOnly Property FromDate As Date
    ReadOnly Property ToDate As Date
    ReadOnly Property DailyTerminalStatusReports() As DailyTerminalStatusReport

    Public Save
    Public CancelExisting


End Class
