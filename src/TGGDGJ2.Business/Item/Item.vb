Imports TGGDGJ2.Data

Public Class Item
    Inherits TypedEntity(Of ItemData, IItemType)
    Implements IItem

    Public Sub New(data As WorldData, itemId As Guid, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
        Me.ItemId = itemId
    End Sub

    Public Overrides ReadOnly Property EntityType As IItemType
        Get
            Return World.GetItemType(EntityTypeName)
        End Get
    End Property

    Public ReadOnly Property ItemId As Guid Implements IItem.ItemId

    Public ReadOnly Property Hue As Integer Implements IItem.Hue
        Get
            Return EntityType.GetHue(Me)
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IItem.Name
        Get
            Return EntityType.GetName(Me)
        End Get
    End Property

    Public ReadOnly Property Description As IEnumerable(Of String) Implements IItem.Description
        Get
            Return EntityType.GetDescription(Me)
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As ItemData
        Get
            Return Data.Items(ItemId)
        End Get
    End Property

    Public Overrides Sub Destroy()
        MyBase.Destroy()
        Data.Items.Remove(ItemId)
    End Sub
End Class
