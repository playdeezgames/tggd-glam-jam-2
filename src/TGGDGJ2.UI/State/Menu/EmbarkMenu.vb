Imports TGGD.UI

Friend Class EmbarkMenu
    Inherits BaseState

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
    End Sub


    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.WriteText((0, 0), "TODO: Embark!", 0)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Select Case command
            Case Green, Red, Blue
                Return New MainMenuState(buffer, world, doEvent, 0)
            Case Else
                Return Me
        End Select
    End Function
End Class
