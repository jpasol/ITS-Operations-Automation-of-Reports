Imports ADODB
Imports 


Public Class MainUI
    Implements 

    Private arrReports() = New String() {
        "Vessel Movement Report",
        "Crane Logs Report",
        "Throughput Volume Update",
        "Terminal Status Report",
        "Management Report",
        "Budgeted Volume",
        "KPI Report for Operation",
        "Shipping Line TEUs & Monthly Impex Consignees",
        "Consolidation of Monthly Impex Consignees",
        "Monthly Revenue / Volume Report per Destination",
        "Chargeable Marine Unit Rates",
        "Commercial Report",
        "Monthly Reefer Comparison",
        "Crane Movement Report",
        "Shipping Line Database ",
        "Service Route Analysis",
        "Operation Productivity Report"
        }

    Public Property cnnN4 As Connection Implements IReports.IReports.cnnN4
        Get
            Return cnnN4
        End Get
        Set(value As Connection)
            cnnN4 = value
        End Set
    End Property

    Public Property cnnDB As Connection Implements IReports.IReports.cnnDB
        Get
            Return cnnDB
        End Get
        Set(value As Connection)
            cnnDB = value
        End Set
    End Property

    Public Sub ConnectDB() Implements IReports.IReports.ConnectDB
        cnnN4.Open()
        cnnDB.Open()
    End Sub

    Public Sub Initialize() Implements IReports.IReports.Initialize
        cmbReports.Items.AddRange(arrReports)
        ConnectDB()
    End Sub

    Public Sub Format(ReportData() As Object, crReport As Object) Implements IReports.IReports.Format
        Throw New NotImplementedException()
    End Sub

    Public Sub Preview(crReport As Object, crViewer As Object) Implements IReports.IReports.Preview
        Throw New NotImplementedException()
    End Sub

    Public Sub Save(ReportData() As Object) Implements IReports.IReports.Save
        Throw New NotImplementedException()
    End Sub

    Public Function RetrieveDate(paramDate As Object) As DataTable Implements IReports.IReports.RetrieveDate
        Throw New NotImplementedException()
    End Function

    Public Function CalculateInfo(RetrievedData As Object) As Object() Implements IReports.IReports.CalculateInfo
        Throw New NotImplementedException()
    End Function

    Private Sub MainUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initialize()
    End Sub

    Private Sub cmbReports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReports.SelectedIndexChanged
        Select Case cmbReports.SelectedIndex
            Case 0, 1
                mskParameter.Mask = "&&&0000-00"
            Case Else
                mskParameter.Mask = "00/00/0000"
        End Select
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DasdToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdGenerate_Click(sender As Object, e As EventArgs) Handles cmdGenerate.Click

    End Sub

End Class
