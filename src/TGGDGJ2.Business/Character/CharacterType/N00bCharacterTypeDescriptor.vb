Friend Class N00bCharacterTypeDescriptor
    Inherits CharacterTypeDescriptor

    Public Overrides Sub Initialize(character As ICharacter)
    End Sub

    Friend Shared ReadOnly Instance As ICharacterTypeDescriptor = New N00bCharacterTypeDescriptor()
End Class
