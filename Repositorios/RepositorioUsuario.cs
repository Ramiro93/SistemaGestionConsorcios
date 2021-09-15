using System.Data.Entity;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioUsuario
    {
        Contexto contexto;

        public RepositorioUsuario()
        {
            contexto = new Contexto();
        }

        public Usuario login(Usuario usuario)
        {
            Usuario user = (from us in contexto.Usuario where us.Email == usuario.Email && us.Password == usuario.Password select us).FirstOrDefault();

            if (user != null)
            {
                user.FechaUltLogin = DateTime.Now;
                contexto.SaveChanges();
            }
            return user;
        }



        public void Registrar(Usuario usuario)
        {
            Usuario userNew = new Usuario();
            userNew.Email = usuario.Email;
            userNew.Password = usuario.Password;
            userNew.FechaRegistracion = DateTime.Today;
            userNew.FechaUltLogin = DateTime.Today;

            contexto.Usuario.Add(userNew);
            contexto.SaveChanges();
        }

        public Usuario buscarUsuarioPorEmail(String Email)
        {
           Usuario user = new Usuario();
            try
            {
                user = (from us in contexto.Usuario where us.Email == Email select us).First();
                return user;
            } catch
            {
                return user;
            }
           
        }
    }
}

