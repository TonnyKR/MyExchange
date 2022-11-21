using System;
using System.Collections.Generic;

namespace MyExchange.Data.Entities
{
    public partial class WalletPosition : BaseEntity
    {
        public decimal Quantity { get; set; }
        public decimal EntryPrice { get; set; }
        public decimal? CurrentMargin { get; set; }
        public int WalletId { get; set; }
        public int CurrencyId { get; set; }

        public Currency Currency { get; set; } = null!;
        public Wallet Wallet { get; set; } = null!;
    }
}
