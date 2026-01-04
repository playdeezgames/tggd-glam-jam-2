Friend Class LockedDoorLocationType
    Inherits LocationType
    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(result As ILocation)
    End Sub

    Public Overrides Function GetHue(location As ILocation) As Integer
        Return Hue.LOCKED_DOOR
    End Function

    Friend Shared ReadOnly Name As String = NameOf(LockedDoorLocationType)
    Friend Shared ReadOnly Instance As ILocationType = New LockedDoorLocationType
End Class
