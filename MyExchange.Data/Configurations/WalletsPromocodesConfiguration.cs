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
    public class WalletsPromocodesConfiguration : IEntityTypeConfiguration<WalletsPromoCodes>
    {
        public void Configure(EntityTypeBuilder<WalletsPromoCodes> builder)
        {
            builder.HasKey(x => x.Id).HasName("WalletsPromoCodesId");
            builder.HasOne(x => x.PromoCode).WithMany(x => x.WalletsPromoCodes).HasForeignKey(x => x.PromoCodeId);
            builder.HasOne(x => x.Wallet).WithMany(x => x.WalletsPromoCodes).HasForeignKey(x =>x.WalletId);
        }
    }
}
