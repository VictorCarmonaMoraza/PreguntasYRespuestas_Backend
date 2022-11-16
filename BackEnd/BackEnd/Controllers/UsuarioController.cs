using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using BackEnd.Utils;
using BackEnd.DTO;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Post( Usuario usuario)
        {
            try
            {
                var validateExistence = await _usuarioService.ValidateExistence(usuario);
                if (validateExistence)
                {
                    return BadRequest(new { message = "El usuario " + usuario.NombreUsuario + " ya existe!" });
                }
                //Encriptamos
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                await _usuarioService.SaveUser(usuario);
                return Ok(new { message = "Usuario registrado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Localhost:xxx/api/Usuario/CambiarPassword
        [Route("CambiarPassword")]
        [HttpPut]
        public async Task<IActionResult>CambiarPassword([FromBody] CambiarPasswordDTO cambiarPasswordDTO)
        {
            try
            {
                int idUsuario = 5;
                //Encriptamos la password
                string passwordEncriptado = Encriptar.EncriptarPassword(cambiarPasswordDTO.passwordAnterior);
                var usuario = await _usuarioService.ValidatePassword(idUsuario, passwordEncriptado);
                //Es que no encontro usuario
                if (usuario == null)
                {
                    return BadRequest(new { message = "La password es Incorrecta" });
                }
                else
                {
                    usuario.Password = Encriptar.EncriptarPassword(cambiarPasswordDTO.nuevaPassword);
                    await _usuarioService.UpdatePassword(usuario);
                    return Ok(new { message = "La password fue actualizada con exito!" });
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
    }
}
