Friend Class Node
    Public Property [Next] As Node
    Public Property Data As Integer

    Public Sub New(ByVal d As Integer)
        Data = d
        [Next] = Nothing
    End Sub
End Class