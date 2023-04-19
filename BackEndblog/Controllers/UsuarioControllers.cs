using Blog.Model;
using Blog.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioContext _context;

        public UsuarioController(UsuarioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult InserirUsuario([FromBody] TabUsuarioBlog request)
        {
            var usuarioService = new UsuarioService(_context);
            var sucesso = usuarioService.InserirUsuario(request);

            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult ObterUsuarios()
        {
            var usuarioService = new UsuarioService(_context);
            var usuarios = usuarioService.ObterUsuarios();

            try
            {
                return Ok(usuarios);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
