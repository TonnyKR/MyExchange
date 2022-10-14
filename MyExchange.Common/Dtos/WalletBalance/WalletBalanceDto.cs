using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Common.Dtos.WalletBalance
{
    public class WalletBalanceDto
    {
        public int Id { get; set; }
        public decimal USD { get; set; } = 0;
        public decimal UAH { get; set; } = 0;
        public int WalletId { get; set; }
    }
}
