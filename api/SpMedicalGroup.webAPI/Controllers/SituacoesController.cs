using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.webAPI.Domains;
using SpMedicalGroup.webAPI.Interfaces;
using SpMedicalGroup.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class SituacoesController : ControllerBase
    {

        private ISituacaoRepository _situacaoRepository { get; set; }


        public SituacoesController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

        [Authorize(Roles="1,2")]
        [HttpGet]
        public IActionResult GetSituacao()
        {
            try
            {
                return Ok(_situacaoRepository.ListarSituacoes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1,2")]
        [HttpGet("{id}")]
        public IActionResult GetSituacaoPorId(int id)
        {
            try
            {
                return Ok(_situacaoRepository.BuscarSituacaoPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult PostSituacao(Situacao novaSituacao)
        {
            try
            {
                _situacaoRepository.CadastrarSituacao(novaSituacao);

                return StatusCode(201);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult PutSituacao(int id, Situacao situacaoAtualizada)
        {
            try
            {
                _situacaoRepository.AtualizarUrlSituacao(id, situacaoAtualizada);

                return NoContent();  
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeleteSituacao(int id)
        {
            try
            {
                _situacaoRepository.DeletarSituacao(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



    }
}
