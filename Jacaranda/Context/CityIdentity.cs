using System;
using Jacaranda.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.Context
{
    public class UserEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StateId)
                    .IsRequired();

                entity.HasOne<State>(e => e.State)
                   .WithMany(x => x.Cities)
                   .HasForeignKey(x => x.StateId);

                entity.HasMany<User>(e => e.Users);

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

