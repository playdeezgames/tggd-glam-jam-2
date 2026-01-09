Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Class TitleState
    Inherits BaseState

    Public Sub New(buffer As IUIBuffer(Of Integer), world As IWorld, doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
        frame.Box(0, 0, buffer.Columns, 3, True)
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.DrawFrame((0, 0), frame)
        buffer.WriteCenteredText(1, "Gummies of SPLORR!!", 0)
        buffer.WriteCenteredText(3, "A Production of TheGrumpyGameDev", 0)
        buffer.WriteCenteredText(4, "For Glam Jam #2", 0)
        buffer.WriteCenteredText(6, "Controls:", 0)
        buffer.WriteCenteredText(7, "W,Z,Up Arrow: Up", 0)
        buffer.WriteCenteredText(8, "S,Down Arrow: Down", 0)
        buffer.WriteCenteredText(9, "A,Q,Left Arrow: Left", 0)
        buffer.WriteCenteredText(10, "D,Right Arrow: Right", 0)
        buffer.WriteCenteredText(11, "Space: Action", 0)
        buffer.WriteCenteredText(12, "Backspace: Cancel", 0)
        buffer.WriteCenteredText(15, "-Click Screen To Focus Keyboard Input-", 0)
        buffer.WriteCenteredText(buffer.Rows - 1, "Press <SPACE>", 0)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Select Case command
            Case UI.Command.Green
                Return New MainMenuState(buffer, world, doEvent, 0)
            Case Else
                Return Me
        End Select
    End Function
End Class
