Public MustInherit Class CharacterType
    Implements ICharacterType
    Protected Sub New(characterTypeName As String)
        Me.CharacterTypeName = characterTypeName
    End Sub

    Public ReadOnly Property CharacterTypeName As String Implements ICharacterType.CharacterTypeName
    Public MustOverride Sub Initialize(character As ICharacter) Implements ICharacterType.Initialize
    Public MustOverride Function GetHue(character As ICharacter) As Integer Implements ICharacterType.GetHue

    Public Function CanEnter(character As ICharacter, location As ILocation) As Boolean Implements ICharacterType.CanEnter
        Return location.EntityTypeName = FloorLocationType.Name
    End Function
End Class
