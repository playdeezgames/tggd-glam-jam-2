Imports TGGD.UI

Friend Class MessageState
    Inherits BaseState
    Implements IUIState

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
        frame.Box(0, 0, buffer.Columns, 3, True)
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        Dim message = world.GetMessage()
        buffer.WriteCenteredText(1, message.Title, 0)
        Dim position = (0, 3)
        For Each line In message.Lines
            position = buffer.WriteLine(position, line, 0)
        Next
        buffer.DrawFrame((0, 0), frame)
        buffer.WriteCenteredText(buffer.Rows - 1, "<SPACE> to Continue...", 0)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Select Case command
            Case UI.Command.Green
                world.DismissMessage()
                Return InPlayState.Launch(buffer, world, doEvent)
            Case Else
                Return Me
        End Select
    End Function
End Class
