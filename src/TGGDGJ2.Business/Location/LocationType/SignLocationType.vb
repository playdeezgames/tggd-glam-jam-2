Public Class SignLocationType
    Inherits LocationType

    Friend Shared ReadOnly Name As String = NameOf(SignLocationType)
    Friend Shared ReadOnly Instance As ILocationType = New SignLocationType

    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(result As ILocation)
    End Sub

    Public Overrides Function GetHue(location As ILocation) As Integer
        Return Hue.SIGN
    End Function
End Class
