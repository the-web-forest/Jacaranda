using System;
using System.Security.Policy;
using Jacaranda.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Jacaranda.Context
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Certificate> Certificate { get; set; }
        public DbSet<MailVerification> MailVerification { get; set; }
        public DbSet<Biome> Biome { get; set; }
        public DbSet<Tree> Tree { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Plant> Plant { get; set; }
        public DbSet<PlantTag> PlantTag { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<PasswordReset> PasswordReset { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AdministratorEntity.Configure(modelBuilder);
            UserEntity.Configure(modelBuilder);
            CertificateEntity.Configure(modelBuilder);
            MailVerificationEntity.Configure(modelBuilder);
            BiomeEntity.Configure(modelBuilder);
            PartnerEntity.Configure(modelBuilder);
            CityEntity.Configure(modelBuilder);
            StateEntity.Configure(modelBuilder);
            PlantEntity.Configure(modelBuilder);
            PlantTagEntity.Configure(modelBuilder);
            PaymentEntity.Configure(modelBuilder);
            OrderEntity.Configure(modelBuilder);
            PasswordResetEntity.Configure(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
    }

    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            // Colocar Connection String Aqui Para Migrations
            optionsBuilder.UseMySQL();

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}

