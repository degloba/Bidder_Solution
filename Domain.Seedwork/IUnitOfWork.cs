using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Seedwork
{
    public interface IUnitOfWork : IDisposable
    {
        Guid InstanceId { get; }

        void Commit();
        void CommitAndRefreshChanges();
        bool GetStatusAutodetectChanges();
        void RollbackChanges();
        void SetAutodetectChanges(bool status);
    }
}
