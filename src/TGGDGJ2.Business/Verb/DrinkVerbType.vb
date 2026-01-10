Friend Class DrinkVerbType
    Inherits VerbType

    Friend Shared ReadOnly Instance As IVerbType = New DrinkVerbType

    Private Sub New()
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Drink"
        End Get
    End Property

    Public Overrides Sub Perform(character As ICharacter)
        Dim item = character.CurrentItem
        character.RemoveItem(item)
        item.Destroy()
        character.CurrentItem = Nothing
        character.AddMessage("Glunk!", "*BURP*!")
        Dim health = character.GetCounter(Counters.Health)
        health.Value = health.Maximum
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return True
    End Function
End Class
