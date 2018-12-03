Public Class ReportFunctions

    Shared Function getMilTime(strLDate As String) As String
        Dim dteDate As DateTime
        Try
            dteDate = Convert.ToDateTime(strLDate)
            getMilTime = dteDate.ToString("HHmm\H MM/dd/yyyy")
        Catch

        End Try

    End Function

    Shared Function getDateTime(strMDate As String) As Date
        Try
            Return Date.ParseExact(strMDate, "HHmm\H MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)
        Catch

        End Try

    End Function

End Class
