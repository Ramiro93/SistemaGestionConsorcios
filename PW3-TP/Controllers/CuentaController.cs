using Repositorios;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcContrib.Filters;

namespace PW3_TP.Controllers
{
    public class CuentaController : Controller
    {
        ServicioUsuario servicioUsuario;
        public CuentaController()
        {
            servicioUsuario = new ServicioUsuario();
        }

        [HttpPost]
        [ModelStateToTempData]
        public ActionResult Registrar(Usuario usuario, string Repassword)
        {
            LimpiarSession();

            if (ModelState.IsValid && Repassword == usuario.Password)
            {
                if (!servicioUsuario.Registrar(usuario))
                {
                    Session["MsjError"] = "Ya existe un usuario con el email ingresado";
                    return Redirect("/Home/CrearCuentaForm");
                }
                else
                {
                    Session["MsjSuccess"] = "El usuario se registro con exito!";
                    return Redirect("/Home/Ingresar");
                }
            }

            if(Repassword != usuario.Password)
            {
                Session["MsjError"] = "El password y Repassword no coinciden";
            }
            return Redirect("/Home/CrearCuentaForm");
        }

        [HttpPost]
        [ModelStateToTempData]
        public ActionResult Login(Usuario usuario)
        {
            LimpiarSession();

            if (ModelState.IsValid)
            {
                Usuario usuarioExist = servicioUsuario.Login(usuario);

                if (usuarioExist != null)
                {
                    Session["idUser"] = usuarioExist.IdUsuario;
                    Session["userEmail"] = usuarioExist.Email;
                    return Redirect("/Consorcio/Listar");
                }
                else
                {
                    Session["MsjError"] = "El Email y/o Contraseña son inválidos";
                    return Redirect("/Home/Ingresar");
                }
            }
            return RedirectToAction("Ingresar", "Home");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("/Home/Ingresar"); 
        }

        private void LimpiarSession()
        {
            Session["MsjError"] = null;
            Session["idUser"] = null;
            Session["MsjSuccess"] = null;
        }
    }
}