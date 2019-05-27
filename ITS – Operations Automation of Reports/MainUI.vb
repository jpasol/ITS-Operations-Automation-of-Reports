Imports Vessel_Movement_Report_Creator
Imports Crane_Logs_Report_Creator
Imports Terminal_Status_Report
Imports Throughput_Volume_Update
Imports Management_Report
Imports Budgeted_Volume_Creator
Imports KPI_for_Operations

Public Class MainUI

    Private arrReports() = New String() {
        "Crane Logs Report",
        "Vessel Movement Report",
        "Terminal Status Report",
        "Management Report",
        "KPI Report for Operation",
        "Budgeted Volume"}
    '"Throughput Volume Update",
    '"Shipping Line TEUs & Monthly Impex Consignees",
    '"Consolidation of Monthly Impex Consignees",
    '"Monthly Revenue / Volume Report per Destination",
    '"Chargeable Marine Unit Rates",
    '"Commercial Report",
    '"Monthly Reefer Comparison",
    '"Crane Movement Report",
    '"Shipping Line Database ",
    '"Service Route Analysis",
    '"Operation Productivity Report"
    '}

    Shared User As String = UCase(System.Environment.UserName.ToString) 'Uppercased for uniformity, opdox though only has one username, only vmr has tagging
    Shared CnnN4 As New ADODB.Connection
    Shared CnnDB As New ADODB.Connection

    Public Sub Initialize()
        cmbReports.Items.AddRange(arrReports)
        cmbReports.SelectedIndex = 0

        Dim tempConnections As New Reports.Connections
        CnnN4 = tempConnections.N4Connection
        CnnDB = tempConnections.OPConnection

    End Sub

    Private Sub MainUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initialize()
        lblVersion.Text = $"v{Application.ProductVersion}"
    End Sub

    Private Sub cmbReports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReports.SelectedIndexChanged
        cmbMode.ResetText()
        cmbMode.Items.Clear()
        cmbMode.Enabled = False
        lblParameter.ResetText()
        mskParameter.Text = ""
        mskParameter.Mask = ""
        Select Case cmbReports.SelectedIndex
            Case 0, 1
                lblParameter.Text = "Registry:"
                mskParameter.Mask = ">CCCCCCCCCCC"

            Case 2
                cmbMode.Enabled = True
                cmbMode.Items.AddRange({"Berth Window Report",
                                       "Cummulative Volume Report",
                                       "Volume Breakdown",
                                       "All Vessel Throughput Volume",
                                       "Monthly Throughput Volume",
                                       "Monthly Co-Load Throughput Volume",
                                       "LOA Table",
                                       "Handling Services"})
            Case 3
                cmbMode.Enabled = True
                cmbMode.Items.AddRange({"Daily", "Monthly", "Annually"})
                lblParameter.Text = "Date:"
            Case 4
                cmbMode.Enabled = True
                lblParameter.Text = "Date: (MM/YYYY)"
                mskParameter.Mask = "00/0000"

            Case Else
                lblParameter.Text = "Date:"
                mskParameter.Mask = "00/00/0000"
        End Select
    End Sub
    Private Function FindVMR(strRegistry As String) As Boolean
        'Find VMR
    End Function
    Private Sub cmdGenerate_Click(sender As Object, e As EventArgs) Handles cmdGenerate.Click
        Try
            Select Case cmbReports.Text
                Case "Vessel Movement Report"
                    Dim createVMR As New VMRForm(mskParameter.Text, CnnN4, CnnDB, User)
                    createVMR.Show()
                Case "Crane Logs Report"
                    Dim createCLR As New CLRForm(mskParameter.Text, CnnN4, CnnDB, User)
                    createCLR.Show()
                Case "Terminal Status Report"
                    Select Case cmbMode.Text
                        Case "Daily"
                            Dim createDailyTSR As New DailyTerminalStatusReport(mskParameter.Text)
                            createDailyTSR.FormatReport()
                            crvPreview.ReportSource = createDailyTSR.Report
                        Case "Monthly"
                            Dim createMonthlyTSR As New MonthlyTerminalStatusReport(mskParameter.Text)
                            createMonthlyTSR.formatreport()
                            crvPreview.ReportSource = createMonthlyTSR.Report
                        Case "Annually"
                            Dim createYearlyTsr As New YearlyTerminalStatusReport(mskParameter.Text)
                            createYearlyTsr.formatreport()
                            crvPreview.ReportSource = createYearlyTsr.Report
                    End Select
                'Case "Throughput Volume Update"
                '    Select Case cmbMode.Text
                '        Case "Berth Window Report"
                '            Dim berthWindow As New BerthWindowReport(mskParameter.Text)
                '            crvPreview.ReportSource = berthWindow.Report
                '        Case "Cummulative Volume Report"
                '            Dim CummulativeVolume As New CummulativeReport(mskParameter.Text)
                '            crvPreview.ReportSource = CummulativeVolume.Report
                '        Case "Volume Breakdown"
                '            Dim VolumeBreakdown As New VolumeBreakdown(mskParameter.Text)
                '            crvPreview.ReportSource = VolumeBreakdown
                '        Case "All Vessel Throughput Volume"
                '            Dim month As Integer = mskParameter.Text.Substring(0, 2)
                '            Dim year As Integer = mskParameter.Text.Substring(3)
                '            Dim AllVesselVolume As New AllVesselThroughputVolume(month, year)
                '            crvPreview.ReportSource = AllVesselVolume.Report
                '        Case "Monthly Throughput Volume"
                '            Dim month As Integer = mskParameter.Text.Substring(0, 2)
                '            Dim year As Integer = mskParameter.Text.Substring(3)
                '            Dim MonthlyVolume As New MTDMonthlyThroughputVolume(month, year)
                '            crvPreview.ReportSource = MonthlyVolume.Report
                '        Case "Monthly Co-Load Throughput Volume"
                '            Dim month As Integer = mskParameter.Text.Substring(0, 2)
                '            Dim year As Integer = mskParameter.Text.Substring(3)
                '            Dim MonthlyCoLoadVolume As New MTDMonthlyCoLoadVolume(month, year)
                '            crvPreview.ReportSource = MonthlyCoLoadVolume.Report
                '        Case "LOA Table"
                '            Dim loa As New LOATable
                '            crvPreview.ReportSource = loa
                '        Case "Handling Services"
                '            Dim year As Integer = mskParameter.Text
                '            Dim handlingServices As New HandlingServices(year)
                '            crvPreview.ReportSource = handlingServices
                '    End Select
                Case "Management Report"
                    Dim month As Integer = mskParameter.Text.Substring(0, 2)
                    Dim year As Integer = mskParameter.Text.Substring(3)
                    Dim managementReport As New ManagementReport(month, year)
                    crvPreview.ReportSource = managementReport
                Case "KPI Report for Operation"
                    Dim month As Integer = mskParameter.Text.Substring(0, 2)
                    Dim day As Integer = mskParameter.Text.Substring(3, 2)
                    Dim year As Integer = mskParameter.Text.Substring(6)
                    Dim managementReport As New KPI_for_Operations.KPI_for_Operations(day, month, year)
                    crvPreview.ReportSource = managementReport

                Case "Budgeted Volume"
                    Dim frmBudget As New Budgeted_Volume_Creator.BudgetForm
                    frmBudget.ShowDialog()
                Case Else

            End Select
        Catch ex As Exception
            MsgBox("Error in Displaying Report." & vbNewLine &
                           "Error Description: " & ex.Message)

            '    If CnnDB.State = ConnectionState.Open Then CnnDB.Close()
            '    If CnnN4.State = ConnectionState.Open Then CnnN4.Close()
        End Try

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
    End Sub

    Private Sub cmbMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMode.SelectedIndexChanged
        lblParameter.ResetText()
        mskParameter.Mask = ""
        mskParameter.Text = ""
        lblParameter.Enabled = True
        mskParameter.Enabled = True


        Select Case cmbMode.Text
            Case "Daily"
                lblParameter.Text = "Date: (MM/DD/YYYY)"
                mskParameter.Mask = "00/00/0000"

            Case "Monthly"
                lblParameter.Text = "Date: (MM/YYYY)"
                mskParameter.Mask = "00/0000"

            Case "Annually"
                lblParameter.Text = "Date: (YYYY)"
                mskParameter.Mask = "0000"

            Case "Berth Window Report", "Cummulative Volume Report"
                lblParameter.Text = "Shipping Line:"
                mskParameter.Mask = ">LLL"

            Case "All Vessel Throughput Volume",
                 "Monthly Throughput Volume",
                 "Monthly Co-Load Throughput Volume"

                lblParameter.Text = "Date: (MM/YYYY)"
                mskParameter.Mask = "00/0000"

            Case "LOA Table"
                lblParameter.Enabled = False
                mskParameter.Enabled = False

            Case "Volume Breakdown", "Handling Services"
                lblParameter.Text = "Year: (YYYY)"
                mskParameter.Mask = "0000"
        End Select
    End Sub

End Class
