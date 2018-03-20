using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  cBaseQMS.Core.DAL.Models;
using cBaseQms.Core.Repositry.Infrastructure;

namespace cBaseQms.Core.Repositry.Repositories
{
    public interface IEquationRepositry : IRepository<Equation>
    {

    }
    public class EquationRepositry : RepositoryBase<Equation>, IEquationRepositry
    {
        public EquationRepositry(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
