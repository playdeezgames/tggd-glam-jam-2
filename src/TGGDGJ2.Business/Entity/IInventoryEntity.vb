Public Interface IInventoryEntity(Of TEntityType)
    Inherits ITypedEntity(Of TEntityType)
    Function CreateItem(itemType As IItemType) As IItem
    ReadOnly Property Items As IEnumerable(Of IItem)
    Sub AddItem(item As IItem)
    Sub RemoveItem(item As IItem)
    ReadOnly Property HasItems As Boolean
End Interface
