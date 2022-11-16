using BackEnd.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class LoginRepository:ILoginRepository
    {
        private readonly ILoginRepository _loginRepository;
        public LoginRepository(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
    }
}
