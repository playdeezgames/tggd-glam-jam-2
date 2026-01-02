Friend Class FloorLocationTypeDescriptor
    Inherits LocationTypeDescriptor
    Private Sub New()

    End Sub

    Public Overrides Sub Initialize(result As ILocation)
    End Sub

    Friend Shared ReadOnly Instance As ILocationTypeDescriptor = New FloorLocationTypeDescriptor
End Class
