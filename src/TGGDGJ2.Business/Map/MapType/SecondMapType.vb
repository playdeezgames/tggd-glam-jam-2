Friend Class SecondMapType
    Inherits MapType
    Friend Shared ReadOnly Name As String = NameOf(SecondMapType)
    Friend Shared ReadOnly Instance As IMapType = New SecondMapType()

    Private Sub New()
        MyBase.New(
            Name,
            {
                "################^###############",
                "#               .             !#",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "+x                             #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                             f#",
                "################################"
            })
    End Sub

    Protected Overrides Sub PostProcess(gridCell As Char, location As ILocation, context As Dictionary(Of String, Object))
        Select Case gridCell
            Case "+"c
                CreateWestDoor(location, context)
            Case "x"c
                CreateWestDestination(location, context)
            Case "!"c
                CreateSign(location)
            Case "^"c
                CreateNorthDoor(location, context)
            Case "."c
                CreateNorthDestination(location, context)
        End Select
    End Sub

    Private Sub CreateNorthDestination(location As ILocation, context As Dictionary(Of String, Object))
        context(Grimoire.SecondAreaDoorDestination) = location
    End Sub

    Private Sub CreateNorthDoor(location As ILocation, context As Dictionary(Of String, Object))
        context(Grimoire.SecondAreaDoorExit) = location
        location.BumpTrigger = location.CreateTrigger(TeleportTriggerType.Instance)
    End Sub

    Private Sub CreateSign(location As ILocation)
        Dim trigger = location.CreateTrigger(MessageTriggerType.Instance)
        trigger.SetMessage(
            "Food!",
            "Yes, that's food down there.",
            "You can pick it up into yer inventory,",
            "just like the key.",
            "Press <SPACE> to bring up the action menu,",
            "and see if you can figure out how to eat it.")
        location.BumpTrigger = trigger
    End Sub

    Private Sub CreateWestDestination(location As ILocation, context As Dictionary(Of String, Object))
        CType(context(StartingAreaDoorExit), ILocation).BumpTrigger.Destination = location
    End Sub

    Private Sub CreateWestDoor(location As ILocation, context As Dictionary(Of String, Object))
        location.BumpTrigger = location.CreateTrigger(TeleportTriggerType.Instance)
        location.BumpTrigger.Destination = CType(context(StartingAreaDoorDestination), ILocation)
    End Sub

    Protected Overrides Function GetItemType(gridCell As Char) As IItemType
        Return If(gridCell = "f"c, FoodItemType.Instance, Nothing)
    End Function

    Protected Overrides Function GetCharacterType(gridCell As Char) As ICharacterType
        Return Nothing
    End Function

    Protected Overrides Function GetLocationType(gridCell As Char) As ILocationType
        Return If(gridCell = "#"c, WallLocationType.Instance,
            If(gridCell = "+"c OrElse gridCell = "^"c, UnlockedDoorLocationType.Instance,
            If(gridCell = "!"c, SignLocationType.Instance,
            FloorLocationType.Instance)))
    End Function
End Class
