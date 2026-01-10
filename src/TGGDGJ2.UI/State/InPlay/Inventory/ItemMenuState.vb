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
        frame.Box(0, 0, buffer.Columns, 3, True)
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
        For Each verbType In world.Avatar.CurrentItem.AvailableVerbs.Where(Function(x) x.CanPerform(world.Avatar))
            choices.Add(New Choice(verbType.Name, DoVerb(buffer, world, doEvent, verbType)))
        Next
        Return New Menu((0, 0), choices.ToArray, 0)
    End Function

    Private Function DoVerb(
                           buffer As IUIBuffer(Of Integer),
                           world As IWorld,
                           doEvent As Action(Of String()),
                           verbType As IVerbType) As Func(Of IUIState)
        Return Function()
                   verbType.Perform(world.Avatar)
                   Return InPlayState.Launch(buffer, world, doEvent)
               End Function
    End Function

    Public Overrides Sub Refresh()
        Dim item = world.Avatar.CurrentItem
        buffer.Fill(32)
        buffer.WriteCenteredText(1, $"{item.Name}", 0)
        Dim position = (0, 3)
        For Each line In item.Description
            position = buffer.WriteLine(position, line, 0)
        Next
        menu.Position = (position.Item1, position.Item2 + 1)
        menu.Render(buffer)
        buffer.DrawFrame((0, 0), frame)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return If(menu.HandleCommand(command), Me)
    End Function
End Class
