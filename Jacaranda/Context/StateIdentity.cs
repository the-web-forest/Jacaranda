using System;
using Jacaranda.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.Context
{
    public class StateEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasMany<City>(x => x.Cities);

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

