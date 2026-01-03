Public Interface ICharacterType
    ReadOnly Property CharacterTypeName As String
    Sub Initialize(character As ICharacter)
    Function GetHue(character As ICharacter) As Integer
    Function CanEnter(character As ICharacter, location As ILocation) As Boolean
End Interface
