Friend Class FloorLocationType
    Inherits LocationType
    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(result As ILocation)
    End Sub

    Public Overrides Function GetHue(location As ILocation) As Integer
        Return Hue.FLOOR
    End Function

    Friend Shared ReadOnly Name As String = NameOf(FloorLocationType)
    Friend Shared ReadOnly Instance As ILocationType = New FloorLocationType
End Class
