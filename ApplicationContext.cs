using Microsoft.EntityFrameworkCore;

namespace batch15webAPI
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
