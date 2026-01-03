Public MustInherit Class LocationType
    Implements ILocationType
    Protected Sub New(locationTypeName As String)
        Me.LocationTypeName = locationTypeName
    End Sub

    Public ReadOnly Property LocationTypeName As String Implements ILocationType.LocationTypeName

    Public MustOverride Sub Initialize(result As ILocation) Implements ILocationType.Initialize

    Public Overridable Sub HandleEnter(location As ILocation, character As ICharacter) Implements ILocationType.HandleEnter
    End Sub

    Public Overridable Sub HandleLeave(location As ILocation, character As ICharacter) Implements ILocationType.HandleLeave
    End Sub

    Public Overridable Sub HandleBump(location As ILocation, character As ICharacter) Implements ILocationType.HandleBump
    End Sub

    Public MustOverride Function GetHue(location As ILocation) As Integer Implements ILocationType.GetHue
End Class
