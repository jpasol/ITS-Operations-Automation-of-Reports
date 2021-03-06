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
        Function CalculateInfo(strFunction As String, Inputs() As String) As Object
        Function Exists() As Boolean
        Sub Format(ByRef crReport As CrystalDecisions.CrystalReports.Engine.ReportClass)
        Sub Preview(ByRef crReport As CrystalDecisions.CrystalReports.Engine.ReportClass, crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer)
        Sub RetrieveData()
        Sub Save()
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
    Public Interface IUnits
        ReadOnly Property Registry As String
        ReadOnly Property Containers As Data.DataSet
        ReadOnly Property Connection As ADODB.Connection
        Sub Retrieve(Vessel As String)
        Function Count(Containers As Data.DataTable, Condition As String) As Double
    End Interface
    Public Interface IVessel
        ReadOnly Property Name As String
        ReadOnly Property Registry As String
        ReadOnly Property InboundVoyage As String
        ReadOnly Property OutboundVoyage As String
        ReadOnly Property BerthWindow As String
        ReadOnly Property Service As String
        ReadOnly Property LOA As Integer
        ReadOnly Property SLGangRequest As Date
        ReadOnly Property OvertimeRequired As Date
        ReadOnly Property ATA As DateTime
        ReadOnly Property ATD As DateTime
        ReadOnly Property ETA As DateTime
        ReadOnly Property ETD As DateTime
        ReadOnly Property StartWork As DateTime
        ReadOnly Property EndWork As DateTime
        ReadOnly Property FirstContainerDischarged As DateTime?
        ReadOnly Property LastContainerDischarged As DateTime?
        ReadOnly Property FirstContainerLoaded As DateTime?
        ReadOnly Property LastContainerLoaded As DateTime?
        ReadOnly Property LineOperator() As String
        ReadOnly Property Owner As String
        ReadOnly Property Phase As String
        ReadOnly Property LaborOnBoard As Date
        ReadOnly Property LaborOffBoard As Date?
        ReadOnly Property Units As Reports.Units
        ReadOnly Property Connection As ADODB.Connection
        ReadOnly Property WindowState As String

        Sub Retrieve(Registry As String)
        Function TEU(Optional Condition As String = "") As Double
        Function Boxes(Optional Condition As String = "") As Long
    End Interface

    Public Interface ICrane
        ReadOnly Property CraneName As String
        ReadOnly Property Registry As String
        ReadOnly Property GrossWorkingHours As Double
        ReadOnly Property GrossProductivity As Double
        ReadOnly Property NetWorkingHours As Double
        ReadOnly Property NetProductivity As Double
        Property Moves As CraneMoves
        Property Delays As CraneDelays
        Property FirstMove As Date
        Property LastMove As Date

    End Interface


End Module
