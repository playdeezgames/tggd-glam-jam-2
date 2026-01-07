Public Interface IItemType
    ReadOnly Property ItemTypeName As String
    Sub Initialize(result As IItem)
    Function GetHue(item As IItem) As Integer
    Function GetName(item As Item) As String
    Function GetDescription(item As Item) As IEnumerable(Of String)
End Interface
