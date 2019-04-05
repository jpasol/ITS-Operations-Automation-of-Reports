Imports System.Data
Imports ADODB
Imports Reports
Public Class Vessel
    Implements IReports.IVessel

    Sub New(Registry As String, Optional WithoutUnits As Boolean = False)

        Dim connections As New Connections
        OPConnection = connections.OPConnection
        N4Connection = connections.N4Connection

        Retrieve(Registry)
        If WithoutUnits = False Then
            vslUnits = New Units(Registry)
        End If

        strRegistry = Registry
        On Error Resume Next

        Me.Name = dtVessel.Rows(0)(Vessel.Name).ToString
        Me.Registry = dtVessel.Rows(0)(Vessel.Registry).ToString
        Me.InboundVoyage = dtVessel.Rows(0)(Vessel.IBVoyage).ToString
        Me.OutboundVoyage = dtVessel.Rows(0)(Vessel.OBVoyage).ToString
        Me.BerthWindow = dtVessel.Rows(0)(Vessel.Berth).ToString
        Me.ATA = dtVessel.Rows(0)(Vessel.ATA).ToString
        Me.ATD = dtVessel.Rows(0)(Vessel.ATD).ToString
        Me.ETA = dtVessel.Rows(0)(Vessel.ETA).ToString
        Me.Owner = dtVessel.Rows(0)(Vessel.LineOP)
        Me.Units = vslUnits
        Me.Connection = N4Connection
        Me.LastContainerDischarged = dtVessel.Rows(0)(Vessel.LastContrDisch).ToString()
        Me.FirstContainerDischarged = GetFirstContainerDischarge()
        Me.FirstContainerLoaded = GetFirstContainerLoaded()
        Me.LastContainerLoaded = GetLastContainerLoaded()
        Me.Phase = dtVessel.Rows(0)(Vessel.Phase).ToString()
        Me.LaborOnBoard = dtVessel.Rows(0)(Vessel.LaborOnBoard).ToString()
        Me.LaborOffBoard = dtVessel.Rows(0)(Vessel.LaborOffBoard).ToString()
        Me.Service = dtVessel.Rows(0)(Vessel.Service).ToString()
        Me.LOA = dtVessel.Rows(0)(Vessel.LOA).ToString()

    End Sub

    Private Function GetLastContainerLoaded() As Date
        Dim descMove As New DataView
        With descMove
            .Table = vslUnits.Containers.Tables(1)
            .Sort = "time_move desc"

            Return Date.Parse(descMove.Item(0)("time_move").ToString)
        End With
    End Function

    Private Function GetFirstContainerLoaded() As Date
        Dim ascMove As New DataView
        With ascMove
            .Table = vslUnits.Containers.Tables(1)
            .Sort = "time_move asc"

            Return Date.Parse(.Item(0)("time_move").ToString)
        End With
    End Function

    Private Function GetFirstContainerDischarge() As Date
        Dim ascMove As New DataView
        With ascMove
            .Table = vslUnits.Containers.Tables(0)
            .Sort = "time_move asc"

            Return Date.Parse(.Item(0)("time_move").ToString)
        End With
    End Function
    Private OPConnection As ADODB.Connection
    Private N4Connection As ADODB.Connection
    Private strRegistry As String
    Private dtVessel As DataTable
    Private dtContainers As DataTable
    Private vslUnits As Units
    Private dtCMU As DataTable
    Enum Vessel
        Name
        LineOP
        IBVoyage
        OBVoyage
        Registry
        Berth
        ATA
        ATD
        ETA
        StartWork
        EndWork
        LastContrDisch
        Phase
        LaborOnBoard
        LaborOffBoard
        Service
        LOA
    End Enum
    Public ReadOnly Property Name As String Implements IReports.IVessel.Name
    Public ReadOnly Property Registry As String Implements IReports.IVessel.Registry
    Public ReadOnly Property InboundVoyage As String Implements IReports.IVessel.InboundVoyage
    Public ReadOnly Property OutboundVoyage As String Implements IReports.IVessel.OutboundVoyage
    Public ReadOnly Property BerthWindow As String Implements IReports.IVessel.BerthWindow
    Public ReadOnly Property ATA As Date Implements IReports.IVessel.ATA
    Public ReadOnly Property ATD As Date Implements IReports.IVessel.ATD
    Public ReadOnly Property ETA As Date Implements IReports.IVessel.ETA
    Public ReadOnly Property ETD As Date Implements IReports.IVessel.ETD
    Public ReadOnly Property StartWork As Date Implements IReports.IVessel.StartWork
    Public ReadOnly Property EndWork As Date Implements IReports.IVessel.EndWork
    Public ReadOnly Property FirstContainerDischarged As Date? Implements IReports.IVessel.FirstContainerDischarged
    Public ReadOnly Property LastContainerDischarged As Date? Implements IReports.IVessel.LastContainerDischarged
    Public ReadOnly Property FirstContainerLoaded As Date? Implements IReports.IVessel.FirstContainerLoaded
    Public ReadOnly Property LastContainerLoaded As Date? Implements IReports.IVessel.LastContainerLoaded
    Public ReadOnly Property LineOperators() As String Implements IReports.IVessel.LineOperator
    Public ReadOnly Property Owner As String Implements IReports.IVessel.Owner
    Public ReadOnly Property Units As Units Implements IReports.IVessel.Units
    Public ReadOnly Property Connection As Connection Implements IReports.IVessel.Connection
    Public ReadOnly Property Phase As String Implements IVessel.Phase
    Public ReadOnly Property LaborOnBoard As Date Implements IVessel.LaborOnBoard
    Public ReadOnly Property LaborOffBoard As Date? Implements IVessel.LaborOffBoard
    Public ReadOnly Property Service As String Implements IVessel.Service

    Public ReadOnly Property SLGangRequest As Date Implements IVessel.SLGangRequest
        Get
            Dim tempETA As Date = ETA
            tempETA -= New TimeSpan(0, 30, 0)
            If tempETA.Hour = 12 Or tempETA.Hour = 0 Then
                tempETA -= New TimeSpan(1, 0, 0)
            End If
            Return tempETA
        End Get
    End Property

    Public ReadOnly Property OvertimeRequired As Date Implements IVessel.OvertimeRequired
        Get
            Return SLGangRequest
        End Get
    End Property
    Public ReadOnly Property LOA As Integer Implements IVessel.LOA

    Public Sub Retrieve(Registry As String) Implements IReports.IVessel.Retrieve
        N4Connection.Open()
        Dim rsContainers As New ADODB.Command
        Dim DataAdapter As New OleDb.OleDbDataAdapter
        Dim strSQLVessel As String

        dtVessel = New DataTable

        strSQLVessel =
        $"Declare @Registry numeric(18,0)

        select @Registry = gkey
        from [argo_carrier_visit] where id = '{Registry}'

        select 'MV '+ vsl.name as 'Vessel Name'
        ,biz.[id] as 'Line Operator'
        ,ib_vyg 'I/B Voyage Number' 
        ,ob_vyg 'O/B Voyage Number'
        ,acv.id as 'Registry Number'
        ,flex_string02 as 'Pier Berth (NCT)'
        ,ata as 'Actual Time of Arrival (ATA)'
        ,atd as 'Actual Time of Departure (ATD)'
		,eta as 'Estimated Time of Arrival'
        ,[start_work] as 'Time Operation Commenced'
        ,[end_work] as 'Time of Completion'
        ,[time_discharge_complete] as 'Time of Last Contr. Discharged'
		,[phase]
		,[labor_on_board]
		,[labor_off_board]
		,svce.[id] AS 'Service'
		,cast(round([loa_cm] / 100.0,0) as integer) as 'LOA' 
		

        FROM [apex].[dbo].[vsl_vessel_visit_details] vvd
        inner join 
        [vsl_vessels] vsl
        on vsl.gkey = vvd.vessel_gkey 
        inner join
        [argo_carrier_visit] acv
        on cvcvd_gkey = vvd_gkey
        inner join
        [argo_visit_details] avd
        on cvcvd_gkey = avd.gkey
        inner join
        [ref_bizunit_scoped] biz
        on owner_gkey = biz.gkey
		inner join
		[ref_carrier_service] svce
		on avd.service = svce.gkey
		inner join
		[vsl_vessel_classes] vcl
		on vsl.vesclass_gkey = vcl.gkey

        where acv.gkey = @Registry"

        rsContainers.CommandText = strSQLVessel
        rsContainers.ActiveConnection = N4Connection

        DataAdapter.Fill(dtVessel, rsContainers.Execute)
        N4Connection.Close()
    End Sub

    Public Function TEU(Optional Condition As String = "") As Double Implements IReports.IVessel.TEU
        Dim dvContainers As New DataView()
    End Function

    Public Function Boxes(Optional Condition As String = "") As Long Implements IReports.IVessel.Boxes
        Throw New NotImplementedException()
    End Function
End Class
