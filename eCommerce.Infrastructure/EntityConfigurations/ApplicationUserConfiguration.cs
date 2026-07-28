using eCommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Infrastructure.EntityConfigurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Password)
               .HasMaxLength(30)
               .IsRequired();

            builder.Property(x => x.PersonName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Gender)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
