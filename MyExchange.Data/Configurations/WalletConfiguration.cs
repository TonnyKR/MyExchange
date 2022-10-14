using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExchange.Domain.Entities;

namespace MyExchange.Data.Configurations
{
    internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(x => x.Id).HasName("WalletId");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(u => u.User).WithOne(w => w.Wallet).HasForeignKey<Wallet>(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
