<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.txtTotalYardCapacity = New System.Windows.Forms.TextBox()
        Me.txtStaticCapacity = New System.Windows.Forms.TextBox()
        Me.txtGroundSlot = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInterval = New System.Windows.Forms.TextBox()
        Me.lblInterval = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtTotalYardCapacity
        '
        Me.txtTotalYardCapacity.BackColor = System.Drawing.Color.White
        Me.txtTotalYardCapacity.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalYardCapacity.Location = New System.Drawing.Point(195, 138)
        Me.txtTotalYardCapacity.Name = "txtTotalYardCapacity"
        Me.txtTotalYardCapacity.Size = New System.Drawing.Size(103, 27)
        Me.txtTotalYardCapacity.TabIndex = 35
        Me.txtTotalYardCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtStaticCapacity
        '
        Me.txtStaticCapacity.BackColor = System.Drawing.Color.White
        Me.txtStaticCapacity.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtStaticCapacity.Location = New System.Drawing.Point(195, 115)
        Me.txtStaticCapacity.Name = "txtStaticCapacity"
        Me.txtStaticCapacity.Size = New System.Drawing.Size(103, 27)
        Me.txtStaticCapacity.TabIndex = 34
        Me.txtStaticCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGroundSlot
        '
        Me.txtGroundSlot.BackColor = System.Drawing.Color.White
        Me.txtGroundSlot.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtGroundSlot.Location = New System.Drawing.Point(195, 92)
        Me.txtGroundSlot.Name = "txtGroundSlot"
        Me.txtGroundSlot.Size = New System.Drawing.Size(103, 27)
        Me.txtGroundSlot.TabIndex = 33
        Me.txtGroundSlot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 23)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Total Yard Capacity (TEU)"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 23)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Static Capacity (TEU)"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 23)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Total Ground Slot (TEU)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(273, 73)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Settings"
        '
        'txtInterval
        '
        Me.txtInterval.BackColor = System.Drawing.Color.White
        Me.txtInterval.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtInterval.Location = New System.Drawing.Point(195, 161)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(103, 27)
        Me.txtInterval.TabIndex = 38
        Me.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblInterval
        '
        Me.lblInterval.BackColor = System.Drawing.Color.White
        Me.lblInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInterval.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.lblInterval.Location = New System.Drawing.Point(12, 163)
        Me.lblInterval.Name = "lblInterval"
        Me.lblInterval.Size = New System.Drawing.Size(177, 23)
        Me.lblInterval.TabIndex = 37
        Me.lblInterval.Text = "Interval (Minutes)"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(223, 206)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 39
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 241)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.txtInterval)
        Me.Controls.Add(Me.lblInterval)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotalYardCapacity)
        Me.Controls.Add(Me.txtStaticCapacity)
        Me.Controls.Add(Me.txtGroundSlot)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTotalYardCapacity As TextBox
    Friend WithEvents txtStaticCapacity As TextBox
    Friend WithEvents txtGroundSlot As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtInterval As TextBox
    Friend WithEvents lblInterval As Label
    Friend WithEvents cmdSave As Button
End Class
