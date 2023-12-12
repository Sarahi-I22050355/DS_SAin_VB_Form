Friend Class SelectionSort
    Public Sub Sort(ByRef arr As Integer())
        Dim n As Integer = arr.Length

        For i As Integer = 0 To n - 2
            ' Encontrar el índice del mínimo elemento en el subarreglo no ordenado
            Dim minIndex As Integer = i
            For j As Integer = i + 1 To n - 1
                If arr(j) < arr(minIndex) Then
                    minIndex = j
                End If
            Next

            ' Intercambiar el mínimo encontrado con el primer elemento del subarreglo no ordenado
            Swap(arr(i), arr(minIndex))
        Next
    End Sub

    Private Sub Swap(ByRef a As Integer, ByRef b As Integer)
        Dim temp As Integer = a
        a = b
        b = temp
    End Sub
End Class