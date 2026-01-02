Public Interface IUIBuffer(Of TPixel)
    Sub SetPixel(column As Integer, row As Integer, hue As TPixel)
    Function GetPixel(column As Integer, row As Integer) As TPixel
    Sub Fill(column As Integer, row As Integer, columns As Integer, rows As Integer, hue As TPixel)
    Sub Fill(hue As TPixel)
    Sub VLine(column As Integer, row As Integer, rows As Integer, hue As TPixel)
    Sub HLine(column As Integer, row As Integer, columns As Integer, hue As TPixel)
    Sub Box(column As Integer, row As Integer, columns As Integer, rows As Integer, hue As TPixel)
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
End Interface
