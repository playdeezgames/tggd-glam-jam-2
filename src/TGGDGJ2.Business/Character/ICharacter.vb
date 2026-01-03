Public Interface ICharacter
    Inherits ITypedEntity(Of ICharacterType)
    ReadOnly Property CharacterId As Guid
    ReadOnly Property Map As IMap
    ReadOnly Property Hue As Integer
    Property Location As ILocation
    Sub TryMove(directionName As String)
    Function CanEnter(location As ILocation) As Boolean
End Interface
