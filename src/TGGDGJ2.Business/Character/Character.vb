Imports TGGDGJ2.Data

Friend Class Character
    Inherits Entity(Of CharacterData)
    Implements ICharacter

    Public Sub New(data As WorldData, characterId As Guid, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
        Me.CharacterId = characterId
    End Sub

    Public ReadOnly Property CharacterId As Guid Implements ICharacter.CharacterId

    Protected Overrides ReadOnly Property EntityData As CharacterData
        Get
            Return Data.Characters(CharacterId)
        End Get
    End Property
End Class
