Imports TGGD.UI

Friend Class InteractionState
    Inherits BaseState
    Implements IUIState

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.WriteText((0, 0), "TODO: interaction", 0)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return Me
    End Function
End Class
