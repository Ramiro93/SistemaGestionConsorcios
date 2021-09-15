using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioConsorcio
    {
        RepositorioConsorcio repositorioConsorcio;


        public ServicioConsorcio()
        {
            repositorioConsorcio = new RepositorioConsorcio();
        }

        public List<Consorcio> Listar(int idUsuario)
        {
    
            return repositorioConsorcio.Listar(idUsuario);
        }

        public void Eliminar(int idConsorcio)
        {
            repositorioConsorcio.Eliminar(idConsorcio);
        }

        public void Editar(Consorcio consorcio)
        {
            repositorioConsorcio.Editar(consorcio);
        }

        public int Alta(Consorcio consorcio)
        {
            return repositorioConsorcio.Alta(consorcio);
        }

        public Consorcio ObtenerPorId(int idConsorcio)
        {
            return repositorioConsorcio.ObtenerPorId(idConsorcio);
        }

    }
}
