Public Interface ITrigger
    Inherits ITypedEntity(Of ITriggerType)
    ReadOnly Property TriggerId As Guid
    Sub Fire(Optional character As ICharacter = Nothing, Optional location As ILocation = Nothing)
    Sub SetMessage(title As String, ParamArray lines As String())
    Function GetMessage() As String()
    Property Title As String
    Property NextLocation As ILocation
End Interface
