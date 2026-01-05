Friend Class UnlockedDoorLocationType
    Inherits LocationType

    Friend Shared ReadOnly Name As String = NameOf(UnlockedDoorLocationType)
    Friend Shared ReadOnly Instance As ILocationType = New UnlockedDoorLocationType

    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(result As ILocation)
    End Sub

    Public Overrides Function GetHue(location As ILocation) As Integer
        Return Hue.OPEN_DOOR
    End Function
End Class
