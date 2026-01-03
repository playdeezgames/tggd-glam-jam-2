Friend Class FloorLocationType
    Inherits LocationType
    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(result As ILocation)
    End Sub

    Friend Shared ReadOnly Instance As ILocationType = New FloorLocationType
    Friend Shared ReadOnly Name As String = NameOf(FloorLocationType)
End Class
