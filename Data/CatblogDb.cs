using Catblog.Models.Accounts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Catblog.Data
{
	public class CatblogDb : IdentityDbContext<User>
	{
		public CatblogDb(DbContextOptions<CatblogDb> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
	}
}
