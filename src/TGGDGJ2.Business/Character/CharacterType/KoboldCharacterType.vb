Public Class KoboldCharacterType
    Inherits CharacterType

    Friend Shared ReadOnly Name As String = NameOf(KoboldCharacterType)
    Friend Shared ReadOnly Instance As ICharacterType = New KoboldCharacterType

    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(character As ICharacter)
    End Sub

    Public Overrides Sub AddMessage(character As ICharacter, title As String, ParamArray lines() As String)
    End Sub

    Public Overrides Function GetHue(character As ICharacter) As Integer
        Return Hue.KOBOLD
    End Function
End Class
