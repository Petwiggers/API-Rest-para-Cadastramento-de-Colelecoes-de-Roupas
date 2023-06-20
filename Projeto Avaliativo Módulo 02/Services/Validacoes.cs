using Projeto_Avaliativo_Módulo_02.Enums;
using Projeto_Avaliativo_Módulo_02.FromBodys;
using Projeto_Avaliativo_Módulo_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Services
{
    public class Validacoes
    {
        public bool ValidaStatus_TipoUsuario(Usuario usuario)
        {
            if ((usuario.Status == Enums.Status.Ativo || usuario.Status == Enums.Status.Inativo)
                        && (usuario.TipoUsuario == Enums.TipoUsuario.Administrador || usuario.TipoUsuario == Enums.TipoUsuario.Criador
                        || usuario.TipoUsuario == Enums.TipoUsuario.Gerente || usuario.TipoUsuario == Enums.TipoUsuario.Outro))
            {
                return true;
            }
            return false;
            
        }
        public bool ValidaStatus(Status status)
        {
            if (status == Status.Ativo || status == Status.Inativo)
            {
                return true;
            }
            return false;
        }

        public bool ValidaEstacoes(Estacoes estacao)
        {
            if(estacao == Estacoes.Outono || estacao == Estacoes.Inverno || estacao == Estacoes.Primavera || estacao == Estacoes.Verao)
            {
                    return true;
            }
            return false;
        }
    }
}
