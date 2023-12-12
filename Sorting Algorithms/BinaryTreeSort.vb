Friend Class BinaryTreeSort
    Private root As BinaryNode
    Private index As Integer = 0

    Public Sub Sort(arr As Integer())
        ' Construir el árbol binario
        For Each value As Integer In arr
            root = Insert(root, value)
        Next

        ' Recorrer el árbol en orden para obtener los elementos ordenados
        InOrderTraversal(root, arr, index)
    End Sub

    Private Function Insert(node As BinaryNode, value As Integer) As BinaryNode
        If node Is Nothing Then
            Return New BinaryNode(value)
        End If

        If value < node.Data Then
            node.Left = Insert(node.Left, value)
        ElseIf value > node.Data Then
            node.Right = Insert(node.Right, value)
        End If

        Return node
    End Function

    Private Sub InOrderTraversal(node As BinaryNode, arr As Integer(), ByRef index As Integer)
        If node IsNot Nothing Then
            InOrderTraversal(node.Left, arr, index)
            arr(index) = node.Data
            index += 1
            InOrderTraversal(node.Right, arr, index)
        End If
    End Sub
End Class