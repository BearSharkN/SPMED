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

    public class ClinicasController : ControllerBase
    {

        private IClinicaRepository _clinicaRepository { get; set; }


        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult GetClinicas()
        {
            try
            {
                return Ok(_clinicaRepository.ListarClinicas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClinicasPorId(int id)
        {
            try
            {
                return Ok(_clinicaRepository.BuscarClinicaPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult PostClinicas(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.CadastrarClinica(novaClinica);

                return StatusCode(201);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClinicas(int id, Clinica clinicaAtualizada)
        {
            try
            {
                _clinicaRepository.AtualizarUrlClinica(id, clinicaAtualizada);

                return NoContent();   
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteClinicas(int id)
        {
            try
            {
                _clinicaRepository.DeletarClinica(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



    }
}
