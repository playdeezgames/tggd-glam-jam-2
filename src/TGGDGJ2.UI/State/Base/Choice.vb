Imports TGGD.UI

Friend Class Choice
    Sub New(text As String, choose As Func(Of IUIState))
        Me.Text = text
        Me._choose = choose
    End Sub
    Property Text As String
    Private ReadOnly _choose As Func(Of IUIState)

    Function Choose() As IUIState
        Return _choose()
    End Function
End Class
