Imports TGGD.UI
Imports TGGDGJ2.Business

Friend Module InPlayState
    Friend Function DetermineNextState(
                                      buffer As IUIBuffer(Of Integer),
                                      world As IWorld,
                                      doEvent As Action(Of String())) As IUIState
        Return New NavigationState(buffer, world, doEvent)
    End Function
End Module
