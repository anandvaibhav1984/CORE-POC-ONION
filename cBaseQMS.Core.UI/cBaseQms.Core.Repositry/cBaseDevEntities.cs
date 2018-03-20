using cBaseQMS.Core.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace cBaseQms.Core.Repositry
{
   public class cBaseDevEntities: cBaseDevContext
    {
        public cBaseDevEntities(DbContextOptions options) : base(options)
        {
        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
