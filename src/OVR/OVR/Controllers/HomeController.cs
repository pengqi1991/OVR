using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OVR.Common;
using OVR.Common.Extensions;
using OVR.Entities;
using OVR.Filters;
using OVR.Models;
using OVR.Services.Login;
using OVR.WebCore.Core;

namespace OVR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserLoginService userLoginService;

        public HomeController(ILogger<HomeController> logger,IUserLoginService userLoginService)
        {
            _logger = logger;
            this.userLoginService = userLoginService;
        }
        [AuthorizeFilter]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


        #region 实现登录
        [HttpPost]
        public async Task<IActionResult> LoginJson(string userName, string password)
        {

            TData<UserLogin> userObj = await userLoginService.CheckLogin(userName, password);
            if (userObj.Tag == 1)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(30);
                HttpContext?.Response.Cookies.Append(CommonData.TokenName, userObj.ToJsonString(), option);
            }

            return Json(userObj);
        }
        #endregion



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
