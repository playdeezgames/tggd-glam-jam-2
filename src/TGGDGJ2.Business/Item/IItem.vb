Public Interface IItem
    Inherits ITypedEntity(Of IItemType)
    ReadOnly Property ItemId As Guid
    ReadOnly Property Hue As Integer
    ReadOnly Property Name As String
    ReadOnly Property Description As IEnumerable(Of String)
    ReadOnly Property AvailableVerbs As IEnumerable(Of IVerbType)
End Interface
