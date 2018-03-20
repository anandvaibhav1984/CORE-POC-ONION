
using cBaseQms.Core.Repositry.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cBaseQMS.Core.DAL.Models;

namespace cBaseQms.Core.Repositry.Repositories
{
  public  class TestRepositry : RepositoryBase<Tests>, ITestRepository
    {
        public TestRepositry(IDbFactory dbFactory) : base(dbFactory) { }

        public Tests GetTests(string name)
        {
            throw new NotImplementedException();
        }
        public bool ifExistsTestName(string testname,int testmasterid)
        {
            bool result;           
            result=this.DbContext.Tests.Where(x => x.TestName == testname && x.TestMasterId == testmasterid).Count() > 0;
            return !result;
          
        }
    }

    public interface ITestRepository : IRepository<Tests>
    {
        Tests GetTests(string name);
        bool ifExistsTestName(string testname, int testmasterid);
    }
}
