Public Interface ICharacter
    Inherits IInventoryEntity(Of ICharacterType)
    ReadOnly Property Name As String
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
    Sub StartInteration(target As ICharacter)
    Property CurrentItem As IItem
    Property InteractionTarget As ICharacter
    ReadOnly Property AvailableVerbs As IEnumerable(Of IVerbType)
    Property Weapon As IItem
    Property Armor As IItem
    ReadOnly Property HasEquipment As Boolean
    ReadOnly Property Description As IEnumerable(Of String)
    Function GetAttackValue() As Integer
    Function GetDefendValue() As Integer
    Sub Die()
    Sub Kill(defender As ICharacter)
End Interface
