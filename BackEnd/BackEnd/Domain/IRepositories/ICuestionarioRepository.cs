using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IRepositories
{
    public interface ICuestionarioRepository
    {
        /// <summary>
        /// Crea un cuestionario
        /// </summary>
        /// <param name="cuestionario">cuestionario</param>
        /// <returns></returns>
        Task CreateCuestionario(Cuestionario cuestionario);

        /// <summary>
        /// Obtiene los cuestionarios por el id del usaurio
        /// </summary>
        /// <param name="idUsuario">id del usuario</param>
        /// <returns></returns>
        Task<List<Cuestionario>> GetListCuestionarioByUser(int idUsuario);

        /// <summary>
        /// Obtiene el cuestionario por su id 
        /// </summary>
        /// <param name="idCuestionario">id del cuestionario</param>
        /// <returns></returns>
        Task<Cuestionario> GetCuestionario(int idCuestionario);
    }
}
