Imports TGGD.UI

Friend Class MainMenuState
    Inherits PickerState
    Implements IUIState

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  doEvent As Action(Of String()))
        MyBase.New(
            buffer,
            world,
            doEvent,
            0,
            MakeChoices(buffer, world, doEvent))
    End Sub

    Private Shared Function MakeChoices(
                                buffer As IUIBuffer(Of Integer),
                                world As Business.IWorld,
                                doEvent As Action(Of String())) As IEnumerable(Of Choice)
        Return {
            New Choice("Embark!", Function() Nothing),
            New Choice("Story", Function() Nothing),
            New Choice("About", Function() Nothing)
            }
    End Function
End Class
