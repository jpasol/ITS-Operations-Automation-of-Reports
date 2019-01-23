Imports WindowsApp1

Public Class GateTransaction
    Implements IGateTransaction

    Public Sub New(containerNumber As String, nomContainerSize As String, transactionType As String, startDate As String)
        Me.ContainerNumber = containerNumber
        Me.nomContainerSize = nomContainerSize
        Me.TransactionType = transactionType
        Me.StartDate = startDate
    End Sub

    Private nomContainerSize As String

    Public ReadOnly Property ContainerNumber As String Implements IGateTransaction.ContainerNumber
    Public ReadOnly Property TransactionType As String Implements IGateTransaction.TransactionType
    Public ReadOnly Property StartDate As Date Implements IGateTransaction.StartDate
    Public ReadOnly Property ContainerSize As String Implements IGateTransaction.ContainerSize
        Get
            Return nomContainerSize.Substring(3)
        End Get
    End Property

    Public ReadOnly Property TEU As Double Implements IGateTransaction.TEU
        Get
            Return Format(CDbl(ContainerSize / 20), "0.0")
        End Get
    End Property
End Class
