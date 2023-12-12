Friend Class BucketSort
    Private Shared _rand As New Random()

    Private Shared Sub PrintBucketState(buckets As List(Of Integer)(), txtBox As TextBox)
        txtBox.Text += "Current state of buckets: " & vbCrLf
        For i As Integer = 0 To buckets.Length - 1
            txtBox.Text += $"Bucket {i}: "
            For Each item In buckets(i)
                txtBox.Text += $"{item} "
            Next
            txtBox.Text += vbCrLf
        Next
        txtBox.Text += vbCrLf
    End Sub

    Public Sub BucketSort_int(array As Integer(), txtBox As TextBox)
        ' Encuentra el valor máximo en el array
        Dim maxVal As Integer = array(0)

        For i As Integer = 1 To array.Length - 1
            If array(i) > maxVal Then
                maxVal = array(i)
            End If
        Next

        ' Crea una lista de buckets vacíos
        Dim buckets(maxVal) As List(Of Integer)
        For i As Integer = 0 To buckets.Length - 1
            buckets(i) = New List(Of Integer)()
        Next

        ' Distribuye los elementos en los buckets
        For i As Integer = 0 To array.Length - 1
            buckets(array(i)).Add(array(i))
        Next
        PrintBucketState(buckets, txtBox)

        ' Ordena cada cubo individualmente
        For i As Integer = 0 To buckets.Length - 1
            buckets(i).Sort()
        Next
        PrintBucketState(buckets, txtBox)

        ' Concatena los elementos ordenados de cada cubo
        Dim index As Integer = 0
        For i As Integer = 0 To buckets.Length - 1
            For Each item In buckets(i)
                array(index) = item
                index += 1
            Next
        Next
    End Sub
End Class