using Blog.Autenticacao;
using Blog.Model;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AutenticacaoController : ControllerBase
    {
        private readonly UsuarioContext _context;
        public AutenticacaoController(UsuarioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AutenticacaoRequest request)
        {
            var autenticacaoService = new AutenticacaoService(_context);
            var resposta = autenticacaoService.Autenticar(request);

            if (resposta == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(resposta);
            }
        }
    }
}
