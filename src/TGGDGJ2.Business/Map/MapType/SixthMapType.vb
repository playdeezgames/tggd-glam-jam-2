Friend Class SixthMapType
    Inherits MapType

    Friend Shared ReadOnly Name As String = NameOf(SixthMapType)
    Friend Shared ReadOnly Instance As IMapType = New SixthMapType

    Private Sub New()
        MyBase.New(
            Name,
            {
                "###############+################",
                "#              x               #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "################################"
            })
    End Sub

    Protected Overrides Sub PostProcess(gridCell As Char, location As ILocation, context As Dictionary(Of String, Object))
        Select Case gridCell
            Case "+"c
                CreateNorthDoor(location, context)
            Case "x"c
                CreateNorthDestination(location, context)
        End Select
    End Sub

    Private Sub CreateNorthDestination(location As ILocation, context As Dictionary(Of String, Object))
        CType(context(FifthRoomSouthDoor), ILocation).BumpTrigger.Destination = location
    End Sub

    Private Sub CreateNorthDoor(location As ILocation, context As Dictionary(Of String, Object))
        location.BumpTrigger = location.CreateTrigger(TeleportTriggerType.Instance)
        location.BumpTrigger.Destination = CType(context(FifthRoomSouthDestination), ILocation)
    End Sub

    Protected Overrides Function GetItemType(gridCell As Char) As IItemType
        Return Nothing
    End Function

    Protected Overrides Function GetCharacterType(gridCell As Char) As ICharacterType
        Return Nothing
    End Function

    Protected Overrides Function GetLocationType(gridCell As Char) As ILocationType
        Return If(gridCell = "#"c, WallLocationType.Instance,
            If(gridCell = "+"c, UnlockedDoorLocationType.Instance,
            FloorLocationType.Instance))
    End Function
End Class
