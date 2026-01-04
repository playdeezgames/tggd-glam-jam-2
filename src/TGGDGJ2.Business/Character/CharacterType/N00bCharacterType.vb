Friend Class N00bCharacterType
    Inherits CharacterType

    Public Overrides Sub Initialize(character As ICharacter)
        character.CreateCounter(Counters.Satiety, 100, 0, 100)
        character.CreateCounter(Counters.Health, 100, 0, 100)
    End Sub

    Friend Shared ReadOnly Name As String = NameOf(N00bCharacterType)
    Friend Shared ReadOnly Instance As ICharacterType = New N00bCharacterType()

    Public Sub New()
        MyBase.New(Name)
    End Sub

    Public Overrides Function GetHue(character As ICharacter) As Integer
        Return Hue.N00B
    End Function

    Public Overrides Sub Leave(character As ICharacter, location As ILocation)
        MyBase.Leave(character, location)
        Dim satiety = character.GetCounter(Counters.Satiety)
        If satiety.Value > 0 Then
            satiety.Value -= 1
        Else
            character.GetCounter(Counters.Health).Value -= 1
        End If
    End Sub
End Class
