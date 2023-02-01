using System;
using Jacaranda.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.Context
{
    public class CertificateEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CertificateId)
                    .IsRequired()
                    .HasMaxLength(13);

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

