using Microsoft.EntityFrameworkCore;

namespace Catblog.Data
{
    public class AdminCatContext : DbContext
    {
        public AdminCatContext(DbContextOptions<AdminCatContext> options): base(options) { }
        public DbSet<>
        
    }
}
