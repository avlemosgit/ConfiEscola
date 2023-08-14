using FluentValidation;
using ConfiEscola.Domain.Commands;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConfiEscola.Domain.Validations
{
    public class AlunoDeleteCommandValidation : CommandValidation<AlunoDeleteCommand>
    {
        public AlunoDeleteCommandValidation() 
        {
            RuleFor(x=>x.Id)
                .NotEmpty().WithMessage("O Aluno não encontrado")
                .GreaterThan(0).WithMessage("O Aluno não encontrado");
        }
    }
}

