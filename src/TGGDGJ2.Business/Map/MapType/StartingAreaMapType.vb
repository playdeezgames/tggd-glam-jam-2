Imports System.Data.Common

Friend Class StartingAreaMapType
    Inherits MapType

    Private Sub New()
        MyBase.New(Name, MAP_COLUMNS, MAP_ROWS)
    End Sub

    Public Overrides Sub Initialize(map As IMap)
        For Each column In Enumerable.Range(0, map.Columns)
            map.CreateLocation(column, 0, WallLocationType.Instance)
            map.CreateLocation(column, map.Rows - 1, WallLocationType.Instance)
        Next
        For Each row In Enumerable.Range(1, map.Rows - 2)
            map.CreateLocation(0, row, WallLocationType.Instance)
            If row = map.Rows \ 2 Then
                map.CreateLocation(map.Columns - 1, row, LockedDoorLocationType.Instance)
            Else
                map.CreateLocation(map.Columns - 1, row, WallLocationType.Instance)
            End If
        Next
        For Each column In Enumerable.Range(1, map.Columns - 2)
            For Each row In Enumerable.Range(1, map.Rows - 2)
                map.CreateLocation(column, row, FloorLocationType.Instance)
            Next
        Next
        Dim location = map.GetLocation(map.Columns \ 2, map.Rows \ 2)
        map.World.Avatar = location.CreateCharacter(N00bCharacterType.Instance)
    End Sub

    Friend Shared ReadOnly Name As String = NameOf(StartingAreaMapType)
    Friend Shared ReadOnly Instance As New StartingAreaMapType
End Class
