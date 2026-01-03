Imports TGGDGJ2.Data

Friend Class Character
    Inherits TypedEntity(Of CharacterData, ICharacterType)
    Implements ICharacter

    Public Sub New(
                  data As WorldData,
                  characterId As Guid,
                  doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
        Me.CharacterId = characterId
    End Sub

    Public ReadOnly Property CharacterId As Guid Implements ICharacter.CharacterId

    Public Overrides ReadOnly Property EntityType As ICharacterType
        Get
            Return World.GetCharacterType(EntityTypeName)
        End Get
    End Property

    Public ReadOnly Property Map As IMap Implements ICharacter.Map
        Get
            Return Location.Map
        End Get
    End Property

    Public ReadOnly Property Hue As Integer Implements ICharacter.Hue
        Get
            Return EntityType.GetHue(Me)
        End Get
    End Property

    Public ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return If(
                EntityData.LocationId <> Guid.Empty,
                New Location(Data, EntityData.LocationId, DoEvent),
                Nothing)
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As CharacterData
        Get
            Return Data.Characters(CharacterId)
        End Get
    End Property
End Class
