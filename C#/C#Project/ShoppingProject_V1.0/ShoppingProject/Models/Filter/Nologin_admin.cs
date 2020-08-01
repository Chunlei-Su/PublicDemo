using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShoppingProject.Models.Filter
{
    public class Nologin_adminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("CurrentAdminAccount") == null)
            {
                context.Result = new RedirectResult("~/ShoppigBackEnd/AdminLogin");
            }
        }
    }
}
