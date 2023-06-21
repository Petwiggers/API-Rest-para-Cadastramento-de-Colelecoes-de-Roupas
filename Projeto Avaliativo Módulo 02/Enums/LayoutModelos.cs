using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
    public enum LayoutModelos
    {
        [Description("Bordado")]
        Bordado,
        [Description("Estampa")]
        Estampa,
        [Description("Liso")]
        Liso
    }
}
