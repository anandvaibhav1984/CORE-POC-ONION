using  cBaseQMS.Core.DAL.Models;
using cBaseQms.Core.Repositry.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cBaseQms.Core.Repositry.Repositories
{
    public class LocationMasterRepositry : RepositoryBase<LocationMaster>, ILocationMasterRepositry
    {
        public LocationMasterRepositry(IDbFactory dbFactory) : base(dbFactory) { }
       
    }

    public interface ILocationMasterRepositry : IRepository<LocationMaster>
    {
      
    }
}
