Imports System.Drawing
Imports System.IO

Module Program
    Const FILENAME = "font.png"
    Const OUTPUT_FILENAME = "output.png"
    Const OUTPUT_TEXT_FILENAME = "output.txt"
    Const SCALE_X = 4
    Const SCALE_Y = 4
    Sub Main(args As String())
        Using fromImage As Bitmap = CType(Image.FromFile(FILENAME), Bitmap)
            Using toBitmap = New Bitmap(fromImage.Width * SCALE_X, fromImage.Height * SCALE_Y)
                For Each column In Enumerable.Range(0, fromImage.Width)
                    For Each row In Enumerable.Range(0, fromImage.Height)
                        Dim pixel = fromImage.GetPixel(column, row)
                        For Each x In Enumerable.Range(0, SCALE_X)
                            For Each y In Enumerable.Range(0, SCALE_Y)
                                toBitmap.SetPixel(column * SCALE_X + x, row * SCALE_Y + y, pixel)
                            Next
                        Next
                    Next
                Next
                toBitmap.Save(OUTPUT_FILENAME)
            End Using
        End Using
        Dim allBytes = File.ReadAllBytes(OUTPUT_FILENAME)
        Dim base64 = Convert.ToBase64String(allBytes)
        File.WriteAllText(OUTPUT_TEXT_FILENAME, $"data:image/png;base64,{base64}")
    End Sub
End Module
