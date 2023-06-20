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

        // PUT: api/Colecoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColecoes(int id, Colecoes colecoes)
        {
            if (id != colecoes.Id)
            {
                return BadRequest();
            }

            _repository.Entry(colecoes).State = EntityState.Modified;

            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColecoesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Colecoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colecoes>> PostColecoes(Colecoes colecao)
        {
            try
            {
                Colecoes validandoUsuario = _repository.Colecoes.FirstOrDefault(x => x.Nome == colecao.Nome);
                if (validandoUsuario == null)
                {
                    if (_services.ValidaStatus(colecao.Status) && _services.ValidaEstacoes(colecao.Estacao))
                    {
                        _repository.Colecoes.Add(colecao);
                        var resultado = _repository.SaveChanges();
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
