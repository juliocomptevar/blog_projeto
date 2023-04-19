using Blog.Model;
using Blog.Service;
using Blog.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly UsuarioContext _context;
        public PostController(UsuarioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult InserirPost([FromBody] TabPost request)
        {
            var usuarioService = new PostService(_context);
            var sucesso = usuarioService.InserirPost(request);

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
        public IActionResult ObterPost()
        {
            var usuarioService = new PostService(_context);
            var sucesso = usuarioService.ObterPost();

            return Ok(sucesso);
        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeletePost([FromRoute] int id)
        {
            var PostService = new PostService(_context);
            var sucesso = PostService.DeletePost(id);

            if (sucesso == true)
            {
                return NoContent();
            }
            else { return BadRequest(); }
        }


    }
}
