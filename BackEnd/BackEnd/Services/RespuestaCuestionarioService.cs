using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class RespuestaCuestionarioService: IRespuestaCuestionarioService
    {
        private readonly IRespuestaCuestionarioRepository _respuestaCuestionarioRepository;

        public RespuestaCuestionarioService(IRespuestaCuestionarioRepository respuestaCuestionarioRepository)
        {
            _respuestaCuestionarioRepository = respuestaCuestionarioRepository;
        }

        public async Task SaveRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario)
        {
             await _respuestaCuestionarioRepository.SaveRespuestaCuestionario(respuestaCuestionario);
        }
    }
}
