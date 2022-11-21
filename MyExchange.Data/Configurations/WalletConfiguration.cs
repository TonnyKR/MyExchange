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
    internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(x => x.Id).HasName("WalletId");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Balance).HasColumnType("decimal(38,19)");
            builder.Property(x => x.TotalEnrolment).HasColumnType("decimal(38,19)");
            builder.Property(x => x.TotalWithdrawl).HasColumnType("decimal(38,19)");
            builder.Property(x => x.TotalCurrentMargin).HasColumnType("decimal(38,19)");
            builder.Property(x => x.TotalPositionsCost).HasColumnType("decimal(38,19)");
            
        }
    }
}
