using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly ISysMenuService sysMenuService;
        private readonly IUserLoginService userLoginService;
        private readonly IUserMenuService userMenuService;

        public HomeController(ILogger<HomeController> logger,ISysMenuService sysMenuService,IUserLoginService userLoginService,IUserMenuService userMenuService)
        {
            _logger = logger;
            this.sysMenuService = sysMenuService;
            this.userLoginService = userLoginService;
            this.userMenuService = userMenuService;
        }
        [AuthorizeFilter]
        public async Task<IActionResult> Index()
        {
            UserLogin user =  JsonConvert.DeserializeObject<UserLogin>(GetCookies(CommonData.TokenName));
            IList<SysMenu> sysMenus = await sysMenuService.GetAll();
            if (!user.isSuperAdmin)
            {
                List<long> authorizeMenuIdList = await userMenuService.GetUserMenuIdList(user);
                sysMenus = sysMenus.Where(p => authorizeMenuIdList.Contains(p.Id)).ToList();
            }
            ViewBag.MenuList = sysMenus;
            ViewBag.UserLogin = user;
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
        [HttpGet]
        public IActionResult Welcome()
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
                HttpContext?.Response.Cookies.Append(CommonData.TokenName, userObj.Data.ToJsonString(), option);
            }

            return Json(userObj);
        }
        #endregion

        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>返回对应的值</returns>
        protected string GetCookies(string key)
        {
            HttpContext.Request.Cookies.TryGetValue(key, out string value);
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
