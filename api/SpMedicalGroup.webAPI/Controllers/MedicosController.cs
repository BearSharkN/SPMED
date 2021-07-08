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

    public class MedicosController : ControllerBase
    {

     
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }


        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult GetMedicos()
        {
            try
            {
                return Ok(_medicoRepository.ListarMedicos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);   
            }
        }


        [Authorize(Roles = "1,2")]
        [HttpGet("{id}")]
        public IActionResult GetMedicosPorId(int id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarMedicoPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult PostMedico(Medico novoMedico)
        {
            try
            {
                _medicoRepository.CadastrarMedico(novoMedico);

                return StatusCode(201);   
            }

            catch (Exception ex)
            {
                return BadRequest(ex);   
            }

        }


        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult PutMedico(int id, Medico medicoAtualizado)
        {
            try
            {
                _medicoRepository.AtualizarUrlMedico(id, medicoAtualizado);

                return StatusCode(204);  
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeleteMedico(int id)
        {
            try
            {
                _medicoRepository.DeletarMedico(id);

                return StatusCode(204);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }



    }

}
