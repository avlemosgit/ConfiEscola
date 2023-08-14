using ConfiEscola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiEscola.Domain.Interfaces.Data.Repositories
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> GetById(int id);
        Task<IEnumerable<Aluno>> GetByNome(string nome, string sobrenome);
        Task<IEnumerable<Aluno>> GetByEmail(string email);
        Task<IEnumerable<Aluno>> Get();
    }
}
