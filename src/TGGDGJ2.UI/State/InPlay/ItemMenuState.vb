Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Class ItemMenuState
    Inherits BaseState
    Implements IUIState

    Private ReadOnly item As IItem

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  doEvent As Action(Of String()),
                  item As IItem)
        MyBase.New(buffer, world, doEvent)
        Me.item = item
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.WriteText((0, 0), $"{item.Name}", 0)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return New InventoryMenuState(buffer, world, doEvent)
    End Function
End Class
