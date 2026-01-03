Public Interface ILocation
    Inherits ITypedEntity(Of ILocationType)
    ReadOnly Property LocationId As Guid
    Function CreateCharacter(characterType As ICharacterType) As ICharacter
    ReadOnly Property Character As ICharacter
    ReadOnly Property Hue As Integer
    ReadOnly Property Map As IMap
End Interface
