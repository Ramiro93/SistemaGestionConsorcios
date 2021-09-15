using DTO;
using Newtonsoft.Json;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace PW3_TP.ApiControllers
{
    public class ExpensaApiController : ApiController
    {
        ServicioUnidad servicioUnidad;
        ServicioGasto servicioGasto;
        ServicioExpensaDTO servicioExpensaDTO;
        ExpensaDTO expensaDTO;

        public ExpensaApiController()
        {
            servicioUnidad = new ServicioUnidad();
            servicioGasto = new ServicioGasto();
            expensaDTO = new ExpensaDTO();
            servicioExpensaDTO = new ServicioExpensaDTO();
        }
        
        public IList Get(String id)
        {
            int idConsorcio = int.Parse(id);
            IList lista = servicioExpensaDTO.ListarExpensas(idConsorcio);

            return lista;
        }
    }
}