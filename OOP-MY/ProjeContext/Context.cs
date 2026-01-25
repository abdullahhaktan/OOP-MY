using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OOP_MY.Entities;

namespace OOP_MY.ProjeContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ABDULLAH;database=DbNewOopCore;integrated security=true;Encrypt=False;");
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers
        { get; set; }
        
        public DbSet<Category> Categories { get; set; }


    }
}
