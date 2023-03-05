using System;
using Jacaranda.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.Context
{
    public class MailVerificationEntity
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailVerification>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne<User>(e => e.User)
                   .WithMany(x => x.MailVerifications)
                   .HasForeignKey(x => x.UserId);

                entity.Property(e => e.ActivatedAt)
                   .HasDefaultValue(null);

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.UpdatedAt)
                    .IsRequired();

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasDefaultValue(false);
            });
        }
    }
}

