Imports TGGDGJ2.Data

Friend Class Location
    Inherits TypedEntity(Of LocationData, ILocationType)
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
End Class
