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
    public class AlunoCreateCommand : Command
    {
        public AlunoCreateCommand() { }
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string SobreNome { get; protected set; }
        public string Email { get; protected set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
        public HistoricoEscolar HistoricoEscolar { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AlunoCreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
