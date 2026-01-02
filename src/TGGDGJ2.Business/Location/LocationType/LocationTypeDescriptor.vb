Public MustInherit Class LocationTypeDescriptor
    Implements ILocationTypeDescriptor
    Protected Sub New()

    End Sub

    Public MustOverride Sub Initialize(result As ILocation) Implements ILocationTypeDescriptor.Initialize
End Class
