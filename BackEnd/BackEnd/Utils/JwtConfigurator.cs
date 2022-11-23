using BackEnd.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Utils
{
    public class JwtConfigurator
    {
        public static string GetToken(Usuario userInfo, IConfiguration config)
        {
            string Secretkey = config["Jwt:SecretKey"];
            string Issuer = config["Jwt:Issuer"];
            string Audience = config["Jwt:Audience"];
            return "token";
        }
    }
}
