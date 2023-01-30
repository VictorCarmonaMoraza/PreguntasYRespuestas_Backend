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
    public class RespuestaCuestionarioRepository:IRespuestaCuestionarioRepository
    {
        private readonly AplicationDbContext _context;
        public RespuestaCuestionarioRepository(AplicationDbContext context)
        {
            _context= context;
        }

        public async Task SaveRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario)
        {
            respuestaCuestionario.Activo = 1;
            respuestaCuestionario.Fecha = DateTime.Now;
            _context.Add(respuestaCuestionario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RespuestaCuestionario>> ListRespuestaCuestionario(int idCuestionario, int idUsuario)
        {
            var listRespuestaCuestionario = await _context.RespuestaCuestionario.Where(x=>x.CuestionarioId == idCuestionario
            && x.Activo==1 && x.Cuestionario.UsuarioId==idUsuario).OrderByDescending(x=>x.Fecha).ToListAsync();
            return listRespuestaCuestionario;
        }
    }
}
