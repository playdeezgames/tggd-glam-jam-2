Friend Class SlugCharacterType
    Inherits CharacterType


    Friend Shared ReadOnly Name As String = NameOf(SlugCharacterType)
    Friend Shared ReadOnly Instance As ICharacterType = New SlugCharacterType()

    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides ReadOnly Property VerbTypes As IEnumerable(Of IVerbType)
        Get
            Return {
                AttackVerbType.Instance
                }
        End Get
    End Property

    Public Overrides Sub Initialize(character As ICharacter)
        character.CreateCounter(Counters.Health, 10, 0, 10)
    End Sub

    Public Overrides Sub AddMessage(character As ICharacter, title As String, ParamArray lines() As String)
    End Sub

    Public Overrides Sub Update(character As ICharacter)
    End Sub

    Public Overrides Sub StartInteraction(character As ICharacter)
    End Sub

    Public Overrides Sub Die(character As ICharacter)
        character.Location.Character = Nothing
        character.Destroy()
    End Sub

    Public Overrides Function GetHue(character As ICharacter) As Integer
        Return Hue.SLUG
    End Function

    Public Overrides Function GetName(character As ICharacter) As String
        Return "Slug"
    End Function

    Public Overrides Function GetDescription(character As ICharacter) As IEnumerable(Of String)
        Return {
            "It is a slug.",
            "It is gooey and sluggy.",
            "It looks fairly harmless and entirely smushable."}
    End Function
End Class
