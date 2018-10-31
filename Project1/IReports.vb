Public Module IReports
    Public Interface IReports
        Property cnnN4 As ADODB.Connection
        Property cnnDB As ADODB.Connection
        Sub Initialize()
        Sub ConnectDB()
        Function RetrieveDate(paramDate As Object) As Data.DataTable
        Function CalculateInfo(RetrievedData As Object) As Object()
        Sub Format(ReportData As Object(), crReport As Object)
        Sub Preview(crReport As Object, crViewer As Object)
        Sub Save(ReportData As Object())
    End Interface
End Module
