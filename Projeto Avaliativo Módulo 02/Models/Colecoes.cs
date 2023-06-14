using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Models
{
    public class Colecoes
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int IdResponsavel { get; set; }

        public string Marca { get; set; }

        public double Orcamento{ get; set; }

        public DateTime Ano { get; set; }

        public int Estacao { get; set; } 
        public int Status { get; set; }

    }
}
