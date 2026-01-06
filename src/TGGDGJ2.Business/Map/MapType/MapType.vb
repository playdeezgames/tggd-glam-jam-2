Public MustInherit Class MapType
    Implements IMapType

    Protected Sub New(mapTypeName As String, grid As String())
        Me.Columns = grid(0).Length
        Me.Rows = grid.Length
        Me.MapTypeName = mapTypeName
        Me.grid = grid
    End Sub

    Public ReadOnly Property Columns As Integer Implements IMapType.Columns

    Public ReadOnly Property Rows As Integer Implements IMapType.Rows

    Public ReadOnly Property MapTypeName As String Implements IMapType.MapTypeName
    Protected ReadOnly grid As String()
    Public Overridable Sub Initialize(map As IMap, context As Dictionary(Of String, Object)) Implements IMapType.Initialize
        For Each row In Enumerable.Range(0, Rows)
            For Each column In Enumerable.Range(0, Columns)
                Dim gridCell = grid(row)(column)
                CreateLocation(map, row, column, gridCell, context)
            Next
        Next
    End Sub

    Protected MustOverride Sub PostProcess(gridCell As Char, location As ILocation, context As Dictionary(Of String, Object))

    Private Sub CreateItem(gridCell As Char, location As ILocation)
        Dim itemType As IItemType = GetItemType(gridCell)
        If itemType IsNot Nothing Then
            location.CreateItem(itemType)
        End If
    End Sub

    Protected MustOverride Function GetItemType(gridCell As Char) As IItemType

    Private Sub CreateCharacter(gridCell As Char, location As ILocation)
        Dim characterType As ICharacterType = GetCharacterType(gridCell)
        If characterType IsNot Nothing Then
            location.CreateCharacter(characterType)
        End If
    End Sub

    Protected MustOverride Function GetCharacterType(gridCell As Char) As ICharacterType

    Private Sub CreateLocation(map As IMap, row As Integer, column As Integer, gridCell As Char, context As Dictionary(Of String, Object))
        Dim locationType As ILocationType = GetLocationType(gridCell)
        Dim location = map.CreateLocation(column, row, locationType)
        CreateCharacter(gridCell, location)
        CreateItem(gridCell, location)
        PostProcess(gridCell, location, context)
    End Sub

    Protected MustOverride Function GetLocationType(gridCell As Char) As ILocationType
End Class
