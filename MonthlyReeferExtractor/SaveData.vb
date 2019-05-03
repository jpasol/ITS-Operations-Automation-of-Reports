Friend Class SaveData
    Private reefer As ReeferData.reefer

    Public Sub New(reefer As ReeferData.reefer)
        Me.reefer = reefer

        Dim connections As New Reports.Connections
        OPConnection = connections.OPConnection

        If Exists() Then
            Update()
        Else
            Insert()

        End If
    End Sub
    Private Function Exists() As Boolean
        Dim checkReefer As New ADODB.Command
        OPConnection.Open()
        checkReefer.ActiveConnection = OPConnection
        checkReefer.CommandText = $"
SELECT [gkey]
      ,[equipment_id]
      ,[consignee]
      ,[equipment_type]
      ,[length_mm]
      ,[category]
      ,[time_in]
      ,[time_out]
      ,[actual_ib_cv_id]
      ,[actual_ob_cv_id]
      ,[visit_state]
      ,[transit_state]
      ,[last_pos_name]
      ,[line_op_id]
      ,[pol_id]
      ,[pod1_id]
      ,[freight_kind]
      ,[extract_date]
  FROM [opreports].[dbo].[reefer]

where gkey = {reefer.Gkey}
"

        If checkReefer.Execute.EOF Then
            OPConnection.Close()
            Return False 'no results

        Else
            OPConnection.Close()
            Return True 'results
        End If

    End Function

    Private Sub Update()
        Dim updateReefer As New ADODB.Command
        OPConnection.Open()
        updateReefer.ActiveConnection = OPConnection
        updateReefer.CommandText = $"
UPDATE [opreports].[dbo].[reefer] 
   SET [gkey] = {reefer.Gkey}
      ,[equipment_id] = '{reefer.ContainerNumber}'
      ,[consignee] = '{Replace(reefer.Consignee, "'", "''")}'
      ,[equipment_type] = '{reefer.ISO}'
      ,[length_mm] = {reefer.Length}
      ,[category] = '{reefer.Category}'
      ,[time_in] = {reefer.TimeIn}
      ,[time_out] = {reefer.TimeOut}
      ,[actual_ib_cv_id] = '{reefer.ActualIB}'
      ,[actual_ob_cv_id] = '{reefer.ActualOB}'
      ,[visit_state] = '{reefer.VisitState}'
      ,[transit_state] = '{reefer.TransitState}'
      ,[last_pos_name] = '{reefer.LastPositionName}'
      ,[line_op_id] = '{reefer.LineOperator}'
      ,[pol_id] = '{reefer.PortOfLaden}'
      ,[pod1_id] = '{reefer.PortOfDestination}'
      ,[freight_kind] = '{reefer.FreightKind}'
      ,[extract_date] = '{Date.Now}'

where gkey = {reefer.Gkey}


"
        updateReefer.Execute()
        Remarks = "Update"
        OPConnection.Close()
    End Sub

    Private Sub Insert()
        Dim insertReefer As New ADODB.Command
        OPConnection.Open()
        insertReefer.ActiveConnection = OPConnection
        insertReefer.CommandText = $"
INSERT INTO [opreports].[dbo].[reefer]
           ([gkey]
           ,[equipment_id]
           ,[consignee]
           ,[equipment_type]
           ,[length_mm]
           ,[category]
           ,[time_in]
           ,[time_out]
           ,[actual_ib_cv_id]
           ,[actual_ob_cv_id]
           ,[visit_state]
           ,[transit_state]
           ,[last_pos_name]
           ,[line_op_id]
           ,[pol_id]
           ,[pod1_id]
           ,[freight_kind]
           ,[extract_date])
     VALUES
           ({reefer.Gkey}
           ,'{reefer.ContainerNumber}'
           ,'{Replace(reefer.Consignee, "'", "''")}'
           ,'{reefer.ISO}'
           ,{reefer.Length}
           ,'{reefer.Category}'
           ,{reefer.TimeIn}
           ,{reefer.TimeOut}
           ,'{reefer.ActualIB}'
           ,'{reefer.ActualOB}'
           ,'{reefer.VisitState}'
           ,'{reefer.TransitState}'
           ,'{reefer.LastPositionName}'
           ,'{reefer.LineOperator}'
           ,'{reefer.PortOfLaden}'
           ,'{reefer.PortOfDestination}'
           ,'{reefer.FreightKind}'
           ,'{Date.Now}'
           )
"
        insertReefer.Execute()
        Remarks = "Added"
        OPConnection.Close()
    End Sub
    Public Property Remarks As String
    Private Property OPConnection As ADODB.Connection
End Class
