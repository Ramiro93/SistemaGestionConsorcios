using PW3_TP.Controllers;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PW3_TP.Filters
{
    public class UsuarioNoLogueadoAttribute : ActionFilterAttribute
    {
        
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                
                if(HttpContext.Current.Session["idUser"] != null)
                {
                    if (filterContext.Controller is CuentaController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Consorcio/listar");
                    }
                    
                }
            }
            catch (Exception)
            {

                filterContext.Result = new RedirectResult("~/Home/Ingresar");
            }
        }
    }
}