Friend Module MapTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, IMapTypeDescriptor) =
        New List(Of IMapTypeDescriptor) From
        {
            StartingAreaMapTypeDescriptor.Instance
        }.ToDictionary(Function(x) x.MapTypeName, Function(x) x)
End Module
