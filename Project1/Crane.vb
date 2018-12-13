Imports System.Data
Imports ADODB

Public Class Crane
    Implements ICrane

    Public Sub New(Crane As String, Registry As String, ByRef Connection As ADODB.Connection)

        ' This call is required by the designer.
        Me.Registry = Registry
        Me.CraneName = Crane
        adoConnection = Connection

        RetrieveMoves()

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

            Return Format(span.TotalHours - breakdelays, "0.00")

        End Get
    End Property

    Public ReadOnly Property GrossProductivity As Double Implements ICrane.GrossProductivity
        Get
            Return Format(Moves.TotalMoves / GrossWorkingHours, "0.00")
        End Get
    End Property

    Public ReadOnly Property NetWorkingHours As Double Implements ICrane.NetWorkingHours
        Get
            Dim deductdelays As Double = Delays.Deductable.Totalhours
            Dim breakdelays As Double = Delays.Break.Totalhours
            Dim span As TimeSpan = LastMove.Subtract(FirstMove)

            Return Format(span.TotalHours - deductdelays - breakdelays, "0.00")
        End Get
    End Property

    Public ReadOnly Property NetProductivity As Double Implements ICrane.NetProductivity
        Get
            Return Format(Moves.TotalMoves / NetWorkingHours, "0.00")
        End Get
    End Property


    Private Sub RetrieveMoves()
        Dim rsMoves As New ADODB.Recordset
        Dim dataAdapter As New OleDb.OleDbDataAdapter 'adodb doesnt have dataadpter, used oledb instead since it works with adodb.recordset
        Dim strInbound As String
        Dim strOutbound As String

        Moves = New CraneMoves

        strInbound = "
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

        strOutbound = "
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

        'add Inbound moves
        rsMoves.Open(strInbound, adoConnection, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, CommandTypeEnum.adCmdText)
        dataAdapter.Fill(Moves.Tables("Inbound"), rsMoves)
        rsMoves.Close()

        'add Outbound moves
        rsMoves.Open(strOutbound, adoConnection, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, CommandTypeEnum.adCmdText)
        dataAdapter.Fill(Moves.Tables("Outbound"), rsMoves)
        rsMoves.Close()


    End Sub
End Class
