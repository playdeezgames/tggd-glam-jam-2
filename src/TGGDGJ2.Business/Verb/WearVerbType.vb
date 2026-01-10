Friend Class WearVerbType
    Inherits VerbType
    Friend Shared ReadOnly Instance As IVerbType = New WearVerbType
    Private Sub New()

    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Wear"
        End Get
    End Property

    Public Overrides Sub Perform(character As ICharacter)
        character.Armor = character.CurrentItem
        character.RemoveItem(character.CurrentItem)
        character.CurrentItem = Nothing
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return character.Armor Is Nothing
    End Function
End Class
