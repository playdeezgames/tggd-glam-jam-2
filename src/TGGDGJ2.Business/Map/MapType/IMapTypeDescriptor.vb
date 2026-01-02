Public Interface IMapTypeDescriptor
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    Sub Initialize(result As IMap)
End Interface
