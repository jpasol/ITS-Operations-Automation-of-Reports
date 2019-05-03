Imports System.Collections.Generic
Imports ADODB
Imports Reports

Public Class BudgetVolume

    Public Structure Volume
        Public Sub New(Year As Integer,
                       Month As Integer,
                       Category As String,
                       FreightKind As String,
                       Volume As Double)

            Me.Year = Year
            Me.Month = Month
            Me.Category = Category
            Me.FreightKind = FreightKind
            Me.Volume = Volume

        End Sub
        Public ReadOnly Year As Integer
        Public ReadOnly Month As Integer
        Public ReadOnly Category As String
        Public ReadOnly FreightKind As String
        Public ReadOnly Volume As Double

    End Structure


    Public Sub New(Year As Integer)
        Me.Year = Year

        Dim connections As New Reports.Connections
        Me.OPConnection = connections.OPConnection

        MonthlyVolume = New List(Of Volume)
        Retrieve()

    End Sub

    Private Sub Retrieve()
        Dim retrieveYear As Integer = Me.Year
        OPConnection.Open()
        Dim budgetRetrieveCommand As New ADODB.Command
        budgetRetrieveCommand.ActiveConnection = OPConnection
        budgetRetrieveCommand.CommandText = $"
SELECT [month]
      ,[year]
      ,[category]
      ,[freight_kind]
      ,[volume]
  FROM [opreports].[dbo].[budget]

where [year] = {retrieveYear}
"
        GenerateVolume(budgetRetrieveCommand.Execute)
        OPConnection.Close()

    End Sub

    Private Sub GenerateVolume(execute As Recordset)
        With execute
            While Not .EOF
                Dim volumeYear As Integer = .Fields("year").Value
                Dim volumeMonth As Integer = .Fields("month").Value
                Dim volumeCategory As String = .Fields("category").Value
                Dim volumeFreight As String = .Fields("freight_kind").Value
                Dim volume As Double = .Fields("volume").Value

                MonthlyVolume.Add(New Volume(Year:=volumeYear,
                                             Month:=volumeMonth,
                                             Category:=volumeCategory,
                                             FreightKind:=volumeFreight,
                                             Volume:=volume))
                .MoveNext()

            End While

        End With
    End Sub

    Public Sub Save()
        OPConnection.Open()
        OPConnection.BeginTrans()

        Try
            For Each volume As Volume In MonthlyVolume
                If Exists(volume) Then
                    Update(volume)
                    Continue For
                Else

                    If volume.Volume > 0 Then
                        Dim saveVolumeCommand As New ADODB.Command
                        saveVolumeCommand.ActiveConnection = OPConnection
                        saveVolumeCommand.CommandText = $"
INSERT INTO [opreports].[dbo].[budget]
           ([month]
           ,[year]
           ,[category]
           ,[freight_kind]
           ,[volume])
     VALUES
           ({volume.Month}
           ,{volume.Year}
           ,'{volume.Category}'
           ,'{volume.FreightKind}'
           ,{volume.Volume})
"
                        saveVolumeCommand.Execute()
                    End If
                End If
            Next
            OPConnection.CommitTrans()
            MsgBox("Successfully Saved!")
        Catch ex As Exception

            OPConnection.RollbackTrans()
            MsgBox("Error in Saving,Rolled Back Changes...")


        End Try

        OPConnection.Close()
    End Sub

    Private Sub Update(volume As Volume)
        Dim updateVolume As New ADODB.Command
        updateVolume.ActiveConnection = OPConnection
        updateVolume.CommandText = $"
UPDATE [opreports].[dbo].[budget]
   SET [volume] = {volume.Volume}

where [month] = {volume.Month} 
and [year] = {volume.Year}
and [category] = '{volume.Category}'
and [freight_kind] = '{volume.FreightKind}'

"
        updateVolume.Execute()
    End Sub

    Private Function Exists(volume As Volume) As Boolean
        Dim checkVolume As New ADODB.Command

        checkVolume.ActiveConnection = OPConnection
        checkVolume.CommandText = $"
SELECT [gkey]
      ,[month]
      ,[year]
      ,[category]
      ,[freight_kind]
      ,[volume]
  FROM [opreports].[dbo].[budget]

where [month] = {volume.Month} 
and [year] = {volume.Year}
and [category] = '{volume.Category}'
and [freight_kind] = '{volume.FreightKind}'

"

        Dim result As Boolean = Not checkVolume.Execute.EOF
        Return result
    End Function

    Public ReadOnly Property Year As Integer
    Public ReadOnly MonthlyVolume As List(Of Volume)
    Private OPConnection As ADODB.Connection

End Class
