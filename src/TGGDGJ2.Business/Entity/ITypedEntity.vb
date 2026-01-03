Public Interface ITypedEntity(Of TEntityType)
    Inherits IEntity
    ReadOnly Property EntityTypeName As String
    ReadOnly Property EntityType As TEntityType
End Interface
