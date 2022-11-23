using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;
        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {
                //Primero encriptamos contraseña
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                //Validamos el usuario
                var user = await _loginService.ValidateUser(usuario);

                if (user == null)
                {
                    return BadRequest(new { message = "Usuario o contraseña invalidos" });
                }
                string tokenString = JwtConfigurator.GetToken(user, _config);

                return Ok(new { usuario = usuario.NombreUsuario });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
