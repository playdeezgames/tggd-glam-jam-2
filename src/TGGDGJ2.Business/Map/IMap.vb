Public Interface IMap
    Inherits IEntity
    ReadOnly Property MapId As Guid
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    Function CreateLocation(column As Integer, row As Integer, locationType As ILocationTypeDescriptor) As ILocation
    Function GetLocation(column As Integer, row As Integer) As ILocation
End Interface
