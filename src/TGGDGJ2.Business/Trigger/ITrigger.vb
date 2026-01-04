Public Interface ITrigger
    Inherits ITypedEntity(Of ITriggerType)
    ReadOnly Property TriggerId As Guid
    Sub Fire(Optional character As ICharacter = Nothing, Optional location As ILocation = Nothing)
    Sub SetMessage(ParamArray lines As String())
    Function GetMessage() As String()
End Interface
