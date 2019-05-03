Friend Class ReeferData
    Inherits List(Of Reefer)

    Public Structure Reefer
        Public Sub New(Gkey As Integer, ContainerNumber As String,
                       Consignee As String, ISO As String, Length As Double, Category As String,
                       TimeIn As DateTime?, Timeout As DateTime?, ActualIB As String, ActualOB As String,
                       VisitState As String, TransitState As String, LastPositionName As String,
                       LineOperator As String, PortOfLaden As String, PortOfDestination As String,
                       FreightKind As String)
            Me.Gkey = Gkey
            Me.ContainerNumber = ContainerNumber
            Me.Consignee = Consignee
            Me.ISO = ISO
            Me.Length = Length
            Me.Category = Category
            Me.dateIn = TimeIn.ToString
            Me.dateOut = Timeout.ToString
            Me.ActualIB = ActualIB
            Me.ActualOB = ActualOB
            Me.VisitState = VisitState
            Me.TransitState = TransitState
            Me.LastPositionName = LastPositionName
            Me.LineOperator = LineOperator
            Me.PortOfLaden = PortOfLaden
            Me.PortOfDestination = PortOfDestination
            Me.FreightKind = FreightKind
        End Sub
        Private dateOut As String
        Private dateIn As String

        Public ReadOnly Gkey As String
        Public ReadOnly ContainerNumber As String
        Public ReadOnly Consignee As String
        Public ReadOnly ISO As String
        Public ReadOnly Length As Double
        Public ReadOnly Category As String
        Public ReadOnly ActualIB As String
        Public ReadOnly ActualOB As String
        Public ReadOnly VisitState As String
        Public ReadOnly TransitState As String
        Public ReadOnly LastPositionName As String
        Public ReadOnly LineOperator As String
        Public ReadOnly PortOfLaden As String
        Public ReadOnly PortOfDestination As String
        Public ReadOnly FreightKind As String

        Public ReadOnly Property TimeIn As String 'special case
            Get
                Try
                    Return $"'{CDate(dateIn)}'"
                Catch ex As Exception
                    Return "null"
                End Try
            End Get
        End Property
        Public ReadOnly Property TimeOut As String 'special case
            Get
                Try
                    Return $"'{CDate(dateOut)}'"
                Catch ex As Exception
                    Return "null"
                End Try
            End Get
        End Property
    End Structure

    Private now As Date

    Public Sub New(now As Date)
        Me.now = now

        Dim connections As New Reports.Connections
        N4Connection = connections.N4Connection
        OPConnection = connections.OPConnection

        For Each reeferData As DataRow In RetrievedReeferDatafromN4(now).Rows
            Dim tempReefer As New Reefer(Gkey:=reeferData("gkey"),
                                         ContainerNumber:=reeferData("UnitNbr").ToString,
                                         Consignee:=reeferData("consignee").ToString,
                                         ISO:=reeferData("iso").ToString,
                                         Length:=reeferData("length_mm"),
                                         Category:=reeferData("category").ToString,
                                         TimeIn:=IIf(IsDBNull(reeferData("time_in")), Nothing, reeferData("time_in")),
                                         Timeout:=IIf(IsDBNull(reeferData("time_out")), Nothing, reeferData("time_out")),
                                         ActualIB:=reeferData("actual_ib").ToString,
                                         ActualOB:=reeferData("actual_ob").ToString,
                                         VisitState:=reeferData("visit_state").ToString,
                                         TransitState:=reeferData("transit_state").ToString,
                                         LastPositionName:=reeferData("last_pos_name").ToString,
                                         LineOperator:=reeferData("line_op").ToString,
                                         PortOfLaden:=reeferData("pol").ToString,
                                         PortOfDestination:=reeferData("pod1").ToString,
                                         FreightKind:=reeferData("freight_kind").ToString)

            Me.Add(tempReefer)
        Next

    End Sub

    Private Function RetrievedReeferDatafromN4(now As Date) As DataTable
        Dim thisMonth As Integer = now.Month
        Dim year As Integer = now.Year

        Dim retrieveMonthlyReefers As New ADODB.Command
        N4Connection.Open()
        retrieveMonthlyReefers.ActiveConnection = N4Connection
        retrieveMonthlyReefers.CommandText = $"select unit.[gkey],
	   unit.[id] 'UnitNbr' , 
	   cons.[name] 'consignee',
		eqt.[id] 'iso',
		eqt.[length_mm] 'length_mm',
			[category],
			[time_in],
			[time_out],
	   cvib.[id] 'actual_ib',
	   cvob.[id] 'actual_ob',
		ufv.[visit_state],
			[transit_state],
			[last_pos_name],
	   line.[id] 'line_op',
		pol.[id] 'pol',
	   pod1.[id] 'pod1',
			[freight_kind]

from [inv_unit] unit
inner join [inv_unit_equip] ueq on unit.gkey = ueq.unit_gkey
inner join [ref_equipment] eqp on ueq.eq_gkey = eqp.gkey
inner join [ref_equip_type] eqt on eqp.eqtyp_gkey = eqt.gkey
inner join [inv_unit_fcy_visit] ufv on unit.gkey = ufv.unit_gkey
inner join [argo_carrier_visit] cvib on ufv.actual_ib_cv = cvib.gkey
inner join [argo_carrier_visit] cvob on ufv.actual_ob_cv = cvob.gkey
inner join [ref_bizunit_scoped] line on unit.line_op = line.gkey
inner join [ref_routing_point] pol on unit.pol_gkey = pol.gkey
inner join [ref_routing_point] pod1 on unit.pod1_gkey = pod1.gkey
inner join [inv_goods] gds on unit.goods = gds.gkey

left join [ref_bizunit_scoped] cons on gds.consignee_bzu = cons.gkey

where freight_kind = 'FCL' 
and ufv.time_in > cast('{thisMonth}/1/{year}' as datetime)  
and category <> 'TRSHP'
and category <> 'THRGH'
and transit_state not like '%INBOUND%'
and requires_power = 1

order by unit.id

		
"
        Dim tempAdapter As New OleDb.OleDbDataAdapter
        Dim tempDatatable As New DataTable
        tempAdapter.Fill(tempDatatable, retrieveMonthlyReefers.Execute)
        Return tempDatatable
    End Function

    Private N4Connection As ADODB.Connection
    Private OPConnection As ADODB.Connection
End Class
