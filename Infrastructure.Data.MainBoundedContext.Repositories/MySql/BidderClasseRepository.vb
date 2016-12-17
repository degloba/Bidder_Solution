Imports Domain.MainBoundedContext.Modules
Imports Swaksoft.Domain.Seedwork

Public Class BidderClasseRepository
    Inherits Swaksoft.Infrastructure.Data.NHibernate.Seedwork.Repositories.Repository(Of EntityBase)

    Public Sub New(unitOfWork As ITransactionUnitOfWork)
        MyBase.New(unitOfWork)
    End Sub
End Class
