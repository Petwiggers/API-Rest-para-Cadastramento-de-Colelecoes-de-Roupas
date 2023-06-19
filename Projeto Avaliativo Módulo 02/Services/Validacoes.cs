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
            else
            {
                return false;
            }
        }
        public bool ValidaStatus(StatusModel status)
        {
            if (status.StatusUsuario == Enums.Status.Ativo || status.StatusUsuario == Enums.Status.Inativo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
