using System;
using Jacaranda.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.Context
{
    public class PlantEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Message)
                   .IsRequired()
                   .HasMaxLength(255);

                entity.Property(e => e.Value)
                   .IsRequired();

                entity.Property(e => e.UserId)
                   .IsRequired();

                entity.Property(e => e.TreeId)
                   .IsRequired();

                entity.HasOne<User>(e => e.User)
                    .WithMany(x => x.Plants)
                    .HasForeignKey(x => x.UserId);

                entity.HasOne<Tree>(e => e.Tree)
                    .WithMany(x => x.Plants)
                    .HasForeignKey(x => x.TreeId);

                entity.HasOne<Partner>(e => e.Partner)
                    .WithMany(x => x.Plants)
                    .HasForeignKey(x => x.PartnerId);

                entity.HasMany<PlantTag>(e => e.Tags)
                    .WithOne(e => e.Plant);

                entity.Property(e => e.Value)
                    .IsRequired();

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

