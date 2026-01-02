Imports TGGD.UI

Friend Class MainMenuState
    Inherits BaseState
    Implements IUIState
    Private ReadOnly menu As Menu

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  doEvent As Action(Of String()),
                  choiceIndex As Integer)
        MyBase.New(
            buffer,
            world,
            doEvent)
        menu = New Menu(
            (buffer.Columns \ 2 - 4, buffer.Rows \ 2 - 1),
            {
                New Choice("Embark!", Function() New EmbarkMenu(buffer, world, doEvent)),
                New Choice("Story", Function() New StoryMenu(buffer, world, doEvent)),
                New Choice("About", Function() New AboutMenu(buffer, world, doEvent))
            },
            choiceIndex)
        frame.Box(0, 0, buffer.Columns, 3, True)
        frame.Box(buffer.Columns \ 2 - 5, buffer.Rows \ 2 - 2, 10, 5, True)
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        menu.Render(buffer)
        buffer.WriteCenteredText(1, "Main Menu", 0)
        buffer.DrawFrame((0, 0), frame)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return If(menu.HandleCommand(command), Me)
    End Function
End Class
