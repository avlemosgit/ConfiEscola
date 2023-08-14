using System;
using ConfiEscola.Infra.Data.Mappings;
using ConfiEscola.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConfiEscola.Infra.Data.Context
{
    public class ConfiEscolaContext : DbContext
    {
        public ConfiEscolaContext(DbContextOptions<ConfiEscolaContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json").Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new EscolariadeMap());
            modelBuilder.ApplyConfiguration(new HistoricoEscolarMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
