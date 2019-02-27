Public Class StatusForm

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ConnectToDatabases()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ConnectToDatabases()
        With My.Settings
            N4Connection.ConnectionString = "Provider=SQLOLEDB;
                        Data Source=" & .N4Server & ";
                        Initial Catalog=" & .N4Database & ";
                        User ID=tosadmin;Password=tosadmin;"

            OPConnection.ConnectionString = "Provider=SQLOLEDB;
                        Data Source=" & .OPServer & ";
                        Initial Catalog=" & .OPDatabase & ";
                        User ID=sa_ictsi;Password=Ictsi123;"

            Try
                N4Connection.Open()
                OPConnection.Open()

                N4Connection.Close()
                OPConnection.Close()
            Catch ex As Exception
                MsgBox("Cannot Connect to Database" & vbNewLine &
                       Err.Number & vbNewLine &
                       Err.Description)
            End Try
        End With
    End Sub

    Private terminalStatus As TSRClass
    Private N4Connection As New ADODB.Connection
    Private OPConnection As New ADODB.Connection

    Private Sub CreateTerminalStatus(now As Date)
        terminalStatus = New TSRClass(now)
        terminalStatus.Save()


        lblTsrDate.Text = now
        With terminalStatus
            txtGroundSlot.Text = .TotalGroundSlotTEU
            txtStaticCapacity.Text = .StaticCapacityTEU
            txtTotalYardCapacity.Text = .TotalYardCapacityTEU
            txtGrossCrane.Text = Format(.MTDAverageGrossCraneProductivity, "0")
            txtGrossVessel.Text = Format(.MTDAverageGrossVesselProductivity, "0")
            txtGrossBerth.Text = Format(.MTDAverageGrossBerthProductivity, "0")
            txtNetCrane.Text = Format(.MTDAverageNetCraneProductivity, "0")
            txtNetVessel.Text = Format(.MTDAverageNetVesselProductivity, "0")
            txtNetBerth.Text = Format(.MTDAverageNetBerthProductivity, "0")
            txtAverageImport.Text = Format(.AverageImportDwellTime, "0")
            txtMTDImport.Text = Format(.MTDImportDwellTime, "0")
            txtYTDImport.Text = Format(.YTDImportDwellTime, "0")
            txtMTDExport.Text = Format(.MTDExportDwellTime, "0")
            txtYTDExport.Text = Format(.YTDExportDwellTime, "0")
            txtDailyTEUIn.Text = Format(.DailyTEUInByTrucks, "0")
            txtDailyTEUOut.Text = Format(.DailyTEUOutByTrucks, "0")
            txtMTDTEUIn.Text = Format(.MTDTEUInByTrucks, "0")
            txtMTDTEUOut.Text = Format(.MTDTEUOutByTrucks, "0")
            txtYTDTEUIn.Text = Format(.YTDTEUInByTrucks, "0")
            txtYTDTEUOut.Text = Format(.YTDTEUOutByTrucks, "0")
            txtOverstayingManila.Text = Format(.OverstayingManilaCargo, "0")
            txtOverstayingTotal.Text = Format(.TotalOverstayingCargo, "0")
            txtImportFull.Text = Format(.ImportFullTEU, "0")
            txtImportEmpty.Text = Format(.ImportEmptyTEU, "0")
            txtExportFull.Text = Format(.ExportFullTEU, "0")
            txtExportEmpty.Text = Format(.ExportEmptyTEU, "0")
            txtStorageEmpty.Text = Format(.StorageEmptyTEU, "0")
            txtYardTotal.Text = Format(.TotalInYardTEU, "0")
            txtYardUtilization.Text = Format(.YardUtilization, "0") & "%"


        End With

    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        CreateTerminalStatus(Date.Now)
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        Dim settings As New Settings
        settings.ShowDialog()
    End Sub

    Private Sub StatusForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            NotifyIcon1.Icon = Me.Icon
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            NotifyIcon1.BalloonTipTitle = "Terminal Status Report"
            NotifyIcon1.BalloonTipText = "Show Terminal Status Generator"
            NotifyIcon1.ShowBalloonTip(50000)
            ShowInTaskbar = False
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (Date.Now.Minute Mod My.Settings.Interval) = 0 Then
            Timer1.Stop()
            CreateTerminalStatus(Date.Now)
            Timer1.Start()
        End If
    End Sub

End Class
