Friend Class GummerellaCharacterType
    Inherits CharacterType

    Public Overrides Sub Initialize(character As ICharacter)
        character.CreateCounter(Counters.Satiety, 100, 0, 100)
        character.CreateCounter(Counters.Health, 100, 0, 100)
        character.CreateCounter(Counters.Attack, 0, 0, 0)
        character.CreateCounter(Counters.Defend, 0, 0, 0)
    End Sub

    Friend Shared ReadOnly Name As String = NameOf(GummerellaCharacterType)
    Friend Shared ReadOnly Instance As ICharacterType = New GummerellaCharacterType()

    Public Overrides ReadOnly Property VerbTypes As IEnumerable(Of IVerbType)
        Get
            Return Array.Empty(Of IVerbType)
        End Get
    End Property

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
        character.Map.Update()
    End Sub

    Public Overrides Sub Leave(character As ICharacter, location As ILocation)
        MyBase.Leave(character, location)
    End Sub

    Public Overrides Sub Bump(character As ICharacter, location As ILocation)
        MyBase.Bump(character, location)
        Dim target = location.Character
        If target IsNot Nothing Then
            character.StartInteration(target)
        Else
            Dim trigger = location.BumpTrigger
            If trigger IsNot Nothing Then
                trigger.Fire(
                character:=character,
                location:=location)
            End If
        End If
    End Sub

    Public Overrides Sub AddMessage(character As ICharacter, title As String, ParamArray lines() As String)
        character.World.AddMessage(title, lines)
    End Sub

    Public Overrides Sub Update(character As ICharacter)
        Dim satiety = character.GetCounter(Counters.Satiety)
        If satiety.Value > 0 Then
            satiety.Value -= 1
        Else
            character.GetCounter(Counters.Health).Value -= 1
        End If
    End Sub

    Public Overrides Sub StartInteraction(character As ICharacter)
    End Sub

    Public Overrides Function GetName(character As ICharacter) As String
        Return "Gummerella"
    End Function
End Class
