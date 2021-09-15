using Servicios;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PW3_TP.Filters;
using PW3_TP.Utilities;
using MvcContrib.Filters;

namespace PW3_TP.Controllers
{
    [ModelStateToTempData]
    [ValidarSession]
    public class GastoController : Controller
    {
        ServicioGasto servicioGasto;
        ServicioConsorcio servicioConsorcio;
        RepositorioTipoGasto repositorioTipoGasto;

        public GastoController()
        {
            servicioGasto = new ServicioGasto();
            servicioConsorcio = new ServicioConsorcio();
            repositorioTipoGasto = new RepositorioTipoGasto();
        }
        // GET: Gasto
        public ActionResult ListarGastos(int id)
        {
            Consorcio consorcio = servicioConsorcio.ObtenerPorId(id);
            List<Gasto> gastos = servicioGasto.ListarGastos(consorcio.IdConsorcio);
            ViewBag.consorcio = consorcio;
            return View(gastos);
        }

        public ActionResult AltaGastoForm(int id)
        {
            Gasto gasto = new Gasto();
            gasto.IdConsorcio = id;
            Consorcio consorcio = servicioConsorcio.ObtenerPorId(id);
            gasto.Consorcio = consorcio;
            gasto.FechaGasto = DateTime.Today;
            List<TipoGasto> tipoGastos = repositorioTipoGasto.Listar();
            ViewBag.TipoGasto = tipoGastos;

            return View(gasto);
        }

        [HttpPost]
        public ActionResult AltaGasto([Bind(Exclude = "Consorcio")] Gasto gasto)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                string pathRelativoImagen = ComprobantesUtility.Guardar(Request.Files[0], "comprobante_"+gasto.Nombre);
                gasto.ArchivoComprobante = pathRelativoImagen;
            }

            gasto.IdUsuarioCreador = (int)Session["idUser"];
            

            if (ModelState.IsValid)
            {
                servicioGasto.AltaGasto(gasto);

                Session["MsjSuccess"] = "Gasto agregado correctamente";

                switch (Request.Params.Get("tipoDeAction"))
                {
                    case "save":
                        return Redirect(url: "/Gasto/ListarGastos/" + gasto.IdConsorcio);
                    case "saveAndCreate":
                        return Redirect(url: "/Gasto/AltaGastoForm/" + gasto.IdConsorcio);
                    default:
                        return Redirect(url: "/Gasto/ListarGastos/" + gasto.IdConsorcio);

                }
            }
            else
            {
                Consorcio consorcio = servicioConsorcio.ObtenerPorId(gasto.IdConsorcio);
                gasto.Consorcio = consorcio;
                List<TipoGasto> tipoGastos = repositorioTipoGasto.Listar();
                ViewBag.TipoGasto = tipoGastos;
                return View("AltaGastoForm", gasto);
            }
         
        }
        public ActionResult EditarGastoForm(int id)
        {
            Gasto gasto = servicioGasto.ObtenerPorId(id);
            Consorcio consorcio = servicioConsorcio.ObtenerPorId(gasto.IdConsorcio);
            ViewBag.Consorcio = consorcio;
            List<TipoGasto> tipoGastos = repositorioTipoGasto.Listar();
            ViewBag.TipoGasto = tipoGastos;
            return View(gasto);
        }

        [HttpPost]
        public ActionResult EditarGasto([Bind(Exclude = "Consorcio")] Gasto gasto)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                string pathRelativoImagen = ComprobantesUtility.Guardar(Request.Files[0], "comprobante_" + gasto.Nombre);
                gasto.ArchivoComprobante = pathRelativoImagen;
            }

            if (ModelState.IsValid)
            {
                servicioGasto.Editar(gasto);

                Session["MsjSuccess"] = "Gasto editado correctamente";
                return Redirect(url: "/Gasto/ListarGastos/" + gasto.IdConsorcio);
            }
            else
            {
                return Redirect("/Gasto/EditarGastoForm/" + gasto.IdGasto);
            }
        }
        public ActionResult EliminarForm(int id)
        {
            Gasto gasto = servicioGasto.ObtenerPorId(id);
            return View(gasto);
        }

        public ActionResult Eliminar(int id)
        {

            Gasto gasto = servicioGasto.ObtenerPorId(id);

            servicioGasto.Eliminar(id);

            Session["MsjSuccess"] = "La unidad ha sido eliminada";

            return Redirect(url: "/Gasto/ListarGastos/" + gasto.IdConsorcio);
        }

        public FileResult DescargarComprobante(int id)
        {
            Gasto gasto = servicioGasto.ObtenerPorId(id);
            var path = Server.MapPath(gasto.ArchivoComprobante);
            
            return File(path, "application/pdf","comprobante_"+gasto.Nombre+".pdf");
        }
    }
    
}