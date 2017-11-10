using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LocadoraCarro.Filtros
{
    public class AutorizacaoFiltreAdmAttribute : ActionFilterAttribute
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
            } else
            {
                if (((Funcionario)(funcionario)).FuncaoId != 3)
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
}