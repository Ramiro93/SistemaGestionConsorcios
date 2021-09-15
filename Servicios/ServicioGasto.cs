using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioGasto
    {

        RepositorioGasto repositorioGasto;

        public ServicioGasto()
        {
            repositorioGasto = new RepositorioGasto();

        }

        public List<Gasto> ListarGastos(int idConsorcio)
        {
            return repositorioGasto.ListarGastos(idConsorcio);
        }

        public void AltaGasto(Gasto gasto)
        {
            repositorioGasto.AltaGasto(gasto);
        }
        public Gasto ObtenerPorId(int idGasto)
        {
            return repositorioGasto.ObtenerPorId(idGasto);
        }
        public void Editar(Gasto gasto)
        {
            repositorioGasto.Editar(gasto);
        }

        public void Eliminar(int idGasto)
        {
            repositorioGasto.Eliminar(idGasto);
        }
    }

}
