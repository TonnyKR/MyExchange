using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;

namespace MyExchange.Data.Entities
{
    public partial class BankCard : BaseEntity
    {
        public long Number { get; set; }
        public DateTime TerminalDate { get; set; }
        public int Cvv { get; set; }
        public int WalletId { get; set; }

        public Wallet Wallet { get; set; } = null!;
        public int BankId { get; set; }

        public Bank Bank { get; set; } = null!;
    }
}
