using cBaseQms.Core.Repositry.Infrastructure;

namespace cBaseQms.Core.Repositry.Repositories
{
    public interface IVWLocationAttributesRepository : IRepository<vWLocationAttribute>
    {

    }
    public class VWLocationAttributesRepository : RepositoryBase<vWLocationAttribute>, IVWLocationAttributesRepository
    {
        public VWLocationAttributesRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
