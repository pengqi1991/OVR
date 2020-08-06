using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OVR.IServices;
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

        public async Task<IActionResult> Index()
        {
            var t1 = await advertisementServices.ReadAllAd();
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
