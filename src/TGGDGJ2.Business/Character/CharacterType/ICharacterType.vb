Public Interface ICharacterType
    ReadOnly Property CharacterTypeName As String
    Sub Initialize(character As ICharacter)
    Sub Enter(character As ICharacter, location As ILocation)
    Sub Leave(character As ICharacter, location As ILocation)
    Sub Bump(character As ICharacter, location As ILocation)
    Function GetHue(character As ICharacter) As Integer
    Function CanEnter(character As ICharacter, location As ILocation) As Boolean
End Interface
