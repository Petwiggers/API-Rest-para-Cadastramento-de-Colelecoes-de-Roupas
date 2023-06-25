using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Avaliativo_Módulo_02.Data;
using Projeto_Avaliativo_Módulo_02.Enums;
using Projeto_Avaliativo_Módulo_02.Models;
using Projeto_Avaliativo_Módulo_02.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Avaliativo_Módulo_02.Controllers
{
    [Route("api/colecoes")]
    [ApiController]
    public class ColecoesController : ControllerBase
    {
        private readonly Context _repository;
        private readonly Validacoes _services;

        public ColecoesController(Context context)
        {
            _repository = context;
            _services = new Validacoes(context);
        }

        [HttpPost]
        public async Task<IActionResult> CadastroColecoes(Colecoes colecao)
        {
            try
            {
                if (_services.ValidaNomeColecao(colecao.Nome))
                {
                    return Conflict($"Já possui uma Coleção com o nome {colecao.Nome} !");
                }
                if (!(_services.ValidaSeUsuarioExiste(colecao.IdResponsavel)))
                {
                    return BadRequest("O Modelo que você relacionou a esta Coleção não existe !");
                }
                if (!(_services.ValidaDadosColecoes(colecao.Status, colecao.Estacao, colecao.IdResponsavel)))
                {
                    return BadRequest("A algum erro na inserção de Dados !");
                }

                await _repository.Colecoes.AddAsync(colecao);
                var resultado = await _repository.SaveChangesAsync();
                if (resultado > 0)
                {
                    return StatusCode(201, colecao);
                }
                return BadRequest("O Usuario não foi atualizado !");
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
                Colecoes colecao  = await _repository.Colecoes.FindAsync(id);
                if (!(_services.ValidaSeColecaoExiste(id)))
                {
                    return NotFound("A Coleção informada não existe !");
                }
                if (colecaoAtualizada.Id != id)
                {
                    return BadRequest("No corpo da Coleção você deve inserir o mesmo Id correspondente a ela!");
                }
                if (_services.ValidaNomeColecao(colecaoAtualizada.Nome) && colecaoAtualizada.Nome != colecao.Nome)
                {
                    return Conflict($"Já possui uma Coleção com o nome {colecaoAtualizada.Nome} !");
                }
                if (!(_services.ValidaSeUsuarioExiste(colecaoAtualizada.IdResponsavel)))
                {
                    return BadRequest("O Modelo que você relacionou a esta Coleção não existe !");
                }
                if (!(_services.ValidaDadosColecoes(colecaoAtualizada.Status, colecaoAtualizada.Estacao, colecaoAtualizada.IdResponsavel)))
                {
                    return BadRequest("A algum erro na inserção de Dados");
                }

                _repository.Entry(colecao).CurrentValues.SetValues(colecaoAtualizada);
                int resultado = await _repository.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Ok(colecaoAtualizada);
                }
                return BadRequest("A Coleção não foi atualizado !");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut]
        [Route("{id}/status")]
        public async Task<ActionResult<IEnumerable<Colecoes>>> AtualizandoStatusColecao([FromBody] Status status, [FromRoute] int id)
        {
            try
            {
                if (!(_services.ValidaSeColecaoExiste(id)))
                {
                    return NotFound("A Coleção informada não existe !");
                }
                if (!(_services.ValidaStatus(status)))
                {
                    return BadRequest("O campo Status deve conter os Valores de 'inativo' ou 'ativo'");
                }

                Colecoes colecao = await _repository.Colecoes.FindAsync(id);
                colecao.Status = status;
                _repository.Entry(colecao).CurrentValues.SetValues(colecao);
                int resultado = await _repository.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Ok(colecao);
                }
                return BadRequest($"A Coleção já está {status}(a) !");

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colecoes>>> ListagemDeColecoes([FromQuery] string status)
        {
            try
            {
                List<Colecoes> colecoes;
                if (status == null)
                {
                    colecoes = await _repository.Colecoes.ToListAsync();
                    return Ok(colecoes);
                }
                else
                {
                    if (status == "ativo")
                    {
                        colecoes = await _repository.Colecoes.Where(x => x.Status == Enums.Status.Ativo).ToListAsync();
                        return Ok(colecoes);
                    }
                    else if (status == "inativo")
                    {
                        colecoes = await _repository.Colecoes.Where(x => x.Status == Enums.Status.Inativo).ToListAsync();
                        return Ok(colecoes);
                    }
                    return BadRequest("Você deve informar parametros Validos para a busca.\n\n 'ativo' ou 'inativo'\n\n Obs: Precisa ser escrito em Minúsculo !");
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Colecoes>> ListagemDeColecoesId(int id)
        {
            try
            {
                if (_services.ValidaSeColecaoExiste(id))
                {
                    Colecoes colecoes = await _repository.Colecoes.FindAsync(id);
                    return Ok(colecoes);
                }
                return NotFound("A Coleção informada não existe !");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColecoes(int id)
        {
            try
            {
                var colecoes = await _repository.Colecoes.FindAsync(id);
                if (!(_services.ValidaSeColecaoExiste(id)))
                {
                    return NotFound("A Coleção digitada não existe na base de Dados !");
                }
                else if (colecoes.Status == Status.Ativo)
                {
                    return BadRequest("Só podem ser excluidas Coleções Inativas no sistema !");
                }
                else if ((_services.VerificaModelosVinculados(id)))
                {
                    return BadRequest("Você não pode excluir está coleção pois ela possui Modelos Vinculados a ela !");
                }

                _repository.Colecoes.Remove(colecoes);
                await _repository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
            
        }
    }
}
