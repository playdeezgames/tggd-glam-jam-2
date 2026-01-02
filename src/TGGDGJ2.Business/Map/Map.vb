Imports TGGDGJ2.Data

Friend Class Map
    Inherits Entity(Of MapData)
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

    Protected Overrides ReadOnly Property EntityData As MapData
        Get
            Return Data.Maps(MapId)
        End Get
    End Property

    Public Function CreateLocation(column As Integer, row As Integer, locationType As ILocationTypeDescriptor) As ILocation Implements IMap.CreateLocation
        Dim locationId = Guid.NewGuid
        Dim locationData As New LocationData With
            {
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
