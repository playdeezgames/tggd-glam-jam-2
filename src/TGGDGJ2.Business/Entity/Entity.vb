Imports TGGDGJ2.Data

Public MustInherit Class Entity(Of TEntityData As EntityData)
    Implements IEntity
    Protected ReadOnly Property Data As WorldData
    Protected ReadOnly Property DoEvent As Action(Of String())
    Sub New(data As WorldData, doEvent As Action(Of String()))
        Me.Data = data
        Me.DoEvent = doEvent
    End Sub

    Protected MustOverride ReadOnly Property EntityData As TEntityData

    Public Overridable Sub Clear() Implements IEntity.Clear
        'TODO: clear
    End Sub

    Public ReadOnly Property World As IWorld Implements IEntity.World
        Get
            Return New World(Data, DoEvent)
        End Get
    End Property
End Class
