using Microsoft.EntityFrameworkCore;
using Catblog.Domain;


namespace Catblog.Data
{
    public class AdminCatContext : DbContext
    {
        public AdminCatContext(DbContextOptions<AdminCatContext> options) : base(options) { }
        public DbSet<Kitty> Kitties { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kitty>().ToTable("Kitty");
            modelBuilder.Entity<FileToDatabase>().ToTable("FileToDatabase");
        }
    }
}
