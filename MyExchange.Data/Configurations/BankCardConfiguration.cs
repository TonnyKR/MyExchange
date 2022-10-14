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
    internal class BankCardConfiguration : IEntityTypeConfiguration<BankCard>
    {
        public void Configure(EntityTypeBuilder<BankCard> builder)
        {
            builder.HasKey(b => b.Id).HasName("BankCardId");
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Cvv).IsRequired().HasMaxLength(3);
            builder.Property(b => b.TerminalDate).IsRequired();
            builder.Property(b => b.Number).IsRequired().HasMaxLength(16);
            builder.HasOne(d => d.User).WithMany(p => p.BankCards).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
