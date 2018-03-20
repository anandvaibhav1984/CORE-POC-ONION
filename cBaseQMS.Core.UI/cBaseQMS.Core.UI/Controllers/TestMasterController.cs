using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cBaseQMS.Areas.cBaseQMS.RestController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cBaseQMS.Core.UI.Controllers
{
    public class TestMasterController : Controller
    {

        private readonly ITestMasterClient _iTestMaserClient;

        public TestMasterController(ITestMasterClient iTestMaserClient)
        {

            this._iTestMaserClient = iTestMaserClient;
            this._iTestMaserClient.ModelState = this.ModelState;
        }

        public IActionResult Index()
        {         
            var testMasterViewmodel = _iTestMaserClient.GetAll().ToList();
            return View(testMasterViewmodel);
            //return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}