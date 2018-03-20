using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  cBaseQMS.Core.DAL.Models;
using cBaseQms.Core.Repositry.Infrastructure;

namespace cBaseQms.Core.Repositry.Repositories
{
    public interface ITestInputFieldsRepositry : IRepository<InputField>
    {

    }
    public class TestInputFieldsRepositry : RepositoryBase<InputField>, ITestInputFieldsRepositry
    {
        public TestInputFieldsRepositry(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
