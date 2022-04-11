using Micrioservice.api.Seguridad.Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Microservice.api.Seguridad.Core.JWTLogic
{
    public class JwtGenerator : IJWTGenerator
    {
        public string CreateToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim("username", usuario.UserName),
                new Claim("nombre", usuario.Nombre),
                new Claim("apellido", usuario.Apellido)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jIuNtM5M9XNd7PiY2UKdLT5b7gSLQay0"));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = credential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
