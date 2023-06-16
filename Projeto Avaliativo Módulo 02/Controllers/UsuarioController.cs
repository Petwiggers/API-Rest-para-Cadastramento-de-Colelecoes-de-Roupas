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
            //Usuario validandoUsuario = _repository.Usuarios.Find(usuario.Cpf_Cnpj);
            //if(validandoUsuario == null)
            //{
            //    _repository.Usuarios.Add(usuario);
            //    _repository.SaveChanges();
            //    return CreatedResult();
            //}
            //else
            //{
            //    return Conflict();
            //}
            _repository.Usuarios.Add(usuario);
            return Ok();


            
        }

     
    }
}
