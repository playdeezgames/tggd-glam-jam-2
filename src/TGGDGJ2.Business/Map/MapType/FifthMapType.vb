Friend Class FifthMapType
    Inherits MapType

    Friend Shared ReadOnly Name As String = NameOf(FifthMapType)
    Friend Shared ReadOnly Instance As IMapType = New FifthMapType

    Private Sub New()
        MyBase.New(
            Name,
            {
                "################################",
                "#s                            s#",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                             x+",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#s                            s#",
                "################################"
            })
    End Sub

    Protected Overrides Sub PostProcess(gridCell As Char, location As ILocation, context As Dictionary(Of String, Object))
        Select Case gridCell
            Case "+"c
                CreateEastDoor(location, context)
            Case "x"c
                CreateEastDestination(location, context)
        End Select
    End Sub

    Private Shared Sub CreateEastDestination(location As ILocation, context As Dictionary(Of String, Object))
        CType(context(FourthRoomWestDoor), ILocation).BumpTrigger.Destination = location
    End Sub

    Private Shared Sub CreateEastDoor(location As ILocation, context As Dictionary(Of String, Object))
        location.BumpTrigger = location.CreateTrigger(TeleportTriggerType.Instance)
        location.BumpTrigger.Destination = CType(context(FourthRoomWestDestination), ILocation)
    End Sub

    Protected Overrides Function GetItemType(gridCell As Char) As IItemType
        Return Nothing
    End Function

    Protected Overrides Function GetCharacterType(gridCell As Char) As ICharacterType
        Return If(gridCell = "s"c, SlugCharacterType.Instance, Nothing)
    End Function

    Protected Overrides Function GetLocationType(gridCell As Char) As ILocationType
        Return If(gridCell = "#"c, WallLocationType.Instance,
            If(gridCell = "+"c, UnlockedDoorLocationType.Instance,
            FloorLocationType.Instance))
    End Function
End Class
