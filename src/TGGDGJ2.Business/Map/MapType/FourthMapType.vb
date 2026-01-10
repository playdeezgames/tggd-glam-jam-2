Friend Class FourthMapType
    Inherits MapType

    Friend Shared ReadOnly Name As String = NameOf(FourthMapType)
    Friend Shared ReadOnly Instance As IMapType = New FourthMapType

    Private Sub New()
        MyBase.New(
            Name,
            {
                "################################",
                "#pf                           /#",
                "#ff                            #",
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
                "#!              x             )#",
                "################+###############"
            })
    End Sub

    Protected Overrides Sub PostProcess(gridCell As Char, location As ILocation, context As Dictionary(Of String, Object))
        Select Case gridCell
            Case "+"c
                CreateSouthDoor(location, context)
            Case "x"c
                CreateSouthDestination(location, context)
        End Select
    End Sub

    Private Shared Sub CreateSouthDestination(location As ILocation, context As Dictionary(Of String, Object))
        CType(context(ThirdRoomNorthDoor), ILocation).BumpTrigger.Destination = location
    End Sub

    Private Shared Sub CreateSouthDoor(location As ILocation, context As Dictionary(Of String, Object))
        location.BumpTrigger = location.CreateTrigger(TeleportTriggerType.Instance)
        location.BumpTrigger.Destination = CType(context(ThirdRoomNorthDestination), ILocation)
    End Sub

    Protected Overrides Function GetItemType(gridCell As Char) As IItemType
        Return If(gridCell = "f"c, FoodItemType.Instance,
            If(gridCell = "p"c, PotionItemType.Instance,
            If(gridCell = "/"c, KnifeItemType.Instance,
            If(gridCell = ")"c, ShieldItemType.Instance,
            Nothing))))
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
