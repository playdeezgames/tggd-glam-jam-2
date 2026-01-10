Public MustInherit Class CharacterType
    Implements ICharacterType
    Protected Sub New(characterTypeName As String)
        Me.CharacterTypeName = characterTypeName
    End Sub

    Public ReadOnly Property CharacterTypeName As String Implements ICharacterType.CharacterTypeName
    Public MustOverride ReadOnly Property VerbTypes As IEnumerable(Of IVerbType) Implements ICharacterType.VerbTypes
    Public MustOverride Sub Initialize(character As ICharacter) Implements ICharacterType.Initialize
    Public Overridable Sub Enter(character As ICharacter, location As ILocation) Implements ICharacterType.Enter
        location.EntityType.HandleEnter(location, character)
    End Sub
    Public Overridable Sub Leave(character As ICharacter, location As ILocation) Implements ICharacterType.Leave
        location.EntityType.HandleLeave(location, character)
    End Sub
    Public Overridable Sub Bump(character As ICharacter, location As ILocation) Implements ICharacterType.Bump
        location.EntityType.HandleBump(location, character)
    End Sub

    Public MustOverride Sub AddMessage(character As ICharacter, title As String, ParamArray lines() As String) Implements ICharacterType.AddMessage
    Public MustOverride Sub Update(character As ICharacter) Implements ICharacterType.Update
    Public MustOverride Sub StartInteraction(character As ICharacter) Implements ICharacterType.StartInteraction
    Public MustOverride Sub Die(character As ICharacter) Implements ICharacterType.Die
    Public MustOverride Function GetHue(character As ICharacter) As Integer Implements ICharacterType.GetHue

    Public Function CanEnter(character As ICharacter, location As ILocation) As Boolean Implements ICharacterType.CanEnter
        Return location.EntityTypeName = FloorLocationType.Name
    End Function

    Public MustOverride Function GetName(character As ICharacter) As String Implements ICharacterType.GetName
    Public MustOverride Function GetDescription(character As ICharacter) As IEnumerable(Of String) Implements ICharacterType.GetDescription
End Class
