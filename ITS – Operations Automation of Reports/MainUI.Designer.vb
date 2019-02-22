<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainUI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbReports = New System.Windows.Forms.ComboBox()
        Me.lblReports = New System.Windows.Forms.Label()
        Me.crvPreview = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblParameter = New System.Windows.Forms.Label()
        Me.mskParameter = New System.Windows.Forms.MaskedTextBox()
        Me.cmdGenerate = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.cmbMode = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1584, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmbReports
        '
        Me.cmbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReports.FormattingEnabled = True
        Me.cmbReports.Location = New System.Drawing.Point(12, 180)
        Me.cmbReports.Name = "cmbReports"
        Me.cmbReports.Size = New System.Drawing.Size(208, 28)
        Me.cmbReports.TabIndex = 1
        '
        'lblReports
        '
        Me.lblReports.AutoSize = True
        Me.lblReports.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReports.Location = New System.Drawing.Point(12, 161)
        Me.lblReports.Name = "lblReports"
        Me.lblReports.Size = New System.Drawing.Size(62, 16)
        Me.lblReports.TabIndex = 2
        Me.lblReports.Text = "Reports:"
        '
        'crvPreview
        '
        Me.crvPreview.ActiveViewIndex = -1
        Me.crvPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvPreview.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvPreview.Location = New System.Drawing.Point(226, 27)
        Me.crvPreview.Name = "crvPreview"
        Me.crvPreview.Size = New System.Drawing.Size(1346, 822)
        Me.crvPreview.TabIndex = 3
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Calibri", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(8, 27)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(212, 134)
        Me.lblTitle.TabIndex = 4
        Me.lblTitle.Text = "ITS - Operations Automation of Reports"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParameter
        '
        Me.lblParameter.AutoSize = True
        Me.lblParameter.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblParameter.Location = New System.Drawing.Point(12, 315)
        Me.lblParameter.Name = "lblParameter"
        Me.lblParameter.Size = New System.Drawing.Size(51, 16)
        Me.lblParameter.TabIndex = 5
        Me.lblParameter.Text = "Label1"
        '
        'mskParameter
        '
        Me.mskParameter.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.mskParameter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskParameter.Location = New System.Drawing.Point(12, 334)
        Me.mskParameter.Name = "mskParameter"
        Me.mskParameter.Size = New System.Drawing.Size(208, 26)
        Me.mskParameter.SkipLiterals = False
        Me.mskParameter.TabIndex = 6
        Me.mskParameter.ValidatingType = GetType(Date)
        '
        'cmdGenerate
        '
        Me.cmdGenerate.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.cmdGenerate.Location = New System.Drawing.Point(12, 569)
        Me.cmdGenerate.Name = "cmdGenerate"
        Me.cmdGenerate.Size = New System.Drawing.Size(208, 69)
        Me.cmdGenerate.TabIndex = 7
        Me.cmdGenerate.Text = "Generate"
        Me.cmdGenerate.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.cmdSave.Location = New System.Drawing.Point(12, 644)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(208, 69)
        Me.cmdSave.TabIndex = 8
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(9, 839)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(39, 13)
        Me.lblVersion.TabIndex = 9
        Me.lblVersion.Text = "Label1"
        '
        'lblMode
        '
        Me.lblMode.AutoSize = True
        Me.lblMode.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMode.Location = New System.Drawing.Point(12, 238)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(51, 16)
        Me.lblMode.TabIndex = 11
        Me.lblMode.Text = "Mode: "
        '
        'cmbMode
        '
        Me.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMode.FormattingEnabled = True
        Me.cmbMode.Items.AddRange(New Object() {"Daily", "Monthly", "Annually"})
        Me.cmbMode.Location = New System.Drawing.Point(12, 257)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.Size = New System.Drawing.Size(208, 28)
        Me.cmbMode.TabIndex = 10
        '
        'MainUI
        '
        Me.AcceptButton = Me.cmdGenerate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1584, 861)
        Me.Controls.Add(Me.lblMode)
        Me.Controls.Add(Me.cmbMode)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdGenerate)
        Me.Controls.Add(Me.mskParameter)
        Me.Controls.Add(Me.lblParameter)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.crvPreview)
        Me.Controls.Add(Me.lblReports)
        Me.Controls.Add(Me.cmbReports)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ITS - Operations Automation of Reports"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents cmbReports As ComboBox
    Friend WithEvents lblReports As Label
    Friend WithEvents crvPreview As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblParameter As Label
    Friend WithEvents mskParameter As MaskedTextBox
    Friend WithEvents cmdGenerate As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents lblVersion As Label
    Friend WithEvents ExitToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents lblMode As Label
    Friend WithEvents cmbMode As ComboBox
End Class
