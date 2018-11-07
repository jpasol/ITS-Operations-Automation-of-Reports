Public Module IReports
    Public Interface IReportswoSave
        Property CnnN4 As ADODB.Connection
        Property CnnDB As ADODB.Connection
        Sub Initialize()
        Function RetrieveDate(paramDate As Object) As Data.DataTable
        Function CalculateInfo(RetrievedData As Object) As Object()
        Sub Format(ReportData As Object(), crReport As Object)
        Sub Preview(crReport As Object, crViewer As Object)
        Sub Save(ReportData As Object())
    End Interface
    Public Interface IReportswSave 'Used by VMR / CLR / TSR
        Property CnnN4 As ADODB.Connection
        Property CnnDB As ADODB.Connection
        Property Parameter As String
        Property dsRpt As Data.DataSet
        Sub Initialize()
        Function RetrieveOPData(Parameter As Object) As Data.DataSet
        Function RetrieveN4Data(Parameter As Object) As Data.DataSet
        Function CalculateInfo(RetrievedData As Object) As Object()
        Sub Format(ReportData As Object(), crReport As Object)
        Sub Preview(crReport As Object, crViewer As Object)
        Sub Save(ReportData As Object())
    End Interface
    Public Interface IReportfromN4 'Used by VMR / CLR
        Property CnnN4 As ADODB.Connection
        Property CnnDB As ADODB.Connection
        Property paramReg As String
        Sub Initialize()
        Function RetrieveN4Data(Parameter As Object) As Data.DataTable
        Function CalculateInfo(RetrievedData As Object) As Object()
        Sub Format(ReportData As Object(), crReport As Object)
        Sub Preview(crReport As Object, crViewer As Object)
        Sub Save(ReportData As Object())
    End Interface
End Module
