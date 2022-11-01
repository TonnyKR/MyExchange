using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Data.Configurations
{
    internal class BankCardConfiguration : IEntityTypeConfiguration<BankCard>
    {
        public void Configure(EntityTypeBuilder<BankCard> builder)
        {
            builder.HasKey(b => b.Id).HasName("BankCardId");
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Cvv).IsRequired().HasMaxLength(3);
            builder.Property(b => b.TerminalDate).IsRequired();
            builder.Property(b => b.Number).IsRequired().HasMaxLength(16);
            builder.HasOne(d => d.Wallet).WithMany(p => p.BankCards).HasForeignKey(d => d.WalletId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Bank).WithMany(p => p.BankCards).HasForeignKey(d => d.BankId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
