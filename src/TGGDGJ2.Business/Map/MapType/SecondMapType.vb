Friend Class SecondMapType
    Inherits MapType
    Friend Shared ReadOnly Name As String = NameOf(SecondMapType)
    Friend Shared ReadOnly Instance As IMapType = New SecondMapType()

    Private Sub New()
        MyBase.New(
            Name,
            {
                "################################",
                "#                              #",
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
                "#                              #",
                "################################"
            })
    End Sub

    Protected Overrides Sub PostProcess(gridCell As Char, location As ILocation, context As Dictionary(Of String, Object))
        Select Case gridCell
            Case "+"c
                CreateDoor(location, context)
            Case "x"c
                CreateDestination(location, context)
        End Select
    End Sub

    Private Sub CreateDestination(location As ILocation, context As Dictionary(Of String, Object))
        CType(context(StartingAreaDoorExit), ILocation).BumpTrigger.Destination = location
    End Sub

    Private Sub CreateDoor(location As ILocation, context As Dictionary(Of String, Object))
        location.BumpTrigger = location.CreateTrigger(TeleportTriggerType.Instance)
        location.BumpTrigger.Destination = CType(context(StartingAreaDoorDestination), ILocation)
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
