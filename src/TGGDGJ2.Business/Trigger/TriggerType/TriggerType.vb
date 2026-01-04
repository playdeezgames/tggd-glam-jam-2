Friend MustInherit Class TriggerType
    Implements ITriggerType

    Protected Sub New(triggerTypeName As String)
        Me.TriggerTypeName = triggerTypeName
    End Sub

    Public ReadOnly Property TriggerTypeName As String Implements ITriggerType.TriggerTypeName
    Public MustOverride Sub Initialize(trigger As ITrigger) Implements ITriggerType.Initialize
    Public MustOverride Sub Fire(trigger As ITrigger, character As ICharacter, location As ILocation) Implements ITriggerType.Fire
End Class
