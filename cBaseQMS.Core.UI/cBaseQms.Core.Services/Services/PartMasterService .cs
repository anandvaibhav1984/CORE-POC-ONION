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
    public interface IPartMasterService
    {
        IEnumerable<PartMasterViewModel> GetAllParts();
        
    }
    public class PartMasterService : IPartMasterService
    {
        private readonly IPartMasterRepositry partMasterRepositry;
        private readonly IMapper _iMapper;


        public PartMasterService(IPartMasterRepositry partMasterRepositry, IMapper _iMapper)
        {   
            this.partMasterRepositry = partMasterRepositry;
            this._iMapper = _iMapper;

        }
        public IEnumerable<PartMasterViewModel> GetAllParts()
        {
            IEnumerable<PartMasterViewModel> partMasterViewModel;
            IEnumerable<PartMaster> testMaster;
            testMaster= partMasterRepositry.GetAll().ToList();
            partMasterViewModel = _iMapper.Map<IEnumerable<PartMaster>, IEnumerable<PartMasterViewModel>>(testMaster);
            return partMasterViewModel;
        }

        
    }
}
