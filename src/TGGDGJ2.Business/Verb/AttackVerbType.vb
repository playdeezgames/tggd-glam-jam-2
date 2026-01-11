Imports TGGD.Business

Public Class AttackVerbType
    Inherits VerbType

    Friend Shared ReadOnly Instance As IVerbType = New AttackVerbType

    Private Sub New()
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Attack!"
        End Get
    End Property

    Public Overrides Sub Perform(character As ICharacter)
        DoAttack(character, character.InteractionTarget)
        If Not character.InteractionTarget.IsDead Then
            DoAttack(character.InteractionTarget, character)
        Else
            character.InteractionTarget.Die()
            character.InteractionTarget = Nothing
        End If
    End Sub

    Private Sub DoAttack(attacker As ICharacter, defender As ICharacter)
        Dim lines As New List(Of String) From {
            $"{attacker.Name} attacks {defender.Name}!"
        }
        Dim attack = attacker.GetAttackValue()
        lines.Add($"{attacker.Name} has an attack strength of {attack}!")
        Dim defend = defender.GetDefendValue()
        lines.Add($"{defender.Name} has a defend strength of {defend}!")
        Dim damage = Math.Max(attack - defend, 0)
        lines.Add($"{defender.Name} takes {damage} points of damage!")
        Dim health = defender.GetCounter(Counters.Health)
        health.Value -= damage
        lines.Add($"{defender.Name} has {health.Value}/{health.Maximum} health remaining!")
        If defender.IsDead Then
            lines.Add($"{attacker.Name} kills {defender.Name}!")
        End If
        attacker.AddMessage($"COMBAT!", lines.ToArray)
        defender.AddMessage($"COMBAT!", lines.ToArray)
        If defender.IsDead Then
            attacker.Kill(defender)
        End If
    End Sub

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return character.InteractionTarget IsNot Nothing
    End Function
End Class
