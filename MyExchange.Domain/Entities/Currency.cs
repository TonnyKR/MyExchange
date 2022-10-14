using System;
using System.Collections.Generic;

namespace MyExchange.Domain.Entities
{
    public partial class Currency : BaseEntity
    {
        public Currency()
        {
            WalletPositions = new List<WalletPosition>();
        }

        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public decimal PriceUsd { get; set; }
        public string MarketType { get; set; } = null!;

        public virtual List<WalletPosition> WalletPositions { get; set; }
    }
}
