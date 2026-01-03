Imports System.ComponentModel
Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Class NavigationState
    Inherits BaseState
    Implements IUIState
    Const MAP_OFFSET_COLUMN = 1
    Const STATUS_OFFSET_COLUMN = 34
    Const OFFSET_ROW = 1

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
        frame.Box(0, 0, buffer.Columns, buffer.Rows, True)
        frame.Box(0, 0, 34, buffer.Rows, True)
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.DrawFrame((0, 0), frame)
        Dim map = world.Avatar.Map
        For Each column In Enumerable.Range(0, map.Columns)
            Dim plotX = MAP_OFFSET_COLUMN + column
            For Each row In Enumerable.Range(0, map.Rows)
                Dim plotY = OFFSET_ROW + row
                Dim location = map.GetLocation(column, row)
                Dim character = location.Character
                Dim hue As Integer = 32
                If character IsNot Nothing Then
                    hue = character.Hue
                Else
                    hue = location.Hue
                End If
                buffer.SetPixel(plotX, plotY, hue)
            Next
        Next
        buffer.WriteText((STATUS_OFFSET_COLUMN, OFFSET_ROW), Counters.Health, 0)
        Dim health = world.Avatar.GetCounter(Counters.Health)
        buffer.WriteText((STATUS_OFFSET_COLUMN, OFFSET_ROW + 1), $"{health.Value}/{health.Maximum}", 0)
        buffer.WriteText((STATUS_OFFSET_COLUMN, OFFSET_ROW + 2), Counters.Satiety, 0)
        Dim satiety = world.Avatar.GetCounter(Counters.Satiety)
        buffer.WriteText((STATUS_OFFSET_COLUMN, OFFSET_ROW + 3), $"{satiety.Value}/{satiety.Maximum}", 0)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Select Case command
            Case Up
                world.Avatar.TryMove(Direction.North)
                Return InPlayState.DetermineNextState(buffer, world, doEvent)
            Case Right
                world.Avatar.TryMove(Direction.East)
                Return InPlayState.DetermineNextState(buffer, world, doEvent)
            Case Down
                world.Avatar.TryMove(Direction.South)
                Return InPlayState.DetermineNextState(buffer, world, doEvent)
            Case Left
                world.Avatar.TryMove(Direction.West)
                Return InPlayState.DetermineNextState(buffer, world, doEvent)
        End Select
        Return Me
    End Function
End Class
