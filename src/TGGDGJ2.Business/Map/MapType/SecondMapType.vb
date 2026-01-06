Friend Class SecondMapType
    Inherits MapType
    Friend Shared ReadOnly Name As String = NameOf(SecondMapType)
    Friend Shared ReadOnly Instance As IMapType = New SecondMapType()
    Private Shared ReadOnly legacyGrid As String() =
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
        }

    Private Sub New()
        MyBase.New(Name, legacyGrid(0).Length, legacyGrid.Length)
    End Sub

    Public Overrides Sub Initialize(map As IMap)
    End Sub
End Class
