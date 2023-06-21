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
        Biquini,
        [Description("Bolsa")]
        Bolsa,
        [Description("Boné")]
        Bone,
        [Description("Calça")]
        Calca,
        [Description("Calçados")]
        Calcados,
        [Description("Camisa")]
        Camisa,
        [Description("Chapeu")]
        Chapeu,
        [Description("Saia")]
        Saia
    }
}
