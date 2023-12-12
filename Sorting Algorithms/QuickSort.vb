Friend Class QuickSort
    Private Shared _Random As New Random()
    Private Shared _Option, _ContainExchange, _ContainPartition, _ContainRecursive As Integer

    Private Shared Sub Swap(ByRef IndexOne As Integer, ByRef IndexTwo As Integer)
        Dim Temporary As Integer = IndexOne
        IndexOne = IndexTwo
        IndexTwo = Temporary
    End Sub

    Private Shared Function Partition(ByRef Array As Integer(), ByVal FirstIndex As Integer, ByVal LastIndex As Integer, ByVal textBox As TextBox) As Integer
        _ContainPartition += 1
        Dim IndexPivot As Integer
        Select Case _Option
            Case 1
                IndexPivot = FirstIndex
            Case 2
                IndexPivot = CInt(Math.Floor(CDbl(LastIndex + FirstIndex) / 2))
            Case 3
                IndexPivot = LastIndex
            Case Else
                IndexPivot = _Random.Next(FirstIndex, LastIndex)
        End Select
        Swap(Array(FirstIndex), Array(IndexPivot))
        PrintSwap(Array, FirstIndex, IndexPivot, textBox)
        _ContainExchange += 1
        Dim Pivot As Integer = Array(FirstIndex)
        Dim Left As Integer = FirstIndex + 1
        Dim Right As Integer = LastIndex
        While True
            While Left <= Right AndAlso Array(Left) <= Pivot
                Left += 1
            End While
            While Left <= Right AndAlso Array(Right) >= Pivot
                Right -= 1
            End While
            If Right < Left Then
                Exit While
            End If
            Swap(Array(Left), Array(Right))
            PrintSwap(Array, Left, Right, textBox)
            _ContainExchange += 1
            Left += 1
            Right -= 1
        End While
        Swap(Array(FirstIndex), Array(Right))
        PrintSwap(Array, FirstIndex, Right, textBox)
        _ContainExchange += 1
        Return Right
    End Function

    Private Shared Sub PrintSwap(ByVal array As Integer(), ByVal Left As Integer, ByVal Right As Integer, ByVal textBox As TextBox)
        textBox.Text += ("[ ")
        For i As Integer = 0 To array.Length - 1
            If Right = i AndAlso Left = i Then
                textBox.Text += (array(i))
            ElseIf i = Left OrElse i = Right Then
                textBox.Text += (array(i))
            Else
                textBox.Text += (array(i))
            End If
            If i < array.Length - 1 Then
                textBox.Text += (", ")
            End If
        Next
        textBox.Text += (" ]" & vbCrLf)
    End Sub

    Public Sub Quicksort(ByRef Array As Integer(), ByVal FirstIndex As Integer, ByVal LastIndex As Integer, ByVal textBox As TextBox)
        If FirstIndex < LastIndex Then
            _ContainRecursive += 1
            Dim IndexPivot As Integer = Partition(Array, FirstIndex, LastIndex, textBox)
            Quicksort(Array, FirstIndex, IndexPivot - 1, textBox)
            Quicksort(Array, IndexPivot + 1, LastIndex, textBox)
        End If
    End Sub
End Class