Imports TGGD.UI
Imports TGGDGJ2.Business
Imports TGGDGJ2.Data

Public Class UIContext
    Implements IUIContext
    ReadOnly buffer As IUIBuffer(Of Integer)
    Private state As IUIState = Nothing
    Private ReadOnly sfxQueue As New Queue(Of String())
    Private ReadOnly worldData As New WorldData
    Private ReadOnly Property World As IWorld
        Get
            Return New Business.World(worldData, AddressOf PlaySfx)
        End Get
    End Property

    Public ReadOnly Property Sfx As String() Implements IUIContext.Sfx
        Get
            Return If(sfxQueue.Any, sfxQueue.Peek, Nothing)
        End Get
    End Property

    Sub New(columns As Integer, rows As Integer, pixelBuffer As Integer())
        Me.buffer = New UIBuffer(Of Integer)(columns, rows, pixelBuffer)
        state = New TitleState(buffer, World, AddressOf PlaySfx)
    End Sub
    Private Sub PlaySfx(ParamArray sfx As String())
        sfxQueue.Enqueue(sfx)
    End Sub

    Public Sub Refresh() Implements IUIContext.Refresh
        state.Refresh()
    End Sub

    Public Sub HandleCommand(command As String) Implements IUIContext.HandleCommand
        state = state.HandleCommand(command)
    End Sub

    Public Sub NextSfx() Implements IUIContext.NextSfx
        If sfxQueue.Any Then
            sfxQueue.Dequeue()
        End If
    End Sub
End Class
