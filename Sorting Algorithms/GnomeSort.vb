Friend Class GnomeSort
    Public Sub Sort(ByRef arr As Integer())
        Dim n As Integer = arr.Length
        Dim index As Integer = 0

        While index < n
            If index = 0 Then
                index += 1
            End If

            If index < n AndAlso arr(index) >= arr(index - 1) Then
                index += 1
            Else
                Swap(arr(index), arr(index - 1))
                index -= 1
            End If
        End While
    End Sub

    Private Sub Swap(ByRef a As Integer, ByRef b As Integer)
        Dim temp As Integer = a
        a = b
        b = temp
    End Sub
End Class