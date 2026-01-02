Public Interface ILocation
    Inherits IEntity
    ReadOnly Property LocationId As Guid
    Function CreateCharacter(characterType As ICharacterTypeDescriptor) As ICharacter
End Interface
