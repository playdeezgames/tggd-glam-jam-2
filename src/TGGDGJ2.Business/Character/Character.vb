Imports TGGDGJ2.Data

Friend Class Character
    Inherits InventoryEntity(Of CharacterData, ICharacterType)
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

    Public ReadOnly Property IsDead As Boolean Implements ICharacter.IsDead
        Get
            Dim health = GetCounter(Counters.Health)
            Return health IsNot Nothing AndAlso health.Value = health.Minimum
        End Get
    End Property

    Public Property CurrentItem As IItem Implements ICharacter.CurrentItem
        Get
            Return If(EntityData.CurrentItemId <> Guid.Empty, New Item(Data, EntityData.CurrentItemId, DoEvent), Nothing)
        End Get
        Set(value As IItem)
            EntityData.CurrentItemId = If(value?.ItemId, Guid.Empty)
        End Set
    End Property

    Public Property InteractionTarget As ICharacter Implements ICharacter.InteractionTarget
        Get
            Return If(
                EntityData.InteractionTargetId <> Guid.Empty,
                New Character(Data, EntityData.InteractionTargetId, DoEvent),
                Nothing)
        End Get
        Set(value As ICharacter)
            EntityData.InteractionTargetId = If(value?.CharacterId, Guid.Empty)
        End Set
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
            If CanEnter(nextLocation) Then
                Leave(currentLocation)
                currentLocation.Character = Nothing
                nextLocation.Character = Me
                Me.Location = nextLocation
                Enter(nextLocation)
            Else
                Bump(nextLocation)
            End If
        End If
    End Sub

    Public Function CanEnter(location As ILocation) As Boolean Implements ICharacter.CanEnter
        Return EntityType.CanEnter(Me, location) AndAlso location.Character Is Nothing
    End Function

    Public Sub Enter(location As ILocation) Implements ICharacter.Enter
        EntityType.Enter(Me, location)
    End Sub

    Public Sub Leave(location As ILocation) Implements ICharacter.Leave
        EntityType.Leave(Me, location)
    End Sub

    Public Sub Bump(location As ILocation) Implements ICharacter.Bump
        EntityType.Bump(Me, location)
    End Sub

    Public Sub AddMessage(title As String, ParamArray lines() As String) Implements ICharacter.AddMessage
        EntityType.AddMessage(Me, title, lines)
    End Sub

    Public Sub Update() Implements ICharacter.Update
        EntityType.Update(Me)
    End Sub

    Public Sub StartInteration(target As ICharacter) Implements ICharacter.StartInteration
        InteractionTarget = target
        EntityType.StartInteraction(Me)
    End Sub
End Class
