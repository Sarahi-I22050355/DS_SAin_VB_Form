Friend Class MyStack(Of T)
    Private stackList As List(Of T)

    Public Sub New()
        stackList = New List(Of T)()
    End Sub

    Public Sub Push(item As T)
        stackList.Add(item)
    End Sub

    Public Function Pop() As T
        If stackList.Count = 0 Then
            Throw New InvalidOperationException("the stack is empty.")
        End If

        Dim lastIndex As Integer = stackList.Count - 1
        Dim poppedItem As T = stackList(lastIndex)
        stackList.RemoveAt(lastIndex)

        Return poppedItem
    End Function

    Public Function Peek() As T
        If stackList.Count = 0 Then
            Throw New InvalidOperationException("the stack is empty.")
        End If

        Return stackList(stackList.Count - 1)
    End Function

    Public ReadOnly Property Count As Integer
        Get
            Return stackList.Count
        End Get
    End Property

    Default Public ReadOnly Property Item(index As Integer) As T
        Get
            Return stackList(index)
        End Get
    End Property
End Class