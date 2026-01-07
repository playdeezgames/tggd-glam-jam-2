Public MustInherit Class ItemType
    Implements IItemType

    Protected Sub New(itemTypeName As String)
        Me.ItemTypeName = itemTypeName
    End Sub

    Public ReadOnly Property ItemTypeName As String Implements IItemType.ItemTypeName
    Public MustOverride ReadOnly Property VerbTypes As IEnumerable(Of IVerbType) Implements IItemType.VerbTypes
    Public MustOverride Sub Initialize(result As IItem) Implements IItemType.Initialize
    Public MustOverride Function GetHue(item As IItem) As Integer Implements IItemType.GetHue
    Public MustOverride Function GetName(item As Item) As String Implements IItemType.GetName
    Public MustOverride Function GetDescription(item As Item) As IEnumerable(Of String) Implements IItemType.GetDescription
End Class
