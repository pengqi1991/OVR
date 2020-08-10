using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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

        

        /// <summary>
        /// 权限字符串，例如 organization:user:view
        /// </summary>
        public string Authorize { get; set; }



        public const string TokenName = "UserToken";

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            string token = string.Empty;
            token = context.HttpContext.Request.Cookies[TokenName];


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
