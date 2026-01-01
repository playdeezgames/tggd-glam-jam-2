Imports TGGD.UI

Friend Class PickerState
    Inherits BaseState
    Private ReadOnly choices As Choice()
    Private choiceIndex As Integer

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  doEvent As Action(Of String()),
                  choiceIndex As Integer,
                  choices As IEnumerable(Of Choice))
        MyBase.New(buffer, world, doEvent)
        Me.choiceIndex = choiceIndex
        Me.choices = choices.ToArray
    End Sub

    Public Overrides Sub Refresh()
        buffer.Fill(32)
        For Each index In Enumerable.Range(0, choices.Length)
            Dim choice = choices(index)
            Dim text = $"{If(index = choiceIndex, ">", " ")}{choice.Text}"
            buffer.WriteText((0, index), text, 0)
        Next
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Select Case command
            Case Up
                choiceIndex = (choiceIndex + choices.Length - 1) Mod choices.Length
                Return Me
            Case Down
                choiceIndex = (choiceIndex + 1) Mod choices.Length
                Return Me
            Case Green
                Return If(choices(choiceIndex).Choose.Invoke(), Me)
            Case Else
                Return Me
        End Select
    End Function
End Class
