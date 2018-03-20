using cBaseQms.Core.Repositry.Infrastructure;
using cBaseQms.Core.Services.Models;
using cBaseQms.Core.Services.Services;
//using cBaseQMS.Api.Caching;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cBaseQms.Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestMasterApiController : Controller
    {
        

        private readonly ITestMasterService iTestMasterService;
        //private readonly IPartMasterService iPartMasterService;
        //private readonly ILocationMasterService iLocationMasterService;
        //private readonly ITestMasterMappingService itestMasterMappingService;
        //private readonly ICacheService cache;

        //public TestMasterApiController(IUnitOfWork iunit, ITestMasterService iTestMasterService, 
        //    IPartMasterService iPartMasterService, ILocationMasterService iLocationMasterService, ITestMasterMappingService itestMasterMappingService)
        //{
        //    this.itestMasterMappingService = itestMasterMappingService;
        //    this.iLocationMasterService = iLocationMasterService;
        //    this.iPartMasterService = iPartMasterService;
        //    this.iTestMasterService = iTestMasterService;
           


        //}
        public TestMasterApiController( ITestMasterService iTestMasterService )      {
         
           
            this.iTestMasterService = iTestMasterService;


        }

        [Route("GetAllTestMaster")]
        [HttpGet]
        public IActionResult Get()
        {

            IEnumerable<TestMasterViewModel> testMasterViewModel;           
            testMasterViewModel =iTestMasterService.GetMasterTests().ToList();           
            return new  ObjectResult(testMasterViewModel);

        }

        //[Route("GetAllTestMasterByTest")]
        //public IActionResult GetAllTestMasterByTest(int testid,string redirect )
        //{

        //    IEnumerable<usp_GetTestMasterByTestIdViewModel> testMasterViewModel;
        //    testMasterViewModel = cache.GetOrSet("GetAllTestMasterByTest", () => iTestMasterService.GetTestMasterByTestId(testid),bool.Parse(redirect));
        //    return new  ObjectResult(testMasterViewModel);

        //}


        [HttpPost]
        [Route("AddTestMaster")]
        public IActionResult AddTestMaster([FromBody]TestMasterViewModel testMasterViewModel)
        {
            
            iTestMasterService.CreateTestMaster(testMasterViewModel);
            iTestMasterService.SaveTestMaster();
            return new  OkResult();
        }

        //[Route("GetAllPartMaster")]
        //public IActionResult GetAllPartMaster()
        //{
        //    IEnumerable<PartMasterViewModel> partMasterViewModel;
        //    partMasterViewModel = cache.GetOrSet("GetAllPartMaster", ()=>iPartMasterService.GetAllParts().ToList());
        //    return new  ObjectResult(partMasterViewModel);

        //}

        //[Route("GetAllLocationMaster")]
        //public IActionResult GetAllLocationMaster()
        //{
        //    List<LocationMasterViewModel> locationMasterViewModel;
        //    locationMasterViewModel =cache.GetOrSet("GetAllLocationMaster", ()=> iLocationMasterService.GetAllLocations().ToList());
        //    return new  ObjectResult(locationMasterViewModel);
        //}


        //[Route("GetAllLocationAndPartMasterMapping")]
        //public IActionResult GetAllLocationAndPartMasterMapping(int testMasterid,string redirect)
        //{
        //    List<Usp_GetLocationAndPartMappingViewModel> objgetAllLocationAndPartMasterMapping;
        //    objgetAllLocationAndPartMasterMapping = cache.GetOrSet("GetAllLocationAndPartMasterMapping",()=> itestMasterMappingService.GetAllLocationAndPartMasterMapping(testMasterid),bool.Parse(redirect)).ToList();
        //    return new  ObjectResult(objgetAllLocationAndPartMasterMapping);
        //}

        //[Route("ifExistsLocationAndPartMapping")]
        //public IActionResult ifExistsLocationAndPartMapping(TestMasterMappingViewModel testMasterMappingViewModel)
        //{   
        //    return new  ObjectResult();
        //}

        //[Route("CreateTestMasterMapping")]
        //public IActionResult CreateTestMasterMapping(TestMasterMappingViewModel testMasterMappingViewModel)
        //{
        //    itestMasterMappingService.CreateTestMasterMapping(testMasterMappingViewModel);
        //    itestMasterMappingService.SaveTest();
        //    return new  OkResult();
        //}

        //[Route("RemovePartAndLocation")]
        //public IActionResult RemovePartAndLocation(TestMasterMappingViewModel testMasterMappingViewModel)
        //{
        //    itestMasterMappingService.RemovePartAndLocationMapping(testMasterMappingViewModel);
        //    itestMasterMappingService.SaveTest();
        //    return new  OkResult();
        //}


        //[HttpPost]
        //[Route("UpdateTestMaster")]
        //public IActionResult UpdateTestMaster(TestMasterViewModel testMasterViewModel)
        //{
        //    iTestMasterService.UpdateTestMaster(testMasterViewModel);
        //    iTestMasterService.SaveTestMaster();
        //    return new  ObjectResult();

        //}


    }
}
