using Servicios;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcContrib.Filters;
using PW3_TP.Filters;

namespace PW3_TP.Controllers
{
    [ModelStateToTempData]
    [ValidarSession]
    public class UnidadController : Controller
    {

        ServicioUnidad servicioUnidad;
        ServicioConsorcio servicioConsorcio;
  
        public UnidadController()
        {
            servicioUnidad = new ServicioUnidad();
            servicioConsorcio = new ServicioConsorcio();   

        }

        // GET: Unidad
        public ActionResult ListarUnidades(int id)
        {
            Consorcio consorcio = servicioConsorcio.ObtenerPorId(id);
            List<Unidad> unidades = servicioUnidad.Listar(consorcio.IdConsorcio);
            ViewBag.consorcio = consorcio;
            return View(unidades);
        }

        public ActionResult AltaUnidadForm(int id)
        {
            Consorcio consorcio = servicioConsorcio.ObtenerPorId(id);
            Unidad unidad = new Unidad();
            unidad.IdConsorcio = id;
            unidad.Consorcio = consorcio;
            return View(unidad);
        }

        //testear
        [HttpPost]
        public ActionResult AltaUnidad([Bind(Exclude = "Consorcio")] Unidad unidad)
        {
            unidad.IdUsuarioCreador = (int)Session["idUser"];
     
            if (ModelState.IsValid)
            {
                servicioUnidad.Alta(unidad);

                Session["MsjSuccess"] = "Unidad agregada correctamente";

                switch (Request.Params.Get("tipoDeAction"))
                {
                    case "save":
                        return Redirect(url: "/Unidad/ListarUnidades/" + unidad.IdConsorcio);
                    case "saveAndCreate":
                        return Redirect(url: "/Unidad/AltaUnidadForm/" + unidad.IdConsorcio);
                    default:
                        return Redirect(url: "/Unidad/ListarUnidades/" + unidad.IdConsorcio);

                }
            }else
            {
                Consorcio consorcio = servicioConsorcio.ObtenerPorId(unidad.IdConsorcio);
                unidad.Consorcio = consorcio;
                return View("AltaUnidadForm", unidad);
                //return Redirect("/Unidad/AltaUnidadForm/" + consorcio.IdConsorcio);
            }
            
        }
        public ActionResult EditarUnidadForm(int id)
        {
            Unidad unidad = servicioUnidad.ObtenerPorId(id);
            ViewBag.consorcio = servicioConsorcio.ObtenerPorId(unidad.IdConsorcio);
            return View(unidad);
        }
        [HttpPost]
        public ActionResult Editar([Bind(Exclude = "Consorcio")] Unidad unidad)
        {
            unidad.IdUsuarioCreador = (int)Session["idUser"];

            if (ModelState.IsValid)
            {
                servicioUnidad.Editar(unidad);

                Session["MsjSuccess"] = "Unidad editada correctamente";
                return Redirect(url: "/Unidad/ListarUnidades/" + unidad.IdConsorcio);
            }
            else
            {
                return Redirect(url: "/Unidad/EditarUnidadForm/" + unidad.IdUnidad);
            }
           
        }

        public ActionResult EliminarForm(int id)
        {
            Unidad unidad = servicioUnidad.ObtenerPorId(id);
            return View(unidad);
        }


        public ActionResult Eliminar(int id)
        {

            Unidad unidad = servicioUnidad.ObtenerPorId(id);

            servicioUnidad.Eliminar(id);

            Session["MsjSuccess"] = "La unidad ha sido eliminada";

            return Redirect(url: "/Unidad/ListarUnidades/" + unidad.IdConsorcio);
        }
    }
}