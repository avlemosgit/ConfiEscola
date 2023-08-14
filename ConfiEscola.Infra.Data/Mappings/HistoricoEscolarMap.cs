using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ConfiEscola.Domain.Models;

namespace ConfiEscola.Infra.Data.Mappings
{
    internal class HistoricoEscolarMap : IEntityTypeConfiguration<HistoricoEscolar>
    {
        public void Configure(EntityTypeBuilder<HistoricoEscolar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Formato).HasMaxLength(30);
            builder.Property(x => x.Nome).HasMaxLength(100);
        }
    }
}

