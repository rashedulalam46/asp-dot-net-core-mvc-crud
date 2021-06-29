using ASP.NET_Core_MVC_Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_MVC_Crud.Services
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }
       

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customers>().HasKey(p => new { p.CustomerID });            
        //}

    }
}
