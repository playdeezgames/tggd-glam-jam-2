Public Interface IUIContext
    Sub Refresh()
    Sub HandleCommand(command As String)
    ReadOnly Property CurrentEvent As String()
    Sub NextEvent()
End Interface
