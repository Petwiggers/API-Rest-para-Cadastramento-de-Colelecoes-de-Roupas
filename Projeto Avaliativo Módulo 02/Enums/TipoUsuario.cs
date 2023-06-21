using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Projeto_Avaliativo_Módulo_02.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
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
