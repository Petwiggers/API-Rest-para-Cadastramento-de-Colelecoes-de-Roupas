using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Avaliativo_Módulo_02.Data;
using Projeto_Avaliativo_Módulo_02.Models;
using Projeto_Avaliativo_Módulo_02.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly Context _repository;
        private readonly Validacoes _services;
        public ModelosController(Context context)
        {
            _repository = context;
            _services = new Validacoes(context);
        }

        [HttpPost]
        public async Task<IActionResult> CadastroModelos([FromBody] Modelos modelo)
        {
            try
            {
                Modelos validandoUsuario = await _repository.Modelos.FirstOrDefaultAsync(x => x.Nome == modelo.Nome);
                if (validandoUsuario == null)
                {
                    if (_services.ValidaDadosModelos(modelo.Tipo, modelo.Layout, modelo.IdColecao))
                    {
                        await _repository.Modelos.AddAsync(modelo);
                        var resultado = await _repository.SaveChangesAsync();
                        if (resultado > 0)
                        {
                            return StatusCode(201, modelo);
                        }
                        return BadRequest("O Usuario não foi atualizado !");
                    }
                    return BadRequest("A algum erro na inserção de Dados");
                }
                return Conflict($"Já possui um Modelo com o nome {modelo.Nome}");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
