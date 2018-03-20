using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  cBaseQMS.Core.DAL.Models;
using cBaseQms.Core.Repositry.Infrastructure;

namespace cBaseQms.Core.Repositry.Repositories
{
    public interface IComponentRepositry : IRepository<Component>
    {

    }

    public class ComponentRepositry : RepositoryBase<Component>, IComponentRepositry
    {
        public ComponentRepositry(IDbFactory dbFactory) : base(dbFactory) { }

    }
}
