Friend Class CocktailSort
    Public Sub cocktailSort(arr As Integer())
        Dim n As Integer = arr.Length
        Dim swapped As Boolean = True
        Dim start As Integer = 0
        Dim [end] As Integer = n - 1

        While swapped
            ' Mover de izquierda a derecha
            swapped = False
            For i As Integer = start To [end] - 1
                If arr(i) > arr(i + 1) Then
                    Swap(arr, i, i + 1)
                    swapped = True
                End If
            Next

            If Not swapped Then
                Exit While
            End If

            [end] -= 1

            ' Mover de derecha a izquierda
            swapped = False
            For i As Integer = [end] - 1 To start Step -1
                If arr(i) > arr(i + 1) Then
                    Swap(arr, i, i + 1)
                    swapped = True
                End If
            Next

            start += 1
        End While
    End Sub

    Private Sub Swap(arr As Integer(), i As Integer, j As Integer)
        Dim temp As Integer = arr(i)
        arr(i) = arr(j)
        arr(j) = temp
    End Sub
End Class