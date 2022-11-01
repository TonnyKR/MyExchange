using System;
using System.Collections.Generic;

namespace MyExchange.Data.Entities
{
    public partial class Currency : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public decimal PriceUsd { get; set; }
        public string MarketType { get; set; } = null!;
        public ICollection<WalletPosition> WalletPositions { get; set; }
        public ICollection<PromoCode> PromoCodes { get; set; }
    }
}
