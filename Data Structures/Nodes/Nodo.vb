Public Class Nodo
    Public Property Left As Nodo
    Public Property Right As Nodo
    Public Property [Next] As Nodo
    Public Property Data As Integer

    Public Sub New(ByVal Data As Integer)
        Me.Data = Data
        Left = Nothing
        Right = Nothing
        [Next] = Nothing
    End Sub
End Class