Imports CrystalDecisions.Windows.Forms

Public Class MonitoringForm
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub DateParameter_KeyDown(sender As Object, e As KeyEventArgs) Handles DateParameter.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim tempDate As Date = Date.ParseExact(DateParameter.Text, "MM/dd/yyyy",
                                                       System.Globalization.CultureInfo.InvariantCulture)
                Dim report As New EmptyChargeableUnits(tempDate.Month,
                                                       tempDate.Day,
                                                       tempDate.Year)
                DateRange.Text = $"{report.StartDate} - {report.EndDate}"
                MonitoringReport.ReportSource = report



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

End Class
