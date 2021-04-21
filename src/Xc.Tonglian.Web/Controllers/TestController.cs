using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Services;

namespace Xc.Tonglian.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly IShopService _shopService;
        public TestController(IShopService shopService)
        {
            _shopService = shopService;
        }
        public IActionResult Index()
        {
            //var res = _shopService.GetShopList();

            return View();
        }
    }
}
