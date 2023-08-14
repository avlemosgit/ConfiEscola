using Microsoft.EntityFrameworkCore;
using ConfiEscola.Domain.Interfaces.Data.Repositories;
using ConfiEscola.Infra.Data.Configuration;
using ConfiEscola.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiEscola.Domain.Models;

namespace ConfiEscola.Infra.Data.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        protected ConfiEscolaContext _dbcontext;

        public AlunoRepository(ConfiEscolaContext dbContext) : base(dbContext) 
        { 
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<Aluno>> Get()
        {
            return await _dbcontext.Set<Aluno>().Include(x=>x.HistoricoEscolar).OrderBy(x => x.Nome).AsNoTracking().ToListAsync();

        }
        public async Task<Aluno> GetById(int id)
        {
            return await _dbcontext.Set<Aluno>().Where(x=>x.Id==id).Include(x => x.HistoricoEscolar).OrderBy(x => x.Nome).AsNoTracking().FirstOrDefaultAsync();

        }
        public async Task<IEnumerable<Aluno>> GetByEmail(string email)
        {
            IQueryable<Aluno> query =  DbSet.Where(x=>x.Email == email);
            return await query.AsNoTracking().ToListAsync();
        }

        //public async Task<Aluno> GetById(int id)
        //{
        //    //IQueryable<Aluno> query = DbSet.Where(x => x.Id == id);
        //    return await _dbcontext.Set<Aluno>().Where(x => x.Id == id).FirstOrDefaultAsync();
        //}

        public async Task<IEnumerable<Aluno>> GetByNome(string nome, string sobreNome)
        {
            IQueryable<Aluno> query = DbSet.Where(x => x.Nome == nome && x.SobreNome == sobreNome);
            return await query.AsNoTracking().ToListAsync();
        }
    }
}
