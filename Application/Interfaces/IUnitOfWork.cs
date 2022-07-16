using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
 

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);

        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        Task Rollback();
    }
}
