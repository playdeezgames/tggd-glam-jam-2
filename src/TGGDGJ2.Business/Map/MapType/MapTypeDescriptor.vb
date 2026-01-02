Public MustInherit Class MapTypeDescriptor
    Implements IMapTypeDescriptor

    Protected Sub New(columns As Integer, rows As Integer)
        Me.Columns = columns
        Me.Rows = rows
    End Sub

    Public ReadOnly Property Columns As Integer Implements IMapTypeDescriptor.Columns

    Public ReadOnly Property Rows As Integer Implements IMapTypeDescriptor.Rows

    Public MustOverride Sub Initialize(map As IMap) Implements IMapTypeDescriptor.Initialize
End Class
