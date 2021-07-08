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

    public class UsuariosController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }



        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult GetUsuario()
        {
            try
            {
                return Ok(_usuarioRepository.ListarUsuarios());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetUsuarioPorId(int id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarUsuarioPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult PostUsuario(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.CadastrarUsuario(novoUsuario);

                return StatusCode(201);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuario usuarioAtualizado)
        {
            try
            {
                _usuarioRepository.AtualizarUrlUsuario(id, usuarioAtualizado);

                return NoContent();   
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                _usuarioRepository.DeletarUsuario(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



    }
}
