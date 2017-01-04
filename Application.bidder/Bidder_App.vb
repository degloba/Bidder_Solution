Imports Domain.MainBoundedContext

Public Class Bidder_App
    Implements IBidder_App

    Private _domainService As IBidderClasseService

    Private _wsService As IWSService

    Private _applicationSettingsService As IApplicationSettingsService

    Private _userService As IUserService

End Class
