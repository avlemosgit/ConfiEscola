using ConfiEscola.Core.Commands;
using ConfiEscola.Domain.Models;
using ConfiEscola.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiEscola.Domain.Commands
{
    public class AlunoUpdateCommand : Command
    {
        public AlunoUpdateCommand() { }        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
        public HistoricoEscolar HistoricoEscolar { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AlunoUpdateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
