using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OVR.Common.Auth
{
    public static class CookieHelper
    {

       
        /// 写cookie值
        /// </summary>
        /// <param name="sName">名称</param>
        /// <param name="sValue">值</param>
        public static void WriteCookie(HttpContext httpContext, string sName, string sValue)
        {

            httpContext.Response.Cookies.Append(sName, sValue, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            });
        }



       

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="sName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(HttpContext httpContext, string sName)
        {
            return httpContext.Request.Cookies[sName];
        }

        /// <summary>
        /// 删除Cookie对象
        /// </summary>
        /// <param name="sName">Cookie对象名称</param>
        public static void RemoveCookie(HttpContext httpContext, string sName)
        {
            httpContext.Response.Cookies.Delete(sName);
        }
    }
}
