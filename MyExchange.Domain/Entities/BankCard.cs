using System;
using System.Collections.Generic;

namespace MyExchange.Domain.Entities
{
    public partial class BankCard : BaseEntity
    {
        public long Number { get; set; }
        public DateTime TerminalDate { get; set; }
        public int Cvv { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
