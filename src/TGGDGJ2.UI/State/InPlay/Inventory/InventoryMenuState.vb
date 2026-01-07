Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Class InventoryMenuState
    Inherits BaseState
    Implements IUIState

    Private ReadOnly menu As Menu

    Private Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
        menu = CreateMenu(world)
    End Sub

    Private Function CreateMenu(world As Business.IWorld) As Menu
        Dim choices As New List(Of Choice) From
            {
                New Choice("Never Mind", Function() New ActionMenuState(buffer, world, doEvent))
            }
        For Each item In world.Avatar.Items
            choices.Add(New Choice(item.Name, ChooseItem(buffer, world, doEvent, item)))
        Next
        Return New Menu((0, 0), choices.ToArray, 0)
    End Function

    Private Shared Function ChooseItem(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String()), item As IItem) As Func(Of IUIState)
        Return Function()
                   world.Avatar.CurrentItem = item
                   Return New ItemMenuState(buffer, world, doEvent)
               End Function
    End Function

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        menu.Render(buffer)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return If(menu.HandleCommand(command), Me)
    End Function

    Friend Shared Function Launch(
                          buffer As IUIBuffer(Of Integer),
                          world As Business.IWorld,
                          doEvent As Action(Of String())) As IUIState
        Return If(
            world.Avatar.HasItems,
            CType(New InventoryMenuState(buffer, world, doEvent), IUIState),
            New ActionMenuState(buffer, world, doEvent))
    End Function
End Class
