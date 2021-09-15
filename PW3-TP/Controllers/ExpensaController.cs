using DTO;
using Newtonsoft.Json;
using PW3_TP.ApiControllers;
using Repositorios;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PW3_TP.Controllers
{
    public class ExpensaController : Controller
    {
        ServicioExpensaDTO servicioExpensaDTO;
        ServicioConsorcio servicioConsorcio;

        public ExpensaController()
        {
            servicioExpensaDTO = new ServicioExpensaDTO();
            servicioConsorcio = new ServicioConsorcio();
        }
        public enum MesDelAño
        {
            Enero = 1,
            Febrero = 2,
            Marzo = 3,
            Abril = 4,
            Mayo = 5,
            Junio = 6,
            Julio = 7,
            Agosto = 8,
            Septiembre = 9,
            Octubre = 10,
            Noviembre = 11,
            Diciembre = 12

        }
        // GET: Expensa
        public async Task<ActionResult> VerExpensasAsync(String id)
        {
            int idConsorcio = int.Parse(id);
            Consorcio consorcio = servicioConsorcio.ObtenerPorId(idConsorcio);
            
            //Gasto total Mes Actual
            double gastoTotalMesActual = servicioExpensaDTO.CalcularGastoTotalExpensaUltimoMes(idConsorcio);

            //Cantidad de unidades por Consorcio
            int unidadesPorConsorcio = servicioExpensaDTO.ObtenerCantidadUnidadesPorIdConsorcio(idConsorcio);

            //Lista de expensas
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44382/api/ExpensaApi/"+id);
            List<ExpensaDTO> expensas = JsonConvert.DeserializeObject<List<ExpensaDTO>>(json);

            int intMesActual = 1 + expensas[0].MesExpensa;
            String mesActual = Enum.GetName(typeof(MesDelAño),intMesActual);

            expensas.Remove(expensas[0]); // se quita porque se muestra en los inputs de arriba de la tabla

            ViewBag.Consorcio = consorcio;
            ViewBag.MesActual = mesActual;
            ViewBag.GastoTotalMesActual = gastoTotalMesActual;
            ViewBag.UnidadesPorConsorcio = unidadesPorConsorcio;

            return View(expensas);
        }
    }
}