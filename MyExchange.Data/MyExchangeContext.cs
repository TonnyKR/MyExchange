using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using MyExchange.Data.Entities;
using MyExchange.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MyExchange.Data
{
    public class MyExchangeContext : IdentityDbContext<User, IdentityRole, string>
    {
        public MyExchangeContext()
        {
        }

        public MyExchangeContext(DbContextOptions<MyExchangeContext> options)
            : base(options)
        {
        }

        public DbSet<Bank> Bank { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Wallet> Wallets { get; set; } = null!;
        public DbSet<WalletPosition> WalletPositions { get; set; }
        public DbSet<WalletsPromoCodes> WalletsPromoCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(ConfigurationsAssemblyMarker).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
