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
        With EntityData
            .EntityCounters.Clear()
            .EntityYokes.Clear()
        End With
    End Sub

    Public Function CreateCounter(counterName As String, initialValue As Integer, minimumValue As Integer, maximumValue As Integer) As ICounter Implements IEntity.CreateCounter
        Dim counterId As Guid = Guid.NewGuid
        Dim counterData As New CounterData With
            {
                .Value = initialValue,
                .Maximum = maximumValue,
                .Minimum = minimumValue
            }
        Data.Counters(counterId) = counterData
        EntityData.EntityCounters(counterName) = counterId
        Return New Counter(Data, counterId, DoEvent)
    End Function

    Public Function GetCounter(counterName As String) As ICounter Implements IEntity.GetCounter
        Dim counterId As Guid = Guid.Empty
        If EntityData.EntityCounters.TryGetValue(counterName, counterId) Then
            Return New Counter(Data, counterId, DoEvent)
        End If
        Return Nothing
    End Function

    Public ReadOnly Property World As IWorld Implements IEntity.World
        Get
            Return New World(Data, DoEvent)
        End Get
    End Property
End Class
