Imports TGGD.UI

Friend Class NavigationState
    Inherits BaseState
    Implements IUIState
    Const OFFSET_COLUMN = 1
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
            Dim plotX = OFFSET_COLUMN + column
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
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return Me
    End Function
End Class
