Friend Class FoodItemType
    Inherits ItemType

    Friend Shared ReadOnly Name As String = NameOf(FoodItemType)
    Friend Shared ReadOnly Instance As IItemType = New FoodItemType

    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(result As IItem)
    End Sub

    Public Overrides Function GetHue(item As IItem) As Integer
        Return Hue.FOOD
    End Function

    Public Overrides Function GetName(item As Item) As String
        Return "Food"
    End Function
End Class
