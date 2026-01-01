Imports TGGD.UI

Friend Class Choice
    Sub New(text As String, choose As Func(Of IUIState))
        Me.Text = text
        Me.Choose = choose
    End Sub
    ReadOnly Property Text As String
    ReadOnly Property Choose As Func(Of IUIState)
End Class
