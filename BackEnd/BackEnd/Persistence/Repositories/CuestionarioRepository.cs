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

        
        /// <summary>
        /// Obtenemos el cuestionario por su id
        /// </summary>
        /// <param name="idCuestionario">id del cuestionario</param>
        /// <returns></returns>
        public async Task<Cuestionario> GetCuestionario(int idCuestionario)
        {
            //Obtenemos el cuestionario que se corresponde con el id y que este activo, tambien obtenemos el listado de preguntas 
            //con sus respuestas
            var cuestionario = await _context.Cuestionario.Where(x => x.Id == idCuestionario && x.Activo == 1)
                .Include(x=>x.listPreguntas)
                .ThenInclude(x=>x.listRespuestas)
                .FirstOrDefaultAsync();
            //Retornamos el cuestionario
            return cuestionario;
        }

        /// <summary>
        /// Buscamos un cuestionario por su id
        /// </summary>
        /// <param name="idCuestionario">id del cuestionario a buscar</param>
        /// <returns></returns>
        public async Task<Cuestionario> BuscarCuestionario(int idCuestionario, int idUsuario)
        {
            //Obtenemos el cuestionario por su id y que este activo
            var cuestionario = await _context.Cuestionario.Where(x => x.Id == idCuestionario && x.Activo == 1 && x.UsuarioId == idUsuario).FirstOrDefaultAsync();
            //Retornamos el cuestionario 
            return cuestionario;
        }

        /// <summary>
        /// Eliminamos un cuestionario
        /// </summary>
        /// <param name="cuestionario">cuestionario a eliminar</param>
        /// <returns></returns>
        public async Task EliminarCuestionario(Cuestionario cuestionario)
        {
            //Hacemos borrado logico por lo cual ponemos el formulario en inactivo
            cuestionario.Activo = 0;
            //Modificamos el valor del formulario
            _context.Entry(cuestionario).State = EntityState.Modified;
            //Guardamos los cambios
            await _context.SaveChangesAsync();
        }
    }
}
