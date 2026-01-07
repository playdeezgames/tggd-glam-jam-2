Public Class EatVerbType
    Inherits VerbType
    Friend Shared ReadOnly Instance As IVerbType = New EatVerbType
    Private Sub New()

    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Eat"
        End Get
    End Property

    Public Overrides Sub Perform(character As ICharacter)
        Dim item = character.CurrentItem
        character.RemoveItem(item)
        item.Destroy()
        character.CurrentItem = Nothing
        character.AddMessage("Nom!", "Tasty!")
        Dim satiety = character.GetCounter(Counters.Satiety)
        satiety.Value = satiety.Maximum
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return character.CurrentItem IsNot Nothing AndAlso character.CurrentItem.EntityTypeName = FoodItemType.Name
    End Function
End Class
