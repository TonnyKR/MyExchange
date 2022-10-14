using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Domain.Entities
{
    public partial class WalletStatistic : BaseEntity
    {
        public decimal TotalCurrentCapital { get; set; }
        public decimal TotalAmoundEnrollment { get; set; }
        public decimal TotalAmoundWithdrawl { get; set; }
        public decimal TotalCurrentMargin { get; set; }
        public decimal TotalClosedMargin { get; set; }
        public int WalletId { get; set; }
        public virtual Wallet Wallet { get; set; } = null!;
    }
}
