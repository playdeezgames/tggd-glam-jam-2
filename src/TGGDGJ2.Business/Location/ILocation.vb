Public Interface ILocation
    Inherits IEntity
    ReadOnly Property LocationId As Guid
    Function CreateCharacter(characterType As ICharacterType) As ICharacter
End Interface
