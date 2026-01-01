Imports TGGD.UI

Friend Class AboutMenu
    Inherits BaseState

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
    End Sub


    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.Box((0, 0), (buffer.Columns, 3))
        buffer.WriteCenteredText(1, "About: Gummies of SPLORR!!", 0)
        buffer.WriteText((0, 3), "Gummies of SPLORR!! is a production of          TheGrumpyGameDev made for Glam Jam #2", 0)
        buffer.WriteCenteredText(buffer.Rows - 1, "<Action>", 0)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Select Case command
            Case Green, Red
                Return New MainMenuState(buffer, world, doEvent, 2)
            Case Else
                Return Me
        End Select
    End Function
End Class
