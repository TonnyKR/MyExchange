using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Domain.Entities
{
    public class WalletBalance : BaseEntity
    {
        public decimal USD { get; set; }
        public decimal UAH { get; set; }
        public int WalletId { get; set; }
        public virtual Wallet Wallet { get; set; } = null!;
    }
}
