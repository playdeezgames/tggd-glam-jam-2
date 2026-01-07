Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Module InPlayState
    Friend Function Launch(
                          buffer As IUIBuffer(Of Integer),
                          world As IWorld,
                          doEvent As Action(Of String())) As IUIState
        If world.HasMessage Then
            Return New MessageState(buffer, world, doEvent)
        End If
        If world.Avatar.IsDead Then
            Return New DeadState(buffer, world, doEvent)
        End If
        Return New NavigationState(buffer, world, doEvent)
    End Function
End Module
