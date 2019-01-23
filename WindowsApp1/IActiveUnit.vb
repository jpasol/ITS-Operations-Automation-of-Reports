Public Interface IActiveUnit
    ReadOnly Property UnitNumber As String
    ReadOnly Property Registry As String
    ReadOnly Property Size As Integer
    ReadOnly Property Category As String
    ReadOnly Property Freight As String
    ReadOnly Property TimeIn As Date
    ReadOnly Property TEU As Double 'Convert na para di na mahirapan
    ReadOnly Property Dwell(EndDate As Date) As Double 'add parameter para magkaroon ng comparison

End Interface
