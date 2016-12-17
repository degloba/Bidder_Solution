Imports Domain.MainBoundedContext.Modules

Public Interface IBidderClasseRepository
    Inherits Swaksoft.Domain.Seedwork.Aggregates.IRepository(Of EntityBase)

    Function CreateRepository(Of TEntity As {EntityBase, New})() As Swaksoft.Domain.Seedwork.Aggregates.IRepository(Of TEntity)

End Interface
