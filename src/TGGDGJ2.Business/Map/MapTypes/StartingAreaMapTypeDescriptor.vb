Friend Class StartingAreaMapTypeDescriptor
    Inherits MapTypeDescriptor

    Private Sub New()
        MyBase.New(NameOf(StartingAreaMapTypeDescriptor))
    End Sub

    Friend Shared ReadOnly Instance As New StartingAreaMapTypeDescriptor
End Class
