Public Class UIBuffer(Of TPixel)
    Implements IUIBuffer(Of TPixel)

    Private ReadOnly pixelBuffer As TPixel()

    Sub New(columns As Integer, rows As Integer, pixelBuffer As TPixel())
        Me.columns = columns
        Me.rows = rows
        Me.pixelBuffer = pixelBuffer
    End Sub

    Public ReadOnly Property Columns As Integer Implements IUIBuffer(Of TPixel).Columns

    Public ReadOnly Property Rows As Integer Implements IUIBuffer(Of TPixel).Rows

    Public Sub SetPixel(column As Integer, row As Integer, hue As TPixel) Implements IUIBuffer(Of TPixel).SetPixel
        If column >= 0 AndAlso column < Columns AndAlso row >= 0 AndAlso row < Rows Then
            pixelBuffer(column + row * Columns) = hue
        End If
    End Sub

    Public Sub Fill(column As Integer, row As Integer, columns As Integer, rows As Integer, hue As TPixel) Implements IUIBuffer(Of TPixel).Fill
        For Each y In Enumerable.Range(row, rows)
            For Each x In Enumerable.Range(column, columns)
                SetPixel(x, y, hue)
            Next
        Next
    End Sub

    Public Sub Fill(hue As TPixel) Implements IUIBuffer(Of TPixel).Fill
        Fill(0, 0, columns, rows, hue)
    End Sub

    Public Sub VLine(column As Integer, row As Integer, rows As Integer, hue As TPixel) Implements IUIBuffer(Of TPixel).VLine
        Fill(column, row, 1, rows, hue)
    End Sub

    Public Sub HLine(column As Integer, row As Integer, columns As Integer, hue As TPixel) Implements IUIBuffer(Of TPixel).HLine
        Fill(column, row, columns, 1, hue)
    End Sub

    Public Sub Box(column As Integer, row As Integer, columns As Integer, rows As Integer, hue As TPixel) Implements IUIBuffer(Of TPixel).Box
        HLine(column, row, columns, hue)
        HLine(column, row + rows - 1, columns, hue)
        VLine(column, row, rows, hue)
        VLine(column + columns - 1, row, rows, hue)
    End Sub

    Public Function GetPixel(column As Integer, row As Integer) As TPixel Implements IUIBuffer(Of TPixel).GetPixel
        If column >= 0 AndAlso column < Columns AndAlso row >= 0 AndAlso row < Rows Then
            Return pixelBuffer(column + row * Columns)
        End If
        Return CType(Nothing, TPixel)
    End Function
End Class
