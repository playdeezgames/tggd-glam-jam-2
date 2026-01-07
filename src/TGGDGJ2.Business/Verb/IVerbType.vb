Public Interface IVerbType
    ReadOnly Property Name As String
    Sub Perform(avatar As ICharacter)
    Function CanPerform(avatar As ICharacter) As Boolean
End Interface
