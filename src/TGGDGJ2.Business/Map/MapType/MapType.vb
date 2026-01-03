Public MustInherit Class MapType
    Implements IMapType

    Protected Sub New(mapTypeName As String, columns As Integer, rows As Integer)
        Me.Columns = columns
        Me.Rows = rows
        Me.MapTypeName = mapTypeName
    End Sub

    Public ReadOnly Property Columns As Integer Implements IMapType.Columns

    Public ReadOnly Property Rows As Integer Implements IMapType.Rows

    Public ReadOnly Property MapTypeName As String Implements IMapType.MapTypeName

    Public MustOverride Sub Initialize(map As IMap) Implements IMapType.Initialize
End Class
