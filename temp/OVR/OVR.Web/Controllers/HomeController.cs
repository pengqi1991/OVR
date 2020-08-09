using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OVR.IServices;
using OVR.Model;
using OVR.Model.Auth;
using OVR.Model.Base;
using OVR.Web.Auth;
using OVR.Web.Filter;
using OVR.Web.Models;

namespace OVR.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdvertisementServices advertisementServices;

        public HomeController(ILogger<HomeController> logger, IAdvertisementServices advertisementServices)
        {
            _logger = logger;
            this.advertisementServices = advertisementServices;
        }
        [HttpGet]
        [AuthorizeFilter]
        public async Task<IActionResult> Index()
        {
            //OperatorInfo operatorInfo = await Operator.Instance.Current();

            //TData<List<MenuEntity>> objMenu = await menuBLL.GetList(null);
            //List<MenuEntity> menuList = objMenu.Data;
            //menuList = menuList.Where(p => p.MenuStatus == StatusEnum.Yes.ParseToInt()).ToList();

            //if (operatorInfo.IsSystem != 1)
            //{
            //    TData<List<MenuAuthorizeInfo>> objMenuAuthorize = await menuAuthorizeBLL.GetAuthorizeList(operatorInfo);
            //    List<long?> authorizeMenuIdList = objMenuAuthorize.Data.Select(p => p.MenuId).ToList();
            //    menuList = menuList.Where(p => authorizeMenuIdList.Contains(p.Id)).ToList();
            //}

            //ViewBag.MenuList = menuList;
            //ViewBag.OperatorInfo = operatorInfo;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
