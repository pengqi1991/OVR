using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OVR.Common.Auth;
using OVR.Common.Cache;
using OVR.IServices;
using OVR.Model.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OVR.Web.Auth
{
    public class Operator
    {
        public static Operator Instance
        {
            get { return new Operator(); }
        }



        private string TokenName = "UserToken"; //cookie name 


        public void AddCurrent(HttpContext httpContext, string token)
        {
            CookieHelper.WriteCookie(httpContext, TokenName, token);
        }

        /// <summary>
        /// Api接口需要传入apiToken
        /// </summary>
        /// <param name="apiToken"></param>
        public void RemoveCurrent(HttpContext httpContext)
        {

            CookieHelper.RemoveCookie(httpContext, TokenName);
        }



        public async Task<OperatorInfo> Current(HttpContext httpContext)
        {

            var _IUserEntityRepository = httpContext.RequestServices.GetService<IUserEntityServices>();       
            //  httpContext.RequestServices.GetService<IUserEntityServices>();

            OperatorInfo user = null;
            string token = string.Empty;


            token = CookieHelper.GetCookie(httpContext, TokenName);



            if (string.IsNullOrEmpty(token))
            {
                return user;
            }
            token = token.Trim('"');
            user = CacheFactory.Cache.GetCache<OperatorInfo>(token);
            if (user == null)
            {
                user = await _IUserEntityRepository.GetUserByToken(token);
                if (user != null)
                {
                    CacheFactory.Cache.SetCache(token, user);
                }
            }
            return user;
        }
    }
}
