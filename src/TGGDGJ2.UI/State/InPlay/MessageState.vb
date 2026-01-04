Imports TGGD.UI

Friend Class MessageState
    Inherits BaseState
    Implements IUIState

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        Dim position = (0, 0)
        Dim message = world.GetMessage()
        For Each line In message
            position = buffer.WriteLine(position, line, 0)
        Next
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Select Case command
            Case UI.Command.Green
                world.DismissMessage()
                Return InPlayState.DetermineNextState(buffer, world, doEvent)
            Case Else
                Return Me
        End Select
    End Function
End Class
