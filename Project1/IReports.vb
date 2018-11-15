﻿Public Module IReports
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
        ReadOnly Property N4Connection As ADODB.Connection
        ReadOnly Property OPConnection As ADODB.Connection
        Sub CalculateInfo()
        Sub Format(ReportData As Object(), crReport As Object)
        Sub Preview(crReport As Object, crViewer As Object)
        Sub Save(ReportData As Object())
        Sub RetrieveData(Parameter As Object)
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
    Public Interface Connections
        ReadOnly Property ConnectionString
        ReadOnly Property Connection
        ReadOnly Property State
        Sub Connect(ConnectionString As String)
        Sub Disconnect()
    End Interface
    Public Interface Units
        ReadOnly Property Registry As String
        ReadOnly Property Containers As Data.DataSet
        ReadOnly Property Connection As ADODB.Connection
        Sub Retrieve(Vessel As String, Connection As ADODB.Connection)
        Function Count(Containers As Data.DataTable, Condition As String) As Double
    End Interface
    Public Interface Vessel
        ReadOnly Property Name As String
        ReadOnly Property Registry As String
        ReadOnly Property InboundVoyage As String
        ReadOnly Property OutboundVoyage As String
        ReadOnly Property BerthWindow As String
        ReadOnly Property ATA As DateTime
        ReadOnly Property ATD As DateTime
        ReadOnly Property ETA As DateTime
        ReadOnly Property ETD As DateTime
        ReadOnly Property StartWork As DateTime
        ReadOnly Property EndWork As DateTime
        ReadOnly Property FirstContainerDischarged As DateTime
        ReadOnly Property LastContainerDischarged As DateTime
        ReadOnly Property FirstContainerLoaded As DateTime
        ReadOnly Property LastContainerLoaded As DateTime
        ReadOnly Property LineOperator() As String
        ReadOnly Property Owner As String
        ReadOnly Property Units As Reports.Units
        ReadOnly Property Connection As ADODB.Connection
        Sub Retrieve(Registry As String, Connection As ADODB.Connection)
        Function TEU(Optional Condition As String = "") As Double
        Function Boxes(Optional Condition As String = "") As Long

    End Interface
End Module
