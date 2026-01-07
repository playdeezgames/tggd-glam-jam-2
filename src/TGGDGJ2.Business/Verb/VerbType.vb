Public MustInherit Class VerbType
    Implements IVerbType
    Protected Sub New()

    End Sub

    Public MustOverride ReadOnly Property Name As String Implements IVerbType.Name
    Public MustOverride Sub Perform(character As ICharacter) Implements IVerbType.Perform
    Public MustOverride Function CanPerform(character As ICharacter) As Boolean Implements IVerbType.CanPerform
End Class
