Public Interface IApplicationSettingsService
    Inherits IDisposable

#Region "Properties"

    ReadOnly Property User As String

    ReadOnly Property Scope As String

    ReadOnly Property ApplicationName As String

    ReadOnly Property ApplicationUserRol As String

    ReadOnly Property ApplicationClientComputer As String

#End Region

#Region "Metodes públics"

    Function Get_ApplicationRolParameterValue(ByVal parameterKey As String) As String

#End Region

End Interface

