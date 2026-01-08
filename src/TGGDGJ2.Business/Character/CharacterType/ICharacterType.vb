Public Interface ICharacterType
    ReadOnly Property CharacterTypeName As String
    Sub Initialize(character As ICharacter)
    Sub Enter(character As ICharacter, location As ILocation)
    Sub Leave(character As ICharacter, location As ILocation)
    Sub Bump(character As ICharacter, location As ILocation)
    Sub AddMessage(character As ICharacter, title As String, ParamArray lines() As String)
    Sub Update(character As ICharacter)
    Sub StartInteraction(character As ICharacter)
    Function GetHue(character As ICharacter) As Integer
    Function CanEnter(character As ICharacter, location As ILocation) As Boolean
    Function GetName(character As ICharacter) As String
    ReadOnly Property VerbTypes As IEnumerable(Of IVerbType)
End Interface
