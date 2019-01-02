Imports ADODB
Imports System.Configuration
Imports Vessel_Movement_Report_Creator
Imports Crane_Logs_Report_Creator

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

    Shared User As String = UCase(System.Environment.UserName.ToString) 'Uppercased for uniformity, opdox though only has one username, only vmr has tagging
    Dim CnnN4 As New ADODB.Connection
    Dim CnnDB As New ADODB.Connection

    Public Sub ConnectDB()
        With My.Settings
            CnnN4.ConnectionString = "Provider=SQLOLEDB;
                        Data Source=" & .N4Server & ";
                        Initial Catalog=" & .N4Database & ";
                        Integrated Security=SSPI;"

            CnnDB.ConnectionString = "Provider=SQLOLEDB;
                        Data Source=" & .OPServer & ";
                        Initial Catalog=" & .OPDatabase & ";
                        Integrated Security=SSPI;"

            Try
                CnnN4.Open()
                CnnDB.Open()

                CnnDB.Close()
                CnnN4.Close()
            Catch ex As Exception
                MsgBox("Cannot Connect to Database" & vbNewLine &
                       Err.Number & vbNewLine &
                       Err.Description)
            End Try
        End With
    End Sub

    Public Sub Initialize()
        cmbReports.Items.AddRange(arrReports)
        cmbReports.SelectedIndex = 0
        ConnectDB()
        lblUser.Text = $"Logged in as: {User}"
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
                Dim createVMR As New VMRForm(mskParameter.Text, CnnN4, CnnDB, User)
                createVMR.ShowDialog()
            Case "Crane Logs Report"
                Dim createCLR As New CLRForm(mskParameter.Text, CnnN4, CnnDB, User)
                createCLR.ShowDialog()
            Case Else

        End Select
    End Sub

End Class
