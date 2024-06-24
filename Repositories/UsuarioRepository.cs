using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Exo.WebApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly ExoContext _context;
        
        public UsuarioRepository(ExoContext context)
        {
            _context = context;
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioAtual = _context.Usuarios.Find(id);

            if(usuarioAtual != null)
            {
                usuarioAtual.Email = usuario.Email;
                usuarioAtual.Senha = usuario.Senha;
            }

            _context.Usuarios.Update(usuarioAtual);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioAtual = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuarioAtual);
            _context.SaveChanges();
        }
    }
}