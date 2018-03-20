
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cBaseQms.Core.Repositry.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        cBaseDevEntities dbContext;
        DbContextOptions dbContextOptions;
        //public DbFactory(DbContextOptions dbContextOptions)
        //{
        //    this.dbContextOptions = dbContextOptions;
        //}

        public cBaseDevEntities Init()
        {
            return dbContext ?? (dbContext = new cBaseDevEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
