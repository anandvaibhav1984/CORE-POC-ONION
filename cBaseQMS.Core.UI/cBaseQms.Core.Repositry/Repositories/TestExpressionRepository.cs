using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  cBaseQMS.Core.DAL.Models;
using cBaseQms.Core.Repositry.Infrastructure;

namespace cBaseQms.Core.Repositry.Repositories
{
    public class TestExpressionRepository : RepositoryBase<TestExpressionRepository>, ITestExpressionRepository
    {
        public TestExpressionRepository(IDbFactory dbFactory) : base(dbFactory) { }
        
    }
    public interface ITestExpressionRepository : IRepository<TestExpressionRepository>
    {
        
    }
}
