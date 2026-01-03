Public Interface IMapType
    ReadOnly Property MapTypeName As String
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    Sub Initialize(result As IMap)
End Interface
