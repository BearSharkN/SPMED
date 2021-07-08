using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.webAPI.Domains;
using SpMedicalGroup.webAPI.Interfaces;
using SpMedicalGroup.webAPI.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace SpMedicalGroup.webAPI.Controllers
{
    
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]


    public class ConsultasController : ControllerBase
    {

        private IConsultaRepository _consultaRepository { get; set; }


        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult GetConsultas()

        {
            try
            {
                return Ok(_consultaRepository.ListarConsultas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1,2,3")]
        [HttpGet("{id}")]
        public IActionResult GetConsultasPorId(int id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarConsultaPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult PostConsulta(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.CadastrarConsulta(novaConsulta);

                return StatusCode(201);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpPut("{id}")]
        public IActionResult PutConsulta(int id, Consulta consultaAtualizada)
        {
            try
            {
                _consultaRepository.AtualizarUrlConsulta(id, consultaAtualizada);

                return NoContent();  
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeleteConsulta(int id)
        {
            try
            {
                _consultaRepository.DeletarConsulta(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1,2")]
        [HttpPatch("{id}")] 
        public IActionResult PatchSituacao(int id, Consulta situacao)
        {
            
            try
            {
                
                _consultaRepository.AlterarSituacaoConsulta(id, situacao.IdSituacao);

                return StatusCode(204);
            }
            
            catch (Exception error)
            {

                return BadRequest(error);
            
            }
        
        }

        [Authorize(Roles = "2")]
        [HttpGet("consultasMedico")]  
        public IActionResult GetMedicos()
        {
            
            try
            {
               
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarConsultasMedico(idUsuario));
            }
            
            catch (Exception error)
            {
                return BadRequest(new 
                {
                    mensagem = "É Necessário que você faça login para executar essa opção!", error
                });
            }
        
        }

        [Authorize(Roles = "1,3")]
        [HttpGet("minhasConsultas")]   
        public IActionResult GetPaciente()
        {
            
            try
            {
              
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarConsultasPaciente(idUsuario));
            }
            
            catch (Exception error)
            {

                return BadRequest(new
                {
                    mensagem = "É Necessário que você faça login para executar essa opção!", error
                });
            
            }
        
        }



    
    
    }
}
