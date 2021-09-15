using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioConsorcio
    {
        Contexto contexto;

        public RepositorioConsorcio()
        {
            contexto = new Contexto();
        }

        public List<Consorcio> Listar(int idUsuario)
        {
            List<Consorcio> consorcios = (from con in contexto.Consorcio where con.IdUsuarioCreador == idUsuario select con).ToList();

            return consorcios;
        }


        public void Eliminar(int idConsorcio)
        {
            Consorcio consorcio = ObtenerPorId(idConsorcio);
            if (consorcio != null)
            {
                contexto.Consorcio.Remove(consorcio);
                
            }
            //no anda eliminar en cascada
            contexto.SaveChanges();
        }

        public int Alta(Consorcio consorcio)
        {
            consorcio.FechaCreacion = DateTime.Today;
            contexto.Consorcio.Add(consorcio);
            contexto.SaveChanges();
            return consorcio.IdConsorcio;
        }

        public void Editar(Consorcio consorcio)
        {
            Consorcio consorcioUpdate = ObtenerPorId(consorcio.IdConsorcio);
            consorcioUpdate.Nombre = consorcio.Nombre;
            consorcioUpdate.IdProvincia = consorcio.IdProvincia;
            consorcioUpdate.Ciudad = consorcio.Ciudad;
            consorcioUpdate.Calle = consorcio.Calle;
            consorcioUpdate.Altura = consorcio.Altura;
            consorcioUpdate.DiaVencimientoExpensas = consorcio.DiaVencimientoExpensas;
            contexto.SaveChanges();
        }
        public Consorcio ObtenerPorId(int idConsorcio)
        {
            Consorcio consorcio;
            consorcio = contexto.Consorcio.Find(idConsorcio);
            return consorcio;
        }

    }
}