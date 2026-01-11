Imports TGGD.UI

Friend Class StatusState
    Inherits BaseState

    Private Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.WriteText((0, 0), "TODO: Status", 0)
    End Sub

    Friend Shared Function Launch(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String())) As IUIState
        Return New StatusState(buffer, world, doEvent)
    End Function

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return New ActionMenuState(buffer, world, doEvent)
    End Function
End Class
