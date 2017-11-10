using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LocadoraCarro.Filtros
{
    public class AutorizacaoFilterClienteAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cliente = filterContext.HttpContext.Session["clienteLogado"];
            var funcionario = filterContext.HttpContext.Session["funcionarioLogado"];

            if (funcionario == null & cliente == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                            new { controller = "Login", action = "Index" }
                        )
                    );
            }       
        }
    }
}