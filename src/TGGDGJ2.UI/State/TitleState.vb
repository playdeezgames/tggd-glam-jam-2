Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Class TitleState
    Implements IUIState

    Private ReadOnly buffer As IUIBuffer(Of Integer)
    Private ReadOnly world As IWorld
    Private ReadOnly doEvent As Action(Of String)

    Public Sub New(buffer As IUIBuffer(Of Integer), world As IWorld, doEvent As Action(Of String))
        Me.buffer = buffer
        Me.world = world
        Me.doEvent = doEvent
    End Sub

    Public Sub Refresh() Implements IUIState.Refresh
        buffer.Fill(32)
        buffer.Fill(1, 0, buffer.Columns - 2, 1, 10)
        buffer.Fill(1, 2, buffer.Columns - 2, 1, 10)
        buffer.SetPixel(0, 0, 6)
        buffer.SetPixel(0, 1, 5)
        buffer.SetPixel(0, 2, 3)
        buffer.SetPixel(buffer.Columns - 1, 0, 12)
        buffer.SetPixel(buffer.Columns - 1, 1, 5)
        buffer.SetPixel(buffer.Columns - 1, 2, 9)
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
        buffer.WriteCenteredText(buffer.Rows - 1, "Press <Action>", 0)
    End Sub

    Public Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
        Select Case command
            Case UI.Command.Green
                Return New TitleState(buffer, world, doEvent) 'TODO: main menu!
            Case Else
                Return Me
        End Select
    End Function
End Class
