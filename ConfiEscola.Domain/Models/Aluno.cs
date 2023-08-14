using System;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using ConfiEscola.Core.Models;

namespace ConfiEscola.Domain.Models
{
    public class Aluno : Entity
    {
        public Aluno() { }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
        public int HistoricoEscolarId { get; set; }
        public virtual Escolaridade Escolaridade { get; set; }
        public  HistoricoEscolar HistoricoEscolar { get; set; }
        public void setAluno(int id, string nome, string sobrenome, string email, DateTime datanascimento, int escolaridade, HistoricoEscolar historicoescolar)
        {
            Id = id;
            Nome = nome;
            SobreNome= sobrenome;
            Email = email;
            DataNascimento = datanascimento;
            EscolaridadeId = escolaridade;
            HistoricoEscolar = historicoescolar;
        }
    }
}
