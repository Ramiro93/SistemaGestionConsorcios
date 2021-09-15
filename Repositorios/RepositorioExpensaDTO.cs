using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioExpensaDTO
    {
        Contexto contexto;

        public RepositorioExpensaDTO()
        {
            contexto = new Contexto();
        }

        public IList ListarExpensas(int idConsorcio)
        {

            var cantidadUnidades = (from uni in contexto.Unidad where uni.IdConsorcio == idConsorcio select uni).Count();
            //Agregar AnioExpensa y MesExpensa al Select de la query
            var listaGastos = contexto.Gasto.GroupBy(x => new { x.AnioExpensa, x.MesExpensa, x.IdConsorcio }).OrderByDescending(x => x.Key.AnioExpensa).ThenByDescending(x => x.Key.MesExpensa)
                                .Select(x => new { MesYAnio = x.Key, AnioExpensa = x.Key.AnioExpensa, MesExpensa = x.Key.MesExpensa, GastoTotal = x.Sum(y => y.Monto), ExpensaPorUnidad = x.Sum(y => y.Monto)/cantidadUnidades })
                                .Where(x => x.MesYAnio.IdConsorcio == idConsorcio).ToList();

            return listaGastos;


        }

        public int ObtenerCantidadUnidadesPorIdConsorcio(int idConsorcio)
        {

            var cantidadUnidades = contexto.Unidad.Where(x => x.IdConsorcio == idConsorcio).Count();

            return cantidadUnidades;
        }
        public double CalcularGastoTotalExpensaUltimoMes(int idConsorcio)
        {
         
            var anioExpensaMax = (from con in contexto.Gasto where con.IdConsorcio == idConsorcio orderby con.FechaGasto descending select con.AnioExpensa
                               ).First();
            var mesExpensaMax = (from con in contexto.Gasto where con.IdConsorcio == idConsorcio orderby con.FechaGasto descending select con.MesExpensa
                               ).First();

            decimal gastoTotal = contexto.Gasto.Where(x => x.AnioExpensa == anioExpensaMax && x.MesExpensa == mesExpensaMax).Sum(x => x.Monto);
            
            return decimal.ToDouble(gastoTotal);
        }


    }

}
