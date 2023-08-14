using ConfiEscola.Core.Commands;
using ConfiEscola.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiEscola.Domain.Commands
{
    public class AlunoDeleteCommand : Command
    {
        public AlunoDeleteCommand() { }
        
        public int Id { get; protected set; }

        public AlunoDeleteCommand(int id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new AlunoDeleteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
