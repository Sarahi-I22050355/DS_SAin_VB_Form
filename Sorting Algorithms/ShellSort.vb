Friend Class ShellSort
    Private Sub PrintArray(ByVal array As Integer(), ByVal textBox As TextBox)
        For Each num As Integer In array
            textBox.Text += (num & " ")
        Next
        textBox.Text += vbCrLf
    End Sub

    Public Sub Shell_Sort(ByVal array As Integer(), ByVal textBox As TextBox)
        ' se obtiene la longitud del array
        Dim n As Integer = array.Length
        ' se obtiene el tamaño de espacio entre elementos
        Dim gap As Integer = n \ 2

        textBox.Text += vbCrLf & "Start of Shell Sort algorithm:" & vbCrLf

        ' Mientras el espacio entre elementos sea mayor que 0
        While gap > 0
            textBox.Text += vbCrLf & $"Current Gap: {gap}" & vbCrLf

            ' Aplicar el algoritmo de inserción para cada "subarray" con el tamaño de gap
            For i As Integer = gap To n - 1
                ' Guardar el valor actual del elemento en una variable temporal
                Dim temp As Integer = array(i)
                Dim j As Integer = i

                textBox.Text += vbCrLf & $"Compare {temp} to elements in the subarray:" & vbCrLf

                ' Realizar la inserción
                While j >= gap AndAlso array(j - gap) > temp
                    ' Desplazar elementos hacia la derecha hasta encontrar la posición correcta
                    array(j) = array(j - gap)
                    j -= gap

                    PrintArray(array, textBox)
                End While

                ' Colocar el valor temporal en la posición correcta en el subarray
                array(j) = temp
                textBox.Text += $"Insert {temp} in the subarray {j} position:" & vbCrLf
                PrintArray(array, textBox)
            Next

            ' Reducir el espacio entre elementos a la mitad en cada iteración
            gap \= 2
        End While

        textBox.Text += vbCrLf & "End of Shell Sort algorithm:"
    End Sub
End Class