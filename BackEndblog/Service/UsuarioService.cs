using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Usuario
{
    public class UsuarioService
    {
        private readonly UsuarioContext _context;
        public UsuarioService(UsuarioContext context)
        {
            _context = context;
        }

        public bool InserirUsuario(TabUsuarioBlog request)
        {
            try
            {
                var usuario = new TabUsuarioBlog()
                {
                    IDusuario = request.IDusuario,
                    Usuario = request.Usuario,
                    Senha = request.Senha,

                };

                _context.TabUsuarioBlog.Add(usuario);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<TabUsuarioBlog> ObterUsuarios()
        {
            try
            {
                var usuarios = _context.TabUsuarioBlog.ToList();
                return usuarios;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public TabUsuarioBlog ObterUsuario(int id)
        {
            try
            {
                var usuario = _context.TabUsuarioBlog.FirstOrDefault(x => x.Id == id);
                return usuario;
            }



            catch (Exception ex)
            {
                return null;
            }
        }   



    }
}
