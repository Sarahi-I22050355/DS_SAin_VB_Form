Friend Class SmoothSort
    Private heap As Integer()

    Public Sub Sort(ByVal arr As Integer())
        heap = arr
        Dim n As Integer = arr.Length

        For i As Integer = n \ 2 - 1 To 0 Step -1
            SiftDown(i, n - 1)
        Next

        For i As Integer = n - 1 To 1 Step -1
            Swap(0, i)
            SiftDown(0, i - 1)
        Next
    End Sub

    Private Sub SiftDown(ByVal root As Integer, ByVal [end] As Integer)
        Dim i As Integer = root

        While 2 * i + 1 <= [end]
            Dim j As Integer = 2 * i + 1

            If j + 1 <= [end] AndAlso heap(j) < heap(j + 1) Then
                j += 1
            End If

            If heap(i) >= heap(j) Then
                Exit While
            End If

            Swap(i, j)
            i = j
        End While
    End Sub

    Private Function LeftChild(ByVal i As Integer, ByVal k As Integer) As Integer
        Return i - Fibonacci(k - 1) + Fibonacci(k - 2)
    End Function

    Private Function Fibonacci(ByVal n As Integer) As Integer
        If n <= 1 Then
            Return n
        End If

        Dim a As Integer = 0, b As Integer = 1

        For i As Integer = 2 To n
            Dim temp As Integer = a + b
            a = b
            b = temp
        Next

        Return b
    End Function

    Private Sub Swap(ByVal i As Integer, ByVal j As Integer)
        Dim temp As Integer = heap(i)
        heap(i) = heap(j)
        heap(j) = temp
    End Sub
End Class