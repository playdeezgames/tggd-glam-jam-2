Public Interface IEntity
    ReadOnly Property World As IWorld
    Sub Clear()
    Function CreateCounter(
                          counterName As String,
                          initialValue As Integer,
                          minimumValue As Integer,
                          maximumValue As Integer) As ICounter
    Function GetCounter(counterName As String) As ICounter
End Interface
