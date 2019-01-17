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

        If Existing Then
            'Do Nothing 
        Else
            RetrieveMoves()
        End If


        ' Add any initialization after the InitializeComponent() call.

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
        Dim strInbound As String = "
Declare @Registry numeric(18,0)
Declare @GC numeric(8,0)

select @Registry = gkey
from argo_carrier_visit where id = '" & Registry & "'

Select @GC = gkey
from xps_che where short_name = '" & CraneName & "'

SELECT [mve_gkey]
      ,[move_kind]
	  ,[category]
	  ,[freight_kind]
      ,[short_name]
      ,[nominal_length]

  FROM [apex].[dbo].[inv_move_event] mve
inner join
[xps_che] che on mve.che_qc = che.gkey
inner join
[inv_unit_fcy_visit] ufv on mve.ufv_gkey = ufv.gkey
inner join
[inv_unit] unit on ufv.unit_gkey = unit.gkey
inner join 
[inv_unit_equip] ueq on ueq.unit_gkey = unit.gkey
inner join
[ref_equipment] eqp on ueq.eq_gkey = eqp.gkey
inner join
[ref_equip_type] eqt on eqp.eqtyp_gkey = eqt.gkey

where che_qc = @GC and ufv.actual_ib_cv = @Registry and category <> 'THRGH'"

        Dim strOutbound As String = "
Declare @Registry numeric(18,0)
Declare @GC numeric(8,0)

select @Registry = gkey
from argo_carrier_visit where id = '" & Registry & "'

Select @GC = gkey
from xps_che where short_name = '" & CraneName & "'

SELECT [mve_gkey]
      ,[move_kind]
	  ,[category]
	  ,[freight_kind]
      ,[short_name]
      ,[nominal_length]

  FROM [apex].[dbo].[inv_move_event] mve
inner join
[xps_che] che on mve.che_qc = che.gkey
inner join
[inv_unit_fcy_visit] ufv on mve.ufv_gkey = ufv.gkey
inner join
[inv_unit] unit on ufv.unit_gkey = unit.gkey
inner join 
[inv_unit_equip] ueq on ueq.unit_gkey = unit.gkey
inner join
[ref_equipment] eqp on ueq.eq_gkey = eqp.gkey
inner join
[ref_equip_type] eqt on eqp.eqtyp_gkey = eqt.gkey

where che_qc = @GC and ufv.actual_ob_cv = @Registry and category <> 'THRGH'"


        'add Outbound moves
        adoConnection.Open()
        FillInbound(strInbound)
        FillOutbound(strOutbound)
        adoConnection.Close()

    End Sub

    Private Sub FillOutbound(strOutbound As String)
        Dim rsMoves As New ADODB.Recordset
        Dim dataAdapter As New OleDb.OleDbDataAdapter 'adodb doesnt have dataadpter, used oledb instead since it works with adodb.recordset
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

            If (count20 + count40 + count45) > 0 Then
                Moves.Container.Rows.Add("LOAD",
                                     Registry,
                                     Nothing,
                                     freight,
                                     Nothing,
                                     count20,
                                     count40,
                                     count45)
            End If
        Next
    End Sub

    Private Function CountMoves(outbound As DataTable, freight As String, v As Integer) As Object
        Return (From units In outbound.AsEnumerable
                Where units("freight_kind") = freight And
                                     units("nominal_length") = $"NOM{v}"
                Select units).Count
    End Function

    Private Sub FillInbound(strInbound As String)
        Dim rsMoves As New ADODB.Recordset
        Dim dataAdapter As New OleDb.OleDbDataAdapter 'adodb doesnt have dataadpter, used oledb instead since it works with adodb.recordset
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

            If (count20 + count40 + count45) > 0 Then
                Moves.Container.Rows.Add("DSCH",
                                     Nothing,
                                     Registry,
                                     freight,
                                     Nothing,
                                     count20,
                                     count40,
                                     count45)
            End If
        Next
    End Sub
End Class
