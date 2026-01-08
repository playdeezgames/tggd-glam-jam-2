Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Class InteractionState
    Inherits BaseState
    Implements IUIState
    Private ReadOnly menu As Menu

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
        menu = CreateMenu(buffer, world, doEvent)
    End Sub

    Private Function CreateMenu(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String())) As Menu
        Dim choices As New List(Of Choice) From
            {
                New Choice("Disengage", Function()
                                            world.Avatar.InteractionTarget = Nothing
                                            Return InPlayState.Launch(buffer, world, doEvent)
                                        End Function)
            }
        For Each verbType In world.Avatar.InteractionTarget.AvailableVerbs.Where(Function(x) x.CanPerform(world.Avatar))
            choices.Add(New Choice(verbType.Name, DoVerb(buffer, world, doEvent, verbType)))
        Next
        Return New Menu((0, 5), choices.ToArray, 0)
    End Function

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.WriteText((0, 0), "TODO: interaction", 0)
        menu.Render(buffer)
    End Sub
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

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return If(menu.HandleCommand(command), Me)
    End Function
End Class
