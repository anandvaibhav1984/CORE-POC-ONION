using System;

namespace cBaseQms.Core.Repositry.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        cBaseDevEntities Init();
    }
}