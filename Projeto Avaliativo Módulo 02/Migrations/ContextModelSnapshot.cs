﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Avaliativo_Módulo_02.Data;

namespace Projeto_Avaliativo_Módulo_02.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projeto_Avaliativo_Módulo_02.Models.Colecoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AnoLancamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Estacao")
                        .HasColumnType("int");

                    b.Property<int>("IdResponsavel")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("Orcamento")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdResponsavel");

                    b.ToTable("Colecoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnoLancamento = new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estacao = 0,
                            IdResponsavel = 4,
                            Marca = "Adidas",
                            Nome = "Outono Inverno",
                            Orcamento = 250000.0,
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            AnoLancamento = new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estacao = 2,
                            IdResponsavel = 2,
                            Marca = "Oakley",
                            Nome = "Florescer da Mata",
                            Orcamento = 1000000.0,
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            AnoLancamento = new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estacao = 1,
                            IdResponsavel = 1,
                            Marca = "Nike",
                            Nome = "Esfriou",
                            Orcamento = 100000.0,
                            Status = 1
                        },
                        new
                        {
                            Id = 4,
                            AnoLancamento = new DateTime(2004, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estacao = 3,
                            IdResponsavel = 5,
                            Marca = "Calvin Klein",
                            Nome = "Vem verão",
                            Orcamento = 250000.0,
                            Status = 1
                        },
                        new
                        {
                            Id = 5,
                            AnoLancamento = new DateTime(2010, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estacao = 2,
                            IdResponsavel = 3,
                            Marca = "Puma",
                            Nome = "Moda Fitnes",
                            Orcamento = 428900.0,
                            Status = 0
                        });
                });

            modelBuilder.Entity("Projeto_Avaliativo_Módulo_02.Models.Modelos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdColecao")
                        .HasColumnType("int");

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdColecao");

                    b.ToTable("Modelos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdColecao = 3,
                            Layout = 0,
                            Nome = "Calça Rasgada",
                            Tipo = 4
                        },
                        new
                        {
                            Id = 2,
                            IdColecao = 5,
                            Layout = 2,
                            Nome = "Chápeu de Palha",
                            Tipo = 7
                        },
                        new
                        {
                            Id = 3,
                            IdColecao = 2,
                            Layout = 1,
                            Nome = "Camisa Estampa Dragão",
                            Tipo = 6
                        },
                        new
                        {
                            Id = 4,
                            IdColecao = 4,
                            Layout = 2,
                            Nome = "Sapato Social",
                            Tipo = 5
                        },
                        new
                        {
                            Id = 5,
                            IdColecao = 2,
                            Layout = 0,
                            Nome = "Bolsa de Couro",
                            Tipo = 2
                        });
                });

            modelBuilder.Entity("Projeto_Avaliativo_Módulo_02.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf_Cnpj")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NumeroTelefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf_Cnpj = "01191379908",
                            DataNascimento = new DateTime(1997, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "maria@mail.com",
                            Genero = "Feminino",
                            NomeCompleto = "Maria Fernanda",
                            NumeroTelefone = "49983762147",
                            Status = 1,
                            TipoUsuario = 2
                        },
                        new
                        {
                            Id = 2,
                            Cpf_Cnpj = "01221379908",
                            DataNascimento = new DateTime(1968, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jp@mail.com",
                            Genero = "Masculino",
                            NomeCompleto = "João Paulo",
                            NumeroTelefone = "49988562147",
                            Status = 0,
                            TipoUsuario = 0
                        },
                        new
                        {
                            Id = 3,
                            Cpf_Cnpj = "01121779908",
                            DataNascimento = new DateTime(1977, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mf@mail.com",
                            Genero = "Masculino",
                            NomeCompleto = "Martin Fowler",
                            NumeroTelefone = "48988562246",
                            Status = 1,
                            TipoUsuario = 3
                        },
                        new
                        {
                            Id = 4,
                            Cpf_Cnpj = "01223378808",
                            DataNascimento = new DateTime(2004, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "martin.c.@mail.com",
                            Genero = "Masculino",
                            NomeCompleto = "Uncle Bob",
                            NumeroTelefone = "48978567216",
                            Status = 1,
                            TipoUsuario = 2
                        },
                        new
                        {
                            Id = 5,
                            Cpf_Cnpj = "01327388808",
                            DataNascimento = new DateTime(1991, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lsp@mail.com",
                            Genero = "Masculino",
                            NomeCompleto = "Barbara Liskov",
                            NumeroTelefone = "48877567116",
                            Status = 1,
                            TipoUsuario = 0
                        });
                });

            modelBuilder.Entity("Projeto_Avaliativo_Módulo_02.Models.Colecoes", b =>
                {
                    b.HasOne("Projeto_Avaliativo_Módulo_02.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdResponsavel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Projeto_Avaliativo_Módulo_02.Models.Modelos", b =>
                {
                    b.HasOne("Projeto_Avaliativo_Módulo_02.Models.Colecoes", "Colecao")
                        .WithMany()
                        .HasForeignKey("IdColecao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colecao");
                });
#pragma warning restore 612, 618
        }
    }
}
