using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpMedicalGroup.webAPI.Domains;
using SpMedicalGroup.webAPI.Interfaces;
using SpMedicalGroup.webAPI.Repositories;
using SpMedicalGroup.webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpMedicalGroup.webAPI.Controllers
{

    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioDados = _usuarioRepository.Login(login.Email, login.Senha);

                if (usuarioDados == null)
                {
                    return NotFound("Usuário ou senha Invaido!");
                }

                
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioDados.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioDados.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioDados.IdTipoUsuario.ToString()),
                    
                    
                    new Claim("role", usuarioDados.IdTipoUsuario.ToString())

                };


                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("medical-key-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(

                    issuer: "SpMedicalGroup.webAPI",
                    audience: "SpMedicalGroup.webAPI",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds

                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }


            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }

}
