using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioUnidad
    {
        Contexto contexto;

        public RepositorioUnidad()
        {

            contexto = new Contexto();
        }

        public List<Unidad> Listar(int idConsorcio)
        {
            List<Unidad> unidades = (from con in contexto.Unidad where con.IdConsorcio == idConsorcio select con).ToList();

            return unidades;
        }
        public void Alta(Unidad unidad)
        {
           
            unidad.FechaCreacion = DateTime.Today;
            contexto.Unidad.Add(unidad);
            contexto.SaveChanges();
        }
        public Unidad ObtenerPorId(int idUnidad)
        {
            Unidad unidad;
            unidad = contexto.Unidad.Find(idUnidad);
            return unidad;
        }
        public void Editar(Unidad unidad)
        {
            Unidad unidadUpdate = ObtenerPorId(unidad.IdUnidad);
            unidadUpdate.Nombre = unidad.Nombre;
            unidadUpdate.NombrePropietario = unidad.NombrePropietario;
            unidadUpdate.ApellidoPropietario = unidad.ApellidoPropietario;
            unidadUpdate.EmailPropietario = unidad.EmailPropietario;
            unidadUpdate.Superficie = unidad.Superficie;
            contexto.SaveChanges();
        }

        public void Eliminar(int idUnidad)
        {
            Unidad unidad = ObtenerPorId(idUnidad);
            if (unidad != null)
            {
                contexto.Unidad.Remove(unidad);

            }
            contexto.SaveChanges();
        }


    }


}
