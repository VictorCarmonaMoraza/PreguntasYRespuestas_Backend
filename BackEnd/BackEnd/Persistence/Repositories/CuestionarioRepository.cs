using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class CuestionarioRepository: ICuestionarioRepository
    {
        private readonly AplicationDbContext _context;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public CuestionarioRepository(AplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Crea un cuestionario
        /// </summary>
        /// <param name="cuestionario">cuestionario</param>
        /// <returns></returns>
        public async Task CreateCuestionario(Cuestionario cuestionario)
        {
            _context.Add(cuestionario);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Obtiene los cuestionarios por el id del usaurio
        /// </summary>
        /// <param name="idUsuario">id del usuario</param>
        /// <returns></returns>
        public async Task<List<Cuestionario>> GetListCuestionarioByUser(int idUsuario)
        {
            //Obtiene los cuestionarios que estan activo y donde el id del usuario sea el id del usuario que lo requiere
           var listCuestionario = await _context.Cuestionario.Where(x => x.Activo == 1 && x.UsuarioId == idUsuario).ToListAsync();

            return listCuestionario;
        }
    }
}
