Friend Class StartingAreaMapType
    Inherits MapType

    Private Sub New()
        MyBase.New(Name, grid(0).Length, grid.Length)
    End Sub

    Private Shared ReadOnly grid As String() =
        {
            "################################",
            "#                              #",
            "#                              #",
            "#                              #",
            "#                   !          #",
            "#                              #",
            "#                              #",
            "#                              #",
            "#              @               +",
            "#                              #",
            "#                              #",
            "#                              #",
            "#                              #",
            "#   k                          #",
            "#                              #",
            "################################"
        }

    Private Shared ReadOnly locationTypeTable As IReadOnlyDictionary(Of Char, ILocationType) =
        New Dictionary(Of Char, ILocationType) From
        {
            {" "c, FloorLocationType.Instance},
            {"@"c, FloorLocationType.Instance},
            {"k"c, FloorLocationType.Instance},
            {"#"c, WallLocationType.Instance},
            {"+"c, UnlockedDoorLocationType.Instance},
            {"!"c, SignLocationType.Instance}
        }

    Private Shared ReadOnly characterTypeTable As IReadOnlyDictionary(Of Char, ICharacterType) =
        New Dictionary(Of Char, ICharacterType) From
        {
            {"@"c, N00bCharacterType.Instance}
        }

    Private Shared ReadOnly itemTypeTable As IReadOnlyDictionary(Of Char, IItemType) =
        New Dictionary(Of Char, IItemType) From
        {
            {"k"c, KeyItemType.Instance}
        }

    Private Shared ReadOnly postProcessing As IReadOnlyDictionary(Of Char, Action(Of ILocation)) =
        New Dictionary(Of Char, Action(Of ILocation)) From
        {
            {"@"c, AddressOf SetAvatarCharacter},
            {"!"c, AddressOf CreateSign},
            {"+"c, AddressOf CreateDoor}
        }

    Private Shared Sub CreateDoor(location As ILocation)
        location.BumpTrigger = location.CreateTrigger(MessageTriggerType.Instance)
        location.BumpTrigger.SetMessage("TODO: Go Thru Door", "Yes, you unlocked the door. Good job.")
        Dim newLocation = location.Map.CreateLocation(location.Column, location.Row, LockedDoorLocationType.Instance)
        Dim trigger = location.CreateTrigger(UnlockTriggerType.Instance)
        trigger.NextLocation = location
        newLocation.BumpTrigger = trigger
    End Sub

    Private Shared Sub CreateSign(location As ILocation)
        Dim trigger = location.CreateTrigger(MessageTriggerType.Instance)
        trigger.SetMessage("Example sign!", "They have multiple lines, too!")
        location.BumpTrigger = trigger
    End Sub

    Private Shared Sub SetAvatarCharacter(location As ILocation)
        location.World.Avatar = location.Character
    End Sub

    Public Overrides Sub Initialize(map As IMap)
        For Each row In Enumerable.Range(0, grid.Length)
            For Each column In Enumerable.Range(0, grid(row).Length)
                Dim gridCell = grid(row)(column)
                Dim locationType = locationTypeTable(gridCell)
                Dim location = map.CreateLocation(column, row, locationType)
                Dim characterType As ICharacterType = Nothing
                If characterTypeTable.TryGetValue(gridCell, characterType) Then
                    location.CreateCharacter(characterType)
                End If
                Dim itemType As IItemType = Nothing
                If itemTypeTable.TryGetValue(gridCell, itemType) Then
                    location.CreateItem(itemType)
                End If
                Dim postProcessor As Action(Of ILocation) = Nothing
                postProcessing.TryGetValue(gridCell, postProcessor)
                postProcessor?.Invoke(location)
            Next
        Next
    End Sub

    Friend Shared ReadOnly Name As String = NameOf(StartingAreaMapType)
    Friend Shared ReadOnly Instance As New StartingAreaMapType
End Class
