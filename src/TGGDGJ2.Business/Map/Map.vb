Imports TGGDGJ2.Data

Friend Class Map
    Inherits TypedEntity(Of MapData, IMapType)
    Implements IMap

    Public Sub New(data As WorldData, mapId As Guid, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
        Me.MapId = mapId
    End Sub

    Public ReadOnly Property MapId As Guid Implements IMap.MapId

    Public ReadOnly Property Columns As Integer Implements IMap.Columns
        Get
            Return EntityData.Columns
        End Get
    End Property

    Public ReadOnly Property Rows As Integer Implements IMap.Rows
        Get
            Return EntityData.Rows
        End Get
    End Property

    Public Overrides ReadOnly Property EntityType As IMapType
        Get
            Return World.GetMapType(EntityTypeName)
        End Get
    End Property

    Public ReadOnly Property Locations As IEnumerable(Of ILocation) Implements IMap.Locations
        Get
            Return EntityData.LocationIds.Distinct.Where(Function(x) x <> Guid.Empty).Select(Function(x) New Location(Data, x, DoEvent))
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As MapData
        Get
            Return Data.Maps(MapId)
        End Get
    End Property

    Public Sub SetLocation(column As Integer, row As Integer, location As ILocation) Implements IMap.SetLocation
        EntityData.LocationIds(column + row * Columns) = If(location IsNot Nothing, location.LocationId, Guid.Empty)
    End Sub

    Public Sub Update() Implements IMap.Update
        Dim updatedCharacterIds As New HashSet(Of Guid)
        For Each location In Locations
            Dim character = location.Character
            If character IsNot Nothing AndAlso Not updatedCharacterIds.Contains(character.CharacterId) Then
                updatedCharacterIds.Add(character.CharacterId)
                character.Update()
            End If
        Next
    End Sub

    Public Function CreateLocation(column As Integer, row As Integer, locationType As ILocationType) As ILocation Implements IMap.CreateLocation
        Dim locationId = Guid.NewGuid
        Dim locationData As New LocationData With
            {
                .EntityTypeName = locationType.LocationTypeName,
                .MapId = MapId,
                .Column = column,
                .Row = row
            }
        Data.Locations(locationId) = locationData
        EntityData.LocationIds(column + row * Columns) = locationId
        Dim result As New Location(Data, locationId, DoEvent)
        locationType.Initialize(result)
        Return result
    End Function

    Public Function GetLocation(column As Integer, row As Integer) As ILocation Implements IMap.GetLocation
        If column < 0 OrElse row < 0 OrElse column >= Columns OrElse row >= Rows Then
            Return Nothing
        End If
        Dim locationId = EntityData.LocationIds(column + row * Columns)
        If locationId = Guid.Empty Then
            Return Nothing
        End If
        Return New Location(Data, locationId, DoEvent)
    End Function
End Class
