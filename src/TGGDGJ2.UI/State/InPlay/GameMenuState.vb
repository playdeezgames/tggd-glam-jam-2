Imports TGGD.UI

Friend Class GameMenuState
    Inherits BaseState
    Implements IUIState

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.WriteText((0, 0), "TODO: Game Menu", 0)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return InPlayState.DetermineNextState(buffer, world, doEvent)
    End Function
End Class
