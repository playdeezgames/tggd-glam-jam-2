Imports TGGDGJ2.Data

Public Class World
    Inherits Entity(Of WorldData)
    Implements IWorld
    Sub New(data As WorldData, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
    End Sub
    Public Overrides Sub Clear()
        MyBase.Clear()
        With EntityData
            .AvatarCharacterId = Guid.Empty
            .Characters.Clear()
            .Counters.Clear()
            .Locations.Clear()
            .Maps.Clear()
            .Messages.Clear()
        End With
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

    Public ReadOnly Property HasMessage As Boolean Implements IWorld.HasMessage
        Get
            Return EntityData.Messages.Any
        End Get
    End Property

    Public Sub Initialize() Implements IWorld.Initialize
        Clear()
        Dim context As New Dictionary(Of String, Object)
        Dim startingMap = CreateMap(StartingAreaMapType.Instance, context)
        Dim secondMap = CreateMap(SecondMapType.Instance, context)
    End Sub

    Public Function CreateMap(mapType As IMapType, context As Dictionary(Of String, Object)) As IMap Implements IWorld.CreateMap
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
        mapType.Initialize(result, context)
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

    Public Function GetTriggerType(triggerTypeName As String) As ITriggerType Implements IWorld.GetTriggerType
        Return triggerTypes(triggerTypeName)
    End Function

    Public Function GetItemType(itemTypeName As String) As IItemType Implements IWorld.GetItemType
        Return itemTypes(itemTypeName)
    End Function

    Public Sub AddMessage(title As String, ParamArray lines() As String) Implements IWorld.AddMessage
        EntityData.Messages.Add(New MessageData With {.Title = title, .Lines = lines})
    End Sub

    Public Sub DismissMessage() Implements IWorld.DismissMessage
        EntityData.Messages.RemoveAt(0)
    End Sub

    Public Function GetMessage() As IMessage Implements IWorld.GetMessage
        Return New Message(EntityData.Messages.First.Title, EntityData.Messages.First.Lines)
    End Function

    Private Shared ReadOnly mapTypes As IReadOnlyDictionary(Of String, IMapType) =
        New List(Of IMapType) From
        {
            StartingAreaMapType.Instance,
            SecondMapType.Instance
        }.ToDictionary(Function(x) x.MapTypeName, Function(x) x)

    Private Shared ReadOnly itemTypes As IReadOnlyDictionary(Of String, IItemType) =
        New List(Of IItemType) From
        {
            KeyItemType.Instance
        }.ToDictionary(Function(x) x.ItemTypeName, Function(x) x)

    Private Shared ReadOnly triggerTypes As IReadOnlyDictionary(Of String, ITriggerType) =
        New List(Of ITriggerType) From
        {
            MessageTriggerType.Instance,
            UnlockTriggerType.Instance
        }.ToDictionary(Function(x) x.TriggerTypeName, Function(x) x)

    Private Shared ReadOnly locationTypes As IReadOnlyDictionary(Of String, ILocationType) =
        New List(Of ILocationType) From
        {
            FloorLocationType.Instance,
            WallLocationType.Instance,
            LockedDoorLocationType.Instance,
            SignLocationType.Instance,
            UnlockedDoorLocationType.Instance
        }.ToDictionary(Function(x) x.LocationTypeName, Function(x) x)

    Private Shared ReadOnly characterTypes As IReadOnlyDictionary(Of String, ICharacterType) =
        New List(Of ICharacterType) From
        {
            N00bCharacterType.Instance
        }.ToDictionary(Function(x) x.CharacterTypeName, Function(x) x)
End Class
