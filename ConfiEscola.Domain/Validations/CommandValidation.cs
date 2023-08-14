using FluentValidation;
using ConfiEscola.Core.Commands;

namespace ConfiEscola.Domain.Validations
{
    public class CommandValidation<T> : AbstractValidator<T> where T : Command
    {
    }
}
