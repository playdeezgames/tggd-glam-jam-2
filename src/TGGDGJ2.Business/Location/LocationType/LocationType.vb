Public MustInherit Class LocationType
    Implements ILocationType
    Protected Sub New(locationTypeName As String)
        Me.LocationTypeName = locationTypeName
    End Sub

    Public ReadOnly Property LocationTypeName As String Implements ILocationType.LocationTypeName

    Public MustOverride Sub Initialize(result As ILocation) Implements ILocationType.Initialize
End Class
