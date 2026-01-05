Public Class Message
    Implements IMessage
    Sub New(title As String, lines As IEnumerable(Of String))
        Me.Title = title
        Me.Lines = lines
    End Sub

    Public ReadOnly Property Title As String Implements IMessage.Title

    Public ReadOnly Property Lines As IEnumerable(Of String) Implements IMessage.Lines
End Class
