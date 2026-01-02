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
    Friend Sub DrawFrame(
                        buffer As IUIBuffer(Of Integer),
                        position As (Column As Integer, Row As Integer),
                        frame As IUIBuffer(Of Boolean))
        For Each x In Enumerable.Range(0, frame.Columns)
            For Each y In Enumerable.Range(0, frame.Rows)
                If frame.GetPixel(x, y) Then
                    Dim hue = 0
                    If frame.GetPixel(x, y - 1) Then
                        hue += 1
                    End If
                    If frame.GetPixel(x + 1, y) Then
                        hue += 2
                    End If
                    If frame.GetPixel(x, y + 1) Then
                        hue += 4
                    End If
                    If frame.GetPixel(x - 1, y) Then
                        hue += 8
                    End If
                    buffer.SetPixel(x + position.Column, y + position.Row, hue)
                End If
            Next
        Next
    End Sub
End Module
