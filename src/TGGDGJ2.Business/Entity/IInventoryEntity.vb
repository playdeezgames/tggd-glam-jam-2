Public Interface IInventoryEntity(Of TEntityType)
    Inherits ITypedEntity(Of TEntityType)
    Function CreateItem(itemType As IItemType) As IItem
    ReadOnly Property Items As IEnumerable(Of IItem)
End Interface
