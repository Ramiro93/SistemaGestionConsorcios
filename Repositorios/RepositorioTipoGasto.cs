using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioTipoGasto
    {
        Contexto contexto;

        public RepositorioTipoGasto()
        {
            contexto = new Contexto();
        }

        public List<TipoGasto> Listar()
        {
            List<TipoGasto> listaTipoGasto = (from con in contexto.TipoGasto select con).ToList();

            return listaTipoGasto;
        }

        //public Provincia ObtenerPorId(int idProvincia)
        //{
        //    Provincia provincia;
        //    provincia = contexto.Provincia.Find(idProvincia);
        //    return provincia;
        //}
    }
}
