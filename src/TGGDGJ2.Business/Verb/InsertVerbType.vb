Public Class InsertVerbType
    Inherits VerbType
    Friend Shared ReadOnly Instance As IVerbType = New InsertVerbType
    Private Sub New()

    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Insert(into bum)"
        End Get
    End Property

    Public Overrides Sub Perform(character As ICharacter)
        character.AddMessage("Seriously?", "Dude, I told you *NOT* to.")
        character.CurrentItem = Nothing
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return character.CurrentItem IsNot Nothing
    End Function
End Class
