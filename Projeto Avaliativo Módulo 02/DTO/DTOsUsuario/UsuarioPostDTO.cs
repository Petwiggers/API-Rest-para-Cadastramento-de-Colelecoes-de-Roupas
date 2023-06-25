using Projeto_Avaliativo_Módulo_02.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.DTO.DTOsUsuario
{
    public class UsuarioPostDTO
    {
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string NumeroTelefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Status Status { get; set; }

    }
}
