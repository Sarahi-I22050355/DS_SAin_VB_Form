Friend Class MergeSort
    Public Sub MergeSortt(ByRef arr As Integer())
        If arr.Length < 2 Then
            Return
        End If

        Dim mid As Integer = arr.Length \ 2
        Dim left(mid - 1) As Integer
        Dim right(arr.Length - mid - 1) As Integer

        Array.Copy(arr, 0, left, 0, mid)
        Array.Copy(arr, mid, right, 0, arr.Length - mid)

        MergeSortt(left)
        MergeSortt(right)
        Merge(arr, left, right)
    End Sub

    Public Sub Merge(ByRef arr As Integer(), ByVal left As Integer(), ByVal right As Integer())
        Dim i As Integer = 0, j As Integer = 0, k As Integer = 0

        While i < left.Length AndAlso j < right.Length
            If left(i) <= right(j) Then
                arr(k) = left(i)
                i += 1
            Else
                arr(k) = right(j)
                j += 1
            End If
            k += 1
        End While

        While i < left.Length
            arr(k) = left(i)
            i += 1
            k += 1
        End While

        While j < right.Length
            arr(k) = right(j)
            j += 1
            k += 1
        End While
    End Sub
End Class