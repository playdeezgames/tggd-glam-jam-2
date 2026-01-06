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
                "+                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "#                              #",
                "################################"
            })
    End Sub

    Public Overrides Sub Initialize(map As IMap)
    End Sub

    Protected Overrides Sub PostProcess(gridCell As Char, location As ILocation)
        'nada!
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
