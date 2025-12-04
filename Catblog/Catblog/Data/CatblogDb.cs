using Catblog.Models.Accounts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
﻿using Catblog.Domain;
using Microsoft.EntityFrameworkCore;
using Catblog.Models.Comments;

namespace Catblog.Data
{
	public class CatblogDb : IdentityDbContext<User>
	{
		public CatblogDb(DbContextOptions<CatblogDb> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
		public DbSet<Comment> Comments { get; set; }
    }
}
