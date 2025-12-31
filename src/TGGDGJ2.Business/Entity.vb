Imports TGGDGJ2.Data

Public MustInherit Class Entity(Of TEntityData As EntityData)
    Implements IEntity
    Protected ReadOnly Property Data As WorldData
    Protected ReadOnly Property PlaySfx As Action(Of String())
    Sub New(data As WorldData, playSfx As Action(Of String()))
        Me.Data = data
        Me.PlaySfx = playSfx
    End Sub

    'Public Function GetMetadata(metadataType As String) As String Implements IEntity.GetMetadata
    '    Dim result As String = Nothing
    '    If EntityData.Metadatas.TryGetValue(metadataType, result) Then
    '        Return result
    '    End If
    '    Return Nothing
    'End Function

    'Public Sub SetMetadata(metadataType As String, value As String) Implements IEntity.SetMetadata
    '    If String.IsNullOrWhiteSpace(value) Then
    '        EntityData.Metadatas.Remove(metadataType)
    '    Else
    '        EntityData.Metadatas(metadataType) = value
    '    End If
    'End Sub

    'Public Function GetStatistic(statisticType As String) As Integer Implements IEntity.GetStatistic
    '    Return EntityData.Statistics(statisticType)
    'End Function

    'Public Sub SetStatistic(statisticType As String, value As Integer?) Implements IEntity.SetStatistic
    '    If value.HasValue Then
    '        EntityData.Statistics(statisticType) = Math.Clamp(value.Value, GetStatisticMinimum(statisticType), GetStatisticMaximum(statisticType))
    '    Else
    '        EntityData.Statistics.Remove(statisticType)
    '    End If
    'End Sub

    'Public Sub SetStatisticMinimum(statisticType As String, value As Integer) Implements IEntity.SetStatisticMinimum
    '    If value = Integer.MinValue Then
    '        EntityData.StatisticMinimums.Remove(statisticType)
    '    Else
    '        EntityData.StatisticMinimums(statisticType) = value
    '    End If
    'End Sub

    'Public Sub SetStatisticMaximum(statisticType As String, value As Integer) Implements IEntity.SetStatisticMaximum
    '    If value = Integer.MaxValue Then
    '        EntityData.StatisticMaximums.Remove(statisticType)
    '    Else
    '        EntityData.StatisticMaximums(statisticType) = value
    '    End If
    'End Sub

    'Public Function GetStatisticMinimum(statisticType As String) As Integer Implements IEntity.GetStatisticMinimum
    '    Dim result As Integer
    '    If EntityData.StatisticMinimums.TryGetValue(statisticType, result) Then
    '        Return result
    '    End If
    '    Return Integer.MinValue
    'End Function

    'Public Function GetStatisticMaximum(statisticType As String) As Integer Implements IEntity.GetStatisticMaximum
    '    Dim result As Integer
    '    If EntityData.StatisticMaximums.TryGetValue(statisticType, result) Then
    '        Return result
    '    End If
    '    Return Integer.MaxValue
    'End Function

    'Public Function ChangeStatistic(statisticType As String, delta As Integer) As Integer Implements IEntity.ChangeStatistic
    '    SetStatistic(statisticType, GetStatistic(statisticType) + delta)
    '    Return GetStatistic(statisticType)
    'End Function

    'Public Function HasFlag(flagType As String) As Boolean Implements IEntity.HasFlag
    '    Return EntityData.Flags.Contains(flagType)
    'End Function

    'Public Sub SetFlag(flagType As String, flagValue As Boolean) Implements IEntity.SetFlag
    '    If flagValue Then
    '        EntityData.Flags.Add(flagType)
    '    Else
    '        EntityData.Flags.Remove(flagType)
    '    End If
    'End Sub

    'Protected MustOverride ReadOnly Property EntityData As TEntityData
    Public ReadOnly Property World As IWorld Implements IEntity.World
        Get
            Return New World(Data, PlaySfx)
        End Get
    End Property
End Class
