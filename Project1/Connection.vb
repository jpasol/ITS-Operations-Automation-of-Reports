
Imports System.Configuration
Imports System.Windows.Forms
Public Class Connections
    Public Sub New()

        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(Me.GetType.Assembly.Location)
        Dim userSettings As New ClientSettingsSection
        userSettings = config.SectionGroups.Item("userSettings").Sections("Reports.Settings")

        With userSettings

            Dim n4Server As String = .Settings.Get("N4Server").Value.ValueXml.InnerText
            Dim n4Database As String = .Settings.Get("N4Database").Value.ValueXml.InnerText
            Dim opServer As String = .Settings.Get("OPServer").Value.ValueXml.InnerText
            Dim opDatabase As String = .Settings.Get("OPDatabase").Value.ValueXml.InnerText
            Dim blServer As String = .Settings.Get("BLServer").Value.ValueXml.InnerText
            Dim blDatabase As String = .Settings.Get("BLDatabase").Value.ValueXml.InnerText



            N4Connection.ConnectionString = $"Provider=SQLOLEDB;
                        Data Source={n4Server};
                        Initial Catalog={n4Database};
                        User ID=tosadmin;Password=tosadmin;"

            OPConnection.ConnectionString = $"Provider=SQLOLEDB;
                        Data Source={opServer};
                        Initial Catalog={opDatabase};
                        User ID=sa_ictsi;Password=Ictsi123;"

            BLConnection.ConnectionString = $"Provider=SQLOLEDB;
                        Data Source={blServer};
                        Initial Catalog={blDatabase};
                        User ID=sa_ictsi;Password=Ictsi123;"
        End With
    End Sub

    Public N4Connection As New ADODB.Connection
    Public OPConnection As New ADODB.Connection
    Public BLConnection As New ADODB.Connection

End Class
