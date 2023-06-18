using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Enums
{
    public enum TipoUsuario
    {
        [Description("Administrador")]
        Administrador = 1,
        [Description("Gerente")]
        Gerente = 2,
        [Description("Criador")]
        Criador = 3,
        [Description("Outro")]
        Outro = 4
    }
}
