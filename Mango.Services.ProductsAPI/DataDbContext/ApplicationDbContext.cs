using Mango.Services.ProductsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductsAPI.DataDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
