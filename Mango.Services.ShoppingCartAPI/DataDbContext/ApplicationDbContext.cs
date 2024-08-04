using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShoppingCartAPI.DataDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

       
    }
}
