Public Class ThirdMapType
    Inherits MapType

    Friend Shared ReadOnly Name As String = NameOf(ThirdMapType)
    Friend Shared ReadOnly Instance As IMapType = New ThirdMapType

    Public Sub New()
        MyBase.New(
            Name,
            {
                "################^###############",
                "#!              .              #",
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
                "#ff                            #",
                "#ff             x             M#",
                "################+###############"
            })
    End Sub

    Protected Overrides Sub PostProcess(gridCell As Char, location As ILocation, context As Dictionary(Of String, Object))
        Select Case gridCell
            Case "+"c
                CreateSouthDoor(location, context)
            Case "x"c
                CreateSouthDoorDestination(location, context)
            Case "^"c
                CreateNorthDoor(location, context)
            Case "."c
                CreateNorthDestination(location, context)
            Case "!"c
                CreateSign(location)
        End Select
    End Sub

    Private Sub CreateSign(location As ILocation)
        Dim trigger = location.CreateTrigger(MessageTriggerType.Instance)
        trigger.SetMessage(
            "MONSTARS!",
            "See that thing chasing you?",
            "It wants to eat you!",
            "And you came to read a sign instead of heading",
            "for the door!")
        location.BumpTrigger = trigger
    End Sub

    Private Sub CreateNorthDestination(location As ILocation, context As Dictionary(Of String, Object))
        context(Grimoire.ThirdRoomNorthDestination) = location
    End Sub

    Private Sub CreateNorthDoor(location As ILocation, context As Dictionary(Of String, Object))
        context(Grimoire.ThirdRoomNorthDoor) = location
        location.BumpTrigger = location.CreateTrigger(TeleportTriggerType.Instance)
    End Sub

    Private Sub CreateSouthDoorDestination(location As ILocation, context As Dictionary(Of String, Object))
        CType(context(SecondRoomNorthDoor), ILocation).BumpTrigger.Destination = location
    End Sub

    Private Sub CreateSouthDoor(location As ILocation, context As Dictionary(Of String, Object))
        location.BumpTrigger = location.CreateTrigger(TeleportTriggerType.Instance)
        location.BumpTrigger.Destination = CType(context(SecondRoomNorthDestination), ILocation)
    End Sub

    Protected Overrides Function GetItemType(gridCell As Char) As IItemType
        Return If(gridCell = "f"c, FoodItemType.Instance, Nothing)
    End Function

    Protected Overrides Function GetCharacterType(gridCell As Char) As ICharacterType
        Return If(gridCell = "M"c, KoboldCharacterType.Instance, Nothing)
    End Function

    Protected Overrides Function GetLocationType(gridCell As Char) As ILocationType
        Return If(gridCell = "#"c, WallLocationType.Instance,
            If(gridCell = "!"c, SignLocationType.Instance,
            If(gridCell = "+"c OrElse gridCell = "^"c, UnlockedDoorLocationType.Instance,
            FloorLocationType.Instance)))
    End Function
End Class
