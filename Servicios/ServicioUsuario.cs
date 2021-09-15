using Microsoft.Win32;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioUsuario
    {

        RepositorioUsuario repositorioUsuario;


        public ServicioUsuario()
        {
            repositorioUsuario = new RepositorioUsuario();
        }

        public bool Registrar(Usuario usuario)
        {
            Usuario user = repositorioUsuario.buscarUsuarioPorEmail(usuario.Email);
            if (user.Email != null)
            {
                return false;
            }
            else
            {
                repositorioUsuario.Registrar(usuario);
                return true;
            }
            
            
        }
        
        public Usuario Login(Usuario usuario)
        {
            Usuario user = repositorioUsuario.login(usuario);

            return user;

        }


    }
}
