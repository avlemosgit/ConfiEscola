using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ConfiEscola.Domain.Models;

namespace ConfiEscola.Infra.Data.Mappings
{
    internal class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        { 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasMaxLength(30);
            builder.Property(x => x.SobreNome).HasMaxLength(30);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.DataNascimento);
            builder.Property(x => x.HistoricoEscolarId);
            builder.Property(x => x.EscolaridadeId);
            builder.HasOne(x => x.HistoricoEscolar).WithMany().HasForeignKey(x => x.HistoricoEscolarId);
            builder.HasOne(x => x.Escolaridade).WithMany().HasForeignKey(x => x.EscolaridadeId);
        }
    }
}

