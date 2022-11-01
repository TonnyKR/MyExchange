using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using MyExchange.Data.Entities;

namespace MyExchange.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id).HasName("UserId");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(12);
            builder.HasMany(d => d.Wallets).WithOne(p => p.User).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
