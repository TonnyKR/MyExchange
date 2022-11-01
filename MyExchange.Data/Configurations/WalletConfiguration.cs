using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExchange.Data.Entities;

namespace MyExchange.Data.Configurations
{
    internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(x => x.Id).HasName("WalletId");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(u => u.User).WithMany(w => w.Wallets).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.WalletPositions).WithOne(w => w.Wallet);
            builder.HasMany(b => b.BankCards).WithOne(w => w.Wallet);
            builder.HasMany(wp => wp.WalletsPromoCodes).WithOne(w => w.Wallet);
        }
    }
}
