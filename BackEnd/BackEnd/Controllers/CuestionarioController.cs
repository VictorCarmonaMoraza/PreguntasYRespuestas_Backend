using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuestionarioController : ControllerBase
    {
        private readonly ICuestionarioService _cuestionarioService;
        public CuestionarioController(ICuestionarioService cuestionarioService)
        {
            this._cuestionarioService = cuestionarioService;
        }

        /// <summary>
        /// Crea un cuestionario
        /// </summary>
        /// <param name="cuestionario">cuestionario</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] Cuestionario cuestionario)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                cuestionario.UsuarioId = idUsuario;
                cuestionario.Activo = 1;
                cuestionario.FechaCreacion = DateTime.Now;
                await _cuestionarioService.CreateCuestionario(cuestionario); 


                return Ok(new { message = "Se agrego el cuestionario exitosamente" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los cuestionarios por el id del usuario
        /// </summary>
        /// <returns></returns>
        [Route("GetListCuestionarioByUser")]
        [HttpGet]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListCuestionarioByUser()
        {
            try
            {
                //Obtenemos el id del usuario a traves del token
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var listCuestionario = await _cuestionarioService.GetListCuestionarioByUser(idUsuario);
                return Ok(listCuestionario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un cuestionario por su id
        /// </summary>
        /// <param name="idCuestionario">id del cuestionario</param>
        /// <returns></returns>
        [HttpGet("{idCuestionario}")]
        public async Task<IActionResult> GetCuestionario(int idCuestionario)
        {
            try
            {
                //Obtenemos el cuestionario por su id
                var cuestionario = await _cuestionarioService.GetCuestionario(idCuestionario);
                return Ok(cuestionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Borrado logico para el borrado de un cuestionario
        /// </summary>
        /// <param name="idCuestionario">id del cuestionario a borrar</param>
        /// <returns></returns>
        [HttpDelete("{idCuestionario}")]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int idCuestionario)
        {
            try
            {


                //Obtenemos el id del usuario a traves del token
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                //Comporbamos si el cuestionario existe
                var cuestionario = await _cuestionarioService.BuscarCuestionario(idCuestionario, idUsuario);

                if (cuestionario == null)
                {
                    return BadRequest(new{ message = "No se encontroningun cuestionario" });
                }
                await _cuestionarioService.EliminarCuestionario(cuestionario);
                return Ok(new { message = "Elc cuestionario fue eliminado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        }

        [Route("GetListCuestionarios")]
        [HttpGet]
        public async Task<IActionResult> GetListCuestionarios()
        {
            try
            {
                var listCuestionarios = await _cuestionarioService.GetListCuestionarios();
                return Ok(listCuestionarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
