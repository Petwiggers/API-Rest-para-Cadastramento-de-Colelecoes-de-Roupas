using Microsoft.EntityFrameworkCore;
using Projeto_Avaliativo_Módulo_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Data
{
    public class Context : DbContext
    {
        public Context()
        {
        }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Colecoes> Colecoes { get; set; }
        public DbSet<Modelos> Modelos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DataBase");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                            new Usuario
                            {

                                Id = 1,
                                NomeCompleto = "Maria Fernanda",
                                Genero = "Feminino",
                                Cpf_Cnpj = "01191379908",
                                NumeroTelefone = "49983762147",
                                Email = "maria@mail.com",
                                DataNascimento = new DateTime(1997,06,25),
                                TipoUsuario = Enums.TipoUsuario.Criador,
                                Status = Enums.Status.Ativo,
                            },
                            new Usuario
                            {
                                Id = 2,
                                NomeCompleto = "João Paulo",
                                Genero = "Masculino",
                                Cpf_Cnpj = "01221379908",
                                NumeroTelefone = "49988562147",
                                Email = "jp@mail.com",
                                DataNascimento = new DateTime(1968, 08, 15),
                                TipoUsuario = Enums.TipoUsuario.Administrador,
                                Status = Enums.Status.Inativo,
                            },
                            new Usuario
                            { 
                                Id = 3,
                                NomeCompleto = "Martin Fowler",
                                Genero = "Masculino",
                                Cpf_Cnpj = "01121779908",
                                NumeroTelefone = "48988562246",
                                Email = "mf@mail.com",
                                DataNascimento = new DateTime(1977, 01, 01),
                                TipoUsuario = Enums.TipoUsuario.Outro,
                                Status = Enums.Status.Ativo,
                            },
                            new Usuario
                            {
                                Id = 4,
                                NomeCompleto = "Uncle Bob",
                                Genero = "Masculino",
                                Cpf_Cnpj = "01223378808",
                                NumeroTelefone = "48978567216",
                                Email = "martin.c.@mail.com",
                                DataNascimento = new DateTime(2004, 06, 18),
                                TipoUsuario = Enums.TipoUsuario.Criador,
                                Status = Enums.Status.Ativo,
                            },
                            new Usuario
                            {
                                Id = 5,    
                                NomeCompleto = "Barbara Liskov",
                                Genero = "Masculino",
                                Cpf_Cnpj = "01327388808",
                                NumeroTelefone = "48877567116",
                                Email = "lsp@mail.com",
                                DataNascimento = new DateTime(1991, 12, 11),
                                TipoUsuario = Enums.TipoUsuario.Administrador,
                                Status = Enums.Status.Ativo,
                            }
               );
            modelBuilder.Entity<Colecoes>().HasData(
                            new Colecoes
                            {
                                Id = 1,
                                Nome = "Outono Inverno",
                                IdResponsavel = 4,
                                Marca = "Adidas",
                                Orcamento = 250000,
                                AnoLancamento = new DateTime (2022,11,11),
                                Estacao = Enums.Estacoes.Outono,
                                Status = Enums.Status.Ativo
                            },
                            new Colecoes
                            {
                                Id = 2,
                                Nome = "Florescer da Mata",
                                IdResponsavel = 2,
                                Marca = "Oakley",
                                Orcamento = 1000000,
                                AnoLancamento = new DateTime (2019,05,30),
                                Estacao = Enums.Estacoes.Primavera,
                                Status = Enums.Status.Inativo
                            },
                            new Colecoes
                            {
                                Id = 3,
                                Nome = "Esfriou",
                                IdResponsavel = 1,
                                Marca = "Nike",
                                Orcamento = 100000,
                                AnoLancamento = new DateTime (2023, 07, 14),
                                Estacao = Enums.Estacoes.Inverno,
                                Status = Enums.Status.Ativo
                            },
                            new Colecoes
                            {
                                Id = 4,
                                Nome = "Vem verão",
                                IdResponsavel = 5,
                                Marca = "Calvin Klein",
                                Orcamento = 250000,
                                AnoLancamento = new DateTime (2004,06,15),
                                Estacao = Enums.Estacoes.Verao,
                                Status = Enums.Status.Ativo
                            },
                            new Colecoes
                            {
                                Id = 5,
                                Nome = "Moda Fitnes",
                                IdResponsavel = 3,
                                Marca = "Puma",
                                Orcamento = 428900,
                                AnoLancamento = new DateTime (2010, 01, 03),
                                Estacao = Enums.Estacoes.Primavera,
                                Status = Enums.Status.Inativo
                            }

                );
            modelBuilder.Entity<Modelos>().HasData(
                            new Modelos 
                            {
                                Id = 1,
                                Nome = "Calça Rasgada",
                                IdColecao = 3,
                                Tipo = Enums.TipoModelos.Calça,
                                Layout = Enums.LayoutModelos.Bordado
                            },
                            new Modelos
                            {
                                Id = 2,
                                Nome = "Chápeu de Palha",
                                IdColecao = 5,
                                Tipo = Enums.TipoModelos.Chápeu,
                                Layout = Enums.LayoutModelos.Liso
                            },
                            new Modelos
                            {
                                Id = 3,
                                Nome = "Camisa Estampa Dragão",
                                IdColecao = 2,
                                Tipo = Enums.TipoModelos.Camisa,
                                Layout = Enums.LayoutModelos.Estampa
                            },
                            new Modelos 
                            {
                                Id = 4,
                                Nome = "Sapato Social",
                                IdColecao = 4,
                                Tipo = Enums.TipoModelos.Calçados,
                                Layout = Enums.LayoutModelos.Liso
                            },
                            new Modelos
                            {
                                Id = 5,
                                Nome = "Bolsa de Couro",
                                IdColecao = 2,
                                Tipo = Enums.TipoModelos.Bolsa,
                                Layout = Enums.LayoutModelos.Bordado
                            }
                );
        }

    }
}
