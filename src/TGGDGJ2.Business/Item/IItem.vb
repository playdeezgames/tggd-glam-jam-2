Public Interface IItem
    Inherits ITypedEntity(Of IItemType)
    ReadOnly Property ItemId As Guid
    ReadOnly Property Hue As Integer
    ReadOnly Property Name As String
End Interface
