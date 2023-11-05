using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebCMSTraining.Models.DB;
using WebCMSTraining.Helper;
using Microsoft.AspNetCore.Identity;

namespace WebCMSTraining.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.SuperAdmin();
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        //public virtual DbSet<SuperAdmin> SuperAdmins { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<DetailOrder> DetailOrders { get; set; }
    }
}
