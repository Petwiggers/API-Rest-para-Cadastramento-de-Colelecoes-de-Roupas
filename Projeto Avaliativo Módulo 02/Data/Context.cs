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
        //public DbSet<Colecoes> Colecoes { get; set; }
        //public DbSet<Modelos> Modelos { get; set; }

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
        }

    }
}
