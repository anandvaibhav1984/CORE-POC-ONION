using  cBaseQMS.Core.DAL.Models;
using cBaseQms.Core.Repositry.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cBaseQms.Core.Repositry.Repositories
{
  public  class TestMasterMappingRepositry : RepositoryBase<TestMasterMapping>, ITestMasterMappingRepositry
    {
       

        public TestMasterMappingRepositry(IDbFactory dbFactory) : base(dbFactory) { }

        public Tests GetTestMasterMapping(int testMasterId)
        {
            throw new NotImplementedException();
        }

        public bool IfExistsPartAndLocationCombination(int locationId, int partId,int testMasterId)
        {
            
            var count= this.DbContext.TestMasterMapping.Where(p => p.LocationMasterId == locationId && p.PartMasterId== partId && p.TestMasterId==testMasterId).Count();
            return (count == 0);
          
        }
    }

    public interface ITestMasterMappingRepositry : IRepository<TestMasterMapping>
    {
        Tests GetTestMasterMapping(int testMasterId );
      
        bool IfExistsPartAndLocationCombination(int locationId, int partId, int testMasterId);
    }
}
