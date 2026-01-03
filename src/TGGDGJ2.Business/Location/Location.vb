Imports System.Xml
Imports TGGDGJ2.Data

Friend Class Location
    Inherits Entity(Of LocationData)
    Implements ILocation


    Public Sub New(data As WorldData, locationId As Guid, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
        Me.LocationId = locationId
    End Sub

    Public ReadOnly Property LocationId As Guid Implements ILocation.LocationId

    Protected Overrides ReadOnly Property EntityData As LocationData
        Get
            Return Data.Locations(LocationId)
        End Get
    End Property

    Public Function CreateCharacter(characterType As ICharacterType) As ICharacter Implements ILocation.CreateCharacter
        Dim characterId = Guid.NewGuid
        Dim characterData = New CharacterData With
            {
                .LocationId = LocationId
            }
        Data.Characters(characterId) = characterData
        Dim result As ICharacter = New Character(Data, characterId, DoEvent)
        characterType.Initialize(result)
        Return result
    End Function
End Class
