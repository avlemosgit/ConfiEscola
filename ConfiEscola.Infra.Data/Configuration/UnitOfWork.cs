using Microsoft.EntityFrameworkCore;
using ConfiEscola.Domain.Interfaces.Data;
using ConfiEscola.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiEscola.Infra.Data.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConfiEscolaContext _dbContext;

        public UnitOfWork(ConfiEscolaContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
        }

        public async Task<bool> Commit()
        {
            int rowsAffected = await _dbContext.SaveChangesAsync();

            if(rowsAffected > 0)
            {
                var changedEntriesCopy = _dbContext.ChangeTracker.Entries().ToList();
                foreach (var entry in changedEntriesCopy)
                    entry.State = EntityState.Detached;
            }

            return rowsAffected > 0;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
