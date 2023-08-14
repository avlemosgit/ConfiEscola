using ConfiEscola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiEscola.Application.ViewModels
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        public string Nome { get;  set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
        public HistoricoEscolarViewModel HistoricoEscolar { get; set; }
    }
}
