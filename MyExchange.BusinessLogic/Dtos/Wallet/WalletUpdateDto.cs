using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Dtos.Wallet
{
    public class WalletUpdateDto
    {
        [DataType(DataType.Currency)]
        public decimal? Balance { get; set; }
        [DataType(DataType.Currency)]
        public decimal? TotalPositionsCost { get; set; }
        [DataType(DataType.Currency)]
        public decimal? TotalEnrolment { get; set; }
        [DataType(DataType.Currency)]
        public decimal? TotalWithdrawl { get; set; }
        [DataType(DataType.Currency)]
        public decimal? TotalCurrentMargin { get; set; }
    }
}
