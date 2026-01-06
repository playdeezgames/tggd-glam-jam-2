Friend Class TeleportTriggerType
    Inherits TriggerType

    Friend Shared ReadOnly Name As String = NameOf(TeleportTriggerType)
    Friend Shared ReadOnly Instance As ITriggerType = New TeleportTriggerType

    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(trigger As ITrigger)
    End Sub

    Public Overrides Sub Fire(trigger As ITrigger, character As ICharacter, location As ILocation)
        Dim destination = trigger.Destination
        character.Location = destination
        destination.Character = character
        location.Character = Nothing
    End Sub
End Class
