Friend Class SimpleList(Of T)
    Private Property Head As Node

    Public Sub New()
        Clear()
    End Sub

    Public Sub Add(ByVal data As Integer)
        Dim NewNode As New Node(data)

        If IsEmpty() Then
            Head = NewNode
            Return
        End If

        If Exist(NewNode.Data) Then
            Return
        End If

        If NewNode.Data < Head.Data Then
            NewNode.Next = Head
            Head = NewNode
            Return
        End If

        Dim CurrentNode As Node = Head
        While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data < NewNode.Data
            CurrentNode = CurrentNode.Next
        End While

        NewNode.Next = CurrentNode.Next
        CurrentNode.Next = NewNode
    End Sub

    Public Sub Delete(ByVal data As Integer, ByVal textBox As System.Windows.Forms.TextBox)
        textBox.Text = String.Empty

        If IsEmpty() Then
            Return
        End If

        If Head.Data = data Then
            Head = Head.Next
            textBox.Text = $"- Data[{data}] removed of the list"
            Return
        End If

        Dim CurrentNode As Node = Head
        While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data < data
            CurrentNode = CurrentNode.Next
        End While

        If CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data = data Then
            CurrentNode.Next = CurrentNode.Next.Next
            textBox.Text = $"- Data[{data}] Removed of the list"
            Return
        End If

        textBox.Text = $"- Data[{data}] Not found/removed of the list"
    End Sub

    Public Sub Search(ByVal data As Integer, ByVal textBox As System.Windows.Forms.TextBox)
        textBox.Text = String.Empty

        If IsEmpty() Then
            Return
        End If

        If Head.Data = data Then
            textBox.Text = $"- Data[{data}] Exist in the list"
            Return
        End If

        Dim CurrentNode As Node = Head
        While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.Data <= data
            CurrentNode = CurrentNode.Next
        End While

        If CurrentNode.Data = data Then
            textBox.Text = $"- Data[{data}] Exist in the list"
            Return
        End If

        textBox.Text = $"- Data[{data}] does not exist in the list"
    End Sub

    Public Sub Show(ByVal textBox As System.Windows.Forms.TextBox)
        textBox.Text = String.Empty

        If IsEmpty() Then
            textBox.Text = "Empty List"
            Return
        End If

        Dim i As Integer = 0
        Dim CurrentNode As Node = Head
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

        Dim CurrentNode As Node = Head
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
    End Sub
End Class
