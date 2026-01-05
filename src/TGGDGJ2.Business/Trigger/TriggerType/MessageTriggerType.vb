Friend Class MessageTriggerType
    Inherits TriggerType

    Friend Shared ReadOnly Name As String = NameOf(MessageTriggerType)
    Friend Shared ReadOnly Instance As ITriggerType = New MessageTriggerType()

    Public Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(trigger As ITrigger)
    End Sub

    Public Overrides Sub Fire(trigger As ITrigger, character As ICharacter, location As ILocation)
        character.AddMessage(trigger.Title, trigger.GetMessage())
    End Sub
End Class
