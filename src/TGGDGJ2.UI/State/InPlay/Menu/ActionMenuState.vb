Imports TGGD.UI

Friend Class ActionMenuState
    Inherits BaseState
    Implements IUIState
    Private ReadOnly menu As Menu

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String()))
        MyBase.New(buffer, world, doEvent)
        Dim menuChoices = GenerateChoices(buffer, world, doEvent)
        Me.menu = New Menu((0, 0), menuChoices.ToArray, 0)
        menu.Position = ((buffer.Columns - menu.Columns) \ 2, (buffer.Rows - menu.Rows) \ 2)
        frame.Box(0, 0, buffer.Columns, 3, True)
        frame.Box(menu.Position.Column - 1, menu.Position.Row - 1, menu.Columns + 2, menu.Rows + 2, True)
    End Sub

    Private Shared Function GenerateChoices(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String())) As IEnumerable(Of Choice)
        Dim result As New List(Of Choice) From {
            New Choice("Never Mind", Function() InPlayState.Launch(buffer, world, doEvent)),
            New Choice("Status", Function() StatusState.Launch(buffer, world, doEvent))
        }
        If world.Avatar.HasItems Then
            result.Add(New Choice("Inventory", Function() InventoryMenuState.Launch(buffer, world, doEvent)))
        End If
        If world.Avatar.HasEquipment Then
            result.Add(New Choice("Equipment", Function() EquipmentMenuState.Launch(buffer, world, doEvent)))
        End If
        result.Add(New Choice("Game Menu", Function() New GameMenuState(buffer, world, doEvent)))
        Return result
    End Function

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        buffer.WriteCenteredText(1, "Action Menu", 0)
        menu.Render(buffer)
        buffer.DrawFrame((0, 0), frame)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return If(menu.HandleCommand(command), Me)
    End Function
End Class
