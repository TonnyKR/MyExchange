using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Dtos.Wallet
{
    public class WalletUpdateDto
    {
        public decimal? Balance { get; set; }
        public decimal? TotalCurrentCapital { get; set; }
        public decimal? TotalEnrolment { get; set; }
        public decimal? TotalWithdrawl { get; set; }
        public decimal? TotalCurrentMargin { get; set; }
        public decimal? TotalClosedMargin { get; set; }
    }
}
