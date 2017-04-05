Public Class x9Rec
  Private _recType As String
  Private _recData As String
  Private _recImage As String

  Sub New()

  End Sub

  Sub New(ByVal recType As String, ByVal recData As String, ByVal recImage As String)
    _recType = recType
    _recData = recData
    _recImage = recImage
  End Sub
  Public Property recType() As String
    Get
      Return _recType
    End Get
    Set(ByVal value As String)
      _recType = value
    End Set
  End Property

  Public Property recData() As String
    Get
      Return _recData
    End Get
    Set(ByVal value As String)
      _recData = value
    End Set
  End Property

  Public Property recImage() As String
    Get
      Return _recImage
    End Get
    Set(ByVal value As String)
      _recImage = value
    End Set
  End Property

End Class

Public Class x9Recs
  Inherits System.Collections.CollectionBase
  Public Function Add(ByVal newX9Rec As x9Rec) As Integer
    Return List.Add(newX9Rec)
  End Function
  Public Sub Remove(Optional ByVal index As Integer = -1)
    If index = -1 Then index = List.Count - 1
    If index >= 0 And index < List.Count Then
      List.RemoveAt(index)
    End If
  End Sub
  Default Public ReadOnly Property Item(ByVal index As Integer) As x9Rec
    Get
      Return CType(List.Item(index), x9Rec)
    End Get
  End Property
End Class
