using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCMSTraining.Models.DB;

namespace WebCMSTraining.Helper
{
    public static class SeedData
    {
        public static void SuperAdmin(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperAdmin>().HasData(
                
                new SuperAdmin { 
                    
                    Id = 1, 
                    Email = "admin@weekendinc.com", 
                    Password = "admin12345" 
                });
        }
    }
}
