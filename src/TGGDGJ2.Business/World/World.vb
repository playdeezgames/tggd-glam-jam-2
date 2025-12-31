Imports TGGDGJ2.Data

Public Class World
    Inherits Entity(Of WorldData)
    Implements IWorld
    Sub New(data As WorldData, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
    End Sub

    'Public ReadOnly Property Locations As IEnumerable(Of ILocation) Implements IWorld.Locations
    '    Get
    '        Return Enumerable.Range(0, Data.Locations.Count).Select(Function(x) New Location(Data, x, DoEvent))
    '    End Get
    'End Property

    'Public Property Avatar As ICharacter Implements IWorld.Avatar
    '    Get
    '        Return If(Data.AvatarId.HasValue, New Character(Data, Data.AvatarId.Value, DoEvent), Nothing)
    '    End Get
    '    Set(value As ICharacter)
    '        If value Is Nothing Then
    '            Data.AvatarId = Nothing
    '        Else
    '            Data.AvatarId = value.CharacterId
    '        End If
    '    End Set
    'End Property

    'Public ReadOnly Property HasMessage As Boolean Implements IWorld.HasMessage
    '    Get
    '        Return Data.Messages.Any
    '    End Get
    'End Property

    'Public ReadOnly Property CurrentMessage As IMessage Implements IWorld.CurrentMessage
    '    Get
    '        Return New Message(Data)
    '    End Get
    'End Property

    'Protected Overrides ReadOnly Property EntityData As WorldData
    '    Get
    '        Return Data
    '    End Get
    'End Property

    'Public Sub Clear() Implements IWorld.Clear
    '    Data.Characters.Clear()
    '    Data.Locations.Clear()
    '    Data.AvatarId = Nothing
    'End Sub

    'Public Sub Abandon() Implements IWorld.Abandon
    '    Clear()
    'End Sub

    'Public Sub AddMessage(ParamArray lines() As String) Implements IWorld.AddMessage
    '    Data.Messages.Add(New MessageData With {.Lines = lines.ToList})
    'End Sub

    'Public Sub DismissMessage() Implements IWorld.DismissMessage
    '    If Data.Messages.Any Then
    '        Data.Messages.RemoveAt(0)
    '    End If
    'End Sub

    'Public Function CreateLocation(locationType As String) As ILocation Implements IWorld.CreateLocation
    '    Dim locationId = EntityData.Locations.Count
    '    EntityData.Locations.Add(New LocationData With
    '                             {
    '                                .LocationType = locationType
    '                             })
    '    Dim result As ILocation = New Location(Data, locationId, DoEvent)
    '    result.Initialize()
    '    Return result
    'End Function

    'Public Function CreateCharacter(characterType As String, location As ILocation) As ICharacter Implements IWorld.CreateCharacter
    '    Dim characterId = EntityData.Characters.Count
    '    EntityData.Characters.Add(New CharacterData With
    '                             {
    '                                .CharacterType = characterType,
    '                                .LocationId = location.LocationId
    '                             })
    '    Dim result As ICharacter = New Character(Data, characterId, DoEvent)
    '    result.Initialize()
    '    location.AddCharacter(result)
    '    Return result
    'End Function

    'Public Function CreateItem(itemType As String) As IItem Implements IWorld.CreateItem
    '    Dim itemId = EntityData.Items.Count
    '    EntityData.Items.Add(New ItemData With
    '                             {
    '                                .ItemType = itemType
    '                             })
    '    Dim result As IItem = New Item(Data, itemId, DoEvent)
    '    result.Initialize()
    '    Return result
    'End Function

    'Public Function GetItem(itemId As Integer) As IItem Implements IWorld.GetItem
    '    Return New Item(Data, itemId, DoEvent)
    'End Function
End Class
