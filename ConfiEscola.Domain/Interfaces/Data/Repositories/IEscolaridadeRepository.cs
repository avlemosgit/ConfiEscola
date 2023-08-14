using ConfiEscola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiEscola.Domain.Interfaces.Data.Repositories
{
    public interface IEscolaridadeRepository : IRepository<Escolaridade>
    {
        Task<IEnumerable<Escolaridade>> Get();
    }
}
