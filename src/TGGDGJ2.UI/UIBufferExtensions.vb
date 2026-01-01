Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data
Imports System.Runtime.CompilerServices
Imports TGGD.UI

Friend Module UIBufferExtensions
    Const PAGE_SIZE = 256
    <Extension>
    Friend Function WriteText(buffer As IUIBuffer(Of Integer), position As (Column As Integer, Row As Integer), text As String, page As Integer) As (Column As Integer, Row As Integer)
        Dim column = position.Column Mod buffer.Columns
        Dim row = (position.Row + position.Column \ buffer.Columns) Mod buffer.Rows
        For Each character In text
            buffer.SetPixel(column, row, Asc(character) + page * PAGE_SIZE)
            column += 1
            row = (row + column \ buffer.Columns) Mod buffer.Rows
            column = column Mod buffer.Columns
        Next
        Return (column, row)
    End Function
    <Extension>
    Friend Function WriteLine(buffer As IUIBuffer(Of Integer), position As (Column As Integer, Row As Integer), text As String, page As Integer) As (Column As Integer, Row As Integer)
        position = WriteText(buffer, position, text, page)
        If position.Column = 0 Then
            Return position
        End If
        Return (0, (position.Row + 1) Mod buffer.Rows)
    End Function
    <Extension>
    Friend Function WriteCenteredText(buffer As IUIBuffer(Of Integer), row As Integer, text As String, page As Integer) As (Column As Integer, Row As Integer)
        WriteText(buffer, ((buffer.Columns - text.Length) \ 2, row), text, page)
    End Function
    <Extension>
    Friend Sub Box(buffer As IUIBuffer(Of Integer), position As (Column As Integer, Row As Integer), size As (Columns As Integer, Rows As Integer))
        buffer.Fill(position.Column + 1, position.Row, size.Columns - 2, 1, BORDER_EW)
        buffer.Fill(position.Column + 1, position.Row + size.Rows - 1, size.Columns - 2, 1, BORDER_EW)
        buffer.SetPixel(position.Column, position.Row, BORDER_ES)
        buffer.Fill(position.Column, position.Row + 1, 1, size.Rows - 2, BORDER_NS)
        buffer.SetPixel(position.Column, position.Row + size.Rows - 1, BORDER_NE)
        buffer.SetPixel(position.Column + size.Columns - 1, position.Row, BORDER_SW)
        buffer.Fill(position.Column + size.Columns - 1, position.Row + 1, 1, size.Rows - 2, BORDER_NS)
        buffer.SetPixel(position.Column + size.Columns - 1, position.Row + size.Rows - 1, BORDER_NW)
    End Sub
End Module
