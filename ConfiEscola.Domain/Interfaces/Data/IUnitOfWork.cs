using System;
using System.Threading.Tasks;

namespace ConfiEscola.Domain.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
