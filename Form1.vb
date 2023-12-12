Public Class Form1

    Private random As Random
    Private auto As Auto
    Private stringStack As MyStack(Of String)
    Private ReadOnly binaryTree As BinaryTree
    Private cola As Queue(Of String)
    Private bicola As LinkedList(Of String)
    Private grafo As Grafo
    Private colaPrioridad As SortedDictionary(Of Integer, Queue(Of String))
    Private array As Integer() = {9, 1, 8, 2, 7}
    Private stopwatch As Stopwatch

    Public Sub New()
        random = New Random()
        auto = New Auto()
        stringStack = New MyStack(Of String)()
        binaryTree = New BinaryTree()
        cola = New Queue(Of String)()
        bicola = New LinkedList(Of String)()
        grafo = New Grafo()
        colaPrioridad = New SortedDictionary(Of Integer, Queue(Of String))()
        stopwatch = New Stopwatch()
        InitializeComponent()
    End Sub

    Private Function ArrayReset(ByVal arr() As Integer) As Integer()
        arr(0) = 9
        arr(1) = 1
        arr(2) = 8
        arr(3) = 2
        arr(4) = 7
        Return arr
    End Function

    Public Shared Sub PrintArray(ByVal array As Integer(), ByVal txtBox As TextBox)
        txtBox.Text &= ("[" & String.Join(", ", array) & "]" & vbCrLf)
    End Sub

    Public Shared Sub BubbleSort(ByVal array As Integer(), ByVal txtBox As TextBox)
        txtBox.Text = String.Empty
        txtBox.Text &= "Initial Array: "
        PrintArray(array, txtBox)

        For i As Integer = 0 To array.Length - 2
            For j As Integer = 0 To array.Length - i - 2
                ' Comparar los elementos adyacentes e intercambiar si el elemento actual es mayor que el siguiente
                If array(j) > array(j + 1) Then
                    ' Intercambiar elementos
                    Dim temp As Integer = array(j)
                    array(j) = array(j + 1)
                    array(j + 1) = temp

                    ' Mostrar el estado actual del arreglo
                    txtBox.Text &= "Exchange - [" & String.Join(", ", array) & "]" & vbCrLf
                End If
            Next
        Next

        txtBox.Text &= "Sorted Array: "
        PrintArray(array, txtBox)
    End Sub

#Region "Lists"
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Lista_Simple As New SimpleList(Of Integer)()
        auto.Auto_Add_SimpleList(Lista_Simple, random, TextBox2, Integer.Parse(TextBox1.Text))
        Await Task.Delay(2000)
        auto.Auto_Delete_SimpleList(Lista_Simple, random, TextBox2, Integer.Parse(TextBox1.Text))
        Await Task.Delay(2000)
        auto.Auto_Search_SimpleList(Lista_Simple, random, TextBox2, Integer.Parse(TextBox1.Text))
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Circular_List As New CircularList(Of Integer)()

        auto.Auto_Add_CircularList(Circular_List, random, TextBox2, Integer.Parse(TextBox1.Text))
        Await Task.Delay(2000)
        auto.Auto_Delete_CircularList(Circular_List, random, TextBox2, Integer.Parse(TextBox1.Text))
        Await Task.Delay(2000)
        auto.Auto_Search_CircularList(Circular_List, random, TextBox2, Integer.Parse(TextBox1.Text))
    End Sub

    Private Async Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Doubly_List_Linked As New DoublyLinkedList(Of Integer)()
        auto.Auto_Add_DoublyListLinked(Doubly_List_Linked, random, TextBox2, Integer.Parse(TextBox1.Text))
        Await Task.Delay(2000)
        auto.Auto_Delete_DoublyListLinked(Doubly_List_Linked, random, TextBox2, Integer.Parse(TextBox1.Text))
        Await Task.Delay(2000)
        auto.Auto_Search_DoublyListLinked(Doubly_List_Linked, random, TextBox2, Integer.Parse(TextBox1.Text))
    End Sub

    Private Async Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Circular_Doubly_Linked_List As New CircularDoublyLinkedList(Of Integer)()
        auto.Auto_Add_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, TextBox2, Integer.Parse(TextBox1.Text))
        Await Task.Delay(2000)
        auto.Auto_Delete_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, TextBox2, Integer.Parse(TextBox1.Text))
        Await Task.Delay(2000)
        auto.Auto_Search_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, TextBox2, Integer.Parse(TextBox1.Text))
    End Sub
#End Region

#Region "Stack"

    Private Sub UpdateStackListBox()
        StackListBox.Items.Clear()

        Dim i As Integer = stringStack.Count - 1
        While i >= 0
            Dim item As String = stringStack(i)
            StackListBox.Items.Add(item)
            i -= 1
        End While
    End Sub

    Private Sub PushButton_Click(sender As Object, e As EventArgs) Handles PushButton.Click
        Dim item As String = InputTextBox.Text
        stringStack.Push(item)
        UpdateStackListBox()
        InputTextBox.Clear()
    End Sub

    Private Sub PopButton_Click(sender As Object, e As EventArgs) Handles PopButton.Click
        Try
            Dim poppedItem As String = stringStack.Pop()
            MessageBox.Show("Popped element: " & poppedItem)
            UpdateStackListBox()
        Catch ex As InvalidOperationException
            MessageBox.Show("The stack is empty. No elements to pop.")
        End Try
    End Sub

    Private Sub PeekButton_Click(sender As Object, e As EventArgs) Handles PeekButton.Click
        Try
            Dim topItem As String = stringStack.Peek()
            MessageBox.Show("Element at the top of the stack: " & topItem)
        Catch ex As InvalidOperationException
            MessageBox.Show("The stack is empty. No elements to view.")
        End Try
    End Sub

#End Region
#Region "Tree"
    Private Sub Add_BinaryTree_Click(sender As Object, e As EventArgs) Handles Add_BinaryTree.Click
        Dim number As Integer = 0
        If Not Integer.TryParse(TexBox_Add_BinaryTree.Text, number) Then
            MessageBox.Show("Only integer numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        binaryTree.Add(number)

        ToursOfTree()

        Dim Data As Integer = 0
        Try
            Data = Integer.Parse(TexBox_Add_BinaryTree.Text)
        Catch ex As Exception
        End Try

        binaryTree.Add(Data)

        _TreeV(binaryTree.Root, Nothing, TreeView.Nodes)

        TexBox_Add_BinaryTree.Clear()
        TexBox_Add_BinaryTree.Focus()
    End Sub
    Private Sub Delete_BinaryTree_Click(sender As Object, e As EventArgs) Handles Delete_BinaryTree.Click
        Dim number As Integer
        If Not Integer.TryParse(TexBox_Delete_BinaryTree.Text, number) Then
            MessageBox.Show("only integer numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        binaryTree.Delete(number)
        ToursOfTree()

        TexBox_Delete_BinaryTree.Clear()
        TexBox_Delete_BinaryTree.Focus()
    End Sub

    Private Sub Search_BinaryTree_Click(sender As Object, e As EventArgs) Handles Search_BinaryTree.Click
        Dim number As Integer
        If Not Integer.TryParse(TexBox_Search_BinaryTree.Text, number) Then
            MessageBox.Show("only integer numbers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        binaryTree.Search(number)

        TexBox_Search_BinaryTree.Clear()
        TexBox_Search_BinaryTree.Focus()
    End Sub
    Public Sub _TreeV(ByVal Tree As BinaryNode, ByVal parentNode As TreeNode, ByVal nodes As TreeNodeCollection)
        If Tree IsNot Nothing Then
            Dim NewNode = New TreeNode(Tree.Data.ToString())

            If parentNode IsNot Nothing Then
                parentNode.Nodes.Add(NewNode)
            Else
                nodes.Add(NewNode)
            End If

            _TreeV(Tree.Left, NewNode, NewNode.Nodes)
            _TreeV(Tree.Right, NewNode, NewNode.Nodes)
        End If
    End Sub
    Public Sub ToursOfTree()
        ListView_PreOrden.Items.Clear()

        For Each val As Integer In binaryTree.GetPreOrden()
            ListView_PreOrden.Items.Add(val.ToString())
        Next

        ListView_PostOrden.Items.Clear()

        For Each val As Integer In binaryTree.GetPostOrden()
            ListView_PostOrden.Items.Add(val.ToString())
        Next

        ListView_InOrden.Items.Clear()

        For Each val As Integer In binaryTree.GetInOrden()
            ListView_InOrden.Items.Add(val.ToString())
        Next
    End Sub
    Private Shared Sub VisualizarArbol(ByVal Tree As Nodo, ByVal parentNode As TreeNode, ByVal nodes As TreeNodeCollection)
        If Tree IsNot Nothing Then
            Dim NewNode = New TreeNode(Tree.Data.ToString())

            If parentNode IsNot Nothing Then
                parentNode.Nodes.Add(NewNode)
            Else
                nodes.Add(NewNode)
            End If

            VisualizarArbol(Tree.Left, NewNode, NewNode.Nodes)
            VisualizarArbol(Tree.Right, NewNode, NewNode.Nodes)
        End If
    End Sub

#End Region
#Region "Queue"
    Private Sub btnEnqueue_Click(sender As Object, e As EventArgs) Handles btnEnqueue.Click
        ' Agregar un elemento a la cola
        Dim elemento As String = txtQueue.Text
        cola.Enqueue(elemento)

        ' Actualizar la lista de elementos en la cola
        ActualizarListaCola()
    End Sub
    Private Sub ActualizarListaCola()
        ' Mostrar la cola en el ListBox
        lstvQueue.Items.Clear()
        For Each elemento As String In cola
            lstvQueue.Items.Add(elemento)
        Next
    End Sub

    Private Sub btnDequeue_Click(sender As Object, e As EventArgs) Handles btnDequeue.Click
        ' Verificar si la cola no está vacía antes de intentar eliminar
        If cola.Count > 0 Then
            ' Eliminar el elemento de la cola
            Dim elementoEliminado As String = cola.Dequeue()

            ' Mostrar un mensaje con el elemento eliminado
            MessageBox.Show($"Element removed: {elementoEliminado}")

            ' Actualizar la lista de elementos en la cola
            ActualizarListaCola()
        Else
            MessageBox.Show("The queue is empty. No elements to remove.")
        End If
    End Sub
    Private Sub ActualizarListaBicola()
        ' Mostrar la bicola en el ListBox
        lstvDeque.Items.Clear()
        For Each elemento As String In bicola
            lstvDeque.Items.Add(elemento)
        Next
    End Sub

    Private Sub btnEnqueueFirst_Click(sender As Object, e As EventArgs) Handles btnEnqueueFirst.Click
        ' Agregar un elemento al inicio de la bicola
        Dim elemento As String = txtDeque.Text
        bicola.AddFirst(elemento)

        ' Actualizar la lista de elementos en la bicola
        ActualizarListaBicola()
    End Sub

    Private Sub btnEnqueueLast_Click(sender As Object, e As EventArgs) Handles btnEnqueueLast.Click
        ' Agregar un elemento al final de la bicola
        Dim elemento As String = txtDeque.Text
        bicola.AddLast(elemento)

        ' Actualizar la lista de elementos en la bicola
        ActualizarListaBicola()
    End Sub

    Private Sub btnDequeueFirst_Click(sender As Object, e As EventArgs) Handles btnDequeueFirst.Click
        ' Verificar si la bicola no está vacía antes de intentar eliminar al inicio
        If bicola.Count > 0 Then
            ' Eliminar el elemento al inicio de la bicola
            Dim elementoEliminado As String = bicola.First.Value
            bicola.RemoveFirst()

            ' Mostrar un mensaje con el elemento eliminado
            MessageBox.Show($"Removed element from the start: {elementoEliminado}")

            ' Actualizar la lista de elementos en la bicola
            ActualizarListaBicola()
        Else
            MessageBox.Show("The deque is empty. No elements to remove from the start.")
        End If
    End Sub

    Private Sub btnDequeueLast_Click(sender As Object, e As EventArgs) Handles btnDequeueLast.Click
        ' Verificar si la bicola no está vacía antes de intentar eliminar al final
        If bicola.Count > 0 Then
            ' Eliminar el elemento al final de la bicola
            Dim elementoEliminado As String = bicola.Last.Value
            bicola.RemoveLast()

            ' Mostrar un mensaje con el elemento eliminado
            MessageBox.Show($"Removed element from the end: {elementoEliminado}")

            ' Actualizar la lista de elementos en la bicola
            ActualizarListaBicola()
        Else
            MessageBox.Show("The deque is empty. No elements to remove from the end.")
        End If
    End Sub

    Private Sub btnEnqueuePrior_Click(sender As Object, e As EventArgs) Handles btnEnqueuePrior.Click
        Dim elemento As String = txtPriorityQueue.Text
        Dim prioridad As Integer

        If Integer.TryParse(txtPriorityQueue.Text, prioridad) Then
            If Not colaPrioridad.ContainsKey(prioridad) Then
                colaPrioridad(prioridad) = New Queue(Of String)()
            End If

            colaPrioridad(prioridad).Enqueue(elemento)

            ' Actualizar la lista de elementos en la cola de prioridad
            ActualizarListaColaPrioridad()
        Else
            MessageBox.Show("Please enter a valid priority (integer number).")
        End If
    End Sub

    Private Sub btnDequeuePiror_Click(sender As Object, e As EventArgs) Handles btnDequeuePiror.Click
        ' Verificar si la cola de prioridad no está vacía antes de intentar eliminar
        If colaPrioridad.Count > 0 Then
            ' Encontrar la cola con la prioridad más baja
            Dim primeraCola = colaPrioridad.Keys.Min()
            Dim elementoEliminado = colaPrioridad(primeraCola).Dequeue()

            ' Si la cola está vacía, eliminarla de la cola de prioridad
            If colaPrioridad(primeraCola).Count = 0 Then
                colaPrioridad.Remove(primeraCola)
            End If

            ' Mostrar un mensaje con el elemento eliminado
            MessageBox.Show($"Element removed: {elementoEliminado}")

            ' Actualizar la lista de elementos en la cola de prioridad
            ActualizarListaColaPrioridad()
        Else
            MessageBox.Show("The priority queue is empty. No elements to remove.")
        End If
    End Sub
    Private Sub ActualizarListaColaPrioridad()
        ' Mostrar la cola de prioridad en el ListBox
        lstvPriorityQueue.Items.Clear()
        For Each kvp In colaPrioridad
            For Each elemento In kvp.Value
                lstvPriorityQueue.Items.Add($"{elemento} - Priority: {kvp.Key}")
            Next
        Next
    End Sub
#End Region
#Region "Graph"
    Private Sub ActualizarVisualizacionGrafo()
        ' Crear una imagen para visualizar el grafo
        Dim imagenGrafo As New Bitmap(pictureBox1.Width, pictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(imagenGrafo)
            ' Dibujar los vértices
            For Each vertice In grafo.Vertices
                g.FillEllipse(Brushes.Blue, vertice.Valor.X, vertice.Valor.Y, 30, 30)
                g.DrawString(vertice.Nombre, DefaultFont, Brushes.White, vertice.Valor.X + 8, vertice.Valor.Y + 8)
            Next

            ' Dibujar las aristas
            For Each arista In grafo.Aristas
                g.DrawLine(Pens.Black, arista.Origen.Valor.X + 15, arista.Origen.Valor.Y + 15,
                                    arista.Destino.Valor.X + 15, arista.Destino.Valor.Y + 15)
            Next
        End Using

        ' Mostrar la imagen del grafo en el PictureBox
        pictureBox1.Image = imagenGrafo
    End Sub

    Private Sub btnAddVertex_Click(sender As Object, e As EventArgs) Handles btnAddVertex.Click
        Dim vertice As String = txtVertex.Text

        ' Añadir vértice al grafo
        grafo.AgregarVertice(vertice)

        ' Actualizar la visualización del grafo
        ActualizarVisualizacionGrafo()
    End Sub

    Private Sub btnAddEdge_Click(sender As Object, e As EventArgs) Handles btnAddEdge.Click
        Dim origen As String = txtOrigin.Text
        Dim destino As String = txtDestination.Text

        ' Añadir arista al grafo
        grafo.AgregarArista(origen, destino)

        ' Actualizar la visualización del grafo
        ActualizarVisualizacionGrafo()
    End Sub

#End Region
#Region "Algorithms"
    Private Sub btnBubbleRandom_Click(sender As Object, e As EventArgs) Handles btnBubbleRandom.Click
        txtBubble.Text = String.Empty
        stopwatch.Restart()
        stopwatch.Start()
        BubbleSort(array, txtBubble)
        stopwatch.Stop()
        txtBubble.Text &= "Execution time of BubbleSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnBinaryTree_Click(sender As Object, e As EventArgs) Handles btnBinaryTree.Click
        txtBinaryTree.Text = String.Empty
        PrintArray(array, txtBinaryTree)
        Dim binaryTree As New BinaryTreeSort()
        stopwatch.Restart()
        stopwatch.Start()
        binaryTree.Sort(array)
        stopwatch.Stop()
        PrintArray(array, txtBinaryTree)
        txtBinaryTree.Text &= "Execution time of Binary Tree Sort Method= " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnBucket_Click(sender As Object, e As EventArgs) Handles btnBucket.Click
        Dim bucketSort As New BucketSort()
        txtBucket.Text = String.Empty
        stopwatch.Reset()
        txtBucket.Text &= "Initial Array: "
        PrintArray(array, txtBucket)
        stopwatch.Start()
        bucketSort.BucketSort_int(array, txtBucket)
        stopwatch.Stop()
        txtBucket.Text &= "Sorted Array: "
        PrintArray(array, txtBucket)
        txtBucket.Text &= "Execution time of BucketSort() method= " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnCocktail_Click(sender As Object, e As EventArgs) Handles btnCocktail.Click
        Dim cocktailSort As New CocktailSort()
        txtCocktail.Text = String.Empty
        stopwatch.Reset()
        txtCocktail.Text &= "Initial Array: "
        PrintArray(array, txtCocktail)
        stopwatch.Start()
        cocktailSort.cocktailSort(array)
        stopwatch.Stop()
        txtCocktail.Text &= "Sorted Array: "
        PrintArray(array, txtCocktail)
        txtCocktail.Text &= "Execution time of CocktailSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnComb_Click(sender As Object, e As EventArgs) Handles btnComb.Click
        Dim combSort As New CombSort()
        txtComb.Text = String.Empty
        stopwatch.Reset()
        txtComb.Text &= "Initial Array: "
        PrintArray(array, txtComb)
        stopwatch.Start()
        combSort.Sort(array)
        stopwatch.Stop()
        txtComb.Text &= "Sorted Array: "
        PrintArray(array, txtComb)
        txtComb.Text &= "Execution time of CombSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnCounting_Click(sender As Object, e As EventArgs) Handles btnCounting.Click
        Dim countingSort As New CountingSort()
        txtCounting.Text = String.Empty
        stopwatch.Reset()
        txtCounting.Text &= "Initial Array: "
        PrintArray(array, txtCounting)
        stopwatch.Start()
        countingSort.Sort(array)
        stopwatch.Stop()
        txtCounting.Text &= "Sorted Array: "
        PrintArray(array, txtCounting)
        txtCounting.Text &= "Execution time of CountingSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnGnome_Click(sender As Object, e As EventArgs) Handles btnGnome.Click
        Dim gnomeSort As New GnomeSort()
        txtGnome.Text = String.Empty
        stopwatch.Reset()
        txtGnome.Text &= "Initial Array: "
        PrintArray(array, txtGnome)
        stopwatch.Start()
        gnomeSort.Sort(array)
        stopwatch.Stop()
        txtGnome.Text &= "Sorted Array: "
        PrintArray(array, txtGnome)
        txtGnome.Text &= "Execution time of GnomeSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnHeap_Click(sender As Object, e As EventArgs) Handles btnHeap.Click
        Dim heapSort As New HeapSort()
        txtHeap.Text = String.Empty
        stopwatch.Reset()
        txtHeap.Text &= "Initial Array: "
        PrintArray(array, txtHeap)
        stopwatch.Start()
        heapSort.Sort(array)
        stopwatch.Stop()
        txtHeap.Text &= "Sorted Array: "
        PrintArray(array, txtHeap)
        txtHeap.Text &= "Execution time of HeapSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnInsertion_Click(sender As Object, e As EventArgs) Handles btnInsertion.Click
        Dim insertionSort As New InsertionSort()
        txtInsertion.Text = String.Empty
        stopwatch.Reset()
        txtInsertion.Text &= "Initial Array: "
        PrintArray(array, txtInsertion)
        stopwatch.Start()
        insertionSort.InsertionSortAlgorithm(array)
        stopwatch.Stop()
        txtInsertion.Text &= "Sorted Array: "
        PrintArray(array, txtInsertion)
        txtInsertion.Text &= "Execution time of InsertionSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnMerge_Click(sender As Object, e As EventArgs) Handles btnMerge.Click
        Dim mergeSort As New MergeSort()
        txtMerge.Text = String.Empty
        stopwatch.Reset()
        txtMerge.Text &= "Initial Array: "
        PrintArray(array, txtMerge)
        stopwatch.Start()
        mergeSort.MergeSortt(array)
        stopwatch.Stop()
        txtMerge.Text &= "Sorted Array: "
        PrintArray(array, txtMerge)
        txtMerge.Text &= "Execution time of MergeSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnPigeon_Click(sender As Object, e As EventArgs) Handles btnPigeon.Click
        Dim pigeonHole As New PigeonHole()
        txtPigeon.Text = String.Empty
        stopwatch.Reset()
        txtPigeon.Text &= "Initial Array: "
        PrintArray(array, txtPigeon)
        stopwatch.Start()
        pigeonHole.PigeonholeSort(array)
        stopwatch.Stop()
        txtPigeon.Text &= "Sorted Array: "
        PrintArray(array, txtPigeon)
        txtPigeon.Text &= "Execution time of PigeonHoleSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnQuick_Click(sender As Object, e As EventArgs) Handles btnQuick.Click
        txtQuick.Text = String.Empty
        Dim quickSort As New QuickSort()
        stopwatch.Reset()
        txtQuick.Text &= "Initial Array: "
        PrintArray(array, txtQuick)
        stopwatch.Start()
        quickSort.Quicksort(array, 0, 4, txtQuick)
        stopwatch.Stop()
        txtQuick.Text &= "Sorted Array: "
        PrintArray(array, txtQuick)
        txtQuick.Text &= "Execution time of QuickSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnRadix_Click(sender As Object, e As EventArgs) Handles btnRadix.Click
        txtRadix.Text = String.Empty
        Dim radixSort As New RadixSort()
        stopwatch.Reset()
        txtRadix.Text &= "Initial Array: "
        PrintArray(array, txtRadix)
        stopwatch.Start()
        radixSort.Sort(array)
        stopwatch.Stop()
        txtRadix.Text &= "Sorted Array: "
        PrintArray(array, txtRadix)
        txtRadix.Text &= "Execution time of RadixSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnSelection_Click(sender As Object, e As EventArgs) Handles btnSelection.Click
        txtSelection.Text = String.Empty
        Dim selection_Sort As New SelectionSort()
        stopwatch.Reset()
        txtSelection.Text &= "Initial Array: "
        PrintArray(array, txtSelection)
        stopwatch.Start()
        selection_Sort.Sort(array)
        stopwatch.Stop()
        txtSelection.Text &= "Sorted Array: "
        PrintArray(array, txtSelection)
        txtSelection.Text &= "Execution time of SelectionSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnShell_Click(sender As Object, e As EventArgs) Handles btnShell.Click
        txtShell.Text = String.Empty
        Dim shellSort As New ShellSort()
        stopwatch.Reset()
        txtShell.Text &= "Initial Array: "
        PrintArray(array, txtShell)
        stopwatch.Start()
        shellSort.Shell_Sort(array, txtShell)
        stopwatch.Stop()
        txtShell.Text &= vbCrLf & "Sorted Array: "
        PrintArray(array, txtShell)
        txtShell.Text &= "Execution time of ShellSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub

    Private Sub btnSmooth_Click(sender As Object, e As EventArgs) Handles btnSmooth.Click
        txtSmooth.Text = String.Empty
        Dim smoothSort As New SmoothSort()
        stopwatch.Reset()
        txtSmooth.Text &= "Initial Array: "
        PrintArray(array, txtSmooth)
        stopwatch.Start()
        smoothSort.Sort(array)
        stopwatch.Stop()
        txtSmooth.Text &= "Sorted Array: "
        PrintArray(array, txtSmooth)
        txtSmooth.Text &= "Execution time of SmoothSort() method = " & stopwatch.Elapsed.ToString()
        ArrayReset(array)
    End Sub


#End Region
End Class
