Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Class NavigationState
    Inherits BaseState
    Implements IUIState
    Const MAP_OFFSET_COLUMN = 1
    Const STATUS_OFFSET_COLUMN = 34
    Const OFFSET_ROW = 1
    Const INVENTORY_OFFSET_ROW = OFFSET_ROW + 4
    Const INVENTORY_COLUMNS = 13

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
        frame.Box(0, 0, buffer.Columns, buffer.Rows, True)
        frame.Box(0, 0, STATUS_OFFSET_COLUMN, buffer.Rows, True)
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
                    Dim item = location.Items.FirstOrDefault
                    If item IsNot Nothing Then
                        hue = item.Hue
                    Else
                        hue = location.Hue
                    End If
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
        buffer.WriteText((STATUS_OFFSET_COLUMN, INVENTORY_OFFSET_ROW), "==Inventory==", 0)
        Dim index As Integer = 0
        For Each item In world.Avatar.Items
            buffer.SetPixel(STATUS_OFFSET_COLUMN + index Mod INVENTORY_COLUMNS, INVENTORY_OFFSET_ROW + 1 + index \ INVENTORY_COLUMNS, item.Hue)
            index += 1
        Next
    End Sub

    Private Function TryMove(directionName As String) As IUIState
        world.Avatar.TryMove(directionName)
        Return InPlayState.DetermineNextState(buffer, world, doEvent)
    End Function


    Public Overrides Function HandleCommand(command As String) As IUIState
        Select Case command
            Case Up
                Return TryMove(Direction.North)
            Case Right
                Return TryMove(Direction.East)
            Case Down
                Return TryMove(Direction.South)
            Case Left
                Return TryMove(Direction.West)
            Case Green
                Return New ActionMenuState(buffer, world, doEvent)
        End Select
        Return Me
    End Function
End Class
