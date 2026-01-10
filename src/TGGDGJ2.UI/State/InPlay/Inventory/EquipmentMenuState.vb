Imports TGGD.UI

Friend Class EquipmentMenuState
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
        If world.Avatar.Armor IsNot Nothing Then
            choices.Add(New Choice($"Unequip {world.Avatar.Armor.Name}", UnequipArmor(buffer, world, doEvent)))
        End If
        If world.Avatar.Weapon IsNot Nothing Then
            choices.Add(New Choice($"Unequip {world.Avatar.Weapon.Name}", UnequipWeapon(buffer, world, doEvent)))
        End If
        Return New Menu((0, 0), choices.ToArray, 0)
    End Function

    Private Function UnequipWeapon(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String())) As Func(Of IUIState)
        Return Function()
                   world.Avatar.AddItem(world.Avatar.Weapon)
                   world.Avatar.Weapon = Nothing
                   Return Launch(buffer, world, doEvent)
               End Function
    End Function

    Private Function UnequipArmor(buffer As IUIBuffer(Of Integer), world As Business.IWorld, doEvent As Action(Of String())) As Func(Of IUIState)
        Return Function()
                   world.Avatar.AddItem(world.Avatar.Armor)
                   world.Avatar.Armor = Nothing
                   Return Launch(buffer, world, doEvent)
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
            world.Avatar.HasEquipment,
            CType(New EquipmentMenuState(buffer, world, doEvent), IUIState),
            New ActionMenuState(buffer, world, doEvent))
    End Function
End Class
