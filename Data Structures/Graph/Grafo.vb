Friend Class Grafo
    Public ReadOnly Property Vertices As List(Of Vertex)
    Public ReadOnly Property Aristas As List(Of Edge)

    Public Sub New()
        Vertices = New List(Of Vertex)()
        Aristas = New List(Of Edge)()
    End Sub

    Public Sub AgregarVertice(nombre As String)
        ' Añadir un vértice a posiciones aleatorias en el PictureBox
        Dim random As New Random()
        Dim nuevoVertice As New Vertex(nombre, New Point(random.Next(0, 400), random.Next(0, 300)))
        Vertices.Add(nuevoVertice)
    End Sub

    Public Sub AgregarArista(origen As String, destino As String)
        ' Añadir una arista entre los vértices con los nombres dados
        Dim verticeOrigen As Vertex = Vertices.Find(Function(v) v.Nombre = origen)
        Dim verticeDestino As Vertex = Vertices.Find(Function(v) v.Nombre = destino)

        If verticeOrigen IsNot Nothing AndAlso verticeDestino IsNot Nothing Then
            Aristas.Add(New Edge(verticeOrigen, verticeDestino))
        End If
    End Sub
End Class