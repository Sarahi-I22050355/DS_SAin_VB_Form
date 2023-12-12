Friend Class Auto
    Public Sub Auto_Add_SimpleList(lista As SimpleList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Add(R.Next(25))
        Next
        lista.Show(textBox)
    End Sub

    Public Sub Auto_Delete_SimpleList(lista As SimpleList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Delete(R.Next(25), textBox)
        Next
    End Sub

    Public Sub Auto_Search_SimpleList(lista As SimpleList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Search(R.Next(25), textBox)
        Next
    End Sub

    Public Sub Auto_Add_CircularList(lista As CircularList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        textBox.Text = String.Empty
        For i As Integer = 0 To numDatos - 1
            lista.Add(R.Next(25))
        Next
        lista.Show(textBox)
    End Sub

    Public Sub Auto_Delete_CircularList(lista As CircularList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Delete(R.Next(25), textBox)
        Next
    End Sub

    Public Sub Auto_Search_CircularList(lista As CircularList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Search(R.Next(25), textBox)
        Next
    End Sub

    Public Sub Auto_Add_DoublyListLinked(lista As DoublyLinkedList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Add(R.Next(25))
        Next
        lista.Show(textBox)
    End Sub

    Public Sub Auto_Delete_DoublyListLinked(lista As DoublyLinkedList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Delete(R.Next(25), textBox)
        Next
    End Sub

    Public Sub Auto_Search_DoublyListLinked(lista As DoublyLinkedList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Search(R.Next(25), textBox)
        Next
    End Sub

    Public Sub Auto_Add_CircularDoublyLinkedList(lista As CircularDoublyLinkedList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Add(R.Next(25))
        Next
        lista.Show(textBox)
    End Sub

    Public Sub Auto_Delete_CircularDoublyLinkedList(lista As CircularDoublyLinkedList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Delete(R.Next(25), textBox)
        Next
    End Sub

    Public Sub Auto_Search_CircularDoublyLinkedList(lista As CircularDoublyLinkedList(Of Integer), R As Random, textBox As System.Windows.Forms.TextBox, numDatos As Integer)
        For i As Integer = 0 To numDatos - 1
            lista.Search(R.Next(25), textBox)
        Next
    End Sub
End Class