Public MustInherit Class MapTypeDescriptor
    Implements IMapTypeDescriptor

    Sub New(mapTypeName As String)
        Me.MapTypeName = mapTypeName
    End Sub

    Public ReadOnly Property MapTypeName As String Implements IMapTypeDescriptor.MapTypeName
End Class
