using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using MyExchange.Domain.Entities;
using MyExchange.Data.Configurations;

namespace MyExchange.Data
{
    public class MyExchangeContext : DbContext
    {
        public MyExchangeContext()
        {
        }

        public MyExchangeContext(DbContextOptions<MyExchangeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankCard> BankCards { get; set; } = null!;
        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Wallet> Wallets { get; set; } = null!;
        public virtual DbSet<WalletPosition> WalletPositions { get; set; } = null!;
        public virtual DbSet<WalletBalance> WalletBalance { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //???
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(CurrencyConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
