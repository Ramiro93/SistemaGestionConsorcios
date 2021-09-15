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
    [ValidarSession]
    [ModelStateToTempData]
    public class ConsorcioController : Controller
    {
        ServicioConsorcio servicioConsorcio;
        RepositorioProvincia repositorioProvincia;
        public ConsorcioController()
        {
            servicioConsorcio = new ServicioConsorcio();
            repositorioProvincia = new RepositorioProvincia();
        }


        // GET: Consorcio
        public ActionResult Listar()
        {
            int userId = (int)Session["idUser"];
            List<Consorcio> consorcios = servicioConsorcio.Listar(userId);

            return View(consorcios);
        }

        public ActionResult EditarForm(int id)
        {
            Consorcio consorcio = servicioConsorcio.ObtenerPorId(id);
            List<Provincia> provincias = repositorioProvincia.Listar();
            ViewBag.Provincias = provincias;   
            
            return View(consorcio);
        }

        public ActionResult AltaForm()
        {
            List<Provincia> provincias = repositorioProvincia.Listar();
            ViewBag.Provincias = provincias;
            Consorcio consorcio = new Consorcio();
            consorcio.IdProvincia = 0;

            return View(consorcio);
        }

        [HttpPost]
        public ActionResult Alta(Consorcio consorcio)
        {
            if (ModelState.IsValid)
            {
                consorcio.IdUsuarioCreador = (int)Session["idUser"];

                int idConsorcio = servicioConsorcio.Alta(consorcio);

                Session["MsjSuccess"] = "Consorcio agregado correctamente";
                


                switch (Request.Params.Get("tipoDeAction"))
                {
                    case "save":
                        return Redirect("/Consorcio/Listar");
                    case "saveAndCreate":
                        return Redirect(url: "/Consorcio/AltaForm/");
                    case "saveAndEdit":
                        return Redirect(url: "/Consorcio/EditarForm/"+idConsorcio);
                    default:
                        return Redirect("/Consorcio/Listar");

                }
            }
            List<Provincia> provincias = repositorioProvincia.Listar();
            ViewBag.Provincias = provincias;
            return View("AltaForm", consorcio);
        }


        [HttpPost]
        public ActionResult Editar(Consorcio consorcio)
        {
            if (ModelState.IsValid)
            {
                consorcio.IdUsuarioCreador = (int)Session["idUser"];

                servicioConsorcio.Editar(consorcio);

                Session["MsjSuccess"] = "Consorcio editado correctamente";
                return Redirect("/Consorcio/Listar");
            }
            return Redirect("/Consorcio/EditarForm/" + consorcio.IdConsorcio);
        }


        public ActionResult EliminarForm(int id)
        {
            Consorcio consorcio = servicioConsorcio.ObtenerPorId(id);
            return View(consorcio);
        }

        
        public ActionResult Eliminar(int id)
        {
            servicioConsorcio.Eliminar(id);

            Session["MsjSuccess"] = "El consorcio ha sido eliminado";

            return Redirect("/Consorcio/Listar");
        }
    }
}