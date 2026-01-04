Public Interface IWorld
    Inherits IEntity
    Sub Initialize()
    Function CreateMap(mapType As IMapType) As IMap
    Property Avatar As ICharacter
    Function GetMapType(mapTypeName As String) As IMapType
    Function GetLocationType(locationTypeName As String) As ILocationType
    Function GetCharacterType(characterTypeName As String) As ICharacterType
    Function GetTriggerType(triggerTypeName As String) As ITriggerType
    Sub AddMessage(ParamArray lines As String())
End Interface
