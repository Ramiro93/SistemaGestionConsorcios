using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioGasto
    {
        Contexto contexto;

        public RepositorioGasto()
        {

            contexto = new Contexto();
        }

        public List<Gasto> ListarGastos(int idConsorcio)
        {
            List<Gasto> gastos = (from con in contexto.Gasto where con.IdConsorcio == idConsorcio orderby con.FechaGasto descending select con).ToList();

            return gastos;
        }

        public void AltaGasto(Gasto gasto)
        {
            gasto.FechaCreacion = DateTime.Today;
            contexto.Gasto.Add(gasto);
            contexto.SaveChanges();
        }

        public Gasto ObtenerPorId(int idGasto)
        {
            Gasto gasto;
            gasto = contexto.Gasto.Find(idGasto);
            return gasto;
        }

        public void Editar(Gasto gasto)
        {
            Gasto gastoUpdate = ObtenerPorId(gasto.IdGasto);
            gastoUpdate.Nombre = gasto.Nombre;
            gastoUpdate.IdTipoGasto = gasto.IdTipoGasto;
            gastoUpdate.MesExpensa = gasto.MesExpensa;
            gastoUpdate.AnioExpensa = gasto.AnioExpensa;
            gastoUpdate.Monto = gasto.Monto;
            gastoUpdate.ArchivoComprobante = gasto.ArchivoComprobante;
            contexto.SaveChanges();
        }

        public void Eliminar(int idGasto)
        {
            Gasto gasto = ObtenerPorId(idGasto);
            if (gasto != null)
            {
                contexto.Gasto.Remove(gasto);

            }
            contexto.SaveChanges();
        }
    }
}
