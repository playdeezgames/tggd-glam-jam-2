Public Interface IMessage
    ReadOnly Property Title As String
    ReadOnly Property Lines As IEnumerable(Of String)
End Interface
