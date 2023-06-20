using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Enums
{
    public enum Estacoes
    {
        [Description("Outono")]
        Outono = 0,
        [Description("Inverno")]
        Inverno,
        [Description("Primavera")]
        Primavera,
        [Description("Verão")]
        Verao
    }
}
