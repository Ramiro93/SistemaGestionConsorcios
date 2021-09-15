using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioUnidad
    {
        RepositorioUnidad repositorioUnidad;

        public ServicioUnidad() {


          repositorioUnidad = new RepositorioUnidad();

        }

        public List<Unidad> Listar(int idConsorcio)
        {
            return repositorioUnidad.Listar(idConsorcio);
        }
        public void Alta(Unidad unidad)
        {
            repositorioUnidad.Alta(unidad);
        }
        public Unidad ObtenerPorId(int idUnidad)
        {
            return repositorioUnidad.ObtenerPorId(idUnidad);
        }
        public void Editar(Unidad unidad)
        {
            repositorioUnidad.Editar(unidad);
        }

        public void Eliminar(int idUnidad)
        {
            repositorioUnidad.Eliminar(idUnidad);
        }
    }
}
