using Microsoft.EntityFrameworkCore;
using Catblog.Models;
using Catblog.Domain;

namespace Catblog.Data
{
    public class AdminCatContext : DbContext
    {
        public AdminCatContext(DbContextOptions<AdminCatContext> options) : base(options) { }
        public DbSet<Kitty> Kittys { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AdminCat>().ToTable("AdminCat");
        //}
    }
}
