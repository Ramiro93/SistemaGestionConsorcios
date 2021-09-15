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
    public class HomeController : Controller
    {
        // GET: Home
        [UsuarioNoLogueado]
        public ActionResult Inicio()
        {
            LimpiarSession();
            return View();
        }
        [UsuarioNoLogueado]
        public ActionResult Ingresar()
        {
            return View();
        }
        [UsuarioNoLogueado]
        public ActionResult CrearCuentaForm()
        {
            return View();
        }

        public ActionResult error(int error = 0)
        {
            switch (error)
            {
                case 500:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.Description = "Esto es muy vergonzoso, esperemos que no vuelva a pasar ..";
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "La URL que está intentando ingresar no existe";
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Algo salio muy mal :( ..";
                    break;
            }

            return View();
        }

        public void LimpiarSession()
        {
            Session["MsjError"] = null;
            Session["MsjSuccess"] = null;
        }
    }
}