using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioProvincia
    {
        Contexto contexto;

        public RepositorioProvincia()
        {
            contexto = new Contexto();
        }

        public List<Provincia> Listar()
        {
            List<Provincia> provincias = (from con in contexto.Provincia select con).ToList();

            return provincias;
        }

        public Provincia ObtenerPorId(int idProvincia)
        {
            Provincia provincia;
            provincia = contexto.Provincia.Find(idProvincia);
            return provincia;
        }



    }
}
