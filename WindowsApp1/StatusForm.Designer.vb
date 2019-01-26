<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StatusForm
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EventLog1 = New System.Diagnostics.EventLog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtGroundSlot = New System.Windows.Forms.TextBox()
        Me.txtStaticCapacity = New System.Windows.Forms.TextBox()
        Me.txtGrossCrane = New System.Windows.Forms.TextBox()
        Me.txtTotalYardCapacity = New System.Windows.Forms.TextBox()
        Me.txtMTDImport = New System.Windows.Forms.TextBox()
        Me.txtAverageImport = New System.Windows.Forms.TextBox()
        Me.txtGrossBerth = New System.Windows.Forms.TextBox()
        Me.txtGrossVessel = New System.Windows.Forms.TextBox()
        Me.txtMTDTEUIn = New System.Windows.Forms.TextBox()
        Me.txtYTDExport = New System.Windows.Forms.TextBox()
        Me.txtMTDExport = New System.Windows.Forms.TextBox()
        Me.txtYTDImport = New System.Windows.Forms.TextBox()
        Me.txtYardUtilization = New System.Windows.Forms.TextBox()
        Me.txtYardTotal = New System.Windows.Forms.TextBox()
        Me.txtStorageEmpty = New System.Windows.Forms.TextBox()
        Me.txtExportFull = New System.Windows.Forms.TextBox()
        Me.txtImportEmpty = New System.Windows.Forms.TextBox()
        Me.txtImportFull = New System.Windows.Forms.TextBox()
        Me.txtOverstayingTotal = New System.Windows.Forms.TextBox()
        Me.txtOverstayingManila = New System.Windows.Forms.TextBox()
        Me.txtYTDTEUOut = New System.Windows.Forms.TextBox()
        Me.txtYTDTEUIn = New System.Windows.Forms.TextBox()
        Me.txtMTDTEUOut = New System.Windows.Forms.TextBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTsrDate = New System.Windows.Forms.Label()
        Me.txtNetBerth = New System.Windows.Forms.TextBox()
        Me.txtNetVessel = New System.Windows.Forms.TextBox()
        Me.txtNetCrane = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtDailyTEUOut = New System.Windows.Forms.TextBox()
        Me.txtDailyTEUIn = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtExportEmpty = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(488, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "As of: "
        '
        'EventLog1
        '
        Me.EventLog1.SynchronizingObject = Me
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(315, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Total Ground Slot (TEU)"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(315, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Static Capacity (TEU)"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(315, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Total Yard Capacity (TEU)"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(315, 23)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "MTD Average Gross Crane Productivity"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 258)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(315, 23)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "MTD Average Gross Vessel Productivity"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 281)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(315, 23)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "MTD Average Gross Berth Productivity"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 373)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(315, 23)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Average Import Dwell Time (In Yard - Days)"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 396)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(315, 23)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Import Dwell Time MTD (Days)"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 419)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(315, 23)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Import Dwell Time YTD (Days)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 442)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(315, 23)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Export Dwell Time MTD (Days)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 465)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(315, 23)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Export Dwell Time YTD (Days)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 534)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(315, 23)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "MTD TEU IN by Trucks"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 557)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(315, 23)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "MTD TEU OUT by Trucks"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 580)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(315, 23)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "YTD TEU IN by Trucks"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 764)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(315, 23)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Storage Empty (TEU)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 718)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(315, 23)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Export Full (TEU)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(12, 695)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(315, 23)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Import Empty (TEU)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(12, 672)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(315, 23)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "Import Full (TEU)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(12, 649)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(315, 23)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "Total Overstaying Cargo (TEU)"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.White
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(12, 626)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(315, 23)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Overstaying Cargo Manila Only (TEU)"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(12, 603)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(315, 23)
        Me.Label22.TabIndex = 18
        Me.Label22.Text = "YTD TEU OUT by Trucks"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(12, 810)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(315, 23)
        Me.Label23.TabIndex = 26
        Me.Label23.Text = "YARD UTILIZATION"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.White
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(12, 787)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(315, 23)
        Me.Label24.TabIndex = 25
        Me.Label24.Text = "TOTAL IN YARD (TEU)"
        '
        'txtGroundSlot
        '
        Me.txtGroundSlot.BackColor = System.Drawing.Color.White
        Me.txtGroundSlot.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtGroundSlot.Location = New System.Drawing.Point(333, 166)
        Me.txtGroundSlot.Multiline = True
        Me.txtGroundSlot.Name = "txtGroundSlot"
        Me.txtGroundSlot.Size = New System.Drawing.Size(143, 23)
        Me.txtGroundSlot.TabIndex = 27
        Me.txtGroundSlot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtStaticCapacity
        '
        Me.txtStaticCapacity.BackColor = System.Drawing.Color.White
        Me.txtStaticCapacity.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtStaticCapacity.Location = New System.Drawing.Point(333, 189)
        Me.txtStaticCapacity.Multiline = True
        Me.txtStaticCapacity.Name = "txtStaticCapacity"
        Me.txtStaticCapacity.Size = New System.Drawing.Size(143, 23)
        Me.txtStaticCapacity.TabIndex = 28
        Me.txtStaticCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGrossCrane
        '
        Me.txtGrossCrane.BackColor = System.Drawing.Color.White
        Me.txtGrossCrane.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtGrossCrane.Location = New System.Drawing.Point(333, 235)
        Me.txtGrossCrane.Multiline = True
        Me.txtGrossCrane.Name = "txtGrossCrane"
        Me.txtGrossCrane.Size = New System.Drawing.Size(143, 23)
        Me.txtGrossCrane.TabIndex = 30
        Me.txtGrossCrane.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalYardCapacity
        '
        Me.txtTotalYardCapacity.BackColor = System.Drawing.Color.White
        Me.txtTotalYardCapacity.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalYardCapacity.Location = New System.Drawing.Point(333, 212)
        Me.txtTotalYardCapacity.Multiline = True
        Me.txtTotalYardCapacity.Name = "txtTotalYardCapacity"
        Me.txtTotalYardCapacity.Size = New System.Drawing.Size(143, 23)
        Me.txtTotalYardCapacity.TabIndex = 29
        Me.txtTotalYardCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMTDImport
        '
        Me.txtMTDImport.BackColor = System.Drawing.Color.White
        Me.txtMTDImport.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtMTDImport.Location = New System.Drawing.Point(333, 396)
        Me.txtMTDImport.Multiline = True
        Me.txtMTDImport.Name = "txtMTDImport"
        Me.txtMTDImport.Size = New System.Drawing.Size(143, 23)
        Me.txtMTDImport.TabIndex = 34
        Me.txtMTDImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAverageImport
        '
        Me.txtAverageImport.BackColor = System.Drawing.Color.White
        Me.txtAverageImport.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtAverageImport.Location = New System.Drawing.Point(333, 373)
        Me.txtAverageImport.Multiline = True
        Me.txtAverageImport.Name = "txtAverageImport"
        Me.txtAverageImport.Size = New System.Drawing.Size(143, 23)
        Me.txtAverageImport.TabIndex = 33
        Me.txtAverageImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGrossBerth
        '
        Me.txtGrossBerth.BackColor = System.Drawing.Color.White
        Me.txtGrossBerth.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtGrossBerth.Location = New System.Drawing.Point(333, 281)
        Me.txtGrossBerth.Multiline = True
        Me.txtGrossBerth.Name = "txtGrossBerth"
        Me.txtGrossBerth.Size = New System.Drawing.Size(143, 23)
        Me.txtGrossBerth.TabIndex = 32
        Me.txtGrossBerth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGrossVessel
        '
        Me.txtGrossVessel.BackColor = System.Drawing.Color.White
        Me.txtGrossVessel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtGrossVessel.Location = New System.Drawing.Point(333, 258)
        Me.txtGrossVessel.Multiline = True
        Me.txtGrossVessel.Name = "txtGrossVessel"
        Me.txtGrossVessel.Size = New System.Drawing.Size(143, 23)
        Me.txtGrossVessel.TabIndex = 31
        Me.txtGrossVessel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMTDTEUIn
        '
        Me.txtMTDTEUIn.BackColor = System.Drawing.Color.White
        Me.txtMTDTEUIn.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtMTDTEUIn.Location = New System.Drawing.Point(333, 534)
        Me.txtMTDTEUIn.Multiline = True
        Me.txtMTDTEUIn.Name = "txtMTDTEUIn"
        Me.txtMTDTEUIn.Size = New System.Drawing.Size(143, 23)
        Me.txtMTDTEUIn.TabIndex = 38
        Me.txtMTDTEUIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtYTDExport
        '
        Me.txtYTDExport.BackColor = System.Drawing.Color.White
        Me.txtYTDExport.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtYTDExport.Location = New System.Drawing.Point(333, 465)
        Me.txtYTDExport.Multiline = True
        Me.txtYTDExport.Name = "txtYTDExport"
        Me.txtYTDExport.Size = New System.Drawing.Size(143, 23)
        Me.txtYTDExport.TabIndex = 37
        Me.txtYTDExport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMTDExport
        '
        Me.txtMTDExport.BackColor = System.Drawing.Color.White
        Me.txtMTDExport.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtMTDExport.Location = New System.Drawing.Point(333, 442)
        Me.txtMTDExport.Multiline = True
        Me.txtMTDExport.Name = "txtMTDExport"
        Me.txtMTDExport.Size = New System.Drawing.Size(143, 23)
        Me.txtMTDExport.TabIndex = 36
        Me.txtMTDExport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtYTDImport
        '
        Me.txtYTDImport.BackColor = System.Drawing.Color.White
        Me.txtYTDImport.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtYTDImport.Location = New System.Drawing.Point(333, 419)
        Me.txtYTDImport.Multiline = True
        Me.txtYTDImport.Name = "txtYTDImport"
        Me.txtYTDImport.Size = New System.Drawing.Size(143, 23)
        Me.txtYTDImport.TabIndex = 35
        Me.txtYTDImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtYardUtilization
        '
        Me.txtYardUtilization.BackColor = System.Drawing.Color.White
        Me.txtYardUtilization.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtYardUtilization.Location = New System.Drawing.Point(333, 810)
        Me.txtYardUtilization.Multiline = True
        Me.txtYardUtilization.Name = "txtYardUtilization"
        Me.txtYardUtilization.Size = New System.Drawing.Size(143, 23)
        Me.txtYardUtilization.TabIndex = 49
        Me.txtYardUtilization.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtYardTotal
        '
        Me.txtYardTotal.BackColor = System.Drawing.Color.White
        Me.txtYardTotal.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtYardTotal.Location = New System.Drawing.Point(333, 787)
        Me.txtYardTotal.Multiline = True
        Me.txtYardTotal.Name = "txtYardTotal"
        Me.txtYardTotal.Size = New System.Drawing.Size(143, 23)
        Me.txtYardTotal.TabIndex = 48
        Me.txtYardTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtStorageEmpty
        '
        Me.txtStorageEmpty.BackColor = System.Drawing.Color.White
        Me.txtStorageEmpty.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtStorageEmpty.Location = New System.Drawing.Point(333, 764)
        Me.txtStorageEmpty.Multiline = True
        Me.txtStorageEmpty.Name = "txtStorageEmpty"
        Me.txtStorageEmpty.Size = New System.Drawing.Size(143, 23)
        Me.txtStorageEmpty.TabIndex = 47
        Me.txtStorageEmpty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtExportFull
        '
        Me.txtExportFull.BackColor = System.Drawing.Color.White
        Me.txtExportFull.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtExportFull.Location = New System.Drawing.Point(333, 718)
        Me.txtExportFull.Multiline = True
        Me.txtExportFull.Name = "txtExportFull"
        Me.txtExportFull.Size = New System.Drawing.Size(143, 23)
        Me.txtExportFull.TabIndex = 46
        Me.txtExportFull.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtImportEmpty
        '
        Me.txtImportEmpty.BackColor = System.Drawing.Color.White
        Me.txtImportEmpty.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtImportEmpty.Location = New System.Drawing.Point(333, 695)
        Me.txtImportEmpty.Multiline = True
        Me.txtImportEmpty.Name = "txtImportEmpty"
        Me.txtImportEmpty.Size = New System.Drawing.Size(143, 23)
        Me.txtImportEmpty.TabIndex = 45
        Me.txtImportEmpty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtImportFull
        '
        Me.txtImportFull.BackColor = System.Drawing.Color.White
        Me.txtImportFull.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtImportFull.Location = New System.Drawing.Point(333, 672)
        Me.txtImportFull.Multiline = True
        Me.txtImportFull.Name = "txtImportFull"
        Me.txtImportFull.Size = New System.Drawing.Size(143, 23)
        Me.txtImportFull.TabIndex = 44
        Me.txtImportFull.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOverstayingTotal
        '
        Me.txtOverstayingTotal.BackColor = System.Drawing.Color.White
        Me.txtOverstayingTotal.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtOverstayingTotal.Location = New System.Drawing.Point(333, 649)
        Me.txtOverstayingTotal.Multiline = True
        Me.txtOverstayingTotal.Name = "txtOverstayingTotal"
        Me.txtOverstayingTotal.Size = New System.Drawing.Size(143, 23)
        Me.txtOverstayingTotal.TabIndex = 43
        Me.txtOverstayingTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOverstayingManila
        '
        Me.txtOverstayingManila.BackColor = System.Drawing.Color.White
        Me.txtOverstayingManila.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtOverstayingManila.Location = New System.Drawing.Point(333, 626)
        Me.txtOverstayingManila.Multiline = True
        Me.txtOverstayingManila.Name = "txtOverstayingManila"
        Me.txtOverstayingManila.Size = New System.Drawing.Size(143, 23)
        Me.txtOverstayingManila.TabIndex = 42
        Me.txtOverstayingManila.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtYTDTEUOut
        '
        Me.txtYTDTEUOut.BackColor = System.Drawing.Color.White
        Me.txtYTDTEUOut.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtYTDTEUOut.Location = New System.Drawing.Point(333, 603)
        Me.txtYTDTEUOut.Multiline = True
        Me.txtYTDTEUOut.Name = "txtYTDTEUOut"
        Me.txtYTDTEUOut.Size = New System.Drawing.Size(143, 23)
        Me.txtYTDTEUOut.TabIndex = 41
        Me.txtYTDTEUOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtYTDTEUIn
        '
        Me.txtYTDTEUIn.BackColor = System.Drawing.Color.White
        Me.txtYTDTEUIn.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtYTDTEUIn.Location = New System.Drawing.Point(333, 580)
        Me.txtYTDTEUIn.Multiline = True
        Me.txtYTDTEUIn.Name = "txtYTDTEUIn"
        Me.txtYTDTEUIn.Size = New System.Drawing.Size(143, 23)
        Me.txtYTDTEUIn.TabIndex = 40
        Me.txtYTDTEUIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMTDTEUOut
        '
        Me.txtMTDTEUOut.BackColor = System.Drawing.Color.White
        Me.txtMTDTEUOut.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtMTDTEUOut.Location = New System.Drawing.Point(333, 557)
        Me.txtMTDTEUOut.Multiline = True
        Me.txtMTDTEUOut.Name = "txtMTDTEUOut"
        Me.txtMTDTEUOut.Size = New System.Drawing.Size(143, 23)
        Me.txtMTDTEUOut.TabIndex = 39
        Me.txtMTDTEUOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Image = Global.AutomatedTerminalStatusReport.My.Resources.Resources.REFRESH
        Me.cmdRefresh.Location = New System.Drawing.Point(446, 135)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(30, 26)
        Me.cmdRefresh.TabIndex = 50
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AutomatedTerminalStatusReport.My.Resources.Resources.download
        Me.PictureBox1.Location = New System.Drawing.Point(12, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(464, 101)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'lblTsrDate
        '
        Me.lblTsrDate.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTsrDate.Location = New System.Drawing.Point(73, 135)
        Me.lblTsrDate.Name = "lblTsrDate"
        Me.lblTsrDate.Size = New System.Drawing.Size(190, 25)
        Me.lblTsrDate.TabIndex = 51
        Me.lblTsrDate.Text = "1400H 11/03/2019"
        '
        'txtNetBerth
        '
        Me.txtNetBerth.BackColor = System.Drawing.Color.White
        Me.txtNetBerth.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtNetBerth.Location = New System.Drawing.Point(333, 350)
        Me.txtNetBerth.Multiline = True
        Me.txtNetBerth.Name = "txtNetBerth"
        Me.txtNetBerth.Size = New System.Drawing.Size(143, 23)
        Me.txtNetBerth.TabIndex = 57
        Me.txtNetBerth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNetVessel
        '
        Me.txtNetVessel.BackColor = System.Drawing.Color.White
        Me.txtNetVessel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtNetVessel.Location = New System.Drawing.Point(333, 327)
        Me.txtNetVessel.Multiline = True
        Me.txtNetVessel.Name = "txtNetVessel"
        Me.txtNetVessel.Size = New System.Drawing.Size(143, 23)
        Me.txtNetVessel.TabIndex = 56
        Me.txtNetVessel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNetCrane
        '
        Me.txtNetCrane.BackColor = System.Drawing.Color.White
        Me.txtNetCrane.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtNetCrane.Location = New System.Drawing.Point(333, 304)
        Me.txtNetCrane.Multiline = True
        Me.txtNetCrane.Name = "txtNetCrane"
        Me.txtNetCrane.Size = New System.Drawing.Size(143, 23)
        Me.txtNetCrane.TabIndex = 55
        Me.txtNetCrane.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(12, 350)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(315, 23)
        Me.Label26.TabIndex = 54
        Me.Label26.Text = "MTD Average Net Berth Productivity"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 327)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(315, 23)
        Me.Label27.TabIndex = 53
        Me.Label27.Text = "MTD Average Net Vessel Productivity"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(12, 304)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(315, 23)
        Me.Label28.TabIndex = 52
        Me.Label28.Text = "MTD Average Net Crane Productivity"
        '
        'txtDailyTEUOut
        '
        Me.txtDailyTEUOut.BackColor = System.Drawing.Color.White
        Me.txtDailyTEUOut.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtDailyTEUOut.Location = New System.Drawing.Point(333, 511)
        Me.txtDailyTEUOut.Multiline = True
        Me.txtDailyTEUOut.Name = "txtDailyTEUOut"
        Me.txtDailyTEUOut.Size = New System.Drawing.Size(143, 23)
        Me.txtDailyTEUOut.TabIndex = 61
        Me.txtDailyTEUOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDailyTEUIn
        '
        Me.txtDailyTEUIn.BackColor = System.Drawing.Color.White
        Me.txtDailyTEUIn.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtDailyTEUIn.Location = New System.Drawing.Point(333, 488)
        Me.txtDailyTEUIn.Multiline = True
        Me.txtDailyTEUIn.Name = "txtDailyTEUIn"
        Me.txtDailyTEUIn.Size = New System.Drawing.Size(143, 23)
        Me.txtDailyTEUIn.TabIndex = 60
        Me.txtDailyTEUIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label29.Location = New System.Drawing.Point(12, 511)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(315, 23)
        Me.Label29.TabIndex = 59
        Me.Label29.Text = "Daily TEU OUT by Trucks"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label30.Location = New System.Drawing.Point(12, 488)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(315, 23)
        Me.Label30.TabIndex = 58
        Me.Label30.Text = "Daily TEU IN by Trucks"
        '
        'txtExportEmpty
        '
        Me.txtExportEmpty.BackColor = System.Drawing.Color.White
        Me.txtExportEmpty.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtExportEmpty.Location = New System.Drawing.Point(333, 741)
        Me.txtExportEmpty.Multiline = True
        Me.txtExportEmpty.Name = "txtExportEmpty"
        Me.txtExportEmpty.Size = New System.Drawing.Size(143, 23)
        Me.txtExportEmpty.TabIndex = 63
        Me.txtExportEmpty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(12, 741)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(315, 23)
        Me.Label31.TabIndex = 62
        Me.Label31.Text = "Export Empty (TEU)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "Terminal Status Report"
        Me.NotifyIcon1.Text = "Terminal Status Report"
        Me.NotifyIcon1.Visible = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'StatusForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 854)
        Me.Controls.Add(Me.txtExportEmpty)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtDailyTEUOut)
        Me.Controls.Add(Me.txtDailyTEUIn)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtNetBerth)
        Me.Controls.Add(Me.txtNetVessel)
        Me.Controls.Add(Me.txtNetCrane)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.lblTsrDate)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.txtYardUtilization)
        Me.Controls.Add(Me.txtYardTotal)
        Me.Controls.Add(Me.txtStorageEmpty)
        Me.Controls.Add(Me.txtExportFull)
        Me.Controls.Add(Me.txtImportEmpty)
        Me.Controls.Add(Me.txtImportFull)
        Me.Controls.Add(Me.txtOverstayingTotal)
        Me.Controls.Add(Me.txtOverstayingManila)
        Me.Controls.Add(Me.txtYTDTEUOut)
        Me.Controls.Add(Me.txtYTDTEUIn)
        Me.Controls.Add(Me.txtMTDTEUOut)
        Me.Controls.Add(Me.txtMTDTEUIn)
        Me.Controls.Add(Me.txtYTDExport)
        Me.Controls.Add(Me.txtMTDExport)
        Me.Controls.Add(Me.txtYTDImport)
        Me.Controls.Add(Me.txtMTDImport)
        Me.Controls.Add(Me.txtAverageImport)
        Me.Controls.Add(Me.txtGrossBerth)
        Me.Controls.Add(Me.txtGrossVessel)
        Me.Controls.Add(Me.txtGrossCrane)
        Me.Controls.Add(Me.txtTotalYardCapacity)
        Me.Controls.Add(Me.txtStaticCapacity)
        Me.Controls.Add(Me.txtGroundSlot)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "StatusForm"
        Me.Text = "Terminal Status"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents EventLog1 As EventLog
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdRefresh As Button
    Friend WithEvents txtYardUtilization As TextBox
    Friend WithEvents txtYardTotal As TextBox
    Friend WithEvents txtStorageEmpty As TextBox
    Friend WithEvents txtExportFull As TextBox
    Friend WithEvents txtImportEmpty As TextBox
    Friend WithEvents txtImportFull As TextBox
    Friend WithEvents txtOverstayingTotal As TextBox
    Friend WithEvents txtOverstayingManila As TextBox
    Friend WithEvents txtYTDTEUOut As TextBox
    Friend WithEvents txtYTDTEUIn As TextBox
    Friend WithEvents txtMTDTEUOut As TextBox
    Friend WithEvents txtMTDTEUIn As TextBox
    Friend WithEvents txtYTDExport As TextBox
    Friend WithEvents txtMTDExport As TextBox
    Friend WithEvents txtYTDImport As TextBox
    Friend WithEvents txtMTDImport As TextBox
    Friend WithEvents txtAverageImport As TextBox
    Friend WithEvents txtGrossBerth As TextBox
    Friend WithEvents txtGrossVessel As TextBox
    Friend WithEvents txtGrossCrane As TextBox
    Friend WithEvents txtTotalYardCapacity As TextBox
    Friend WithEvents txtStaticCapacity As TextBox
    Friend WithEvents txtGroundSlot As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents lblTsrDate As Label
    Friend WithEvents txtNetBerth As TextBox
    Friend WithEvents txtNetVessel As TextBox
    Friend WithEvents txtNetCrane As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents txtDailyTEUOut As TextBox
    Friend WithEvents txtDailyTEUIn As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents txtExportEmpty As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents Timer1 As Timer
End Class
