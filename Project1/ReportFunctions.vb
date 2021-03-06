﻿Public Class ReportFunctions
    Public Sub New(ByRef OPConnection As ADODB.Connection, ByRef N4Connection As ADODB.Connection)
        Me.OPConnection = OPConnection
        Me.N4Connection = N4Connection
    End Sub
    Private Property OPConnection As ADODB.Connection
    Private Property N4Connection As ADODB.Connection
    Public Enum KeyType
        Port
        Shipline
        BerthDelay
        QuayCrane
        Move_kind
        Ctrtyp
        Freight
        Delaykind
        Registry
    End Enum
    Shared Function GetFullName(ShippingLine As String) As String
        Dim tempConnections As Connections = New Connections()
        Dim N4Connection As ADODB.Connection = tempConnections.N4Connection

        N4Connection.Open()
        Dim FullNameRetriever As ADODB.Command = New ADODB.Command
        FullNameRetriever.ActiveConnection = N4Connection
        FullNameRetriever.CommandText = $"
SELECT NAME FROM REF_BIZUNIT_SCOPED WHERE ID = '{ShippingLine}'
"
        Try
            Return FullNameRetriever.Execute.Fields(0).Value

        Catch ex As Exception
            Return "N/A"
        End Try

    End Function
    Shared Function GetMilTime(strLDate As String) As String
        Dim dteDate As DateTime
        Try
            dteDate = Convert.ToDateTime(strLDate)
            GetMilTime = dteDate.ToString("HHmm\H MM/dd/yyyy")
        Catch

        End Try

    End Function

    Shared Function GetDateTime(strMDate As String) As Date
        Try
            Return Date.ParseExact(strMDate, "HHmm\H MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)
        Catch

        End Try


    End Function

    Shared Function GetSpanHours(TimeStart As Date, TimeEnd As Date) As Double
        Dim ata As Date = TimeStart
        Dim atd As Date = TimeEnd
        Dim span As TimeSpan = atd.Subtract(ata)

        Return span.TotalHours

    End Function


    Shared Function GetSpanDays(TimeStart As Date, TimeEnd As Date) As Double
        Dim ata As Date = TimeStart
        Dim atd As Date = TimeEnd
        Dim span As TimeSpan = atd.Subtract(ata)

        Return span.TotalDays

    End Function

    Public Function GetRefkey(keyName As KeyType, keyValue As String) As Integer
        Dim refkeyCommand As New ADODB.Command
        Dim insertRefkey As String
        Dim selectRefkey As String
        Dim refkey As Integer
        Dim database As String
        Dim field As String

        Select Case keyName
            Case KeyType.Port
                database = "ref_ports"
                field = "port"
            Case KeyType.Shipline
                database = "ref_shiplines"
                field = "shipline"
            Case KeyType.BerthDelay
                database = "ref_berthdelays"
                field = "berthdelay"
            Case KeyType.QuayCrane
                database = "ref_quaycranes"
                field = "qc_shortname"
            Case KeyType.Move_kind
                database = "ref_move_kinds"
                field = "move_kind"
            Case KeyType.Delaykind
                database = "ref_delaykinds"
                field = "delaykind"
            Case KeyType.Registry
                database = "ref_registry"
                field = "registry"
        End Select

        refkeyCommand.ActiveConnection = OPConnection

        insertRefkey = $"insert into {database}({field}) values('{keyValue}') select scope_identity() as newid "
        selectRefkey = $"select refkey from {database} where {field} = '{keyValue}'"
        ' $ for string interpolation, to lessen string concatenation when building sql statements etc.
        Try
            refkeyCommand.CommandText = selectRefkey
            refkey = refkeyCommand.Execute.Fields("refkey").Value.ToString
        Catch 'insert shipline then return refkey
            refkeyCommand.CommandText = insertRefkey
            refkey = refkeyCommand.Execute.Fields("newid").Value
        End Try

        Return refkey
    End Function

    Shared Function ParseDBNulltoString(v As Object) As String
        If v Is DBNull.Value Then
            Return ""
        Else
            Return Trim(v.ToString())
        End If
    End Function

    Shared Function ConvertDelayKindtoTableName(value As Object) As String
        Select Case value
            Case "DEDUC"
                Return "Deductable"
            Case "BREAK"
                Return "Break"
            Case "NONDE"
                Return "NonDeductable"
        End Select
    End Function

    Public Shared Function TranslateISO(v As String) As String
        Select Case v
            Case "Dry"
                Return "Dry"
            Case "Rfr"
                Return "Reefer"
            Case "FRk"
                Return "Flat/Rack"
            Case "Tnk"
                Return "Tank Tainer"
            Case "Opn"
                Return "Open Top"
        End Select
    End Function
End Class
