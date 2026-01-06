Friend Class StartingAreaMapType
    Inherits MapType

    Private Sub New()
        MyBase.New(
            Name,
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
            })
    End Sub

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

    Protected Overrides Function GetItemType(gridCell As Char) As IItemType
        Return If(gridCell = "k"c, KeyItemType.Instance, Nothing)
    End Function

    Protected Overrides Function GetCharacterType(gridCell As Char) As ICharacterType
        Return If(gridCell = "@"c, N00bCharacterType.Instance, Nothing)
    End Function

    Protected Overrides Function GetLocationType(gridCell As Char) As ILocationType
        Return If(gridCell = "#"c, WallLocationType.Instance,
            If(gridCell = "+"c, UnlockedDoorLocationType.Instance,
            If(gridCell = "!"c, SignLocationType.Instance,
            FloorLocationType.Instance)))
    End Function

    Protected Overrides Sub PostProcess(gridCell As Char, location As ILocation, context As Dictionary(Of String, Object))
        Select Case gridCell
            Case "@"c
                SetAvatarCharacter(location)
            Case "!"c
                CreateSign(location)
            Case "+"c
                CreateDoor(location)
        End Select
    End Sub

    Friend Shared ReadOnly Name As String = NameOf(StartingAreaMapType)
    Friend Shared ReadOnly Instance As New StartingAreaMapType
End Class
