Public Class Connections
    Public Sub New()
        With My.Settings
            N4Connection.ConnectionString = "Provider=SQLOLEDB;
                        Data Source=" & .N4Server & ";
                        Initial Catalog=" & .N4Database & ";
                        User ID=tosadmin;Password=tosadmin;"

            OPConnection.ConnectionString = "Provider=SQLOLEDB;
                        Data Source=" & .OPServer & ";
                        Initial Catalog=" & .OPDatabase & ";
                        User ID=sa_ictsi;Password=Ictsi123;"
        End With

    End Sub

    Public N4Connection As New ADODB.Connection
    Public OPConnection As New ADODB.Connection

End Class
