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
    public class HistoricoEscolarRepository : Repository<HistoricoEscolar>, IHistoricoEscolarRepository
    {
        protected ConfiEscolaContext _context;

        public HistoricoEscolarRepository(ConfiEscolaContext context) : base(context) 
        { 
            _context = context;
        }
    }
}
