using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OVR.Common;
using OVR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OVR.Filters
{
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        public AuthorizeFilterAttribute() { }

        

       

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            string token = string.Empty;
            token = context.HttpContext.Request.Cookies[CommonData.TokenName];


            if (string.IsNullOrEmpty(token))
            {
                context.Result = new RedirectResult("~/Home/Login");
                return;
            }
            else
            {
                 await next();
            }


            
           
        }
    }
}
