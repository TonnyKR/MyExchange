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
    internal class WalletPositionConfiguration : IEntityTypeConfiguration<WalletPosition>
    {
        public void Configure(EntityTypeBuilder<WalletPosition> builder)
        {
            builder.HasKey(x => x.Id).HasName("WalletPositionId");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity).HasColumnType("decimal(38,19)").IsRequired();
            builder.Property(x => x.EntryPrice).HasColumnType("decimal(38,19)").IsRequired();
            builder.Property(x => x.ClosePrice).HasColumnType("decimal(38,19)");
            builder.Property(x => x.CurrentMargin).HasColumnType("decimal(38,19)").HasDefaultValue(0);
            builder.Property(x => x.ClosedMargin).HasColumnType("decimal(38,19)");
            builder.HasOne(w => w.Wallet).WithMany(wp => wp.WalletPositions).HasForeignKey(w => w.WalletId);
            builder.HasOne(c => c.Currency).WithMany(wp => wp.WalletPositions).HasForeignKey(w => w.CurrencyId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
