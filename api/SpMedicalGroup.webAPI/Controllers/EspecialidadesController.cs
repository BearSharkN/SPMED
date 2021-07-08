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

    public class EspecialidadesController : ControllerBase
    {

        private IEspecialidadeRepository _especialidadeRepository { get; set; }


        public EspecialidadesController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }


        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult GetEspecialidades()
        {
            try
            {
                return Ok(_especialidadeRepository.ListarEspecialidades());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1,2")]
        [HttpGet("{id}")]
        public IActionResult GetEspecialidadesPorId(int id)
        {
            try
            {
                return Ok(_especialidadeRepository.BuscarEspecialidadePorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult PostEspecialidade(Especialidade novaEspecialidade)
        {
            try
            {
                _especialidadeRepository.CadastrarEspecialidade(novaEspecialidade);

                return StatusCode(201);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult PutEspecialidade(int id, Especialidade especialidadeAtualizada)
        {
            try
            {
                _especialidadeRepository.AtualizarUrlEspecialidade(id, especialidadeAtualizada);

                return NoContent();  
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeleteEspecialidade(int id)
        {
            try
            {
                _especialidadeRepository.DeletarEspecialidade(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



    }
}
