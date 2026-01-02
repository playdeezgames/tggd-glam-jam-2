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
        Dim startingMap = CreateMap(StartingAreaMapTypeDescriptor.Instance)
    End Sub

    Public Function CreateMap(mapType As IMapTypeDescriptor) As IMap Implements IWorld.CreateMap
        Dim mapId = Guid.NewGuid()
        Dim mapData As New MapData With
            {
                .Columns = mapType.Columns,
                .Rows = mapType.Rows,
                .LocationIds = Enumerable.Repeat(Guid.Empty, mapType.Columns * mapType.Rows).ToList
            }
        Data.Maps(mapId) = mapData
        Dim result As New Map(Data, mapId, DoEvent)
        mapType.Initialize(result)
        Return result
    End Function
End Class
