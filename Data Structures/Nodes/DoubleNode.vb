Public Class DoubleNode
    Public Property Back As DoubleNode
    Public Property [Next] As DoubleNode
    Public Property Data As Integer

    Public Sub New(ByVal data As Integer)
        Me.Data = data
        [Next] = Nothing
        Back = Nothing
    End Sub
End Class