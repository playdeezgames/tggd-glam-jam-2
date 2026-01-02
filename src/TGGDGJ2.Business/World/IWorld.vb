Public Interface IWorld
    Inherits IEntity
    Sub Initialize()
    Function CreateMap(mapType As IMapTypeDescriptor) As IMap
    Property Avatar As ICharacter
End Interface
