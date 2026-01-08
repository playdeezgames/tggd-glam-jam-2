Public Interface IMap
    Inherits ITypedEntity(Of IMapType)
    ReadOnly Property MapId As Guid
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    Function CreateLocation(column As Integer, row As Integer, locationType As ILocationType) As ILocation
    Function GetLocation(column As Integer, row As Integer) As ILocation
    Sub SetLocation(column As Integer, row As Integer, location As ILocation)
    Sub Update()
    ReadOnly Property Locations As IEnumerable(Of ILocation)
End Interface
