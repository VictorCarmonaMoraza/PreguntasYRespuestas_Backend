using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface ICuestionarioService
    {
        /// <summary>
        /// Crea un cuestionario
        /// </summary>
        /// <param name="cuestionario">cuestionario</param>
        /// <returns></returns>
        Task CreateCuestionario(Cuestionario cuestionario);

        /// <summary>
        /// Obtiene los cuestionarios por el id del usuario
        /// </summary>
        /// <param name="idUsuario">id del usuario</param>
        /// <returns></returns>
        Task<List<Cuestionario>> GetListCuestionarioByUser(int idUsuario);
    }
}
