Friend Class SnotItemType
    Inherits ItemType

    Friend Shared ReadOnly Name As String = NameOf(SnotItemType)
    Friend Shared ReadOnly Instance As IItemType = New SnotItemType

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
        Return Hue.SNOT
    End Function

    Public Overrides Function GetName(item As Item) As String
        Return "Snot"
    End Function

    Public Overrides Function GetDescription(item As Item) As IEnumerable(Of String)
        Return {
            "It is a pile of snot.",
            "It glistens in the light.",
            "You don't want to touch it."
            }
    End Function
End Class
