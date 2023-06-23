using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Avaliativo_Módulo_02.Data;
using Projeto_Avaliativo_Módulo_02.Enums;
using Projeto_Avaliativo_Módulo_02.FromBodys;
using Projeto_Avaliativo_Módulo_02.Models;
using Projeto_Avaliativo_Módulo_02.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Controllers
{

    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Context _repository;
        private readonly Validacoes _services;

        public UsuarioController(Context context)
        {
            _repository = context;
            _services = new Validacoes(context);
        }

        [HttpPost]
        public IActionResult CadastrandoUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (_services.ValidaCnpjCpf(usuario.Cpf_Cnpj))
                {
                    return Conflict("Ja possui um Usuário com o Cpf/Cnpj :" + usuario.Cpf_Cnpj);
                }
                if (!(_services.ValidaStatus_TipoUsuario(usuario)))
                {
                    return BadRequest("O campo Status deve conter os Valores de 'inativo' ou 'ativo'");
                }

                _repository.Usuarios.Add(usuario);
                var resultado = _repository.SaveChanges();
                if (resultado > 0)
                {
                    return StatusCode(201, usuario);
                }
                return BadRequest("O Usuario não foi atualizado !");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizandoUsuario([FromBody] Usuario novoUsuario, [FromRoute] int id)
        {
            try
            {
                if (!(_services.ValidaSeUsuarioExiste(id)))
                {
                    return NotFound("O Usuario informado não existe !");
                }
                if (novoUsuario.Id != id)
                {
                    return BadRequest("No corpo do Usuario você deve inserir o mesmo Id correspondente a ele!");
                }
                if (_services.ValidaCnpjCpf(novoUsuario.Cpf_Cnpj))
                {
                    return Conflict("Ja possui um Usuário com o Cpf/Cnpj :" + novoUsuario.Cpf_Cnpj);
                }
                if (!(_services.ValidaStatus_TipoUsuario(novoUsuario)))
                {
                    return BadRequest("A algum erro na inserção de Dados");
                }

                Usuario usuario = _repository.Usuarios.Find(id);
                _repository.Entry(usuario).CurrentValues.SetValues(novoUsuario);
                int resultado = _repository.SaveChanges();
                if (resultado > 0)
                {
                    return Ok(usuario);
                }
                return BadRequest("O Usuario não foi atualizado !");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut]
        [Route("{id}/status")]
        public IActionResult AtualizandoStatusUsuario([FromBody] Status status, [FromRoute] int id)
        {
            try
            {
                Usuario usuario = _repository.Usuarios.Find(id);
                if (!(usuario == null))
                {
                    if (_services.ValidaStatus(status))
                    {
                        usuario.Status = status;
                        _repository.Entry(usuario).CurrentValues.SetValues(usuario);
                        int resultado = _repository.SaveChanges();
                        if (resultado > 0)
                        {
                            return Ok(usuario);
                        }
                        return BadRequest($"O Usuário ja está {status} !");

                    }
                    return BadRequest("O campo Status deve conter os Valores de 0 = inativo ou 1 = ativo");

                }
                return NotFound("O Usuario informado não existe !");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet]
        public IActionResult BuscarUsuarios([FromQuery] string status)
        {
            try
            {
                List<Usuario> usuarios;
                if (status == null)
                {
                    usuarios = _repository.Usuarios.ToList();
                    return Ok(usuarios);
                }
                else
                {
                    if (status == "ATIVO")
                    {
                        usuarios = _repository.Usuarios.Where(x => x.Status == Enums.Status.Ativo).ToList();
                        return Ok(usuarios);
                    }
                    else if (status == "INATIVO")
                    {
                        usuarios = _repository.Usuarios.Where(x => x.Status == Enums.Status.Inativo).ToList();
                        return Ok(usuarios);
                    }
                    return BadRequest("Você deve informar parametros Validos para a busca.\n\n ATIVO ou INATIVO \n\n Obs: Precisa ser escrito em Maiúsculo");
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscarUsuario([FromRoute] int id)
        {
            try
            {
                Usuario usuario = _repository.Usuarios.Find(id);
                if (!(usuario == null))
                {
                    return Ok(usuario);
                }
                return NotFound("O Usuario informado não existe !");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
