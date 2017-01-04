Imports degloba.Mod.Core.degloba.Mod.Core


Namespace SICA.Mod.Core
    Public Interface IClientCredentials
        'Implements IMod

        Function GetClientCredential(type As ClientCredentialType) As String
        Function GetClientCredentialName(type As ClientCredentialType) As String
        Function GetClientCredentials() As IList(Of KeyValuePair(Of String, String))
    End Interface
End Namespace
