using FluentValidation;
using ConfiEscola.Domain.Commands;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConfiEscola.Domain.Validations
{
    public class AlunoUpdateCommandValidation : CommandValidation<AlunoUpdateCommand>
    {
        public AlunoUpdateCommandValidation() 
        {
            RuleFor(x=>x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório");

            RuleFor(x => x.SobreNome)
                .NotEmpty().WithMessage("O sobrenome é obrigatório");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório")
                .EmailAddress().WithMessage("O e-mail é inválido");
            
            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória")
                .LessThan(p => DateTime.Now).WithMessage("A data de nascimento não pode ser maior que a data de hoje");
        }
    }
}

