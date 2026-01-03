Public Interface ILocationType
    ReadOnly Property LocationTypeName As String
    Sub Initialize(result As ILocation)
    Function GetHue(location As ILocation) As Integer
End Interface
