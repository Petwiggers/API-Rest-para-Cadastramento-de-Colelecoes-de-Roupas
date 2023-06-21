using Projeto_Avaliativo_Módulo_02.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Models
{
    public class Modelos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo Nome do Modelo é Obrigatório !")]
        [MaxLength(250, ErrorMessage = "O Campo Nome do Modelo deve conter no maximo 250 carcteres !")]
        public string Nome{ get; set; }

        [ForeignKey("Colecao")]
        [Required(ErrorMessage = "O Campo IdColecao é Obrigatório !")]
        public int IdColecao { get; set; }
        public Colecoes Colecao { get; set; }

        [Required(ErrorMessage = "O campo Tipo é Obrigatório !")]
        public TipoModelos Tipo { get; set; }

        [Required(ErrorMessage = "O campo Layout é Obrigatório !")]
        public LayoutModelos Layout { get; set; }
    }
}
