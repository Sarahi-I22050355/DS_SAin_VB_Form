Friend Class HeapSort
    Public Sub Sort(ByRef arr As Integer())
        Dim n As Integer = arr.Length

        ' Construir un heap (montículo) máximo
        For i As Integer = n \ 2 - 1 To 0 Step -1
            Heapify(arr, n, i)
        Next

        ' Extraer elementos uno por uno del heap
        For i As Integer = n - 1 To 1 Step -1
            ' Mover la raíz actual al final
            Swap(arr(0), arr(i))

            ' Llamar a heapify en el subárbol reducido
            Heapify(arr, i, 0)
        Next
    End Sub

    Private Sub Heapify(ByRef arr As Integer(), ByVal n As Integer, ByVal i As Integer)
        Dim largest As Integer = i
        Dim left As Integer = 2 * i + 1
        Dim right As Integer = 2 * i + 2

        ' Comparar con el hijo izquierdo
        If left < n AndAlso arr(left) > arr(largest) Then
            largest = left
        End If

        ' Comparar con el hijo derecho
        If right < n AndAlso arr(right) > arr(largest) Then
            largest = right
        End If

        ' Si el mayor no es la raíz
        If largest <> i Then
            Swap(arr(i), arr(largest))

            ' Recursivamente heapify el subárbol afectado
            Heapify(arr, n, largest)
        End If
    End Sub

    Private Sub Swap(ByRef a As Integer, ByRef b As Integer)
        Dim temp As Integer = a
        a = b
        b = temp
    End Sub
End Class