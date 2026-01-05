Public Interface IItemType
    ReadOnly Property ItemTypeName As String
    Sub Initialize(result As IItem)
    Function GetHue(item As IItem) As Integer
End Interface
