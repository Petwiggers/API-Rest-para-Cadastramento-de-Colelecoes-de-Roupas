using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Avaliativo_Módulo_02.Data;
using Projeto_Avaliativo_Módulo_02.Models;
using Projeto_Avaliativo_Módulo_02.Services;

namespace Projeto_Avaliativo_Módulo_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColecoesController : ControllerBase
    {
        private readonly Context _repository;
        private readonly Validacoes _services = new Validacoes();

        public ColecoesController(Context context)
        {
            _repository = context;
        }

        [HttpPost]
        public async Task<IActionResult> CadastroColecoes(Colecoes colecao)
        {
            try
            {
                Colecoes validandoUsuario = await _repository.Colecoes.FirstOrDefaultAsync(x => x.Nome == colecao.Nome);
                if (validandoUsuario == null)
                {
                    if (_services.ValidaStatus(colecao.Status) && _services.ValidaEstacoes(colecao.Estacao))
                    {
                        await _repository.Colecoes.AddAsync(colecao);
                        var resultado = await _repository.SaveChangesAsync();
                        if (resultado > 0)
                        {
                            return StatusCode(201, colecao);
                        }
                        return BadRequest("O Usuario não foi atualizado !");
                    }
                    return BadRequest("A algum erro na inserção de Dados");
                }
                return Conflict($"Já possui uma coleção com o nome {colecao.Nome}");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarColecoes(int id, Colecoes colecaoAtualizada)
        {
            try
            {
                if (colecaoAtualizada.Id != id)
                {
                    return BadRequest("No corpo da Coleção você deve inserir o mesmo Id correspondente a ela!");
                }
                Colecoes colecao  = await _repository.Colecoes.FindAsync(id);
                if (!(colecao == null))
                {
                    if (_services.ValidaStatus(colecaoAtualizada.Status) && _services.ValidaEstacoes(colecaoAtualizada.Estacao))
                    {
                        _repository.Entry(colecao).CurrentValues.SetValues(colecaoAtualizada);
                        int resultado = await _repository.SaveChangesAsync();
                        if (resultado > 0)
                        {
                            return Ok(colecaoAtualizada);
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
    
        // GET: api/Colecoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colecoes>>> GetColecoes()
        {
            return await _repository.Colecoes.ToListAsync();
        }

        // GET: api/Colecoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colecoes>> GetColecoes(int id)
        {
            var colecoes = await _repository.Colecoes.FindAsync(id);

            if (colecoes == null)
            {
                return NotFound();
            }

            return colecoes;
        }

        // DELETE: api/Colecoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColecoes(int id)
        {
            var colecoes = await _repository.Colecoes.FindAsync(id);
            if (colecoes == null)
            {
                return NotFound();
            }

            _repository.Colecoes.Remove(colecoes);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        private bool ColecoesExists(int id)
        {
            return _repository.Colecoes.Any(e => e.Id == id);
        }
    }
}
