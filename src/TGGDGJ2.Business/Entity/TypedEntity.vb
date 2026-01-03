Imports TGGDGJ2.Data

Public MustInherit Class TypedEntity(Of TEntityData As TypedEntityData, TEntityType)
    Inherits Entity(Of TEntityData)
    Implements ITypedEntity(Of TEntityType)
    Protected Sub New(data As WorldData, doEvent As Action(Of String()))
        MyBase.New(data, doEvent)
    End Sub
    Public ReadOnly Property EntityTypeName As String Implements ITypedEntity(Of TEntityType).EntityTypeName
        Get
            Return EntityData.EntityTypeName
        End Get
    End Property
    Public MustOverride ReadOnly Property EntityType As TEntityType Implements ITypedEntity(Of TEntityType).EntityType
End Class
