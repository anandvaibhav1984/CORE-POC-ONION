using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  cBaseQMS.Core.DAL.Models;
using cBaseQms.Core.Repositry.Infrastructure;

namespace cBaseQms.Core.Repositry.Repositories
{
    public interface IPartAttributesRepository : IRepository<PartAttributes>
    {

    }
    public class PartAttributesRepository : RepositoryBase<PartAttributes>, IPartAttributesRepository
    {
        public PartAttributesRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
