using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Service
{
    public class PostService
    {
        private readonly UsuarioContext _context;
        public PostService(UsuarioContext context)
        {
            _context = context;
        }
        public bool InserirPost(TabPost request)
        {
            try
            {
                var post = new TabPost()
                {
                    IdUsuario = request.IdUsuario,
                    titulo = request.titulo,
                    texto = request.texto,

                };

                _context.TabPost.Add(post);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex )
            {
                return false;
            }

        }
        public List<TabPost> ObterPost()
        {
            try
            {
                var usuarios = _context.TabPost.ToList();
                return usuarios;
            }
            catch (Exception )
            {
                return null;
            }
        }
        public bool DeletePost(int id)
        {
            try
            {
                var deletar = _context.TabPost.FirstOrDefault(x => x.Id == id);
                if (deletar == null)
                {
                    return false;
                };
                _context.TabPost.Remove(deletar);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }



    }
}
