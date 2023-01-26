using System;
using System.Security.Policy;
using Jacaranda.Domain.Model;
using Jacaranda.Model;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.Context
{
	public class DatabaseContext: DbContext
    {

        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<User> User { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AdministratorEntity.Configure(modelBuilder);
            UserEntity.Configure(modelBuilder);
        }
    }
}

