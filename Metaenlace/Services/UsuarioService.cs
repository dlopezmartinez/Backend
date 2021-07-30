using Metaenlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metaenlace.Repositories;

namespace Metaenlace.Services
{
    public class UsuarioService : IUsuarioService
    {

        private BDContext context;

        public UsuarioService(BDContext context)
        {
            this.context = context;
        }

        public void DeleteById(long id)
        {
            Usuario u = context.Usuarios.Find(id);
            context.Remove(u);
            context.SaveChanges();
        }

        public ICollection<Usuario> FindAll() => context.Usuarios.ToList();


        public Usuario FindById(long id)
        {
           return context.Usuarios.Find(id);
        }

        public bool Save(Usuario usuario)
        {

            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return true;
        }
    }
}
