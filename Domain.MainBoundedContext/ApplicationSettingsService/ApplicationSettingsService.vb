Imports degloba.Mod.Core.SICA.Mod.Core
Imports SICA.Mod.Core

Public Class ApplicationSettingsService
    Implements IApplicationSettingsService

#Region "Constants privades"

    Private Const CONST_DEFAULT_USER As String = "WS_USER"
    Private Const CONST_HEADER_USR As String = "USR"
    Private Const CONST_HEADER_NAMESPACE As String = "http://althaia.cat/DistSvc/ETF/"
#End Region

#Region "Variables privades"

    Private _user As String = Nothing
    Private _scope As String = Nothing
    Private _applicationName As String = Nothing
    Private _applicationUserRol As String
    Private _applicationClientComputer As String

    Private _repositorySys As ISysRepository
    Private _clientCredentials As IClientCredentials
#End Region

#Region "Constructors"

    Sub New(scope As String, repositorySys As ISysRepository, clientCredentials As IClientCredentials)
        _scope = scope
        _repositorySys = repositorySys
        _clientCredentials = clientCredentials
    End Sub
#End Region

#Region "Propietats públiques"

    Public ReadOnly Property User As String Implements IApplicationSettingsService.User
        Get
            If String.IsNullOrEmpty(_user) Then
                _user = Me.GetUserFromHeader()
            End If

            Return _user
        End Get
    End Property

    Public ReadOnly Property Scope As String Implements IApplicationSettingsService.Scope
        Get
            Return _scope
        End Get
    End Property

    Public ReadOnly Property ApplicationName As String Implements IApplicationSettingsService.ApplicationName
        Get
            If String.IsNullOrEmpty(_applicationName) Then
                _applicationName = _clientCredentials.GetClientCredential(degloba.Mod.Core.ClientCredentialType.ApplicationName)
            End If

            Return _applicationName
        End Get
    End Property

    Public ReadOnly Property ApplicationUserRol As String Implements IApplicationSettingsService.ApplicationUserRol
        Get
            If String.IsNullOrEmpty(_applicationUserRol) Then
                _applicationUserRol = _clientCredentials.GetClientCredential(degloba.Mod.Core.ClientCredentialType.ApplicationUserRol)
            End If

            Return _applicationUserRol
        End Get
    End Property

    Public ReadOnly Property ApplicationClientComputer As String Implements IApplicationSettingsService.ApplicationClientComputer
        Get
            If String.IsNullOrEmpty(_applicationClientComputer) Then
                _applicationClientComputer = _clientCredentials.GetClientCredential(degloba.Mod.Core.ClientCredentialType.ApplicationClientComputer)
            End If

            Return _applicationClientComputer
        End Get
    End Property
#End Region

#Region "Metodes públics"

    Public Function Get_ApplicationRolParameterValue(ByVal parameterKey As String) As String Implements IApplicationSettingsService.Get_ApplicationRolParameterValue
        Return _repositorySys.Get_ApplicationRolParameterValue(Me.ApplicationUserRol, parameterKey)
    End Function
#End Region

#Region "Metodes privats"

    Private Function GetUserFromHeader() As String
        Dim headerPos As Integer = System.ServiceModel.OperationContext.Current.IncomingMessageHeaders.FindHeader(CONST_HEADER_USR, CONST_HEADER_NAMESPACE)

        If headerPos >= 0 Then
            Return System.ServiceModel.OperationContext.Current.IncomingMessageHeaders.GetHeader(Of String)(headerPos)
        End If

        Return CONST_DEFAULT_USER
    End Function
#End Region

#Region "IDisposable Support"

    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            _user = Nothing
            _scope = Nothing
            _applicationName = Nothing
            _applicationUserRol = Nothing
            _applicationClientComputer = Nothing
            _repositorySys = Nothing
            _clientCredentials = Nothing

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
