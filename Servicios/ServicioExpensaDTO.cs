using DTO;
using Repositorios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{

    public class ServicioExpensaDTO
    {
        RepositorioExpensaDTO repositorioExpensaDTO;

        public ServicioExpensaDTO()
        {
            repositorioExpensaDTO = new RepositorioExpensaDTO();
        }

        public IList ListarExpensas(int idConsorcio)
        {
            IList expensas = repositorioExpensaDTO.ListarExpensas(idConsorcio);
            
            return expensas;
        }

        public int ObtenerCantidadUnidadesPorIdConsorcio(int idConsorcio)
        {
            int cantidad = repositorioExpensaDTO.ObtenerCantidadUnidadesPorIdConsorcio(idConsorcio);

            return cantidad;
        }

        public double CalcularGastoTotalExpensaUltimoMes(int idConsorcio)
        {
            double gasto = repositorioExpensaDTO.CalcularGastoTotalExpensaUltimoMes(idConsorcio);

            return gasto;

        }

    }
}