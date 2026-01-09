Public Class PotionItemType
    Inherits ItemType

    Friend Shared ReadOnly Name As String = NameOf(PotionItemType)
    Friend Shared ReadOnly Instance As IItemType = New PotionItemType()

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
        Return Hue.POTION
    End Function

    Public Overrides Function GetName(item As Item) As String
        Return "Potion"
    End Function

    Public Overrides Function GetDescription(item As Item) As IEnumerable(Of String)
        Return {
            "------------------------------------------------",
            "It's a potion. You drink it.",
            "Intended to be consumed orally. ORALLY."
            }
    End Function
End Class
