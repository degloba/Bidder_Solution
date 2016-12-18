Imports System.Linq.Expressions
Imports Swaksoft.Domain.Seedwork.Aggregates

Public Interface IEntityService(Of T As Entity)
    Inherits IDisposable

    Sub Add(ByVal value As T)
    Sub Remove(ByVal value As T)
    Sub RemoveById(ByVal value As Guid)
    Sub Change(ByVal value As T)
    Sub Merge(ByVal persisted As T, ByVal current As T)
    Function [Get](ByVal id As Guid) As T
    Sub ChangeAllWhere(changeStatement As Action(Of T), where As Expression(Of Func(Of T, Boolean)))
    Sub RemoveAllWhere(where As Expression(Of Func(Of T, Boolean)))

    ReadOnly Property Repository As Swaksoft.Domain.Seedwork.Aggregates.IRepository(Of T)


End Interface
