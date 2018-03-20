using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  cBaseQMS.Core.DAL.Models;
using cBaseQms.Core.Repositry.Infrastructure;

namespace cBaseQms.Core.Repositry.Repositories
{
    public interface ITestCalculatedFieldsRepository : IRepository<TestCalculatedField>
    {

    }
    public class TestCalculatedFieldsRepository : RepositoryBase<TestCalculatedField>, ITestCalculatedFieldsRepository
    {
        public TestCalculatedFieldsRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
