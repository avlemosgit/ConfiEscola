using ConfiEscola.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiEscola.Domain.Models
{
    public class HistoricoEscolar : Entity
    {
        public string Formato { get; set; }
        public string Nome { get; set; }
        public byte[] Arquivo { get; set; }
        public void SetHitoricoEscolar(int id, string formato, string nome, byte[] arquivo)
        {
            Id = id;
            Formato=formato;
            Nome=nome;
            Arquivo=arquivo;
        }
    }    
}

