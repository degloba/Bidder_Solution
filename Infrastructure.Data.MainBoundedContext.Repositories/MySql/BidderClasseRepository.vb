Imports Domain.MainBoundedContext
Imports Domain.MainBoundedContext.Modules
Imports Swaksoft.Domain.Seedwork
Imports Swaksoft.Domain.Seedwork.Aggregates

Public Class BidderClasseRepository
    Inherits Swaksoft.Infrastructure.Data.NHibernate.Seedwork.Repositories.Repository(Of EntityBase)
    Implements IBidderClasseRepository

    Public Sub New(unitOfWork As ITransactionUnitOfWork)
        MyBase.New(unitOfWork)
    End Sub

    Public Function CreateRepository(Of TEntity As {EntityBase, New})() As IRepository(Of TEntity) Implements IBidderClasseRepository.CreateRepository
        Throw New NotImplementedException()
    End Function
End Class
