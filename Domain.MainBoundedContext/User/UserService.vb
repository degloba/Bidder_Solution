Public Class UserService
    Implements IUserService

    Private _repository As IUserRepository

    Sub New(repository As IUserRepository)
        _repository = repository
    End Sub
    Public ReadOnly Property Repository As IUserRepository Implements IUserService.Repository
        Get
            Return _repository
        End Get
    End Property
End Class
