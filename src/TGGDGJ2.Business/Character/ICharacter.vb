Public Interface ICharacter
    Inherits IInventoryEntity(Of ICharacterType)
    ReadOnly Property CharacterId As Guid
    ReadOnly Property Map As IMap
    ReadOnly Property Hue As Integer
    Property Location As ILocation
    Sub TryMove(directionName As String)
    Function CanEnter(location As ILocation) As Boolean
    Sub Enter(location As ILocation)
    Sub Leave(location As ILocation)
    Sub Bump(location As ILocation)
    ReadOnly Property IsDead As Boolean
    Sub AddMessage(title As String, ParamArray lines As String())
    Sub Update()
    Property CurrentItem As IItem
End Interface
