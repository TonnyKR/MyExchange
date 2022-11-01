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
    internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(c => c.Id).HasName("CurrencyId");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.PriceUsd).IsRequired().HasColumnType("decimal(38,19)");
            builder.Property(c=> c.ShortName).IsRequired().HasMaxLength(10);
            builder.Property(c => c.MarketType).IsRequired().HasMaxLength(10);
            builder.HasMany(w => w.WalletPositions).WithOne(c => c.Currency);
            builder.HasMany(p => p.PromoCodes).WithOne(c => c.Currency);
        }
    }
}
