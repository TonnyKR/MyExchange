using System;
using System.Collections.Generic;

namespace MyExchange.Domain.Entities
{
    public partial class Wallet : BaseEntity
    {
        public Wallet()
        {
            WalletPositions = new List<WalletPosition>();
            WalletStatistic = new WalletStatistic();
        }

        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual List<WalletPosition> WalletPositions { get; set; }
        public virtual WalletStatistic WalletStatistic { get; set; }
        public virtual WalletBalance WalletBalance { get; set; }
    }
}
