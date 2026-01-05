Friend Class UnlockTriggerType
    Inherits TriggerType

    Friend Shared ReadOnly Name As String = NameOf(UnlockTriggerType)
    Friend Shared ReadOnly Instance As ITriggerType = New UnlockTriggerType

    Public Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(trigger As ITrigger)
    End Sub

    Public Overrides Sub Fire(trigger As ITrigger, character As ICharacter, location As ILocation)
        Dim key = character.Items.FirstOrDefault(Function(x) x.EntityTypeName = KeyItemType.Name)
        If key Is Nothing Then
            character.AddMessage("Door is Locked!", "You need a key!")
            Return
        End If
    End Sub
End Class
