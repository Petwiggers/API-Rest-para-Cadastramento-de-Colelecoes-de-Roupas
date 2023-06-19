using Projeto_Avaliativo_Módulo_02.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.FromBodys
{
    public class StatusModel
    {
        [Required(ErrorMessage = "O Campo Tipo Status é obrigatório")]
        public Status StatusUsuario { get; set; }
    }
}
