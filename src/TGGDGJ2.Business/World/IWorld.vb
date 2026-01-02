Public Interface IWorld
    Inherits IEntity
    Sub Initialize()
    Function CreateMap(mapType As IMapTypeDescriptor) As IMap
End Interface
