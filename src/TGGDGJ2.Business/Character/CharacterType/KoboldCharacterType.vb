Public Class KoboldCharacterType
    Inherits CharacterType

    Friend Shared ReadOnly Name As String = NameOf(KoboldCharacterType)
    Friend Shared ReadOnly Instance As ICharacterType = New KoboldCharacterType

    Private Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Sub Initialize(character As ICharacter)
    End Sub

    Public Overrides Sub AddMessage(character As ICharacter, title As String, ParamArray lines() As String)
    End Sub

    Public Overrides Sub Update(character As ICharacter)
        Dim target = character.World.Avatar
        Dim deltaX = target.Location.Column - character.Location.Column
        Dim deltaY = target.Location.Row - character.Location.Row
        If deltaY < 0 Then
            character.TryMove(Direction.North)
        ElseIf deltaY > 0 Then
            character.TryMove(Direction.South)
        Else
            If deltaX < 0 Then
                character.TryMove(Direction.West)
            ElseIf deltaX > 0 Then
                character.TryMove(Direction.East)
            End If
        End If
    End Sub

    Public Overrides Sub StartInteraction(character As ICharacter)
    End Sub

    Public Overrides Function GetHue(character As ICharacter) As Integer
        Return Hue.KOBOLD
    End Function
End Class
