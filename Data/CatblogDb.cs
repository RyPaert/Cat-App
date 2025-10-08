using Catblog.Models.Accounts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
﻿using Catblog.Domain;
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
    public class CatblogDb : DbContext
    {
        public CatblogDb(DbContextOptions<CatblogDb> options): base(options) 
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
    }
}
