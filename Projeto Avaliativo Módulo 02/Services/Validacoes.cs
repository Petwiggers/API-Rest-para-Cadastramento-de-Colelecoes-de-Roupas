using Projeto_Avaliativo_Módulo_02.Data;
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
        private readonly Context _repository;
        public Validacoes(Context context)
        {
            _repository = context;
        }
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

        public bool ValidaTipoModelos (TipoModelos tipo)
        {
            if(tipo == TipoModelos.Bermuda || tipo == TipoModelos.Biquini || 
                    tipo == TipoModelos.Bolsa || tipo == TipoModelos.Bone ||
                        tipo == TipoModelos.Calca || tipo == TipoModelos.Calcados ||
                            tipo == TipoModelos.Camisa || tipo == TipoModelos.Chapeu ||
                                tipo == TipoModelos.Saia)
            {
                return true;
            }
            return false;
        }

        public bool ValidaLayoutModelos(LayoutModelos layout)
        {
            if(layout == LayoutModelos.Bordado || 
                    layout == LayoutModelos.Estampa ||
                        layout == LayoutModelos.Liso)
            {
                return true;
            }
            return false;
        }

        public bool ValidaSeUsuarioExiste(int id)
        {
            return _repository.Usuarios.Any(e => e.Id == id);
        }

        public bool ValidaSeColecaoExiste(int id)
        {
            return _repository.Colecoes.Any(e => e.Id == id);
        }

        public bool ValidaDadosColecoes(Status status, Estacoes estacao, int Id)
        {
            if(ValidaEstacoes(estacao) && 
                    ValidaStatus(status) &&
                        ValidaSeUsuarioExiste(Id))
            {
                return true;
            }
            return false;
        }

        public bool ValidaDadosModelos (TipoModelos tipo, LayoutModelos layout, int Id)
        {
            if(ValidaTipoModelos(tipo) && 
                    ValidaLayoutModelos(layout) &&
                        ValidaSeColecaoExiste(Id))
            {
                return true;
            }
            return false;
        }
    }
}
