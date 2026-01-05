Public Class KeyItemType
    Inherits ItemType
    Public Shared ReadOnly Name As String = NameOf(KeyItemType)
    Public Shared ReadOnly Instance As IItemType = New KeyItemType
    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(result As IItem)
    End Sub

    Public Overrides Function GetHue(item As IItem) As Integer
        Return Hue.KEY
    End Function
End Class
