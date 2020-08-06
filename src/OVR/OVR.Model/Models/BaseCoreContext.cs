using Microsoft.EntityFrameworkCore;
using OVR.Model.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OVR.Model.Models
{
    public partial class BaseCoreContext : DbContext, IBaseContext
    {

        public  DbSet<Advertisement> Advertisement { get; set; }
       

        public BaseCoreContext(DbContextOptions<BaseCoreContext> options)
            : base(options)
        {
        }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
