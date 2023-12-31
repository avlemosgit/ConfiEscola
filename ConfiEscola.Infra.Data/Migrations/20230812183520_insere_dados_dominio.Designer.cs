﻿// <auto-generated />
using System;
using ConfiEscola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConfiEscola.Infra.Data.Migrations
{
    [DbContext(typeof(ConfiEscolaContext))]
    [Migration("20230812183520_insere_dados_dominio")]
    partial class insere_dados_dominio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConfiEscola.Domain.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EscolaridadeId")
                        .HasColumnType("int");

                    b.Property<int>("HistoricoEscolarId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("EscolaridadeId");

                    b.HasIndex("HistoricoEscolarId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("ConfiEscola.Domain.Models.Escolaridade", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Escolaridade");
                });

            modelBuilder.Entity("ConfiEscola.Domain.Models.HistoricoEscolar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Arquivo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Formato")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("HistoricoEscolar");
                });

            modelBuilder.Entity("ConfiEscola.Domain.Models.Aluno", b =>
                {
                    b.HasOne("ConfiEscola.Domain.Models.Escolaridade", "Escolaridade")
                        .WithMany()
                        .HasForeignKey("EscolaridadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConfiEscola.Domain.Models.HistoricoEscolar", "HistoricoEscolar")
                        .WithMany()
                        .HasForeignKey("HistoricoEscolarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Escolaridade");

                    b.Navigation("HistoricoEscolar");
                });
#pragma warning restore 612, 618
        }
    }
}
