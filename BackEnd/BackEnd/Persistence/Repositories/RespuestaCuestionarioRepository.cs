using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using System;
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
    }
}
