using System;
using Jacaranda.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.Context
{
    public class OrderEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.UserId)
                    .IsRequired();

                entity.HasMany<Plant>(e => e.Plants)
                   .WithOne(e => e.Order);

                entity.HasMany<Payment>(e => e.Payments)
                    .WithOne(e => e.Order);

                entity.HasOne<User>(e => e.User)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.UserId);

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.UpdatedAt)
                    .IsRequired();

                entity.Property(e => e.Deleted)
                    .IsRequired().HasDefaultValue(false);
            });
        }
    }
}

