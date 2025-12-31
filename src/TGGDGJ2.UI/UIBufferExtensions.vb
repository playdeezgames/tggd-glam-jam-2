Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data
Imports System.Runtime.CompilerServices
Imports TGGD.UI

Friend Module UIBufferExtensions
    Private ReadOnly table As IReadOnlyDictionary(Of Char, Integer) = New Dictionary(Of Char, Integer) From
        {
            {"a"c, 1},
            {"b"c, 2},
            {"c"c, 3},
            {"d"c, 4},
            {"e"c, 5},
            {"f"c, 6},
            {"g"c, 7},
            {"h"c, 8},
            {"i"c, 9},
            {"j"c, 10},
            {"k"c, 11},
            {"l"c, 12},
            {"m"c, 13},
            {"n"c, 14},
            {"o"c, 15},
            {"p"c, 16},
            {"q"c, 17},
            {"r"c, 18},
            {"s"c, 19},
            {"t"c, 20},
            {"u"c, 21},
            {"v"c, 22},
            {"w"c, 23},
            {"x"c, 24},
            {"y"c, 25},
            {"z"c, 26},
            {"_"c, 32},
            {"@"c, 64},
            {"A"c, 65},
            {"B"c, 66},
            {"C"c, 67},
            {"D"c, 68},
            {"E"c, 69},
            {"F"c, 70},
            {"G"c, 71},
            {"H"c, 72},
            {"I"c, 73},
            {"J"c, 74},
            {"K"c, 75},
            {"L"c, 76},
            {"M"c, 77},
            {"N"c, 78},
            {"O"c, 79},
            {"P"c, 80},
            {"Q"c, 81},
            {"R"c, 82},
            {"S"c, 83},
            {"T"c, 84},
            {"U"c, 85},
            {"V"c, 86},
            {"W"c, 87},
            {"X"c, 88},
            {"Y"c, 89},
            {"Z"c, 90},
            {"["c, 91},
            {"\"c, 92},
            {"]"c, 93},
            {"^"c, 94},
            {" "c, 96},
            {"!"c, 97},
            {""""c, 98},
            {"#"c, 99},
            {"$"c, 100},
            {"%"c, 101},
            {"&"c, 102},
            {"'"c, 103},
            {"("c, 104},
            {")"c, 105},
            {"*"c, 106},
            {"+"c, 107},
            {","c, 108},
            {"-"c, 109},
            {"."c, 110},
            {"/"c, 111},
            {"0"c, 112},
            {"1"c, 113},
            {"2"c, 114},
            {"3"c, 115},
            {"4"c, 116},
            {"5"c, 117},
            {"6"c, 118},
            {"7"c, 119},
            {"8"c, 120},
            {"9"c, 121},
            {":"c, 122},
            {";"c, 123},
            {"<"c, 124},
            {"="c, 125},
            {">"c, 126},
            {"?"c, 127}
        }
    <Extension>
    Friend Function WriteText(buffer As IUIBuffer(Of Integer), position As (Column As Integer, Row As Integer), text As String) As (Column As Integer, Row As Integer)
        Dim column = position.Column Mod buffer.Columns
        Dim row = (position.Row + position.Column \ buffer.Columns) Mod buffer.Rows
        For Each character In text
            buffer.SetPixel(column, row, table(character))
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
    <Extension>
    Friend Sub Invert(buffer As IUIBuffer(Of Integer), column As Integer, row As Integer, columns As Integer, rows As Integer)
        For Each x In Enumerable.Range(column, columns)
            For Each y In Enumerable.Range(row, rows)
                buffer.SetPixel(x, y, buffer.GetPixel(x, y) Xor 64)
            Next
        Next
    End Sub
    <Extension>
    Friend Function WriteInvertedCenteredText(buffer As IUIBuffer(Of Integer), row As Integer, text As String) As (Column As Integer, Row As Integer)
        WriteText(buffer, ((buffer.Columns - text.Length) \ 2, row), text)
        Invert(buffer, 0, row, buffer.Columns, 1)
    End Function
End Module
