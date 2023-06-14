using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Models
{
    public class Usuario : Pessoa
    {
        public string Email { get; set; }
        public int TipoUsuario { get; set; }
        public int Status { get; set; }
    }
}
