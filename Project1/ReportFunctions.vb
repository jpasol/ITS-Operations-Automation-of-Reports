Public Class ReportFunctions

    Shared Function getMilTime(strLDate As String) As String
        Dim dteDate As DateTime

        dteDate = Convert.ToDateTime(strLDate)
        getMilTime = dteDate.ToString("HHmm\H MM/dd/yyyy")
    End Function

    Shared Function getDateTime(strMDate As String) As Date
        Return Date.ParseExact(strMDate, "HHmm\H MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)
    End Function

End Class
