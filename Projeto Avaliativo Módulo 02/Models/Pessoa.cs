using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Models
{
    public class Pessoa
    {
        public  int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public DateTime Data { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string NumeroTelefone { get; set; }
    }
}
