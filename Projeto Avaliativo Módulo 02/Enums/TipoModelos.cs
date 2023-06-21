using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TipoModelos
    {
        [Description("Bermuda")]
        Bermuda,
        [Description("Bíquini")]
        Bíquini,
        [Description("Bolsa")]
        Bolsa,
        [Description("Boné")]
        Boné,
        [Description("Calça")]
        Calça,
        [Description("Calçados")]
        Calçados,
        [Description("Camisa")]
        Camisa,
        [Description("Chápeu")]
        Chápeu,
        [Description("Saia")]
        Saia
    }
}
