using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LocadoraCarro.Filtros
{
    public class AutorizacaoFiltreFuncionarioAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var funcionario = filterContext.HttpContext.Session["funcionarioLogado"];
            var cliente = filterContext.HttpContext.Session["clienteLogado"];
         
            if (cliente != null || funcionario == null)
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