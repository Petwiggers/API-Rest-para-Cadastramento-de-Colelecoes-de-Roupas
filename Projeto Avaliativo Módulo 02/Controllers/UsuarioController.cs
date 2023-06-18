using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Avaliativo_Módulo_02.Data;
using Projeto_Avaliativo_Módulo_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Context _repository;

        public UsuarioController(Context context)
        {
            _repository = context;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> BuscarTodosUSuarios()
        {
            var usuarios = _repository.Usuarios.ToList();
            return Ok(usuarios);
        }

        [HttpPost]
        [Route("/Cliente")]
        public IActionResult CadastrandoUsuario([FromBody]Usuario usuario)
        {
            try
            {
                Usuario validandoUsuario = _repository.Usuarios.FirstOrDefault(x => x.Cpf_Cnpj == usuario.Cpf_Cnpj);
                if (validandoUsuario == null)
                {

                    if ((usuario.Status == Enums.Status.Ativo || usuario.Status == Enums.Status.Inativo)
                        && (usuario.TipoUsuario == Enums.TipoUsuario.Administrador || usuario.TipoUsuario == Enums.TipoUsuario.Criador
                        || usuario.TipoUsuario == Enums.TipoUsuario.Gerente || usuario.TipoUsuario == Enums.TipoUsuario.Outro))
                    {
                        _repository.Usuarios.Add(usuario);
                        var resultado = _repository.SaveChanges();
                        if (resultado > 0)
                        {
                            return StatusCode(201, usuario);
                        }

                    }
                    return BadRequest("A algum erro na inserção de Dados");

                }

                return Conflict();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        
        }

     
    }
}
