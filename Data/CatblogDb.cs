using Catblog.Domain;
using Microsoft.EntityFrameworkCore;

namespace Catblog.Data
{
    public class CatblogDb : DbContext
    {
        public CatblogDb(DbContextOptions<CatblogDb> options): base(options) 
        {

        }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
    }
}
