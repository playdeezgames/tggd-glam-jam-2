Imports TGGDGJ2.Data

Friend MustInherit Class InventoryEntity(Of TEntityData As InventoryEntityData, TEntityType)
    Inherits TypedEntity(Of TEntityData, TEntityType)
    Implements IInventoryEntity(Of TEntityType)

    Protected Sub New(data As WorldData, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
    End Sub

    Public ReadOnly Property Items As IEnumerable(Of IItem) Implements IInventoryEntity(Of TEntityType).Items
        Get
            Return EntityData.ItemIds.Select(Function(x) New Item(Data, x, DoEvent))
        End Get
    End Property

    Public Function CreateItem(itemType As IItemType) As IItem Implements IInventoryEntity(Of TEntityType).CreateItem
        Dim itemId = Guid.NewGuid
        Dim itemData = New ItemData With
            {
                .EntityTypeName = itemType.ItemTypeName
            }
        Data.Items(itemId) = itemData
        EntityData.ItemIds.Add(itemId)
        Dim result As IItem = New Item(Data, itemId, DoEvent)
        itemType.Initialize(result)
        Return result
    End Function
End Class
