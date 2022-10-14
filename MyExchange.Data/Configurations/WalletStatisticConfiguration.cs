using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyExchange.Domain.Entities;


namespace MyExchange.Data.Configurations
{
    internal class WalletStatisticConfiguration : IEntityTypeConfiguration<WalletStatistic>
    {

        public void Configure(EntityTypeBuilder<WalletStatistic> builder)
        {
            builder.HasKey(x => x.Id).HasName("WalletStatisticId");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TotalCurrentCapital).HasColumnType("decimal(38,19)").HasDefaultValue(0);
            builder.Property(x => x.TotalAmoundEnrollment).HasColumnType("decimal(38,19)").HasDefaultValue(0);
            builder.Property(x => x.TotalAmoundWithdrawl).HasColumnType("decimal(38,19)").HasDefaultValue(0);
            builder.Property(x => x.TotalCurrentMargin).HasColumnType("decimal(38,19)").HasDefaultValue(0);
            builder.Property(x => x.TotalClosedMargin).HasColumnType("decimal(38,19)").HasDefaultValue(0);
        }
    }
}
