using Blog.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Blog.Autenticacao;
using System.Linq;

namespace Blog.Services
{
    public class AutenticacaoService
    {
        private readonly UsuarioContext _context;
        public AutenticacaoService(UsuarioContext context)
        {
            _context = context;
        }
        public AutenticacaoResponse Autenticar(AutenticacaoRequest request)
        {

            var usuario = _context.TabUsuarioBlog.FirstOrDefault(x => x.Usuario == request.UserName && x.Senha == request.Password);
            if (usuario == null)
            {
                return null;
            }
            else
            {
                var tokenString = GerarTokenJwt(usuario);

                var resposta = new AutenticacaoResponse()
                {
                    Token = tokenString,
                    UsuarioId = usuario.Id,
                };

                return resposta;
            }
        }

        private string GerarTokenJwt(TabUsuarioBlog usuario)
        {
            var issuer = "var";
            var audience = "var";
            var key = "2f47ed76-e7d3-4257-86c5-08c20a26a0e7";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("UsuarioId", usuario.Id.ToString())
            };

            var token = new JwtSecurityToken(issuer: issuer, claims: claims, audience: audience, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}