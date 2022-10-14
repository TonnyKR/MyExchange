using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyExchange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Data.Configurations
{
    internal class WalletBalanceConfiguration : IEntityTypeConfiguration<WalletBalance>
    {
        public void Configure(EntityTypeBuilder<WalletBalance> builder)
        {
            builder.HasKey(x => x.Id).HasName("WalletBalanceId");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.USD).HasColumnType("decimal(38,19)").HasDefaultValue(0);
            builder.Property(x => x.UAH).HasColumnType("decimal(38,19)").HasDefaultValue(0);
        }
    }
}
