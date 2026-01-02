Imports TGGDGJ2.Data

Public Class World
    Inherits Entity(Of WorldData)
    Implements IWorld
    Sub New(data As WorldData, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
    End Sub

    Public Sub Initialize() Implements IWorld.Initialize
        Clear()
    End Sub

    Public Function CreateMap(mapType As IMapTypeDescriptor) As IMap Implements IWorld.CreateMap
        Throw New NotImplementedException()
    End Function
End Class
