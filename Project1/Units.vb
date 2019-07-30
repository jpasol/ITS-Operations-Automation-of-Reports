Imports System.Data
Imports ADODB
Imports Reports

Public Class Units
    Implements IReports.IUnits

    Sub New(Registry As String)

        ' This call is required by the designer..
        strRegistry = Registry
        Dim connections As New Reports.Connections
        untConnection = connections.N4Connection
        dbConnection = connections.OPConnection
        If Exists() Then
            'Do nothing
        Else
            Retrieve(Registry)
        End If


        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Function Exists() As Boolean
        dbConnection.Open()
        Dim unitsChecker As New ADODB.Command
        unitsChecker.ActiveConnection = dbConnection
        unitsChecker.CommandText = $"
SELECT case 

when exists( 
select registry from vmr_units where [registry] = '{strRegistry}')
then 
cast(1 as bit)
else 
cast(0 as bit) 
end
"
        Dim result As Boolean = unitsChecker.Execute.Fields(0).Value
        dbConnection.Close()
        Return result
    End Function

    Private strRegistry As String
    Private dsContainers As DataSet
    Private untConnection As Connection
    Private dbConnection As Connection

    Public Enum UnitDetails
        ContNum
        NomLength
        IsoGrp
        FreightKnd
        LineOP
        ReqPowers
        Hazard
        IMDG
        IsoCode
        ctrTyp
    End Enum
    Public ReadOnly Property Registry As String Implements IReports.IUnits.Registry
        Get
            Registry = strRegistry
        End Get
    End Property

    Public ReadOnly Property Connection As Connection Implements IReports.IUnits.Connection
        Get
            Connection = untConnection
        End Get
    End Property

    Public ReadOnly Property Containers As DataSet Implements IReports.IUnits.Containers
        Get
            Containers = dsContainers
        End Get
    End Property

    Private Function getMilTime(strLDate As String) As String
        Dim dteDate As DateTime

        dteDate = Convert.ToDateTime(strLDate)
        getMilTime = dteDate.ToString("HHmm\H MM/dd/yyyy")
    End Function

    Private Sub tagCtrTyp(ByRef dtContr As DataTable)
        Dim colCtrTyp As New DataColumn
        colCtrTyp.ColumnName = "ctrTyp"

        dtContr.Columns.Add(colCtrTyp)
        For Each row As DataRow In dtContr.Rows
            If row("rfr_type") <> "NON_RFR" Then
                row("ctrTyp") = "Rfr"
            Else
                Select Case row("iso_group").ToString.Substring(0, 1)
                    Case "P"
                        row("ctrTyp") = "FRk"
                    Case "U"
                        row("ctrTyp") = "Opn"
                    Case "T"
                        row("ctrTyp") = "Tnk"
                    Case Else
                        row("ctrTyp") = "Dry"
                End Select
            End If
        Next
    End Sub

    Public Sub Retrieve(Vessel As String) Implements IReports.IUnits.Retrieve
        Dim strSQl(1) As String '0 = Inbound | 1 = Outbound
        Dim datAdapt As New OleDb.OleDbDataAdapter
        Dim rsUnits As New ADODB.Recordset
        Dim ibTable As New DataTable
        Dim obTable As New DataTable

        dsContainers = New DataSet
        dsContainers.Tables.Add(ibTable)
        dsContainers.Tables.Add(obTable)

        'Get I/B Containers
        strSQl(0) = "Declare @Registry numeric(18,0)

select @Registry = gkey
from argo_carrier_visit where id = '" & Vessel & "'

Select unit.[id]
,[nominal_length]
,reqt.[iso_group]
,[freight_kind]
,lin.[id] as 'line_op'
,[requires_power]
,[hazardous]
,[imdg_types]
,reqt.[id] as 'iso_code'
,[time_in] as 'time_move'
,reqt.[rfr_type]
,ufv.transit_state
,unit.[remark]

from 
[inv_unit] unit
inner join
[inv_unit_equip] ueqp
on unit.[gkey] = ueqp.[unit_gkey]
inner join
[inv_goods] gds
on goods = gds.[gkey]
inner join
[ref_bizunit_scoped] lin
on line_op = lin.gkey
inner join
[ref_equipment] reqp
on ueqp.eq_gkey = reqp.gkey
inner join 
[ref_equip_type] reqt
on reqp.eqtyp_gkey = reqt.gkey
inner join 
[inv_unit_fcy_visit] ufv 
on unit.gkey = ufv.unit_gkey


where [actual_ib_cv] = @Registry and pod1_gkey = 1"

        'Get O/B Containers
        strSQl(1) = "Declare @Registry numeric(18,0)

select @Registry = gkey
from argo_carrier_visit where id = '" & Vessel & "'

Select unit.[id]
,[nominal_length]
,reqt.[iso_group]
,[freight_kind]
,lin.[id] as 'line_op'
,[requires_power]
,[hazardous]
,[imdg_types]
,reqt.[id] as 'iso_code'
,[time_load] as 'time_move'
,reqt.[rfr_type]
,ufv.transit_state
,unit.[remark]

from 
[inv_unit] unit
inner join
[inv_unit_equip] ueqp
on unit.[gkey] = ueqp.[unit_gkey]
inner join
[inv_goods] gds
on goods = gds.[gkey]
inner join
[ref_bizunit_scoped] lin
on line_op = lin.gkey
inner join
[ref_equipment] reqp
on ueqp.eq_gkey = reqp.gkey
inner join 
[ref_equip_type] reqt
on reqp.eqtyp_gkey = reqt.gkey
inner join 
[inv_unit_fcy_visit] ufv 
on unit.gkey = ufv.unit_gkey


where [actual_ob_cv] = @Registry and category <> 'THRGH'" 'and ufv.transit_state like '%DEPARTED%'"

        For count As Integer = 0 To 1
            untConnection.Open()

            rsUnits.Open(strSQl(count), untConnection)
            datAdapt.Fill(dsContainers.Tables(count), rsUnits)
            tagCtrTyp(dsContainers.Tables(count))
            rsUnits.Close()

            untConnection.Close()
        Next


    End Sub

    Public Function Count(Containers As DataTable, Condition As String) As Double Implements IReports.IUnits.Count
        Dim dvContainers As New DataView
        dvContainers.Table = Containers
        dvContainers.RowFilter = Condition

        Count = dvContainers.Count
    End Function
End Class
