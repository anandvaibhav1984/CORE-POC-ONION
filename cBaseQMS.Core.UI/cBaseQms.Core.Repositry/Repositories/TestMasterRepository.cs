using cBaseQMS.Core.DAL.Models;
using cBaseQms.Core.Repositry.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cBaseQms.Core.Repositry.Repositories
{
    public class TestMasterRepository : RepositoryBase<TestMaster>, ITestMasterRepository
    {

        public TestMasterRepository(cBaseDevEntities dataContext) : base(dataContext)
        {

        }

        public TestMaster GetTestMasterByName(string name)
        {
            var testMaster = this.DbContext.TestMaster.Where(x => x.TestMasterName == name).FirstOrDefault();
            return testMaster;
        }


        public bool GetCountTestMasterByName(string name)
        {
            bool result;
            result = this.DbContext.TestMaster.Where(x => x.TestMasterName == name).Count()>0;
            return !result;
        }

        public override void Update(TestMaster entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Update(entity);
        }

      
    }

    public interface ITestMasterRepository : IRepository<TestMaster>
    {
        TestMaster GetTestMasterByName(string name);
        bool GetCountTestMasterByName(string name);
       
    }
}