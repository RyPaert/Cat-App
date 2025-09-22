using Microsoft.EntityFrameworkCore;
using Catblog.Models;

namespace Catblog.Data
{
    public class AdminCatContext : DbContext
    {
        public AdminCatContext(DbContextOptions<AdminCatContext> options) : base(options) { }
        public DbSet<AdminCat> adminCats { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AdminCat>().ToTable("AdminCat");
        //}
    }
}
