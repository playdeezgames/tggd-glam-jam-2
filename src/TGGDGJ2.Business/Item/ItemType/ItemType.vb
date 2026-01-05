Public MustInherit Class ItemType
    Implements IItemType

    Protected Sub New(itemTypeName As String)
        Me.ItemTypeName = itemTypeName
    End Sub

    Public ReadOnly Property ItemTypeName As String Implements IItemType.ItemTypeName
    Public MustOverride Sub Initialize(result As IItem) Implements IItemType.Initialize
    Public MustOverride Function GetHue(item As IItem) As Integer Implements IItemType.GetHue
End Class
