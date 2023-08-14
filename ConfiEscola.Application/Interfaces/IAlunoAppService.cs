using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiEscola.Application.ViewModels;

namespace ConfiEscola.Application.Interfaces
{
    public interface IAlunoAppService
    {
        Task Create(AlunoViewModel model);
        Task Delete(int id);
        Task Update(AlunoViewModel model);
        Task<IEnumerable<AlunoViewModel>> Get();       
        Task<AlunoViewModel> GetById(int id);
        Task<IEnumerable<EscolaridadeViewModel>> GetEscolaridade();
    }
}
