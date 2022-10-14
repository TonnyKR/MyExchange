using System;
using System.Collections.Generic;

namespace MyExchange.Domain.Entities
{
    public partial class WalletPosition : BaseEntity
    {
        public decimal Quantity { get; set; }
        public decimal EntryPrice { get; set; }
        public decimal? ClosePrice { get; set; }
        public decimal CurrentMargin { get; set; }
        public decimal? ClosedMargin { get; set; }
        public int WalletId { get; set; }
        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; } = null!;
        public virtual Wallet Wallet { get; set; } = null!;
    }
}
