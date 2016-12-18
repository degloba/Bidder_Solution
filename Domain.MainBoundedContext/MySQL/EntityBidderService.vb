Imports System.Linq.Expressions
Imports Domain.MainBoundedContext
Imports Swaksoft.Domain.Seedwork
Imports Swaksoft.Domain.Seedwork.Aggregates

Public Class EntityBidderService(Of TEntity As {Modules.EntityBase, New})
    Implements IEntityService(Of TEntity)

    Private _repository As IRepository(Of TEntity)


    Sub New(rep As IRepository(Of TEntity))
        _repository = rep
    End Sub


    Public ReadOnly Property Repository As IRepository(Of TEntity) Implements IEntityService(Of TEntity).Repository
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Sub Add(value As TEntity) Implements IEntityService(Of TEntity).Add
        Dim uow As IUnitOfWork = CType(_repository.UnitOfWork, IUnitOfWork)
        _repository.Add(value)
        uow.CommitAndRefreshChanges()
    End Sub

    Public Sub Change(value As TEntity) Implements IEntityService(Of TEntity).Change
        Dim uow As IUnitOfWork = CType(_repository.UnitOfWork, IUnitOfWork)
        _repository.Modify(value)
        uow.Commit()
    End Sub

    Public Sub ChangeAllWhere(changeStatement As Action(Of TEntity), where As Expression(Of Func(Of TEntity, Boolean))) Implements IEntityService(Of TEntity).ChangeAllWhere
        Throw New NotImplementedException()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Throw New NotImplementedException()
    End Sub

    Public Sub Merge(persisted As TEntity, current As TEntity) Implements IEntityService(Of TEntity).Merge
        Dim uow As IUnitOfWork = CType(_repository.UnitOfWork, IUnitOfWork)
        _repository.Merge(persisted, current)
        uow.CommitAndRefreshChanges()
    End Sub

    Public Sub Remove(value As TEntity) Implements IEntityService(Of TEntity).Remove
        Dim uow As IUnitOfWork = CType(_repository.UnitOfWork, IUnitOfWork)
        _repository.Remove(value)
        uow.Commit()
    End Sub

    Public Sub RemoveAllWhere(where As Expression(Of Func(Of TEntity, Boolean))) Implements IEntityService(Of TEntity).RemoveAllWhere
        Throw New NotImplementedException()
    End Sub

    Public Sub RemoveById(value As Guid) Implements IEntityService(Of TEntity).RemoveById
        Throw New NotImplementedException()
        ' Remove(_repository.AllMatching(New Specification.DirectSpecification(Of TEntity)(Function(b) b.Id = value)).FirstOrDefault
    End Sub

    Public Function [Get](id As Guid) As TEntity Implements IEntityService(Of TEntity).Get
        Throw New NotImplementedException()
    End Function
End Class
