Public MustInherit Class CharacterTypeDescriptor
    Implements ICharacterTypeDescriptor
    Protected Sub New()

    End Sub

    Public MustOverride Sub Initialize(character As ICharacter) Implements ICharacterTypeDescriptor.Initialize
End Class
