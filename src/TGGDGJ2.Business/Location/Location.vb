Imports TGGDGJ2.Data

Friend Class Location
    Inherits InventoryEntity(Of LocationData, ILocationType)
    Implements ILocation


    Public Sub New(data As WorldData, locationId As Guid, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
        Me.LocationId = locationId
    End Sub

    Public ReadOnly Property LocationId As Guid Implements ILocation.LocationId

    Public Overrides ReadOnly Property EntityType As ILocationType
        Get
            Return World.GetLocationType(EntityTypeName)
        End Get
    End Property

    Public Property Character As ICharacter Implements ILocation.Character
        Get
            Return If(EntityData.CharacterId <> Guid.Empty, New Character(Data, EntityData.CharacterId, DoEvent), Nothing)
        End Get
        Set(value As ICharacter)
            EntityData.CharacterId = If(value?.CharacterId, Guid.Empty)
        End Set
    End Property

    Public ReadOnly Property Hue As Integer Implements ILocation.Hue
        Get
            Return EntityType.GetHue(Me)
        End Get
    End Property

    Public ReadOnly Property Map As IMap Implements ILocation.Map
        Get
            Return If(EntityData.MapId <> Guid.Empty, New Map(Data, EntityData.MapId, DoEvent), Nothing)
        End Get
    End Property

    Public ReadOnly Property Column As Integer Implements ILocation.Column
        Get
            Return EntityData.Column
        End Get
    End Property

    Public ReadOnly Property Row As Integer Implements ILocation.Row
        Get
            Return EntityData.Row
        End Get
    End Property

    Public Property BumpTrigger As ITrigger Implements ILocation.BumpTrigger
        Get
            Dim triggerId As Guid = Guid.Empty
            If EntityData.EntityYokes.TryGetValue(Yokes.BumpTrigger, triggerId) Then
                Return New Trigger(Data, triggerId, DoEvent)
            End If
            Return Nothing
        End Get
        Set(value As ITrigger)
            If value Is Nothing Then
                EntityData.EntityYokes.Remove(Yokes.BumpTrigger)
            Else
                EntityData.EntityYokes(Yokes.BumpTrigger) = value.TriggerId
            End If
        End Set
    End Property

    Protected Overrides ReadOnly Property EntityData As LocationData
        Get
            Return Data.Locations(LocationId)
        End Get
    End Property

    Public Function CreateCharacter(characterType As ICharacterType) As ICharacter Implements ILocation.CreateCharacter
        Dim characterId = Guid.NewGuid
        Dim characterData = New CharacterData With
            {
                .EntityTypeName = characterType.CharacterTypeName,
                .LocationId = LocationId
            }
        Data.Characters(characterId) = characterData
        EntityData.CharacterId = characterId
        Dim result As ICharacter = New Character(Data, characterId, DoEvent)
        characterType.Initialize(result)
        Return result
    End Function

    Public Function CreateTrigger(triggerType As ITriggerType) As ITrigger Implements ILocation.CreateTrigger
        Dim triggerId = Guid.NewGuid
        Dim triggerData = New TriggerData With
            {
                .EntityTypeName = triggerType.TriggerTypeName
            }
        Data.Triggers(triggerId) = triggerData
        Dim result As ITrigger = New Trigger(Data, triggerId, DoEvent)
        triggerType.Initialize(result)
        Return result
    End Function

    Public Overrides Sub Destroy()
        MyBase.Destroy()
        Data.Locations.Remove(LocationId)
    End Sub
End Class
