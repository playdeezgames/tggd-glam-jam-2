Imports TGGDGJ2.Data

Friend Class Counter
    Implements ICounter

    Private ReadOnly data As WorldData
    Private ReadOnly doEvent As Action(Of String())
    Private ReadOnly Property CounterData As CounterData
        Get
            Return data.Counters(CounterId)
        End Get
    End Property

    Public Sub New(data As WorldData, counterId As Guid, doEvent As Action(Of String()))
        Me.data = data
        Me.counterId = counterId
        Me.doEvent = doEvent
    End Sub

    Public ReadOnly Property CounterId As Guid Implements ICounter.CounterId

    Public Property Value As Integer Implements ICounter.Value
        Get
            Return Math.Clamp(CounterData.Value, Minimum, Maximum)
        End Get
        Set(value As Integer)
            CounterData.Value = Math.Clamp(value, Minimum, Maximum)
        End Set
    End Property

    Public Property Maximum As Integer Implements ICounter.Maximum
        Get
            Return CounterData.Maximum
        End Get
        Set(value As Integer)
            CounterData.Maximum = value
        End Set
    End Property

    Public ReadOnly Property Minimum As Integer Implements ICounter.Minimum
        Get
            Return CounterData.Minimum
        End Get
    End Property
End Class
