Friend Class StartingAreaMapTypeDescriptor
    Inherits MapTypeDescriptor

    Private Sub New()
        MyBase.New(32, 16)
    End Sub

    Public Overrides Sub Initialize(map As IMap)
        For Each column In Enumerable.Range(0, map.Columns)
            For Each row In Enumerable.Range(0, map.Rows)
                map.CreateLocation(column, row, FloorLocationTypeDescriptor.Instance)
            Next
        Next
        Dim location = map.GetLocation(map.Columns \ 2, map.Rows \ 2)
        map.World.Avatar = location.CreateCharacter(N00bCharacterTypeDescriptor.Instance)
    End Sub

    Friend Shared ReadOnly Instance As New StartingAreaMapTypeDescriptor
End Class
