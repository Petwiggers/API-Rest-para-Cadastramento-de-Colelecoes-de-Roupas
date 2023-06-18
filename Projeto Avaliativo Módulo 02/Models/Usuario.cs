using Projeto_Avaliativo_Módulo_02.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Models
{
    public class Usuario : DataTypeAttribute
    {
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O Campo Tipo Usuario é obrigatório")]
        public TipoUsuario TipoUsuario { get; set; }

        [Required(ErrorMessage = "O Campo Tipo Status é obrigatório")]
        public Status Status { get; set; }
    }
}
