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

    Public Overrides Sub Enter(character As ICharacter, location As ILocation)
        MyBase.Enter(character, location)
        For Each item In location.Items
            location.RemoveItem(item)
            character.AddItem(item)
        Next
    End Sub

    Public Overrides Sub Leave(character As ICharacter, location As ILocation)
        MyBase.Leave(character, location)
        Dim satiety = character.GetCounter(Counters.Satiety)
        If satiety.Value > 0 Then
            satiety.Value -= 1
        Else
            character.GetCounter(Counters.Health).Value -= 1
        End If
    End Sub

    Public Overrides Sub Bump(character As ICharacter, location As ILocation)
        MyBase.Bump(character, location)
        Dim trigger = location.BumpTrigger
        If trigger IsNot Nothing Then
            trigger.Fire(
                character:=character,
                location:=location)
        End If
    End Sub

    Public Overrides Sub AddMessage(character As ICharacter, title As String, ParamArray lines() As String)
        character.World.AddMessage(title, lines)
    End Sub
End Class
