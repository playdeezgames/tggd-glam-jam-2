Public Interface ICharacterType
    ReadOnly Property CharacterTypeName As String
    Sub Initialize(character As ICharacter)
    Function GetHue(character As ICharacter) As Integer
End Interface
