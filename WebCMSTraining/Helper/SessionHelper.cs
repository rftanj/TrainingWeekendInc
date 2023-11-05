using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace WebCMSTraining.Helper
{
    public class SessionHelper : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var email = context.HttpContext.Session.GetString("Email");

            var controller = context.Controller as Controller;
            if (controller == null) return;

            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
           

            if (email == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller","Autentikasi"},{"action", "Login" } });
            }
           

            base.OnActionExecuting(context);
        }
        
    }
}

//NOTE

//Model ini dapat digunakan untuk beberapa Method yang tidak bisa diakses siapapun.
//Apabila ingin mengakses sebuah Method berdasarkan user role yang login, tambahkan [SessionHelper] diatas Method tersebut



