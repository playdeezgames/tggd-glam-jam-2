Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data
Imports System.Runtime.CompilerServices
Imports TGGD.UI

Friend Module UIBufferExtensions
    <Extension>
    Friend Function WriteText(buffer As IUIBuffer(Of Integer), position As (Column As Integer, Row As Integer), text As String) As (Column As Integer, Row As Integer)
        Dim column = position.Column Mod buffer.Columns
        Dim row = (position.Row + position.Column \ buffer.Columns) Mod buffer.Rows
        For Each character In text
            buffer.SetPixel(column, row, Asc(character))
            column += 1
            row = (row + column \ buffer.Columns) Mod buffer.Rows
            column = column Mod buffer.Columns
        Next
        Return (column, row)
    End Function
    <Extension>
    Friend Function WriteLine(buffer As IUIBuffer(Of Integer), position As (Column As Integer, Row As Integer), text As String) As (Column As Integer, Row As Integer)
        position = WriteText(buffer, position, text)
        If position.Column = 0 Then
            Return position
        End If
        Return (0, (position.Row + 1) Mod buffer.Rows)
    End Function
    <Extension>
    Friend Function WriteCenteredText(buffer As IUIBuffer(Of Integer), row As Integer, text As String) As (Column As Integer, Row As Integer)
        WriteText(buffer, ((buffer.Columns - text.Length) \ 2, row), text)
    End Function
End Module
