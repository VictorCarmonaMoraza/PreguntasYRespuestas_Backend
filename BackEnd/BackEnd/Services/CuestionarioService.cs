using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class CuestionarioService : ICuestionarioService
    {
        private readonly ICuestionarioRepository _cuestionarioRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cuestionarioService"></param>
        public CuestionarioService(ICuestionarioRepository cuestionarioService)
        {
            this._cuestionarioRepository = cuestionarioService;
        }

        /// <summary>
        /// Crea un cuestionario
        /// </summary>
        /// <param name="cuestionario">cuestionario</param>
        /// <returns></returns>
        public async Task CreateCuestionario(Cuestionario cuestionario)
        {
            await _cuestionarioRepository.CreateCuestionario(cuestionario);
        }

        /// <summary>
        /// Obtiene los cuestionarios por el id del usaurio
        /// </summary>
        /// <param name="idUsuario">id del usuario</param>
        /// <returns></returns>
        public async  Task<List<Cuestionario>> GetListCuestionarioByUser(int idUsuario)
        {
            return await _cuestionarioRepository.GetListCuestionarioByUser(idUsuario);
        }

        /// <summary>
        /// Ontenemos el cuestionario por su id
        /// </summary>
        /// <param name="idCuestionario">id del cuestionario</param>
        /// <returns></returns>
        public async Task<Cuestionario> GetCuestionario(int idCuestionario)
        {
            return await _cuestionarioRepository.GetCuestionario(idCuestionario);
        }
    }
}
