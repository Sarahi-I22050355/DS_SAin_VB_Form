Friend Class CircularList(Of T)
    Private Property Head As Node
    Private Property LastNode As Node

    Public Sub New()
        Clear()
    End Sub

    Public Sub Add(ByVal data As Integer)
        Dim NewNode As New Node(data)

        If IsEmpty() Then
            Head = NewNode
            Head.Next = Head
            LastNode = NewNode
            Return
        End If

        If Exist(NewNode.Data) Then
            Return
        End If

        If NewNode.Data < Head.Data Then
            NewNode.Next = Head
            Head = NewNode
            LastNode.Next = Head
            Return
        End If

        Dim CurrentNode As Node = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data <= NewNode.Data
            CurrentNode = CurrentNode.Next
        End While

        If NewNode.Data < CurrentNode.Next.Data Then
            NewNode.Next = CurrentNode.Next
            CurrentNode.Next = NewNode
            Return
        End If

        NewNode.Next = CurrentNode.Next
        CurrentNode.Next = NewNode
        LastNode = NewNode
    End Sub

    Public Sub Delete(ByVal data As Integer, ByVal textBox As System.Windows.Forms.TextBox)
        If IsEmpty() Then
            Return
        End If

        If Head.Data = data Then
            Head = Head.Next
            LastNode.Next = Head
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        Dim CurrentNode As Node = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data < data
            CurrentNode = CurrentNode.Next
        End While

        If CurrentNode.Next Is LastNode AndAlso CurrentNode.Next.Data = data Then
            CurrentNode.Next = CurrentNode.Next.Next
            LastNode = CurrentNode
            LastNode.Next = Head
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        If CurrentNode.Next.Data = data Then
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

        Dim CurrentNode As Node = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.Data <= data
            CurrentNode = CurrentNode.Next
        End While

        If CurrentNode.Data = data Then
            textBox.Text = $"- Data[{data}] Exist in the list"
            Return
        End If

        textBox.Text = $"- Data[{data}] Does not exist in the list"
    End Sub

    Public Sub Show(ByVal textBox As System.Windows.Forms.TextBox)
        If IsEmpty() Then
            textBox.Text = "Empty list"
            Return
        End If

        Dim CurrentNode As Node = Head
        Dim i As Integer = 0
        Do
            textBox.Text += $"- Node[{i}] and data: {CurrentNode.Data}{vbCrLf}"
            CurrentNode = CurrentNode.Next
            i += 1
        Loop While CurrentNode IsNot Head
    End Sub

    Public Function Exist(ByVal data As Integer) As Boolean
        If IsEmpty() Then
            Return False
        End If

        If Head.Data = data Then
            Return True
        End If

        Dim CurrentNode As Node = Head
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
    End Sub
End Class
