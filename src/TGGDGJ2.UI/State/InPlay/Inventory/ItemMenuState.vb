Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Class ItemMenuState
    Inherits BaseState
    Implements IUIState

    Private ReadOnly menu As Menu

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  doEvent As Action(Of String()))
        MyBase.New(
            buffer,
            world,
            doEvent)
        menu = CreateMenu(buffer, world, doEvent)
    End Sub

    Private Function CreateMenu(
                               buffer As IUIBuffer(Of Integer),
                               world As IWorld,
                               doEvent As Action(Of String())) As Menu
        Dim choices As New List(Of Choice) From
            {
                New Choice("Never Mind", Function()
                                             world.Avatar.CurrentItem = Nothing
                                             Return InventoryMenuState.Launch(buffer, world, doEvent)
                                         End Function)
            }
        Return New Menu((0, 5), choices.ToArray, 0)
    End Function

    Public Overrides Sub Refresh()
        Dim item = world.Avatar.CurrentItem
        buffer.Fill(32)
        buffer.WriteText((0, 0), $"{item.Name}", 0)
        Dim position = (0, 1)
        For Each line In item.Description
            position = buffer.WriteLine(position, line, 0)
        Next
        menu.Render(buffer)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return If(menu.HandleCommand(command), Me)
    End Function
End Class
