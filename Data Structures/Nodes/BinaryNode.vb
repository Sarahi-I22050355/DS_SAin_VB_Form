Public Class BinaryNode
    Public Data As Integer
    Public Left, Right As BinaryNode

    Public Sub New(ByVal value As Integer)
        Data = value
        Left = Nothing
        Right = Nothing
    End Sub
End Class