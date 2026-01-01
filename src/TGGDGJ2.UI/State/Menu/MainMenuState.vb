Imports TGGD.UI

Friend Class MainMenuState
    Inherits PickerState
    Implements IUIState

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  doEvent As Action(Of String()),
                  choiceIndex As Integer)
        MyBase.New(
            buffer,
            world,
            doEvent,
            choiceIndex,
            MakeChoices(buffer, world, doEvent))
    End Sub

    Private Shared Function MakeChoices(
                                buffer As IUIBuffer(Of Integer),
                                world As Business.IWorld,
                                doEvent As Action(Of String())) As IEnumerable(Of Choice)
        Return {
            New Choice("Embark!", Function() New EmbarkMenu(buffer, world, doEvent)),
            New Choice("Story", Function() New StoryMenu(buffer, world, doEvent)),
            New Choice("About", Function() New AboutMenu(buffer, world, doEvent))
            }
    End Function
End Class
