Public Class BinaryTree
    Public Property Root As BinaryNode

    Public Sub New()
        Root = Nothing
    End Sub

    Public Sub PrintTree()
        Dim treeGraph As String = GenerateTreeGraph()
        Console.WriteLine(treeGraph)
    End Sub

    Private Function GenerateTreeGraph() As String
        Dim treeGraph As New System.Text.StringBuilder()
        _GenerateTreeGraph(Root, "", True, treeGraph)
        Return treeGraph.ToString()
    End Function

    Private Sub _GenerateTreeGraph(node As BinaryNode, prefix As String, isLeft As Boolean, treeGraph As System.Text.StringBuilder)
        If node IsNot Nothing Then
            treeGraph.Append(prefix)
            treeGraph.Append(If(isLeft, "├── ", "└── "))
            treeGraph.AppendLine(node.Data.ToString())

            _GenerateTreeGraph(node.Left, prefix & If(isLeft, "│   ", "    "), True, treeGraph)
            _GenerateTreeGraph(node.Right, prefix & If(isLeft, "│   ", "    "), False, treeGraph)
        End If
    End Sub

    Public Sub Add(valor As Integer)
        Root = _Add(Root, valor)
    End Sub

    Public Sub Delete(valor As Integer)
        Root = _Delete(Root, valor)
    End Sub

    Public Function Search(valor As Integer) As Boolean
        Return _Search(Root, valor)
    End Function

    Public Sub PreOrden()
        _PreOrden(Root)
        Console.WriteLine()
    End Sub

    Public Sub PostOrden()
        _PostOrden(Root)
        Console.WriteLine()
    End Sub

    Public Sub InOrden()
        _InOrden(Root)
        Console.WriteLine()
    End Sub

    Private Function _Add(nodo As BinaryNode, valor As Integer) As BinaryNode
        If nodo Is Nothing Then
            Return New BinaryNode(valor)
        End If

        If valor < nodo.Data Then
            nodo.Left = _Add(nodo.Left, valor)
        ElseIf valor > nodo.Data Then
            nodo.Right = _Add(nodo.Right, valor)
        End If

        Return nodo
    End Function

    Private Function _Delete(nodo As BinaryNode, valor As Integer) As BinaryNode
        If nodo Is Nothing Then
            Return nodo
        End If

        If valor < nodo.Data Then
            nodo.Left = _Delete(nodo.Left, valor)
        ElseIf valor > nodo.Data Then
            nodo.Right = _Delete(nodo.Right, valor)
        Else
            If nodo.Left Is Nothing Then
                Return nodo.Right
            ElseIf nodo.Right Is Nothing Then
                Return nodo.Left
            End If

            nodo.Data = MinValue(nodo.Right)
            nodo.Right = _Delete(nodo.Right, nodo.Data)
        End If

        Return nodo
    End Function

    Private Function MinValue(nodo As BinaryNode) As Integer
        Dim min As Integer = nodo.Data
        While nodo.Left IsNot Nothing
            min = nodo.Left.Data
            nodo = nodo.Left
        End While
        Return min
    End Function

    Private Function _Search(nodo As BinaryNode, valor As Integer) As Boolean
        If nodo Is Nothing Then
            MessageBox.Show("Data does not exist in the tree", "Not exist", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If valor = nodo.Data Then
            MessageBox.Show("Data exist int the list", "Founded", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        End If

        If valor < nodo.Data Then
            Return _Search(nodo.Left, valor)
        End If

        Return _Search(nodo.Right, valor)
    End Function

    Public Function GetPreOrden() As List(Of Integer)
        Dim result As New List(Of Integer)()
        _GetPreOrden(Root, result)
        Return result
    End Function

    Public Function GetPostOrden() As List(Of Integer)
        Dim result As New List(Of Integer)()
        _GetPostOrden(Root, result)
        Return result
    End Function

    Public Function GetInOrden() As List(Of Integer)
        Dim result As New List(Of Integer)()
        _GetInOrden(Root, result)
        Return result
    End Function

    Private Sub _GetPreOrden(node As BinaryNode, result As List(Of Integer))
        If node IsNot Nothing Then
            result.Add(node.Data)
            _GetPreOrden(node.Left, result)
            _GetPreOrden(node.Right, result)
        End If
    End Sub

    Private Sub _GetPostOrden(node As BinaryNode, result As List(Of Integer))
        If node IsNot Nothing Then
            _GetPostOrden(node.Left, result)
            _GetPostOrden(node.Right, result)
            result.Add(node.Data)
        End If
    End Sub

    Private Sub _GetInOrden(node As BinaryNode, result As List(Of Integer))
        If node IsNot Nothing Then
            _GetInOrden(node.Left, result)
            result.Add(node.Data)
            _GetInOrden(node.Right, result)
        End If
    End Sub

    Private Sub _PreOrden(Tree As BinaryNode)
        If Tree IsNot Nothing Then
            Console.Write(Tree.Data & " ")
            _PreOrden(Tree.Left)
            _PreOrden(Tree.Right)
        End If
    End Sub

    Private Sub _PostOrden(Tree As BinaryNode)
        If Tree IsNot Nothing Then
            _PostOrden(Tree.Left)
            _PostOrden(Tree.Right)
            Console.Write(Tree.Data & " ")
        End If
    End Sub

    Private Sub _InOrden(Tree As BinaryNode)
        If Tree IsNot Nothing Then
            _InOrden(Tree.Left)
            Console.Write(Tree.Data & " ")
            _InOrden(Tree.Right)
        End If
    End Sub
End Class