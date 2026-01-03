Friend Class N00bCharacterType
    Inherits CharacterType

    Public Overrides Sub Initialize(character As ICharacter)
    End Sub

    Friend Shared ReadOnly Instance As ICharacterType = New N00bCharacterType()
    Friend Shared ReadOnly Name As String = NameOf(N00bCharacterType)

    Public Sub New()
        MyBase.New(Name)
    End Sub
End Class
