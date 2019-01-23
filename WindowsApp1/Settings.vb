Public Class Settings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        With My.Settings
            txtGroundSlot.Text = .TotalGroundSlot
            txtStaticCapacity.Text = .StaticCapacity
            txtTotalYardCapacity.Text = .TotalYardCapacity
            txtInterval.Text = .Interval
        End With
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim result = MsgBox("Would you like to save these settings?", vbYesNo)
        If result = vbYes Then
            With My.Settings
                .TotalGroundSlot = txtGroundSlot.Text
                .StaticCapacity = txtStaticCapacity.Text
                .TotalYardCapacity = txtTotalYardCapacity.Text
                .Interval = txtInterval.Text
            End With
            Me.Dispose()
        End If
    End Sub
End Class