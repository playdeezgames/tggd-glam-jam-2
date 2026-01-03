Public MustInherit Class CharacterType
    Implements ICharacterType
    Protected Sub New(characterTypeName As String)
        Me.CharacterTypeName = characterTypeName
    End Sub

    Public ReadOnly Property CharacterTypeName As String Implements ICharacterType.CharacterTypeName
    Public MustOverride Sub Initialize(character As ICharacter) Implements ICharacterType.Initialize
    Public Sub Enter(character As ICharacter, location As ILocation) Implements ICharacterType.Enter
        location.EntityType.HandleEnter(location, character)
    End Sub
    Public Sub Leave(character As ICharacter, location As ILocation) Implements ICharacterType.Leave
        location.EntityType.HandleLeave(location, character)
    End Sub
    Public Sub Bump(character As ICharacter, location As ILocation) Implements ICharacterType.Bump
        location.EntityType.HandleBump(location, character)
    End Sub
    Public MustOverride Function GetHue(character As ICharacter) As Integer Implements ICharacterType.GetHue

    Public Function CanEnter(character As ICharacter, location As ILocation) As Boolean Implements ICharacterType.CanEnter
        Return location.EntityTypeName = FloorLocationType.Name
    End Function
End Class
