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

    Public Property Title As String Implements ITrigger.Title
        Get
            Return EntityData.Title
        End Get
        Set(value As String)
            EntityData.Title = value
        End Set
    End Property

    Public Property NextLocation As ILocation Implements ITrigger.NextLocation
        Get
            Dim locationId As Guid = Guid.Empty
            If EntityData.EntityYokes.TryGetValue(Yokes.NextLocation, locationId) Then
                Return New Location(Data, locationId, DoEvent)
            End If
            Return Nothing
        End Get
        Set(value As ILocation)
            If value Is Nothing Then
                EntityData.EntityYokes.Remove(Yokes.NextLocation)
            Else
                EntityData.EntityYokes(Yokes.NextLocation) = value.LocationId
            End If
        End Set
    End Property

    Protected Overrides ReadOnly Property EntityData As TriggerData
        Get
            Return Data.Triggers(TriggerId)
        End Get
    End Property

    Public Property Destination As ILocation Implements ITrigger.Destination
        Get
            Dim locationId As Guid = Guid.Empty
            If EntityData.EntityYokes.TryGetValue(Yokes.Destination, locationId) Then
                Return New Location(Data, locationId, DoEvent)
            End If
            Return Nothing
        End Get
        Set(value As ILocation)
            If value Is Nothing Then
                EntityData.EntityYokes.Remove(Yokes.Destination)
            Else
                EntityData.EntityYokes(Yokes.Destination) = value.LocationId
            End If
        End Set
    End Property

    Public Sub Fire(Optional character As ICharacter = Nothing, Optional location As ILocation = Nothing) Implements ITrigger.Fire
        EntityType.Fire(Me, character, location)
    End Sub

    Public Sub SetMessage(title As String, ParamArray lines() As String) Implements ITrigger.SetMessage
        EntityData.Title = title
        EntityData.Lines = lines
    End Sub

    Public Function GetMessage() As String() Implements ITrigger.GetMessage
        Return EntityData.Lines
    End Function

    Public Overrides Sub Destroy()
        MyBase.Destroy()
        Data.Triggers.Remove(TriggerId)
    End Sub
End Class
