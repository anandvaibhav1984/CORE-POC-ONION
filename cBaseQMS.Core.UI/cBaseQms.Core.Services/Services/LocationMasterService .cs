using AutoMapper;
using cBaseQms.Core.Repositry.Infrastructure;
using cBaseQms.Core.Repositry.Repositories;
using cBaseQms.Core.Services.Models;
using cBaseQMS.Core.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace cBaseQms.Core.Services.Services
{
    // operations you want to expose
    public interface ILocationMasterService
    {
        IEnumerable<LocationMasterViewModel> GetAllLocations();
       
    }
    public class LocationMasterService : ILocationMasterService
    {
        private readonly ILocationMasterRepositry locationMasterRepositry;        
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _iMapper;



        public LocationMasterService(ILocationMasterRepositry locationMasterRepositry, IUnitOfWork unitOfWork, IMapper _iMapper)
        {   
            this.locationMasterRepositry = locationMasterRepositry;
            this.unitOfWork = unitOfWork;
            this._iMapper = _iMapper;

        }
        public IEnumerable<LocationMasterViewModel> GetAllLocations()
        {
            List<LocationMasterViewModel> locationMasterViewModel;
            List<LocationMaster> locationMaster;

            locationMaster= locationMasterRepositry.GetAll().ToList();
            locationMasterViewModel = _iMapper.Map<List<LocationMaster>, List<LocationMasterViewModel>>(locationMaster);
            return locationMasterViewModel;
        }


    }
}
