
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Projeto_Avaliativo_Módulo_02.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        [Description("Inativo")]
        Inativo,
        [Description("Ativo")]
        Ativo
    }
}
