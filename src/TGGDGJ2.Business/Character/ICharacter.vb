Public Interface ICharacter
    Inherits ITypedEntity(Of ICharacterType)
    ReadOnly Property CharacterId As Guid
    ReadOnly Property Map As IMap
    ReadOnly Property Hue As Integer
    ReadOnly Property Location As ILocation
End Interface
