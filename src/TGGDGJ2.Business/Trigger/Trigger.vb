Imports TGGDGJ2.Data

Public Class Trigger
    Inherits TypedEntity(Of TriggerData, ITriggerType)
    Implements ITrigger

    Public Sub New(data As WorldData, triggerId As Guid, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
        Me.TriggerId = triggerId
    End Sub

    Public Overrides ReadOnly Property EntityType As ITriggerType
        Get
            Return World.GetTriggerType(EntityData.EntityTypeName)
        End Get
    End Property

    Public ReadOnly Property TriggerId As Guid Implements ITrigger.TriggerId

    Protected Overrides ReadOnly Property EntityData As TriggerData
        Get
            Return Data.Triggers(TriggerId)
        End Get
    End Property

    Public Sub Fire(Optional character As ICharacter = Nothing, Optional location As ILocation = Nothing) Implements ITrigger.Fire
        EntityType.Fire(Me, character, location)
    End Sub

    Public Sub SetMessage(ParamArray lines() As String) Implements ITrigger.SetMessage
        EntityData.Lines = lines
    End Sub

    Public Function GetMessage() As String() Implements ITrigger.GetMessage
        Return EntityData.Lines
    End Function
End Class
