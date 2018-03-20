using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cBaseQMS.Core.UI.Models;
using cBaseQMS.Areas.cBaseQMS.RestController;

namespace cBaseQMS.Core.UI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ITestMasterClient _iTestMaserClient;
        //public HomeController(ITestMasterClient iTestMaserClient)
        //{
        //    //this._iTestMaserClient = iTestMaserClient;
        //    //this._iTestMaserClient.ModelState = this.ModelState;
        //}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
