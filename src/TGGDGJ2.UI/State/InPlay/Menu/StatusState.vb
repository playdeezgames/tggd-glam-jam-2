Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Class StatusState
    Inherits BaseState

    Private Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
        frame.Box(0, 0, buffer.Columns, 3, True)
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.WriteCenteredText(1, "Status", 0)
        Dim position = (0, 3)
        Dim health = world.Avatar.GetCounter(Counters.Health)
        Dim satiety = world.Avatar.GetCounter(Counters.Satiety)
        Dim attackValue = world.Avatar.GetAttackValue()
        Dim defendValue = world.Avatar.GetDefendValue()
        Dim xp = world.Avatar.GetCounter(Counters.XP)
        Dim xpLevel = world.Avatar.GetCounter(Counters.XPLevel).Value
        position = buffer.WriteLine(position, $"Health: {health.Value}/{health.Maximum}", 0)
        position = buffer.WriteLine(position, $"Satiety: {Satiety.Value}/{Satiety.Maximum}", 0)
        position = buffer.WriteLine(position, $"Attack: {attackValue}", 0)
        position = buffer.WriteLine(position, $"Defend: {defendValue}", 0)
        position = buffer.WriteLine(position, $"XP: {xp.Value}/{xp.Maximum}", 0)
        position = buffer.WriteLine(position, $"XP Level: {xpLevel}", 0)
        buffer.DrawFrame((0, 0), frame)
    End Sub

    Friend Shared Function Launch(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String())) As IUIState
        Return New StatusState(buffer, world, doEvent)
    End Function

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return New ActionMenuState(buffer, world, doEvent)
    End Function
End Class
