Public Class WorldData
    Inherits EntityData
    Public Property Maps As New Dictionary(Of Guid, MapData)
    Public Property Locations As New Dictionary(Of Guid, LocationData)
    Public Property Characters As New Dictionary(Of Guid, CharacterData)
    Public Property AvatarCharacterId As Guid
    Public Property Counters As New Dictionary(Of Guid, CounterData)
End Class
