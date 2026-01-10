Friend Class WieldVerbType
    Inherits VerbType
    Friend Shared ReadOnly Instance As IVerbType = New WieldVerbType
    Private Sub New()

    End Sub


    Public Overrides ReadOnly Property Name As String
        Get
            Return "Wield"
        End Get
    End Property

    Public Overrides Sub Perform(character As ICharacter)
        character.Weapon = character.CurrentItem
        character.RemoveItem(character.CurrentItem)
        character.CurrentItem = Nothing
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return character.Weapon Is Nothing
    End Function
End Class
