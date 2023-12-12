Friend Class CircularDoublyLinkedList(Of T)

    Private Property Head As DoubleNode
    Private Property LastNode As DoubleNode

    Public Sub New()
        Clear()
    End Sub

    Public Sub Add(data As Integer)
        Dim NewNode As New DoubleNode(data)

        If IsEmpty() Then
            Head = NewNode
            NewNode.Back = Head
            NewNode.Next = Head
            LastNode = Head
            Return
        End If

        If Exist(NewNode.Data) Then
            Return
        End If

        If NewNode.Data < Head.Data Then
            NewNode.Next = Head
            NewNode.Back = Head
            Head.Next = NewNode
            Head.Back = NewNode
            LastNode = Head
            Head = NewNode
            Return
        End If

        If NewNode.Data > LastNode.Data Then
            NewNode.Back = LastNode
            LastNode.Next = NewNode
            LastNode = NewNode
            LastNode.Next = Head
            Head.Back = LastNode
            Return
        End If

        Dim CurrentNode As DoubleNode = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data < NewNode.Data
            CurrentNode = CurrentNode.Next
        End While

        NewNode.Next = CurrentNode.Next
        NewNode.Back = CurrentNode
        CurrentNode.Next.Back = NewNode
        CurrentNode.Next = NewNode
    End Sub

    Public Sub Delete(data As Integer, textBox As System.Windows.Forms.TextBox)
        If IsEmpty() Then
            Return
        End If

        If Head.Data = LastNode.Data Then
            Clear()
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        If Head.Data = data Then
            Head = Head.Next
            Head.Back = LastNode
            LastNode.Next = Head
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        If LastNode.Data = data Then
            LastNode = LastNode.Back
            LastNode.Next = Head
            Head.Back = LastNode
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        Dim CurrentNode As DoubleNode = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data < data
            CurrentNode = CurrentNode.Next
        End While

        If CurrentNode.Next.Data = data Then
            CurrentNode.Next.Next.Back = CurrentNode
            CurrentNode.Next = CurrentNode.Next.Next
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        textBox.Text = $"- Data[{data}] Not found/removed of the list"
    End Sub

    Public Sub Search(data As Integer, textBox As System.Windows.Forms.TextBox)
        If IsEmpty() Then
            Return
        End If

        If Head.Data = data Then
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        If LastNode.Data = data Then
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        Dim CurrentNode As DoubleNode = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data <= data
            CurrentNode = CurrentNode.Next
        End While

        If CurrentNode.Data = data Then
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        textBox.Text = $"- Data[{data}] Does not exist in the list "
    End Sub

    Public Sub Show(textBox As System.Windows.Forms.TextBox)
        textBox.Text = String.Empty

        If IsEmpty() Then
            textBox.Text = "Empty list"
            Return
        End If

        Dim CurrentNode As DoubleNode = Head
        Dim i As Integer = 0
        Do
            textBox.Text += $"- Node[{i}] and data: {CurrentNode.Data}" & vbCrLf
            CurrentNode = CurrentNode.Next
            i += 1
        Loop While CurrentNode IsNot Head
    End Sub

    Public Function Exist(data As Integer) As Boolean
        If IsEmpty() Then
            Return False
        End If

        If Head.Data = data Then
            Return True
        End If

        If LastNode.Data = data Then
            Return True
        End If

        Dim CurrentNode As DoubleNode = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data <= data
            CurrentNode = CurrentNode.Next
        End While

        If CurrentNode.Data = data Then
            Return True
        End If

        Return False
    End Function

    Public Function IsEmpty() As Boolean
        Return Head Is Nothing
    End Function

    Public Sub Clear()
        Head = Nothing
        LastNode = Nothing
    End Sub
End Class