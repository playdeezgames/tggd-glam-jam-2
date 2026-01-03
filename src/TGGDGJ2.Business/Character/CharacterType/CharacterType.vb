Public MustInherit Class CharacterType
    Implements ICharacterType
    Protected Sub New(characterTypeName As String)
        Me.CharacterTypeName = characterTypeName
    End Sub

    Public ReadOnly Property CharacterTypeName As String Implements ICharacterType.CharacterTypeName

    Public MustOverride Sub Initialize(character As ICharacter) Implements ICharacterType.Initialize
End Class
