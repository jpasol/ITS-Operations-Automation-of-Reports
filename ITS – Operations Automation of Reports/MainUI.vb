Imports ADODB
Imports System.Configuration
Imports Vessel_Movement_Report_Creator

Public Class MainUI

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
    Dim CnnN4 As New ADODB.Connection
    Dim CnnDB As New ADODB.Connection

    Public Sub ConnectDB()
        With My.Settings
            CnnN4.Open("Provider=SQLOLEDB;
                        Data Source=" & .N4Server & ";
                        Initial Catalog=" & .N4Database & ";
                        Integrated Security=SSPI;")
            CnnDB.Open("Provider=SQLOLEDB;
                        Data Source=" & .OPServer & ";
                        Initial Catalog=" & .OPDatabase & ";
                        Integrated Security=SSPI;")
        End With
    End Sub

    Public Sub Initialize()
        cmbReports.Items.AddRange(arrReports)
        cmbReports.SelectedIndex = 0
        ConnectDB()
    End Sub

    Private Sub MainUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initialize()
    End Sub

    Private Sub cmbReports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReports.SelectedIndexChanged
        Select Case cmbReports.SelectedIndex
            Case 0, 1
                lblParameter.Text = "Registry:"
                mskParameter.Mask = "&&&0000-00"
            Case Else
                lblParameter.Text = "Date:"
                mskParameter.Mask = "00/00/0000"
        End Select
    End Sub
    Private Function FindVMR(strRegistry As String) As Boolean
        'Find VMR
    End Function
    Private Sub cmdGenerate_Click(sender As Object, e As EventArgs) Handles cmdGenerate.Click
        Select Case cmbReports.Text
            Case "Vessel Movement Report"
                Dim createVMR As New VMRForm(mskParameter.Text, CnnN4, CnnDB)
                createVMR.ShowDialog()
            Case Else

        End Select
    End Sub

End Class
