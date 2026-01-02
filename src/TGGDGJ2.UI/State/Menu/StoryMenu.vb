Imports TGGD.UI

Friend Class StoryMenu
    Inherits BaseState

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
        frame.Box(0, 0, buffer.Columns, buffer.Rows, True)
        frame.HLine(0, 2, buffer.Columns, True)
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.WriteCenteredText(1, "The Story...", 0)

        buffer.WriteText((1, 3), "Everybody knows that there is a giant frog", 0)
        buffer.WriteText((1, 4), "that lives in its own universe named Zex the", 0)
        buffer.WriteText((1, 5), "Guh, and that Zex can only communicate with", 0)
        buffer.WriteText((1, 6), "people in *OUR* universe through the use of", 0)
        buffer.WriteText((1, 7), "Ouija boards and LLMs.", 0)
        buffer.WriteText((1, 9), "This has nothing to do with the story of this", 0)
        buffer.WriteText((1, 10), "game, of course, but is true none-the-less.", 0)
        buffer.WriteText((1, 12), "Yer a gummy creature in the world of SPLORR!!", 0)
        buffer.WriteText((1, 13), "which has a number of advantages and", 0)
        buffer.WriteText((1, 14), "disadvantages, the most notable of which is", 0)
        buffer.WriteText((1, 15), "that yer extremely tasty.", 0)
        buffer.WriteCenteredText(17, "<ACTION>", 0)
        buffer.DrawFrame((0, 0), frame)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Select Case command
            Case Green, Red, Blue
                Return New MainMenuState(buffer, world, doEvent, 1)
            Case Else
                Return Me
        End Select
    End Function
End Class
