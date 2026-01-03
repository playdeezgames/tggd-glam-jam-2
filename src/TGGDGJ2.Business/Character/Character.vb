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

    Public Property Location As ILocation Implements ICharacter.Location
        Get
            Return If(
                EntityData.LocationId <> Guid.Empty,
                New Location(Data, EntityData.LocationId, DoEvent),
                Nothing)
        End Get
        Set(value As ILocation)
            If value Is Nothing Then
                EntityData.LocationId = Guid.Empty
            Else
                EntityData.LocationId = value.LocationId
            End If
        End Set
    End Property

    Protected Overrides ReadOnly Property EntityData As CharacterData
        Get
            Return Data.Characters(CharacterId)
        End Get
    End Property

    Private ReadOnly DeltaX As IReadOnlyDictionary(Of String, Integer) =
        New Dictionary(Of String, Integer) From
        {
            {Direction.North, 0},
            {Direction.East, 1},
            {Direction.South, 0},
            {Direction.West, -1}
        }
    Private ReadOnly DeltaY As IReadOnlyDictionary(Of String, Integer) =
        New Dictionary(Of String, Integer) From
        {
            {Direction.North, -1},
            {Direction.East, 0},
            {Direction.South, 1},
            {Direction.West, 0}
        }

    Public Sub TryMove(directionName As String) Implements ICharacter.TryMove
        Dim currentLocation = Me.Location
        Dim nextColumn = currentLocation.Column + DeltaX(directionName)
        Dim nextRow = currentLocation.Row + DeltaY(directionName)
        Dim nextLocation = Map.GetLocation(nextColumn, nextRow)
        If nextLocation IsNot Nothing Then
            currentLocation.Character = Nothing
            nextLocation.Character = Me
            Me.Location = nextLocation
        End If
    End Sub
End Class
