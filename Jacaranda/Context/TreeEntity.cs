using System;
using Jacaranda.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.Context
{
    public class TreeEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tree>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.BiomeId)
                      .IsRequired();

                entity.HasOne<Biome>(e => e.Biome)
                    .WithMany(x => x.Trees)
                    .HasForeignKey(x => x.BiomeId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .IsRequired();

                entity.Property(e => e.Image)
                    .IsRequired();

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

