Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Class TitleState
    Implements IUIState

    Private ReadOnly buffer As IUIBuffer(Of Integer)
    Private ReadOnly world As IWorld
    Private ReadOnly playSfx As Action(Of String)

    Public Sub New(buffer As IUIBuffer(Of Integer), world As IWorld, playSfx As Action(Of String))
        Me.buffer = buffer
        Me.world = world
        Me.playSfx = playSfx
    End Sub

    Public Sub Refresh() Implements IUIState.Refresh
        buffer.Fill(32)
        buffer.WriteCenteredText(1, "GUMMIES OF SPLORR!!")
        buffer.WriteCenteredText(3, "A PRODUCTION OF THEGRUMPYGAMEDEV")
        buffer.WriteCenteredText(4, "FOR GLAM JAM #2")
        buffer.WriteCenteredText(6, "W,Z,UP ARROW: UP")
        buffer.WriteCenteredText(7, "S,DOWN ARROW: DOWN")
        buffer.WriteCenteredText(8, "A,Q,LEFT ARROW: LEFT")
        buffer.WriteCenteredText(9, "D,RIGHT ARROW: RIGHT")
        buffer.WriteCenteredText(10, "SPACE: ACTION")
        buffer.WriteCenteredText(11, "BACKSPACE: CANCEL")
        buffer.WriteCenteredText(buffer.Rows - 1, "         PRESS <ACTION>         ")
    End Sub

    Public Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
        Select Case command
            Case UI.Command.Green
                Return New TitleState(buffer, world, playSfx) 'TODO: main menu!
            Case Else
                Return Me
        End Select
    End Function
End Class
