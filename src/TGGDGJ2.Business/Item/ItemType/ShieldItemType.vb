Public Class ShieldItemType
    Inherits ItemType

    Friend Shared ReadOnly Name As String = NameOf(ShieldItemType)
    Friend Shared ReadOnly Instance As IItemType = New ShieldItemType()

    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides ReadOnly Property VerbTypes As IEnumerable(Of IVerbType)
        Get
            Return {
                InsertVerbType.Instance,
                WearVerbType.Instance
                }
        End Get
    End Property

    Public Overrides Sub Initialize(result As IItem)
        result.CreateCounter(Counters.Defend, 50, 50, 50)
    End Sub

    Public Overrides Function GetHue(item As IItem) As Integer
        Return Hue.SHIELD
    End Function

    Public Overrides Function GetName(item As Item) As String
        Return "Shield"
    End Function

    Public Overrides Function GetDescription(item As Item) As IEnumerable(Of String)
        Return {
            "It's a shield! You cover yer ass with it!",
            "COVER yer ass. Not fill!"
            }
    End Function
End Class
