Imports Reports
Imports adodb
Public Class VesselMonitor

    Public Property GC1 As Crane
    Public Property GC2 As Crane
    Public Property GC3 As Crane
    Public Property GC4 As Crane
    Public Property Vessel As Vessel
    Private DateNow As DateTime
    Private N4Connection As New ADODB.Connection

    Private Sub GenerateMonitoring(Registry)

        Vessel = New Vessel(Registry, N4Connection)
        If Not Vessel.Phase.Contains("WORKING") Then MsgBox("Vessel has finished 'WORKING' Phase.") : Exit Sub
        GC1 = New Crane("GC01", Registry, N4Connection, False)
        GC2 = New Crane("GC02", Registry, N4Connection, False)
        GC3 = New Crane("GC03", Registry, N4Connection, False)
        GC4 = New Crane("GC04", Registry, N4Connection, False)

        txtVessel.Text = Vessel.Name
        txtVoyage.Text = $"{Vessel.InboundVoyage} - {Vessel.OutboundVoyage}"
        txtBerthWindow.Text = Vessel.BerthWindow


        Dim consolidatedMoves1 As New DataTable
        Dim consolidatedMoves2 As New DataTable
        Dim consolidatedMoves3 As New DataTable
        Dim consolidatedMoves4 As New DataTable

        consolidatedMoves1.Merge(GC1.Moves.Inbound)
        consolidatedMoves1.Merge(GC1.Moves.Outbound)

        consolidatedMoves2.Merge(GC2.Moves.Inbound)
        consolidatedMoves2.Merge(GC2.Moves.Outbound)

        consolidatedMoves3.Merge(GC3.Moves.Inbound)
        consolidatedMoves3.Merge(GC3.Moves.Outbound)

        consolidatedMoves4.Merge(GC4.Moves.Inbound)
        consolidatedMoves4.Merge(GC4.Moves.Outbound)

        txtDsc1.Text = consolidatedMoves1.AsEnumerable.Count(Function(move) move("category") = "IMPRT")
        txtLoad1.Text = consolidatedMoves1.AsEnumerable.Count(Function(move) move("category") = "EXPRT")
        txtSVD1.Text = consolidatedMoves1.AsEnumerable.Where(Function(move) move("event") IsNot DBNull.Value).Count(Function(move) move("event") = "UNIT_SHIFT_VIA_DOCK")
        txtMoves1.Text = consolidatedMoves1.AsEnumerable.Count()

        txtDsc2.Text = consolidatedMoves2.AsEnumerable.Count(Function(move) move("category") = "IMPRT")
        txtLoad2.Text = consolidatedMoves2.AsEnumerable.Count(Function(move) move("category") = "EXPRT")
        txtSVD2.Text = consolidatedMoves2.AsEnumerable.Where(Function(move) move("event") IsNot DBNull.Value).Count(Function(move) move("event") IsNot DBNull.Value And move("event") = "UNIT_SHIFT_VIA_DOCK")
        txtMoves2.Text = consolidatedMoves2.AsEnumerable.Count()

        txtDSC3.Text = consolidatedMoves3.AsEnumerable.Count(Function(move) move("category") = "IMPRT")
        txtLoad3.Text = consolidatedMoves3.AsEnumerable.Count(Function(move) move("category") = "EXPRT")
        txtSVD3.Text = consolidatedMoves3.AsEnumerable.Where(Function(move) move("event") IsNot DBNull.Value).Count(Function(move) move("event") IsNot DBNull.Value And move("event") = "UNIT_SHIFT_VIA_DOCK")
        txtMoves3.Text = consolidatedMoves3.AsEnumerable.Count()

        txtDsc4.Text = consolidatedMoves4.AsEnumerable.Count(Function(move) move("category") = "IMPRT")
        txtLoad4.Text = consolidatedMoves4.AsEnumerable.Count(Function(move) move("category") = "EXPRT")
        txtSVD4.Text = consolidatedMoves4.AsEnumerable.Where(Function(move) move("event") IsNot DBNull.Value).Count(Function(move) move("event") IsNot DBNull.Value And move("event") = "UNIT_SHIFT_VIA_DOCK")
        txtMoves4.Text = consolidatedMoves4.AsEnumerable.Count()

        Dim FirstMove1 As DateTime = consolidatedMoves1.AsEnumerable().Where(Function(move) move("time_move") IsNot DBNull.Value).Select(Of Date)(Function(move) CDate(move("time_move"))).OrderBy(Of Date)(Function(move) move).DefaultIfEmpty(DateNow).First
        Dim FirstMove2 As DateTime = consolidatedMoves2.AsEnumerable().Where(Function(move) move("time_move") IsNot DBNull.Value).Select(Of Date)(Function(move) CDate(move("time_move"))).OrderBy(Of Date)(Function(move) move).DefaultIfEmpty(DateNow).First
        Dim FirstMove3 As DateTime = consolidatedMoves3.AsEnumerable().Where(Function(move) move("time_move") IsNot DBNull.Value).Select(Of Date)(Function(move) CDate(move("time_move"))).OrderBy(Of Date)(Function(move) move).DefaultIfEmpty(DateNow).First
        Dim FirstMove4 As DateTime = consolidatedMoves4.AsEnumerable().Where(Function(move) move("time_move") IsNot DBNull.Value).Select(Of Date)(Function(move) CDate(move("time_move"))).OrderBy(Of Date)(Function(move) move).DefaultIfEmpty(DateNow).First

        Dim TimeElapsed1 As Double = ReportFunctions.GetSpanHours(FirstMove1, DateNow)
        Dim TimeElapsed2 As Double = ReportFunctions.GetSpanHours(FirstMove2, DateNow)
        Dim TimeElapsed3 As Double = ReportFunctions.GetSpanHours(FirstMove3, DateNow)
        Dim TimeElapsed4 As Double = ReportFunctions.GetSpanHours(FirstMove4, DateNow)

        txtHours1.Text = TimeElapsed1
        txtHours2.Text = TimeElapsed2
        txtHours3.Text = TimeElapsed3
        txtHours4.Text = TimeElapsed4

        txtMPH1.Text = txtMoves1.Text / TimeElapsed1
        txtMPH2.Text = txtMoves2.Text / TimeElapsed2
        txtMPH3.Text = txtMoves3.Text / TimeElapsed3
        txtMPH4.Text = txtMoves4.Text / TimeElapsed4

        txtTotalDsc.Text = Vessel.Units.Containers.Tables(0).AsEnumerable.Count()
        txtTotalLoad.Text = Vessel.Units.Containers.Tables(1).AsEnumerable.Count()
        txtBalanceDSC.Text = CDbl(txtTotalDsc.Text) - (CDbl(0 & txtDsc1.Text) + CDbl(0 & txtDsc2.Text) + CDbl(0 & txtDSC3.Text) + CDbl(0 & txtDsc4.Text))
        txtBalanceLoad.Text = CDbl(txtTotalLoad.Text) - (CDbl(0 & txtLoad1.Text) + CDbl(0 & txtLoad2.Text) + CDbl(0 & txtLoad3.Text) + CDbl(0 & txtLoad4.Text))
        txtTotalSVD.Text = CDbl(0 & txtSVD1.Text) + CDbl(0 & txtSVD2.Text) + CDbl(0 & txtSVD3.Text) + CDbl(0 & txtSVD4.Text)
    End Sub

    Private Sub ConnectToDatabase()
        N4Connection.ConnectionString = "Provider=SQLOLEDB;
                        Data Source=sbitc-db;
                        Initial Catalog=apex;
                        User ID=tosadmin;Password=tosadmin;"
    End Sub

    Private Sub mskRegistry_KeyDown(sender As Object, e As KeyEventArgs) Handles mskRegistry.KeyDown
        If e.KeyCode = Keys.Enter Then
            DateNow = Date.Now
            ConnectToDatabase()
            GenerateMonitoring(mskRegistry.Text)

            For Each ctl As Control In Me.Controls
                If ctl.GetType Is GetType(TextBox) Then
                    Try
                        Dim convert As Double = ctl.Text
                        ctl.Text = Math.Round(convert, 1)

                    Catch ex As Exception

                    End Try
                End If
            Next
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label38_Click(sender As Object, e As EventArgs) Handles Label38.Click

    End Sub

    Private Sub VesselMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub
End Class
