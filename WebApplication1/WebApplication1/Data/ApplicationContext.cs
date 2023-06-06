using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Variant> Variants { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
