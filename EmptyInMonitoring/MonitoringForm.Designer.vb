<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonitoringForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MonitoringReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.DateParameter = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateRange = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'MonitoringReport
        '
        Me.MonitoringReport.ActiveViewIndex = -1
        Me.MonitoringReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MonitoringReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MonitoringReport.Cursor = System.Windows.Forms.Cursors.Default
        Me.MonitoringReport.Location = New System.Drawing.Point(0, 49)
        Me.MonitoringReport.Name = "MonitoringReport"
        Me.MonitoringReport.Size = New System.Drawing.Size(858, 628)
        Me.MonitoringReport.TabIndex = 0
        '
        'DateParameter
        '
        Me.DateParameter.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateParameter.Location = New System.Drawing.Point(211, 12)
        Me.DateParameter.Mask = "00/00/0000"
        Me.DateParameter.Name = "DateParameter"
        Me.DateParameter.Size = New System.Drawing.Size(198, 31)
        Me.DateParameter.TabIndex = 1
        Me.DateParameter.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 26)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Date (MM/DD/YYYY):"
        '
        'DateRange
        '
        Me.DateRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateRange.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateRange.Location = New System.Drawing.Point(415, 15)
        Me.DateRange.Name = "DateRange"
        Me.DateRange.Size = New System.Drawing.Size(431, 25)
        Me.DateRange.TabIndex = 3
        Me.DateRange.Text = "Label2"
        Me.DateRange.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MonitoringForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 677)
        Me.Controls.Add(Me.DateRange)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateParameter)
        Me.Controls.Add(Me.MonitoringReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "MonitoringForm"
        Me.Text = "Empty In Monitoring"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MonitoringReport As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DateParameter As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DateRange As Label
End Class
