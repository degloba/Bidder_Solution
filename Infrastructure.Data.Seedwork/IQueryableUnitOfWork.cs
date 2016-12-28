using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seedwork
{
    public interface IQueryableUnitOfWork : IUnitOfWork, IDisposable, ISql
    {
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;
        void Attach<TEntity>(TEntity item) where TEntity : class;
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
        void Detach<TEntity>(TEntity item) where TEntity : class;
        void DetachAll();
        void SetModified<TEntity>(TEntity item) where TEntity : class;
    }
}
