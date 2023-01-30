using BackEnd.Domain.Models;
using System.Threading.Tasks;

namespace BackEnd.Domain.IRepositories
{
    public interface IRespuestaCuestionarioRepository
    {
        Task SaveRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario);
    }
}
