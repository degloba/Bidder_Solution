Public Interface IBidderClasseService
    Inherits IDisposable

    ReadOnly Property BidderRepository As IBidderClasseRepository

    Function CreateService(Of TEntity As {Modules.EntityBase, New})() As IEntityService(Of TEntity)

End Interface
