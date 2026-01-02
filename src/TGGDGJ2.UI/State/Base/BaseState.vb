Imports TGGD.UI
Imports TGGDGJ2.Business

Friend MustInherit Class BaseState
    Implements IUIState
    Protected ReadOnly buffer As IUIBuffer(Of Integer)
    Protected ReadOnly world As IWorld
    Protected ReadOnly doEvent As Action(Of String())
    Protected ReadOnly frame As IUIBuffer(Of Boolean)

    Public Sub New(buffer As IUIBuffer(Of Integer), world As IWorld, doEvent As Action(Of String()))
        Me.buffer = buffer
        Me.world = world
        Me.doEvent = doEvent
        Me.frame = New UIBuffer(Of Boolean)(buffer.Columns, buffer.Rows, Enumerable.Repeat(False, buffer.Columns * buffer.Rows).ToArray())
    End Sub

    Public MustOverride Sub Refresh() Implements IUIState.Refresh
    Public MustOverride Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
End Class
