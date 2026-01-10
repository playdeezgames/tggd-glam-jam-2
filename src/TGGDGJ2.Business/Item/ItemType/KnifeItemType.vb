Friend Class KnifeItemType
    Inherits ItemType

    Friend Shared ReadOnly Name As String = NameOf(KnifeItemType)
    Friend Shared ReadOnly Instance As IItemType = New KnifeItemType()

    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides ReadOnly Property VerbTypes As IEnumerable(Of IVerbType)
        Get
            Return {
                WieldVerbType.Instance,
                InsertVerbType.Instance
                }
        End Get
    End Property

    Public Overrides Sub Initialize(result As IItem)
        result.CreateCounter(Counters.Attack, 25, 25, 25)
    End Sub

    Public Overrides Function GetHue(item As IItem) As Integer
        Return Hue.KNIFE
    End Function

    Public Overrides Function GetName(item As Item) As String
        Return "Knife"
    End Function

    Public Overrides Function GetDescription(item As Item) As IEnumerable(Of String)
        Return {
            "Its a knife. Not a noif. I asked an Australian.",
            "He told me...",
            "'That's not a noif.'",
            "Caution: keep out of bum.",
            "For stabbing others, ideally only those who",
            "really need it."}
    End Function
End Class
