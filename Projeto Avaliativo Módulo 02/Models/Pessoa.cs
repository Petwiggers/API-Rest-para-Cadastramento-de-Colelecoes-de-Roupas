using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Models
{
    public class DataTypeAttribute
    {
        [Key]
        public  int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome Completo é obrigatório")]
        [MaxLength(200,ErrorMessage = "O nome deve ter no maximo 200 caracteres")]
        public string NomeCompleto { get; set; }

        [MaxLength(100, ErrorMessage = "O Gênero deve ter no maximo 200 caracteres")]
        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo data é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Cpf/Cnpj é obrigatório")]
        [MaxLength(20, ErrorMessage = "O campo Cpf/Cnpj deve conter no Maximo 20 caracteres")]
        public string Cpf_Cnpj { get; set; }

        [Required(ErrorMessage = "O campo Numero de Telefone é obrigatório")]
        public string NumeroTelefone { get; set; }
    }
}
