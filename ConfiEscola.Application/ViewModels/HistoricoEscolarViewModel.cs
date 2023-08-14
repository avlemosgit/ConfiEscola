using ConfiEscola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiEscola.Application.ViewModels
{
    public class HistoricoEscolarViewModel
    {
        public int Id { get; set; }
        public string Formato { get; set; }
        public string Nome { get; set; }
        public byte[] Arquivo { get; set; }
    }
}