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

        [HttpPut("{id}")]

        public async Task<IActionResult> AtualizarModelos([FromBody] Modelos modeloAtualizado, int id)
        {
            try
            {
                if (modeloAtualizado.Id != id)
                {
                    return BadRequest("No corpo da Coleção você deve inserir o mesmo Id correspondente a ela!");
                }
                Modelos modelo = await _repository.Modelos.FindAsync(id);
                if (!(modelo == null))
                {
                    if (_services.ValidaDadosModelos(modeloAtualizado.Tipo, modeloAtualizado.Layout, modeloAtualizado.IdColecao))
                    {
                        _repository.Entry(modelo).CurrentValues.SetValues(modeloAtualizado);
                        int resultado = await _repository.SaveChangesAsync();
                        if (resultado > 0)
                        {
                            return Ok(modeloAtualizado);
                        }
                        return BadRequest("O Usuario não foi atualizado !");
                    }
                    return BadRequest("A algum erro na inserção de Dados");
                }
                return NotFound("O Usuario informado não existe !");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelos>>> ListagemDeModelos([FromQuery] string layout)
        {
            try
            {
                List<Modelos> modelos;
                if (layout == null)
                {
                    modelos = await _repository.Modelos.ToListAsync();
                    return Ok(modelos);
                }
                else
                {
                    if (layout == "liso")
                    {
                        modelos = await _repository.Modelos.Where(x => x.Layout == Enums.LayoutModelos.Liso).ToListAsync();
                        return Ok(modelos);
                    }
                    else if (layout == "bordado")
                    {
                        modelos = await _repository.Modelos.Where(x => x.Layout== Enums.LayoutModelos.Bordado).ToListAsync();
                        return Ok(modelos);
                    }
                    else if (layout == "estampa")
                    {
                        modelos = await _repository.Modelos.Where(x => x.Layout == Enums.LayoutModelos.Estampa).ToListAsync();
                        return Ok(modelos);
                    }
                    return BadRequest("Você deve informar parametros Validos para a busca.\n\n 'liso', 'bordado' ou 'estampa' \n\n Obs: Precisa ser escrito em Minúsculo !");
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Modelos>> ListagemDeModelosId(int id)
        {
            try
            {
                Modelos modelo = await _repository.Modelos.FindAsync(id);
                if (!(modelo == null))
                {
                    return Ok(modelo);
                }
                return NotFound("O Modelo informado não existe !");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelos(int id)
        {
            Modelos modelo= await _repository.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound("O Usuário digitado não existe na base de Dados !");
            }

            _repository.Modelos.Remove(modelo);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}


