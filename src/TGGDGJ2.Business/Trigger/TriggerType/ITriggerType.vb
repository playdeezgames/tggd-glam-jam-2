Public Interface ITriggerType
    ReadOnly Property TriggerTypeName As String
    Sub Initialize(trigger As ITrigger)
    Sub Fire(trigger As ITrigger, character As ICharacter, location As ILocation)
End Interface
