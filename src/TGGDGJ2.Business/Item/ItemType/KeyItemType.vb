Public Class KeyItemType
    Inherits ItemType
    Public Shared ReadOnly Name As String = NameOf(KeyItemType)
    Public Shared ReadOnly Instance As IItemType = New KeyItemType
    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides ReadOnly Property VerbTypes As IEnumerable(Of IVerbType)
        Get
            Return {
                InsertVerbType.Instance
                }
        End Get
    End Property

    Public Overrides Sub Initialize(result As IItem)
    End Sub

    Public Overrides Function GetHue(item As IItem) As Integer
        Return Hue.KEY
    End Function

    Public Overrides Function GetName(item As Item) As String
        Return "Key"
    End Function

    Public Overrides Function GetDescription(item As Item) As IEnumerable(Of String)
        Return {
            "For putting into keyholes to unlock doors.",
            "Do not place in butt. You may lose it."
            }
    End Function
End Class
