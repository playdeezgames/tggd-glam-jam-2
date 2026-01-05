Public Interface IItem
    Inherits ITypedEntity(Of IItemType)
    ReadOnly Property ItemId As Guid
    ReadOnly Property Hue As Integer
End Interface
