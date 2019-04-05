Imports System.Data
Imports ADODB
Imports System.Linq
Imports Reports

Public Class Crane
    Implements ICrane

    Public Sub New(Crane As String, Registry As String, ByRef Connection As ADODB.Connection, Existing As Boolean)

        ' This call is required by the designer.
        Me.Registry = Registry
        Me.CraneName = Crane
        adoConnection = Connection

        InitializeContainerTypeRows()


        If Existing Then
            'Do Nothing 
        Else
            RetrieveMoves()
        End If



        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub InitializeContainerTypeRows()
        With Moves.Container
            Dim containerTypes As String() = {"DSCH", "LOAD", "SHFT", "SHOB"}
            Dim freightKinds As String() = {"FCL", "MTY"}
            For Each type As String In containerTypes
                For Each freight As String In freightKinds
                    If type <> "DSCH" Then
                        .AddContainerRow(container:=type,
                                move_kind:=type,
                                actual_ob:=Registry,
                                actual_ib:=Nothing,
                                freight_kind:=freight,
                                category:=Nothing,
                                cntsze20:=0,
                                cntsze40:=0,
                                cntsze45:=0)
                    End If

                    If type <> "LOAD" Then
                        .AddContainerRow(container:=type,
                                move_kind:=type,
                                actual_ob:=Nothing,
                                actual_ib:=Registry,
                                freight_kind:=freight,
                                category:=Nothing,
                                cntsze20:=0,
                                cntsze40:=0,
                                cntsze45:=0)
                    End If
                Next

            Next
            AddTranshipmentRow(Moves.Container, freightKinds)
        End With
    End Sub

    Private Sub AddTranshipmentRow(container As CraneMoves.ContainerDataTable, freightKinds() As String)
        With container
            For Each freight As String In freightKinds
                .AddContainerRow(container:="TRSHP",
                                move_kind:=Nothing,
                                actual_ob:=Registry,
                                actual_ib:=Nothing,
                                freight_kind:=freight,
                                category:="TRSHP",
                                cntsze20:=0,
                                cntsze40:=0,
                                cntsze45:=0)

                .AddContainerRow(container:="TRSHP",
                                move_kind:=Nothing,
                                actual_ob:=Nothing,
                                actual_ib:=Registry,
                                freight_kind:=freight,
                                category:=Nothing,
                                cntsze20:=0,
                                cntsze40:=0,
                                cntsze45:=0)
            Next
        End With
    End Sub

    Private adoConnection As ADODB.Connection
    Public ReadOnly Property CraneName As String Implements ICrane.CraneName
    Public ReadOnly Property Registry As String Implements ICrane.Registry
    Public Property FirstMove As Date Implements ICrane.FirstMove
    Public Property LastMove As Date Implements ICrane.LastMove
    Public Property Delays As New CraneDelays Implements ICrane.Delays
    Public Property Moves As New CraneMoves Implements ICrane.Moves

    Public ReadOnly Property GrossWorkingHours As Double Implements ICrane.GrossWorkingHours
        Get
            Dim breakdelays As Double = Delays.Break.Totalhours
            Dim span As TimeSpan = LastMove.Subtract(FirstMove)

            Return span.TotalHours - breakdelays

        End Get
    End Property

    Public ReadOnly Property GrossProductivity As Double Implements ICrane.GrossProductivity
        Get
            Return Moves.TotalMoves / GrossWorkingHours
        End Get
    End Property

    Public ReadOnly Property NetWorkingHours As Double Implements ICrane.NetWorkingHours
        Get
            Dim deductdelays As Double = Delays.Deductable.Totalhours
            Dim breakdelays As Double = Delays.Break.Totalhours
            Dim span As TimeSpan = LastMove.Subtract(FirstMove)

            Return span.TotalHours - deductdelays - breakdelays
        End Get
    End Property

    Public ReadOnly Property NetProductivity As Double Implements ICrane.NetProductivity
        Get
            Return Moves.TotalMoves / NetWorkingHours
        End Get
    End Property

    Private Sub RetrieveMoves()
        adoConnection.Open()
        FillInbound()
        FillOutbound()
        adoConnection.Close()

    End Sub

    Private Sub FillOutbound()
        Dim rsMoves As New ADODB.Recordset
        Dim dataAdapter As New OleDb.OleDbDataAdapter 'adodb doesnt have dataadpter, used oledb instead since it works with adodb.recordset
        Dim strOutbound As String = $"
Declare @Registry numeric(18,0)
Declare @GC numeric(8,0)

select @Registry = gkey
from argo_carrier_visit where id = '{Registry}'

Select @GC = gkey
from xps_che where short_name = '{CraneName}'

SELECT DISTINCT unit.gkey
	  ,mve.[move_kind]
	  ,[category]
	  ,[freight_kind]
      ,[short_name]
      ,[length_mm]
      ,[time_load] as 'time_move'
	  ,svnt.[id] as 'event'

  FROM [apex].[dbo].[inv_unit] unit
inner join
[inv_unit_fcy_visit] ufv on unit.gkey = ufv.unit_gkey
inner join
[inv_move_event] mve on ufv.gkey = mve.ufv_gkey
inner join
[xps_che] che on mve.che_qc = che.gkey
inner join
[inv_unit_equip] ueq on ueq.unit_gkey = unit.gkey
inner join
[ref_equipment] eqp on ueq.eq_gkey = eqp.gkey
left join
( SELECT [gkey]
      ,[event_type_gkey]
      ,[applied_to_class]
      ,[applied_to_gkey]
      ,[applied_to_natural_key]
  FROM [apex].[dbo].[srv_event] where event_type_gkey = 141 ) evnt on evnt.[applied_to_gkey] = unit.gkey
left join 
[srv_event_types] svnt on evnt.event_type_gkey = svnt.gkey



where che_qc = @GC and ufv.actual_ob_cv = @Registry "

        rsMoves.Open(strOutbound, adoConnection, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, CommandTypeEnum.adCmdText)
        dataAdapter.Fill(Moves.Tables("Outbound"), rsMoves)
        rsMoves.Close()


        CountOutboundMoves(Moves.Outbound)
    End Sub

    Private Sub CountOutboundMoves(outbound As CraneMoves.OutboundDataTable)
        Dim freightkinds As String() = {"FCL", "MTY"}

        For Each freight In freightkinds

            Dim count20 As Object = CountMoves(outbound, freight, 20)
            Dim count40 As Object = CountMoves(outbound, freight, 40)
            Dim count45 As Object = CountMoves(outbound, freight, 45)


            With Moves.Container.AsEnumerable.Where(Function(row) row("freight_kind").ToString = freight And
                                                        row("container").ToString = "LOAD").FirstOrDefault
                If (count20 + count40 + count45) > 0 Then
                    .Item("cntsze20") = count20
                    .Item("cntsze40") = count40
                    .Item("cntsze45") = count45
                End If
            End With
        Next
    End Sub

    Private Function CountMoves(outbound As DataTable, freight As String, v As Integer) As Object
        Return (From units In outbound.AsEnumerable
                Where units("freight_kind") = freight And
                                     Math.Round(units("length_mm") / 304.8, 0) = v
                Select units).Count
    End Function

    Private Sub FillInbound()
        Dim rsMoves As New ADODB.Recordset
        Dim dataAdapter As New OleDb.OleDbDataAdapter 'adodb doesnt have dataadpter, used oledb instead since it works with adodb.recordset

        Dim strInbound As String = $"
Declare @Registry numeric(18,0)
Declare @GC numeric(8,0)

select @Registry = gkey
from argo_carrier_visit where id = '{Registry}'

Select @GC = gkey
from xps_che where short_name = '{CraneName}'

SELECT DISTINCT unit.gkey
	  ,mve.[move_kind]
	  ,[category]
	  ,[freight_kind]
      ,[short_name]
      ,[length_mm]
      ,[time_in] as 'time_move'
	  ,svnt.[id] as 'event'


  FROM [apex].[dbo].[inv_unit] unit
inner join
[inv_unit_fcy_visit] ufv on unit.gkey = ufv.unit_gkey
inner join
[inv_move_event] mve on ufv.gkey = mve.ufv_gkey
inner join
[xps_che] che on mve.che_qc = che.gkey
inner join
[inv_unit_equip] ueq on ueq.unit_gkey = unit.gkey
inner join
[ref_equipment] eqp on ueq.eq_gkey = eqp.gkey 
left join
( SELECT [gkey]
      ,[event_type_gkey]
      ,[applied_to_class]
      ,[applied_to_gkey]
      ,[applied_to_natural_key]
  FROM [apex].[dbo].[srv_event] where event_type_gkey = 141 ) evnt on evnt.[applied_to_gkey] = unit.gkey
left join 
[srv_event_types] svnt on evnt.event_type_gkey = svnt.gkey


where che_qc = @GC and ufv.actual_ib_cv = @Registry"

        rsMoves.Open(strInbound, adoConnection, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, CommandTypeEnum.adCmdText)
        dataAdapter.Fill(Moves.Tables("Inbound"), rsMoves)
        rsMoves.Close()

        CountInboundMoves(Moves.Inbound)
    End Sub

    Private Sub CountInboundMoves(inbound As CraneMoves.InboundDataTable)
        Dim freightkinds As String() = {"FCL", "MTY"}

        For Each freight In freightkinds

            Dim count20 As Object = CountMoves(inbound, freight, 20)
            Dim count40 As Object = CountMoves(inbound, freight, 40)
            Dim count45 As Object = CountMoves(inbound, freight, 45)

            With Moves.Container.AsEnumerable.Where(Function(row) row("freight_kind") = freight And
                                                        row("container") = "DSCH").FirstOrDefault
                If (count20 + count40 + count45) > 0 Then
                    .Item("cntsze20") = count20
                    .Item("cntsze40") = count40
                    .Item("cntsze45") = count45
                End If
            End With
        Next
    End Sub
    Public Function TotalInboundMoves(datatable As CraneMoves.InboundDataTable) As Double
        Return CountMoves(datatable, "FCL", 20) + CountMoves(datatable, "FCL", 40) + CountMoves(datatable, "FCL", 45) +
            CountMoves(datatable, "MTY", 20) + CountMoves(datatable, "MTY", 40) + CountMoves(datatable, "MTY", 45)
    End Function
    Public Function TotalOutboundMoves(datatable As CraneMoves.OutboundDataTable) As Double
        Return CountMoves(datatable, "FCL", 20) + CountMoves(datatable, "FCL", 40) + CountMoves(datatable, "FCL", 45) +
            CountMoves(datatable, "MTY", 20) + CountMoves(datatable, "MTY", 40) + CountMoves(datatable, "MTY", 45)
    End Function
End Class
