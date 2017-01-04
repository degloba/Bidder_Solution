Public Interface IUserRepository

#Region "User"

    Function Get_NomCompletByLogin(ByVal login As String) As String

    Function Get_LoginByEmployeeNumber(ByVal employeeNumber As String) As String

    Function Get_ComputerInformationDescripcio(ByVal computerName As String) As String

#End Region

End Interface
