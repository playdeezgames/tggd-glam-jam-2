Imports TGGD.UI

Friend Class Menu
    Private ReadOnly choices As Choice()
    Private ReadOnly position As (Column As Integer, Row As Integer)
    Private choiceIndex As Integer

    Sub New(position As (Column As Integer, Row As Integer), choices As Choice(), choiceIndex As Integer)
        Me.choices = choices
        Me.choiceIndex = choiceIndex
        Me.position = position
    End Sub
    Sub Render(buffer As IUIBuffer(Of Integer))
        For Each index In Enumerable.Range(0, choices.Length)
            Dim choice = choices(index)
            buffer.WriteText((position.Column, position.Row + index), $"{If(choiceIndex = index, ">", " ")}{choice.Text}", 0)
        Next
    End Sub
    Function HandleCommand(command As String) As IUIState
        Select Case command
            Case Up
                choiceIndex = (choiceIndex + choices.Length - 1) Mod choices.Length
            Case Down
                choiceIndex = (choiceIndex + 1) Mod choices.Length
            Case Green, Blue
                Return choices(choiceIndex).Choose()
        End Select
        Return Nothing
    End Function
End Class
