Imports TGGDGJ2.Data

Public Class World
    Inherits Entity(Of WorldData)
    Implements IWorld
    Sub New(data As WorldData, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
    End Sub

    Public Property Avatar As ICharacter Implements IWorld.Avatar
        Get
            Dim characterId = Data.AvatarCharacterId
            If characterId = Guid.Empty Then
                Return Nothing
            End If
            Return New Character(Data, characterId, DoEvent)
        End Get
        Set(value As ICharacter)
            If value Is Nothing Then
                Data.AvatarCharacterId = Guid.Empty
            Else
                Data.AvatarCharacterId = value.CharacterId
            End If
        End Set
    End Property

    Protected Overrides ReadOnly Property EntityData As WorldData
        Get
            Return Data
        End Get
    End Property

    Public Sub Initialize() Implements IWorld.Initialize
        Clear()
        Dim startingMap = CreateMap(StartingAreaMapType.Instance)
    End Sub

    Public Function CreateMap(mapType As IMapType) As IMap Implements IWorld.CreateMap
        Dim mapId = Guid.NewGuid()
        Dim mapData As New MapData With
            {
                .EntityTypeName = mapType.MapTypeName,
                .Columns = mapType.Columns,
                .Rows = mapType.Rows,
                .LocationIds = Enumerable.Repeat(Guid.Empty, mapType.Columns * mapType.Rows).ToList
            }
        Data.Maps(mapId) = mapData
        Dim result As New Map(Data, mapId, DoEvent)
        mapType.Initialize(result)
        Return result
    End Function

    Public Function GetMapType(mapTypeName As String) As IMapType Implements IWorld.GetMapType
        Return mapTypes(mapTypeName)
    End Function

    Public Function GetLocationType(locationTypeName As String) As ILocationType Implements IWorld.GetLocationType
        Return locationTypes(locationTypeName)
    End Function

    Public Function GetCharacterType(characterTypeName As String) As ICharacterType Implements IWorld.GetCharacterType
        Return characterTypes(characterTypeName)
    End Function

    Private Shared ReadOnly mapTypes As IReadOnlyDictionary(Of String, IMapType) =
        New List(Of IMapType) From
        {
            StartingAreaMapType.Instance
        }.ToDictionary(Function(x) x.MapTypeName, Function(x) x)

    Private Shared ReadOnly locationTypes As IReadOnlyDictionary(Of String, ILocationType) =
        New List(Of ILocationType) From
        {
            FloorLocationType.Instance,
            WallLocationType.Instance
        }.ToDictionary(Function(x) x.LocationTypeName, Function(x) x)

    Private Shared ReadOnly characterTypes As IReadOnlyDictionary(Of String, ICharacterType) =
        New List(Of ICharacterType) From
        {
            N00bCharacterType.Instance
        }.ToDictionary(Function(x) x.CharacterTypeName, Function(x) x)
End Class
