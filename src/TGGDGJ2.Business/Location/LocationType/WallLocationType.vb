Friend Class WallLocationType
    Inherits LocationType

    Public Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(result As ILocation)
    End Sub

    Public Overrides Function GetHue(location As ILocation) As Integer
        Return Asc("#")
    End Function

    Friend Shared ReadOnly Name As String = NameOf(WallLocationType)
    Friend Shared ReadOnly Instance As ILocationType = New WallLocationType
End Class
