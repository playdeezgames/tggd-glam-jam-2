Friend Class StartingAreaMapType
    Inherits MapType

    Private Sub New()
        MyBase.New(Name, MAP_COLUMNS, MAP_ROWS)
    End Sub

    Public Overrides Sub Initialize(map As IMap)
        For Each column In Enumerable.Range(0, map.Columns)
            For Each row In Enumerable.Range(0, map.Rows)
                map.CreateLocation(column, row, FloorLocationType.Instance)
            Next
        Next
        Dim location = map.GetLocation(map.Columns \ 2, map.Rows \ 2)
        map.World.Avatar = location.CreateCharacter(N00bCharacterType.Instance)
    End Sub

    Friend Shared ReadOnly Instance As New StartingAreaMapType
    Friend Shared ReadOnly Name As String = NameOf(StartingAreaMapType)
End Class
