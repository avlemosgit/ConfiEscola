using System;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using ConfiEscola.Core.Models;

namespace ConfiEscola.Domain.Models
{
    public class Escolaridade : Entity
    {       
        public string Descricao { get; set; }
    }
}
