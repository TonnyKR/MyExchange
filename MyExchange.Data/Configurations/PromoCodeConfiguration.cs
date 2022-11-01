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
    internal class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
    {

        public void Configure(EntityTypeBuilder<PromoCode> builder)
        {
            builder.HasKey(b => b.Id).HasName("PromoCodeId");
            
        }
    }
}
