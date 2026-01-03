Public Interface ILocationType
    ReadOnly Property LocationTypeName As String
    Sub Initialize(result As ILocation)
    Sub HandleEnter(location As ILocation, character As ICharacter)
    Sub HandleLeave(location As ILocation, character As ICharacter)
    Sub HandleBump(location As ILocation, character As ICharacter)
    Function GetHue(location As ILocation) As Integer
End Interface
