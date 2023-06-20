using Projeto_Avaliativo_Módulo_02.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Models
{
    public class Colecoes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(250,ErrorMessage = "O campo nome deve conter no máximo 250 caracteres !")]
        public string Nome { get; set; }

        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "O campo Responsável é obrigatório")]
        public int IdResponsavel { get; set; }
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "O campo marca é obrigatório !")]
        [MaxLength(300, ErrorMessage = "O campo marca deve conter no máximo 300 caracteres !")] 
        public string Marca { get; set; }

        [Required (ErrorMessage = "O campo orçamento é obrigatório !")]
        public double Orcamento{ get; set; }

        [Required(ErrorMessage = "O campo Ano de Lançamento é obrigatório !")]
        public DateTime AnoLancamento { get; set; }

        [Required(ErrorMessage = "O campo estação é obrigatório !")]
        public Estacoes Estacao { get; set; } 

        [Required(ErrorMessage = "O campo Status é obrigatório !")]
        public Status Status { get; set; }

    }
}
