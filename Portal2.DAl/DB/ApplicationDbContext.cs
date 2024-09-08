using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal2.DAl.Entities;
using Portal2.DAL.Entities;

namespace Portal2.DAl.DB
{
    public class ApplicationDbContext: IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-R2OBI1A;Database=PortalITI2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        //}

    }
}
