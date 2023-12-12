Friend Class DoublyLinkedList(Of T)
    Private Property Head As DoubleNode
    Private Property LastNode As DoubleNode

    Public Sub New()
        Clear()
    End Sub

    Public Sub Add(ByVal data As Integer)
        Dim NewNode As New DoubleNode(data)

        If IsEmpty() Then
            Head = NewNode
            LastNode = NewNode
            Return
        End If

        If Exist(NewNode.Data) Then
            Return
        End If

        If NewNode.Data < Head.Data Then
            Head.Back = NewNode
            NewNode.Next = Head
            Head = NewNode
            Return
        End If

        If NewNode.Data > LastNode.Data Then
            LastNode.Next = NewNode
            NewNode.Back = LastNode
            LastNode = NewNode
            Return
        End If

        Dim CurrentNode As DoubleNode = Head
        While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data < NewNode.Data
            CurrentNode = CurrentNode.Next
        End While

        NewNode.Next = CurrentNode.Next
        NewNode.Back = CurrentNode
        CurrentNode.Next.Back = NewNode
        CurrentNode.Next = NewNode
    End Sub

    Public Sub Delete(ByVal data As Integer, ByVal textBox As System.Windows.Forms.TextBox)
        If IsEmpty() Then
            Return
        End If

        If Head.Data = data Then
            Head = Head.Next
            Head.Back = Nothing
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        If LastNode.Data = data Then
            LastNode = LastNode.Back
            LastNode.Next = Nothing
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        Dim CurrentNode As DoubleNode = Head
        While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data < data
            CurrentNode = CurrentNode.Next
        End While

        If CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data = data Then
            CurrentNode.Next.Next.Back = CurrentNode
            CurrentNode.Next = CurrentNode.Next.Next
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        textBox.Text = $"- Data[{data}] Not found/removed of the list"
    End Sub

    Public Sub Search(ByVal data As Integer, ByVal textBox As System.Windows.Forms.TextBox)
        If IsEmpty() Then
            Return
        End If

        If Head.Data = data Then
            textBox.Text = $"- Data[{data}] Exist in the list"
            Return
        End If

        If LastNode.Data = data Then
            textBox.Text = $"- Data[{data}] Exist in the list"
            Return
        End If

        Dim CurrentNode As DoubleNode = Head
        While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data <= data
            CurrentNode = CurrentNode.Next
        End While

        If CurrentNode.Data = data Then
            textBox.Text = $"- Data[{data}] Exist in the list"
            Return
        End If

        textBox.Text = $"- Data[{data}] Does not exist in the list "
    End Sub

    Public Sub Show(ByVal textBox As System.Windows.Forms.TextBox)
        textBox.Text = String.Empty

        If IsEmpty() Then
            textBox.Text = "Empty List"
            Return
        End If

        Dim CurrentNode As DoubleNode = Head
        Dim i As Integer = 0
        While CurrentNode IsNot Nothing
            textBox.Text += $"- Node[{i}] and data: {CurrentNode.Data}{vbCrLf}"
            CurrentNode = CurrentNode.Next
            i += 1
        End While
    End Sub

    Public Function Exist(ByVal data As Integer) As Boolean
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
        While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data <= data
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